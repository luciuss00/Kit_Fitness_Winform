namespace Kit_Fitness.Forms
{
    partial class frmAddFridgeItem
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
            btnCancel = new Button();
            btnSave = new Button();
            dtpExpiry = new DateTimePicker();
            lblExpiry = new Label();
            rbFreezer = new RadioButton();
            rbChill = new RadioButton();
            lblStorage = new Label();
            cbUnit = new ComboBox();
            lblUnit = new Label();
            numQuantity = new NumericUpDown();
            lblQuantity = new Label();
            cbFood = new ComboBox();
            lblFood = new Label();
            pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // pnlBody
            // 
            pnlBody.BackColor = Color.White;
            pnlBody.Controls.Add(btnCancel);
            pnlBody.Controls.Add(btnSave);
            pnlBody.Controls.Add(dtpExpiry);
            pnlBody.Controls.Add(lblExpiry);
            pnlBody.Controls.Add(rbFreezer);
            pnlBody.Controls.Add(rbChill);
            pnlBody.Controls.Add(lblStorage);
            pnlBody.Controls.Add(cbUnit);
            pnlBody.Controls.Add(lblUnit);
            pnlBody.Controls.Add(numQuantity);
            pnlBody.Controls.Add(lblQuantity);
            pnlBody.Controls.Add(cbFood);
            pnlBody.Controls.Add(lblFood);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 0);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(20);
            pnlBody.Size = new Size(420, 375);
            pnlBody.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(240, 238, 232);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.FromArgb(80, 80, 80);
            btnCancel.Location = new Point(20, 298);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 42);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(41, 75, 54);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(220, 298);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 42);
            btnSave.TabIndex = 11;
            btnSave.Text = "✓ Cất Vào Tủ";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // dtpExpiry
            // 
            dtpExpiry.Font = new Font("Segoe UI", 10F);
            dtpExpiry.Format = DateTimePickerFormat.Short;
            dtpExpiry.Location = new Point(20, 245);
            dtpExpiry.Name = "dtpExpiry";
            dtpExpiry.Size = new Size(380, 30);
            dtpExpiry.TabIndex = 10;
            // 
            // lblExpiry
            // 
            lblExpiry.AutoSize = true;
            lblExpiry.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblExpiry.ForeColor = Color.FromArgb(80, 80, 80);
            lblExpiry.Location = new Point(20, 220);
            lblExpiry.Name = "lblExpiry";
            lblExpiry.Size = new Size(105, 21);
            lblExpiry.TabIndex = 9;
            lblExpiry.Text = "Hạn Sử Dụng";
            // 
            // rbFreezer
            // 
            rbFreezer.AutoSize = true;
            rbFreezer.Font = new Font("Segoe UI", 9.5F);
            rbFreezer.Location = new Point(220, 182);
            rbFreezer.Name = "rbFreezer";
            rbFreezer.Size = new Size(167, 25);
            rbFreezer.TabIndex = 8;
            rbFreezer.Text = "Ngăn Đá (FREEZER)";
            rbFreezer.UseVisualStyleBackColor = true;
            // 
            // rbChill
            // 
            rbChill.AutoSize = true;
            rbChill.Checked = true;
            rbChill.Font = new Font("Segoe UI", 9.5F);
            rbChill.Location = new Point(25, 182);
            rbChill.Name = "rbChill";
            rbChill.Size = new Size(155, 25);
            rbChill.TabIndex = 7;
            rbChill.TabStop = true;
            rbChill.Text = "Ngăn Mát (CHILL)";
            rbChill.UseVisualStyleBackColor = true;
            // 
            // lblStorage
            // 
            lblStorage.AutoSize = true;
            lblStorage.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblStorage.ForeColor = Color.FromArgb(80, 80, 80);
            lblStorage.Location = new Point(20, 155);
            lblStorage.Name = "lblStorage";
            lblStorage.Size = new Size(120, 21);
            lblStorage.TabIndex = 6;
            lblStorage.Text = "Vị Trí Bảo Quản";
            // 
            // cbUnit
            // 
            cbUnit.Font = new Font("Segoe UI", 10F);
            cbUnit.FormattingEnabled = true;
            cbUnit.Items.AddRange(new object[] { "g", "kg", "bó", "quả", "hộp", "miếng", "gói" });
            cbUnit.Location = new Point(220, 110);
            cbUnit.Name = "cbUnit";
            cbUnit.Size = new Size(180, 31);
            cbUnit.TabIndex = 5;
            cbUnit.Text = "g";
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblUnit.ForeColor = Color.FromArgb(80, 80, 80);
            lblUnit.Location = new Point(220, 85);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(58, 21);
            lblUnit.TabIndex = 4;
            lblUnit.Text = "Đơn Vị";
            // 
            // numQuantity
            // 
            numQuantity.DecimalPlaces = 1;
            numQuantity.Font = new Font("Segoe UI", 10F);
            numQuantity.Location = new Point(20, 110);
            numQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(175, 30);
            numQuantity.TabIndex = 3;
            numQuantity.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblQuantity.ForeColor = Color.FromArgb(80, 80, 80);
            lblQuantity.Location = new Point(20, 85);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(80, 21);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "Số Lượng";
            // 
            // cbFood
            // 
            cbFood.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbFood.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbFood.DropDownStyle = ComboBoxStyle.DropDown;
            cbFood.Font = new Font("Segoe UI", 10F);
            cbFood.FormattingEnabled = true;
            cbFood.Location = new Point(20, 40);
            cbFood.MaxDropDownItems = 7;
            cbFood.Name = "cbFood";
            cbFood.Size = new Size(380, 31);
            cbFood.TabIndex = 1;
            // 
            // lblFood
            // 
            lblFood.AutoSize = true;
            lblFood.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblFood.ForeColor = Color.FromArgb(80, 80, 80);
            lblFood.Location = new Point(20, 15);
            lblFood.Name = "lblFood";
            lblFood.Size = new Size(132, 21);
            lblFood.TabIndex = 0;
            lblFood.Text = "Chọn hoặc nhập thực phẩm";
            // 
            // frmAddFridgeItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 375);
            Controls.Add(pnlBody);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddFridgeItem";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cất Thực Phẩm Vào Tủ Lạnh";
            Load += frmAddFridgeItem_Load;
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblFood;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.Label lblStorage;
        private System.Windows.Forms.RadioButton rbChill;
        private System.Windows.Forms.RadioButton rbFreezer;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.DateTimePicker dtpExpiry;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
