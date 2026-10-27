using Kit_Fitness.Helpers;
using Kit_Fitness.Services;

namespace Kit_Fitness.Forms
{
    public partial class frmAiMealLog : Form
    {
        private readonly DateOnly _logDate;
        private readonly GeminiService _geminiService = new();
        private readonly MealLogService _mealLogService = new();
        private string? _imagePath;
        private DTOs.AiMealPhotoAnalysis? _analysis;

        private readonly (string slot, string mealName)[] _mealSlots =
        {
            ("07:00", "Bữa sáng sớm"),
            ("08:30", "Cà phê & ăn nhẹ"),
            ("10:00", "Bữa phụ sáng"),
            ("12:00", "Bữa trưa"),
            ("14:30", "Bữa phụ chiều"),
            ("16:30", "Năng lượng trước tập"),
            ("19:00", "Bữa tối")
        };

        public frmAiMealLog(DateOnly logDate)
        {
            _logDate = logDate;
            InitializeComponent();

            foreach (var (slot, mealName) in _mealSlots)
            {
                cbTimeSlot.Items.Add($"{slot} - {mealName}");
            }

            int defaultIndex = Array.FindIndex(_mealSlots, item =>
                TimeSpan.TryParse(item.slot, out var slotTime) && slotTime >= DateTime.Now.TimeOfDay);
            cbTimeSlot.SelectedIndex = defaultIndex >= 0 ? defaultIndex : _mealSlots.Length - 1;

            btnChooseImage.Click += BtnChooseImage_Click;
            btnAnalyze.Click += async (s, e) => await AnalyzeImageAsync();
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => Close();
        }

        private void BtnChooseImage_Click(object? sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Chọn ảnh món ăn",
                Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp;*.webp)|*.jpg;*.jpeg;*.png;*.bmp;*.webp",
                Multiselect = false
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            _imagePath = dialog.FileName;
            _analysis = null;
            btnSave.Enabled = false;
            lblStatus.Text = "Đã chọn ảnh. Bấm Phân tích để nhận diện món ăn.";

            try
            {
                using var stream = new FileStream(_imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var image = Image.FromStream(stream);
                picMeal.Image?.Dispose();
                picMeal.Image = new Bitmap(image);
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Không thể mở ảnh: {ex.Message}";
            }
        }

        // **
        private async Task AnalyzeImageAsync()
        {
            if (string.IsNullOrWhiteSpace(_imagePath) || !File.Exists(_imagePath))
            {
                MessageBox.Show("Vui lòng chọn ảnh món ăn trước.", "Thiếu ảnh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnAnalyze.Enabled = false;
            btnChooseImage.Enabled = false;
            btnSave.Enabled = false;
            lblStatus.Text = "AI đang phân tích món ăn...";

            try
            {
                _analysis = await _geminiService.AnalyzeMealPhotoAsync(_imagePath);
                txtFoodName.Text = _analysis.FoodName;
                numQuantityGrams.Value = Math.Min(numQuantityGrams.Maximum,
                    Math.Max(numQuantityGrams.Minimum, Math.Round(_analysis.QuantityGrams)));
                numCalories.Value = Math.Min(numCalories.Maximum,
                    Math.Max(numCalories.Minimum, _analysis.EstimatedCalories));
                lblMacroEstimate.Text = $"Ước tính /100g: Đạm {_analysis.ProteinPer100g:0.#}g  •  Carb {_analysis.CarbsPer100g:0.#}g  •  Béo {_analysis.FatPer100g:0.#}g";
                lblStatus.Text = "Đã phân tích. Kiểm tra thông tin, chọn giờ ăn rồi lưu.";
                btnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                _analysis = null;
                lblStatus.Text = "Phân tích ảnh thất bại.";
                MessageBox.Show($"Không thể phân tích món ăn: {ex.Message}", "Lỗi AI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAnalyze.Enabled = true;
                btnChooseImage.Enabled = true;
            }
        }

        // **
        private void BtnSave_Click(object? sender, EventArgs e)
        {
            string foodName = txtFoodName.Text.Trim();
            if (_analysis is null || string.IsNullOrWhiteSpace(foodName) || cbTimeSlot.SelectedIndex < 0)
            {
                MessageBox.Show("Hãy phân tích ảnh và kiểm tra thông tin món ăn.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal quantityGrams = numQuantityGrams.Value;
                int caloriesPer100g = (int)Math.Round(numCalories.Value * 100m / quantityGrams);
                var food = _mealLogService.FindOrCreateFood(
                    foodName,
                    caloriesPer100g,
                    "g",
                    _analysis.ProteinPer100g,
                    _analysis.CarbsPer100g,
                    _analysis.FatPer100g);

                var (timeSlot, mealName) = _mealSlots[cbTimeSlot.SelectedIndex];
                _mealLogService.AddMeal(
                    AppSession.CurrentUserId,
                    _logDate,
                    mealName,
                    timeSlot,
                    new List<(long foodId, decimal quantity)> { (food.Id, quantityGrams) });

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể lưu món ăn: {ex.Message}", "Lỗi lưu món", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}