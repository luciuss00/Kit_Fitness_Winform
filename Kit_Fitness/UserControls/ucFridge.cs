using Kit_Fitness.Forms;
using Kit_Fitness.Helpers;
using Kit_Fitness.Services;
using Kit_Fitness.DTOs;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Kit_Fitness.UserControls
{
    public partial class ucFridge : UserControl
    {
        private const int CardGap = 16;
        private const int InitialFridgeItemsToShow = 3;
        private const int FridgeItemsPerPage = 3;
        private readonly FridgeService _fridgeService = new();
        private readonly MealLogService _mealLogService = new();
        private readonly GeminiService _geminiService = new();
        private readonly DashboardService _dashboardService = new();

        private Panel? _pnlAiInfoBanner;
        private readonly List<Panel> _aiCardPanels = new();
        private int _visibleChillItems = InitialFridgeItemsToShow;
        private int _visibleFreezerItems = InitialFridgeItemsToShow;
        private readonly (string slot, string mealName)[] _diarySlots =
        {
            ("07:00", "Bữa Sáng Sớm"),
            ("08:30", "Cà Phê & Ăn Nhẹ"),
            ("10:00", "Bữa Phụ Sáng"),
            ("12:00", "Bữa Trưa"),
            ("14:30", "Bữa Phụ Chiều"),
            ("16:30", "Năng Lượng Trước Tập"),
            ("19:00", "Bữa Tối")
        };

        public ucFridge()
        {
            InitializeComponent();

            pnlChillCol.AutoScroll = true;
            pnlFreezerCol.AutoScroll = true;

            flpSuggestions.AutoScroll = false;
            flpSuggestions.AutoSize = true;
            flpSuggestions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpSuggestions.WrapContents = true;
            flpSuggestions.FlowDirection = FlowDirection.LeftToRight;
            FitSuggestionsWidth();
            pnlSuggestionsTab.AutoSize = true;
            pnlSuggestionsTab.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpSuggestions.Dock = DockStyle.Top;
            flpSuggestions.Margin = Padding.Empty;
            flpSuggestions.Padding = new Padding(0, 0, 0, 24);

            pnlSuggestionsTab.Resize += (s, e) => UpdateSuggestionsLayout();
            pnlContentHolder.Resize += (s, e) => UpdateSuggestionsLayout();
            Resize += (s, e) => UpdateSuggestionsLayout();

            WireEvents();
            SwitchToTab(true);
            LoadData();
        }

        private void WireEvents()
        {
            btnTabFridge.Click += (s, e) => SwitchToTab(true);
            btnTabSuggestions.Click += (s, e) => SwitchToTab(false);

            btnManualAdd.Click += (s, e) => OpenAddItemDialog("CHILL");
            btnCookNow.Click += (s, e) => SwitchToTab(false);

            btnScanReceipt.Click += (s, e) =>
            {
                using var dlg = new frmScanReceipt();
                dlg.ShowDialog(FindForm());
                LoadData();
            };

            btnRefreshAi.Click += async (s, e) =>
            {
                await LoadAiSuggestionsAsync();
            };
        }

        private void FitSuggestionsWidth()
        {
            var parent = flpSuggestions.Parent;
            if (parent == null) return;

            if (parent is ScrollableControl sc) sc.AutoScrollPosition = new Point(0, 0);

            flpSuggestions.Dock = DockStyle.Top;
            flpSuggestions.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            flpSuggestions.Margin = Padding.Empty;
            flpSuggestions.Padding = new Padding(0, 0, 0, 24); // khoảng đệm đáy
            flpSuggestions.MaximumSize = new Size(parent.ClientSize.Width, 0);
            flpSuggestions.Left = 0;
            UpdateSuggestionsLayout();
        }

        private void UpdateSuggestionsLayout()
        {
            var parent = flpSuggestions.Parent;
            if (parent == null) return;

            int availableWidth = parent.ClientSize.Width;
            if (availableWidth <= 0) return;

            flpSuggestions.SuspendLayout();
            flpSuggestions.Width = availableWidth;
            flpSuggestions.MaximumSize = new Size(availableWidth, 0);

            // 1. Label màu xanh thông tin calo sát với mép 2 bên panel
            if (_pnlAiInfoBanner != null)
            {
                _pnlAiInfoBanner.Width = availableWidth;
                _pnlAiInfoBanner.Margin = new Padding(0, 0, 0, 12);
            }

            // 2. Chiều dài card cho sát với mép panel gợi ý bữa cơm
            if (_aiCardPanels.Count > 0)
            {
                int gap = CardGap; // 16
                if (availableWidth >= 800)
                {
                    // 2 cột: Cột trái margin-right = gap; Cột phải margin-right = 0
                    // Cột 1 + gap + Cột 2 = availableWidth -> sát khít mép panel, không có khoảng hở bên phải
                    int col1Width = (availableWidth - gap) / 2;
                    int col2Width = availableWidth - col1Width - gap;

                    for (int i = 0; i < _aiCardPanels.Count; i++)
                    {
                        var card = _aiCardPanels[i];
                        if (i % 2 == 0)
                        {
                            card.Width = col1Width;
                            card.Margin = new Padding(0, 0, gap, gap);
                        }
                        else
                        {
                            card.Width = col2Width;
                            card.Margin = new Padding(0, 0, 0, gap);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < _aiCardPanels.Count; i++)
                    {
                        var card = _aiCardPanels[i];
                        card.Width = availableWidth;
                        card.Margin = new Padding(0, 0, 0, gap);
                    }
                }
            }

            flpSuggestions.ResumeLayout(true);

        }

        private void SwitchToTab(bool isFridgeTab)
        {
            pnlFridgeTab.Visible = isFridgeTab;
            pnlSuggestionsTab.Visible = !isFridgeTab;

            if (isFridgeTab)
            {
                btnTabFridge.BackColor = Color.White;
                btnTabFridge.ForeColor = Color.FromArgb(34, 76, 56);
                btnTabSuggestions.BackColor = Color.FromArgb(240, 236, 228);
                btnTabSuggestions.ForeColor = Color.FromArgb(100, 100, 95);
            }
            else
            {
                btnTabSuggestions.BackColor = Color.White;
                btnTabSuggestions.ForeColor = Color.FromArgb(34, 76, 56);
                btnTabFridge.BackColor = Color.FromArgb(240, 236, 228);
                btnTabFridge.ForeColor = Color.FromArgb(100, 100, 95);

                // Không tự động gọi API Gemini khi vào tab.
                // Chỉ hiển thị panel chờ nếu chưa từng bấm nút gợi ý lần nào.
                if (_aiCardPanels.Count == 0 && flpSuggestions.Controls.Count == 0)
                {
                    ShowEmptyAiPromptPanel();
                }
            }
        }

        private void OpenAddItemDialog(string defaultStorage)
        {
            using var dlg = new frmAddFridgeItem(defaultStorage);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private int GetCardWidth()
        {
            int available = pnlSuggestionsTab.ClientSize.Width > 0 ? pnlSuggestionsTab.ClientSize.Width : flpSuggestions.MaximumSize.Width;
            if (available <= 0) available = 1150;
            return Math.Max(400, (available - CardGap) / 2);
        }

        // **
        public void LoadData()
        {
            try
            {
                long userId = AppSession.CurrentUserId;
                var allItems = _fridgeService.GetAllItems(userId);

                // Update tab title with count
                btnTabFridge.Text = $"🧊 Tủ Lạnh Của Tôi ({allItems.Count})";

                var chillItems = allItems.Where(i => i.StorageType == "CHILL" || i.StorageType == "ROOM").ToList();
                var freezerItems = allItems.Where(i => i.StorageType == "FREEZER" || i.StorageType == "FREEZE").ToList();

                lblChillBadge.Text = $"{chillItems.Count} món";
                lblFreezerBadge.Text = $"{freezerItems.Count} món";

                // Expiry warnings
                var expiring = allItems.Where(i => i.DaysRemaining <= 3 && i.DaysRemaining >= 0).ToList();
                var expired = allItems.Where(i => i.DaysRemaining < 0).ToList();

                if (expiring.Count > 0 || expired.Count > 0)
                {
                    pnlWarningBanner.Visible = true;
                    lblWarningText.Text = $"{expiring.Count} món sắp hết hạn (1-3 ngày). {expired.Count} món đã quá hạn.";
                }
                else
                {
                    pnlWarningBanner.Visible = false;
                }

                // Render Chill list
                RenderCardsList(pnlChillItems, chillItems, isChill: true);

                // Render Freezer list
                RenderCardsList(pnlFreezerItems, freezerItems, isChill: false);
            }
            catch
            {
                // Fallback demo layout
            }
        }

        private void RenderCardsList(Panel container, List<FridgeItemDisplay> items, bool isChill)
        {
            container.Controls.Clear();
            container.SuspendLayout();

            int visibleCount = isChill ? _visibleChillItems : _visibleFreezerItems;
            var visibleItems = items.Take(visibleCount).ToList();
            int yPos = 0;
            foreach (var item in visibleItems)
            {
                var card = CreateItemCard(item, isChill);
                card.Location = new Point(0, yPos);
                card.Width = container.Width;
                container.Controls.Add(card);
                yPos += card.Height + 10;
            }

            if (items.Count > InitialFridgeItemsToShow)
            {
                bool hasMoreItems = visibleItems.Count < items.Count;
                var btnShowMore = new Button
                {
                    Text = hasMoreItems
                        ? $"Xem tiếp ({Math.Min(FridgeItemsPerPage, items.Count - visibleItems.Count)})"
                        : "Thu gọn",
                    Location = new Point(0, yPos),
                    Size = new Size(130, 34),
                    BackColor = Color.FromArgb(240, 245, 240),
                    ForeColor = Color.FromArgb(34, 76, 56),
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderColor = Color.FromArgb(180, 210, 190) },
                    Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnShowMore.Click += (s, e) =>
                {
                    if (isChill)
                    {
                        _visibleChillItems = hasMoreItems
                            ? Math.Min(items.Count, _visibleChillItems + FridgeItemsPerPage)
                            : InitialFridgeItemsToShow;
                    }
                    else
                    {
                        _visibleFreezerItems = hasMoreItems
                            ? Math.Min(items.Count, _visibleFreezerItems + FridgeItemsPerPage)
                            : InitialFridgeItemsToShow;
                    }

                    RenderCardsList(container, items, isChill);
                };
                container.Controls.Add(btnShowMore);
                yPos += btnShowMore.Height + 10;
            }

            container.Height = yPos + 10;
            container.ResumeLayout(true);
        }

        // **
        private Panel CreateItemCard(FridgeItemDisplay item, bool isChill)
        {
            var pnl = new Panel
            {
                BackColor = Color.White,
                Height = 84,
                Padding = new Padding(12),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            // Days status badge
            var lblDays = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 7.8F, FontStyle.Bold),
                Location = new Point(12, 12)
            };

            if (item.DaysRemaining < 0)
            {
                lblDays.Text = "Đã quá hạn";
                lblDays.BackColor = Color.FromArgb(255, 235, 235);
                lblDays.ForeColor = Color.FromArgb(200, 50, 50);
            }
            else if (item.DaysRemaining <= 2)
            {
                lblDays.Text = $"Còn {item.DaysRemaining} ngày (Nấu ngay)";
                lblDays.BackColor = Color.FromArgb(255, 245, 225);
                lblDays.ForeColor = Color.FromArgb(190, 110, 20);
            }
            else
            {
                lblDays.Text = $"Còn {item.DaysRemaining} ngày";
                lblDays.BackColor = Color.FromArgb(235, 248, 235);
                lblDays.ForeColor = Color.FromArgb(40, 120, 60);
            }
            lblDays.Padding = new Padding(4, 2, 4, 2);

            // Storage Tag (Mát / Đá)
            var lblTag = new Label
            {
                Text = isChill ? "🍃 Mát" : "❄ Đá",
                Font = new Font("Segoe UI", 7.5F),
                ForeColor = isChill ? Color.FromArgb(34, 112, 68) : Color.FromArgb(50, 100, 180),
                BackColor = isChill ? Color.FromArgb(240, 248, 240) : Color.FromArgb(240, 245, 255),
                Location = new Point(lblDays.Right + 60, 12),
                AutoSize = true,
                Padding = new Padding(4, 2, 4, 2)
            };

            // Food Name
            var lblStatusDot = new Label
            {
                Text = "●",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = item.DaysRemaining < 0
                    ? Color.FromArgb(190, 65, 45)
                    : item.DaysRemaining <= 2
                        ? Color.FromArgb(220, 165, 45)
                        : Color.FromArgb(0, 175, 135),
                Location = new Point(12, 32),
                AutoSize = true
            };

            var lblName = new Label
            {
                Text = item.FoodName,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 40, 35),
                Location = new Point(30, 34),
                AutoSize = true
            };

            // Quantity & Expiry info
            var lblMeta = new Label
            {
                Text = $"Số lượng: {(int)item.Quantity} {item.Unit}  •  Hạn: {(item.ExpiryDate.HasValue ? item.ExpiryDate.Value.ToString("yyyy-MM-dd") : "Không rõ")}",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(120, 120, 115),
                Location = new Point(30, 58),
                AutoSize = true
            };

            // Action Buttons
            int btnX = pnl.Width - 40;

            // Delete button 🗑
            var btnDelete = new Button
            {
                Text = "🗑",
                Size = new Size(30, 28),
                Location = new Point(btnX, 28),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                ForeColor = Color.FromArgb(160, 160, 160),
                Cursor = Cursors.Hand
            };
            btnDelete.Click += (s, e) =>
            {
                _fridgeService.RemoveItem(item.Id);
                LoadData();
            };

            // Use button [- Dùng]
            var btnUse = new Button
            {
                Text = "— Dùng",
                Size = new Size(80, 28),
                Location = new Point(btnX - 83, 28),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderColor = Color.FromArgb(220, 215, 205) },
                BackColor = Color.FromArgb(250, 248, 245),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(60, 70, 65),
                Cursor = Cursors.Hand
            };
            btnUse.Click += (s, e) =>
            {
                if (PromptUsageQuantity(item, out decimal quantityUsed))
                {
                    _fridgeService.UseItem(item.Id, quantityUsed);
                    LoadData();
                }
            };

            // Toggle storage button [❄️ Sang đá / 🍃 Sang mát]
            var btnToggle = new Button
            {
                Text = isChill ? "❄ Sang đá" : "🍃 Sang mát",
                Size = new Size(110, 28),
                Location = new Point(btnX - 188, 28),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderColor = Color.FromArgb(210, 225, 240) },
                BackColor = isChill ? Color.FromArgb(245, 250, 255) : Color.FromArgb(245, 255, 245),
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = isChill ? Color.FromArgb(40, 100, 180) : Color.FromArgb(34, 112, 68),
                Cursor = Cursors.Hand
            };
            btnToggle.Click += (s, e) =>
            {
                _fridgeService.ToggleStorage(item.Id);
                LoadData();
            };

            pnl.Controls.Add(lblDays);
            pnl.Controls.Add(lblTag);
            pnl.Controls.Add(lblStatusDot);
            pnl.Controls.Add(lblName);
            pnl.Controls.Add(lblMeta);
            pnl.Controls.Add(btnToggle);
            pnl.Controls.Add(btnUse);
            pnl.Controls.Add(btnDelete);

            lblDays.BringToFront();
            lblTag.BringToFront();

            return pnl;
        }

        private bool PromptUsageQuantity(FridgeItemDisplay item, out decimal quantityUsed)
        {
            quantityUsed = 0;

            using var dialog = new Form
            {
                Text = "Số lượng sử dụng",
                ClientSize = new Size(320, 145),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false,
                Font = new Font("Segoe UI", 9F)
            };

            var label = new Label
            {
                AutoSize = true,
                Text = $"Nhập số lượng muốn dùng ({item.Unit}):",
                Location = new Point(20, 18)
            };

            var quantityInput = new NumericUpDown
            {
                DecimalPlaces = 2,
                Increment = 0.5M,
                Minimum = 0.01M,
                Maximum = item.Quantity,
                Value = Math.Min(1M, item.Quantity),
                Location = new Point(20, 48),
                Size = new Size(280, 30)
            };

            var cancelButton = new Button
            {
                Text = "Hủy",
                DialogResult = DialogResult.Cancel,
                Location = new Point(125, 95),
                Size = new Size(80, 30)
            };

            var confirmButton = new Button
            {
                Text = "Dùng",
                DialogResult = DialogResult.OK,
                Location = new Point(220, 95),
                Size = new Size(80, 30)
            };

            dialog.Controls.Add(label);
            dialog.Controls.Add(quantityInput);
            dialog.Controls.Add(cancelButton);
            dialog.Controls.Add(confirmButton);
            dialog.AcceptButton = confirmButton;
            dialog.CancelButton = cancelButton;

            if (dialog.ShowDialog(FindForm()) != DialogResult.OK)
            {
                return false;
            }

            quantityUsed = quantityInput.Value;
            return true;
        }

        private void ShowEmptyAiPromptPanel()
        {
            FitSuggestionsWidth();
            flpSuggestions.Controls.Clear();

            var pnlEmpty = new Panel
            {
                Size = new Size(Math.Max(500, flpSuggestions.ClientSize.Width - 40), 220),
                BackColor = Color.White,
                Padding = new Padding(24),
                Margin = new Padding(10, 20, 10, 20)
            };

            var lblIcon = new Label
            {
                Text = "👨‍🍳",
                Font = new Font("Segoe UI", 32F),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };

            var lblPrompt = new Label
            {
                Text = "Nhấn nút bên dưới hoặc nút '✨ Gợi ý lại bằng AI' ở trên\nđể Gemini AI phân tích nguyên liệu trong tủ lạnh và đề xuất thực đơn phù hợp cho bạn!",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(70, 80, 75),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 55
            };

            var btnStart = new Button
            {
                Text = "✨ Bắt đầu gợi ý món ăn bằng AI",
                Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold),
                BackColor = Color.FromArgb(41, 75, 54),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Size = new Size(280, 44),
                Cursor = Cursors.Hand
            };
            btnStart.Location = new Point((pnlEmpty.Width - btnStart.Width) / 2, 140);
            btnStart.Anchor = AnchorStyles.Top;
            btnStart.Click += async (s, e) => await LoadAiSuggestionsAsync();

            pnlEmpty.Controls.Add(btnStart);
            pnlEmpty.Controls.Add(lblPrompt);
            pnlEmpty.Controls.Add(lblIcon);

            flpSuggestions.Controls.Add(pnlEmpty);
        }

        // **
        private async Task LoadAiSuggestionsAsync()
        {
            btnRefreshAi.Enabled = false;
            FitSuggestionsWidth();
            flpSuggestions.Controls.Clear();

            // --- Hiển thị loading indicator ---
            var pnlLoading = new Panel
            {
                Size = new Size(flpSuggestions.MaximumSize.Width, 140),
                BackColor = Color.FromArgb(235, 248, 240),
                Margin = new Padding(0, 0, 0, 12)
            };

            var lblLoading = new Label
            {
                Text = "✨ Gemini AI đang phân tích tủ lạnh và tính toán calo...",
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 90, 60),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 70
            };

            var lblWait = new Label
            {
                Text = "Vui lòng chờ giây lát",
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(90, 120, 105),
                TextAlign = ContentAlignment.TopCenter,
                Dock = DockStyle.Top,
                Height = 28
            };

            var progress = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 30,
                Size = new Size(320, 6),
                Location = new Point((pnlLoading.Width - 320) / 2, 108),
                Anchor = AnchorStyles.Top
            };

            pnlLoading.Controls.Add(progress);
            pnlLoading.Controls.Add(lblWait);
            pnlLoading.Controls.Add(lblLoading);
            flpSuggestions.Controls.Add(pnlLoading);
            flpSuggestions.Refresh();


            try
            {
                long userId = AppSession.CurrentUserId;
                var today = DateOnly.FromDateTime(DateTime.Now);

                // Lấy nguyên liệu tủ lạnh (chỉ những thứ chưa hết hạn)
                var fridgeItems = _fridgeService.GetAllItems(userId)
                    .Where(i => i.DaysRemaining >= 0)
                    .ToList();

                // Lấy calo còn lại trong ngày
                var nutrition = _dashboardService.GetDailyNutrition(userId, today);
                int caloriesRemaining = Math.Max(100, nutrition.CaloriesRemaining + nutrition.CaloriesBurned);

                // Gọi Gemini AI
                var suggestions = await _geminiService.SuggestMealsAsync(
                    fridgeItems,
                    caloriesRemaining,
                    nutrition.TargetProtein - nutrition.TotalProtein,
                    nutrition.TargetCarbs - nutrition.TotalCarbs,
                    nutrition.TargetFat - nutrition.TotalFat
                );

                // Xóa loading, render card
                flpSuggestions.Controls.Clear();
                _aiCardPanels.Clear();

                // Banner thông tin calo
                var pnlInfo = new Panel
                {
                    Size = new Size(flpSuggestions.MaximumSize.Width, 44),
                    BackColor = Color.FromArgb(235, 248, 240),
                    Margin = new Padding(0, 0, 0, 12)
                };
                var lblInfo = new Label
                {
                    Text = $"🤖 Gemini AI gợi ý cho {caloriesRemaining} kcal còn lại hôm nay  •  {fridgeItems.Count} nguyên liệu trong tủ lạnh",
                    Font = new Font("Segoe UI", 8.5F),
                    ForeColor = Color.FromArgb(34, 90, 60),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pnlInfo.Controls.Add(lblInfo);
                _pnlAiInfoBanner = pnlInfo;
                flpSuggestions.Controls.Add(pnlInfo);
                flpSuggestions.SetFlowBreak(pnlInfo, true);

                foreach (var suggestion in suggestions)
                {
                    var card = CreateSuggestionCard(suggestion);
                    _aiCardPanels.Add(card);
                    flpSuggestions.Controls.Add(card);
                }

                btnRefreshAi.Text = "🔄 Đổi thực đơn khác (AI)";
                UpdateSuggestionsLayout();
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("API Key"))
            {
                flpSuggestions.Controls.Clear();
                ShowApiKeySetupPanel();
            }
            catch (Exception ex)
            {
                flpSuggestions.Controls.Clear();
                var pnlErr = new Panel { Size = new Size(560, 100), BackColor = Color.FromArgb(255, 245, 245) };
                var lblErr = new Label
                {
                    Text = $"⚠ Không kết nối được Gemini AI:\n{ex.Message}\n\nKiểm tra API Key và kết nối mạng.",
                    Font = new Font("Segoe UI", 8.8F),
                    ForeColor = Color.FromArgb(180, 50, 50),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pnlErr.Controls.Add(lblErr);
                flpSuggestions.Controls.Add(pnlErr);
            }
            finally
            {
                btnRefreshAi.Enabled = true;
            }
        }

        /// <summary>
        /// Hiển thị panel hướng dẫn cài API Key khi chưa cấu hình
        /// </summary>
        private void ShowApiKeySetupPanel()
        {
            var pnl = new Panel
            {
                Size = new Size(560, 240),
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            var lblTitle = new Label
            {
                Text = "🔑 Cần cấu hình Gemini API Key",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 76, 56),
                Location = new Point(20, 20),
                AutoSize = true
            };

            var lblSteps = new Label
            {
                Text =
                    "Hướng dẫn lấy API Key miễn phí:\n\n" +
                    "1. Truy cập: https://aistudio.google.com/\n" +
                    "2. Đăng nhập bằng tài khoản Google\n" +
                    "3. Bấm 'Get API Key' → 'Create API key'\n" +
                    "4. Copy key, mở file:\n" +
                    "   Kit_Fitness/Services/GeminiService.cs\n" +
                    "5. Thay 'YOUR_GEMINI_API_KEY' bằng key của bạn\n" +
                    "6. Build lại và thử lại!",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(20, 55),
                Size = new Size(520, 170)
            };

            var btnOpenUrl = new Button
            {
                Text = "🌐 Mở Google AI Studio",
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(34, 120, 75),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Location = new Point(20, 190),
                Size = new Size(200, 34),
                Cursor = Cursors.Hand
            };
            btnOpenUrl.Click += (s, e) =>
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://aistudio.google.com/",
                    UseShellExecute = true
                });
            };

            pnl.Controls.Add(lblTitle);
            pnl.Controls.Add(lblSteps);
            pnl.Controls.Add(btnOpenUrl);
            flpSuggestions.Controls.Add(pnl);
        }

        private Panel CreateSuggestionCard(AiMealSuggestion suggestion)
        {
            int w = GetCardWidth();
            int inner = w - 36;

            // Màu tag theo loại
            var (tagFg, tagBg) = suggestion.Tag switch
            {
                "GIÀU PROTEIN" => (Color.FromArgb(30, 90, 180), Color.FromArgb(235, 243, 255)),
                "TĂNG CƠ" => (Color.FromArgb(150, 60, 20), Color.FromArgb(255, 243, 235)),
                "TƯƠI LÀNH" => (Color.FromArgb(20, 120, 100), Color.FromArgb(235, 250, 245)),
                _ => (Color.FromArgb(34, 112, 68), Color.FromArgb(240, 248, 240))
            };

            var pnl = new Panel
            {
                BackColor = Color.White,
                Size = new Size(w, 230),
                Margin = new Padding(0, 0, CardGap, CardGap),
                Padding = new Padding(18)
            };

            var lblTag = new Label
            {
                Text = suggestion.Tag,
                Font = new Font("Segoe UI", 7.8F, FontStyle.Bold),
                ForeColor = tagFg,
                BackColor = tagBg,
                Location = new Point(18, 16),
                AutoSize = true,
                Padding = new Padding(6, 3, 6, 3)
            };

            var lblCal = new Label
            {
                Text = $"{suggestion.Calories} Kcal",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 76, 56),
                TextAlign = ContentAlignment.TopRight,
                AutoSize = false,
                Size = new Size(120, 26),
                Location = new Point(w - 18 - 120, 14),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            var lblTitle = new Label
            {
                Text = suggestion.Title,
                Font = new Font("Segoe UI", 11.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 40, 35),
                AutoEllipsis = true,
                Location = new Point(18, 48),
                Size = new Size(inner, 28),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            var lblDesc = new Label
            {
                Text = suggestion.Description,
                Font = new Font("Segoe UI", 8.8F),
                ForeColor = Color.FromArgb(100, 100, 95),
                Location = new Point(18, 78),
                Size = new Size(inner, 36),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            var lblServings = new Label
            {
                Text = suggestion.Servings,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(130, 125, 120),
                Location = new Point(18, 114),
                AutoSize = true
            };

            // Macros bar
            var pnlMacros = new Panel
            {
                BackColor = Color.FromArgb(250, 247, 240),
                Location = new Point(18, 138),
                Size = new Size(inner, 28),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            var lblMacroText = new Label
            {
                Text = $"Đạm: {suggestion.Protein}g   •   Carb: {suggestion.Carb}g   •   Béo: {suggestion.Fat}g",
                Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(110, 90, 50),
                Location = new Point(10, 5),
                AutoSize = true
            };
            pnlMacros.Controls.Add(lblMacroText);

            // Button Cook and Log
            var btnCook = new Button
            {
                Text = "Nấu & Ghi Nhận Bữa Này ›",
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 76, 56),
                BackColor = Color.FromArgb(245, 243, 237),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Location = new Point(18, 172),
                Size = new Size(inner, 42),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Cursor = Cursors.Hand
            };
            btnCook.Click += (s, e) => ShowCookingDialog(suggestion);

            pnl.Controls.Add(lblTag);
            pnl.Controls.Add(lblCal);
            pnl.Controls.Add(lblTitle);
            pnl.Controls.Add(lblDesc);
            pnl.Controls.Add(lblServings);
            pnl.Controls.Add(pnlMacros);
            pnl.Controls.Add(btnCook);

            return pnl;
        }

        /// <summary>
        /// Dialog hiển thị nguyên liệu + hướng dẫn nấu ăn do AI tạo ra,
        /// và cho phép ghi nhận bữa ăn vào nhật ký
        /// </summary>
        // **
        private void ShowCookingDialog(AiMealSuggestion suggestion)
        {
            var fridgeItems = _fridgeService.GetAllItems(AppSession.CurrentUserId)
                .Where(item => item.DaysRemaining >= 0)
                .ToList();
            var ingredientUsage = BuildIngredientUsage(suggestion, fridgeItems);

            using var dlg = new Form
            {
                Text = $"🍽 {suggestion.Title}",
                ClientSize = new Size(560, 520),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false,
                Font = new Font("Segoe UI", 9.5F),
                BackColor = Color.FromArgb(252, 250, 246)
            };

            int y = 18;

            // Header: tag + calories
            var lblTag = new Label
            {
                Text = suggestion.Tag,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 112, 68),
                BackColor = Color.FromArgb(235, 248, 235),
                Location = new Point(18, y),
                AutoSize = true,
                Padding = new Padding(6, 2, 6, 2)
            };
            var lblCal = new Label
            {
                Text = $"{suggestion.Calories} Kcal",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 76, 56),
                Location = new Point(420, y),
                AutoSize = true
            };
            dlg.Controls.Add(lblTag);
            dlg.Controls.Add(lblCal);
            y += 34;

            // Macros
            var lblMacro = new Label
            {
                Text = $"Đạm: {suggestion.Protein}g  •  Carb: {suggestion.Carb}g  •  Béo: {suggestion.Fat}g",
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(110, 90, 50),
                BackColor = Color.FromArgb(250, 247, 240),
                Location = new Point(18, y),
                Size = new Size(524, 28),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 0, 0)
            };
            dlg.Controls.Add(lblMacro);
            y += 38;

            var lblTimeTitle = new Label
            {
                Text = "Ghi vào mốc giờ:",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 76, 56),
                Location = new Point(18, y + 4),
                AutoSize = true
            };
            var cbTimeSlot = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(150, y),
                Size = new Size(392, 28)
            };
            foreach (var (slot, mealName) in _diarySlots)
            {
                cbTimeSlot.Items.Add($"{slot} - {mealName}");
            }
            cbTimeSlot.SelectedIndex = Array.FindIndex(_diarySlots, option =>
                TimeSpan.TryParse(option.slot, out var slotTime) && slotTime >= DateTime.Now.TimeOfDay);
            if (cbTimeSlot.SelectedIndex < 0)
            {
                cbTimeSlot.SelectedIndex = _diarySlots.Length - 1;
            }
            dlg.Controls.Add(lblTimeTitle);
            dlg.Controls.Add(cbTimeSlot);
            y += 38;

            // Nguyên liệu
            var lblIngTitle = new Label
            {
                Text = "📋 Nguyên liệu sẽ trừ khỏi tủ lạnh:",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 76, 56),
                Location = new Point(18, y),
                AutoSize = true
            };
            dlg.Controls.Add(lblIngTitle);
            y += 24;

            string ingText = suggestion.Ingredients.Count > 0
                ? string.Join("\n", suggestion.Ingredients.Select(ingredient =>
                {
                    var usage = ingredientUsage.FirstOrDefault(entry =>
                        entry.Ingredient.Equals(ingredient, StringComparison.Ordinal));
                    return usage.Item is not null
                        ? $"  • {usage.Item.FoodName}: {usage.Quantity:0.##} {usage.Item.Unit} sẽ được trừ"
                        : $"  • {ingredient} (không có trong tủ lạnh, không trừ)";
                }))
                : "  • AI không cung cấp danh sách nguyên liệu; không có nguyên liệu nào bị trừ.";
            var lblIng = new Label
            {
                Text = ingText,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(18, y),
                Size = new Size(524, Math.Max(60, suggestion.Ingredients.Count * 20 + 10)),
                AutoSize = false
            };
            dlg.Controls.Add(lblIng);
            y += lblIng.Height + 10;

            // Hướng dẫn nấu
            var lblStepTitle = new Label
            {
                Text = "👨‍🍳 Hướng dẫn nấu:",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 76, 56),
                Location = new Point(18, y),
                AutoSize = true
            };
            dlg.Controls.Add(lblStepTitle);
            y += 24;

            var txtSteps = new RichTextBox
            {
                Text = string.IsNullOrWhiteSpace(suggestion.CookingSteps)
                    ? "AI chưa cung cấp hướng dẫn chi tiết."
                    : suggestion.CookingSteps,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(40, 40, 40),
                BackColor = Color.White,
                Location = new Point(18, y),
                Size = new Size(524, 160),
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                ScrollBars = RichTextBoxScrollBars.Vertical
            };
            dlg.Controls.Add(txtSteps);
            y += 170;

            // Nút Ghi Nhận
            var btnLog = new Button
            {
                Text = "✅ Ghi Nhận Bữa Này Vào Nhật Ký",
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(34, 120, 75),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Location = new Point(18, y),
                Size = new Size(340, 40),
                Cursor = Cursors.Hand
            };
            btnLog.Click += (s, e) =>
            {
                try
                {
                    long userId = AppSession.CurrentUserId;
                    var today = DateOnly.FromDateTime(DateTime.Now);
                    var selectedSlot = _diarySlots[cbTimeSlot.SelectedIndex];
                    var mealFood = _mealLogService.FindOrCreateFood(
                        suggestion.Title,
                        suggestion.Calories,
                        "g",
                        suggestion.Protein,
                        suggestion.Carb,
                        suggestion.Fat);

                    _mealLogService.AddMeal(
                        userId,
                        today,
                        selectedSlot.mealName,
                        selectedSlot.slot,
                        new List<(long foodId, decimal quantity)> { (mealFood.Id, 100m) });

                    foreach (var usage in ingredientUsage.Where(entry => entry.Item is not null))
                    {
                        _fridgeService.UseItem(usage.Item!.Id, usage.Quantity);
                    }

                    MessageBox.Show(
                        $"✅ Đã ghi nhận '{suggestion.Title}'\n" +
                        $"vào {selectedSlot.mealName} ({selectedSlot.slot}) — {suggestion.Calories} kcal\n" +
                        $"Đã trừ {ingredientUsage.Count(entry => entry.Item is not null)} nguyên liệu trong tủ lạnh.",
                        "Ghi Nhận Thành Công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    dlg.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            var btnClose = new Button
            {
                Text = "Đóng",
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(60, 60, 60),
                BackColor = Color.FromArgb(240, 237, 230),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Location = new Point(370, y),
                Size = new Size(100, 40),
                DialogResult = DialogResult.Cancel
            };

            dlg.Controls.Add(btnLog);
            dlg.Controls.Add(btnClose);
            dlg.AcceptButton = btnLog;
            dlg.CancelButton = btnClose;
            dlg.ClientSize = new Size(560, y + 58);

            if (dlg.ShowDialog(FindForm()) == DialogResult.OK)
            {
                LoadData();
            }
        }

        private List<(string Ingredient, FridgeItemDisplay? Item, decimal Quantity)> BuildIngredientUsage(
            AiMealSuggestion suggestion,
            List<FridgeItemDisplay> fridgeItems)
        {
            var result = new List<(string Ingredient, FridgeItemDisplay? Item, decimal Quantity)>();
            var usedItemIds = new HashSet<long>();

            foreach (string ingredient in suggestion.Ingredients)
            {
                string ingredientName = ingredient.Split(':', 2)[0].Trim();
                var item = fridgeItems
                    .Where(candidate =>
                        ingredient.Contains(candidate.FoodName, StringComparison.OrdinalIgnoreCase) ||
                        candidate.FoodName.Contains(ingredientName, StringComparison.OrdinalIgnoreCase))
                    .OrderByDescending(candidate => candidate.FoodName.Length)
                    .FirstOrDefault(candidate => !usedItemIds.Contains(candidate.Id));

                if (item is null)
                {
                    result.Add((ingredient, null, 0));
                    continue;
                }

                decimal quantity = ParseIngredientQuantity(ingredient, item.Unit, item.Quantity);
                usedItemIds.Add(item.Id);
                result.Add((ingredient, item, quantity));
            }

            return result;
        }

        private static decimal ParseIngredientQuantity(string ingredient, string unit, decimal available)
        {
            var matches = Regex.Matches(ingredient, @"(?<amount>\d+(?:[.,]\d+)?)\s*(?<unit>[\p{L}]+)?");
            var match = matches.Cast<Match>().LastOrDefault(candidate => candidate.Groups["amount"].Success);
            decimal defaultQuantity = unit.Equals("g", StringComparison.OrdinalIgnoreCase) ||
                                     unit.Equals("ml", StringComparison.OrdinalIgnoreCase)
                ? 100m
                : 1m;

            if (match is null || !decimal.TryParse(
                    match.Groups["amount"].Value.Replace(',', '.'),
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out decimal quantity))
            {
                return Math.Min(defaultQuantity, available);
            }

            string requestedUnit = match.Groups["unit"].Value.ToLowerInvariant();
            string stockUnit = unit.ToLowerInvariant();
            if (requestedUnit == "kg" && stockUnit == "g") quantity *= 1000m;
            else if (requestedUnit == "g" && stockUnit == "kg") quantity /= 1000m;
            else if (requestedUnit == "l" && stockUnit == "ml") quantity *= 1000m;
            else if (requestedUnit == "ml" && stockUnit == "l") quantity /= 1000m;
            else if (!string.IsNullOrEmpty(requestedUnit) && requestedUnit != stockUnit)
            {
                quantity = defaultQuantity;
            }

            return Math.Min(Math.Max(quantity, 0.01m), available);
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flpSuggestions_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnManualAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
