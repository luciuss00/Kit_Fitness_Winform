using Kit_Fitness.Helpers;
using Kit_Fitness.Repositories;

namespace Kit_Fitness.Forms;

public sealed partial class frmLogin : Form
{
    private readonly AuthRepository _authRepository = new();

    public frmLogin()
    {
        InitializeComponent();
    }

    private void BtnLogin_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            ShowError("Vui lòng nhập tên tài khoản và mật khẩu.");
            return;
        }

        try
        {
            var result = _authRepository.Login(txtUserName.Text, txtPassword.Text);
            if (!result.Success)
            {
                ShowError(result.Message);
                return;
            }

            AppSession.CurrentUserId   = result.UserId;
            AppSession.CurrentUserName = result.UserName;
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            var detail = ex.GetBaseException().Message;
            MessageBox.Show(
                $"Không thể đăng nhập. Vui lòng kiểm tra cơ sở dữ liệu.\n\nChi tiết lỗi: {detail}",
                "Lỗi đăng nhập",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void RegisterLink_Click(object? sender, EventArgs e)
    {
        using var registerForm = new frmRegister();
        if (registerForm.ShowDialog(this) == DialogResult.OK)
        {
            txtUserName.Text = registerForm.RegisteredUserName;
            txtPassword.Clear();
            txtPassword.Focus();
        }
    }

    private void ForgotPasswordLink_Click(object? sender, EventArgs e)
    {
        using var forgotForm = new frmForgotPassword();
        if (forgotForm.ShowDialog(this) == DialogResult.OK)
        {
            // Điền sẵn tên tài khoản để người dùng chỉ cần nhập pass mới
            txtUserName.Text = forgotForm.RestoredUserName;
            txtPassword.Clear();
            txtPassword.Focus();
        }
    }

    private void ShowError(string message)
    {
        MessageBox.Show(message, "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
