using Kit_Fitness.Helpers;
using Kit_Fitness.Models;
using Kit_Fitness.Services;
using Kit_Fitness.UserControls;

namespace Kit_Fitness.Forms
{
    public partial class frmQuickLogMeal : Form
    {
        private readonly MealLogService _mealLogService = new();
        private List<Food> _allFoods = new();
        private readonly List<ucMealItemRow> _itemRows = new();
        private readonly ToolTip _toolTip = new();
        private DateOnly _logDate;
        private int _remainingDailyCalories = 1450;
        private int _targetDailyCalories = 1450;
        private bool _isSyncingMealSelection;

        public frmQuickLogMeal(string defaultTimeSlot = "12:00", string defaultMealType = "Bữa Trưa", DateOnly? logDate = null)
        {
            InitializeComponent();
            _logDate = logDate ?? DateOnly.FromDateTime(DateTime.Now);

            // Tải thông tin calo mục tiêu và còn lại từ DB
            LoadDailyCaloriesInfo();

            // Tải danh sách món ăn từ DB
            LoadFoodData();

            // Cấu hình mốc giờ và loại bữa
            SetupTimeAndMealType(defaultTimeSlot, defaultMealType);

            // Thêm các dòng món ăn mặc định (#1, #2 như trong hình mẫu)
            AddNewItemRow();
            if (_allFoods.Count > 1)
            {
                AddNewItemRow();
            }
        }

        // **
        private void LoadDailyCaloriesInfo()
        {
            try
            {
                long userId = AppSession.CurrentUserId;
                var status = _mealLogService.GetDailyCaloriesStatus(userId, _logDate);
                _remainingDailyCalories = status.remaining;
                _targetDailyCalories = status.target;
            }
            catch
            {
                _remainingDailyCalories = 985;
                _targetDailyCalories = 1450;
            }
        }

        private void SetupTimeAndMealType(string defaultTimeSlot, string defaultMealType)
        {
            if (cbTimeSlot.Items.Contains(defaultTimeSlot))
            {
                cbTimeSlot.SelectedItem = defaultTimeSlot;
            }
            else
            {
                cbTimeSlot.Items.Add(defaultTimeSlot);
                cbTimeSlot.SelectedItem = defaultTimeSlot;
            }

            // Đồng bộ meal type
            SelectOrAddMealType(defaultMealType);

            cbTimeSlot.SelectedIndexChanged += (s, e) =>
            {
                if (_isSyncingMealSelection)
                {
                    return;
                }

                string slot = cbTimeSlot.SelectedItem?.ToString() ?? "12:00";
                string autoMeal = GetMealNameForSlot(slot);
                _isSyncingMealSelection = true;
                try
                {
                    SelectOrAddMealType(autoMeal);
                }
                finally
                {
                    _isSyncingMealSelection = false;
                }
            };

            cbMealType.SelectedIndexChanged += (s, e) =>
            {
                if (_isSyncingMealSelection)
                {
                    return;
                }

                string mealType = cbMealType.SelectedItem?.ToString() ?? string.Empty;
                string? slot = GetTimeSlotForMeal(mealType);
                if (slot == null)
                {
                    return;
                }

                _isSyncingMealSelection = true;
                try
                {
                    SelectOrAddTimeSlot(slot);
                }
                finally
                {
                    _isSyncingMealSelection = false;
                }
            };
        }

        private void SelectOrAddTimeSlot(string timeSlot)
        {
            int index = cbTimeSlot.Items.IndexOf(timeSlot);
            if (index < 0)
            {
                cbTimeSlot.Items.Add(timeSlot);
                cbTimeSlot.SelectedItem = timeSlot;
            }
            else
            {
                cbTimeSlot.SelectedIndex = index;
            }
        }

        private string? GetTimeSlotForMeal(string mealType)
        {
            return mealType switch
            {
                "Bữa Sáng" or "Bữa Sáng Sớm" => "07:00",
                "Cà Phê & Ăn Nhẹ" => "08:30",
                "Bữa Phụ Sáng" => "10:00",
                "Bữa Trưa" => "12:00",
                "Bữa Phụ Chiều" => "14:30",
                "Năng Lượng Trước Tập" => "16:30",
                "Bữa Tối" => "19:00",
                "Bữa Phụ" or "Ăn Nhẹ" => "21:00",
                _ => null
            };
        }

