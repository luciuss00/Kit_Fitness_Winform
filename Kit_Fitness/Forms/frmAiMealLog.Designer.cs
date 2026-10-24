namespace Kit_Fitness.Forms
{
    partial class frmAiMealLog
    {
        private System.ComponentModel.IContainer? components = null;
        private PictureBox picMeal = null!;
        private Button btnChooseImage = null!;
        private Button btnAnalyze = null!;
        private Label lblStatus = null!;
        private Label lblFoodName = null!;
        private Label lblQuantityGrams = null!;
        private Label lblCalories = null!;
        private Label lblTimeSlot = null!;
        private TextBox txtFoodName = null!;
        private NumericUpDown numQuantityGrams = null!;
        private NumericUpDown numCalories = null!;
        private ComboBox cbTimeSlot = null!;
        private Label lblMacroEstimate = null!;
        private Button btnSave = null!;
        private Button btnCancel = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
                picMeal?.Image?.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            picMeal = new PictureBox();
            btnChooseImage = new Button();
            btnAnalyze = new Button();
            lblStatus = new Label();
            lblFoodName = new Label();
            lblQuantityGrams = new Label();
            lblCalories = new Label();
            lblTimeSlot = new Label();
            txtFoodName = new TextBox();
            numQuantityGrams = new NumericUpDown();
            numCalories = new NumericUpDown();
            cbTimeSlot = new ComboBox();
            lblMacroEstimate = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)picMeal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantityGrams).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCalories).BeginInit();
            SuspendLayout();
            //
            // picMeal
            //
            picMeal.BackColor = Color.FromArgb(245, 245, 243);
            picMeal.BorderStyle = BorderStyle.FixedSingle;
            picMeal.Location = new Point(20, 20);
            picMeal.Name = "picMeal";
            picMeal.Size = new Size(330, 390);
            picMeal.SizeMode = PictureBoxSizeMode.Zoom;
            picMeal.TabStop = false;
            //
            // btnChooseImage
            //
            btnChooseImage.Location = new Point(20, 425);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(160, 38);
            btnChooseImage.Text = "Chọn ảnh món ăn";
            btnChooseImage.UseVisualStyleBackColor = true;
            //
            // btnAnalyze
            //
            btnAnalyze.Location = new Point(190, 425);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(160, 38);
            btnAnalyze.Text = "Phân tích AI";
            btnAnalyze.UseVisualStyleBackColor = true;
            //
            // lblStatus
            //
            lblStatus.ForeColor = Color.FromArgb(80, 90, 80);
            lblStatus.Location = new Point(20, 474);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(760, 38);
            lblStatus.Text = "Chọn ảnh món ăn để bắt đầu.";
            //
            // txtFoodName
            //
            lblFoodName.Location = new Point(380, 20);
            lblFoodName.Name = "lblFoodName";
            lblFoodName.Size = new Size(390, 25);
            lblFoodName.Text = "Tên món ăn";
            //
            // lblQuantityGrams
            //
            lblQuantityGrams.Location = new Point(380, 90);
            lblQuantityGrams.Name = "lblQuantityGrams";
            lblQuantityGrams.Size = new Size(390, 25);
            lblQuantityGrams.Text = "Khối lượng khẩu phần (g)";
            //
            // lblCalories
            //
            lblCalories.Location = new Point(380, 160);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(390, 25);
            lblCalories.Text = "Calo ước tính cho khẩu phần (kcal)";
            //
            // lblTimeSlot
            //
            lblTimeSlot.Location = new Point(380, 230);
            lblTimeSlot.Name = "lblTimeSlot";
            lblTimeSlot.Size = new Size(390, 25);
            lblTimeSlot.Text = "Thời gian ăn";
            //
            // txtFoodName
            //
            txtFoodName.Location = new Point(380, 55);
            txtFoodName.Name = "txtFoodName";
            txtFoodName.PlaceholderText = "Tên món ăn";
            txtFoodName.Size = new Size(390, 27);
            //
            // numQuantityGrams
            //
            numQuantityGrams.DecimalPlaces = 0;
            numQuantityGrams.Location = new Point(380, 125);
            numQuantityGrams.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numQuantityGrams.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantityGrams.Name = "numQuantityGrams";
            numQuantityGrams.Size = new Size(390, 27);
            numQuantityGrams.Value = new decimal(new int[] { 100, 0, 0, 0 });
            //
            // numCalories
            //
            numCalories.DecimalPlaces = 0;
            numCalories.Location = new Point(380, 195);
            numCalories.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            numCalories.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCalories.Name = "numCalories";
            numCalories.Size = new Size(390, 27);
            numCalories.Value = new decimal(new int[] { 100, 0, 0, 0 });
            //
            // cbTimeSlot
            //
            cbTimeSlot.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTimeSlot.Location = new Point(380, 265);
            cbTimeSlot.Name = "cbTimeSlot";
            cbTimeSlot.Size = new Size(390, 28);
            //
            // lblMacroEstimate
            //
            lblMacroEstimate.ForeColor = Color.FromArgb(100, 100, 95);
            lblMacroEstimate.Location = new Point(380, 315);
            lblMacroEstimate.Name = "lblMacroEstimate";
            lblMacroEstimate.Size = new Size(390, 55);
            lblMacroEstimate.Text = "Macro ước tính sẽ hiển thị sau khi phân tích.";
            //
            // btnSave
            //
            btnSave.Enabled = false;
            btnSave.Location = new Point(540, 425);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 38);
            btnSave.Text = "Lưu nhật ký";
            btnSave.UseVisualStyleBackColor = true;
            //
            // btnCancel
            //
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(660, 425);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 38);
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            //
            // frmAiMealLog
            //
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 530);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblMacroEstimate);
            Controls.Add(cbTimeSlot);
            Controls.Add(lblTimeSlot);
            Controls.Add(numCalories);
            Controls.Add(lblCalories);
            Controls.Add(numQuantityGrams);
            Controls.Add(lblQuantityGrams);
            Controls.Add(txtFoodName);
            Controls.Add(lblFoodName);
            Controls.Add(lblStatus);
            Controls.Add(btnAnalyze);
            Controls.Add(btnChooseImage);
            Controls.Add(picMeal);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAiMealLog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ghi món ăn bằng AI";
            ((System.ComponentModel.ISupportInitialize)picMeal).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantityGrams).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCalories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}