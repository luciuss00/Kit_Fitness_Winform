namespace Kit_Fitness.UserControls
{
    partial class ucWorkout
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
            tlpMain = new TableLayoutPanel();
            pnlHeader = new Panel();
            btnNextDay = new Button();
            btnPreviousDay = new Button();
            lblSelectedDate = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlEntry = new Panel();
            lblEntryTitle = new Label();
            lblUserWeightInfo = new Label();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            lblSport = new Label();
            cboSport = new ComboBox();
            lblIntensity = new Label();
            cboIntensity = new ComboBox();
            lblDuration = new Label();
            numDuration = new NumericUpDown();
            lblCalories = new Label();
            numCalories = new NumericUpDown();
            lblIntensityDesc = new Label();
            btnAddWorkout = new Button();
            pnlSummary = new Panel();
            lblSummary = new Label();
            lblSummaryTitle = new Label();
            lblSummaryTip = new Label();
            pnlWorkoutList = new Panel();
            lblListTitle = new Label();
            pnlMain.SuspendLayout();
            tlpMain.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCalories).BeginInit();
            pnlSummary.SuspendLayout();
            pnlWorkoutList.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.AutoScroll = true;
            pnlMain.BackColor = Color.FromArgb(250, 247, 240);
            pnlMain.Controls.Add(tlpMain);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(24, 18, 24, 18);
            pnlMain.Size = new Size(1200, 800);
            pnlMain.TabIndex = 0;
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            tlpMain.Controls.Add(pnlHeader, 0, 0);
            tlpMain.Controls.Add(pnlEntry, 0, 1);
            tlpMain.Controls.Add(pnlSummary, 1, 1);
            tlpMain.Controls.Add(pnlWorkoutList, 0, 2);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(24, 18);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 3;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 185F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(1152, 764);
            tlpMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            tlpMain.SetColumnSpan(pnlHeader, 2);
            pnlHeader.Controls.Add(btnNextDay);
            pnlHeader.Controls.Add(btnPreviousDay);
            pnlHeader.Controls.Add(lblSelectedDate);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Location = new Point(3, 3);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1146, 86);
            pnlHeader.TabIndex = 0;
            // 
            // btnNextDay
            // 
            btnNextDay.BackColor = Color.White;
            btnNextDay.Cursor = Cursors.Hand;
            btnNextDay.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnNextDay.FlatStyle = FlatStyle.Flat;
            btnNextDay.Font = new Font("Segoe UI", 12F);
            btnNextDay.Location = new Point(494, 7);
            btnNextDay.Name = "btnNextDay";
            btnNextDay.Size = new Size(38, 37);
            btnNextDay.TabIndex = 2;
            btnNextDay.Text = "›";
            btnNextDay.UseVisualStyleBackColor = false;
            // 
            // btnPreviousDay
            // 
            btnPreviousDay.BackColor = Color.White;
            btnPreviousDay.Cursor = Cursors.Hand;
            btnPreviousDay.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnPreviousDay.FlatStyle = FlatStyle.Flat;
            btnPreviousDay.Font = new Font("Segoe UI", 12F);
            btnPreviousDay.Location = new Point(216, 6);
            btnPreviousDay.Name = "btnPreviousDay";
            btnPreviousDay.Size = new Size(38, 37);
            btnPreviousDay.TabIndex = 1;
            btnPreviousDay.Text = "‹";
            btnPreviousDay.UseVisualStyleBackColor = false;
            // 
            // lblSelectedDate
            // 
            lblSelectedDate.AutoSize = true;
            lblSelectedDate.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            lblSelectedDate.ForeColor = Color.FromArgb(34, 76, 56);
            lblSelectedDate.Location = new Point(260, 6);
            lblSelectedDate.Name = "lblSelectedDate";
            lblSelectedDate.Size = new Size(240, 35);
            lblSelectedDate.TabIndex = 2;
            lblSelectedDate.Text = "Hôm nay, 22 Thg 10";
            lblSelectedDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(120, 120, 115);
            lblSubtitle.Location = new Point(5, 44);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(375, 20);
            lblSubtitle.TabIndex = 3;
            lblSubtitle.Text = "Theo dõi quá trình vận động và năng lượng đã tiêu hao";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 40, 35);
            lblTitle.Location = new Point(5, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(192, 41);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "🏋 Workout";
            // 
            // pnlEntry
            // 
            pnlEntry.BackColor = Color.White;
            pnlEntry.Controls.Add(lblEntryTitle);
            pnlEntry.Controls.Add(lblUserWeightInfo);
            pnlEntry.Controls.Add(lblCategory);
            pnlEntry.Controls.Add(cboCategory);
            pnlEntry.Controls.Add(lblSport);
            pnlEntry.Controls.Add(cboSport);
            pnlEntry.Controls.Add(lblIntensity);
            pnlEntry.Controls.Add(cboIntensity);
            pnlEntry.Controls.Add(lblDuration);
            pnlEntry.Controls.Add(numDuration);
            pnlEntry.Controls.Add(lblCalories);
            pnlEntry.Controls.Add(numCalories);
            pnlEntry.Controls.Add(lblIntensityDesc);
            pnlEntry.Controls.Add(btnAddWorkout);
            pnlEntry.Dock = DockStyle.Fill;
            pnlEntry.Location = new Point(3, 95);
            pnlEntry.Name = "pnlEntry";
            pnlEntry.Padding = new Padding(16);
            pnlEntry.Size = new Size(777, 179);
            pnlEntry.TabIndex = 1;
            // 
            // lblEntryTitle
            // 
            lblEntryTitle.AutoSize = true;
            lblEntryTitle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblEntryTitle.ForeColor = Color.FromArgb(40, 50, 45);
            lblEntryTitle.Location = new Point(16, 12);
            lblEntryTitle.Name = "lblEntryTitle";
            lblEntryTitle.Size = new Size(215, 25);
            lblEntryTitle.TabIndex = 0;
            lblEntryTitle.Text = "Ghi lại buổi tập hôm nay";
            // 
            // lblUserWeightInfo
            // 
            lblUserWeightInfo.AutoSize = true;
            lblUserWeightInfo.Font = new Font("Segoe UI", 9F);
            lblUserWeightInfo.ForeColor = Color.FromArgb(80, 115, 95);
            lblUserWeightInfo.Location = new Point(238, 16);
            lblUserWeightInfo.Name = "lblUserWeightInfo";
            lblUserWeightInfo.Size = new Size(160, 20);
            lblUserWeightInfo.TabIndex = 1;
            lblUserWeightInfo.Text = "👤 Cân nặng: 55 kg";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 8.8F);
            lblCategory.ForeColor = Color.FromArgb(90, 90, 85);
            lblCategory.Location = new Point(16, 42);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(82, 20);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Nhóm môn";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Font = new Font("Segoe UI", 9.5F);
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(16, 65);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(155, 29);
            cboCategory.TabIndex = 3;
            // 
            // lblSport
            // 
            lblSport.AutoSize = true;
            lblSport.Font = new Font("Segoe UI", 8.8F);
            lblSport.ForeColor = Color.FromArgb(90, 90, 85);
            lblSport.Location = new Point(179, 42);
            lblSport.Name = "lblSport";
            lblSport.Size = new Size(151, 20);
            lblSport.TabIndex = 4;
            lblSport.Text = "Môn thể thao / Bài tập";
            // 
            // cboSport
            // 
            cboSport.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSport.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboSport.Font = new Font("Segoe UI", 9.5F);
            cboSport.FormattingEnabled = true;
            cboSport.Location = new Point(179, 65);
            cboSport.Name = "cboSport";
            cboSport.Size = new Size(235, 29);
            cboSport.TabIndex = 5;
            // 
            // lblIntensity
            // 
            lblIntensity.AutoSize = true;
            lblIntensity.Font = new Font("Segoe UI", 8.8F);
            lblIntensity.ForeColor = Color.FromArgb(90, 90, 85);
            lblIntensity.Location = new Point(422, 42);
            lblIntensity.Name = "lblIntensity";
            lblIntensity.Size = new Size(141, 20);
            lblIntensity.TabIndex = 6;
            lblIntensity.Text = "Mức cường độ (MET)";
            // 
            // cboIntensity
            // 
            cboIntensity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboIntensity.DropDownStyle = ComboBoxStyle.DropDownList;
            cboIntensity.Font = new Font("Segoe UI", 9.5F);
            cboIntensity.FormattingEnabled = true;
            cboIntensity.Location = new Point(422, 65);
            cboIntensity.Name = "cboIntensity";
            cboIntensity.Size = new Size(205, 29);
            cboIntensity.TabIndex = 7;
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font("Segoe UI", 8.8F);
            lblDuration.ForeColor = Color.FromArgb(90, 90, 85);
            lblDuration.Location = new Point(16, 103);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(111, 20);
            lblDuration.TabIndex = 8;
            lblDuration.Text = "Thời gian (phút)";
            // 
            // numDuration
            // 
            numDuration.Font = new Font("Segoe UI", 9.5F);
            numDuration.Location = new Point(16, 126);
            numDuration.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            numDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(115, 29);
            numDuration.TabIndex = 9;
            numDuration.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // lblCalories
            // 
            lblCalories.AutoSize = true;
            lblCalories.Font = new Font("Segoe UI", 8.8F);
            lblCalories.ForeColor = Color.FromArgb(90, 90, 85);
            lblCalories.Location = new Point(141, 103);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(106, 20);
            lblCalories.TabIndex = 10;
            lblCalories.Text = "Calo đốt (kcal)";
            // 
            // numCalories
            // 
            numCalories.Font = new Font("Segoe UI", 9.5F);
            numCalories.Location = new Point(141, 126);
            numCalories.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numCalories.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCalories.Name = "numCalories";
            numCalories.Size = new Size(120, 29);
            numCalories.TabIndex = 11;
            numCalories.ThousandsSeparator = true;
            numCalories.Value = new decimal(new int[] { 300, 0, 0, 0 });
            // 
            // lblIntensityDesc
            // 
            lblIntensityDesc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblIntensityDesc.AutoEllipsis = true;
            lblIntensityDesc.Font = new Font("Segoe UI", 8.8F, FontStyle.Italic);
            lblIntensityDesc.ForeColor = Color.FromArgb(120, 100, 45);
            lblIntensityDesc.Location = new Point(272, 129);
            lblIntensityDesc.Name = "lblIntensityDesc";
            lblIntensityDesc.Size = new Size(355, 25);
            lblIntensityDesc.TabIndex = 12;
            lblIntensityDesc.Text = "⚡ MET 8.3 • Chạy vừa, nhịp thở đều";
            // 
            // btnAddWorkout
            // 
            btnAddWorkout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddWorkout.BackColor = Color.FromArgb(34, 76, 56);
            btnAddWorkout.Cursor = Cursors.Hand;
            btnAddWorkout.FlatAppearance.BorderSize = 0;
            btnAddWorkout.FlatStyle = FlatStyle.Flat;
            btnAddWorkout.Font = new Font("Segoe UI Semibold", 9.8F, FontStyle.Bold);
            btnAddWorkout.ForeColor = Color.White;
            btnAddWorkout.Location = new Point(640, 65);
            btnAddWorkout.Name = "btnAddWorkout";
            btnAddWorkout.Size = new Size(122, 90);
            btnAddWorkout.TabIndex = 13;
            btnAddWorkout.Text = "＋ Lưu\r\nbuổi tập";
            btnAddWorkout.UseVisualStyleBackColor = false;
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.FromArgb(230, 245, 235);
            pnlSummary.Controls.Add(lblSummaryTip);
            pnlSummary.Controls.Add(lblSummary);
            pnlSummary.Controls.Add(lblSummaryTitle);
            pnlSummary.Dock = DockStyle.Fill;
            pnlSummary.Location = new Point(797, 95);
            pnlSummary.Margin = new Padding(14, 0, 0, 0);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Padding = new Padding(18);
            pnlSummary.Size = new Size(355, 179);
            pnlSummary.TabIndex = 2;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSummary.ForeColor = Color.FromArgb(34, 76, 56);
            lblSummary.Location = new Point(18, 56);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(184, 35);
            lblSummary.TabIndex = 0;
            lblSummary.Text = "0 phút • 0 kcal";
            // 
            // lblSummaryTitle
            // 
            lblSummaryTitle.AutoSize = true;
            lblSummaryTitle.Font = new Font("Segoe UI", 9.5F);
            lblSummaryTitle.ForeColor = Color.FromArgb(80, 100, 85);
            lblSummaryTitle.Location = new Point(18, 24);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Size = new Size(194, 21);
            lblSummaryTitle.TabIndex = 1;
            lblSummaryTitle.Text = "Tổng vận động trong ngày";
            // 
            // lblSummaryTip
            // 
            lblSummaryTip.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSummaryTip.Font = new Font("Segoe UI", 8.8F);
            lblSummaryTip.ForeColor = Color.FromArgb(90, 120, 100);
            lblSummaryTip.Location = new Point(18, 100);
            lblSummaryTip.Name = "lblSummaryTip";
            lblSummaryTip.Size = new Size(320, 60);
            lblSummaryTip.TabIndex = 2;
            lblSummaryTip.Text = "💡 Tính lượng calo chuẩn theo chỉ số MET (ACSM) dựa trên cân nặng thực tế và cường độ vận động.";
            // 
            // pnlWorkoutList
            // 
            pnlWorkoutList.AutoScroll = true;
            tlpMain.SetColumnSpan(pnlWorkoutList, 2);
            pnlWorkoutList.Controls.Add(lblListTitle);
            pnlWorkoutList.Dock = DockStyle.Fill;
            pnlWorkoutList.Location = new Point(3, 280);
            pnlWorkoutList.Name = "pnlWorkoutList";
            pnlWorkoutList.Padding = new Padding(0, 20, 0, 0);
            pnlWorkoutList.Size = new Size(1146, 481);
            pnlWorkoutList.TabIndex = 3;
            // 
            // lblListTitle
            // 
            lblListTitle.AutoSize = true;
            lblListTitle.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblListTitle.ForeColor = Color.FromArgb(40, 50, 45);
            lblListTitle.Location = new Point(16, 20);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(178, 25);
            lblListTitle.TabIndex = 0;
            lblListTitle.Text = "Các buổi tập đã ghi";
            // 
            // ucWorkout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Name = "ucWorkout";
            Size = new Size(1200, 800);
            pnlMain.ResumeLayout(false);
            tlpMain.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlEntry.ResumeLayout(false);
            pnlEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCalories).EndInit();
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlWorkoutList.ResumeLayout(false);
            pnlWorkoutList.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private TableLayoutPanel tlpMain;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblSelectedDate;
        private Button btnPreviousDay;
        private Button btnNextDay;
        private Panel pnlEntry;
        private Label lblEntryTitle;
        private Label lblUserWeightInfo;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Label lblSport;
        private ComboBox cboSport;
        private Label lblIntensity;
        private ComboBox cboIntensity;
        private Label lblDuration;
        private NumericUpDown numDuration;
        private Label lblCalories;
        private NumericUpDown numCalories;
        private Label lblIntensityDesc;
        private Button btnAddWorkout;
        private Panel pnlSummary;
        private Label lblSummaryTitle;
        private Label lblSummary;
        private Label lblSummaryTip;
        private Panel pnlWorkoutList;
        private Label lblListTitle;
    }
}
