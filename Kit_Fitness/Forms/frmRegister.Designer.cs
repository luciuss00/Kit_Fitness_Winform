namespace Kit_Fitness.Forms;

partial class frmRegister
{
    private System.ComponentModel.IContainer components = null!;
    private Panel pnlBody = null!;
    private Label lblLogo = null!;
    private Label lblSubtitle = null!;
    private Label lblName = null!;
    private TextBox txtName = null!;
    private Label lblPassword = null!;
    private TextBox txtPassword = null!;
    private Label lblConfirmPassword = null!;
    private TextBox txtConfirmPassword = null!;
    private Button btnRegister = null!;
    private Button btnCancel = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlBody          = new Panel();
        lblLogo          = new Label();
        lblSubtitle      = new Label();
        lblName          = new Label();
        txtName          = new TextBox();
        lblPassword      = new Label();
        txtPassword      = new TextBox();
        lblConfirmPassword = new Label();
        txtConfirmPassword = new TextBox();
        btnRegister      = new Button();
        btnCancel        = new Button();

        pnlBody.SuspendLayout();
        SuspendLayout();

        // ── pnlBody ──────────────────────────────────────
        pnlBody.BackColor = Color.FromArgb(250, 247, 240);
        pnlBody.Controls.AddRange(new Control[]
        {
            lblLogo, lblSubtitle,
            lblName, txtName,
            lblPassword, txtPassword,
            lblConfirmPassword, txtConfirmPassword,
            btnRegister, btnCancel
        });
        pnlBody.Dock     = DockStyle.Fill;
        pnlBody.Location = new Point(0, 0);
        pnlBody.Name     = "pnlBody";
        pnlBody.Size     = new Size(440, 460);
        pnlBody.TabIndex = 0;

        // ── lblLogo ───────────────────────────────────────
        lblLogo.Font      = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblLogo.ForeColor = Color.FromArgb(34, 76, 56);
        lblLogo.Location  = new Point(30, 28);
        lblLogo.Name      = "lblLogo";
        lblLogo.Size      = new Size(380, 46);
        lblLogo.TabIndex  = 0;
        lblLogo.Text      = "KIT FITNESS";
        lblLogo.TextAlign = ContentAlignment.MiddleCenter;

        // ── lblSubtitle ───────────────────────────────────
        lblSubtitle.ForeColor = Color.FromArgb(105, 100, 91);
        lblSubtitle.Location  = new Point(30, 78);
        lblSubtitle.Name      = "lblSubtitle";
        lblSubtitle.Size      = new Size(380, 36);
        lblSubtitle.TabIndex  = 1;
        lblSubtitle.Text      = "Tạo tài khoản để bắt đầu hành trình khỏe hơn";
        lblSubtitle.TextAlign = ContentAlignment.TopCenter;

        // ── lblName ───────────────────────────────────────
        lblName.ForeColor = Color.FromArgb(70, 70, 65);
        lblName.Location  = new Point(30, 128);
        lblName.Name      = "lblName";
        lblName.Size      = new Size(380, 22);
        lblName.TabIndex  = 2;
        lblName.Text      = "Tên tài khoản";

        // ── txtName ───────────────────────────────────────
        txtName.BackColor   = Color.White;
        txtName.BorderStyle = BorderStyle.FixedSingle;
        txtName.Font        = new Font("Segoe UI", 10F);
        txtName.Location    = new Point(30, 152);
        txtName.Name        = "txtName";
        txtName.Size        = new Size(380, 30);
        txtName.TabIndex    = 3;

        // ── lblPassword ───────────────────────────────────
        lblPassword.ForeColor = Color.FromArgb(70, 70, 65);
        lblPassword.Location  = new Point(30, 196);
        lblPassword.Name      = "lblPassword";
        lblPassword.Size      = new Size(380, 22);
        lblPassword.TabIndex  = 4;
        lblPassword.Text      = "Mật khẩu";

