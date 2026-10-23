using Kit_Fitness.Repositories;

namespace Kit_Fitness.Forms;

public sealed partial class frmForgotPassword : Form
{
    private readonly AuthRepository _authRepository = new();

    /// <summary>Tên tài khoản vừa đặt lại mật khẩu (để điền sẵn vào form login).</summary>
    public string RestoredUserName { get; private set; } = string.Empty;

    public frmForgotPassword()
    {
        InitializeComponent();
    }

    private void BtnReset_Click(object? sender, EventArgs e)
    {
        var userName = txtUserName.Text.Trim();
        var recoveryCode = txtRecoveryCode.Text.Trim();
        var newPassword = txtNewPassword.Text;
        var confirmPwd = txtConfirmPassword.Text;

        // ── Validate ─────────────────────────────────────────────
        if (string.IsNullOrWhiteSpace(userName)
            || string.IsNullOrWhiteSpace(recoveryCode)
            || string.IsNullOrWhiteSpace(newPassword)
            || string.IsNullOrWhiteSpace(confirmPwd))
        {
            ShowError("Vui lòng nhập đầy đủ thông tin.");
            return;
        }

        if (newPassword.Length < 6)
        {
            ShowError("Mật khẩu mới phải có ít nhất 6 ký tự.");
            return;
        }

        if (newPassword != confirmPwd)
        {
            ShowError("Mật khẩu xác nhận không khớp.");
            return;
        }

        // ── Reset ────────────────────────────────────────────────
        try
        {
            var result = _authRepository.ResetPassword(userName, recoveryCode, newPassword);
            if (!result.Success)
            {
                ShowError(result.Message);
                return;
            }

            RestoredUserName = userName;

            MessageBox.Show(
                "Đặt lại mật khẩu thành công!\nHãy đăng nhập bằng mật khẩu mới.",
                "Kit Fitness",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            var detail = ex.GetBaseException().Message;
            MessageBox.Show(
                $"Không thể đặt lại mật khẩu. Vui lòng kiểm tra kết nối CSDL.\n\nChi tiết lỗi: {detail}",
                "Lỗi đặt lại mật khẩu",
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
        MessageBox.Show(message, "Quên mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
