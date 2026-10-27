using Kit_Fitness.Helpers;
using Kit_Fitness.Services;

namespace Kit_Fitness.UserControls
{
    public partial class ucDashboard : UserControl
    {
        private readonly DashboardService _dashboardService = new();
        private readonly UserProfileService _profileService = new();

        /// <summary>
        /// Event khi người dùng nhấn nút Nhập Món
        /// </summary>
        public event EventHandler? OnNhapMonClicked;

        /// <summary>
        /// Event khi người dùng nhấn nút Tủ Lạnh / Vào bếp
        /// </summary>
        public event EventHandler? OnTuLanhClicked;

        /// <summary>
        /// Event khi người dùng nhấn Xem timeline
        /// </summary>
        public event EventHandler? OnViewTimelineClicked;

        public ucDashboard()
        {
            InitializeComponent();
            pnlMacroContainer.Resize += PnlMacroContainer_Resize;
            dgvFridge.CellPainting += DgvFridge_CellPainting;
            WireEvents();
            LoadData();
        }

        private void DgvFridge_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0 || e.Value is not string foodName)
            {
                return;
            }

            e.PaintBackground(e.CellBounds, true);

            Color dotColor = e.RowIndex < dgvFridge.Rows.Count && dgvFridge.Rows[e.RowIndex].Tag is Color color
                ? color
                : Color.FromArgb(0, 175, 135);

            using var brush = new SolidBrush(dotColor);
            float dotSize = 7;
            float dotY = e.CellBounds.Top + (e.CellBounds.Height - dotSize) / 2f;
            e.Graphics.FillEllipse(brush, e.CellBounds.Left + 5, dotY, dotSize, dotSize);

            TextRenderer.DrawText(
                e.Graphics,
                foodName,
                e.CellStyle.Font,
                new Rectangle(e.CellBounds.Left + 18, e.CellBounds.Top, e.CellBounds.Width - 18, e.CellBounds.Height),
                e.CellStyle.ForeColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            e.Paint(e.CellBounds, DataGridViewPaintParts.Border);
            e.Handled = true;
        }

        private void PnlMacroContainer_Resize(object? sender, EventArgs e)
        {
            int spacing = pnlProtein.Margin.Right + pnlCarbs.Margin.Right;
            int cardWidth = Math.Max(0, (pnlMacroContainer.ClientSize.Width - spacing) / 3);

            pnlProtein.Width = cardWidth;
            pnlCarbs.Width = cardWidth;
            pnlFat.Width = pnlMacroContainer.ClientSize.Width - cardWidth * 2 - spacing;
        }

        private void WireEvents()
        {
            btnNhapMon.Click += (s, e) => OnNhapMonClicked?.Invoke(this, EventArgs.Empty);
            btnTuLanh.Click += (s, e) => OnTuLanhClicked?.Invoke(this, EventArgs.Empty);
            lnkViewTimeline.LinkClicked += (s, e) => OnViewTimelineClicked?.Invoke(this, EventArgs.Empty);
            lnkGoToBep.LinkClicked += (s, e) => OnTuLanhClicked?.Invoke(this, EventArgs.Empty);
            btnWaterPlus.Click += BtnWaterPlus_Click;
            btnWaterMinus.Click += BtnWaterMinus_Click;
            btnUpdateWeight.Click += BtnUpdateWeight_Click;
        }

