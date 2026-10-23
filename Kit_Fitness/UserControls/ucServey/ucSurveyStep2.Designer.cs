namespace Kit_Fitness.UserControls
{
    partial class ucSurveyStep2
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
            pnlHeight = new Panel();
            btnH180 = new Button();
            btnH175 = new Button();
            btnH170 = new Button();
            btnH165 = new Button();
            btnH160 = new Button();
            btnH155 = new Button();
            btnH150 = new Button();
            trackH = new TrackBar();
            btnPlusH = new Button();
            lblHeightVal = new Label();
            btnMinusH = new Button();
            lblHeightTitle = new Label();
            pnlWeight = new Panel();
            trackW = new TrackBar();
            btnPlusW = new Button();
            lblWeightVal = new Label();
            btnMinusW = new Button();
            lblWeightTitle = new Label();
            pnlHeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackH).BeginInit();
            pnlWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackW).BeginInit();
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
            lblBadge.Size = new Size(192, 23);
            lblBadge.TabIndex = 0;
            lblBadge.Text = "🌱 Bước 2: Chỉ số hình thể";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 40, 35);
            lblTitle.Location = new Point(25, 48);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(580, 35);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Chiều cao và Cân nặng hiện tại";
            // 
            // lblSub
            // 
            lblSub.Font = new Font("Segoe UI", 8.8F);
            lblSub.ForeColor = Color.FromArgb(120, 120, 115);
            lblSub.Location = new Point(25, 85);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(600, 30);
            lblSub.TabIndex = 2;
            lblSub.Text = "Cùng xem chỉ số khối cơ thể (BMI) của bạn đang ở mức nào nhé!";
            // 
            // pnlHeight
            // 
            pnlHeight.BackColor = Color.FromArgb(252, 250, 245);
            pnlHeight.Controls.Add(btnH180);
            pnlHeight.Controls.Add(btnH175);
            pnlHeight.Controls.Add(btnH170);
            pnlHeight.Controls.Add(btnH165);
            pnlHeight.Controls.Add(btnH160);
            pnlHeight.Controls.Add(btnH155);
            pnlHeight.Controls.Add(btnH150);
            pnlHeight.Controls.Add(trackH);
            pnlHeight.Controls.Add(btnPlusH);
            pnlHeight.Controls.Add(lblHeightVal);
            pnlHeight.Controls.Add(btnMinusH);
            pnlHeight.Controls.Add(lblHeightTitle);
            pnlHeight.Location = new Point(25, 125);
            pnlHeight.Name = "pnlHeight";
            pnlHeight.Padding = new Padding(15);
            pnlHeight.Size = new Size(610, 160);
            pnlHeight.TabIndex = 3;
            // 
            // btnH180
            // 
            btnH180.BackColor = Color.White;
            btnH180.Cursor = Cursors.Hand;
            btnH180.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnH180.FlatStyle = FlatStyle.Flat;
            btnH180.Font = new Font("Segoe UI Semibold", 8F);
            btnH180.ForeColor = Color.FromArgb(60, 70, 65);
            btnH180.Location = new Point(507, 105);
            btnH180.Name = "btnH180";
            btnH180.Size = new Size(74, 34);
            btnH180.TabIndex = 11;
            btnH180.Text = "180 cm";
            btnH180.UseVisualStyleBackColor = false;
            // 
            // btnH175
            // 
            btnH175.BackColor = Color.White;
            btnH175.Cursor = Cursors.Hand;
            btnH175.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnH175.FlatStyle = FlatStyle.Flat;
            btnH175.Font = new Font("Segoe UI Semibold", 8F);
            btnH175.ForeColor = Color.FromArgb(60, 70, 65);
            btnH175.Location = new Point(425, 105);
            btnH175.Name = "btnH175";
            btnH175.Size = new Size(74, 34);
            btnH175.TabIndex = 10;
            btnH175.Text = "175 cm";
            btnH175.UseVisualStyleBackColor = false;
            // 
            // btnH170
            // 
            btnH170.BackColor = Color.White;
            btnH170.Cursor = Cursors.Hand;
            btnH170.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnH170.FlatStyle = FlatStyle.Flat;
            btnH170.Font = new Font("Segoe UI Semibold", 8F);
            btnH170.ForeColor = Color.FromArgb(60, 70, 65);
            btnH170.Location = new Point(343, 105);
            btnH170.Name = "btnH170";
            btnH170.Size = new Size(74, 34);
            btnH170.TabIndex = 9;
            btnH170.Text = "170 cm";
            btnH170.UseVisualStyleBackColor = false;
            // 
            // btnH165
            // 
            btnH165.BackColor = Color.White;
            btnH165.Cursor = Cursors.Hand;
            btnH165.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnH165.FlatStyle = FlatStyle.Flat;
            btnH165.Font = new Font("Segoe UI Semibold", 8F);
            btnH165.ForeColor = Color.FromArgb(60, 70, 65);
            btnH165.Location = new Point(261, 105);
            btnH165.Name = "btnH165";
            btnH165.Size = new Size(74, 34);
            btnH165.TabIndex = 8;
            btnH165.Text = "165 cm";
            btnH165.UseVisualStyleBackColor = false;
            // 
            // btnH160
            // 
            btnH160.BackColor = Color.FromArgb(34, 76, 56);
            btnH160.Cursor = Cursors.Hand;
            btnH160.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnH160.FlatStyle = FlatStyle.Flat;
            btnH160.Font = new Font("Segoe UI Semibold", 8F);
            btnH160.ForeColor = Color.White;
            btnH160.Location = new Point(179, 105);
            btnH160.Name = "btnH160";
            btnH160.Size = new Size(74, 34);
            btnH160.TabIndex = 7;
            btnH160.Text = "160 cm";
            btnH160.UseVisualStyleBackColor = false;
            // 
            // btnH155
            // 
            btnH155.BackColor = Color.White;
            btnH155.Cursor = Cursors.Hand;
            btnH155.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnH155.FlatStyle = FlatStyle.Flat;
            btnH155.Font = new Font("Segoe UI Semibold", 8F);
            btnH155.ForeColor = Color.FromArgb(60, 70, 65);
            btnH155.Location = new Point(97, 105);
            btnH155.Name = "btnH155";
            btnH155.Size = new Size(74, 34);
            btnH155.TabIndex = 6;
            btnH155.Text = "155 cm";
            btnH155.UseVisualStyleBackColor = false;
            // 
            // btnH150
            // 
            btnH150.BackColor = Color.White;
            btnH150.Cursor = Cursors.Hand;
            btnH150.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnH150.FlatStyle = FlatStyle.Flat;
            btnH150.Font = new Font("Segoe UI Semibold", 8F);
            btnH150.ForeColor = Color.FromArgb(60, 70, 65);
            btnH150.Location = new Point(15, 105);
            btnH150.Name = "btnH150";
            btnH150.Size = new Size(74, 34);
            btnH150.TabIndex = 5;
            btnH150.Text = "150 cm";
            btnH150.UseVisualStyleBackColor = false;
            // 
            // trackH
            // 
            trackH.Location = new Point(15, 52);
            trackH.Maximum = 210;
            trackH.Minimum = 120;
            trackH.Name = "trackH";
            trackH.Size = new Size(575, 56);
            trackH.TabIndex = 4;
            trackH.TickStyle = TickStyle.None;
            trackH.Value = 160;
            // 
            // btnPlusH
            // 
            btnPlusH.BackColor = Color.White;
            btnPlusH.Cursor = Cursors.Hand;
            btnPlusH.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnPlusH.FlatStyle = FlatStyle.Flat;
            btnPlusH.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPlusH.Location = new Point(555, 12);
            btnPlusH.Name = "btnPlusH";
            btnPlusH.Size = new Size(38, 32);
            btnPlusH.TabIndex = 3;
            btnPlusH.Text = "+";
            btnPlusH.UseVisualStyleBackColor = false;
            // 
            // lblHeightVal
            // 
            lblHeightVal.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblHeightVal.ForeColor = Color.FromArgb(30, 40, 35);
            lblHeightVal.Location = new Point(480, 12);
            lblHeightVal.Name = "lblHeightVal";
            lblHeightVal.Size = new Size(70, 30);
            lblHeightVal.TabIndex = 2;
            lblHeightVal.Text = "160 cm";
            lblHeightVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnMinusH
            // 
            btnMinusH.BackColor = Color.White;
            btnMinusH.Cursor = Cursors.Hand;
            btnMinusH.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnMinusH.FlatStyle = FlatStyle.Flat;
            btnMinusH.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMinusH.Location = new Point(435, 12);
            btnMinusH.Name = "btnMinusH";
            btnMinusH.Size = new Size(38, 32);
            btnMinusH.TabIndex = 1;
            btnMinusH.Text = "—";
            btnMinusH.UseVisualStyleBackColor = false;
            // 
            // lblHeightTitle
            // 
            lblHeightTitle.AutoSize = true;
            lblHeightTitle.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblHeightTitle.ForeColor = Color.FromArgb(100, 100, 95);
            lblHeightTitle.Location = new Point(15, 18);
            lblHeightTitle.Name = "lblHeightTitle";
            lblHeightTitle.Size = new Size(155, 20);
            lblHeightTitle.TabIndex = 0;
            lblHeightTitle.Text = "CHIỀU CAO CỦA BẠN";
            // 
            // pnlWeight
            // 
            pnlWeight.BackColor = Color.FromArgb(252, 250, 245);
            pnlWeight.Controls.Add(trackW);
            pnlWeight.Controls.Add(btnPlusW);
            pnlWeight.Controls.Add(lblWeightVal);
            pnlWeight.Controls.Add(btnMinusW);
            pnlWeight.Controls.Add(lblWeightTitle);
            pnlWeight.Location = new Point(25, 305);
            pnlWeight.Name = "pnlWeight";
            pnlWeight.Padding = new Padding(15);
            pnlWeight.Size = new Size(610, 120);
            pnlWeight.TabIndex = 4;
            // 
            // trackW
            // 
            trackW.Location = new Point(15, 55);
            trackW.Maximum = 140;
            trackW.Minimum = 35;
            trackW.Name = "trackW";
            trackW.Size = new Size(575, 56);
            trackW.TabIndex = 4;
            trackW.TickStyle = TickStyle.None;
            trackW.Value = 50;
            // 
            // btnPlusW
            // 
            btnPlusW.BackColor = Color.White;
            btnPlusW.Cursor = Cursors.Hand;
            btnPlusW.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnPlusW.FlatStyle = FlatStyle.Flat;
            btnPlusW.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPlusW.Location = new Point(555, 12);
            btnPlusW.Name = "btnPlusW";
            btnPlusW.Size = new Size(38, 32);
            btnPlusW.TabIndex = 3;
            btnPlusW.Text = "+";
            btnPlusW.UseVisualStyleBackColor = false;
            // 
            // lblWeightVal
            // 
            lblWeightVal.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblWeightVal.ForeColor = Color.FromArgb(30, 40, 35);
            lblWeightVal.Location = new Point(480, 12);
            lblWeightVal.Name = "lblWeightVal";
            lblWeightVal.Size = new Size(70, 30);
            lblWeightVal.TabIndex = 2;
            lblWeightVal.Text = "50 kg";
            lblWeightVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnMinusW
            // 
            btnMinusW.BackColor = Color.White;
            btnMinusW.Cursor = Cursors.Hand;
            btnMinusW.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnMinusW.FlatStyle = FlatStyle.Flat;
            btnMinusW.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMinusW.Location = new Point(435, 12);
            btnMinusW.Name = "btnMinusW";
            btnMinusW.Size = new Size(38, 32);
            btnMinusW.TabIndex = 1;
            btnMinusW.Text = "—";
            btnMinusW.UseVisualStyleBackColor = false;
            // 
            // lblWeightTitle
            // 
            lblWeightTitle.AutoSize = true;
            lblWeightTitle.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblWeightTitle.ForeColor = Color.FromArgb(100, 100, 95);
            lblWeightTitle.Location = new Point(15, 18);
            lblWeightTitle.Name = "lblWeightTitle";
            lblWeightTitle.Size = new Size(153, 20);
            lblWeightTitle.TabIndex = 0;
            lblWeightTitle.Text = "CÂN NẶNG HIỆN TẠI";
            // 
            // ucSurveyStep2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(pnlWeight);
            Controls.Add(pnlHeight);
            Controls.Add(lblSub);
            Controls.Add(lblTitle);
            Controls.Add(lblBadge);
            Name = "ucSurveyStep2";
            Padding = new Padding(25);
            Size = new Size(650, 580);
            pnlHeight.ResumeLayout(false);
            pnlHeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackH).EndInit();
            pnlWeight.ResumeLayout(false);
            pnlWeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackW).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBadge;
        private Label lblTitle;
        private Label lblSub;
        private Panel pnlHeight;
        private Label lblHeightTitle;
        private Button btnMinusH;
        private Label lblHeightVal;
        private Button btnPlusH;
        private TrackBar trackH;
        private Button btnH150;
        private Button btnH155;
        private Button btnH160;
        private Button btnH165;
        private Button btnH170;
        private Button btnH175;
        private Button btnH180;
        private Panel pnlWeight;
        private Label lblWeightTitle;
        private Button btnMinusW;
        private Label lblWeightVal;
        private Button btnPlusW;
        private TrackBar trackW;
    }
}
