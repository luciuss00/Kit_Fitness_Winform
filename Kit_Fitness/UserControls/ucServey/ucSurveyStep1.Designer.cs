namespace Kit_Fitness.UserControls
{
    partial class ucSurveyStep1
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
            lblBadge = new Label();
            lblTitle = new Label();
            lblSub = new Label();
            lblSection1 = new Label();
            pnlFemale = new Panel();
            lblFemaleSub = new Label();
            lblFemaleTitle = new Label();
            lblFemaleIcon = new Label();
            pnlMale = new Panel();
            lblMaleSub = new Label();
            lblMaleTitle = new Label();
            lblMaleIcon = new Label();
            pnlAgeBox = new Panel();
            trackAge = new TrackBar();
            btnPlusAge = new Button();
            lblAgeVal = new Label();
            btnMinusAge = new Button();
            lblAgeTitle = new Label();
            pnlFemale.SuspendLayout();
            pnlMale.SuspendLayout();
            pnlAgeBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackAge).BeginInit();
            SuspendLayout();
            // 
            // lblBadge
            // 
            lblBadge.AutoSize = true;
            lblBadge.BackColor = Color.FromArgb(240, 248, 240);
            lblBadge.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblBadge.ForeColor = Color.FromArgb(34, 112, 68);
            lblBadge.Location = new Point(25, 20);
            lblBadge.Name = "lblBadge";
            lblBadge.Padding = new Padding(6, 2, 6, 2);
            lblBadge.Size = new Size(214, 23);
            lblBadge.TabIndex = 0;
            lblBadge.Text = "🌱 Bước 1: Khởi đầu thể trạng";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 40, 35);
            lblTitle.Location = new Point(25, 48);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(580, 35);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Giới tính và Độ tuổi của bạn";
            // 
            // lblSub
            // 
            lblSub.Font = new Font("Segoe UI", 8.8F);
            lblSub.ForeColor = Color.FromArgb(120, 120, 115);
            lblSub.Location = new Point(25, 85);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(600, 30);
            lblSub.TabIndex = 2;
            lblSub.Text = "Cơ sở khoa học để tính năng lượng trao đổi chất cơ bản (BMR) chuẩn phương trình Mifflin-St Jeor.";
            // 
            // lblSection1
            // 
            lblSection1.AutoSize = true;
            lblSection1.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblSection1.ForeColor = Color.FromArgb(120, 120, 115);
            lblSection1.Location = new Point(25, 122);
            lblSection1.Name = "lblSection1";
            lblSection1.Size = new Size(199, 20);
            lblSection1.TabIndex = 3;
            lblSection1.Text = "CHỌN GIỚI TÍNH SINH HỌC";
            // 
            // pnlFemale
            // 
            pnlFemale.BackColor = Color.FromArgb(246, 252, 248);
            pnlFemale.BorderStyle = BorderStyle.FixedSingle;
            pnlFemale.Controls.Add(lblFemaleSub);
            pnlFemale.Controls.Add(lblFemaleTitle);
            pnlFemale.Controls.Add(lblFemaleIcon);
            pnlFemale.Cursor = Cursors.Hand;
            pnlFemale.Location = new Point(25, 150);
            pnlFemale.Name = "pnlFemale";
            pnlFemale.Size = new Size(290, 130);
            pnlFemale.TabIndex = 4;
            // 
            // lblFemaleSub
            // 
            lblFemaleSub.Font = new Font("Segoe UI", 8F);
            lblFemaleSub.ForeColor = Color.FromArgb(120, 120, 115);
            lblFemaleSub.Location = new Point(10, 92);
            lblFemaleSub.Name = "lblFemaleSub";
            lblFemaleSub.Size = new Size(270, 20);
            lblFemaleSub.TabIndex = 2;
            lblFemaleSub.Text = "Tiêu chuẩn thể trạng nữ";
            lblFemaleSub.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFemaleTitle
            // 
            lblFemaleTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFemaleTitle.ForeColor = Color.FromArgb(30, 40, 35);
            lblFemaleTitle.Location = new Point(10, 65);
            lblFemaleTitle.Name = "lblFemaleTitle";
            lblFemaleTitle.Size = new Size(270, 24);
            lblFemaleTitle.TabIndex = 1;
            lblFemaleTitle.Text = "Nữ giới";
            lblFemaleTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFemaleIcon
            // 
            lblFemaleIcon.Font = new Font("Segoe UI", 24F);
            lblFemaleIcon.Location = new Point(10, 15);
            lblFemaleIcon.Name = "lblFemaleIcon";
            lblFemaleIcon.Size = new Size(270, 45);
            lblFemaleIcon.TabIndex = 0;
            lblFemaleIcon.Text = "👩";
            lblFemaleIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMale
            // 
            pnlMale.BackColor = Color.White;
            pnlMale.BorderStyle = BorderStyle.FixedSingle;
            pnlMale.Controls.Add(lblMaleSub);
            pnlMale.Controls.Add(lblMaleTitle);
            pnlMale.Controls.Add(lblMaleIcon);
            pnlMale.Cursor = Cursors.Hand;
            pnlMale.Location = new Point(335, 150);
            pnlMale.Name = "pnlMale";
            pnlMale.Size = new Size(290, 130);
            pnlMale.TabIndex = 5;
            // 
            // lblMaleSub
            // 
            lblMaleSub.Font = new Font("Segoe UI", 8F);
            lblMaleSub.ForeColor = Color.FromArgb(120, 120, 115);
            lblMaleSub.Location = new Point(10, 92);
            lblMaleSub.Name = "lblMaleSub";
            lblMaleSub.Size = new Size(270, 20);
            lblMaleSub.TabIndex = 2;
            lblMaleSub.Text = "Tiêu chuẩn thể trạng nam";
            lblMaleSub.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMaleTitle
            // 
            lblMaleTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMaleTitle.ForeColor = Color.FromArgb(30, 40, 35);
            lblMaleTitle.Location = new Point(10, 65);
            lblMaleTitle.Name = "lblMaleTitle";
            lblMaleTitle.Size = new Size(270, 24);
            lblMaleTitle.TabIndex = 1;
            lblMaleTitle.Text = "Nam giới";
            lblMaleTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMaleIcon
            // 
            lblMaleIcon.Font = new Font("Segoe UI", 24F);
            lblMaleIcon.Location = new Point(10, 15);
            lblMaleIcon.Name = "lblMaleIcon";
            lblMaleIcon.Size = new Size(270, 45);
            lblMaleIcon.TabIndex = 0;
            lblMaleIcon.Text = "👨";
            lblMaleIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAgeBox
            // 
            pnlAgeBox.BackColor = Color.FromArgb(252, 250, 245);
            pnlAgeBox.Controls.Add(trackAge);
            pnlAgeBox.Controls.Add(btnPlusAge);
            pnlAgeBox.Controls.Add(lblAgeVal);
            pnlAgeBox.Controls.Add(btnMinusAge);
            pnlAgeBox.Controls.Add(lblAgeTitle);
            pnlAgeBox.Location = new Point(25, 305);
            pnlAgeBox.Name = "pnlAgeBox";
            pnlAgeBox.Padding = new Padding(20);
            pnlAgeBox.Size = new Size(600, 140);
            pnlAgeBox.TabIndex = 6;
            // 
            // trackAge
            // 
            trackAge.Location = new Point(20, 70);
            trackAge.Maximum = 80;
            trackAge.Minimum = 14;
            trackAge.Name = "trackAge";
            trackAge.Size = new Size(560, 56);
            trackAge.TabIndex = 4;
            trackAge.TickStyle = TickStyle.None;
            trackAge.Value = 24;
            // 
            // btnPlusAge
            // 
            btnPlusAge.BackColor = Color.White;
            btnPlusAge.Cursor = Cursors.Hand;
            btnPlusAge.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnPlusAge.FlatStyle = FlatStyle.Flat;
            btnPlusAge.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPlusAge.Location = new Point(540, 15);
            btnPlusAge.Name = "btnPlusAge";
            btnPlusAge.Size = new Size(42, 38);
            btnPlusAge.TabIndex = 3;
            btnPlusAge.Text = "+";
            btnPlusAge.UseVisualStyleBackColor = false;
            // 
            // lblAgeVal
            // 
            lblAgeVal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAgeVal.ForeColor = Color.FromArgb(30, 40, 35);
            lblAgeVal.Location = new Point(455, 15);
            lblAgeVal.Name = "lblAgeVal";
            lblAgeVal.Size = new Size(80, 38);
            lblAgeVal.TabIndex = 2;
            lblAgeVal.Text = "24 tuổi";
            lblAgeVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnMinusAge
            // 
            btnMinusAge.BackColor = Color.White;
            btnMinusAge.Cursor = Cursors.Hand;
            btnMinusAge.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnMinusAge.FlatStyle = FlatStyle.Flat;
            btnMinusAge.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMinusAge.Location = new Point(405, 15);
            btnMinusAge.Name = "btnMinusAge";
            btnMinusAge.Size = new Size(42, 38);
            btnMinusAge.TabIndex = 1;
            btnMinusAge.Text = "—";
            btnMinusAge.UseVisualStyleBackColor = false;
            // 
            // lblAgeTitle
            // 
            lblAgeTitle.AutoSize = true;
            lblAgeTitle.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblAgeTitle.ForeColor = Color.FromArgb(100, 100, 95);
            lblAgeTitle.Location = new Point(20, 24);
            lblAgeTitle.Name = "lblAgeTitle";
            lblAgeTitle.Size = new Size(134, 20);
            lblAgeTitle.TabIndex = 0;
            lblAgeTitle.Text = "ĐỘ TUỔI HIỆN TẠI";
            // 
            // ucSurveyStep1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(pnlAgeBox);
            Controls.Add(pnlMale);
            Controls.Add(pnlFemale);
            Controls.Add(lblSection1);
            Controls.Add(lblSub);
            Controls.Add(lblTitle);
            Controls.Add(lblBadge);
            Name = "ucSurveyStep1";
            Padding = new Padding(25);
            Size = new Size(650, 580);
            Load += ucSurveyStep1_Load;
            pnlFemale.ResumeLayout(false);
            pnlMale.ResumeLayout(false);
            pnlAgeBox.ResumeLayout(false);
            pnlAgeBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackAge).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBadge;
        private Label lblTitle;
        private Label lblSub;
        private Label lblSection1;
        private Panel pnlFemale;
        private Label lblFemaleIcon;
        private Label lblFemaleTitle;
        private Label lblFemaleSub;
        private Panel pnlMale;
        private Label lblMaleIcon;
        private Label lblMaleTitle;
        private Label lblMaleSub;
        private Panel pnlAgeBox;
        private Label lblAgeTitle;
        private Button btnMinusAge;
        private Label lblAgeVal;
        private Button btnPlusAge;
        private TrackBar trackAge;
    }
}
