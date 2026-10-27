using Kit_Fitness.Forms;
using Kit_Fitness.Helpers;
using Kit_Fitness.Models;
using Kit_Fitness.Repositories;
using Kit_Fitness.Services;

namespace Kit_Fitness.UserControls
{
    public partial class ucDiary : UserControl
    {
        private DateOnly _currentDate = DateOnly.FromDateTime(DateTime.Now);
        private readonly DailyLogRepository _dailyLogRepo = new();
        private readonly DashboardService _dashboardService = new();
        private readonly MealLogService _mealLogService = new();
        private readonly UserProfileService _profileService = new();
        private readonly HashSet<string> _expandedSlots = new();

        public event EventHandler? OnQuickLogRequested;

        private readonly (string slot, string mealName)[] _standardSlots = new[]
        {
            ("07:00", "Bữa sáng sớm"),
            ("08:30", "Cà phê & ăn nhẹ"),
            ("10:00", "Bữa phụ sáng"),
            ("12:00", "Bữa trưa"),
            ("14:30", "Bữa phụ chiều"),
            ("16:30", "Năng lượng trước tập"),
            ("19:00", "Bữa tối")
        };

        public ucDiary()
        {
            InitializeComponent();
            WireEvents();
            LoadData();
        }

        private void WireEvents()
        {
            btnPrevDay.Click += (s, e) =>
            {
                _currentDate = _currentDate.AddDays(-1);
                LoadData();
            };

            btnNextDay.Click += (s, e) =>
            {
                _currentDate = _currentDate.AddDays(1);
                LoadData();
            };

            btnPickDate.Click += (s, e) =>
            {
                using var dtpForm = new Form
                {
                    Text = "Chọn ngày xem nhật ký",
                    Size = new Size(260, 260),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                };
                var cal = new MonthCalendar
                {
                    Dock = DockStyle.Fill,
                    MaxSelectionCount = 1,
                    SelectionStart = _currentDate.ToDateTime(TimeOnly.MinValue)
                };
                cal.DateSelected += (cs, ce) =>
                {
                    _currentDate = DateOnly.FromDateTime(ce.Start);
                    dtpForm.Close();
                    LoadData();
                };
                dtpForm.Controls.Add(cal);
                dtpForm.ShowDialog();
            };

            btnQuickLog.Click += (s, e) =>
            {
                using var dlg = new frmQuickLogMeal(logDate: _currentDate);
                var owner = FindForm();
                var result = owner is null ? dlg.ShowDialog() : dlg.ShowDialog(owner);
                if (result == DialogResult.OK)
                {
                    LoadData();
                }
            };

            btnAiSnap.Click += (s, e) =>
            {
                using var dlg = new frmAiMealLog(_currentDate);
                var owner = FindForm();
                var result = owner is null ? dlg.ShowDialog() : dlg.ShowDialog(owner);
                if (result == DialogResult.OK)
                {
                    LoadData();
                }
            };

            // Vẽ đường timeline dọc
            pnlTimelineList.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(225, 220, 210), 2);
                e.Graphics.DrawLine(pen, 20, 0, 20, pnlTimelineList.Height);
            };

