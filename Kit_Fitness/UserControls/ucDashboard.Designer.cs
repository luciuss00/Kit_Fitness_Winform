namespace Kit_Fitness.UserControls
{
    partial class ucDashboard
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlMain = new Panel();
            tlpContent = new TableLayoutPanel();
            pnlLeftColumn = new Panel();
            pnlMealsSummary = new Panel();
            dgvMeals = new DataGridView();
            lnkViewTimeline = new LinkLabel();
            lblMealsSummaryTitle = new Label();
            pnlActions = new FlowLayoutPanel();
            btnNhapMon = new Button();
            btnTuLanh = new Button();
            pnlMacroContainer = new FlowLayoutPanel();
            pnlProtein = new Panel();
            lblProteinTarget = new Label();
            lblProteinValue = new Label();
            lblProteinTitle = new Label();
            pnlCarbs = new Panel();
            lblCarbsTarget = new Label();
            lblCarbsValue = new Label();
            lblCarbsTitle = new Label();
            pnlFat = new Panel();
            lblFatTarget = new Label();
            lblFatValue = new Label();
            lblFatTitle = new Label();
            pnlNutritionCard = new Panel();
            progressCalories = new ProgressBar();
            lblBurnedCal = new Label();
            lblConsumedCal = new Label();
            lblTargetCal = new Label();
            lblCaloriesRemainingLabel = new Label();
            lblCaloriesRemaining = new Label();
            lblGoal = new Label();
            lblNutritionTitle = new Label();
            lblGreeting = new Label();
            lblDate = new Label();
            pnlRightColumn = new Panel();
            pnlWeightCard = new Panel();
            btnUpdateWeight = new Button();
            lblWeightTarget = new Label();
            lblWeightValue = new Label();
            lblWeightTitle = new Label();
            pnlWaterCard = new Panel();
            btnWaterPlus = new Button();
            btnWaterMinus = new Button();
            progressWater = new ProgressBar();
            lblWaterValue = new Label();
            lblWaterTitle = new Label();
            pnlFridgeCard = new Panel();
            dgvFridge = new DataGridView();
            lblFridgeWarning = new Label();
            lnkGoToBep = new LinkLabel();
            lblFridgeTitle = new Label();
            pnlCalorieCircle = new Panel();
            pnlMain.SuspendLayout();
            tlpContent.SuspendLayout();
            pnlLeftColumn.SuspendLayout();
            pnlMealsSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMeals).BeginInit();
            pnlActions.SuspendLayout();
            pnlMacroContainer.SuspendLayout();
            pnlProtein.SuspendLayout();
            pnlCarbs.SuspendLayout();
            pnlFat.SuspendLayout();
            pnlNutritionCard.SuspendLayout();
            pnlRightColumn.SuspendLayout();
            pnlWeightCard.SuspendLayout();
            pnlWaterCard.SuspendLayout();
            pnlFridgeCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFridge).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.AutoScroll = true;
            pnlMain.BackColor = Color.FromArgb(250, 247, 240);
            pnlMain.Controls.Add(tlpContent);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20, 10, 20, 10);
            pnlMain.Size = new Size(1032, 700);
            pnlMain.TabIndex = 0;
            pnlMain.Paint += pnlMain_Paint;
            // 
            // tlpContent
            // 
            tlpContent.ColumnCount = 2;
            tlpContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            tlpContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            tlpContent.Controls.Add(pnlLeftColumn, 0, 0);
            tlpContent.Controls.Add(pnlRightColumn, 1, 0);
            tlpContent.Dock = DockStyle.Top;
            tlpContent.Location = new Point(20, 10);
            tlpContent.Name = "tlpContent";
            tlpContent.RowCount = 1;
            tlpContent.RowStyles.Add(new RowStyle());
            tlpContent.Size = new Size(971, 1100);
            tlpContent.TabIndex = 0;
            // 
            // pnlLeftColumn
            // 
            pnlLeftColumn.Controls.Add(pnlMealsSummary);
            pnlLeftColumn.Controls.Add(pnlActions);
            pnlLeftColumn.Controls.Add(pnlMacroContainer);
            pnlLeftColumn.Controls.Add(pnlNutritionCard);
            pnlLeftColumn.Controls.Add(lblGreeting);
            pnlLeftColumn.Controls.Add(lblDate);
            pnlLeftColumn.Dock = DockStyle.Fill;
            pnlLeftColumn.Location = new Point(3, 3);
            pnlLeftColumn.Name = "pnlLeftColumn";
            pnlLeftColumn.Padding = new Padding(0, 0, 15, 0);
            pnlLeftColumn.Size = new Size(557, 1094);
            pnlLeftColumn.TabIndex = 0;
            // 
            // pnlMealsSummary
            // 
            pnlMealsSummary.BackColor = Color.White;
            pnlMealsSummary.Controls.Add(dgvMeals);
            pnlMealsSummary.Controls.Add(lnkViewTimeline);
            pnlMealsSummary.Controls.Add(lblMealsSummaryTitle);
            pnlMealsSummary.Dock = DockStyle.Top;
            pnlMealsSummary.Location = new Point(0, 523);
            pnlMealsSummary.Name = "pnlMealsSummary";
            pnlMealsSummary.Padding = new Padding(15);
            pnlMealsSummary.Size = new Size(542, 230);
            pnlMealsSummary.TabIndex = 0;
            // 
            // dgvMeals
            // 
            dgvMeals.AllowUserToAddRows = false;
            dgvMeals.AllowUserToDeleteRows = false;
            dgvMeals.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvMeals.BackgroundColor = Color.White;
            dgvMeals.BorderStyle = BorderStyle.None;
            dgvMeals.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMeals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMeals.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(240, 248, 240);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvMeals.DefaultCellStyle = dataGridViewCellStyle1;
            dgvMeals.GridColor = Color.FromArgb(240, 238, 232);
            dgvMeals.Location = new Point(15, 50);
            dgvMeals.Name = "dgvMeals";
            dgvMeals.ReadOnly = true;
            dgvMeals.RowHeadersVisible = false;
            dgvMeals.RowHeadersWidth = 51;
            dgvMeals.RowTemplate.Height = 35;
            dgvMeals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMeals.Size = new Size(500, 165);
            dgvMeals.TabIndex = 0;
            // 
            // lnkViewTimeline
            // 
            lnkViewTimeline.AutoSize = true;
            lnkViewTimeline.Font = new Font("Segoe UI", 9F);
            lnkViewTimeline.LinkColor = Color.FromArgb(76, 140, 74);
            lnkViewTimeline.Location = new Point(420, 18);
            lnkViewTimeline.Name = "lnkViewTimeline";
            lnkViewTimeline.Size = new Size(111, 20);
            lnkViewTimeline.TabIndex = 1;
            lnkViewTimeline.TabStop = true;
            lnkViewTimeline.Text = "Xem timeline >";
            // 
            // lblMealsSummaryTitle
            // 
            lblMealsSummaryTitle.AutoSize = true;
            lblMealsSummaryTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMealsSummaryTitle.ForeColor = Color.FromArgb(51, 51, 51);
            lblMealsSummaryTitle.Location = new Point(15, 15);
            lblMealsSummaryTitle.Name = "lblMealsSummaryTitle";
            lblMealsSummaryTitle.Size = new Size(244, 25);
            lblMealsSummaryTitle.TabIndex = 2;
            lblMealsSummaryTitle.Text = "🍽️ Bữa Ăn Đã Ghi (2 món)";
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(btnNhapMon);
            pnlActions.Controls.Add(btnTuLanh);
            pnlActions.Dock = DockStyle.Top;
            pnlActions.Location = new Point(0, 463);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(0, 5, 0, 5);
            pnlActions.Size = new Size(542, 60);
            pnlActions.TabIndex = 1;
            // 
            // btnNhapMon
            // 
            btnNhapMon.BackColor = Color.White;
            btnNhapMon.Cursor = Cursors.Hand;
            btnNhapMon.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnNhapMon.FlatStyle = FlatStyle.Flat;
            btnNhapMon.Font = new Font("Segoe UI", 9F);
            btnNhapMon.ForeColor = Color.FromArgb(80, 80, 80);
            btnNhapMon.Location = new Point(3, 8);
            btnNhapMon.Name = "btnNhapMon";
            btnNhapMon.Padding = new Padding(8, 0, 8, 0);
            btnNhapMon.Size = new Size(140, 42);
            btnNhapMon.TabIndex = 0;
            btnNhapMon.Text = "🍽️  Nhập món";
            btnNhapMon.UseVisualStyleBackColor = false;
            // 
            // btnTuLanh
            // 
            btnTuLanh.BackColor = Color.White;
            btnTuLanh.Cursor = Cursors.Hand;
            btnTuLanh.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnTuLanh.FlatStyle = FlatStyle.Flat;
            btnTuLanh.Font = new Font("Segoe UI", 9F);
            btnTuLanh.ForeColor = Color.FromArgb(80, 80, 80);
            btnTuLanh.Location = new Point(149, 8);
            btnTuLanh.Name = "btnTuLanh";
            btnTuLanh.Padding = new Padding(8, 0, 8, 0);
            btnTuLanh.Size = new Size(140, 42);
            btnTuLanh.TabIndex = 1;
            btnTuLanh.Text = "\U0001f9ca  Tủ lạnh";
            btnTuLanh.UseVisualStyleBackColor = false;
            // 
            // pnlMacroContainer
            // 
            pnlMacroContainer.Controls.Add(pnlProtein);
            pnlMacroContainer.Controls.Add(pnlCarbs);
            pnlMacroContainer.Controls.Add(pnlFat);
            pnlMacroContainer.Dock = DockStyle.Top;
            pnlMacroContainer.Location = new Point(0, 341);
            pnlMacroContainer.Name = "pnlMacroContainer";
            pnlMacroContainer.Padding = new Padding(0, 10, 0, 10);
            pnlMacroContainer.Size = new Size(542, 122);
            pnlMacroContainer.TabIndex = 2;
            // 
            // pnlProtein
            // 
            pnlProtein.BackColor = Color.White;
            pnlProtein.Controls.Add(lblProteinTarget);
            pnlProtein.Controls.Add(lblProteinValue);
            pnlProtein.Controls.Add(lblProteinTitle);
            pnlProtein.Location = new Point(0, 10);
            pnlProtein.Margin = new Padding(0, 0, 8, 0);
            pnlProtein.Name = "pnlProtein";
            pnlProtein.Padding = new Padding(12);
            pnlProtein.Size = new Size(174, 96);
            pnlProtein.TabIndex = 0;
            // 
            // lblProteinTarget
            // 
            lblProteinTarget.AutoSize = true;
            lblProteinTarget.Font = new Font("Segoe UI", 7.5F);
            lblProteinTarget.ForeColor = Color.FromArgb(150, 150, 150);
            lblProteinTarget.Location = new Point(12, 67);
            lblProteinTarget.Name = "lblProteinTarget";
            lblProteinTarget.Size = new Size(91, 17);
            lblProteinTarget.TabIndex = 0;
            lblProteinTarget.Text = "Mục tiêu 108g";
            lblProteinTarget.Click += lblProteinTarget_Click;
            // 
            // lblProteinValue
            // 
            lblProteinValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblProteinValue.ForeColor = Color.FromArgb(76, 140, 74);
            lblProteinValue.Location = new Point(12, 25);
            lblProteinValue.Name = "lblProteinValue";
            lblProteinValue.Size = new Size(140, 42);
            lblProteinValue.TabIndex = 1;
            lblProteinValue.Text = "32g";
            lblProteinValue.Click += lblProteinValue_Click;
            // 
            // lblProteinTitle
            // 
            lblProteinTitle.AutoSize = true;
            lblProteinTitle.Font = new Font("Segoe UI", 8F);
            lblProteinTitle.ForeColor = Color.FromArgb(120, 113, 100);
            lblProteinTitle.Location = new Point(12, 8);
            lblProteinTitle.Name = "lblProteinTitle";
            lblProteinTitle.Size = new Size(94, 19);
            lblProteinTitle.TabIndex = 2;
            lblProteinTitle.Text = "Đạm (Protein)";
            // 
            // pnlCarbs
            // 
            pnlCarbs.BackColor = Color.White;
            pnlCarbs.Controls.Add(lblCarbsTarget);
            pnlCarbs.Controls.Add(lblCarbsValue);
            pnlCarbs.Controls.Add(lblCarbsTitle);
            pnlCarbs.Location = new Point(182, 10);
            pnlCarbs.Margin = new Padding(0, 0, 8, 0);
            pnlCarbs.Name = "pnlCarbs";
            pnlCarbs.Padding = new Padding(12);
            pnlCarbs.Size = new Size(174, 96);
            pnlCarbs.TabIndex = 1;
            // 
            // lblCarbsTarget
            // 
            lblCarbsTarget.AutoSize = true;
            lblCarbsTarget.Font = new Font("Segoe UI", 7.5F);
            lblCarbsTarget.ForeColor = Color.FromArgb(150, 150, 150);
            lblCarbsTarget.Location = new Point(12, 67);
            lblCarbsTarget.Name = "lblCarbsTarget";
            lblCarbsTarget.Size = new Size(91, 17);
            lblCarbsTarget.TabIndex = 0;
            lblCarbsTarget.Text = "Mục tiêu 163g";
            // 
            // lblCarbsValue
            // 
            lblCarbsValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCarbsValue.ForeColor = Color.FromArgb(200, 150, 50);
            lblCarbsValue.Location = new Point(12, 26);
            lblCarbsValue.Name = "lblCarbsValue";
            lblCarbsValue.Size = new Size(140, 41);
            lblCarbsValue.TabIndex = 1;
            lblCarbsValue.Text = "58g";
            // 
            // lblCarbsTitle
            // 
            lblCarbsTitle.AutoSize = true;
            lblCarbsTitle.Font = new Font("Segoe UI", 8F);
            lblCarbsTitle.ForeColor = Color.FromArgb(120, 113, 100);
            lblCarbsTitle.Location = new Point(12, 8);
            lblCarbsTitle.Name = "lblCarbsTitle";
            lblCarbsTitle.Size = new Size(101, 19);
            lblCarbsTitle.TabIndex = 2;
            lblCarbsTitle.Text = "Tinh bột (Carb)";
            // 
            // pnlFat
            // 
            pnlFat.BackColor = Color.White;
            pnlFat.Controls.Add(lblFatTarget);
            pnlFat.Controls.Add(lblFatValue);
            pnlFat.Controls.Add(lblFatTitle);
            pnlFat.Location = new Point(364, 10);
            pnlFat.Margin = new Padding(0);
            pnlFat.Name = "pnlFat";
            pnlFat.Padding = new Padding(12);
            pnlFat.Size = new Size(178, 96);
            pnlFat.TabIndex = 2;
            // 
            // lblFatTarget
            // 
            lblFatTarget.AutoSize = true;
            lblFatTarget.Font = new Font("Segoe UI", 7.5F);
            lblFatTarget.ForeColor = Color.FromArgb(150, 150, 150);
            lblFatTarget.Location = new Point(12, 67);
            lblFatTarget.Name = "lblFatTarget";
            lblFatTarget.Size = new Size(84, 17);
            lblFatTarget.TabIndex = 0;
            lblFatTarget.Text = "Mục tiêu 40g";
            // 
            // lblFatValue
            // 
            lblFatValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFatValue.ForeColor = Color.FromArgb(180, 80, 80);
            lblFatValue.Location = new Point(12, 27);
            lblFatValue.Name = "lblFatValue";
            lblFatValue.Size = new Size(140, 40);
            lblFatValue.TabIndex = 1;
            lblFatValue.Text = "12g";
            // 
            // lblFatTitle
            // 
            lblFatTitle.AutoSize = true;
            lblFatTitle.Font = new Font("Segoe UI", 8F);
            lblFatTitle.ForeColor = Color.FromArgb(120, 113, 100);
            lblFatTitle.Location = new Point(12, 8);
            lblFatTitle.Name = "lblFatTitle";
            lblFatTitle.Size = new Size(96, 19);
            lblFatTitle.TabIndex = 2;
            lblFatTitle.Text = "Chất béo (Fat)";
            // 
            // pnlNutritionCard
            // 
            pnlNutritionCard.BackColor = Color.White;
            pnlNutritionCard.Controls.Add(progressCalories);
            pnlNutritionCard.Controls.Add(lblBurnedCal);
            pnlNutritionCard.Controls.Add(lblConsumedCal);
            pnlNutritionCard.Controls.Add(lblTargetCal);
            pnlNutritionCard.Controls.Add(lblCaloriesRemainingLabel);
            pnlNutritionCard.Controls.Add(lblCaloriesRemaining);
            pnlNutritionCard.Controls.Add(lblGoal);
            pnlNutritionCard.Controls.Add(lblNutritionTitle);
            pnlNutritionCard.Dock = DockStyle.Top;
            pnlNutritionCard.Location = new Point(0, 81);
            pnlNutritionCard.Name = "pnlNutritionCard";
            pnlNutritionCard.Padding = new Padding(20);
            pnlNutritionCard.Size = new Size(542, 260);
            pnlNutritionCard.TabIndex = 3;
            // 
            // progressCalories
            // 
            progressCalories.ForeColor = Color.FromArgb(76, 140, 74);
            progressCalories.Location = new Point(20, 220);
            progressCalories.Name = "progressCalories";
            progressCalories.Size = new Size(490, 15);
            progressCalories.Style = ProgressBarStyle.Continuous;
            progressCalories.TabIndex = 0;
            progressCalories.Value = 32;
            // 
            // lblBurnedCal
            // 
            lblBurnedCal.AutoSize = true;
            lblBurnedCal.Font = new Font("Segoe UI", 9.5F);
            lblBurnedCal.ForeColor = Color.FromArgb(200, 120, 50);
            lblBurnedCal.Location = new Point(280, 145);
            lblBurnedCal.Name = "lblBurnedCal";
            lblBurnedCal.Size = new Size(183, 21);
            lblBurnedCal.TabIndex = 1;
            lblBurnedCal.Text = "● Vận động đốt: 220 kcal";
            // 
            // lblConsumedCal
            // 
            lblConsumedCal.AutoSize = true;
            lblConsumedCal.Font = new Font("Segoe UI", 9.5F);
            lblConsumedCal.ForeColor = Color.FromArgb(76, 140, 74);
            lblConsumedCal.Location = new Point(280, 115);
            lblConsumedCal.Name = "lblConsumedCal";
            lblConsumedCal.Size = new Size(167, 21);
            lblConsumedCal.TabIndex = 2;
            lblConsumedCal.Text = "● Đã nạp vào: 465 kcal";
            // 
            // lblTargetCal
            // 
            lblTargetCal.AutoSize = true;
            lblTargetCal.Font = new Font("Segoe UI", 9.5F);
            lblTargetCal.ForeColor = Color.FromArgb(80, 80, 80);
            lblTargetCal.Location = new Point(280, 85);
            lblTargetCal.Name = "lblTargetCal";
            lblTargetCal.Size = new Size(196, 21);
            lblTargetCal.TabIndex = 3;
            lblTargetCal.Text = "● Mục tiêu ngày: 1450 kcal";
            // 
            // lblCaloriesRemainingLabel
            // 
            lblCaloriesRemainingLabel.AutoSize = true;
            lblCaloriesRemainingLabel.Font = new Font("Segoe UI", 9F);
            lblCaloriesRemainingLabel.ForeColor = Color.FromArgb(120, 113, 100);
            lblCaloriesRemainingLabel.Location = new Point(55, 145);
            lblCaloriesRemainingLabel.Name = "lblCaloriesRemainingLabel";
            lblCaloriesRemainingLabel.Size = new Size(105, 20);
            lblCaloriesRemainingLabel.TabIndex = 4;
            lblCaloriesRemainingLabel.Text = "CALO CÒN LẠI";
            // 
            // lblCaloriesRemaining
            // 
            lblCaloriesRemaining.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblCaloriesRemaining.ForeColor = Color.FromArgb(76, 140, 74);
            lblCaloriesRemaining.Location = new Point(20, 80);
            lblCaloriesRemaining.Name = "lblCaloriesRemaining";
            lblCaloriesRemaining.Size = new Size(200, 65);
            lblCaloriesRemaining.TabIndex = 5;
            lblCaloriesRemaining.Text = "985";
            lblCaloriesRemaining.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGoal
            // 
            lblGoal.AutoSize = true;
            lblGoal.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblGoal.ForeColor = Color.FromArgb(100, 100, 100);
            lblGoal.Location = new Point(20, 45);
            lblGoal.Name = "lblGoal";
            lblGoal.Size = new Size(217, 23);
            lblGoal.TabIndex = 6;
            lblGoal.Text = "Mục tiêu: Giảm mỡ tự nhiên";
            // 
            // lblNutritionTitle
            // 
            lblNutritionTitle.AutoSize = true;
            lblNutritionTitle.Font = new Font("Segoe UI", 9F);
            lblNutritionTitle.ForeColor = Color.FromArgb(120, 113, 100);
            lblNutritionTitle.Location = new Point(20, 20);
            lblNutritionTitle.Name = "lblNutritionTitle";
            lblNutritionTitle.Size = new Size(245, 20);
            lblNutritionTitle.TabIndex = 7;
            lblNutritionTitle.Text = "MỤC TIÊU DINH DƯỠNG HÔM NAY";
            // 
            // lblGreeting
            // 
            lblGreeting.AutoSize = true;
            lblGreeting.Dock = DockStyle.Top;
            lblGreeting.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblGreeting.ForeColor = Color.FromArgb(51, 51, 51);
            lblGreeting.Location = new Point(0, 25);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Padding = new Padding(0, 0, 0, 15);
            lblGreeting.Size = new Size(330, 56);
            lblGreeting.TabIndex = 4;
            lblGreeting.Text = "Chào Người dùng! 🌿";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Dock = DockStyle.Top;
            lblDate.Font = new Font("Segoe UI", 9F);
            lblDate.ForeColor = Color.FromArgb(120, 113, 100);
            lblDate.Location = new Point(0, 0);
            lblDate.Name = "lblDate";
            lblDate.Padding = new Padding(0, 5, 0, 0);
            lblDate.Size = new Size(152, 25);
            lblDate.TabIndex = 5;
            lblDate.Text = "HÔM NAY, 20 THG 10";
            // 
            // pnlRightColumn
            // 
            pnlRightColumn.Controls.Add(pnlWeightCard);
            pnlRightColumn.Controls.Add(pnlWaterCard);
            pnlRightColumn.Controls.Add(pnlFridgeCard);
            pnlRightColumn.Dock = DockStyle.Fill;
            pnlRightColumn.Location = new Point(566, 3);
            pnlRightColumn.Name = "pnlRightColumn";
            pnlRightColumn.Size = new Size(402, 1094);
            pnlRightColumn.TabIndex = 1;
            // 
            // pnlWeightCard
            // 
            pnlWeightCard.BackColor = Color.White;
            pnlWeightCard.Controls.Add(btnUpdateWeight);
            pnlWeightCard.Controls.Add(lblWeightTarget);
            pnlWeightCard.Controls.Add(lblWeightValue);
            pnlWeightCard.Controls.Add(lblWeightTitle);
            pnlWeightCard.Dock = DockStyle.Top;
            pnlWeightCard.Location = new Point(0, 480);
            pnlWeightCard.Name = "pnlWeightCard";
            pnlWeightCard.Padding = new Padding(15);
            pnlWeightCard.Size = new Size(402, 120);
            pnlWeightCard.TabIndex = 0;
            // 
            // btnUpdateWeight
            // 
            btnUpdateWeight.BackColor = Color.FromArgb(245, 243, 237);
            btnUpdateWeight.Cursor = Cursors.Hand;
            btnUpdateWeight.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnUpdateWeight.FlatStyle = FlatStyle.Flat;
            btnUpdateWeight.Font = new Font("Segoe UI", 8.5F);
            btnUpdateWeight.ForeColor = Color.FromArgb(80, 80, 80);
            btnUpdateWeight.Location = new Point(271, 49);
            btnUpdateWeight.Name = "btnUpdateWeight";
            btnUpdateWeight.Size = new Size(94, 37);
            btnUpdateWeight.TabIndex = 0;
            btnUpdateWeight.Text = "Cập nhật";
            btnUpdateWeight.UseVisualStyleBackColor = false;
            // 
            // lblWeightTarget
            // 
            lblWeightTarget.AutoSize = true;
            lblWeightTarget.Font = new Font("Segoe UI", 8.5F);
            lblWeightTarget.ForeColor = Color.FromArgb(150, 150, 150);
            lblWeightTarget.Location = new Point(136, 58);
            lblWeightTarget.Name = "lblWeightTarget";
            lblWeightTarget.Size = new Size(119, 20);
            lblWeightTarget.TabIndex = 1;
            lblWeightTarget.Text = "(Mục tiêu: 47 kg)";
            // 
            // lblWeightValue
            // 
            lblWeightValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblWeightValue.ForeColor = Color.FromArgb(51, 51, 51);
            lblWeightValue.Location = new Point(15, 42);
            lblWeightValue.Name = "lblWeightValue";
            lblWeightValue.Size = new Size(125, 63);
            lblWeightValue.TabIndex = 2;
            lblWeightValue.Text = "50 kg";
            // 
            // lblWeightTitle
            // 
            lblWeightTitle.AutoSize = true;
            lblWeightTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblWeightTitle.ForeColor = Color.FromArgb(120, 113, 100);
            lblWeightTitle.Location = new Point(15, 15);
            lblWeightTitle.Name = "lblWeightTitle";
            lblWeightTitle.Size = new Size(202, 20);
            lblWeightTitle.TabIndex = 3;
            lblWeightTitle.Text = "⚖️ CÂN NẶNG GẦN NHẤT";
            // 
            // pnlWaterCard
            // 
            pnlWaterCard.BackColor = Color.White;
            pnlWaterCard.Controls.Add(btnWaterPlus);
            pnlWaterCard.Controls.Add(btnWaterMinus);
            pnlWaterCard.Controls.Add(progressWater);
            pnlWaterCard.Controls.Add(lblWaterValue);
            pnlWaterCard.Controls.Add(lblWaterTitle);
            pnlWaterCard.Dock = DockStyle.Top;
            pnlWaterCard.Location = new Point(0, 340);
            pnlWaterCard.Margin = new Padding(0, 10, 0, 0);
            pnlWaterCard.Name = "pnlWaterCard";
            pnlWaterCard.Padding = new Padding(15);
            pnlWaterCard.Size = new Size(402, 140);
            pnlWaterCard.TabIndex = 1;
            // 
            // btnWaterPlus
            // 
            btnWaterPlus.BackColor = Color.FromArgb(245, 243, 237);
            btnWaterPlus.Cursor = Cursors.Hand;
            btnWaterPlus.FlatAppearance.BorderSize = 0;
            btnWaterPlus.FlatStyle = FlatStyle.Flat;
            btnWaterPlus.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnWaterPlus.ForeColor = Color.FromArgb(80, 80, 80);
            btnWaterPlus.Location = new Point(330, 45);
            btnWaterPlus.Name = "btnWaterPlus";
            btnWaterPlus.Size = new Size(35, 35);
            btnWaterPlus.TabIndex = 0;
            btnWaterPlus.Text = "+";
            btnWaterPlus.UseVisualStyleBackColor = false;
            // 
            // btnWaterMinus
            // 
            btnWaterMinus.BackColor = Color.FromArgb(245, 243, 237);
            btnWaterMinus.Cursor = Cursors.Hand;
            btnWaterMinus.FlatAppearance.BorderSize = 0;
            btnWaterMinus.FlatStyle = FlatStyle.Flat;
            btnWaterMinus.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnWaterMinus.ForeColor = Color.FromArgb(80, 80, 80);
            btnWaterMinus.Location = new Point(290, 45);
            btnWaterMinus.Name = "btnWaterMinus";
            btnWaterMinus.Size = new Size(35, 35);
            btnWaterMinus.TabIndex = 1;
            btnWaterMinus.Text = "−";
            btnWaterMinus.UseVisualStyleBackColor = false;
            // 
            // progressWater
            // 
            progressWater.Location = new Point(15, 95);
            progressWater.Name = "progressWater";
            progressWater.Size = new Size(250, 12);
            progressWater.Style = ProgressBarStyle.Continuous;
            progressWater.TabIndex = 2;
            progressWater.Value = 60;
            // 
            // lblWaterValue
            // 
            lblWaterValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblWaterValue.ForeColor = Color.FromArgb(51, 51, 51);
            lblWaterValue.Location = new Point(15, 40);
            lblWaterValue.Name = "lblWaterValue";
            lblWaterValue.Size = new Size(250, 45);
            lblWaterValue.TabIndex = 3;
            lblWaterValue.Text = "1200 / 2000 ml";
            // 
            // lblWaterTitle
            // 
            lblWaterTitle.AutoSize = true;
            lblWaterTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblWaterTitle.ForeColor = Color.FromArgb(120, 113, 100);
            lblWaterTitle.Location = new Point(15, 15);
            lblWaterTitle.Name = "lblWaterTitle";
            lblWaterTitle.Size = new Size(161, 20);
            lblWaterTitle.TabIndex = 4;
            lblWaterTitle.Text = "💧 NƯỚC UỐNG LỌC";
            // 
            // pnlFridgeCard
            // 
            pnlFridgeCard.BackColor = Color.White;
            pnlFridgeCard.Controls.Add(dgvFridge);
            pnlFridgeCard.Controls.Add(lblFridgeWarning);
            pnlFridgeCard.Controls.Add(lnkGoToBep);
            pnlFridgeCard.Controls.Add(lblFridgeTitle);
            pnlFridgeCard.Dock = DockStyle.Top;
            pnlFridgeCard.Location = new Point(0, 0);
            pnlFridgeCard.Name = "pnlFridgeCard";
            pnlFridgeCard.Padding = new Padding(15);
            pnlFridgeCard.Size = new Size(402, 340);
            pnlFridgeCard.TabIndex = 2;
            // 
            // dgvFridge
            // 
            dgvFridge.AllowUserToAddRows = false;
            dgvFridge.AllowUserToDeleteRows = false;
            dgvFridge.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvFridge.BackgroundColor = Color.White;
            dgvFridge.BorderStyle = BorderStyle.None;
            dgvFridge.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvFridge.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFridge.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(240, 248, 240);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvFridge.DefaultCellStyle = dataGridViewCellStyle2;
            dgvFridge.GridColor = Color.FromArgb(240, 238, 232);
            dgvFridge.Location = new Point(15, 75);
            dgvFridge.Name = "dgvFridge";
            dgvFridge.ReadOnly = true;
            dgvFridge.RowHeadersVisible = false;
            dgvFridge.RowHeadersWidth = 51;
            dgvFridge.RowTemplate.Height = 40;
            dgvFridge.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFridge.Size = new Size(350, 250);
            dgvFridge.TabIndex = 0;
            // 
            // lblFridgeWarning
            // 
            lblFridgeWarning.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFridgeWarning.Font = new Font("Segoe UI", 8.5F);
            lblFridgeWarning.ForeColor = Color.FromArgb(200, 120, 50);
            lblFridgeWarning.Location = new Point(15, 45);
            lblFridgeWarning.Name = "lblFridgeWarning";
            lblFridgeWarning.Size = new Size(350, 22);
            lblFridgeWarning.TabIndex = 1;
            lblFridgeWarning.Text = "⚠️ Có 1 thực phẩm cần nấu ngay hôm nay!";
            // 
            // lnkGoToBep
            // 
            lnkGoToBep.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lnkGoToBep.AutoSize = true;
            lnkGoToBep.Font = new Font("Segoe UI", 9F);
            lnkGoToBep.LinkColor = Color.FromArgb(76, 140, 74);
            lnkGoToBep.Location = new Point(300, 18);
            lnkGoToBep.Name = "lnkGoToBep";
            lnkGoToBep.Size = new Size(78, 20);
            lnkGoToBep.TabIndex = 2;
            lnkGoToBep.TabStop = true;
            lnkGoToBep.Text = "Vào bếp >";
            // 
            // lblFridgeTitle
            // 
            lblFridgeTitle.AutoSize = true;
            lblFridgeTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFridgeTitle.ForeColor = Color.FromArgb(51, 51, 51);
            lblFridgeTitle.Location = new Point(15, 15);
            lblFridgeTitle.Name = "lblFridgeTitle";
            lblFridgeTitle.Size = new Size(275, 25);
            lblFridgeTitle.TabIndex = 3;
            lblFridgeTitle.Text = "\U0001f9ca Tủ Lạnh Hôm Nay (6 món)";
            // 
            // pnlCalorieCircle
            // 
            pnlCalorieCircle.Location = new Point(0, 0);
            pnlCalorieCircle.Name = "pnlCalorieCircle";
            pnlCalorieCircle.Size = new Size(200, 100);
            pnlCalorieCircle.TabIndex = 0;
            // 
            // ucDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Name = "ucDashboard";
            Size = new Size(1032, 700);
            pnlMain.ResumeLayout(false);
            tlpContent.ResumeLayout(false);
            pnlLeftColumn.ResumeLayout(false);
            pnlLeftColumn.PerformLayout();
            pnlMealsSummary.ResumeLayout(false);
            pnlMealsSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMeals).EndInit();
            pnlActions.ResumeLayout(false);
            pnlMacroContainer.ResumeLayout(false);
            pnlProtein.ResumeLayout(false);
            pnlProtein.PerformLayout();
            pnlCarbs.ResumeLayout(false);
            pnlCarbs.PerformLayout();
            pnlFat.ResumeLayout(false);
            pnlFat.PerformLayout();
            pnlNutritionCard.ResumeLayout(false);
            pnlNutritionCard.PerformLayout();
            pnlRightColumn.ResumeLayout(false);
            pnlWeightCard.ResumeLayout(false);
            pnlWeightCard.PerformLayout();
            pnlWaterCard.ResumeLayout(false);
            pnlWaterCard.PerformLayout();
            pnlFridgeCard.ResumeLayout(false);
            pnlFridgeCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFridge).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.Panel pnlLeftColumn;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblGreeting;

        // Nutrition Card
        private System.Windows.Forms.Panel pnlNutritionCard;
        private System.Windows.Forms.Label lblNutritionTitle;
        private System.Windows.Forms.Label lblGoal;
        private System.Windows.Forms.Panel pnlCalorieCircle;
        private System.Windows.Forms.Label lblCaloriesRemaining;
        private System.Windows.Forms.Label lblCaloriesRemainingLabel;
        private System.Windows.Forms.Label lblTargetCal;
        private System.Windows.Forms.Label lblConsumedCal;
        private System.Windows.Forms.Label lblBurnedCal;
        private System.Windows.Forms.ProgressBar progressCalories;

        // Macro panels
        private System.Windows.Forms.FlowLayoutPanel pnlMacroContainer;
        private System.Windows.Forms.Panel pnlProtein;
        private System.Windows.Forms.Label lblProteinTitle;
        private System.Windows.Forms.Label lblProteinValue;
        private System.Windows.Forms.Label lblProteinTarget;
        private System.Windows.Forms.Panel pnlCarbs;
        private System.Windows.Forms.Label lblCarbsTitle;
        private System.Windows.Forms.Label lblCarbsValue;
        private System.Windows.Forms.Label lblCarbsTarget;
        private System.Windows.Forms.Panel pnlFat;
        private System.Windows.Forms.Label lblFatTitle;
        private System.Windows.Forms.Label lblFatValue;
        private System.Windows.Forms.Label lblFatTarget;

        // Actions
        private System.Windows.Forms.FlowLayoutPanel pnlActions;
        private System.Windows.Forms.Button btnNhapMon;
        private System.Windows.Forms.Button btnTuLanh;

        // Meals Summary
        private System.Windows.Forms.Panel pnlMealsSummary;
        private System.Windows.Forms.Label lblMealsSummaryTitle;
        private System.Windows.Forms.LinkLabel lnkViewTimeline;
        private System.Windows.Forms.DataGridView dgvMeals;

        // Right column
        private System.Windows.Forms.Panel pnlRightColumn;

        // Fridge Card
        private System.Windows.Forms.Panel pnlFridgeCard;
        private System.Windows.Forms.Label lblFridgeTitle;
        private System.Windows.Forms.LinkLabel lnkGoToBep;
        private System.Windows.Forms.Label lblFridgeWarning;
        private System.Windows.Forms.DataGridView dgvFridge;

        // Water Card
        private System.Windows.Forms.Panel pnlWaterCard;
        private System.Windows.Forms.Label lblWaterTitle;
        private System.Windows.Forms.Label lblWaterValue;
        private System.Windows.Forms.ProgressBar progressWater;
        private System.Windows.Forms.Button btnWaterMinus;
        private System.Windows.Forms.Button btnWaterPlus;

        // Weight Card
        private System.Windows.Forms.Panel pnlWeightCard;
        private System.Windows.Forms.Label lblWeightTitle;
        private System.Windows.Forms.Label lblWeightValue;
        private System.Windows.Forms.Label lblWeightTarget;
        private System.Windows.Forms.Button btnUpdateWeight;
    }
}
