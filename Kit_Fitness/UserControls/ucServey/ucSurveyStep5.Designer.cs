namespace Kit_Fitness.UserControls
{
    partial class ucSurveyStep5
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
            pnlCard = new Panel();
            lblSummary = new Label();
            pnlDivider = new Panel();
            pnlMacros = new Panel();
            pnlFat = new Panel();
            lblFatPercent = new Label();
            lblFatVal = new Label();
            lblFatTitle = new Label();
            pnlCarb = new Panel();
            lblCarbPercent = new Label();
            lblCarbVal = new Label();
            lblCarbTitle = new Label();
            pnlProtein = new Panel();
            lblProteinPercent = new Label();
            lblProteinVal = new Label();
            lblProteinTitle = new Label();
            lblDiff = new Label();
            pnlCalDisplay = new Panel();
            lblCalUnit = new Label();
            lblCalNum = new Label();
            lblCardHeader = new Label();
            pnlCard.SuspendLayout();
            pnlMacros.SuspendLayout();
            pnlFat.SuspendLayout();
            pnlCarb.SuspendLayout();
            pnlProtein.SuspendLayout();
            pnlCalDisplay.SuspendLayout();
            SuspendLayout();
            // 
            // lblBadge
            // 
            lblBadge.AutoSize = true;
            lblBadge.BackColor = Color.FromArgb(240, 250, 243);
            lblBadge.BorderStyle = BorderStyle.FixedSingle;
            lblBadge.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblBadge.ForeColor = Color.FromArgb(27, 94, 52);
            lblBadge.Location = new Point(25, 20);
            lblBadge.Name = "lblBadge";
            lblBadge.Padding = new Padding(8, 3, 8, 3);
            lblBadge.Size = new Size(222, 27);
            lblBadge.TabIndex = 0;
            lblBadge.Text = "✓  ĐÃ KIỂM ĐỊNH KHOA HỌC ";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 40, 35);
            lblTitle.Location = new Point(25, 52);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(580, 35);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Lộ Trình Calo Chuẩn Chợ Sáng";
            // 
            // lblSub
            // 
            lblSub.Font = new Font("Segoe UI", 8.8F);
            lblSub.ForeColor = Color.FromArgb(120, 120, 115);
            lblSub.Location = new Point(25, 90);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(610, 25);
            lblSub.TabIndex = 2;
            lblSub.Text = "Để hoàn thành mục tiêu: Giảm mỡ & Nhẹ người (Đích: 47 kg) với cường độ Vận động vừa phải.";
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.BorderStyle = BorderStyle.FixedSingle;
            pnlCard.Controls.Add(lblSummary);
            pnlCard.Controls.Add(pnlDivider);
            pnlCard.Controls.Add(pnlMacros);
            pnlCard.Controls.Add(lblDiff);
            pnlCard.Controls.Add(pnlCalDisplay);
            pnlCard.Controls.Add(lblCardHeader);
            pnlCard.Location = new Point(25, 125);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(610, 335);
            pnlCard.TabIndex = 3;
            // 
            // lblSummary
            // 
            lblSummary.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblSummary.ForeColor = Color.FromArgb(71, 85, 105);
            lblSummary.Location = new Point(0, 284);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(610, 24);
            lblSummary.TabIndex = 5;
            lblSummary.Text = "BMR Cơ Bản: 1219 kcal     •     TDEE Duy Trì: 1889 kcal     •     Nước Tối Thiểu: 1800 ml";
            lblSummary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlDivider
            // 
            pnlDivider.BackColor = Color.FromArgb(230, 225, 215);
            pnlDivider.Location = new Point(15, 264);
            pnlDivider.Name = "pnlDivider";
            pnlDivider.Size = new Size(580, 1);
            pnlDivider.TabIndex = 4;
            // 
            // pnlMacros
            // 
            pnlMacros.Controls.Add(pnlFat);
            pnlMacros.Controls.Add(pnlCarb);
            pnlMacros.Controls.Add(pnlProtein);
            pnlMacros.Location = new Point(15, 132);
            pnlMacros.Name = "pnlMacros";
            pnlMacros.Size = new Size(580, 115);
            pnlMacros.TabIndex = 3;
            // 
            // pnlFat
            // 
            pnlFat.BackColor = Color.FromArgb(252, 250, 245);
            pnlFat.BorderStyle = BorderStyle.FixedSingle;
            pnlFat.Controls.Add(lblFatPercent);
            pnlFat.Controls.Add(lblFatVal);
            pnlFat.Controls.Add(lblFatTitle);
            pnlFat.Location = new Point(396, 0);
            pnlFat.Name = "pnlFat";
            pnlFat.Padding = new Padding(10);
            pnlFat.Size = new Size(184, 115);
            pnlFat.TabIndex = 2;
            // 
            // lblFatPercent
            // 
            lblFatPercent.Font = new Font("Segoe UI", 7.8F);
            lblFatPercent.ForeColor = Color.FromArgb(140, 140, 135);
            lblFatPercent.Location = new Point(0, 74);
            lblFatPercent.Name = "lblFatPercent";
            lblFatPercent.Size = new Size(184, 18);
            lblFatPercent.TabIndex = 2;
            lblFatPercent.Text = "25% calo";
            lblFatPercent.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFatVal
            // 
            lblFatVal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFatVal.ForeColor = Color.FromArgb(31, 41, 55);
            lblFatVal.Location = new Point(0, 36);
            lblFatVal.Name = "lblFatVal";
            lblFatVal.Size = new Size(184, 36);
            lblFatVal.TabIndex = 1;
            lblFatVal.Text = "39g";
            lblFatVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFatTitle
            // 
            lblFatTitle.Font = new Font("Segoe UI Semibold", 7.6F, FontStyle.Bold);
            lblFatTitle.ForeColor = Color.FromArgb(120, 120, 115);
            lblFatTitle.Location = new Point(0, 15);
            lblFatTitle.Name = "lblFatTitle";
            lblFatTitle.Size = new Size(184, 18);
            lblFatTitle.TabIndex = 0;
            lblFatTitle.Text = "CHẤT BÉO (FAT)";
            lblFatTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCarb
            // 
            pnlCarb.BackColor = Color.FromArgb(252, 250, 245);
            pnlCarb.BorderStyle = BorderStyle.FixedSingle;
            pnlCarb.Controls.Add(lblCarbPercent);
            pnlCarb.Controls.Add(lblCarbVal);
            pnlCarb.Controls.Add(lblCarbTitle);
            pnlCarb.Location = new Point(198, 0);
            pnlCarb.Name = "pnlCarb";
            pnlCarb.Padding = new Padding(10);
            pnlCarb.Size = new Size(184, 115);
            pnlCarb.TabIndex = 1;
            // 
            // lblCarbPercent
            // 
            lblCarbPercent.Font = new Font("Segoe UI", 7.8F);
            lblCarbPercent.ForeColor = Color.FromArgb(140, 140, 135);
            lblCarbPercent.Location = new Point(0, 74);
            lblCarbPercent.Name = "lblCarbPercent";
            lblCarbPercent.Size = new Size(184, 18);
            lblCarbPercent.TabIndex = 2;
            lblCarbPercent.Text = "45% calo";
            lblCarbPercent.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCarbVal
            // 
            lblCarbVal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCarbVal.ForeColor = Color.FromArgb(217, 119, 6);
            lblCarbVal.Location = new Point(0, 36);
            lblCarbVal.Name = "lblCarbVal";
            lblCarbVal.Size = new Size(184, 36);
            lblCarbVal.TabIndex = 1;
            lblCarbVal.Text = "156g";
            lblCarbVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCarbTitle
            // 
            lblCarbTitle.Font = new Font("Segoe UI Semibold", 7.6F, FontStyle.Bold);
            lblCarbTitle.ForeColor = Color.FromArgb(120, 120, 115);
            lblCarbTitle.Location = new Point(0, 15);
            lblCarbTitle.Name = "lblCarbTitle";
            lblCarbTitle.Size = new Size(184, 18);
            lblCarbTitle.TabIndex = 0;
            lblCarbTitle.Text = "TINH BỘT (CARBS)";
            lblCarbTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlProtein
            // 
            pnlProtein.BackColor = Color.FromArgb(252, 250, 245);
            pnlProtein.BorderStyle = BorderStyle.FixedSingle;
            pnlProtein.Controls.Add(lblProteinPercent);
            pnlProtein.Controls.Add(lblProteinVal);
            pnlProtein.Controls.Add(lblProteinTitle);
            pnlProtein.Location = new Point(0, 0);
            pnlProtein.Name = "pnlProtein";
            pnlProtein.Padding = new Padding(10);
            pnlProtein.Size = new Size(184, 115);
            pnlProtein.TabIndex = 0;
            // 
            // lblProteinPercent
            // 
            lblProteinPercent.Font = new Font("Segoe UI", 7.8F);
            lblProteinPercent.ForeColor = Color.FromArgb(140, 140, 135);
            lblProteinPercent.Location = new Point(0, 74);
            lblProteinPercent.Name = "lblProteinPercent";
            lblProteinPercent.Size = new Size(184, 18);
            lblProteinPercent.TabIndex = 2;
            lblProteinPercent.Text = "30% calo";
            lblProteinPercent.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblProteinVal
            // 
            lblProteinVal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblProteinVal.ForeColor = Color.FromArgb(185, 28, 28);
            lblProteinVal.Location = new Point(0, 36);
            lblProteinVal.Name = "lblProteinVal";
            lblProteinVal.Size = new Size(184, 36);
            lblProteinVal.TabIndex = 1;
            lblProteinVal.Text = "104g";
            lblProteinVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblProteinTitle
            // 
            lblProteinTitle.Font = new Font("Segoe UI Semibold", 7.6F, FontStyle.Bold);
            lblProteinTitle.ForeColor = Color.FromArgb(120, 120, 115);
            lblProteinTitle.Location = new Point(0, 15);
            lblProteinTitle.Name = "lblProteinTitle";
            lblProteinTitle.Size = new Size(184, 18);
            lblProteinTitle.TabIndex = 0;
            lblProteinTitle.Text = "CHẤT ĐẠM (PROTEIN)";
            lblProteinTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDiff
            // 
            lblDiff.Font = new Font("Segoe UI", 8.8F);
            lblDiff.ForeColor = Color.FromArgb(100, 116, 139);
            lblDiff.Location = new Point(0, 102);
            lblDiff.Name = "lblDiff";
            lblDiff.Size = new Size(610, 22);
            lblDiff.TabIndex = 2;
            lblDiff.Text = "Thâm hụt 500 kcal/ngày so với mức duy trì (TDEE: 1889 kcal)";
            lblDiff.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCalDisplay
            // 
            pnlCalDisplay.Controls.Add(lblCalUnit);
            pnlCalDisplay.Controls.Add(lblCalNum);
            pnlCalDisplay.Location = new Point(0, 40);
            pnlCalDisplay.Name = "pnlCalDisplay";
            pnlCalDisplay.Size = new Size(610, 58);
            pnlCalDisplay.TabIndex = 1;
            // 
            // lblCalUnit
            // 
            lblCalUnit.AutoSize = true;
            lblCalUnit.Font = new Font("Segoe UI Semibold", 11F);
            lblCalUnit.ForeColor = Color.FromArgb(120, 120, 115);
            lblCalUnit.Location = new Point(345, 22);
            lblCalUnit.Name = "lblCalUnit";
            lblCalUnit.Size = new Size(106, 25);
            lblCalUnit.TabIndex = 1;
            lblCalUnit.Text = "kcal / ngày";
            // 
            // lblCalNum
            // 
            lblCalNum.AutoSize = true;
            lblCalNum.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblCalNum.ForeColor = Color.FromArgb(24, 59, 43);
            lblCalNum.Location = new Point(185, 0);
            lblCalNum.Name = "lblCalNum";
            lblCalNum.Size = new Size(154, 72);
            lblCalNum.TabIndex = 0;
            lblCalNum.Text = "1389";
            // 
            // lblCardHeader
            // 
            lblCardHeader.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblCardHeader.ForeColor = Color.FromArgb(100, 116, 139);
            lblCardHeader.Location = new Point(0, 18);
            lblCardHeader.Name = "lblCardHeader";
            lblCardHeader.Size = new Size(610, 18);
            lblCardHeader.TabIndex = 0;
            lblCardHeader.Text = "MỨC CALO MỤC TIÊU HẰNG NGÀY";
            lblCardHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucSurveyStep5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(pnlCard);
            Controls.Add(lblSub);
            Controls.Add(lblTitle);
            Controls.Add(lblBadge);
            Name = "ucSurveyStep5";
            Padding = new Padding(25);
            Size = new Size(650, 580);
            pnlCard.ResumeLayout(false);
            pnlMacros.ResumeLayout(false);
            pnlFat.ResumeLayout(false);
            pnlCarb.ResumeLayout(false);
            pnlProtein.ResumeLayout(false);
            pnlCalDisplay.ResumeLayout(false);
            pnlCalDisplay.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBadge;
        private Label lblTitle;
        private Label lblSub;
        private Panel pnlCard;
        private Label lblCardHeader;
        private Panel pnlCalDisplay;
        private Label lblCalNum;
        private Label lblCalUnit;
        private Label lblDiff;
        private Panel pnlMacros;
        private Panel pnlProtein;
        private Label lblProteinTitle;
        private Label lblProteinVal;
        private Label lblProteinPercent;
        private Panel pnlCarb;
        private Label lblCarbTitle;
        private Label lblCarbVal;
        private Label lblCarbPercent;
        private Panel pnlFat;
        private Label lblFatTitle;
        private Label lblFatVal;
        private Label lblFatPercent;
        private Panel pnlDivider;
        private Label lblSummary;
    }
}
