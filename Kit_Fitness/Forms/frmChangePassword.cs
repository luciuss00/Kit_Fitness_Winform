using Kit_Fitness.Helpers;
using Kit_Fitness.Repositories;

namespace Kit_Fitness.Forms;

public sealed partial class frmChangePassword : Form
{
    private readonly AuthRepository _authRepository = new();
    private readonly long _userId;

    public frmChangePassword(long? userId = null)
    {
        InitializeComponent();
        _userId = userId ?? AppSession.CurrentUserId;
    }

    private void BtnChangePassword_Click(object? sender, EventArgs e)
    {
        var currentPassword = txtCurrentPassword.Text;
        var newPassword = txtNewPassword.Text;
        var confirmPassword = txtConfirmPassword.Text;

        if (string.IsNullOrWhiteSpace(currentPassword)
            || string.IsNullOrWhiteSpace(newPassword)
            || string.IsNullOrWhiteSpace(confirmPassword))
        {
            ShowError("Vui lòng nhập đầy đủ các trường mật khẩu.");
            return;
        }

        if (newPassword.Length < 6)
        {
            ShowError("Mật khẩu mới phải có ít nhất 6 ký tự.");
            txtNewPassword.Focus();
            return;
        }

        if (newPassword != confirmPassword)
        {
            ShowError("Mật khẩu xác nhận không khớp với mật khẩu mới.");
            txtConfirmPassword.Focus();
            return;
        }

        try
        {
            var result = _authRepository.ChangePassword(_userId, currentPassword, newPassword);
            if (!result.Success)
            {
                ShowError(result.Message);
                return;
            }

            MessageBox.Show(
                "Đổi mật khẩu thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            var detail = ex.GetBaseException().Message;
            MessageBox.Show(
                $"Không thể đổi mật khẩu. Vui lòng kiểm tra cơ sở dữ liệu.\n\nChi tiết lỗi: {detail}",
                "Lỗi đổi mật khẩu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void LnkForgotPassword_Click(object? sender, EventArgs e)
    {
        using var forgotForm = new frmForgotPassword();
        if (forgotForm.ShowDialog(this) == DialogResult.OK)
        {
            // Nếu người dùng đã đặt lại mật khẩu thành công qua mã khôi phục, đóng form đổi pass
            DialogResult = DialogResult.OK;
        }
    }

    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    private void ShowError(string message)
    {
        MessageBox.Show(message, "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
