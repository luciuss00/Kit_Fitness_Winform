using Kit_Fitness.Helpers;
using Kit_Fitness.Repositories;
using Kit_Fitness.Services;

namespace Kit_Fitness.Forms
{
    public partial class frmScanReceipt : Form
    {
        private string? _imagePath;
        private readonly GeminiService _geminiService = new();
        private readonly FridgeService _fridgeService = new();
        private readonly FoodRepository _foodRepo = new();

        private List<ScannedReceiptItem> _lastScannedItems = new();
        private bool _hasAddedToFridge = false;

        public frmScanReceipt(string? initialImagePath = null)
        {
            _imagePath = initialImagePath;
            InitializeComponent();
            btnChooseImage.Click += BtnChooseImage_Click;
            btnAnalyze.Click += BtnAnalyze_Click;
            btnSaveSelected.Click += BtnSaveSelected_Click;
            btnClose.Click += BtnClose_Click;
            FormClosing += FrmScanReceipt_FormClosing;

            Load += async (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(_imagePath) && File.Exists(_imagePath))
                {
                    LoadImagePreview(_imagePath);
                    await RunScanAsync();
                }
            };
        }

        private async void BtnAnalyze_Click(object? sender, EventArgs e)
        {
            await RunScanAsync();
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            DialogResult = _hasAddedToFridge ? DialogResult.OK : DialogResult.Cancel;
            Close();
        }

        private void FrmScanReceipt_FormClosing(object? sender, FormClosingEventArgs e)
        {
            DialogResult = _hasAddedToFridge ? DialogResult.OK : DialogResult.Cancel;
        }

        private void LoadImagePreview(string path)
        {
            try
            {
                using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var original = Image.FromStream(fs);
                picReceipt.Image?.Dispose();
                picReceipt.Image = new Bitmap(original);

                var fi = new FileInfo(path);
                lblImageInfo.Text = $"{fi.Name} ({(fi.Length / 1024.0):0.#} KB, {original.Width}x{original.Height}px)";
            }
            catch (Exception ex)
            {
                lblImageInfo.Text = $"Không thể tải ảnh: {ex.Message}";
            }
        }

        private void BtnChooseImage_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn ảnh hóa đơn để AI phân tích",
                Filter = "Tệp ảnh (*.jpg;*.jpeg;*.png;*.bmp;*.webp)|*.jpg;*.jpeg;*.png;*.bmp;*.webp|Tất cả tệp (*.*)|*.*",
                Multiselect = false
            };

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                _imagePath = ofd.FileName;
                LoadImagePreview(_imagePath);
                _ = RunScanAsync();
            }
        }

        // **
        private async Task RunScanAsync()
        {
            if (string.IsNullOrWhiteSpace(_imagePath) || !File.Exists(_imagePath))
            {
                MessageBox.Show("Vui lòng chọn một ảnh hóa đơn hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnAnalyze.Enabled = false;
            btnChooseImage.Enabled = false;
            prgStatus.Visible = true;
            lblStatus.Text = "✨ Gemini AI đang phân tích ảnh hóa đơn và bóc tách thực phẩm...";
            lblStatus.ForeColor = Color.FromArgb(34, 90, 60);

            try
            {
                var items = await _geminiService.AnalyzeReceiptAsync(_imagePath);
                _lastScannedItems = items;

                dgvItems.Rows.Clear();
                foreach (var item in items)
                {
                    string storageText = item.StorageType == "FREEZER" ? "❄ Ngăn Đá" : "🍃 Ngăn Mát";
                    string expiryText = $"{item.ExpiryDays} ngày ({DateTime.Today.AddDays(item.ExpiryDays):dd/MM})";

                    dgvItems.Rows.Add(false, item.FoodName, item.Quantity, item.Unit, storageText, expiryText);
                }

                lblStatus.Text = $"🎉 AI đã nhận diện {items.Count} món. Chọn món muốn thêm vào tủ lạnh.";
                lblStatus.ForeColor = Color.FromArgb(34, 112, 68);
                lblSummary.Text = $"Đã nhận diện {items.Count} món; chưa lưu vào tủ lạnh.";
                btnSaveSelected.Visible = true;
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"⚠ Lỗi phân tích: {ex.Message}";
                lblStatus.ForeColor = Color.FromArgb(190, 50, 50);
                MessageBox.Show($"Không thể phân tích hóa đơn: {ex.Message}", "Lỗi AI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                prgStatus.Visible = false;
                btnAnalyze.Enabled = true;
                btnChooseImage.Enabled = true;
            }
        }

        private void BtnSaveSelected_Click(object? sender, EventArgs e)
        {
            int savedCount = SaveSelectedItems();
            if (savedCount == 0)
            {
                MessageBox.Show("Vui lòng tích chọn ít nhất một món cần lưu.", "Chưa chọn món", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblSummary.Text = $"Đã thêm {savedCount} món vào tủ lạnh.";
            MessageBox.Show($"Đã lưu {savedCount} món vào tủ lạnh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        // **
        private int SaveSelectedItems()
        {
            if (_lastScannedItems.Count == 0) return 0;

            dgvItems.EndEdit();
            long userId = AppSession.CurrentUserId;
            int savedCount = 0;
            for (int i = 0; i < dgvItems.Rows.Count; i++)
            {
                var row = dgvItems.Rows[i];
                bool isChecked = Convert.ToBoolean(row.Cells["colCheck"].Value);
                if (!isChecked) continue;

                string foodName = row.Cells["colName"].Value?.ToString() ?? "";
                if (string.IsNullOrWhiteSpace(foodName)) continue;

                decimal.TryParse(row.Cells["colQty"].Value?.ToString(), out decimal qty);
                if (qty <= 0) qty = 1;

                string unit = row.Cells["colUnit"].Value?.ToString() ?? "g";
                string storageRaw = row.Cells["colStorage"].Value?.ToString() ?? "";
                string storage = storageRaw.Contains("Đá") ? "FREEZER" : "CHILL";

                var matched = _lastScannedItems.FirstOrDefault(it => it.FoodName == foodName);
                int cal = matched?.EstimatedCalories ?? 150;
                decimal pro = matched?.EstimatedProtein ?? 5;
                decimal carb = matched?.EstimatedCarbs ?? 20;
                decimal fat = matched?.EstimatedFat ?? 3;
                int expDays = matched?.ExpiryDays ?? (storage == "FREEZER" ? 30 : 5);

                var food = _foodRepo.FindOrCreate(foodName, cal, pro, carb, fat, unit, userId);
                var expiryDate = DateOnly.FromDateTime(DateTime.Today.AddDays(expDays));
                _fridgeService.AddItem(userId, food.Id, qty, storage, expiryDate);

                row.Cells["colCheck"].Value = false;
                savedCount++;
            }

            if (savedCount > 0)
            {
                _hasAddedToFridge = true;
                lblSummary.Text = $"Đã thêm {savedCount} món vào tủ lạnh.";
            }

            return savedCount;

        }
    }
}
