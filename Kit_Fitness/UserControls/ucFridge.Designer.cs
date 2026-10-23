namespace Kit_Fitness.UserControls
{
    partial class ucFridge
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlMain = new Panel();
            pnlContentHolder = new Panel();
            pnlSuggestionsTab = new Panel();
            flpSuggestions = new FlowLayoutPanel();
            pnlAiBanner = new Panel();
            btnRefreshAi = new Button();
            lblAiBannerSub = new Label();
            lblAiBannerTitle = new Label();
            pnlFridgeTab = new Panel();
            tlpColumns = new TableLayoutPanel();
            pnlChillCol = new Panel();
            pnlChillItems = new Panel();
            lblChillSub = new Label();
            lblChillBadge = new Label();
            lblChillTitle = new Label();
            pnlFreezerCol = new Panel();
            pnlFreezerItems = new Panel();
            lblFreezerSub = new Label();
            lblFreezerBadge = new Label();
            lblFreezerTitle = new Label();
            pnlWarningBanner = new Panel();
            btnCookNow = new Button();
            lblWarningText = new Label();
            lblWarningTitle = new Label();
            pnlTabs = new Panel();
            btnTabSuggestions = new Button();
            btnTabFridge = new Button();
            pnlHeader = new Panel();
            btnManualAdd = new Button();
            btnScanReceipt = new Button();
            lblTitle = new Label();
            lblSubtitle = new Label();
            pnlMain.SuspendLayout();
            pnlContentHolder.SuspendLayout();
            pnlSuggestionsTab.SuspendLayout();
            pnlAiBanner.SuspendLayout();
            pnlFridgeTab.SuspendLayout();
            tlpColumns.SuspendLayout();
            pnlChillCol.SuspendLayout();
            pnlFreezerCol.SuspendLayout();
            pnlWarningBanner.SuspendLayout();
            pnlTabs.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.AutoScroll = true;
            pnlMain.BackColor = Color.FromArgb(250, 247, 240);
            pnlMain.Controls.Add(pnlContentHolder);
            pnlMain.Controls.Add(pnlTabs);
            pnlMain.Controls.Add(pnlHeader);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(25, 15, 25, 20);
            pnlMain.Size = new Size(1200, 850);
            pnlMain.TabIndex = 0;
            pnlMain.Paint += pnlMain_Paint;
            // 
            // pnlContentHolder
            // 
            pnlContentHolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlContentHolder.AutoSize = true;
            pnlContentHolder.Controls.Add(pnlSuggestionsTab);
            pnlContentHolder.Controls.Add(pnlFridgeTab);
            pnlContentHolder.Location = new Point(25, 130);
            pnlContentHolder.Name = "pnlContentHolder";
            pnlContentHolder.Size = new Size(1150, 1280);
            pnlContentHolder.TabIndex = 2;
            // 
            // pnlSuggestionsTab
            // 
            pnlSuggestionsTab.Controls.Add(flpSuggestions);
            pnlSuggestionsTab.Controls.Add(pnlAiBanner);
            pnlSuggestionsTab.Dock = DockStyle.Top;
            pnlSuggestionsTab.Location = new Point(0, 680);
            pnlSuggestionsTab.Name = "pnlSuggestionsTab";
            pnlSuggestionsTab.Size = new Size(1150, 600);
            pnlSuggestionsTab.TabIndex = 1;
            pnlSuggestionsTab.Visible = false;
            // 
            // flpSuggestions
            // 
            flpSuggestions.AutoScroll = true;
            flpSuggestions.Dock = DockStyle.Fill;
            flpSuggestions.Location = new Point(0, 85);
            flpSuggestions.Name = "flpSuggestions";
            flpSuggestions.Padding = new Padding(0, 15, 0, 0);
            flpSuggestions.Size = new Size(1150, 515);
            flpSuggestions.TabIndex = 1;
            // 
            // pnlAiBanner
            // 
            pnlAiBanner.BackColor = Color.White;
            pnlAiBanner.Controls.Add(btnRefreshAi);
            pnlAiBanner.Controls.Add(lblAiBannerSub);
            pnlAiBanner.Controls.Add(lblAiBannerTitle);
            pnlAiBanner.Dock = DockStyle.Top;
            pnlAiBanner.Location = new Point(0, 0);
            pnlAiBanner.Name = "pnlAiBanner";
            pnlAiBanner.Padding = new Padding(20, 15, 20, 15);
            pnlAiBanner.Size = new Size(1150, 85);
            pnlAiBanner.TabIndex = 0;
            // 
            // btnRefreshAi
            // 
            btnRefreshAi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefreshAi.BackColor = Color.FromArgb(41, 75, 54);
            btnRefreshAi.Cursor = Cursors.Hand;
            btnRefreshAi.FlatAppearance.BorderSize = 0;
            btnRefreshAi.FlatStyle = FlatStyle.Flat;
            btnRefreshAi.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnRefreshAi.ForeColor = Color.White;
            btnRefreshAi.Location = new Point(950, 22);
            btnRefreshAi.Name = "btnRefreshAi";
            btnRefreshAi.Size = new Size(180, 40);
            btnRefreshAi.TabIndex = 2;
            btnRefreshAi.Text = "✨ Gợi ý lại bằng AI";
            btnRefreshAi.UseVisualStyleBackColor = false;
            // 
            // lblAiBannerSub
            // 
            lblAiBannerSub.AutoSize = true;
            lblAiBannerSub.Font = new Font("Segoe UI", 9F);
            lblAiBannerSub.ForeColor = Color.FromArgb(120, 120, 115);
            lblAiBannerSub.Location = new Point(20, 48);
            lblAiBannerSub.Name = "lblAiBannerSub";
            lblAiBannerSub.Size = new Size(647, 20);
            lblAiBannerSub.TabIndex = 1;
            lblAiBannerSub.Text = "Hệ thống AI tự động phân tích các thực phẩm sẵn có trong tủ lạnh để đề xuất các món ăn tối ưu:";
            // 
            // lblAiBannerTitle
            // 
            lblAiBannerTitle.AutoSize = true;
            lblAiBannerTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAiBannerTitle.ForeColor = Color.FromArgb(30, 40, 35);
            lblAiBannerTitle.Location = new Point(20, 18);
            lblAiBannerTitle.Name = "lblAiBannerTitle";
            lblAiBannerTitle.Size = new Size(413, 28);
            lblAiBannerTitle.TabIndex = 0;
            lblAiBannerTitle.Text = "✨ Gợi ý bữa cơm từ Tủ Lạnh của bạn (AI)";
            // 
            // pnlFridgeTab
            // 
            pnlFridgeTab.Controls.Add(tlpColumns);
            pnlFridgeTab.Controls.Add(pnlWarningBanner);
            pnlFridgeTab.Dock = DockStyle.Top;
            pnlFridgeTab.Location = new Point(0, 0);
            pnlFridgeTab.Name = "pnlFridgeTab";
            pnlFridgeTab.Size = new Size(1150, 680);
            pnlFridgeTab.TabIndex = 0;
            // 
            // tlpColumns
            // 
            tlpColumns.ColumnCount = 2;
            tlpColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpColumns.Controls.Add(pnlChillCol, 0, 0);
            tlpColumns.Controls.Add(pnlFreezerCol, 1, 0);
            tlpColumns.Dock = DockStyle.Fill;
            tlpColumns.Location = new Point(0, 60);
            tlpColumns.Name = "tlpColumns";
            tlpColumns.RowCount = 1;
            tlpColumns.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpColumns.Size = new Size(1150, 620);
            tlpColumns.TabIndex = 1;
            // 
            // pnlChillCol
            // 
            pnlChillCol.Controls.Add(pnlChillItems);
            pnlChillCol.Controls.Add(lblChillSub);
            pnlChillCol.Controls.Add(lblChillBadge);
            pnlChillCol.Controls.Add(lblChillTitle);
            pnlChillCol.Dock = DockStyle.Fill;
            pnlChillCol.Location = new Point(0, 0);
            pnlChillCol.Margin = new Padding(0, 0, 10, 0);
            pnlChillCol.Name = "pnlChillCol";
            pnlChillCol.Size = new Size(565, 620);
            pnlChillCol.TabIndex = 0;
            // 
            // pnlChillItems
            // 
            pnlChillItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlChillItems.AutoSize = true;
            pnlChillItems.Location = new Point(0, 50);
            pnlChillItems.Name = "pnlChillItems";
            pnlChillItems.Size = new Size(565, 460);
            pnlChillItems.TabIndex = 3;
            // 
            // lblChillSub
            // 
            lblChillSub.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblChillSub.AutoSize = true;
            lblChillSub.Font = new Font("Segoe UI", 8.5F);
            lblChillSub.ForeColor = Color.FromArgb(130, 130, 125);
            lblChillSub.Location = new Point(324, 15);
            lblChillSub.Name = "lblChillSub";
            lblChillSub.Size = new Size(241, 20);
            lblChillSub.TabIndex = 2;
            lblChillSub.Text = "Rau củ, trứng sữa, đồ ăn trong tuần";
            // 
            // lblChillBadge
            // 
            lblChillBadge.AutoSize = true;
            lblChillBadge.BackColor = Color.FromArgb(240, 248, 240);
            lblChillBadge.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblChillBadge.ForeColor = Color.FromArgb(34, 112, 68);
            lblChillBadge.Location = new Point(215, 15);
            lblChillBadge.Name = "lblChillBadge";
            lblChillBadge.Padding = new Padding(6, 2, 6, 2);
            lblChillBadge.Size = new Size(65, 24);
            lblChillBadge.TabIndex = 1;
            lblChillBadge.Text = "4 món";
            // 
            // lblChillTitle
            // 
            lblChillTitle.AutoSize = true;
            lblChillTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChillTitle.ForeColor = Color.FromArgb(30, 40, 35);
            lblChillTitle.Location = new Point(0, 14);
            lblChillTitle.Name = "lblChillTitle";
            lblChillTitle.Size = new Size(200, 25);
            lblChillTitle.TabIndex = 0;
            lblChillTitle.Text = "\U0001f966 Ngăn Mát (CHILL)";
            // 
            // pnlFreezerCol
            // 
            pnlFreezerCol.Controls.Add(pnlFreezerItems);
            pnlFreezerCol.Controls.Add(lblFreezerSub);
            pnlFreezerCol.Controls.Add(lblFreezerBadge);
            pnlFreezerCol.Controls.Add(lblFreezerTitle);
            pnlFreezerCol.Dock = DockStyle.Fill;
            pnlFreezerCol.Location = new Point(585, 0);
            pnlFreezerCol.Margin = new Padding(10, 0, 0, 0);
            pnlFreezerCol.Name = "pnlFreezerCol";
            pnlFreezerCol.Size = new Size(565, 620);
            pnlFreezerCol.TabIndex = 1;
            // 
            // pnlFreezerItems
            // 
            pnlFreezerItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFreezerItems.AutoSize = true;
            pnlFreezerItems.Location = new Point(0, 50);
            pnlFreezerItems.Name = "pnlFreezerItems";
            pnlFreezerItems.Size = new Size(565, 460);
            pnlFreezerItems.TabIndex = 3;
            // 
            // lblFreezerSub
            // 
            lblFreezerSub.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFreezerSub.AutoSize = true;
            lblFreezerSub.Font = new Font("Segoe UI", 8.5F);
            lblFreezerSub.ForeColor = Color.FromArgb(130, 130, 125);
            lblFreezerSub.Location = new Point(380, 15);
            lblFreezerSub.Name = "lblFreezerSub";
            lblFreezerSub.Size = new Size(168, 20);
            lblFreezerSub.TabIndex = 2;
            lblFreezerSub.Text = "Thịt, cá hồi, đồ trữ đông";
            // 
            // lblFreezerBadge
            // 
            lblFreezerBadge.AutoSize = true;
            lblFreezerBadge.BackColor = Color.FromArgb(240, 245, 255);
            lblFreezerBadge.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblFreezerBadge.ForeColor = Color.FromArgb(50, 90, 160);
            lblFreezerBadge.Location = new Point(215, 15);
            lblFreezerBadge.Name = "lblFreezerBadge";
            lblFreezerBadge.Padding = new Padding(6, 2, 6, 2);
            lblFreezerBadge.Size = new Size(64, 24);
            lblFreezerBadge.TabIndex = 1;
            lblFreezerBadge.Text = "2 món";
            // 
            // lblFreezerTitle
            // 
            lblFreezerTitle.AutoSize = true;
            lblFreezerTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFreezerTitle.ForeColor = Color.FromArgb(30, 40, 35);
            lblFreezerTitle.Location = new Point(0, 14);
            lblFreezerTitle.Name = "lblFreezerTitle";
            lblFreezerTitle.Size = new Size(212, 25);
            lblFreezerTitle.TabIndex = 0;
            lblFreezerTitle.Text = "\U0001f969 Ngăn Đá (FREEZER)";
            // 
            // pnlWarningBanner
            // 
            pnlWarningBanner.BackColor = Color.FromArgb(254, 249, 235);
            pnlWarningBanner.BorderStyle = BorderStyle.FixedSingle;
            pnlWarningBanner.Controls.Add(btnCookNow);
            pnlWarningBanner.Controls.Add(lblWarningText);
            pnlWarningBanner.Controls.Add(lblWarningTitle);
            pnlWarningBanner.Dock = DockStyle.Top;
            pnlWarningBanner.Location = new Point(0, 0);
            pnlWarningBanner.Margin = new Padding(0, 0, 0, 15);
            pnlWarningBanner.Name = "pnlWarningBanner";
            pnlWarningBanner.Padding = new Padding(16, 12, 16, 12);
            pnlWarningBanner.Size = new Size(1150, 60);
            pnlWarningBanner.TabIndex = 0;
            // 
            // btnCookNow
            // 
            btnCookNow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCookNow.BackColor = Color.Transparent;
            btnCookNow.Cursor = Cursors.Hand;
            btnCookNow.FlatAppearance.BorderColor = Color.FromArgb(200, 150, 60);
            btnCookNow.FlatStyle = FlatStyle.Flat;
            btnCookNow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCookNow.ForeColor = Color.FromArgb(160, 100, 20);
            btnCookNow.Location = new Point(1020, 12);
            btnCookNow.Name = "btnCookNow";
            btnCookNow.Size = new Size(110, 34);
            btnCookNow.TabIndex = 2;
            btnCookNow.Text = "NẤU NGAY";
            btnCookNow.UseVisualStyleBackColor = false;
            // 
            // lblWarningText
            // 
            lblWarningText.AutoSize = true;
            lblWarningText.Font = new Font("Segoe UI", 8.8F);
            lblWarningText.ForeColor = Color.FromArgb(120, 100, 40);
            lblWarningText.Location = new Point(16, 30);
            lblWarningText.Name = "lblWarningText";
            lblWarningText.Size = new Size(333, 20);
            lblWarningText.TabIndex = 1;
            lblWarningText.Text = "1 món sắp hết hạn (1-2 ngày). 1 món đã quá hạn.";
            // 
            // lblWarningTitle
            // 
            lblWarningTitle.AutoSize = true;
            lblWarningTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblWarningTitle.ForeColor = Color.FromArgb(140, 90, 20);
            lblWarningTitle.Location = new Point(16, 8);
            lblWarningTitle.Name = "lblWarningTitle";
            lblWarningTitle.Size = new Size(323, 21);
            lblWarningTitle.TabIndex = 0;
            lblWarningTitle.Text = "⚠️ Cảnh báo hạn tươi thực phẩm chợ về:";
            // 
            // pnlTabs
            // 
            pnlTabs.Controls.Add(btnTabSuggestions);
            pnlTabs.Controls.Add(btnTabFridge);
            pnlTabs.Dock = DockStyle.Top;
            pnlTabs.Location = new Point(25, 80);
            pnlTabs.Name = "pnlTabs";
            pnlTabs.Size = new Size(1129, 45);
            pnlTabs.TabIndex = 1;
            // 
            // btnTabSuggestions
            // 
            btnTabSuggestions.BackColor = Color.FromArgb(240, 236, 228);
            btnTabSuggestions.Cursor = Cursors.Hand;
            btnTabSuggestions.FlatAppearance.BorderSize = 0;
            btnTabSuggestions.FlatStyle = FlatStyle.Flat;
            btnTabSuggestions.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnTabSuggestions.ForeColor = Color.FromArgb(100, 100, 95);
            btnTabSuggestions.Location = new Point(215, 0);
            btnTabSuggestions.Name = "btnTabSuggestions";
            btnTabSuggestions.Size = new Size(180, 40);
            btnTabSuggestions.TabIndex = 1;
            btnTabSuggestions.Text = "📖 Thực Đơn Gợi Ý";
            btnTabSuggestions.UseVisualStyleBackColor = false;
            // 
            // btnTabFridge
            // 
            btnTabFridge.BackColor = Color.White;
            btnTabFridge.Cursor = Cursors.Hand;
            btnTabFridge.FlatAppearance.BorderSize = 0;
            btnTabFridge.FlatStyle = FlatStyle.Flat;
            btnTabFridge.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnTabFridge.ForeColor = Color.FromArgb(34, 76, 56);
            btnTabFridge.Location = new Point(0, 0);
            btnTabFridge.Name = "btnTabFridge";
            btnTabFridge.Size = new Size(200, 40);
            btnTabFridge.TabIndex = 0;
            btnTabFridge.Text = "\U0001f9ca Tủ Lạnh Của Tôi (6)";
            btnTabFridge.UseVisualStyleBackColor = false;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(btnManualAdd);
            pnlHeader.Controls.Add(btnScanReceipt);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(25, 15);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1129, 65);
            pnlHeader.TabIndex = 0;
            // 
            // btnManualAdd
            // 
            btnManualAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnManualAdd.BackColor = Color.White;
            btnManualAdd.Cursor = Cursors.Hand;
            btnManualAdd.FlatAppearance.BorderColor = Color.FromArgb(215, 210, 200);
            btnManualAdd.FlatStyle = FlatStyle.Flat;
            btnManualAdd.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnManualAdd.ForeColor = Color.FromArgb(34, 76, 56);
            btnManualAdd.Location = new Point(984, 12);
            btnManualAdd.Name = "btnManualAdd";
            btnManualAdd.Size = new Size(140, 40);
            btnManualAdd.TabIndex = 3;
            btnManualAdd.Text = "+ Cất thủ công";
            btnManualAdd.UseVisualStyleBackColor = false;
            // 
            // btnScanReceipt
            // 
            btnScanReceipt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnScanReceipt.BackColor = Color.FromArgb(218, 145, 55);
            btnScanReceipt.Cursor = Cursors.Hand;
            btnScanReceipt.FlatAppearance.BorderSize = 0;
            btnScanReceipt.FlatStyle = FlatStyle.Flat;
            btnScanReceipt.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnScanReceipt.ForeColor = Color.White;
            btnScanReceipt.Location = new Point(804, 12);
            btnScanReceipt.Name = "btnScanReceipt";
            btnScanReceipt.Size = new Size(165, 40);
            btnScanReceipt.TabIndex = 2;
            btnScanReceipt.Text = "📷 Quét hóa đơn AI";
            btnScanReceipt.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 40, 35);
            lblTitle.Location = new Point(0, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(233, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "TỦ LẠNH VÀ BẾP";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblSubtitle.ForeColor = Color.FromArgb(130, 125, 120);
            lblSubtitle.Location = new Point(0, 2);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(196, 19);
            lblSubtitle.TabIndex = 0;
            lblSubtitle.Text = "TỦ LẠNH CHỐNG LÃNG PHÍ";
            // 
            // ucFridge
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Name = "ucFridge";
            Size = new Size(1200, 850);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlContentHolder.ResumeLayout(false);
            pnlSuggestionsTab.ResumeLayout(false);
            pnlAiBanner.ResumeLayout(false);
            pnlAiBanner.PerformLayout();
            pnlFridgeTab.ResumeLayout(false);
            tlpColumns.ResumeLayout(false);
            pnlChillCol.ResumeLayout(false);
            pnlChillCol.PerformLayout();
            pnlFreezerCol.ResumeLayout(false);
            pnlFreezerCol.PerformLayout();
            pnlWarningBanner.ResumeLayout(false);
            pnlWarningBanner.PerformLayout();
            pnlTabs.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnScanReceipt;
        private System.Windows.Forms.Button btnManualAdd;
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Button btnTabFridge;
        private System.Windows.Forms.Button btnTabSuggestions;
        private System.Windows.Forms.Panel pnlContentHolder;
        private System.Windows.Forms.Panel pnlFridgeTab;
        private System.Windows.Forms.Panel pnlWarningBanner;
        private System.Windows.Forms.Label lblWarningTitle;
        private System.Windows.Forms.Label lblWarningText;
        private System.Windows.Forms.Button btnCookNow;
        private System.Windows.Forms.TableLayoutPanel tlpColumns;
        private System.Windows.Forms.Panel pnlChillCol;
        private System.Windows.Forms.Label lblChillTitle;
        private System.Windows.Forms.Label lblChillBadge;
        private System.Windows.Forms.Label lblChillSub;
        private System.Windows.Forms.Panel pnlChillItems;
        private System.Windows.Forms.Panel pnlFreezerCol;
        private System.Windows.Forms.Label lblFreezerTitle;
        private System.Windows.Forms.Label lblFreezerBadge;
        private System.Windows.Forms.Label lblFreezerSub;
        private System.Windows.Forms.Panel pnlFreezerItems;
        private System.Windows.Forms.Panel pnlSuggestionsTab;
        private System.Windows.Forms.Panel pnlAiBanner;
        private System.Windows.Forms.Label lblAiBannerTitle;
        private System.Windows.Forms.Label lblAiBannerSub;
        private System.Windows.Forms.Button btnRefreshAi;
        private System.Windows.Forms.FlowLayoutPanel flpSuggestions;
    }
}