        private void SelectOrAddMealType(string mealType)
        {
            for (int i = 0; i < cbMealType.Items.Count; i++)
            {
                if (string.Equals(cbMealType.Items[i]?.ToString(), mealType, StringComparison.OrdinalIgnoreCase))
                {
                    if (cbMealType.Items.Count > 0 && i >= 0 && i < cbMealType.Items.Count)
                    {
                        cbMealType.SelectedIndex = i;
                    }
                    return;
                }
            }

            cbMealType.Items.Add(mealType);
            cbMealType.SelectedItem = mealType;
        }

        private string GetMealNameForSlot(string slot)
        {
            return slot switch
            {
                "07:00" => "Bữa Sáng Sớm",
                "08:30" => "Cà Phê & Ăn Nhẹ",
                "10:00" => "Bữa Phụ Sáng",
                "12:00" => "Bữa Trưa",
                "14:30" => "Bữa Phụ Chiều",
                "16:30" => "Năng Lượng Trước Tập",
                "19:00" => "Bữa Tối",
                _ => "Bữa Phụ"
            };
        }

        // **
        private void LoadFoodData()
        {
            try
            {
                _allFoods = _mealLogService.GetAllFoods(AppSession.CurrentUserId);
            }
            catch
            {
                _allFoods = new List<Food>();
            }

            if (_allFoods.Count == 0)
            {
                // Fallback nếu không có kết nối DB
                _allFoods = new List<Food>
                {
                    new Food { Id = 1, Name = "Ức gà phi lê", Calories = 165, Protein = 31, Carbs = 0, Fat = 3.6m, Unit = "g" },
                    new Food { Id = 2, Name = "Cơm gạo lứt", Calories = 111, Protein = 2.6m, Carbs = 23, Fat = 0.9m, Unit = "g" },
                    new Food { Id = 3, Name = "Trứng gà luộc", Calories = 78, Protein = 6.3m, Carbs = 0.6m, Fat = 5.3m, Unit = "quả" },
                    new Food { Id = 4, Name = "Phở gà ức ít bánh", Calories = 380, Protein = 32, Carbs = 58, Fat = 12, Unit = "tô" },
                    new Food { Id = 5, Name = "Rau muống luộc", Calories = 30, Protein = 3, Carbs = 5, Fat = 0.3m, Unit = "đĩa" }
                };
            }
        }

        private void BtnAddItem_Click(object? sender, EventArgs e)
        {
            AddNewItemRow();
        }

        // gắn sự kiện cho ucMealItemRow
        private void AddNewItemRow()
        {
            int index = _itemRows.Count + 1;
            var itemRow = new ucMealItemRow
            {
                Dock = DockStyle.Top,
                Margin = new Padding(0, 0, 0, 8)
            };
            itemRow.LblNumber.Text = $"#{index}";
            itemRow.LoadFoods(_allFoods, index);
            _toolTip.SetToolTip(itemRow.NumCalories, "Nhập số calo của món ăn cho mỗi 100g.");

            void PositionRightControls()
            {
                int right = itemRow.ContainerPanel.ClientSize.Width - 6;
                itemRow.BtnDelete.Location = new Point(right - itemRow.BtnDelete.Width, 10);
                itemRow.PnlTrafficLight.Location = new Point(
                    itemRow.BtnDelete.Left - itemRow.PnlTrafficLight.Width - 12,
                    42);
            }

            itemRow.ContainerPanel.Resize += (s, e) => PositionRightControls();

            // Sự kiện cập nhật
            itemRow.BtnDelete.Click += (s, ev) => RemoveItemRow(itemRow);

            itemRow.CbFood.SelectedIndexChanged += (s, ev) =>
            {
                if (itemRow.CbFood.SelectedItem is Food f && !string.IsNullOrEmpty(f.Unit))
                {
                    itemRow.LblUnit.Text = f.Unit;
                    SelectUnit(itemRow.CbUnit, f.Unit);
                    itemRow.NumCalories.Value = Math.Min(itemRow.NumCalories.Maximum, Math.Max(itemRow.NumCalories.Minimum, f.Calories));
                }
                CalculateEstimatedNutrition();
            };

            itemRow.CbFood.TextChanged += (s, ev) =>
            {
                CalculateEstimatedNutrition();
            };

            itemRow.NumWeight.ValueChanged += (s, ev) => CalculateEstimatedNutrition();
            itemRow.NumCalories.ValueChanged += (s, ev) => CalculateEstimatedNutrition();

            if (itemRow.CbFood.SelectedItem is Food initFood && !string.IsNullOrEmpty(initFood.Unit))
            {
                itemRow.LblUnit.Text = initFood.Unit;
                SelectUnit(itemRow.CbUnit, initFood.Unit);
                itemRow.NumCalories.Value = Math.Min(itemRow.NumCalories.Maximum, Math.Max(itemRow.NumCalories.Minimum, initFood.Calories));
            }

            _itemRows.Add(itemRow);
            pnlItemsList.Controls.Add(itemRow);
            PositionRightControls();

            itemRow.SendToBack();

            CalculateEstimatedNutrition();
        }

