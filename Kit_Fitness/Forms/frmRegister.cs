using Kit_Fitness.Repositories;

namespace Kit_Fitness.Forms;

public sealed partial class frmRegister : Form
{
    private readonly AuthRepository _authRepository = new();

    /// <summary>Tên tài khoản vừa đăng ký (để điền sẵn vào form login).</summary>
    public string RegisteredUserName { get; private set; } = string.Empty;

    public frmRegister()
    {
        InitializeComponent();
    }

    // **
    private void BtnRegister_Click(object? sender, EventArgs e)
    {
        var userName = txtName.Text.Trim();
        var password = txtPassword.Text;

        if (string.IsNullOrWhiteSpace(userName)
            || string.IsNullOrWhiteSpace(password)
            || string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
        {
            ShowError("Vui lòng nhập đầy đủ thông tin.");
            return;
        }

        if (userName.Length > 100)
        {
            ShowError("Tên tài khoản không được dài quá 100 ký tự.");
            return;
        }

        if (password.Length < 6)
        {
            ShowError("Mật khẩu phải có ít nhất 6 ký tự.");
            return;
        }

        if (password != txtConfirmPassword.Text)
        {
            ShowError("Mật khẩu xác nhận không khớp.");
            return;
        }

        try
        {
            var result = _authRepository.Register(userName, password);
            if (!result.Success)
            {
                ShowError(result.Message);
                return;
            }

            RegisteredUserName = userName;

            // Hiển thị mã khôi phục cho người dùng lưu lại
            MessageBox.Show(
                $"Đăng ký thành công!\n\n" +
                $"Mã khôi phục tài khoản của bạn:\n\n" +
                $"    {result.RecoveryCode}\n\n" +
                "⚠️  Hãy lưu mã này ở nơi an toàn.\n" +
                "Bạn sẽ cần dùng nó nếu quên mật khẩu.",
                "Đăng ký thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            var detail = ex.GetBaseException().Message;
            MessageBox.Show(
                $"Không thể tạo tài khoản. Vui lòng kiểm tra cơ sở dữ liệu.\n\nChi tiết lỗi: {detail}",
                "Lỗi đăng ký",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    private void ShowError(string message)
    {
        MessageBox.Show(message, "Thông tin đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