        // **
        public void LoadData()
        {
            try
            {
                long userId = AppSession.CurrentUserId;
                var today = DateOnly.FromDateTime(DateTime.Now);

                // Header
                var user = _profileService.GetProfile(userId);
                lblDate.Text = $"HÔM NAY, {DateTime.Now:dd} THG {DateTime.Now:MM}";
                lblGreeting.Text = $"Chào {user?.UserName ?? "Người dùng"}! 🌿";

                // Nutrition
                var nutrition = _dashboardService.GetDailyNutrition(userId, today);
                lblCaloriesRemaining.Text = nutrition.CaloriesRemaining.ToString();
                lblTargetCal.Text = $"● Mục tiêu ngày: {nutrition.TargetCalories} kcal";
                lblConsumedCal.Text = $"● Đã nạp vào: {nutrition.CaloriesConsumed} kcal";
                lblBurnedCal.Text = $"● Vận động đốt: {nutrition.CaloriesBurned} kcal";
                lblGoal.Text = $"Mục tiêu: {_dashboardService.GetGoalDisplayName(user?.Goal)}";

                int calPercent = nutrition.TargetCalories > 0
                    ? Math.Min(100, nutrition.CaloriesConsumed * 100 / nutrition.TargetCalories)
                    : 0;
                progressCalories.Value = calPercent;

                // Macros
                lblProteinValue.Text = $"{nutrition.TotalProtein}g";
                lblProteinTarget.Text = $"Mục tiêu {nutrition.TargetProtein}g";
                lblCarbsValue.Text = $"{nutrition.TotalCarbs}g";
                lblCarbsTarget.Text = $"Mục tiêu {nutrition.TargetCarbs}g";
                lblFatValue.Text = $"{nutrition.TotalFat}g";
                lblFatTarget.Text = $"Mục tiêu {nutrition.TargetFat}g";

                // Water
                var (waterIntake, waterGoal) = _dashboardService.GetWaterIntake(userId, today);
                lblWaterValue.Text = $"{waterIntake} / {waterGoal} ml";
                progressWater.Value = waterGoal > 0 ? Math.Min(100, waterIntake * 100 / waterGoal) : 0;

                // Weight
                var (weight, targetWeight) = _dashboardService.GetLatestWeight(userId);
                lblWeightValue.Text = $"{weight} kg";
                lblWeightTarget.Text = targetWeight.HasValue ? $"(Mục tiêu: {targetWeight} kg)" : "";

                // Fridge
                var fridgeItems = _dashboardService.GetFridgeItems(userId);
                lblFridgeTitle.Text = $"🧊 Tủ Lạnh Hôm Nay ({fridgeItems.Count} món)";
                var expiring = _dashboardService.GetExpiringSoonItems(userId);
                lblFridgeWarning.Text = expiring.Count > 0
                    ? $"⚠️ Có {expiring.Count} thực phẩm sắp hết hạn!"
                    : "✅ Không có thực phẩm nào sắp hết hạn";
                lblFridgeWarning.ForeColor = expiring.Count > 0
                    ? System.Drawing.Color.FromArgb(200, 120, 50)
                    : System.Drawing.Color.FromArgb(76, 140, 74);

                // Load fridge grid
                LoadFridgeGrid(fridgeItems);

                // Meals
                var meals = _dashboardService.GetMealsTimeline(userId, today);
                lblMealsSummaryTitle.Text = $"🍽️ Bữa Ăn Đã Ghi ({meals.Sum(m => m.Items.Count)} món)";
                LoadMealsGrid(meals);
            }
            catch (Exception ex)
            {
                // Khi chưa kết nối DB, hiện dữ liệu mặc định
                System.Diagnostics.Debug.WriteLine($"Dashboard LoadData error: {ex.Message}");
            }
        }

        private void LoadMealsGrid(List<MealDisplayItem> meals)
        {
            dgvMeals.Columns.Clear();
            dgvMeals.Columns.Add("Food", "Món ăn");
            dgvMeals.Columns.Add("Calories", "Kcal");
            dgvMeals.Columns["Food"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMeals.Columns["Calories"].Width = 120;

            dgvMeals.Rows.Clear();
            foreach (var meal in meals)
            {
                foreach (var item in meal.Items)
                {
                    dgvMeals.Rows.Add($"● {item.FoodName} ({item.Quantity:0.##}{item.Unit})", $"{item.Calories} Kcal");
                }
            }
        }

        private void LoadFridgeGrid(List<Models.FridgeItem> items)
        {
            dgvFridge.Columns.Clear();
            dgvFridge.Columns.Add("Food", "Thực phẩm");
            dgvFridge.Columns.Add("Quantity", "Số lượng");
            dgvFridge.Columns["Food"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFridge.Columns["Quantity"].Width = 120;

            dgvFridge.Rows.Clear();
            foreach (var item in items.Take(5))
            {
                string foodName = item.Food?.Name ?? "Không tên";
                string qty = $"{item.Quantity:0.##} {item.Food?.Unit ?? ""}";
                Color expiryColor = item.ExpiryDate.HasValue
                    ? item.ExpiryDate.Value < DateOnly.FromDateTime(DateTime.Today)
                        ? Color.FromArgb(190, 65, 45)
                        : item.ExpiryDate.Value <= DateOnly.FromDateTime(DateTime.Today).AddDays(2)
                            ? Color.FromArgb(220, 165, 45)
                            : Color.FromArgb(0, 175, 135)
                    : Color.Gray;
                int rowIndex = dgvFridge.Rows.Add(foodName, qty);
                dgvFridge.Rows[rowIndex].Tag = expiryColor;
            }
        }

        // **
        private void BtnWaterPlus_Click(object? sender, EventArgs e)
        {
            try
            {
                _profileService.AddWater(AppSession.CurrentUserId, 250);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // **
        private void BtnWaterMinus_Click(object? sender, EventArgs e)
        {
            try
            {
                _profileService.AddWater(AppSession.CurrentUserId, -250);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // **
        private void BtnUpdateWeight_Click(object? sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập cân nặng mới (kg):", "Cập nhật cân nặng", "50");
            if (decimal.TryParse(input, out decimal weight) && weight > 0)
            {
                try
                {
                    _profileService.LogWeight(AppSession.CurrentUserId, weight);
                    LoadData();
                    MessageBox.Show("Cập nhật cân nặng thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblProteinTarget_Click(object sender, EventArgs e)
        {

        }

        private void lblProteinValue_Click(object sender, EventArgs e)
        {

        }
    }
}
