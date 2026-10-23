namespace Kit_Fitness.UserControls
{
    partial class ucSurveyStep4
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
            pnlAct1 = new Panel();
            lblAct1Check = new Label();
            lblAct1Desc = new Label();
            lblAct1Mult = new Label();
            lblAct1Title = new Label();
            pnlAct2 = new Panel();
            lblAct2Check = new Label();
            lblAct2Desc = new Label();
            lblAct2Mult = new Label();
            lblAct2Title = new Label();
            pnlAct3 = new Panel();
            lblAct3Check = new Label();
            lblAct3Desc = new Label();
            lblAct3Mult = new Label();
            lblAct3Title = new Label();
            pnlAct4 = new Panel();
            lblAct4Check = new Label();
            lblAct4Desc = new Label();
            lblAct4Mult = new Label();
            lblAct4Title = new Label();
            pnlAct1.SuspendLayout();
            pnlAct2.SuspendLayout();
            pnlAct3.SuspendLayout();
            pnlAct4.SuspendLayout();
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
            lblBadge.Size = new Size(210, 23);
            lblBadge.TabIndex = 0;
            lblBadge.Text = "🌱 Bước 4: Mức độ vận động";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 40, 35);
            lblTitle.Location = new Point(25, 48);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(580, 35);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Thói quen vận động mỗi ngày";
            // 
            // lblSub
            // 
            lblSub.Font = new Font("Segoe UI", 8.8F);
            lblSub.ForeColor = Color.FromArgb(120, 120, 115);
            lblSub.Location = new Point(25, 85);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(600, 30);
            lblSub.TabIndex = 2;
            lblSub.Text = "Quyết định hệ số TDEE (tổng mức calo bạn thực sự đốt cháy trong 24 giờ).";
            // 
            // pnlAct1
            // 
            pnlAct1.BackColor = Color.White;
            pnlAct1.BorderStyle = BorderStyle.FixedSingle;
            pnlAct1.Controls.Add(lblAct1Check);
            pnlAct1.Controls.Add(lblAct1Desc);
            pnlAct1.Controls.Add(lblAct1Mult);
            pnlAct1.Controls.Add(lblAct1Title);
            pnlAct1.Cursor = Cursors.Hand;
            pnlAct1.Location = new Point(25, 120);
            pnlAct1.Name = "pnlAct1";
            pnlAct1.Size = new Size(610, 80);
            pnlAct1.TabIndex = 3;
            // 
            // lblAct1Check
            // 
            lblAct1Check.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAct1Check.ForeColor = Color.FromArgb(34, 112, 68);
            lblAct1Check.Location = new Point(570, 25);
            lblAct1Check.Name = "lblAct1Check";
            lblAct1Check.Size = new Size(30, 30);
            lblAct1Check.TabIndex = 3;
            lblAct1Check.Text = "✓";
            lblAct1Check.TextAlign = ContentAlignment.MiddleCenter;
            lblAct1Check.Visible = false;
            // 
            // lblAct1Desc
            // 
            lblAct1Desc.Font = new Font("Segoe UI", 8.2F);
            lblAct1Desc.ForeColor = Color.FromArgb(120, 120, 115);
            lblAct1Desc.Location = new Point(18, 44);
            lblAct1Desc.Name = "lblAct1Desc";
            lblAct1Desc.Size = new Size(540, 22);
            lblAct1Desc.TabIndex = 2;
            lblAct1Desc.Text = "Dân văn phòng, ngồi máy tính > 8 tiếng, đi lại ít (< 3.000 bước/ngày)";
            // 
            // lblAct1Mult
            // 
            lblAct1Mult.AutoSize = true;
            lblAct1Mult.BackColor = Color.FromArgb(240, 248, 240);
            lblAct1Mult.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblAct1Mult.ForeColor = Color.FromArgb(34, 112, 68);
            lblAct1Mult.Location = new Point(251, 14);
            lblAct1Mult.Name = "lblAct1Mult";
            lblAct1Mult.Padding = new Padding(4, 2, 4, 2);
            lblAct1Mult.Size = new Size(73, 21);
            lblAct1Mult.TabIndex = 1;
            lblAct1Mult.Text = "x1.2 BMR";
            // 
            // lblAct1Title
            // 
            lblAct1Title.AutoSize = true;
            lblAct1Title.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblAct1Title.ForeColor = Color.FromArgb(30, 40, 35);
            lblAct1Title.Location = new Point(18, 14);
            lblAct1Title.Name = "lblAct1Title";
            lblAct1Title.Size = new Size(223, 25);
            lblAct1Title.TabIndex = 0;
            lblAct1Title.Text = "Ít vận động (Ngồi nhiều)";
            // 
            // pnlAct2
            // 
            pnlAct2.BackColor = Color.White;
            pnlAct2.BorderStyle = BorderStyle.FixedSingle;
            pnlAct2.Controls.Add(lblAct2Check);
            pnlAct2.Controls.Add(lblAct2Desc);
            pnlAct2.Controls.Add(lblAct2Mult);
            pnlAct2.Controls.Add(lblAct2Title);
            pnlAct2.Cursor = Cursors.Hand;
            pnlAct2.Location = new Point(25, 212);
            pnlAct2.Name = "pnlAct2";
            pnlAct2.Size = new Size(610, 80);
            pnlAct2.TabIndex = 4;
            // 
            // lblAct2Check
            // 
            lblAct2Check.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAct2Check.ForeColor = Color.FromArgb(34, 112, 68);
            lblAct2Check.Location = new Point(570, 25);
            lblAct2Check.Name = "lblAct2Check";
            lblAct2Check.Size = new Size(30, 30);
            lblAct2Check.TabIndex = 3;
            lblAct2Check.Text = "✓";
            lblAct2Check.TextAlign = ContentAlignment.MiddleCenter;
            lblAct2Check.Visible = false;
            // 
            // lblAct2Desc
            // 
            lblAct2Desc.Font = new Font("Segoe UI", 8.2F);
            lblAct2Desc.ForeColor = Color.FromArgb(120, 120, 115);
            lblAct2Desc.Location = new Point(18, 44);
            lblAct2Desc.Name = "lblAct2Desc";
            lblAct2Desc.Size = new Size(540, 22);
            lblAct2Desc.TabIndex = 2;
            lblAct2Desc.Text = "Có đi bộ, làm việc nhà, tập nhẹ 1–2 buổi/tuần (3.000 – 6.000 bước/ngày)";
            // 
            // lblAct2Mult
            // 
            lblAct2Mult.AutoSize = true;
            lblAct2Mult.BackColor = Color.FromArgb(240, 248, 240);
            lblAct2Mult.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblAct2Mult.ForeColor = Color.FromArgb(34, 112, 68);
            lblAct2Mult.Location = new Point(214, 18);
            lblAct2Mult.Name = "lblAct2Mult";
            lblAct2Mult.Padding = new Padding(4, 2, 4, 2);
            lblAct2Mult.Size = new Size(87, 21);
            lblAct2Mult.TabIndex = 1;
            lblAct2Mult.Text = "x1.375 BMR";
            // 
            // lblAct2Title
            // 
            lblAct2Title.AutoSize = true;
            lblAct2Title.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblAct2Title.ForeColor = Color.FromArgb(30, 40, 35);
            lblAct2Title.Location = new Point(18, 14);
            lblAct2Title.Name = "lblAct2Title";
            lblAct2Title.Size = new Size(190, 25);
            lblAct2Title.TabIndex = 0;
            lblAct2Title.Text = "Vận động nhẹ nhàng";
            // 
            // pnlAct3
            // 
            pnlAct3.BackColor = Color.FromArgb(246, 252, 248);
            pnlAct3.BorderStyle = BorderStyle.FixedSingle;
            pnlAct3.Controls.Add(lblAct3Check);
            pnlAct3.Controls.Add(lblAct3Desc);
            pnlAct3.Controls.Add(lblAct3Mult);
            pnlAct3.Controls.Add(lblAct3Title);
            pnlAct3.Cursor = Cursors.Hand;
            pnlAct3.Location = new Point(25, 304);
            pnlAct3.Name = "pnlAct3";
            pnlAct3.Size = new Size(610, 80);
            pnlAct3.TabIndex = 5;
            // 
            // lblAct3Check
            // 
            lblAct3Check.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAct3Check.ForeColor = Color.FromArgb(34, 112, 68);
            lblAct3Check.Location = new Point(570, 25);
            lblAct3Check.Name = "lblAct3Check";
            lblAct3Check.Size = new Size(30, 30);
            lblAct3Check.TabIndex = 3;
            lblAct3Check.Text = "✓";
            lblAct3Check.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAct3Desc
            // 
            lblAct3Desc.Font = new Font("Segoe UI", 8.2F);
            lblAct3Desc.ForeColor = Color.FromArgb(120, 120, 115);
            lblAct3Desc.Location = new Point(18, 44);
            lblAct3Desc.Name = "lblAct3Desc";
            lblAct3Desc.Size = new Size(540, 22);
            lblAct3Desc.TabIndex = 2;
            lblAct3Desc.Text = "Tập thể dục, chạy bộ, yoga 3–5 buổi/tuần (7.000 – 10.000 bước/ngày)";
            // 
            // lblAct3Mult
            // 
            lblAct3Mult.AutoSize = true;
            lblAct3Mult.BackColor = Color.FromArgb(240, 248, 240);
            lblAct3Mult.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblAct3Mult.ForeColor = Color.FromArgb(34, 112, 68);
            lblAct3Mult.Location = new Point(330, 18);
            lblAct3Mult.Name = "lblAct3Mult";
            lblAct3Mult.Padding = new Padding(4, 2, 4, 2);
            lblAct3Mult.Size = new Size(80, 21);
            lblAct3Mult.TabIndex = 1;
            lblAct3Mult.Text = "x1.55 BMR";
            // 
            // lblAct3Title
            // 
            lblAct3Title.AutoSize = true;
            lblAct3Title.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblAct3Title.ForeColor = Color.FromArgb(30, 40, 35);
            lblAct3Title.Location = new Point(18, 14);
            lblAct3Title.Name = "lblAct3Title";
            lblAct3Title.Size = new Size(306, 25);
            lblAct3Title.TabIndex = 0;
            lblAct3Title.Text = "Vận động vừa phải (Khuyên dùng)";
            // 
            // pnlAct4
            // 
            pnlAct4.BackColor = Color.White;
            pnlAct4.BorderStyle = BorderStyle.FixedSingle;
            pnlAct4.Controls.Add(lblAct4Check);
            pnlAct4.Controls.Add(lblAct4Desc);
            pnlAct4.Controls.Add(lblAct4Mult);
            pnlAct4.Controls.Add(lblAct4Title);
            pnlAct4.Cursor = Cursors.Hand;
            pnlAct4.Location = new Point(25, 396);
            pnlAct4.Name = "pnlAct4";
            pnlAct4.Size = new Size(610, 80);
            pnlAct4.TabIndex = 6;
            // 
            // lblAct4Check
            // 
            lblAct4Check.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAct4Check.ForeColor = Color.FromArgb(34, 112, 68);
            lblAct4Check.Location = new Point(570, 25);
            lblAct4Check.Name = "lblAct4Check";
            lblAct4Check.Size = new Size(30, 30);
            lblAct4Check.TabIndex = 3;
            lblAct4Check.Text = "✓";
            lblAct4Check.TextAlign = ContentAlignment.MiddleCenter;
            lblAct4Check.Visible = false;
            // 
            // lblAct4Desc
            // 
            lblAct4Desc.Font = new Font("Segoe UI", 8.2F);
            lblAct4Desc.ForeColor = Color.FromArgb(120, 120, 115);
            lblAct4Desc.Location = new Point(18, 44);
            lblAct4Desc.Name = "lblAct4Desc";
            lblAct4Desc.Size = new Size(540, 22);
            lblAct4Desc.TabIndex = 2;
            lblAct4Desc.Text = "Tập gym nặng 6–7 buổi/tuần, chơi thể thao hàng ngày hoặc lao động thể lực";
            // 
            // lblAct4Mult
            // 
            lblAct4Mult.AutoSize = true;
            lblAct4Mult.BackColor = Color.FromArgb(240, 248, 240);
            lblAct4Mult.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblAct4Mult.ForeColor = Color.FromArgb(34, 112, 68);
            lblAct4Mult.Location = new Point(273, 18);
            lblAct4Mult.Name = "lblAct4Mult";
            lblAct4Mult.Padding = new Padding(4, 2, 4, 2);
            lblAct4Mult.Size = new Size(87, 21);
            lblAct4Mult.TabIndex = 1;
            lblAct4Mult.Text = "x1.725 BMR";
            // 
            // lblAct4Title
            // 
            lblAct4Title.AutoSize = true;
            lblAct4Title.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblAct4Title.ForeColor = Color.FromArgb(30, 40, 35);
            lblAct4Title.Location = new Point(18, 14);
            lblAct4Title.Name = "lblAct4Title";
            lblAct4Title.Size = new Size(255, 25);
            lblAct4Title.TabIndex = 0;
            lblAct4Title.Text = "Năng động và Cường độ cao";
            // 
            // ucSurveyStep4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(pnlAct4);
            Controls.Add(pnlAct3);
            Controls.Add(pnlAct2);
            Controls.Add(pnlAct1);
            Controls.Add(lblSub);
            Controls.Add(lblTitle);
            Controls.Add(lblBadge);
            Name = "ucSurveyStep4";
            Padding = new Padding(25);
            Size = new Size(650, 580);
            pnlAct1.ResumeLayout(false);
            pnlAct1.PerformLayout();
            pnlAct2.ResumeLayout(false);
            pnlAct2.PerformLayout();
            pnlAct3.ResumeLayout(false);
            pnlAct3.PerformLayout();
            pnlAct4.ResumeLayout(false);
            pnlAct4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBadge;
        private Label lblTitle;
        private Label lblSub;
        private Panel pnlAct1;
        private Label lblAct1Title;
        private Label lblAct1Mult;
        private Label lblAct1Desc;
        private Label lblAct1Check;
        private Panel pnlAct2;
        private Label lblAct2Title;
        private Label lblAct2Mult;
        private Label lblAct2Desc;
        private Label lblAct2Check;
        private Panel pnlAct3;
        private Label lblAct3Title;
        private Label lblAct3Mult;
        private Label lblAct3Desc;
        private Label lblAct3Check;
        private Panel pnlAct4;
        private Label lblAct4Title;
        private Label lblAct4Mult;
        private Label lblAct4Desc;
        private Label lblAct4Check;
    }
}
