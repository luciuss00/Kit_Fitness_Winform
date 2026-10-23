namespace Kit_Fitness.Forms;

partial class frmChangePassword
{
    private System.ComponentModel.IContainer components = null!;
    private Panel pnlBody = null!;
    private Label lblLogo = null!;
    private Label lblSubtitle = null!;
    private Label lblCurrentPassword = null!;
    private TextBox txtCurrentPassword = null!;
    private Label lblNewPassword = null!;
    private TextBox txtNewPassword = null!;
    private Label lblConfirmPassword = null!;
    private TextBox txtConfirmPassword = null!;
    private LinkLabel lnkForgotPassword = null!;
    private Button btnChangePassword = null!;
    private Button btnCancel = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlBody = new Panel();
        lblLogo = new Label();
        lblSubtitle = new Label();
        lblCurrentPassword = new Label();
        txtCurrentPassword = new TextBox();
        lblNewPassword = new Label();
        txtNewPassword = new TextBox();
        lblConfirmPassword = new Label();
        txtConfirmPassword = new TextBox();
        lnkForgotPassword = new LinkLabel();
        btnChangePassword = new Button();
        btnCancel = new Button();
        pnlBody.SuspendLayout();
        SuspendLayout();
        // 
        // pnlBody
        // 
        pnlBody.BackColor = Color.FromArgb(250, 247, 240);
        pnlBody.Controls.Add(lblLogo);
        pnlBody.Controls.Add(lblSubtitle);
        pnlBody.Controls.Add(lblCurrentPassword);
        pnlBody.Controls.Add(txtCurrentPassword);
        pnlBody.Controls.Add(lblNewPassword);
        pnlBody.Controls.Add(txtNewPassword);
        pnlBody.Controls.Add(lblConfirmPassword);
        pnlBody.Controls.Add(txtConfirmPassword);
        pnlBody.Controls.Add(lnkForgotPassword);
        pnlBody.Controls.Add(btnChangePassword);
        pnlBody.Controls.Add(btnCancel);
        pnlBody.Dock = DockStyle.Fill;
        pnlBody.Location = new Point(0, 0);
        pnlBody.Name = "pnlBody";
        pnlBody.Size = new Size(458, 470);
        pnlBody.TabIndex = 0;
        // 
        // lblLogo
        // 
        lblLogo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblLogo.ForeColor = Color.FromArgb(34, 76, 56);
        lblLogo.Location = new Point(30, 24);
        lblLogo.Name = "lblLogo";
        lblLogo.Size = new Size(400, 42);
        lblLogo.TabIndex = 0;
        lblLogo.Text = "KIT FITNESS";
        lblLogo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSubtitle
        // 
        lblSubtitle.ForeColor = Color.FromArgb(105, 100, 91);
        lblSubtitle.Location = new Point(30, 68);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(400, 28);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Đổi mật khẩu tài khoản";
        lblSubtitle.TextAlign = ContentAlignment.TopCenter;
        // 
        // lblCurrentPassword
        // 
        lblCurrentPassword.ForeColor = Color.FromArgb(70, 70, 65);
        lblCurrentPassword.Location = new Point(30, 104);
        lblCurrentPassword.Name = "lblCurrentPassword";
        lblCurrentPassword.Size = new Size(400, 22);
        lblCurrentPassword.TabIndex = 2;
        lblCurrentPassword.Text = "Mật khẩu hiện tại";
        // 
        // txtCurrentPassword
        // 
        txtCurrentPassword.BackColor = Color.White;
        txtCurrentPassword.BorderStyle = BorderStyle.FixedSingle;
        txtCurrentPassword.Font = new Font("Segoe UI", 10F);
        txtCurrentPassword.Location = new Point(30, 128);
        txtCurrentPassword.Name = "txtCurrentPassword";
        txtCurrentPassword.Size = new Size(400, 30);
        txtCurrentPassword.TabIndex = 3;
        txtCurrentPassword.UseSystemPasswordChar = true;
        // 
        // lblNewPassword
        // 
        lblNewPassword.ForeColor = Color.FromArgb(70, 70, 65);
        lblNewPassword.Location = new Point(30, 170);
        lblNewPassword.Name = "lblNewPassword";
        lblNewPassword.Size = new Size(400, 22);
        lblNewPassword.TabIndex = 4;
        lblNewPassword.Text = "Mật khẩu mới (tối thiểu 6 ký tự)";
        // 
        // txtNewPassword
        // 
        txtNewPassword.BackColor = Color.White;
        txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
        txtNewPassword.Font = new Font("Segoe UI", 10F);
        txtNewPassword.Location = new Point(30, 194);
        txtNewPassword.Name = "txtNewPassword";
        txtNewPassword.Size = new Size(400, 30);
        txtNewPassword.TabIndex = 5;
        txtNewPassword.UseSystemPasswordChar = true;
        // 
        // lblConfirmPassword
        // 
        lblConfirmPassword.ForeColor = Color.FromArgb(70, 70, 65);
        lblConfirmPassword.Location = new Point(30, 236);
        lblConfirmPassword.Name = "lblConfirmPassword";
        lblConfirmPassword.Size = new Size(400, 22);
        lblConfirmPassword.TabIndex = 6;
        lblConfirmPassword.Text = "Xác nhận mật khẩu mới";
        // 
        // txtConfirmPassword
        // 
        txtConfirmPassword.BackColor = Color.White;
        txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
        txtConfirmPassword.Font = new Font("Segoe UI", 10F);
        txtConfirmPassword.Location = new Point(30, 260);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.Size = new Size(400, 30);
        txtConfirmPassword.TabIndex = 7;
        txtConfirmPassword.UseSystemPasswordChar = true;
        // 
        // lnkForgotPassword
        // 
        lnkForgotPassword.ActiveLinkColor = Color.FromArgb(34, 76, 56);
        lnkForgotPassword.Cursor = Cursors.Hand;
        lnkForgotPassword.Font = new Font("Segoe UI", 9.5F);
        lnkForgotPassword.LinkBehavior = LinkBehavior.HoverUnderline;
        lnkForgotPassword.LinkColor = Color.FromArgb(120, 120, 120);
        lnkForgotPassword.Location = new Point(30, 300);
        lnkForgotPassword.Name = "lnkForgotPassword";
        lnkForgotPassword.Size = new Size(400, 24);
        lnkForgotPassword.TabIndex = 8;
        lnkForgotPassword.TabStop = true;
        lnkForgotPassword.Text = "Quên mật khẩu hiện tại?";
        lnkForgotPassword.TextAlign = ContentAlignment.MiddleRight;
        lnkForgotPassword.Click += LnkForgotPassword_Click;
        // 
        // btnChangePassword
        // 
        btnChangePassword.BackColor = Color.FromArgb(41, 75, 54);
        btnChangePassword.Cursor = Cursors.Hand;
        btnChangePassword.FlatAppearance.BorderSize = 0;
        btnChangePassword.FlatStyle = FlatStyle.Flat;
        btnChangePassword.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        btnChangePassword.ForeColor = Color.White;
        btnChangePassword.Location = new Point(30, 336);
        btnChangePassword.Name = "btnChangePassword";
        btnChangePassword.Size = new Size(400, 46);
        btnChangePassword.TabIndex = 9;
        btnChangePassword.Text = "LƯU MẬT KHẨU MỚI";
        btnChangePassword.UseVisualStyleBackColor = false;
        btnChangePassword.Click += BtnChangePassword_Click;
        // 
        // btnCancel
        // 
        btnCancel.BackColor = Color.Transparent;
        btnCancel.Cursor = Cursors.Hand;
        btnCancel.FlatAppearance.BorderSize = 0;
        btnCancel.FlatAppearance.MouseDownBackColor = Color.Transparent;
        btnCancel.FlatAppearance.MouseOverBackColor = Color.Transparent;
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Underline);
        btnCancel.ForeColor = Color.FromArgb(105, 100, 91);
        btnCancel.Location = new Point(30, 390);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(400, 36);
        btnCancel.TabIndex = 10;
        btnCancel.Text = "Hủy bỏ";
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += BtnCancel_Click;
        // 
        // frmChangePassword
        // 
        AcceptButton = btnChangePassword;
        AutoScaleDimensions = new SizeF(9F, 23F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(250, 247, 240);
        CancelButton = btnCancel;
        ClientSize = new Size(458, 450);
        Controls.Add(pnlBody);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "frmChangePassword";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Đổi mật khẩu";
        pnlBody.ResumeLayout(false);
        pnlBody.PerformLayout();
        ResumeLayout(false);
    }
}
