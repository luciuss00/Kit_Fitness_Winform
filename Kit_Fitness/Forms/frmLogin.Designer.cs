namespace Kit_Fitness.Forms;

partial class frmLogin
{
    private System.ComponentModel.IContainer components = null!;
    private Panel pnlBody = null!;
    private Label lblLogo = null!;
    private Label lblSubtitle = null!;
    private Label lblUserName = null!;
    private TextBox txtUserName = null!;
    private Label lblPassword = null!;
    private TextBox txtPassword = null!;
    private Button btnLogin = null!;
    private LinkLabel lnkForgotPassword = null!;
    private LinkLabel lnkRegister = null!;

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
        lblUserName = new Label();
        txtUserName = new TextBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        btnLogin = new Button();
        lnkForgotPassword = new LinkLabel();
        lnkRegister = new LinkLabel();
        pnlBody.SuspendLayout();
        SuspendLayout();
        // 
        // pnlBody
        // 
        pnlBody.BackColor = Color.FromArgb(250, 247, 240);
        pnlBody.Controls.Add(lblLogo);
        pnlBody.Controls.Add(lblSubtitle);
        pnlBody.Controls.Add(lblUserName);
        pnlBody.Controls.Add(txtUserName);
        pnlBody.Controls.Add(lblPassword);
        pnlBody.Controls.Add(txtPassword);
        pnlBody.Controls.Add(btnLogin);
        pnlBody.Controls.Add(lnkForgotPassword);
        pnlBody.Controls.Add(lnkRegister);
        pnlBody.Dock = DockStyle.Fill;
        pnlBody.Location = new Point(0, 0);
        pnlBody.Name = "pnlBody";
        pnlBody.Size = new Size(440, 460);
        pnlBody.TabIndex = 0;
        // 
        // lblLogo
        // 
        lblLogo.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
        lblLogo.ForeColor = Color.FromArgb(34, 76, 56);
        lblLogo.Location = new Point(30, 32);
        lblLogo.Name = "lblLogo";
        lblLogo.Size = new Size(380, 50);
        lblLogo.TabIndex = 0;
        lblLogo.Text = "KIT FITNESS";
        lblLogo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSubtitle
        // 
        lblSubtitle.ForeColor = Color.FromArgb(105, 100, 91);
        lblSubtitle.Location = new Point(30, 86);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(380, 44);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Chào mừng bạn!\r\nĐăng nhập để bắt đầu hành trình của mình.";
        lblSubtitle.TextAlign = ContentAlignment.TopCenter;
        // 
        // lblUserName
        // 
        lblUserName.ForeColor = Color.FromArgb(70, 70, 65);
        lblUserName.Location = new Point(30, 148);
        lblUserName.Name = "lblUserName";
        lblUserName.Size = new Size(380, 22);
        lblUserName.TabIndex = 2;
        lblUserName.Text = "Tên tài khoản";
        // 
        // txtUserName
        // 
        txtUserName.BackColor = Color.White;
        txtUserName.BorderStyle = BorderStyle.FixedSingle;
        txtUserName.Font = new Font("Segoe UI", 10F);
        txtUserName.Location = new Point(30, 172);
        txtUserName.Name = "txtUserName";
        txtUserName.Size = new Size(380, 30);
        txtUserName.TabIndex = 3;
        // 
        // lblPassword
        // 
        lblPassword.ForeColor = Color.FromArgb(70, 70, 65);
        lblPassword.Location = new Point(30, 214);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(380, 22);
        lblPassword.TabIndex = 4;
        lblPassword.Text = "Mật khẩu";
        // 
        // txtPassword
        // 
        txtPassword.BackColor = Color.White;
        txtPassword.BorderStyle = BorderStyle.FixedSingle;
        txtPassword.Font = new Font("Segoe UI", 10F);
        txtPassword.Location = new Point(30, 238);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(380, 30);
        txtPassword.TabIndex = 5;
        txtPassword.UseSystemPasswordChar = true;
        // 
        // btnLogin
        // 
        btnLogin.BackColor = Color.FromArgb(41, 75, 54);
        btnLogin.Cursor = Cursors.Hand;
        btnLogin.FlatAppearance.BorderSize = 0;
        btnLogin.FlatStyle = FlatStyle.Flat;
        btnLogin.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        btnLogin.ForeColor = Color.White;
        btnLogin.Location = new Point(30, 284);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(380, 48);
        btnLogin.TabIndex = 6;
        btnLogin.Text = "ĐĂNG NHẬP";
        btnLogin.UseVisualStyleBackColor = false;
        btnLogin.Click += BtnLogin_Click;
        // 
        // lnkForgotPassword
        // 
        lnkForgotPassword.ActiveLinkColor = Color.FromArgb(25, 55, 40);
        lnkForgotPassword.Cursor = Cursors.Hand;
        lnkForgotPassword.LinkColor = Color.FromArgb(120, 120, 115);
        lnkForgotPassword.Location = new Point(30, 342);
        lnkForgotPassword.Name = "lnkForgotPassword";
        lnkForgotPassword.Size = new Size(380, 28);
        lnkForgotPassword.TabIndex = 7;
        lnkForgotPassword.TabStop = true;
        lnkForgotPassword.Text = "Quên mật khẩu?";
        lnkForgotPassword.TextAlign = ContentAlignment.MiddleCenter;
        lnkForgotPassword.Click += ForgotPasswordLink_Click;
        // 
        // lnkRegister
        // 
        lnkRegister.ActiveLinkColor = Color.FromArgb(25, 55, 40);
        lnkRegister.Cursor = Cursors.Hand;
        lnkRegister.LinkColor = Color.FromArgb(41, 75, 54);
        lnkRegister.Location = new Point(30, 376);
        lnkRegister.Name = "lnkRegister";
        lnkRegister.Size = new Size(380, 36);
        lnkRegister.TabIndex = 8;
        lnkRegister.TabStop = true;
        lnkRegister.Text = "Chưa có tài khoản?  Đăng ký ngay";
        lnkRegister.TextAlign = ContentAlignment.MiddleCenter;
        lnkRegister.Click += RegisterLink_Click;
        // 
        // frmLogin
        // 
        AcceptButton = btnLogin;
        AutoScaleDimensions = new SizeF(9F, 23F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(250, 247, 240);
        ClientSize = new Size(440, 460);
        Controls.Add(pnlBody);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "frmLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Kit Fitness - Đăng nhập";
        pnlBody.ResumeLayout(false);
        pnlBody.PerformLayout();
        ResumeLayout(false);
    }
}