            pnlLeftTimeline.Resize += (s, e) => UpdateTimelineLayout();
            UpdateTimelineLayout();
        }

        private void UpdateTimelineLayout()
        {
            if (pnlLeftTimeline.ClientSize.Width <= 0)
            {
                return;
            }

            pnlTimelineList.Width = Math.Max(0, pnlLeftTimeline.ClientSize.Width - 10);

            foreach (Control item in pnlTimelineList.Controls)
            {
                item.Width = Math.Max(0, pnlTimelineList.ClientSize.Width - 10);
            }

            lblTimelineSub.Location = new Point(
                lblTimelineTitle.Right + 20,
                lblTimelineTitle.Top + 2);
        }

        private void OpenQuickLog(string timeSlot, string mealType)
        {
            using var dlg = new frmQuickLogMeal(timeSlot, mealType, _currentDate);
            var owner = FindForm();
            var result = owner is null ? dlg.ShowDialog() : dlg.ShowDialog(owner);
            if (result == DialogResult.OK)
            {
                LoadData();
            }
        }

        // **
        public void LoadData()
        {
            try
            {
                long userId = AppSession.CurrentUserId;
                var today = DateOnly.FromDateTime(DateTime.Now);

                if (_currentDate == today)
                {
                    lblSelectedDate.Text = $"Hôm nay, {_currentDate:dd} Thg {_currentDate:MM}";
                }
                else
                {
                    lblSelectedDate.Text = $"{_currentDate:dd/MM/yyyy}";
                }

                // Load summary từ DB thật
                var nutrition = _dashboardService.GetDailyNutrition(userId, _currentDate);
                lblCaloriesSummary.Text = $"{nutrition.CaloriesConsumed} / {nutrition.TargetCalories} Kcal";

                int pct = nutrition.TargetCalories > 0 ? (int)(nutrition.CaloriesConsumed * 100.0 / nutrition.TargetCalories) : 0;
                progressCalories.Value = Math.Min(100, Math.Max(0, pct));

                lblProteinVal.Text = $"{nutrition.ProteinConsumed}g";
                lblProteinTarget.Text = $"/ {nutrition.ProteinTarget}g";

                lblCarbsVal.Text = $"{nutrition.CarbsConsumed}g";
                lblCarbsTarget.Text = $"/ {nutrition.CarbsTarget}g";

                lblFatVal.Text = $"{nutrition.FatConsumed}g";
                lblFatTarget.Text = $"/ {nutrition.FatTarget}g";

                // Cập nhật huy hiệu trạng thái dinh dưỡng
                int remaining = nutrition.TargetCalories - nutrition.CaloriesConsumed;
                if (remaining < 0)
                {
                    lblStatusBadge.Text = "VƯỢT CHỈ TIÊU NGÀY";
                    lblStatusBadge.ForeColor = Color.FromArgb(198, 40, 40);
                }
                else if (remaining < nutrition.TargetCalories * 0.20)
                {
                    lblStatusBadge.Text = "GẦN ĐẠT MỤC TIÊU";
                    lblStatusBadge.ForeColor = Color.FromArgb(230, 81, 0);
                }
                else
                {
                    lblStatusBadge.Text = "TƯƠI LÀNH VÀ CÂN BẰNG";
                    lblStatusBadge.ForeColor = Color.FromArgb(46, 125, 50);
                }

                // Build timeline hiển thị các món ăn theo mốc giờ
                BuildTimeline(userId);
            }
            catch (Exception)
            {
                lblCaloriesSummary.Text = "0 / 1450 Kcal";
            }
        }

        // **
        private void BuildTimeline(long userId)
        {
            pnlTimelineList.Controls.Clear();
            pnlTimelineList.SuspendLayout();

            var logs = _dailyLogRepo.GetByUserAndDate(userId, _currentDate);
            var nutrition = _dashboardService.GetDailyNutrition(userId, _currentDate);
            int remainingDailyCal = nutrition.TargetCalories - nutrition.CaloriesConsumed;

            int yPos = 0;

            foreach (var (slot, defaultMealName) in _standardSlots)
            {
                // Lấy tất cả các món ăn thuộc mốc giờ này từ DB
                var matchingLogs = logs.Where(l =>
                    l.LogItems.Any(li => !li.IsDeleted && li.TimeSlot == slot) ||
                    l.MealType.Equals(defaultMealName, StringComparison.OrdinalIgnoreCase) ||
                    l.MealType.Contains(defaultMealName, StringComparison.OrdinalIgnoreCase)).ToList();

                var itemsInSlot = matchingLogs
                    .SelectMany(l => l.LogItems)
                    .Where(li => !li.IsDeleted && (
                        li.TimeSlot == slot ||
                        matchingLogs.Any(ml => ml.MealType.Contains(defaultMealName, StringComparison.OrdinalIgnoreCase))))
                    .DistinctBy(li => li.Id)
                    .ToList();

                if (itemsInSlot.Count > 0)
                {
                    // Hiển thị Card bữa ăn có món
                    var card = CreateActiveMealCard(slot, defaultMealName, itemsInSlot, remainingDailyCal, userId);
                    card.Location = new Point(0, yPos);
                    card.Width = pnlTimelineList.Width - 10;
                    pnlTimelineList.Controls.Add(card);
                    yPos += card.Height + 14;
                }
                else
                {
                    // Hiển thị thanh mốc giờ trống
                    var slotBar = CreateEmptySlotBar(slot, defaultMealName);
                    slotBar.Location = new Point(0, yPos);
                    slotBar.Width = pnlTimelineList.Width - 10;
                    pnlTimelineList.Controls.Add(slotBar);
                    yPos += slotBar.Height + 10;
                }
            }

            pnlTimelineList.Height = yPos + 30;
            pnlTimelineList.ResumeLayout(true);
            pnlTimelineList.Invalidate();
        }

        // **
        private Panel CreateActiveMealCard(string slot, string mealName, List<LogItem> items, int remainingCalories, long userId)
        {
            var pnl = new Panel
            {
                BackColor = Color.White,
                Padding = new Padding(16, 12, 16, 12),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            // Điểm tròn xanh trên đường timeline
            var pnlDot = new Panel
            {
                Location = new Point(13, 16),
                Size = new Size(14, 14),
                BackColor = Color.FromArgb(41, 75, 54)
            };
            // Bo tròn điểm
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 14, 14);
            pnlDot.Region = new Region(path);

            // Tiêu đề mốc giờ và bữa ăn
            var lblTime = new Label
            {
                Text = $"{slot} {mealName}",
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 40, 35),
                Location = new Point(34, 12),
                AutoSize = true
            };

            var lblItemsCount = new Label
            {
                Text = $"{items.Count} món ăn đã nạp",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(130, 130, 125),
                Location = new Point(34, 34),
                AutoSize = true
            };

            int mealCalories = items.Sum(i => (int)((i.Food?.Calories ?? 0) * (i.Quantity / 100m)));
            var lblCal = new Label
            {
                Text = $"{mealCalories}",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 40, 35),
                Location = new Point(pnl.Width - 110, 8),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                AutoSize = true
            };

            var lblKcalUnit = new Label
            {
                Text = "Kcal",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(130, 130, 125),
                Location = new Point(0, 18),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                AutoSize = true
            };

            void PositionCalorieLabels()
            {
                lblKcalUnit.Location = new Point(
                    pnl.ClientSize.Width - pnl.Padding.Right - lblKcalUnit.Width,
                    18);

                lblCal.Location = new Point(
                    lblKcalUnit.Left - 6 - lblCal.Width,
                    8);
            }

            pnl.Resize += (s, e) => PositionCalorieLabels();

            pnl.Controls.Add(pnlDot);
            pnl.Controls.Add(lblTime);
            pnl.Controls.Add(lblItemsCount);
            pnl.Controls.Add(lblCal);
            pnl.Controls.Add(lblKcalUnit);
            PositionCalorieLabels();

            int itemY = 62;
            const int displayLimit = 2; // Số món hiển thị mặc định trước khi hiện nút "Xem tiếp"
            bool isExpanded = _expandedSlots.Contains(slot);
            bool hasTooMany = items.Count > displayLimit;

            var itemsToRender = (!hasTooMany || isExpanded) ? items : items.Take(displayLimit).ToList();

            foreach (var item in itemsToRender)
            {
                int itemCal = (int)((item.Food?.Calories ?? 0) * (item.Quantity / 100m));

                // Traffic light indicator cho từng món ăn từ DB (hoặc tính toán nếu dữ liệu cũ chưa có)
                string light = item.TrafficLight?.Trim().ToUpperInvariant() ?? "";
                if (string.IsNullOrEmpty(light))
                {
                    light = _mealLogService.CalculateTrafficLight(itemCal, remainingCalories);
                }

                Color dotColor;
                string dotTooltip;
                if (light == "RED")
                {
                    dotColor = Color.FromArgb(229, 57, 53);
                    dotTooltip = $"ĐỎ: Chiếm nhiều calo (Món này: {itemCal} cal / Còn lại: {remainingCalories} cal)";
                }
                else if (light == "YELLOW")
                {
                    dotColor = Color.FromArgb(255, 179, 0);
                    dotTooltip = $"VÀNG: Cân nhắc năng lượng (Món này: {itemCal} cal / Còn lại: {remainingCalories} cal)";
                }
                else
                {
                    dotColor = Color.FromArgb(67, 160, 71);
                    dotTooltip = $"XANH: Tươi lành & cân bằng (Món này: {itemCal} cal / Còn lại: {remainingCalories} cal)";
                }

                string unit = string.IsNullOrEmpty(item.Food?.Unit) ? "g" : item.Food.Unit;
                string qtyStr = unit == "g" ? $"{(int)item.Quantity}g" : $"{(int)item.Quantity}{unit}";

                var lblFood = new Label
                {
                    Text = $"• {item.Food?.Name ?? "Món ăn"} ({qtyStr})",
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.FromArgb(50, 60, 55),
                    Location = new Point(34, itemY),
                    AutoSize = true
                };

                var pnlDotLight = new Panel
                {
                    Size = new Size(14, 14),
                    Location = new Point(pnl.Width - 170, itemY + 5),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    BackColor = Color.Transparent,
                    Cursor = Cursors.Hand
                };
                pnlDotLight.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    using var brush = new SolidBrush(dotColor);
                    e.Graphics.FillEllipse(brush, 1, 1, 11, 11);
                };

                var lblItemCal = new Label
                {
                    Text = $"{itemCal} cal",
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(80, 80, 80),
                    Location = new Point(pnl.Width - 145, itemY),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    AutoSize = true
                };

                var btnTrash = new Button
                {
                    Text = "🗑",
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    ForeColor = Color.FromArgb(180, 80, 80),
                    Location = new Point(pnl.Width - 45, itemY - 2),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    Size = new Size(30, 26),
                    Cursor = Cursors.Hand
                };

                long itemId = item.Id;
                btnTrash.Click += (s, e) =>
                {
                    _mealLogService.RemoveLogItem(itemId);
                    LoadData();
                };

                pnl.Controls.Add(lblFood);
                pnl.Controls.Add(pnlDotLight);
                pnl.Controls.Add(lblItemCal);
                pnl.Controls.Add(btnTrash);

                itemY += 28;
            }

            // Nếu có nhiều món quá thì hiển thị nút "Xem tiếp" hoặc "Thu gọn"
            if (hasTooMany)
            {
                var lnkToggle = new LinkLabel
                {
                    Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold),
                    LinkBehavior = LinkBehavior.HoverUnderline,
                    Location = new Point(34, itemY),
                    AutoSize = true,
                    Cursor = Cursors.Hand
                };

                if (!isExpanded)
                {
                    lnkToggle.Text = $"▼ Xem tiếp (+{items.Count - displayLimit} món nữa)";
                    lnkToggle.LinkColor = Color.FromArgb(41, 75, 54);
                    lnkToggle.LinkClicked += (s, e) =>
                    {
                        _expandedSlots.Add(slot);
                        BuildTimeline(userId);
                    };
                }
                else
                {
                    lnkToggle.Text = "▲ Thu gọn danh sách món";
                    lnkToggle.LinkColor = Color.FromArgb(130, 130, 125);
                    lnkToggle.LinkClicked += (s, e) =>
                    {
                        _expandedSlots.Remove(slot);
                        BuildTimeline(userId);
                    };
                }

                pnl.Controls.Add(lnkToggle);
                itemY += 26;
            }

            // Dòng Macros dinh dưỡng & nút Thêm món
            var pnlFooter = new Panel
            {
                Location = new Point(16, itemY + 8),
                Height = 36,
                Width = pnl.Width - 32,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.FromArgb(250, 248, 244)
            };

            decimal p = items.Sum(i => (i.Food?.Protein ?? 0) * (i.Quantity / 100m));
            decimal c = items.Sum(i => (i.Food?.Carbs ?? 0) * (i.Quantity / 100m));
            decimal f = items.Sum(i => (i.Food?.Fat ?? 0) * (i.Quantity / 100m));

            var lblMacros = new Label
            {
                Text = $"Đạm: {(int)p}g   Carb: {(int)c}g   Béo: {(int)f}g",
                Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(120, 100, 60),
                Location = new Point(12, 9),
                AutoSize = true
            };

            var btnAddMore = new LinkLabel
            {
                Text = "+ Thêm món",
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                LinkColor = Color.FromArgb(34, 76, 56),
                LinkBehavior = LinkBehavior.HoverUnderline,
                Location = new Point(pnlFooter.Width - 95, 9),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                AutoSize = true,
                Cursor = Cursors.Hand
            };
            btnAddMore.LinkClicked += (s, e) => OpenQuickLog(slot, mealName);

            pnlFooter.Controls.Add(lblMacros);
            pnlFooter.Controls.Add(btnAddMore);
            pnl.Controls.Add(pnlFooter);

            pnl.Height = itemY + 54;
            return pnl;
        }

        private Panel CreateEmptySlotBar(string slot, string mealName)
        {
            var pnl = new Panel
            {
                BackColor = Color.White,
                Height = 48,
                Padding = new Padding(16, 10, 16, 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            // Vòng tròn rỗng trên đường timeline
            var pnlHollowDot = new Panel
            {
                Location = new Point(14, 17),
                Size = new Size(12, 12),
                BackColor = Color.Transparent
            };
            pnlHollowDot.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(180, 175, 165), 2);
                e.Graphics.DrawEllipse(pen, 1, 1, 9, 9);
            };

            var lblDotTime = new Label
            {
                Text = $"{slot}   {mealName}",
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(120, 120, 115),
                Location = new Point(34, 13),
                AutoSize = true
            };

            var btnAdd = new Button
            {
                Text = "+",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 76, 56),
                BackColor = Color.FromArgb(245, 245, 240),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Location = new Point(pnl.Width - 45, 8),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Size = new Size(32, 32),
                Cursor = Cursors.Hand
            };
            btnAdd.Click += (s, e) => OpenQuickLog(slot, mealName);

            pnl.Controls.Add(pnlHollowDot);
            pnl.Controls.Add(lblDotTime);
            pnl.Controls.Add(btnAdd);
            return pnl;
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
