using Kit_Fitness.Helpers;
using Kit_Fitness.Models;
using Kit_Fitness.Services;

namespace Kit_Fitness.Forms
{
    public partial class frmAddFridgeItem : Form
    {
        // DEPENDENCIES: Các dịch vụ nghiệp vụ mà Form này phụ thuộc vào.
        // Khởi tạo trực tiếp (Direct Instantiation bằng toán tử new), đánh dấu readonly để chống bị gán đè/null giữa chừng.
        private readonly FridgeService _fridgeService = new();     // Xử lý thêm thực phẩm vào tủ lạnh
        private readonly MealLogService _mealLogService = new();   // Lấy danh sách món ăn & tạo món mới

        // INTERNAL STATE: Biến trường nội bộ lưu danh sách Food để hiển thị lên ComboBox cbFood
        private List<Food> _foods = new();

        public frmAddFridgeItem(string defaultStorage = "CHILL")
        {
            InitializeComponent();
            
            // Gọi hàm nạp danh sách món ăn từ SQL Server vào ComboBox ngay sau khi vẽ giao diện
            LoadFoods();

            if (defaultStorage == "FREEZER")
            {
                rbFreezer.Checked = true;
            }
            else
            {
                rbChill.Checked = true;
            }

            dtpExpiry.Value = DateTime.Today.AddDays(rbChill.Checked ? 5 : 30);
            rbChill.CheckedChanged += (s, e) =>
            {
                if (rbChill.Checked) dtpExpiry.Value = DateTime.Today.AddDays(5);
            };
            rbFreezer.CheckedChanged += (s, e) =>
            {
                if (rbFreezer.Checked) dtpExpiry.Value = DateTime.Today.AddDays(30);
            };
        }

        // **
        private void LoadFoods()
        {
            _foods = _mealLogService.GetAllFoods(AppSession.CurrentUserId);
            cbFood.DataSource = _foods;
            cbFood.DisplayMember = "Name";
            cbFood.ValueMember = "Id";

            cbFood.SelectedIndexChanged += (s, e) =>
            {
                if (cbFood.SelectedItem is Food f && !string.IsNullOrEmpty(f.Unit))
                {
                    cbUnit.Text = f.Unit;
                }
            };
        }

        // **
        private void BtnSave_Click(object? sender, EventArgs e)
        {
            string foodName = cbFood.Text.Trim();
            if (string.IsNullOrWhiteSpace(foodName))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập tên thực phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var food = _foods.FirstOrDefault(item =>
                    item.Name.Equals(foodName, StringComparison.OrdinalIgnoreCase));
                if (food is null)
                {
                    food = _mealLogService.FindOrCreateFood(foodName, unit: cbUnit.Text.Trim());
                    _foods.Add(food);
                }

                long userId = AppSession.CurrentUserId;
                string storage = rbChill.Checked ? "CHILL" : "FREEZER";
                var expiryDate = DateOnly.FromDateTime(dtpExpiry.Value);

                _fridgeService.AddItem(userId, food.Id, numQuantity.Value, storage, expiryDate);

                MessageBox.Show($"Đã cất {food.Name} vào {(storage == "CHILL" ? "Ngăn Mát" : "Ngăn Đá")}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cất thực phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void frmAddFridgeItem_Load(object sender, EventArgs e)
        {

        }
    }
}
