namespace Kit_Fitness.UserControls
{
    partial class ucSurveyStep3
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
            pnlGoal1 = new Panel();
            lblGoal1Check = new Label();
            lblGoal1Desc = new Label();
            lblGoal1Badge = new Label();
            lblGoal1Title = new Label();
            lblGoal1Icon = new Label();
            pnlGoal2 = new Panel();
            lblGoal2Check = new Label();
            lblGoal2Desc = new Label();
            lblGoal2Badge = new Label();
            lblGoal2Title = new Label();
            lblGoal2Icon = new Label();
            pnlGoal3 = new Panel();
            lblGoal3Check = new Label();
            lblGoal3Desc = new Label();
            lblGoal3Badge = new Label();
            lblGoal3Title = new Label();
            lblGoal3Icon = new Label();
            pnlTargetW = new Panel();
            trackTW = new TrackBar();
            btnPlusTW = new Button();
            lblTWVal = new Label();
            btnMinusTW = new Button();
            lblTWDiff = new Label();
            lblTWTitle = new Label();
            pnlGoal1.SuspendLayout();
            pnlGoal2.SuspendLayout();
            pnlGoal3.SuspendLayout();
            pnlTargetW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackTW).BeginInit();
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
            lblBadge.Size = new Size(232, 23);
            lblBadge.TabIndex = 0;
            lblBadge.Text = "🌱 Bước 3: Định hướng mục tiêu";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 40, 35);
            lblTitle.Location = new Point(25, 48);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(580, 35);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Mục tiêu thể trạng của bạn";
            // 
            // lblSub
            // 
            lblSub.Font = new Font("Segoe UI", 8.8F);
            lblSub.ForeColor = Color.FromArgb(120, 120, 115);
            lblSub.Location = new Point(25, 85);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(600, 30);
            lblSub.TabIndex = 2;
            lblSub.Text = "Kit Fitness sẽ tinh chỉnh lượng calo thâm hụt hoặc dư thừa lành mạnh nhất.";
            // 
            // pnlGoal1
            // 
            pnlGoal1.BackColor = Color.FromArgb(246, 252, 248);
            pnlGoal1.BorderStyle = BorderStyle.FixedSingle;
            pnlGoal1.Controls.Add(lblGoal1Check);
            pnlGoal1.Controls.Add(lblGoal1Desc);
            pnlGoal1.Controls.Add(lblGoal1Badge);
            pnlGoal1.Controls.Add(lblGoal1Title);
            pnlGoal1.Controls.Add(lblGoal1Icon);
            pnlGoal1.Cursor = Cursors.Hand;
            pnlGoal1.Location = new Point(25, 120);
            pnlGoal1.Name = "pnlGoal1";
            pnlGoal1.Size = new Size(610, 75);
            pnlGoal1.TabIndex = 3;
            // 
            // lblGoal1Check
            // 
            lblGoal1Check.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblGoal1Check.ForeColor = Color.FromArgb(34, 112, 68);
            lblGoal1Check.Location = new Point(570, 22);
            lblGoal1Check.Name = "lblGoal1Check";
            lblGoal1Check.Size = new Size(30, 30);
            lblGoal1Check.TabIndex = 4;
            lblGoal1Check.Text = "✓";
            lblGoal1Check.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGoal1Desc
            // 
            lblGoal1Desc.Font = new Font("Segoe UI", 8.2F);
            lblGoal1Desc.ForeColor = Color.FromArgb(120, 120, 115);
            lblGoal1Desc.Location = new Point(55, 42);
            lblGoal1Desc.Name = "lblGoal1Desc";
            lblGoal1Desc.Size = new Size(500, 22);
            lblGoal1Desc.TabIndex = 3;
            lblGoal1Desc.Text = "Thâm hụt 500 kcal/ngày từ thực phẩm tươi, không nhịn ăn cực đoan";
            // 
            // lblGoal1Badge
            // 
            lblGoal1Badge.AutoSize = true;
            lblGoal1Badge.BackColor = Color.FromArgb(250, 245, 235);
            lblGoal1Badge.Font = new Font("Segoe UI", 7.5F);
            lblGoal1Badge.ForeColor = Color.FromArgb(120, 100, 50);
            lblGoal1Badge.Location = new Point(287, 14);
            lblGoal1Badge.Name = "lblGoal1Badge";
            lblGoal1Badge.Padding = new Padding(4, 2, 4, 2);
            lblGoal1Badge.Size = new Size(183, 21);
            lblGoal1Badge.TabIndex = 2;
            lblGoal1Badge.Text = "Khuyên dùng cho văn phòng";
            // 
            // lblGoal1Title
            // 
            lblGoal1Title.AutoSize = true;
            lblGoal1Title.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblGoal1Title.ForeColor = Color.FromArgb(30, 40, 35);
            lblGoal1Title.Location = new Point(55, 14);
            lblGoal1Title.Name = "lblGoal1Title";
            lblGoal1Title.Size = new Size(208, 25);
            lblGoal1Title.TabIndex = 1;
            lblGoal1Title.Text = "Giảm mỡ và Nhẹ người";
            // 
            // lblGoal1Icon
            // 
            lblGoal1Icon.Font = new Font("Segoe UI", 14F);
            lblGoal1Icon.Location = new Point(12, 16);
            lblGoal1Icon.Name = "lblGoal1Icon";
            lblGoal1Icon.Size = new Size(35, 35);
            lblGoal1Icon.TabIndex = 0;
            lblGoal1Icon.Text = "📉";
            lblGoal1Icon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlGoal2
            // 
            pnlGoal2.BackColor = Color.White;
            pnlGoal2.BorderStyle = BorderStyle.FixedSingle;
            pnlGoal2.Controls.Add(lblGoal2Check);
            pnlGoal2.Controls.Add(lblGoal2Desc);
            pnlGoal2.Controls.Add(lblGoal2Badge);
            pnlGoal2.Controls.Add(lblGoal2Title);
            pnlGoal2.Controls.Add(lblGoal2Icon);
            pnlGoal2.Cursor = Cursors.Hand;
            pnlGoal2.Location = new Point(25, 208);
            pnlGoal2.Name = "pnlGoal2";
            pnlGoal2.Size = new Size(610, 75);
            pnlGoal2.TabIndex = 4;
            // 
            // lblGoal2Check
            // 
            lblGoal2Check.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblGoal2Check.ForeColor = Color.FromArgb(34, 112, 68);
            lblGoal2Check.Location = new Point(570, 22);
            lblGoal2Check.Name = "lblGoal2Check";
            lblGoal2Check.Size = new Size(30, 30);
            lblGoal2Check.TabIndex = 4;
            lblGoal2Check.Text = "✓";
            lblGoal2Check.TextAlign = ContentAlignment.MiddleCenter;
            lblGoal2Check.Visible = false;
            // 
            // lblGoal2Desc
            // 
            lblGoal2Desc.Font = new Font("Segoe UI", 8.2F);
            lblGoal2Desc.ForeColor = Color.FromArgb(120, 120, 115);
            lblGoal2Desc.Location = new Point(55, 42);
            lblGoal2Desc.Name = "lblGoal2Desc";
            lblGoal2Desc.Size = new Size(500, 22);
            lblGoal2Desc.TabIndex = 3;
            lblGoal2Desc.Text = "Cân bằng calo, chống lãng phí trong tủ lạnh và đủ chất dinh dưỡng";
            // 
            // lblGoal2Badge
            // 
            lblGoal2Badge.AutoSize = true;
            lblGoal2Badge.BackColor = Color.FromArgb(250, 245, 235);
            lblGoal2Badge.Font = new Font("Segoe UI", 7.5F);
            lblGoal2Badge.ForeColor = Color.FromArgb(120, 100, 50);
            lblGoal2Badge.Location = new Point(287, 14);
            lblGoal2Badge.Name = "lblGoal2Badge";
            lblGoal2Badge.Padding = new Padding(4, 2, 4, 2);
            lblGoal2Badge.Size = new Size(123, 21);
            lblGoal2Badge.TabIndex = 2;
            lblGoal2Badge.Text = "Ăn sạch & Bền vững";
            // 
            // lblGoal2Title
            // 
            lblGoal2Title.AutoSize = true;
            lblGoal2Title.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblGoal2Title.ForeColor = Color.FromArgb(30, 40, 35);
            lblGoal2Title.Location = new Point(55, 14);
            lblGoal2Title.Name = "lblGoal2Title";
            lblGoal2Title.Size = new Size(226, 25);
            lblGoal2Title.TabIndex = 1;
            lblGoal2Title.Text = "Giữ dáng và Ăn tươi lành";
            // 
            // lblGoal2Icon
            // 
            lblGoal2Icon.Font = new Font("Segoe UI", 14F);
            lblGoal2Icon.Location = new Point(12, 16);
            lblGoal2Icon.Name = "lblGoal2Icon";
            lblGoal2Icon.Size = new Size(35, 35);
            lblGoal2Icon.TabIndex = 0;
            lblGoal2Icon.Text = "\U0001f957";
            lblGoal2Icon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlGoal3
            // 
            pnlGoal3.BackColor = Color.White;
            pnlGoal3.BorderStyle = BorderStyle.FixedSingle;
            pnlGoal3.Controls.Add(lblGoal3Check);
            pnlGoal3.Controls.Add(lblGoal3Desc);
            pnlGoal3.Controls.Add(lblGoal3Badge);
            pnlGoal3.Controls.Add(lblGoal3Title);
            pnlGoal3.Controls.Add(lblGoal3Icon);
            pnlGoal3.Cursor = Cursors.Hand;
            pnlGoal3.Location = new Point(25, 296);
            pnlGoal3.Name = "pnlGoal3";
            pnlGoal3.Size = new Size(610, 75);
            pnlGoal3.TabIndex = 5;
            // 
            // lblGoal3Check
            // 
            lblGoal3Check.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblGoal3Check.ForeColor = Color.FromArgb(34, 112, 68);
            lblGoal3Check.Location = new Point(570, 22);
            lblGoal3Check.Name = "lblGoal3Check";
            lblGoal3Check.Size = new Size(30, 30);
            lblGoal3Check.TabIndex = 4;
            lblGoal3Check.Text = "✓";
            lblGoal3Check.TextAlign = ContentAlignment.MiddleCenter;
            lblGoal3Check.Visible = false;
            // 
            // lblGoal3Desc
            // 
            lblGoal3Desc.Font = new Font("Segoe UI", 8.2F);
            lblGoal3Desc.ForeColor = Color.FromArgb(120, 120, 115);
            lblGoal3Desc.Location = new Point(55, 42);
            lblGoal3Desc.Name = "lblGoal3Desc";
            lblGoal3Desc.Size = new Size(500, 22);
            lblGoal3Desc.TabIndex = 3;
            lblGoal3Desc.Text = "Dư thừa 300 kcal/ngày giàu đạm tươi để cơ thể săn chắc đầy đặn";
            // 
            // lblGoal3Badge
            // 
            lblGoal3Badge.AutoSize = true;
            lblGoal3Badge.BackColor = Color.FromArgb(250, 245, 235);
            lblGoal3Badge.Font = new Font("Segoe UI", 7.5F);
            lblGoal3Badge.ForeColor = Color.FromArgb(120, 100, 50);
            lblGoal3Badge.Location = new Point(287, 14);
            lblGoal3Badge.Name = "lblGoal3Badge";
            lblGoal3Badge.Padding = new Padding(4, 2, 4, 2);
            lblGoal3Badge.Size = new Size(118, 21);
            lblGoal3Badge.TabIndex = 2;
            lblGoal3Badge.Text = "Tập luyện & Bồi bổ";
            // 
            // lblGoal3Title
            // 
            lblGoal3Title.AutoSize = true;
            lblGoal3Title.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblGoal3Title.ForeColor = Color.FromArgb(30, 40, 35);
            lblGoal3Title.Location = new Point(55, 14);
            lblGoal3Title.Name = "lblGoal3Title";
            lblGoal3Title.Size = new Size(227, 25);
            lblGoal3Title.TabIndex = 1;
            lblGoal3Title.Text = "Tăng cân và Phát triển cơ";
            // 
            // lblGoal3Icon
            // 
            lblGoal3Icon.Font = new Font("Segoe UI", 14F);
            lblGoal3Icon.Location = new Point(12, 16);
            lblGoal3Icon.Name = "lblGoal3Icon";
            lblGoal3Icon.Size = new Size(35, 35);
            lblGoal3Icon.TabIndex = 0;
            lblGoal3Icon.Text = "💪";
            lblGoal3Icon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTargetW
            // 
            pnlTargetW.BackColor = Color.FromArgb(252, 250, 245);
            pnlTargetW.Controls.Add(trackTW);
            pnlTargetW.Controls.Add(btnPlusTW);
            pnlTargetW.Controls.Add(lblTWVal);
            pnlTargetW.Controls.Add(btnMinusTW);
            pnlTargetW.Controls.Add(lblTWDiff);
            pnlTargetW.Controls.Add(lblTWTitle);
            pnlTargetW.Location = new Point(25, 385);
            pnlTargetW.Name = "pnlTargetW";
            pnlTargetW.Padding = new Padding(15);
            pnlTargetW.Size = new Size(610, 120);
            pnlTargetW.TabIndex = 6;
            // 
            // trackTW
            // 
            trackTW.Location = new Point(15, 60);
            trackTW.Maximum = 120;
            trackTW.Minimum = 35;
            trackTW.Name = "trackTW";
            trackTW.Size = new Size(575, 56);
            trackTW.TabIndex = 5;
            trackTW.TickStyle = TickStyle.None;
            trackTW.Value = 47;
            // 
            // btnPlusTW
            // 
            btnPlusTW.BackColor = Color.White;
            btnPlusTW.Cursor = Cursors.Hand;
            btnPlusTW.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnPlusTW.FlatStyle = FlatStyle.Flat;
            btnPlusTW.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPlusTW.Location = new Point(555, 15);
            btnPlusTW.Name = "btnPlusTW";
            btnPlusTW.Size = new Size(38, 32);
            btnPlusTW.TabIndex = 4;
            btnPlusTW.Text = "+";
            btnPlusTW.UseVisualStyleBackColor = false;
            // 
            // lblTWVal
            // 
            lblTWVal.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTWVal.ForeColor = Color.FromArgb(30, 40, 35);
            lblTWVal.Location = new Point(480, 15);
            lblTWVal.Name = "lblTWVal";
            lblTWVal.Size = new Size(70, 30);
            lblTWVal.TabIndex = 3;
            lblTWVal.Text = "47 kg";
            lblTWVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnMinusTW
            // 
            btnMinusTW.BackColor = Color.White;
            btnMinusTW.Cursor = Cursors.Hand;
            btnMinusTW.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnMinusTW.FlatStyle = FlatStyle.Flat;
            btnMinusTW.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMinusTW.Location = new Point(435, 15);
            btnMinusTW.Name = "btnMinusTW";
            btnMinusTW.Size = new Size(38, 32);
            btnMinusTW.TabIndex = 2;
            btnMinusTW.Text = "—";
            btnMinusTW.UseVisualStyleBackColor = false;
            // 
            // lblTWDiff
            // 
            lblTWDiff.AutoSize = true;
            lblTWDiff.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblTWDiff.ForeColor = Color.FromArgb(34, 112, 68);
            lblTWDiff.Location = new Point(15, 34);
            lblTWDiff.Name = "lblTWDiff";
            lblTWDiff.Size = new Size(106, 20);
            lblTWDiff.TabIndex = 1;
            lblTWDiff.Text = "Cần giảm 3 kg";
            // 
            // lblTWTitle
            // 
            lblTWTitle.AutoSize = true;
            lblTWTitle.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblTWTitle.ForeColor = Color.FromArgb(100, 100, 95);
            lblTWTitle.Location = new Point(15, 12);
            lblTWTitle.Name = "lblTWTitle";
            lblTWTitle.Size = new Size(157, 20);
            lblTWTitle.TabIndex = 0;
            lblTWTitle.Text = "CÂN NẶNG KỲ VỌNG";
            // 
            // ucSurveyStep3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(pnlTargetW);
            Controls.Add(pnlGoal3);
            Controls.Add(pnlGoal2);
            Controls.Add(pnlGoal1);
            Controls.Add(lblSub);
            Controls.Add(lblTitle);
            Controls.Add(lblBadge);
            Name = "ucSurveyStep3";
            Padding = new Padding(25);
            Size = new Size(650, 580);
            Load += ucSurveyStep3_Load;
            pnlGoal1.ResumeLayout(false);
            pnlGoal1.PerformLayout();
            pnlGoal2.ResumeLayout(false);
            pnlGoal2.PerformLayout();
            pnlGoal3.ResumeLayout(false);
            pnlGoal3.PerformLayout();
            pnlTargetW.ResumeLayout(false);
            pnlTargetW.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackTW).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBadge;
        private Label lblTitle;
        private Label lblSub;
        private Panel pnlGoal1;
        private Label lblGoal1Icon;
        private Label lblGoal1Title;
        private Label lblGoal1Badge;
        private Label lblGoal1Desc;
        private Label lblGoal1Check;
        private Panel pnlGoal2;
        private Label lblGoal2Icon;
        private Label lblGoal2Title;
        private Label lblGoal2Badge;
        private Label lblGoal2Desc;
        private Label lblGoal2Check;
        private Panel pnlGoal3;
        private Label lblGoal3Icon;
        private Label lblGoal3Title;
        private Label lblGoal3Badge;
        private Label lblGoal3Desc;
        private Label lblGoal3Check;
        private Panel pnlTargetW;
        private Label lblTWTitle;
        private Label lblTWDiff;
        private Button btnMinusTW;
        private Label lblTWVal;
        private Button btnPlusTW;
        private TrackBar trackTW;
    }
}
