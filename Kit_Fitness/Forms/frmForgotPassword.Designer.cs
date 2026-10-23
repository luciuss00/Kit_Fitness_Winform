namespace Kit_Fitness.Forms;

partial class frmForgotPassword
{
    private System.ComponentModel.IContainer components = null!;
    private Panel pnlBody = null!;
    private Label lblLogo = null!;
    private Label lblSubtitle = null!;
    private Panel pnlHint = null!;
    private Label lblHint = null!;
    private Label lblUserName = null!;
    private TextBox txtUserName = null!;
    private Label lblRecoveryCode = null!;
    private TextBox txtRecoveryCode = null!;
    private Label lblNewPassword = null!;
    private TextBox txtNewPassword = null!;
    private Label lblConfirmPassword = null!;
    private TextBox txtConfirmPassword = null!;
    private Button btnReset = null!;
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
        pnlHint = new Panel();
        lblHint = new Label();
        lblUserName = new Label();
        txtUserName = new TextBox();
        lblRecoveryCode = new Label();
        txtRecoveryCode = new TextBox();
        lblNewPassword = new Label();
        txtNewPassword = new TextBox();
        lblConfirmPassword = new Label();
        txtConfirmPassword = new TextBox();
        btnReset = new Button();
        btnCancel = new Button();
        pnlBody.SuspendLayout();
        pnlHint.SuspendLayout();
        SuspendLayout();
        // 
        // pnlBody
        // 
        pnlBody.BackColor = Color.FromArgb(250, 247, 240);
        pnlBody.Controls.Add(lblLogo);
        pnlBody.Controls.Add(lblSubtitle);
        pnlBody.Controls.Add(pnlHint);
        pnlBody.Controls.Add(lblUserName);
        pnlBody.Controls.Add(txtUserName);
        pnlBody.Controls.Add(lblRecoveryCode);
        pnlBody.Controls.Add(txtRecoveryCode);
        pnlBody.Controls.Add(lblNewPassword);
        pnlBody.Controls.Add(txtNewPassword);
        pnlBody.Controls.Add(lblConfirmPassword);
        pnlBody.Controls.Add(txtConfirmPassword);
        pnlBody.Controls.Add(btnReset);
        pnlBody.Controls.Add(btnCancel);
        pnlBody.Dock = DockStyle.Fill;
        pnlBody.Location = new Point(0, 0);
        pnlBody.Name = "pnlBody";
        pnlBody.Size = new Size(458, 601);
        pnlBody.TabIndex = 0;
        // 
        // lblLogo
        // 
        lblLogo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblLogo.ForeColor = Color.FromArgb(34, 76, 56);
        lblLogo.Location = new Point(30, 28);
        lblLogo.Name = "lblLogo";
        lblLogo.Size = new Size(400, 46);
        lblLogo.TabIndex = 0;
        lblLogo.Text = "KIT FITNESS";
        lblLogo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSubtitle
        // 
        lblSubtitle.ForeColor = Color.FromArgb(105, 100, 91);
        lblSubtitle.Location = new Point(30, 78);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(400, 30);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Đặt lại mật khẩu bằng mã khôi phục";
        lblSubtitle.TextAlign = ContentAlignment.TopCenter;
        // 
        // pnlHint
        // 
        pnlHint.BackColor = Color.FromArgb(215, 238, 225);
        pnlHint.Controls.Add(lblHint);
        pnlHint.Location = new Point(30, 116);
        pnlHint.Name = "pnlHint";
        pnlHint.Padding = new Padding(10, 8, 10, 8);
        pnlHint.Size = new Size(400, 63);
        pnlHint.TabIndex = 2;
        // 
        // lblHint
        // 
        lblHint.Dock = DockStyle.Fill;
        lblHint.Font = new Font("Segoe UI", 8.5F);
        lblHint.ForeColor = Color.FromArgb(25, 80, 50);
        lblHint.Location = new Point(10, 8);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(380, 47);
        lblHint.TabIndex = 0;
        lblHint.Text = "🔑  Nhập tên tài khoản và mã khôi phục dạng XXXX-XXXX-XXXX-XXXX\n     mà bạn đã nhận khi đăng ký.";
        // 
        // lblUserName
        // 
        lblUserName.ForeColor = Color.FromArgb(70, 70, 65);
        lblUserName.Location = new Point(30, 194);
        lblUserName.Name = "lblUserName";
        lblUserName.Size = new Size(400, 22);
        lblUserName.TabIndex = 3;
        lblUserName.Text = "Tên tài khoản";
        // 
        // txtUserName
        // 
        txtUserName.BackColor = Color.White;
        txtUserName.BorderStyle = BorderStyle.FixedSingle;
        txtUserName.Font = new Font("Segoe UI", 10F);
        txtUserName.Location = new Point(30, 218);
        txtUserName.Name = "txtUserName";
        txtUserName.Size = new Size(400, 30);
        txtUserName.TabIndex = 4;
        // 
        // lblRecoveryCode
        // 
        lblRecoveryCode.ForeColor = Color.FromArgb(70, 70, 65);
        lblRecoveryCode.Location = new Point(30, 260);
        lblRecoveryCode.Name = "lblRecoveryCode";
        lblRecoveryCode.Size = new Size(400, 22);
        lblRecoveryCode.TabIndex = 5;
        lblRecoveryCode.Text = "Mã khôi phục";
        // 
        // txtRecoveryCode
        // 
        txtRecoveryCode.BackColor = Color.White;
        txtRecoveryCode.BorderStyle = BorderStyle.FixedSingle;
        txtRecoveryCode.CharacterCasing = CharacterCasing.Upper;
        txtRecoveryCode.Font = new Font("Segoe UI", 10F);
        txtRecoveryCode.Location = new Point(30, 284);
        txtRecoveryCode.Name = "txtRecoveryCode";
        txtRecoveryCode.Size = new Size(400, 30);
        txtRecoveryCode.TabIndex = 6;
        // 
        // lblNewPassword
        // 
        lblNewPassword.ForeColor = Color.FromArgb(70, 70, 65);
        lblNewPassword.Location = new Point(30, 326);
        lblNewPassword.Name = "lblNewPassword";
        lblNewPassword.Size = new Size(400, 22);
        lblNewPassword.TabIndex = 7;
        lblNewPassword.Text = "Mật khẩu mới";
        // 
        // txtNewPassword
        // 
        txtNewPassword.BackColor = Color.White;
        txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
        txtNewPassword.Font = new Font("Segoe UI", 10F);
        txtNewPassword.Location = new Point(30, 350);
        txtNewPassword.Name = "txtNewPassword";
        txtNewPassword.Size = new Size(400, 30);
        txtNewPassword.TabIndex = 8;
        txtNewPassword.UseSystemPasswordChar = true;
        // 
        // lblConfirmPassword
        // 
        lblConfirmPassword.ForeColor = Color.FromArgb(70, 70, 65);
        lblConfirmPassword.Location = new Point(30, 392);
        lblConfirmPassword.Name = "lblConfirmPassword";
        lblConfirmPassword.Size = new Size(400, 22);
        lblConfirmPassword.TabIndex = 9;
        lblConfirmPassword.Text = "Xác nhận mật khẩu";
        // 
        // txtConfirmPassword
        // 
        txtConfirmPassword.BackColor = Color.White;
        txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
        txtConfirmPassword.Font = new Font("Segoe UI", 10F);
        txtConfirmPassword.Location = new Point(30, 416);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.Size = new Size(400, 30);
        txtConfirmPassword.TabIndex = 10;
        txtConfirmPassword.UseSystemPasswordChar = true;
        // 
        // btnReset
        // 
        btnReset.BackColor = Color.FromArgb(41, 75, 54);
        btnReset.Cursor = Cursors.Hand;
        btnReset.FlatAppearance.BorderSize = 0;
        btnReset.FlatStyle = FlatStyle.Flat;
        btnReset.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        btnReset.ForeColor = Color.White;
        btnReset.Location = new Point(30, 462);
        btnReset.Name = "btnReset";
        btnReset.Size = new Size(400, 48);
        btnReset.TabIndex = 11;
        btnReset.Text = "ĐẶT LẠI MẬT KHẨU";
        btnReset.UseVisualStyleBackColor = false;
        btnReset.Click += BtnReset_Click;
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
        btnCancel.ForeColor = Color.FromArgb(41, 75, 54);
        btnCancel.Location = new Point(30, 518);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(400, 36);
        btnCancel.TabIndex = 12;
        btnCancel.Text = "Quay lại";
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += BtnCancel_Click;
        // 
        // frmForgotPassword
        // 
        AcceptButton = btnReset;
        AutoScaleDimensions = new SizeF(9F, 23F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(250, 247, 240);
        CancelButton = btnCancel;
        ClientSize = new Size(458, 601);
        Controls.Add(pnlBody);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "frmForgotPassword";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Kit Fitness - Đặt lại mật khẩu";
        pnlBody.ResumeLayout(false);
        pnlBody.PerformLayout();
        pnlHint.ResumeLayout(false);
        ResumeLayout(false);
    }
}
