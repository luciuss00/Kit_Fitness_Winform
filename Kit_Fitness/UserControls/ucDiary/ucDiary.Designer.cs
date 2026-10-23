namespace Kit_Fitness.UserControls
{
    partial class ucDiary
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
            tlpDiary = new TableLayoutPanel();
            pnlLeftTimeline = new Panel();
            pnlTimelineList = new Panel();
            lblTimelineSub = new Label();
            lblTimelineTitle = new Label();
            pnlDateNavigation = new Panel();
            btnPickDate = new Button();
            btnNextDay = new Button();
            lblSelectedDate = new Label();
            btnPrevDay = new Button();
            lblSubtitle = new Label();
            pnlRightSummary = new Panel();
            pnlSummaryCard = new Panel();
            btnAiSnap = new Button();
            btnQuickLog = new Button();
            pnlMacros = new FlowLayoutPanel();
            pnlProtein = new Panel();
            lblProteinTarget = new Label();
            lblProteinVal = new Label();
            lblProteinTitle = new Label();
            pnlCarbs = new Panel();
            lblCarbsTarget = new Label();
            lblCarbsVal = new Label();
            lblCarbsTitle = new Label();
            pnlFat = new Panel();
            lblFatTarget = new Label();
            lblFatVal = new Label();
            lblFatTitle = new Label();
            progressCalories = new ProgressBar();
            lblStatusBadge = new Label();
            lblCaloriesSummary = new Label();
            lblSummaryTitle = new Label();
            pnlMain.SuspendLayout();
            tlpDiary.SuspendLayout();
            pnlLeftTimeline.SuspendLayout();
            pnlDateNavigation.SuspendLayout();
            pnlRightSummary.SuspendLayout();
            pnlSummaryCard.SuspendLayout();
            pnlMacros.SuspendLayout();
            pnlProtein.SuspendLayout();
            pnlCarbs.SuspendLayout();
            pnlFat.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.AutoScroll = true;
            pnlMain.BackColor = Color.FromArgb(250, 247, 240);
            pnlMain.Controls.Add(tlpDiary);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20, 10, 20, 10);
            pnlMain.Size = new Size(1200, 800);
            pnlMain.TabIndex = 0;
            pnlMain.Paint += pnlMain_Paint;
            // 
            // tlpDiary
            // 
            tlpDiary.ColumnCount = 2;
            tlpDiary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66F));
            tlpDiary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tlpDiary.Controls.Add(pnlLeftTimeline, 0, 0);
            tlpDiary.Controls.Add(pnlRightSummary, 1, 0);
            tlpDiary.Dock = DockStyle.Fill;
            tlpDiary.Location = new Point(20, 10);
            tlpDiary.Name = "tlpDiary";
            tlpDiary.RowCount = 1;
            tlpDiary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpDiary.Size = new Size(1160, 780);
            tlpDiary.TabIndex = 0;
            // 
            // pnlLeftTimeline
            // 
            pnlLeftTimeline.AutoScroll = true;
            pnlLeftTimeline.Controls.Add(pnlTimelineList);
            pnlLeftTimeline.Controls.Add(lblTimelineSub);
            pnlLeftTimeline.Controls.Add(lblTimelineTitle);
            pnlLeftTimeline.Controls.Add(pnlDateNavigation);
            pnlLeftTimeline.Controls.Add(lblSubtitle);
            pnlLeftTimeline.Dock = DockStyle.Fill;
            pnlLeftTimeline.Location = new Point(0, 0);
            pnlLeftTimeline.Margin = new Padding(0, 0, 15, 0);
            pnlLeftTimeline.Name = "pnlLeftTimeline";
            pnlLeftTimeline.Size = new Size(750, 780);
            pnlLeftTimeline.TabIndex = 0;
            // 
            // pnlTimelineList
            // 
            pnlTimelineList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTimelineList.Location = new Point(5, 120);
            pnlTimelineList.Name = "pnlTimelineList";
            pnlTimelineList.Size = new Size(719, 680);
            pnlTimelineList.TabIndex = 4;
            // 
            // lblTimelineSub
            // 
            lblTimelineSub.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTimelineSub.AutoSize = true;
            lblTimelineSub.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblTimelineSub.ForeColor = Color.FromArgb(120, 120, 115);
            lblTimelineSub.Location = new Point(519, 92);
            lblTimelineSub.Name = "lblTimelineSub";
            lblTimelineSub.Size = new Size(246, 20);
            lblTimelineSub.TabIndex = 3;
            lblTimelineSub.Text = "Chạm vào bất kỳ giờ nào để ghi món";
            // 
            // lblTimelineTitle
            // 
            lblTimelineTitle.AutoSize = true;
            lblTimelineTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTimelineTitle.ForeColor = Color.FromArgb(40, 50, 45);
            lblTimelineTitle.Location = new Point(5, 88);
            lblTimelineTitle.Name = "lblTimelineTitle";
            lblTimelineTitle.Size = new Size(326, 25);
            lblTimelineTitle.TabIndex = 2;
            lblTimelineTitle.Text = "🕒 Dòng Thời Gian Bữa Ăn Theo Giờ";
            // 
            // pnlDateNavigation
            // 
            pnlDateNavigation.Controls.Add(btnPickDate);
            pnlDateNavigation.Controls.Add(btnNextDay);
            pnlDateNavigation.Controls.Add(lblSelectedDate);
            pnlDateNavigation.Controls.Add(btnPrevDay);
            pnlDateNavigation.Dock = DockStyle.Top;
            pnlDateNavigation.Location = new Point(0, 0);
            pnlDateNavigation.Margin = new Padding(0, 25, 0, 0);
            pnlDateNavigation.Name = "pnlDateNavigation";
            pnlDateNavigation.Padding = new Padding(0, 25, 0, 0);
            pnlDateNavigation.Size = new Size(729, 75);
            pnlDateNavigation.TabIndex = 1;
            // 
            // btnPickDate
            // 
            btnPickDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPickDate.BackColor = Color.White;
            btnPickDate.Cursor = Cursors.Hand;
            btnPickDate.FlatAppearance.BorderColor = Color.FromArgb(215, 210, 200);
            btnPickDate.FlatStyle = FlatStyle.Flat;
            btnPickDate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnPickDate.ForeColor = Color.FromArgb(60, 70, 65);
            btnPickDate.Location = new Point(589, 27);
            btnPickDate.Name = "btnPickDate";
            btnPickDate.Size = new Size(115, 36);
            btnPickDate.TabIndex = 3;
            btnPickDate.Text = "📅 Chọn ngày";
            btnPickDate.UseVisualStyleBackColor = false;
            // 
            // btnNextDay
            // 
            btnNextDay.BackColor = Color.White;
            btnNextDay.Cursor = Cursors.Hand;
            btnNextDay.FlatAppearance.BorderSize = 0;
            btnNextDay.FlatStyle = FlatStyle.Flat;
            btnNextDay.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNextDay.ForeColor = Color.FromArgb(60, 60, 60);
            btnNextDay.Location = new Point(334, 30);
            btnNextDay.Name = "btnNextDay";
            btnNextDay.Size = new Size(34, 34);
            btnNextDay.TabIndex = 2;
            btnNextDay.Text = "›";
            btnNextDay.UseVisualStyleBackColor = false;
            // 
            // lblSelectedDate
            // 
            lblSelectedDate.AutoSize = true;
            lblSelectedDate.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSelectedDate.ForeColor = Color.FromArgb(30, 40, 35);
            lblSelectedDate.Location = new Point(55, 27);
            lblSelectedDate.Name = "lblSelectedDate";
            lblSelectedDate.Size = new Size(273, 37);
            lblSelectedDate.TabIndex = 1;
            lblSelectedDate.Text = "Hôm nay, 20 Thg 10";
            // 
            // btnPrevDay
            // 
            btnPrevDay.BackColor = Color.White;
            btnPrevDay.Cursor = Cursors.Hand;
            btnPrevDay.FlatAppearance.BorderSize = 0;
            btnPrevDay.FlatStyle = FlatStyle.Flat;
            btnPrevDay.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPrevDay.ForeColor = Color.FromArgb(60, 60, 60);
            btnPrevDay.Location = new Point(15, 28);
            btnPrevDay.Name = "btnPrevDay";
            btnPrevDay.Size = new Size(34, 34);
            btnPrevDay.TabIndex = 0;
            btnPrevDay.Text = "‹";
            btnPrevDay.UseVisualStyleBackColor = false;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblSubtitle.ForeColor = Color.FromArgb(120, 115, 110);
            lblSubtitle.Location = new Point(5, 5);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(266, 19);
            lblSubtitle.TabIndex = 0;
            lblSubtitle.Text = "HÀNH TRÌNH ĂN UỐNG TRONG NGÀY";
            // 
            // pnlRightSummary
            // 
            pnlRightSummary.Controls.Add(pnlSummaryCard);
            pnlRightSummary.Dock = DockStyle.Fill;
            pnlRightSummary.Location = new Point(765, 0);
            pnlRightSummary.Margin = new Padding(0);
            pnlRightSummary.Name = "pnlRightSummary";
            pnlRightSummary.Size = new Size(395, 780);
            pnlRightSummary.TabIndex = 1;
            // 
            // pnlSummaryCard
            // 
            pnlSummaryCard.BackColor = Color.White;
            pnlSummaryCard.Controls.Add(btnAiSnap);
            pnlSummaryCard.Controls.Add(btnQuickLog);
            pnlSummaryCard.Controls.Add(pnlMacros);
            pnlSummaryCard.Controls.Add(progressCalories);
            pnlSummaryCard.Controls.Add(lblStatusBadge);
            pnlSummaryCard.Controls.Add(lblCaloriesSummary);
            pnlSummaryCard.Controls.Add(lblSummaryTitle);
            pnlSummaryCard.Dock = DockStyle.Top;
            pnlSummaryCard.Location = new Point(0, 0);
            pnlSummaryCard.Name = "pnlSummaryCard";
            pnlSummaryCard.Padding = new Padding(20);
            pnlSummaryCard.Size = new Size(395, 444);
            pnlSummaryCard.TabIndex = 0;
            // 
            // btnAiSnap
            // 
            btnAiSnap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAiSnap.BackColor = Color.White;
            btnAiSnap.Cursor = Cursors.Hand;
            btnAiSnap.FlatAppearance.BorderColor = Color.FromArgb(215, 150, 70);
            btnAiSnap.FlatStyle = FlatStyle.Flat;
            btnAiSnap.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnAiSnap.ForeColor = Color.FromArgb(180, 100, 20);
            btnAiSnap.Location = new Point(20, 338);
            btnAiSnap.Name = "btnAiSnap";
            btnAiSnap.Size = new Size(355, 46);
            btnAiSnap.TabIndex = 6;
            btnAiSnap.Text = "📷 Chụp Ảnh Món Ăn (AI)";
            btnAiSnap.UseVisualStyleBackColor = false;
            // 
            // btnQuickLog
            // 
            btnQuickLog.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnQuickLog.BackColor = Color.FromArgb(41, 75, 54);
            btnQuickLog.Cursor = Cursors.Hand;
            btnQuickLog.FlatAppearance.BorderSize = 0;
            btnQuickLog.FlatStyle = FlatStyle.Flat;
            btnQuickLog.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnQuickLog.ForeColor = Color.White;
            btnQuickLog.Location = new Point(20, 273);
            btnQuickLog.Name = "btnQuickLog";
            btnQuickLog.Size = new Size(355, 48);
            btnQuickLog.TabIndex = 5;
            btnQuickLog.Text = "🍴 Nhập Món Ăn Nhanh";
            btnQuickLog.UseVisualStyleBackColor = false;
            // 
            // pnlMacros
            // 
            pnlMacros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlMacros.Controls.Add(pnlProtein);
            pnlMacros.Controls.Add(pnlCarbs);
            pnlMacros.Controls.Add(pnlFat);
            pnlMacros.Location = new Point(20, 157);
            pnlMacros.Name = "pnlMacros";
            pnlMacros.Size = new Size(355, 97);
            pnlMacros.TabIndex = 4;
            // 
            // pnlProtein
            // 
            pnlProtein.BackColor = Color.FromArgb(250, 246, 240);
            pnlProtein.Controls.Add(lblProteinTarget);
            pnlProtein.Controls.Add(lblProteinVal);
            pnlProtein.Controls.Add(lblProteinTitle);
            pnlProtein.Location = new Point(0, 0);
            pnlProtein.Margin = new Padding(0, 0, 8, 0);
            pnlProtein.Name = "pnlProtein";
            pnlProtein.Padding = new Padding(10, 8, 10, 8);
            pnlProtein.Size = new Size(110, 88);
            pnlProtein.TabIndex = 0;
            // 
            // lblProteinTarget
            // 
            lblProteinTarget.AutoSize = true;
            lblProteinTarget.Font = new Font("Segoe UI", 7.5F);
            lblProteinTarget.ForeColor = Color.FromArgb(140, 140, 135);
            lblProteinTarget.Location = new Point(8, 60);
            lblProteinTarget.Name = "lblProteinTarget";
            lblProteinTarget.Size = new Size(46, 17);
            lblProteinTarget.TabIndex = 2;
            lblProteinTarget.Text = "/ 106g";
            // 
            // lblProteinVal
            // 
            lblProteinVal.AutoSize = true;
            lblProteinVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblProteinVal.ForeColor = Color.FromArgb(180, 60, 40);
            lblProteinVal.Location = new Point(8, 30);
            lblProteinVal.Name = "lblProteinVal";
            lblProteinVal.Size = new Size(48, 28);
            lblProteinVal.TabIndex = 1;
            lblProteinVal.Text = "82g";
            // 
            // lblProteinTitle
            // 
            lblProteinTitle.AutoSize = true;
            lblProteinTitle.Font = new Font("Segoe UI", 7.5F);
            lblProteinTitle.ForeColor = Color.FromArgb(130, 125, 120);
            lblProteinTitle.Location = new Point(8, 8);
            lblProteinTitle.Name = "lblProteinTitle";
            lblProteinTitle.Size = new Size(88, 17);
            lblProteinTitle.TabIndex = 0;
            lblProteinTitle.Text = "Đạm (Protein)";
            // 
            // pnlCarbs
            // 
            pnlCarbs.BackColor = Color.FromArgb(250, 246, 240);
            pnlCarbs.Controls.Add(lblCarbsTarget);
            pnlCarbs.Controls.Add(lblCarbsVal);
            pnlCarbs.Controls.Add(lblCarbsTitle);
            pnlCarbs.Location = new Point(118, 0);
            pnlCarbs.Margin = new Padding(0, 0, 8, 0);
            pnlCarbs.Name = "pnlCarbs";
            pnlCarbs.Padding = new Padding(10, 8, 10, 8);
            pnlCarbs.Size = new Size(110, 88);
            pnlCarbs.TabIndex = 1;
            // 
            // lblCarbsTarget
            // 
            lblCarbsTarget.AutoSize = true;
            lblCarbsTarget.Font = new Font("Segoe UI", 7.5F);
            lblCarbsTarget.ForeColor = Color.FromArgb(140, 140, 135);
            lblCarbsTarget.Location = new Point(8, 60);
            lblCarbsTarget.Name = "lblCarbsTarget";
            lblCarbsTarget.Size = new Size(46, 17);
            lblCarbsTarget.TabIndex = 2;
            lblCarbsTarget.Text = "/ 163g";
            // 
            // lblCarbsVal
            // 
            lblCarbsVal.AutoSize = true;
            lblCarbsVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCarbsVal.ForeColor = Color.FromArgb(200, 130, 30);
            lblCarbsVal.Location = new Point(8, 30);
            lblCarbsVal.Name = "lblCarbsVal";
            lblCarbsVal.Size = new Size(48, 28);
            lblCarbsVal.TabIndex = 1;
            lblCarbsVal.Text = "86g";
            // 
            // lblCarbsTitle
            // 
            lblCarbsTitle.AutoSize = true;
            lblCarbsTitle.Font = new Font("Segoe UI", 7.5F);
            lblCarbsTitle.ForeColor = Color.FromArgb(130, 125, 120);
            lblCarbsTitle.Location = new Point(8, 8);
            lblCarbsTitle.Name = "lblCarbsTitle";
            lblCarbsTitle.Size = new Size(96, 17);
            lblCarbsTitle.TabIndex = 0;
            lblCarbsTitle.Text = "Tinh bột (Carb)";
            // 
            // pnlFat
            // 
            pnlFat.BackColor = Color.FromArgb(250, 246, 240);
            pnlFat.Controls.Add(lblFatTarget);
            pnlFat.Controls.Add(lblFatVal);
            pnlFat.Controls.Add(lblFatTitle);
            pnlFat.Location = new Point(236, 0);
            pnlFat.Margin = new Padding(0);
            pnlFat.Name = "pnlFat";
            pnlFat.Padding = new Padding(10, 8, 10, 8);
            pnlFat.Size = new Size(110, 88);
            pnlFat.TabIndex = 2;
            // 
            // lblFatTarget
            // 
            lblFatTarget.AutoSize = true;
            lblFatTarget.Font = new Font("Segoe UI", 7.5F);
            lblFatTarget.ForeColor = Color.FromArgb(140, 140, 135);
            lblFatTarget.Location = new Point(8, 60);
            lblFatTarget.Name = "lblFatTarget";
            lblFatTarget.Size = new Size(39, 17);
            lblFatTarget.TabIndex = 2;
            lblFatTarget.Text = "/ 40g";
            // 
            // lblFatVal
            // 
            lblFatVal.AutoSize = true;
            lblFatVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFatVal.ForeColor = Color.FromArgb(60, 70, 80);
            lblFatVal.Location = new Point(8, 30);
            lblFatVal.Name = "lblFatVal";
            lblFatVal.Size = new Size(48, 28);
            lblFatVal.TabIndex = 1;
            lblFatVal.Text = "18g";
            // 
            // lblFatTitle
            // 
            lblFatTitle.AutoSize = true;
            lblFatTitle.Font = new Font("Segoe UI", 7.5F);
            lblFatTitle.ForeColor = Color.FromArgb(130, 125, 120);
            lblFatTitle.Location = new Point(8, 8);
            lblFatTitle.Name = "lblFatTitle";
            lblFatTitle.Size = new Size(90, 17);
            lblFatTitle.TabIndex = 0;
            lblFatTitle.Text = "Chất béo (Fat)";
            // 
            // progressCalories
            // 
            progressCalories.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressCalories.Location = new Point(17, 120);
            progressCalories.Name = "progressCalories";
            progressCalories.Size = new Size(355, 12);
            progressCalories.TabIndex = 3;
            progressCalories.Value = 58;
            // 
            // lblStatusBadge
            // 
            lblStatusBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStatusBadge.BackColor = Color.FromArgb(240, 248, 240);
            lblStatusBadge.BorderStyle = BorderStyle.FixedSingle;
            lblStatusBadge.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            lblStatusBadge.ForeColor = Color.FromArgb(46, 117, 89);
            lblStatusBadge.Location = new Point(184, 27);
            lblStatusBadge.Name = "lblStatusBadge";
            lblStatusBadge.Padding = new Padding(6, 4, 6, 4);
            lblStatusBadge.Size = new Size(191, 30);
            lblStatusBadge.TabIndex = 2;
            lblStatusBadge.Text = "TƯƠI LÀNH & CÂN BẰNG";
            lblStatusBadge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCaloriesSummary
            // 
            lblCaloriesSummary.AutoSize = true;
            lblCaloriesSummary.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCaloriesSummary.ForeColor = Color.FromArgb(34, 76, 56);
            lblCaloriesSummary.Location = new Point(20, 71);
            lblCaloriesSummary.Name = "lblCaloriesSummary";
            lblCaloriesSummary.Size = new Size(232, 41);
            lblCaloriesSummary.TabIndex = 1;
            lblCaloriesSummary.Text = "846 / 1450 Kcal";
            // 
            // lblSummaryTitle
            // 
            lblSummaryTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblSummaryTitle.ForeColor = Color.FromArgb(120, 120, 115);
            lblSummaryTitle.Location = new Point(20, 20);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Size = new Size(141, 43);
            lblSummaryTitle.TabIndex = 0;
            lblSummaryTitle.Text = "TỔNG NĂNG LƯỢNG HÔM NAY";
            // 
            // ucDiary
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Name = "ucDiary";
            Size = new Size(1200, 800);
            pnlMain.ResumeLayout(false);
            tlpDiary.ResumeLayout(false);
            pnlLeftTimeline.ResumeLayout(false);
            pnlLeftTimeline.PerformLayout();
            pnlDateNavigation.ResumeLayout(false);
            pnlDateNavigation.PerformLayout();
            pnlRightSummary.ResumeLayout(false);
            pnlSummaryCard.ResumeLayout(false);
            pnlSummaryCard.PerformLayout();
            pnlMacros.ResumeLayout(false);
            pnlProtein.ResumeLayout(false);
            pnlProtein.PerformLayout();
            pnlCarbs.ResumeLayout(false);
            pnlCarbs.PerformLayout();
            pnlFat.ResumeLayout(false);
            pnlFat.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tlpDiary;
        private System.Windows.Forms.Panel pnlLeftTimeline;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlDateNavigation;
        private System.Windows.Forms.Button btnPrevDay;
        private System.Windows.Forms.Label lblSelectedDate;
        private System.Windows.Forms.Button btnNextDay;
        private System.Windows.Forms.Button btnPickDate;
        private System.Windows.Forms.Label lblTimelineTitle;
        private System.Windows.Forms.Label lblTimelineSub;
        private System.Windows.Forms.Panel pnlTimelineList;
        private System.Windows.Forms.Panel pnlRightSummary;
        private System.Windows.Forms.Panel pnlSummaryCard;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.Label lblCaloriesSummary;
        private System.Windows.Forms.Label lblStatusBadge;
        private System.Windows.Forms.ProgressBar progressCalories;
        private System.Windows.Forms.FlowLayoutPanel pnlMacros;
        private System.Windows.Forms.Panel pnlProtein;
        private System.Windows.Forms.Label lblProteinTitle;
        private System.Windows.Forms.Label lblProteinVal;
        private System.Windows.Forms.Label lblProteinTarget;
        private System.Windows.Forms.Panel pnlCarbs;
        private System.Windows.Forms.Label lblCarbsTitle;
        private System.Windows.Forms.Label lblCarbsVal;
        private System.Windows.Forms.Label lblCarbsTarget;
        private System.Windows.Forms.Panel pnlFat;
        private System.Windows.Forms.Label lblFatTitle;
        private System.Windows.Forms.Label lblFatVal;
        private System.Windows.Forms.Label lblFatTarget;
        private System.Windows.Forms.Button btnQuickLog;
        private System.Windows.Forms.Button btnAiSnap;
    }
}
