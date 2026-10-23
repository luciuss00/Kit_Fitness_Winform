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
            btnAddWorkout = new Button();
            numCalories = new NumericUpDown();
            lblCalories = new Label();
            numDuration = new NumericUpDown();
            lblDuration = new Label();
            txtExerciseName = new TextBox();
            lblExerciseName = new Label();
            lblEntryTitle = new Label();
            pnlSummary = new Panel();
            lblSummary = new Label();
            lblSummaryTitle = new Label();
            pnlWorkoutList = new Panel();
            lblListTitle = new Label();
            pnlMain.SuspendLayout();
            tlpMain.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCalories).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
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
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
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
            pnlEntry.Controls.Add(btnAddWorkout);
            pnlEntry.Controls.Add(numCalories);
            pnlEntry.Controls.Add(lblCalories);
            pnlEntry.Controls.Add(numDuration);
            pnlEntry.Controls.Add(lblDuration);
            pnlEntry.Controls.Add(txtExerciseName);
            pnlEntry.Controls.Add(lblExerciseName);
            pnlEntry.Controls.Add(lblEntryTitle);
            pnlEntry.Dock = DockStyle.Fill;
            pnlEntry.Location = new Point(3, 95);
            pnlEntry.Name = "pnlEntry";
            pnlEntry.Padding = new Padding(16);
            pnlEntry.Size = new Size(777, 144);
            pnlEntry.TabIndex = 1;
            // 
            // btnAddWorkout
            // 
            btnAddWorkout.AutoSize = true;
            btnAddWorkout.BackColor = Color.FromArgb(34, 76, 56);
            btnAddWorkout.Cursor = Cursors.Hand;
            btnAddWorkout.FlatAppearance.BorderSize = 0;
            btnAddWorkout.FlatStyle = FlatStyle.Flat;
            btnAddWorkout.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnAddWorkout.ForeColor = Color.White;
            btnAddWorkout.Location = new Point(582, 67);
            btnAddWorkout.Name = "btnAddWorkout";
            btnAddWorkout.Size = new Size(139, 47);
            btnAddWorkout.TabIndex = 0;
            btnAddWorkout.Text = "＋ Lưu buổi tập";
            btnAddWorkout.UseVisualStyleBackColor = false;
            // 
            // numCalories
            // 
            numCalories.Location = new Point(382, 78);
            numCalories.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numCalories.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCalories.Name = "numCalories";
            numCalories.Size = new Size(150, 27);
            numCalories.TabIndex = 1;
            numCalories.ThousandsSeparator = true;
            numCalories.Value = new decimal(new int[] { 300, 0, 0, 0 });
            // 
            // lblCalories
            // 
            lblCalories.AutoSize = true;
            lblCalories.ForeColor = Color.FromArgb(90, 90, 85);
            lblCalories.Location = new Point(382, 53);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(140, 20);
            lblCalories.TabIndex = 2;
            lblCalories.Text = "Calo đốt cháy (kcal)";
            // 
            // numDuration
            // 
            numDuration.Location = new Point(216, 78);
            numDuration.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            numDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(145, 27);
            numDuration.TabIndex = 3;
            numDuration.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.ForeColor = Color.FromArgb(90, 90, 85);
            lblDuration.Location = new Point(216, 53);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(115, 20);
            lblDuration.TabIndex = 4;
            lblDuration.Text = "Thời gian (phút)";
            // 
            // txtExerciseName
            // 
            txtExerciseName.Location = new Point(16, 78);
            txtExerciseName.Name = "txtExerciseName";
            txtExerciseName.Size = new Size(185, 27);
            txtExerciseName.TabIndex = 5;
            // 
            // lblExerciseName
            // 
            lblExerciseName.AutoSize = true;
            lblExerciseName.ForeColor = Color.FromArgb(90, 90, 85);
            lblExerciseName.Location = new Point(16, 53);
            lblExerciseName.Name = "lblExerciseName";
            lblExerciseName.Size = new Size(127, 20);
            lblExerciseName.TabIndex = 6;
            lblExerciseName.Text = "Tên môn / bài tập";
            // 
            // lblEntryTitle
            // 
            lblEntryTitle.AutoSize = true;
            lblEntryTitle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblEntryTitle.ForeColor = Color.FromArgb(40, 50, 45);
            lblEntryTitle.Location = new Point(16, 16);
            lblEntryTitle.Name = "lblEntryTitle";
            lblEntryTitle.Size = new Size(215, 25);
            lblEntryTitle.TabIndex = 7;
            lblEntryTitle.Text = "Ghi lại buổi tập hôm nay";
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.FromArgb(230, 245, 235);
            pnlSummary.Controls.Add(lblSummary);
            pnlSummary.Controls.Add(lblSummaryTitle);
            pnlSummary.Dock = DockStyle.Fill;
            pnlSummary.Location = new Point(797, 92);
            pnlSummary.Margin = new Padding(14, 0, 0, 0);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Padding = new Padding(18);
            pnlSummary.Size = new Size(355, 150);
            pnlSummary.TabIndex = 2;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblSummary.ForeColor = Color.FromArgb(34, 76, 56);
            lblSummary.Location = new Point(18, 64);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(162, 30);
            lblSummary.TabIndex = 0;
            lblSummary.Text = "0 phút • 0 kcal";
            // 
            // lblSummaryTitle
            // 
            lblSummaryTitle.AutoSize = true;
            lblSummaryTitle.Font = new Font("Segoe UI", 9.5F);
            lblSummaryTitle.ForeColor = Color.FromArgb(80, 100, 85);
            lblSummaryTitle.Location = new Point(18, 28);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Size = new Size(194, 21);
            lblSummaryTitle.TabIndex = 1;
            lblSummaryTitle.Text = "Tổng vận động trong ngày";
            // 
            // pnlWorkoutList
            // 
            pnlWorkoutList.AutoScroll = true;
            tlpMain.SetColumnSpan(pnlWorkoutList, 2);
            pnlWorkoutList.Controls.Add(lblListTitle);
            pnlWorkoutList.Dock = DockStyle.Fill;
            pnlWorkoutList.Location = new Point(3, 245);
            pnlWorkoutList.Name = "pnlWorkoutList";
            pnlWorkoutList.Padding = new Padding(0, 20, 0, 0);
            pnlWorkoutList.Size = new Size(1146, 516);
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
            ((System.ComponentModel.ISupportInitialize)numCalories).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlWorkoutList.ResumeLayout(false);
            pnlWorkoutList.PerformLayout();
            ResumeLayout(false);
        }

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
        private Label lblExerciseName;
        private TextBox txtExerciseName;
        private Label lblDuration;
        private NumericUpDown numDuration;
        private Label lblCalories;
        private NumericUpDown numCalories;
        private Button btnAddWorkout;
        private Panel pnlSummary;
        private Label lblSummaryTitle;
        private Label lblSummary;
        private Panel pnlWorkoutList;
        private Label lblListTitle;

        #endregion
    }
}
