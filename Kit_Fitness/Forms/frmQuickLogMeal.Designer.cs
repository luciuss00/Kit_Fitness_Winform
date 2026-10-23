namespace Kit_Fitness.Forms
{
    partial class frmQuickLogMeal
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlBody = new Panel();
            panel1 = new Panel();
            btnSaveMeal = new Button();
            pnlNutritionCard = new Panel();
            lblMealStatus = new Label();
            lblFat = new Label();
            lblCarbs = new Label();
            lblProtein = new Label();
            lblCalories = new Label();
            lblNutritionHeader = new Label();
            btnAddItem = new Button();
            pnlItemsList = new Panel();
            pnlTimeBar = new Panel();
            cbMealType = new ComboBox();
            cbTimeSlot = new ComboBox();
            lblTimeSlotTitle = new Label();
            lblNote = new Label();
            pnlBody.SuspendLayout();
            panel1.SuspendLayout();
            pnlNutritionCard.SuspendLayout();
            pnlTimeBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBody
            // 
            pnlBody.AutoScroll = true;
            pnlBody.BackColor = Color.FromArgb(250, 247, 240);
            pnlBody.Controls.Add(panel1);
            pnlBody.Controls.Add(btnSaveMeal);
            pnlBody.Controls.Add(pnlNutritionCard);
            pnlBody.Controls.Add(btnAddItem);
            pnlBody.Controls.Add(pnlItemsList);
            pnlBody.Controls.Add(pnlTimeBar);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 0);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(20, 10, 20, 20);
            pnlBody.Size = new Size(520, 574);
            pnlBody.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblNote);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(20, 528);
            panel1.Name = "panel1";
            panel1.Size = new Size(480, 26);
            panel1.TabIndex = 6;
            // 
            // btnSaveMeal
            // 
            btnSaveMeal.BackColor = Color.FromArgb(41, 75, 54);
            btnSaveMeal.Cursor = Cursors.Hand;
            btnSaveMeal.Dock = DockStyle.Top;
            btnSaveMeal.FlatAppearance.BorderSize = 0;
            btnSaveMeal.FlatStyle = FlatStyle.Flat;
            btnSaveMeal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSaveMeal.ForeColor = Color.White;
            btnSaveMeal.Location = new Point(20, 212);
            btnSaveMeal.Margin = new Padding(0, 15, 0, 0);
            btnSaveMeal.Name = "btnSaveMeal";
            btnSaveMeal.Size = new Size(480, 52);
            btnSaveMeal.TabIndex = 4;
            btnSaveMeal.Text = "✓ Lưu Bữa Ăn Vào Nhật Ký";
            btnSaveMeal.UseVisualStyleBackColor = false;
            btnSaveMeal.Click += BtnSaveMeal_Click;
            // 
            // pnlNutritionCard
            // 
            pnlNutritionCard.BackColor = Color.FromArgb(244, 240, 232);
            pnlNutritionCard.Controls.Add(lblMealStatus);
            pnlNutritionCard.Controls.Add(lblFat);
            pnlNutritionCard.Controls.Add(lblCarbs);
            pnlNutritionCard.Controls.Add(lblProtein);
            pnlNutritionCard.Controls.Add(lblCalories);
            pnlNutritionCard.Controls.Add(lblNutritionHeader);
            pnlNutritionCard.Dock = DockStyle.Top;
            pnlNutritionCard.Location = new Point(20, 117);
            pnlNutritionCard.Margin = new Padding(0, 15, 0, 15);
            pnlNutritionCard.Name = "pnlNutritionCard";
            pnlNutritionCard.Padding = new Padding(15);
            pnlNutritionCard.Size = new Size(480, 95);
            pnlNutritionCard.TabIndex = 3;
            // 
            // lblMealStatus
            // 
            lblMealStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblMealStatus.AutoSize = true;
            lblMealStatus.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            lblMealStatus.ForeColor = Color.FromArgb(46, 125, 50);
            lblMealStatus.Location = new Point(275, 12);
            lblMealStatus.Name = "lblMealStatus";
            lblMealStatus.Size = new Size(178, 17);
            lblMealStatus.TabIndex = 5;
            lblMealStatus.Text = "\U0001f7e2 TƯƠI LÀNH & CÂN BẰNG";
            // 
            // lblFat
            // 
            lblFat.AutoSize = true;
            lblFat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFat.ForeColor = Color.FromArgb(60, 70, 80);
            lblFat.Location = new Point(340, 48);
            lblFat.Name = "lblFat";
            lblFat.Size = new Size(62, 20);
            lblFat.TabIndex = 4;
            lblFat.Text = "Béo: 0g";
            // 
            // lblCarbs
            // 
            lblCarbs.AutoSize = true;
            lblCarbs.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCarbs.ForeColor = Color.FromArgb(200, 130, 30);
            lblCarbs.Location = new Point(250, 48);
            lblCarbs.Name = "lblCarbs";
            lblCarbs.Size = new Size(83, 20);
            lblCarbs.TabIndex = 3;
            lblCarbs.Text = "Đường: 0g";
            // 
            // lblProtein
            // 
            lblProtein.AutoSize = true;
            lblProtein.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProtein.ForeColor = Color.FromArgb(180, 60, 40);
            lblProtein.Location = new Point(170, 48);
            lblProtein.Name = "lblProtein";
            lblProtein.Size = new Size(68, 20);
            lblProtein.TabIndex = 2;
            lblProtein.Text = "Đạm: 0g";
            // 
            // lblCalories
            // 
            lblCalories.AutoSize = true;
            lblCalories.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCalories.ForeColor = Color.FromArgb(34, 76, 56);
            lblCalories.Location = new Point(15, 38);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(94, 37);
            lblCalories.TabIndex = 1;
            lblCalories.Text = "0 Kcal";
            // 
            // lblNutritionHeader
            // 
            lblNutritionHeader.AutoSize = true;
            lblNutritionHeader.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            lblNutritionHeader.ForeColor = Color.FromArgb(130, 125, 120);
            lblNutritionHeader.Location = new Point(15, 12);
            lblNutritionHeader.Name = "lblNutritionHeader";
            lblNutritionHeader.Size = new Size(163, 17);
            lblNutritionHeader.TabIndex = 0;
            lblNutritionHeader.Text = "ƯỚC TÍNH DINH DƯỠNG";
            // 
            // btnAddItem
            // 
            btnAddItem.BackColor = Color.FromArgb(245, 243, 238);
            btnAddItem.Cursor = Cursors.Hand;
            btnAddItem.Dock = DockStyle.Top;
            btnAddItem.FlatAppearance.BorderColor = Color.FromArgb(190, 185, 170);
            btnAddItem.FlatStyle = FlatStyle.Flat;
            btnAddItem.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnAddItem.ForeColor = Color.FromArgb(41, 75, 54);
            btnAddItem.Location = new Point(20, 75);
            btnAddItem.Margin = new Padding(0, 10, 0, 10);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(480, 42);
            btnAddItem.TabIndex = 2;
            btnAddItem.Text = "+ Thêm món khác vào mâm này";
            btnAddItem.UseVisualStyleBackColor = false;
            btnAddItem.Click += BtnAddItem_Click;
            // 
            // pnlItemsList
            // 
            pnlItemsList.AutoSize = true;
            pnlItemsList.Dock = DockStyle.Top;
            pnlItemsList.Location = new Point(20, 55);
            pnlItemsList.Name = "pnlItemsList";
            pnlItemsList.Padding = new Padding(0, 10, 0, 10);
            pnlItemsList.Size = new Size(480, 20);
            pnlItemsList.TabIndex = 1;
            // 
            // pnlTimeBar
            // 
            pnlTimeBar.Controls.Add(cbMealType);
            pnlTimeBar.Controls.Add(cbTimeSlot);
            pnlTimeBar.Controls.Add(lblTimeSlotTitle);
            pnlTimeBar.Dock = DockStyle.Top;
            pnlTimeBar.Location = new Point(20, 10);
            pnlTimeBar.Name = "pnlTimeBar";
            pnlTimeBar.Size = new Size(480, 45);
            pnlTimeBar.TabIndex = 0;
            // 
            // cbMealType
            // 
            cbMealType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbMealType.BackColor = Color.FromArgb(232, 245, 233);
            cbMealType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMealType.FlatStyle = FlatStyle.Flat;
            cbMealType.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            cbMealType.ForeColor = Color.FromArgb(34, 112, 68);
            cbMealType.FormattingEnabled = true;
            cbMealType.Items.AddRange(new object[] { "Bữa Sáng", "Bữa Sáng Sớm", "Cà Phê & Ăn Nhẹ", "Bữa Phụ", "Bữa Phụ Sáng", "Bữa Trưa", "Bữa Phụ Chiều", "Năng Lượng Trước Tập", "Bữa Tối", "Ăn Nhẹ" });
            cbMealType.Location = new Point(300, 8);
            cbMealType.Name = "cbMealType";
            cbMealType.Size = new Size(175, 28);
            cbMealType.TabIndex = 2;
            // 
            // cbTimeSlot
            // 
            cbTimeSlot.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTimeSlot.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            cbTimeSlot.FormattingEnabled = true;
            cbTimeSlot.Items.AddRange(new object[] { "07:00", "08:30", "10:00", "12:00", "14:30", "16:30", "19:00", "21:00" });
            cbTimeSlot.Location = new Point(166, 8);
            cbTimeSlot.Name = "cbTimeSlot";
            cbTimeSlot.Size = new Size(111, 29);
            cbTimeSlot.TabIndex = 1;
            // 
            // lblTimeSlotTitle
            // 
            lblTimeSlotTitle.AutoSize = true;
            lblTimeSlotTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTimeSlotTitle.ForeColor = Color.FromArgb(100, 100, 95);
            lblTimeSlotTitle.Location = new Point(0, 12);
            lblTimeSlotTitle.Name = "lblTimeSlotTitle";
            lblTimeSlotTitle.Size = new Size(166, 21);
            lblTimeSlotTitle.TabIndex = 0;
            lblTimeSlotTitle.Text = "MÂM CƠM TẠI MỐC:";
            // 
            // lblNote
            // 
            lblNote.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblNote.Location = new Point(-8, 3);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(496, 21);
            lblNote.TabIndex = 6;
            lblNote.Text = "* Nếu món ăn không có trong hệ thống hãy tự nhập đơn vị và số Calo/100g thức ăn";
            // 
            // frmQuickLogMeal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 247, 240);
            ClientSize = new Size(520, 574);
            Controls.Add(pnlBody);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmQuickLogMeal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nhập Nhanh Món Ăn";
            Load += frmQuickLogMeal_Load;
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            panel1.ResumeLayout(false);
            pnlNutritionCard.ResumeLayout(false);
            pnlNutritionCard.PerformLayout();
            pnlTimeBar.ResumeLayout(false);
            pnlTimeBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlTimeBar;
        private System.Windows.Forms.Label lblTimeSlotTitle;
        private System.Windows.Forms.ComboBox cbTimeSlot;
        private System.Windows.Forms.ComboBox cbMealType;
        private System.Windows.Forms.Panel pnlItemsList;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Panel pnlNutritionCard;
        private System.Windows.Forms.Label lblNutritionHeader;
        private System.Windows.Forms.Label lblCalories;
        private System.Windows.Forms.Label lblMealStatus;
        private System.Windows.Forms.Label lblProtein;
        private System.Windows.Forms.Label lblCarbs;
        private System.Windows.Forms.Label lblFat;
        private System.Windows.Forms.Button btnSaveMeal;
        private Panel panel1;
        private Label lblNote;
    }
}
