namespace Kit_Fitness.UserControls
{
    partial class ucMealItemRow
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
            pnlRow = new Panel();
            btnDelete = new Button();
            pnlTrafficLight = new Panel();
            cbUnit = new ComboBox();
            numCalories = new NumericUpDown();
            lblCaloriesTitle = new Label();
            numWeight = new NumericUpDown();
            cbFood = new ComboBox();
            lblUnit = new Label();
            lblNumber = new Label();
            pnlRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCalories).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWeight).BeginInit();
            SuspendLayout();
            // 
            // pnlRow
            // 
            pnlRow.BackColor = Color.White;
            pnlRow.BorderStyle = BorderStyle.FixedSingle;
            pnlRow.Controls.Add(btnDelete);
            pnlRow.Controls.Add(pnlTrafficLight);
            pnlRow.Controls.Add(cbUnit);
            pnlRow.Controls.Add(numCalories);
            pnlRow.Controls.Add(lblCaloriesTitle);
            pnlRow.Controls.Add(numWeight);
            pnlRow.Controls.Add(cbFood);
            pnlRow.Controls.Add(lblUnit);
            pnlRow.Controls.Add(lblNumber);
            pnlRow.Dock = DockStyle.Fill;
            pnlRow.Location = new Point(0, 0);
            pnlRow.Name = "pnlRow";
            pnlRow.Padding = new Padding(6);
            pnlRow.Size = new Size(480, 78);
            pnlRow.TabIndex = 0;
            pnlRow.Paint += pnlRow_Paint;
            // 
            // btnDelete
            // 
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F);
            btnDelete.ForeColor = Color.FromArgb(180, 80, 80);
            btnDelete.Location = new Point(384, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(32, 32);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "🗑";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // pnlTrafficLight
            // 
            pnlTrafficLight.BackColor = Color.FromArgb(232, 245, 233);
            pnlTrafficLight.Cursor = Cursors.Hand;
            pnlTrafficLight.Location = new Point(292, 42);
            pnlTrafficLight.Name = "pnlTrafficLight";
            pnlTrafficLight.Size = new Size(88, 28);
            pnlTrafficLight.TabIndex = 7;
            pnlTrafficLight.Paint += pnlTrafficLight_Paint;
            // 
            // cbUnit
            // 
            cbUnit.DropDownWidth = 90;
            cbUnit.Font = new Font("Segoe UI", 8.5F);
            cbUnit.Items.AddRange(new object[] { "g", "ml", "cái", "quả", "bát", "tô", "đĩa", "phần" });
            cbUnit.Location = new Point(274, 12);
            cbUnit.Name = "cbUnit";
            cbUnit.Size = new Size(62, 27);
            cbUnit.TabIndex = 3;
            cbUnit.Text = "g";
            // 
            // numCalories
            // 
            numCalories.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            numCalories.Location = new Point(105, 43);
            numCalories.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numCalories.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCalories.Name = "numCalories";
            numCalories.Size = new Size(72, 26);
            numCalories.TabIndex = 5;
            numCalories.TextAlign = HorizontalAlignment.Right;
            numCalories.ThousandsSeparator = true;
            numCalories.Value = new decimal(new int[] { 150, 0, 0, 0 });
            // 
            // lblCaloriesTitle
            // 
            lblCaloriesTitle.AutoSize = true;
            lblCaloriesTitle.Font = new Font("Segoe UI", 8F);
            lblCaloriesTitle.ForeColor = Color.FromArgb(120, 120, 115);
            lblCaloriesTitle.Location = new Point(34, 47);
            lblCaloriesTitle.Name = "lblCaloriesTitle";
            lblCaloriesTitle.Size = new Size(76, 19);
            lblCaloriesTitle.TabIndex = 4;
            lblCaloriesTitle.Text = "Calo/100g:";
            // 
            // numWeight
            // 
            numWeight.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            numWeight.Location = new Point(214, 12);
            numWeight.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numWeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numWeight.Name = "numWeight";
            numWeight.Size = new Size(55, 29);
            numWeight.TabIndex = 2;
            numWeight.TextAlign = HorizontalAlignment.Right;
            numWeight.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // cbFood
            // 
            cbFood.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbFood.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbFood.DisplayMember = "Name";
            cbFood.Font = new Font("Segoe UI", 9.5F);
            cbFood.Location = new Point(34, 12);
            cbFood.MaxDropDownItems = 10;
            cbFood.Name = "cbFood";
            cbFood.Size = new Size(175, 29);
            cbFood.TabIndex = 1;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUnit.ForeColor = Color.FromArgb(120, 120, 115);
            lblUnit.Location = new Point(272, 16);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(18, 20);
            lblUnit.TabIndex = 6;
            lblUnit.Text = "g";
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNumber.ForeColor = Color.FromArgb(120, 120, 115);
            lblNumber.Location = new Point(6, 16);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(28, 21);
            lblNumber.TabIndex = 0;
            lblNumber.Text = "#1";
            // 
            // ucMealItemRow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlRow);
            Name = "ucMealItemRow";
            Size = new Size(480, 78);
            pnlRow.ResumeLayout(false);
            pnlRow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCalories).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWeight).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRow;
        private Label lblNumber;
        private ComboBox cbFood;
        private NumericUpDown numWeight;
        private ComboBox cbUnit;
        private Label lblCaloriesTitle;
        private NumericUpDown numCalories;
        private Label lblUnit;
        private Panel pnlTrafficLight;
        private Button btnDelete;
    }
}