        private static void SelectUnit(ComboBox comboBox, string? unit)
        {
            if (string.IsNullOrWhiteSpace(unit))
            {
                return;
            }

            if (!comboBox.Items.Contains(unit))
            {
                comboBox.Items.Add(unit);
            }

            comboBox.SelectedItem = unit;
        }

        private void RemoveItemRow(ucMealItemRow row)
        {
            if (_itemRows.Count <= 1)
            {
                MessageBox.Show("Bữa ăn phải có ít nhất 1 món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            pnlItemsList.Controls.Remove(row);
            _itemRows.Remove(row);
            row.Dispose();

            // Đánh lại số thứ tự
            for (int i = 0; i < _itemRows.Count; i++)
            {
                _itemRows[i].LblNumber.Text = $"#{i + 1}";
            }

            CalculateEstimatedNutrition();
        }

        private void CalculateEstimatedNutrition()
        {
            decimal totalCal = 0;
            decimal totalP = 0;
            decimal totalC = 0;
            decimal totalF = 0;

            foreach (var row in _itemRows)
            {
                Food? food = GetFoodForRow(row);

                if (food != null)
                {
                    decimal weightRatio = row.NumWeight.Value / 100m;
                    int itemCal = (int)(food.Calories * weightRatio);
                    totalCal += itemCal;
                    totalP += (food.Protein ?? 0) * weightRatio;
                    totalC += (food.Carbs ?? 0) * weightRatio;
                    totalF += (food.Fat ?? 0) * weightRatio;

                    // Tính traffic light cho từng món dựa trên calo còn lại trong ngày
                    UpdateItemTrafficLight(row.PnlTrafficLight, itemCal);
                }
                else if (!string.IsNullOrWhiteSpace(row.CbFood.Text))
                {
                    decimal weightRatio = row.NumWeight.Value / 100m;
                    int itemCal = (int)(row.NumCalories.Value * weightRatio);
                    totalCal += itemCal;
                    UpdateItemTrafficLight(row.PnlTrafficLight, itemCal);
                }
                else
                {
                    if (row.PnlTrafficLight != null)
                    {
                        row.PnlTrafficLight.Tag = (Color.FromArgb(120, 120, 120), "--");
                        row.PnlTrafficLight.BackColor = Color.FromArgb(240, 240, 240);
                        row.PnlTrafficLight.Invalidate();
                    }
                }
            }

            if (lblCalories != null) lblCalories.Text = $"{(int)totalCal} Kcal";
            if (lblProtein != null) lblProtein.Text = $"Đạm (P)\n{(int)totalP}g";
            if (lblCarbs != null) lblCarbs.Text = $"Đường (C)\n{(int)totalC}g";
            if (lblFat != null) lblFat.Text = $"Béo (F)\n{(int)totalF}g";

            // Cập nhật nhãn trạng thái tổng bữa ăn
            UpdateMealTrafficLightStatus((int)totalCal);
        }

        private Food? GetFoodForRow(ucMealItemRow row)
        {
            string foodName = row.CbFood.Text.Trim();
            if (string.IsNullOrWhiteSpace(foodName))
            {
                return null;
            }

            if (row.CbFood.SelectedItem is Food selectedFood &&
                selectedFood.Name.Equals(foodName, StringComparison.OrdinalIgnoreCase))
            {
                return selectedFood;
            }

            return _allFoods.FirstOrDefault(f =>
                f.Name.Equals(foodName, StringComparison.OrdinalIgnoreCase));
        }

        private void UpdateItemTrafficLight(Panel? pnl, int itemCal)
        {
            if (pnl == null) return;
            int remaining = _remainingDailyCalories;

            Color dotColor;
            string tooltip;
            if (remaining <= 0 || itemCal > remaining * 0.70m)
            {
                dotColor = Color.FromArgb(198, 40, 40);
                pnl.BackColor = Color.FromArgb(255, 235, 238);
                int pct = remaining > 0 ? (int)(itemCal * 100.0 / remaining) : 100;
                tooltip = $"Chiếm {pct}% calo còn lại trong ngày (Calo còn: {remaining} Kcal). Cân nhắc giảm lượng!";
            }
            else if (itemCal > remaining * 0.40m)
            {
                dotColor = Color.FromArgb(230, 81, 0);
                pnl.BackColor = Color.FromArgb(255, 248, 225);
                int pct = (int)(itemCal * 100.0 / remaining);
                tooltip = $"Chiếm {pct}% calo còn lại trong ngày (Calo còn: {remaining} Kcal). Mức năng lượng trung bình.";
            }
            else
            {
                dotColor = Color.FromArgb(46, 125, 50);
                pnl.BackColor = Color.FromArgb(232, 245, 233);
                int pct = remaining > 0 ? (int)(itemCal * 100.0 / remaining) : 0;
                tooltip = $"Chiếm {pct}% calo còn lại trong ngày (Calo còn: {remaining} Kcal). Rất an toàn và cân bằng!";
            }

            pnl.Tag = (dotColor, $"{itemCal} cal");
            _toolTip.SetToolTip(pnl, tooltip);
            pnl.Invalidate();
        }

        private void UpdateMealTrafficLightStatus(int totalMealCal)
        {
            if (lblMealStatus == null) return;

            int remaining = _remainingDailyCalories;
            if (remaining <= 0 || totalMealCal > remaining * 0.75m)
            {
                lblMealStatus.Text = "● VƯỢT CHỈ TIÊU NGÀY";
                lblMealStatus.ForeColor = Color.FromArgb(198, 40, 40);
            }
            else if (totalMealCal > remaining * 0.40m)
            {
                lblMealStatus.Text = "● CÂN NHẮC NĂNG LƯỢNG";
                lblMealStatus.ForeColor = Color.FromArgb(230, 81, 0);
            }
            else
            {
                lblMealStatus.Text = "● TƯƠI LÀNH VÀ CÂN BẰNG";
                lblMealStatus.ForeColor = Color.FromArgb(46, 125, 50);
            }
        }

        // **
        private void BtnSaveMeal_Click(object? sender, EventArgs e)
        {
            var mealItems = new List<(long foodId, decimal quantity, string? trafficLight)>();

            foreach (var row in _itemRows)
            {
                Food? food = GetFoodForRow(row);

                if (food == null && !string.IsNullOrWhiteSpace(row.CbFood.Text))
                {
                    try
                    {
                        food = _mealLogService.FindOrCreateFood(
                            row.CbFood.Text.Trim(),
                            (int)row.NumCalories.Value,
                            row.CbUnit.Text.Trim());
                    }
                    catch
                    {
                        food = null;
                    }
                }

                if (food != null)
                {
                    int caloriesPer100g = GetFoodForRow(row) == null
                        ? (int)row.NumCalories.Value
                        : food.Calories;
                    int itemCal = (int)(caloriesPer100g * (row.NumWeight.Value / 100m));
                    string light = _mealLogService.CalculateTrafficLight(itemCal, _remainingDailyCalories);
                    mealItems.Add((food.Id, row.NumWeight.Value, light));
                }
            }

            if (mealItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một món ăn hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                long userId = AppSession.CurrentUserId;
                string mealType = cbMealType.SelectedItem?.ToString() ?? "Bữa Trưa";
                string timeSlot = cbTimeSlot.SelectedItem?.ToString() ?? "12:00";

                _mealLogService.AddMeal(userId, _logDate, mealType, timeSlot, mealItems);

                MessageBox.Show("Đã lưu bữa ăn vào nhật ký thành công! 🌿", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu bữa ăn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBack_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void frmQuickLogMeal_Load(object sender, EventArgs e)
        {

        }
    }
}