        // ── txtPassword ───────────────────────────────────
        txtPassword.BackColor            = Color.White;
        txtPassword.BorderStyle          = BorderStyle.FixedSingle;
        txtPassword.Font                 = new Font("Segoe UI", 10F);
        txtPassword.Location             = new Point(30, 220);
        txtPassword.Name                 = "txtPassword";
        txtPassword.Size                 = new Size(380, 30);
        txtPassword.TabIndex             = 5;
        txtPassword.UseSystemPasswordChar = true;

        // ── lblConfirmPassword ────────────────────────────
        lblConfirmPassword.ForeColor = Color.FromArgb(70, 70, 65);
        lblConfirmPassword.Location  = new Point(30, 264);
        lblConfirmPassword.Name      = "lblConfirmPassword";
        lblConfirmPassword.Size      = new Size(380, 22);
        lblConfirmPassword.TabIndex  = 6;
        lblConfirmPassword.Text      = "Xác nhận mật khẩu";

        // ── txtConfirmPassword ────────────────────────────
        txtConfirmPassword.BackColor            = Color.White;
        txtConfirmPassword.BorderStyle          = BorderStyle.FixedSingle;
        txtConfirmPassword.Font                 = new Font("Segoe UI", 10F);
        txtConfirmPassword.Location             = new Point(30, 288);
        txtConfirmPassword.Name                 = "txtConfirmPassword";
        txtConfirmPassword.Size                 = new Size(380, 30);
        txtConfirmPassword.TabIndex             = 7;
        txtConfirmPassword.UseSystemPasswordChar = true;

        // ── btnRegister ───────────────────────────────────
        btnRegister.BackColor              = Color.FromArgb(41, 75, 54);
        btnRegister.Cursor                 = Cursors.Hand;
        btnRegister.FlatAppearance.BorderSize = 0;
        btnRegister.FlatStyle              = FlatStyle.Flat;
        btnRegister.Font                   = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        btnRegister.ForeColor              = Color.White;
        btnRegister.Location               = new Point(30, 336);
        btnRegister.Name                   = "btnRegister";
        btnRegister.Size                   = new Size(380, 48);
        btnRegister.TabIndex               = 8;
        btnRegister.Text                   = "ĐĂNG KÝ";
        btnRegister.UseVisualStyleBackColor = false;
        btnRegister.Click                  += BtnRegister_Click;

        // ── btnCancel ─────────────────────────────────────
        btnCancel.BackColor                         = Color.Transparent;
        btnCancel.Cursor                            = Cursors.Hand;
        btnCancel.FlatAppearance.BorderSize         = 0;
        btnCancel.FlatAppearance.MouseDownBackColor = Color.Transparent;
        btnCancel.FlatAppearance.MouseOverBackColor = Color.Transparent;
        btnCancel.FlatStyle                         = FlatStyle.Flat;
        btnCancel.Font                              = new Font("Segoe UI", 10F, FontStyle.Underline);
        btnCancel.ForeColor                         = Color.FromArgb(41, 75, 54);
        btnCancel.Location                          = new Point(30, 392);
        btnCancel.Name                              = "btnCancel";
        btnCancel.Size                              = new Size(380, 36);
        btnCancel.TabIndex                          = 9;
        btnCancel.Text                              = "Quay lại đăng nhập";
        btnCancel.UseVisualStyleBackColor           = false;
        btnCancel.Click                             += BtnCancel_Click;

        // ── frmRegister ───────────────────────────────────
        AcceptButton        = btnRegister;
        AutoScaleDimensions = new SizeF(9F, 23F);
        AutoScaleMode       = AutoScaleMode.Font;
        BackColor           = Color.FromArgb(250, 247, 240);
        CancelButton        = btnCancel;
        ClientSize          = new Size(440, 460);
        Controls.Add(pnlBody);
        Font                = new Font("Segoe UI", 10F);
        FormBorderStyle     = FormBorderStyle.FixedDialog;
        MaximizeBox         = false;
        MinimizeBox         = false;
        Name                = "frmRegister";
        StartPosition       = FormStartPosition.CenterScreen;
        Text                = "Kit Fitness - Đăng ký";

        pnlBody.ResumeLayout(false);
        ResumeLayout(false);
    }
}
