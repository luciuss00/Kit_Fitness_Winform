namespace Kit_Fitness.Forms
{
    partial class frmScanReceipt
    {
        private System.ComponentModel.IContainer? components = null;
        private Panel pnlHeader = null!;
        private Label lblHeaderTitle = null!;
        private Label lblHeaderSub = null!;
        private TableLayoutPanel tlpMain = null!;
        private Panel pnlLeft = null!;
        private Label lblLeftTitle = null!;
        private Panel pnlLeftButtons = null!;
        private Panel pnlRight = null!;
        private Panel pnlStatus = null!;
        private Panel pnlBottom = null!;
        private PictureBox picReceipt = null!;
        private Label lblImageInfo = null!;
        private Button btnChooseImage = null!;
        private Button btnAnalyze = null!;
        private ProgressBar prgStatus = null!;
        private Label lblStatus = null!;
        private DataGridView dgvItems = null!;
        private DataGridViewCheckBoxColumn colCheck = null!;
        private DataGridViewTextBoxColumn colName = null!;
        private DataGridViewTextBoxColumn colQty = null!;
        private DataGridViewTextBoxColumn colUnit = null!;
        private DataGridViewTextBoxColumn colStorage = null!;
        private DataGridViewTextBoxColumn colExpiry = null!;
        private Button btnSaveSelected = null!;
        private Button btnClose = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
                picReceipt?.Image?.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblHeaderTitle = new Label();
            lblHeaderSub = new Label();
            tlpMain = new TableLayoutPanel();
            pnlLeft = new Panel();
            picReceipt = new PictureBox();
            lblImageInfo = new Label();
            pnlLeftButtons = new Panel();
            btnChooseImage = new Button();
            btnAnalyze = new Button();
            lblLeftTitle = new Label();
            pnlRight = new Panel();
            dgvItems = new DataGridView();
            colCheck = new DataGridViewCheckBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colUnit = new DataGridViewTextBoxColumn();
            colStorage = new DataGridViewTextBoxColumn();
            colExpiry = new DataGridViewTextBoxColumn();
            pnlBottom = new Panel();
            lblSummary = new Label();
            btnSaveSelected = new Button();
            btnClose = new Button();
            pnlStatus = new Panel();
            lblStatus = new Label();
            prgStatus = new ProgressBar();
            pnlHeader.SuspendLayout();
            tlpMain.SuspendLayout();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picReceipt).BeginInit();
            pnlLeftButtons.SuspendLayout();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            pnlBottom.SuspendLayout();
            pnlStatus.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(34, 76, 56);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Controls.Add(lblHeaderSub);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20, 12, 20, 12);
            pnlHeader.Size = new Size(1085, 68);
            pnlHeader.TabIndex = 1;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(20, 12);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(562, 28);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "📷 QUÉT HÓA ĐƠN AI VÀ TỰ ĐỘNG THÊM VÀO TỦ LẠNH";
            // 
            // lblHeaderSub
            // 
            lblHeaderSub.AutoSize = true;
            lblHeaderSub.Font = new Font("Segoe UI", 9F);
            lblHeaderSub.ForeColor = Color.FromArgb(200, 225, 210);
            lblHeaderSub.Location = new Point(20, 38);
            lblHeaderSub.Name = "lblHeaderSub";
            lblHeaderSub.Size = new Size(731, 20);
            lblHeaderSub.TabIndex = 1;
            lblHeaderSub.Text = "Gemini AI đọc ảnh hóa đơn siêu thị/chợ, tự động phân tích nguyên liệu, số lượng, hạn dùng và lưu vào tủ lạnh";
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 360F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(pnlLeft, 0, 0);
            tlpMain.Controls.Add(pnlRight, 1, 0);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 68);
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(15);
            tlpMain.RowCount = 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(1085, 632);
            tlpMain.TabIndex = 0;
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.Controls.Add(picReceipt);
            pnlLeft.Controls.Add(lblImageInfo);
            pnlLeft.Controls.Add(pnlLeftButtons);
            pnlLeft.Controls.Add(lblLeftTitle);
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.Location = new Point(15, 15);
            pnlLeft.Margin = new Padding(0, 0, 10, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(12);
            pnlLeft.Size = new Size(350, 602);
            pnlLeft.TabIndex = 0;
            // 
            // picReceipt
            // 
            picReceipt.BackColor = Color.FromArgb(245, 245, 243);
            picReceipt.BorderStyle = BorderStyle.FixedSingle;
            picReceipt.Dock = DockStyle.Fill;
            picReceipt.Location = new Point(12, 38);
            picReceipt.Name = "picReceipt";
            picReceipt.Size = new Size(326, 478);
            picReceipt.SizeMode = PictureBoxSizeMode.Zoom;
            picReceipt.TabIndex = 0;
            picReceipt.TabStop = false;
            // 
            // lblImageInfo
            // 
            lblImageInfo.Dock = DockStyle.Bottom;
            lblImageInfo.Font = new Font("Segoe UI", 8.5F);
            lblImageInfo.ForeColor = Color.FromArgb(120, 120, 115);
            lblImageInfo.Location = new Point(12, 516);
            lblImageInfo.Name = "lblImageInfo";
            lblImageInfo.Size = new Size(326, 30);
            lblImageInfo.TabIndex = 1;
            lblImageInfo.Text = "Chưa có ảnh nào được chọn.";
            lblImageInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlLeftButtons
            // 
            pnlLeftButtons.Controls.Add(btnChooseImage);
            pnlLeftButtons.Controls.Add(btnAnalyze);
            pnlLeftButtons.Dock = DockStyle.Bottom;
            pnlLeftButtons.Location = new Point(12, 546);
            pnlLeftButtons.Name = "pnlLeftButtons";
            pnlLeftButtons.Padding = new Padding(0, 6, 0, 0);
            pnlLeftButtons.Size = new Size(326, 44);
            pnlLeftButtons.TabIndex = 2;
            // 
            // btnChooseImage
            // 
            btnChooseImage.BackColor = Color.FromArgb(240, 245, 240);
            btnChooseImage.Cursor = Cursors.Hand;
            btnChooseImage.Dock = DockStyle.Left;
            btnChooseImage.FlatAppearance.BorderColor = Color.FromArgb(180, 210, 190);
            btnChooseImage.FlatStyle = FlatStyle.Flat;
            btnChooseImage.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnChooseImage.ForeColor = Color.FromArgb(34, 76, 56);
            btnChooseImage.Location = new Point(0, 6);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(160, 38);
            btnChooseImage.TabIndex = 0;
            btnChooseImage.Text = "📁 Chọn ảnh";
            btnChooseImage.UseVisualStyleBackColor = false;
            // 
            // btnAnalyze
            // 
            btnAnalyze.BackColor = Color.FromArgb(34, 112, 68);
            btnAnalyze.Cursor = Cursors.Hand;
            btnAnalyze.Dock = DockStyle.Right;
            btnAnalyze.FlatAppearance.BorderSize = 0;
            btnAnalyze.FlatStyle = FlatStyle.Flat;
            btnAnalyze.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAnalyze.ForeColor = Color.White;
            btnAnalyze.Location = new Point(176, 6);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(150, 38);
            btnAnalyze.TabIndex = 1;
            btnAnalyze.Text = "✨ Phân tích lại";
            btnAnalyze.UseVisualStyleBackColor = false;
            // 
            // lblLeftTitle
            // 
            lblLeftTitle.Dock = DockStyle.Top;
            lblLeftTitle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblLeftTitle.ForeColor = Color.FromArgb(34, 76, 56);
            lblLeftTitle.Location = new Point(12, 12);
            lblLeftTitle.Name = "lblLeftTitle";
            lblLeftTitle.Size = new Size(326, 26);
            lblLeftTitle.TabIndex = 3;
            lblLeftTitle.Text = "📄 Ảnh Hóa Đơn / Nguyên Liệu";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(dgvItems);
            pnlRight.Controls.Add(pnlBottom);
            pnlRight.Controls.Add(pnlStatus);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(380, 15);
            pnlRight.Margin = new Padding(5, 0, 0, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(14);
            pnlRight.Size = new Size(690, 602);
            pnlRight.TabIndex = 1;
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.BackgroundColor = Color.White;
            dgvItems.BorderStyle = BorderStyle.None;
            dgvItems.ColumnHeadersHeight = 29;
            dgvItems.Columns.AddRange(new DataGridViewColumn[] { colCheck, colName, colQty, colUnit, colStorage, colExpiry });
            dgvItems.Dock = DockStyle.Fill;
            dgvItems.Font = new Font("Segoe UI", 9F);
            dgvItems.Location = new Point(14, 70);
            dgvItems.Name = "dgvItems";
            dgvItems.RowHeadersVisible = false;
            dgvItems.RowHeadersWidth = 51;
            dgvItems.RowTemplate.Height = 34;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.Size = new Size(662, 466);
            dgvItems.TabIndex = 0;
            // 
            // colCheck
            // 
            colCheck.FillWeight = 8F;
            colCheck.HeaderText = "Chọn";
            colCheck.MinimumWidth = 6;
            colCheck.Name = "colCheck";
            // 
            // colName
            // 
            colName.FillWeight = 25F;
            colName.HeaderText = "Tên Thực Phẩm";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            // 
            // colQty
            // 
            colQty.FillWeight = 14F;
            colQty.HeaderText = "Số Lượng";
            colQty.MinimumWidth = 6;
            colQty.Name = "colQty";
            // 
            // colUnit
            // 
            colUnit.FillWeight = 10F;
            colUnit.HeaderText = "Đơn Vị";
            colUnit.MinimumWidth = 6;
            colUnit.Name = "colUnit";
            // 
            // colStorage
            // 
            colStorage.FillWeight = 17F;
            colStorage.HeaderText = "Ngăn Tủ Lạnh";
            colStorage.MinimumWidth = 6;
            colStorage.Name = "colStorage";
            // 
            // colExpiry
            // 
            colExpiry.FillWeight = 20F;
            colExpiry.HeaderText = "Hạn Dùng Dự Tính";
            colExpiry.MinimumWidth = 6;
            colExpiry.Name = "colExpiry";
            // 
            // pnlBottom
            // 
            pnlBottom.Controls.Add(lblSummary);
            pnlBottom.Controls.Add(btnSaveSelected);
            pnlBottom.Controls.Add(btnClose);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(14, 536);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(0, 10, 0, 0);
            pnlBottom.Size = new Size(662, 52);
            pnlBottom.TabIndex = 1;
            // 
            // lblSummary
            // 
            lblSummary.Dock = DockStyle.Left;
            lblSummary.Font = new Font("Segoe UI", 8.8F);
            lblSummary.ForeColor = Color.FromArgb(100, 100, 95);
            lblSummary.Location = new Point(0, 10);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(183, 42);
            lblSummary.TabIndex = 0;
            lblSummary.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSaveSelected
            // 
            btnSaveSelected.AutoSize = true;
            btnSaveSelected.BackColor = Color.FromArgb(240, 245, 240);
            btnSaveSelected.Cursor = Cursors.Hand;
            btnSaveSelected.Dock = DockStyle.Right;
            btnSaveSelected.FlatAppearance.BorderColor = Color.FromArgb(180, 210, 190);
            btnSaveSelected.FlatStyle = FlatStyle.Flat;
            btnSaveSelected.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnSaveSelected.ForeColor = Color.FromArgb(34, 76, 56);
            btnSaveSelected.Location = new Point(313, 10);
            btnSaveSelected.Name = "btnSaveSelected";
            btnSaveSelected.Size = new Size(224, 42);
            btnSaveSelected.TabIndex = 1;
            btnSaveSelected.Text = "💾 Lưu Lại Các Món Đã Chọn";
            btnSaveSelected.UseVisualStyleBackColor = false;
            btnSaveSelected.Visible = false;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(34, 76, 56);
            btnClose.Cursor = Cursors.Hand;
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(537, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(125, 42);
            btnClose.TabIndex = 2;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // pnlStatus
            // 
            pnlStatus.BackColor = Color.FromArgb(245, 250, 247);
            pnlStatus.Controls.Add(lblStatus);
            pnlStatus.Controls.Add(prgStatus);
            pnlStatus.Dock = DockStyle.Top;
            pnlStatus.Location = new Point(14, 14);
            pnlStatus.Margin = new Padding(0, 0, 0, 10);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Padding = new Padding(10, 8, 10, 8);
            pnlStatus.Size = new Size(662, 56);
            pnlStatus.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Top;
            lblStatus.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(34, 90, 60);
            lblStatus.Location = new Point(10, 8);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(642, 22);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Chọn ảnh hóa đơn để bắt đầu phân tích AI...";
            // 
            // prgStatus
            // 
            prgStatus.Dock = DockStyle.Bottom;
            prgStatus.Location = new Point(10, 40);
            prgStatus.MarqueeAnimationSpeed = 30;
            prgStatus.Name = "prgStatus";
            prgStatus.Size = new Size(642, 8);
            prgStatus.Style = ProgressBarStyle.Marquee;
            prgStatus.TabIndex = 1;
            prgStatus.Visible = false;
            // 
            // frmScanReceipt
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 247, 240);
            ClientSize = new Size(1085, 700);
            Controls.Add(tlpMain);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(860, 580);
            Name = "frmScanReceipt";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quét Hóa Đơn AI - Tự Động Thêm Vào Tủ Lạnh";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpMain.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picReceipt).EndInit();
            pnlLeftButtons.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            pnlStatus.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Label lblSummary;
    }
}
