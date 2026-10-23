namespace Kit_Fitness.Forms;

partial class frmExpiringFoodNotification
{
    private System.ComponentModel.IContainer components = null!;
    private Panel pnlHeader = null!;
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;
    private Panel pnlContent = null!;
    private Panel pnlFooter = null!;
    private Button btnGoToFridge = null!;
    private Button btnClose = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlHeader = new Panel();
        lblTitle = new Label();
        lblSubtitle = new Label();
        pnlContent = new Panel();
        pnlFooter = new Panel();
        btnGoToFridge = new Button();
        btnClose = new Button();
        pnlHeader.SuspendLayout();
        pnlFooter.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.White;
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(lblSubtitle);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(24, 20, 24, 16);
        pnlHeader.Size = new Size(520, 84);
        pnlHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(34, 76, 56);
        lblTitle.Location = new Point(24, 18);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(401, 31);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "🔔  Cảnh Báo Hạn Dùng Thực Phẩm";
        // 
        // lblSubtitle
        // 
        lblSubtitle.AutoSize = true;
        lblSubtitle.Font = new Font("Segoe UI", 9.5F);
        lblSubtitle.ForeColor = Color.FromArgb(110, 110, 105);
        lblSubtitle.Location = new Point(26, 49);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(330, 21);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Các món trong Tủ Lạnh & Kho cần sớm sử dụng";
        // 
        // pnlContent
        // 
        pnlContent.AutoScroll = true;
        pnlContent.BackColor = Color.FromArgb(250, 247, 240);
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Location = new Point(0, 84);
        pnlContent.Name = "pnlContent";
        pnlContent.Padding = new Padding(20, 16, 20, 16);
        pnlContent.Size = new Size(520, 396);
        pnlContent.TabIndex = 1;
        // 
        // pnlFooter
        // 
        pnlFooter.BackColor = Color.White;
        pnlFooter.Controls.Add(btnGoToFridge);
        pnlFooter.Controls.Add(btnClose);
        pnlFooter.Dock = DockStyle.Bottom;
        pnlFooter.Location = new Point(0, 480);
        pnlFooter.Name = "pnlFooter";
        pnlFooter.Padding = new Padding(20, 12, 20, 14);
        pnlFooter.Size = new Size(520, 70);
        pnlFooter.TabIndex = 2;
        // 
        // btnGoToFridge
        // 
        btnGoToFridge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnGoToFridge.BackColor = Color.FromArgb(41, 75, 54);
        btnGoToFridge.Cursor = Cursors.Hand;
        btnGoToFridge.FlatAppearance.BorderSize = 0;
        btnGoToFridge.FlatStyle = FlatStyle.Flat;
        btnGoToFridge.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnGoToFridge.ForeColor = Color.White;
        btnGoToFridge.Location = new Point(236, 14);
        btnGoToFridge.Name = "btnGoToFridge";
        btnGoToFridge.Size = new Size(260, 42);
        btnGoToFridge.TabIndex = 0;
        btnGoToFridge.Text = "\U0001f9ca  Đi Đến Bếp && Kho (Tủ Lạnh)";
        btnGoToFridge.UseVisualStyleBackColor = false;
        btnGoToFridge.Click += BtnGoToFridge_Click;
        // 
        // btnClose
        // 
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.BackColor = Color.White;
        btnClose.Cursor = Cursors.Hand;
        btnClose.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
        btnClose.FlatStyle = FlatStyle.Flat;
        btnClose.Font = new Font("Segoe UI", 9.5F);
        btnClose.ForeColor = Color.FromArgb(100, 100, 95);
        btnClose.Location = new Point(130, 14);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(96, 42);
        btnClose.TabIndex = 1;
        btnClose.Text = "Đóng";
        btnClose.UseVisualStyleBackColor = false;
        btnClose.Click += BtnClose_Click;
        // 
        // frmExpiringFoodNotification
        // 
        AcceptButton = btnGoToFridge;
        AutoScaleDimensions = new SizeF(9F, 23F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(250, 247, 240);
        CancelButton = btnClose;
        ClientSize = new Size(580, 560);
        Controls.Add(pnlContent);
        Controls.Add(pnlFooter);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "frmExpiringFoodNotification";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Thông Báo Thực Phẩm Sắp Hết Hạn";
        Load += frmExpiringFoodNotification_Load;
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        pnlFooter.ResumeLayout(false);
        ResumeLayout(false);
    }
}
