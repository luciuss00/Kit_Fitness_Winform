namespace Kit_Fitness.UserControls
{
    partial class ucProfile
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
            pnlMain = new Panel();
            pnlSurveyView = new Panel();
            tlpSurveyContent = new TableLayoutPanel();
            pnlSurveyLeft = new Panel();
            pnlSurveyStepContainer = new Panel();
            pnlSurveyBottomActions = new Panel();
            btnNextStep = new Button();
            btnPrevStep = new Button();
            pnlSurveyRight = new Panel();
            pnlLivePreviewCard = new Panel();
            lblPreviewDisclaimer = new Label();
            pnlPreviewMacroBox = new Panel();
            lblPreviewMacroBreakdown = new Label();
            pnlMacroColorBar = new Panel();
            lblPreviewTargetCal = new Label();
            lblPreviewCalTitle = new Label();
            pnlPreviewStatsList = new Panel();
            lblPreviewWater = new Label();
            lblPreviewWaterTitle = new Label();
            lblPreviewTdee = new Label();
            lblPreviewTdeeTitle = new Label();
            lblPreviewBmr = new Label();
            lblPreviewBmrTitle = new Label();
            pnlPreviewBmiBox = new Panel();
            lblPreviewBmiStatus = new Label();
            lblPreviewBmiVal = new Label();
            lblPreviewBmiTitle = new Label();
            pnlPreviewUserSnippet = new Panel();
            lblPreviewUserSub = new Label();
            lblPreviewUserName = new Label();
            lblPreviewAvatar = new Label();
            lblPreviewTitle = new Label();
            pnlSurveyHeader = new Panel();
            btnCancelSurvey = new Button();
            lblSurveyStepBadge = new Label();
            btnHomeFromSurvey = new Button();
            lblSurveySub = new Label();
            pnlProfileView = new Panel();
            lblPageTitle = new Label();
            tlpProfile = new TableLayoutPanel();
            pnlUserCard = new Panel();
            btnChangePassword = new Button();
            btnLogOut = new Button();
            pnlUserStatsBar = new Panel();
            lblStatWeightVal = new Label();
            lblStatWeightTitle = new Label();
            lblStatHeightVal = new Label();
            lblStatHeightTitle = new Label();
            lblStatAgeVal = new Label();
            lblStatAgeTitle = new Label();
            lblUserEmail = new Label();
            lblUserName = new Label();
            pnlAvatar = new Panel();
            lblAvatarCheck = new Label();
            lblAvatarInitial = new Label();
            pnlNutritionGoalCard = new Panel();
            btnStartSurvey = new Button();
            tlpMetrics = new TableLayoutPanel();
            pnlBmr = new Panel();
            lblBmrSub = new Label();
            lblBmrVal = new Label();
            lblBmrTitle = new Label();
            pnlTdee = new Panel();
            lblTdeeSub = new Label();
            lblTdeeVal = new Label();
            lblTdeeTitle = new Label();
            pnlTargetCal = new Panel();
            lblTargetCalSub = new Label();
            lblTargetCalVal = new Label();
            lblTargetCalTitle = new Label();
            lblGoalCardTitle = new Label();
            lblGoalCardSub = new Label();
            lblBmiTag = new Label();
            pnlMain.SuspendLayout();
            pnlSurveyView.SuspendLayout();
            tlpSurveyContent.SuspendLayout();
            pnlSurveyLeft.SuspendLayout();
            pnlSurveyBottomActions.SuspendLayout();
            pnlSurveyRight.SuspendLayout();
            pnlLivePreviewCard.SuspendLayout();
            pnlPreviewMacroBox.SuspendLayout();
            pnlPreviewStatsList.SuspendLayout();
            pnlPreviewBmiBox.SuspendLayout();
            pnlPreviewUserSnippet.SuspendLayout();
            pnlSurveyHeader.SuspendLayout();
            pnlProfileView.SuspendLayout();
            tlpProfile.SuspendLayout();
            pnlUserCard.SuspendLayout();
            pnlUserStatsBar.SuspendLayout();
            pnlAvatar.SuspendLayout();
            pnlNutritionGoalCard.SuspendLayout();
            tlpMetrics.SuspendLayout();
            pnlBmr.SuspendLayout();
            pnlTdee.SuspendLayout();
            pnlTargetCal.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.AutoScroll = true;
            pnlMain.BackColor = Color.FromArgb(250, 247, 240);
            pnlMain.Controls.Add(pnlSurveyView);
            pnlMain.Controls.Add(pnlProfileView);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1250, 850);
            pnlMain.TabIndex = 0;
            // 
            // pnlSurveyView
            // 
            pnlSurveyView.Controls.Add(tlpSurveyContent);
            pnlSurveyView.Controls.Add(pnlSurveyHeader);
            pnlSurveyView.Dock = DockStyle.Top;
            pnlSurveyView.Location = new Point(0, 520);
            pnlSurveyView.Name = "pnlSurveyView";
            pnlSurveyView.Padding = new Padding(30, 15, 30, 25);
            pnlSurveyView.Size = new Size(1229, 780);
            pnlSurveyView.TabIndex = 1;
            pnlSurveyView.Visible = false;
            // 
            // tlpSurveyContent
            // 
            tlpSurveyContent.ColumnCount = 2;
            tlpSurveyContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpSurveyContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpSurveyContent.Controls.Add(pnlSurveyLeft, 0, 0);
            tlpSurveyContent.Controls.Add(pnlSurveyRight, 1, 0);
            tlpSurveyContent.Dock = DockStyle.Fill;
            tlpSurveyContent.Location = new Point(30, 70);
            tlpSurveyContent.Name = "tlpSurveyContent";
            tlpSurveyContent.RowCount = 1;
            tlpSurveyContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpSurveyContent.Size = new Size(1169, 685);
            tlpSurveyContent.TabIndex = 1;
            // 
            // pnlSurveyLeft
            // 
            pnlSurveyLeft.Controls.Add(pnlSurveyStepContainer);
            pnlSurveyLeft.Controls.Add(pnlSurveyBottomActions);
            pnlSurveyLeft.Dock = DockStyle.Fill;
            pnlSurveyLeft.Location = new Point(0, 0);
            pnlSurveyLeft.Margin = new Padding(0, 0, 20, 0);
            pnlSurveyLeft.Name = "pnlSurveyLeft";
            pnlSurveyLeft.Size = new Size(681, 685);
            pnlSurveyLeft.TabIndex = 0;
            // 
            // pnlSurveyStepContainer
            // 
            pnlSurveyStepContainer.BackColor = Color.White;
            pnlSurveyStepContainer.Dock = DockStyle.Fill;
            pnlSurveyStepContainer.Location = new Point(0, 0);
            pnlSurveyStepContainer.Name = "pnlSurveyStepContainer";
            pnlSurveyStepContainer.Padding = new Padding(25);
            pnlSurveyStepContainer.Size = new Size(681, 615);
            pnlSurveyStepContainer.TabIndex = 0;
            // 
            // pnlSurveyBottomActions
            // 
            pnlSurveyBottomActions.Controls.Add(btnNextStep);
            pnlSurveyBottomActions.Controls.Add(btnPrevStep);
            pnlSurveyBottomActions.Dock = DockStyle.Bottom;
            pnlSurveyBottomActions.Location = new Point(0, 615);
            pnlSurveyBottomActions.Name = "pnlSurveyBottomActions";
            pnlSurveyBottomActions.Padding = new Padding(0, 15, 0, 0);
            pnlSurveyBottomActions.Size = new Size(681, 70);
            pnlSurveyBottomActions.TabIndex = 1;
            // 
            // btnNextStep
            // 
            btnNextStep.BackColor = Color.FromArgb(34, 76, 56);
            btnNextStep.Cursor = Cursors.Hand;
            btnNextStep.FlatAppearance.BorderSize = 0;
            btnNextStep.FlatStyle = FlatStyle.Flat;
            btnNextStep.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnNextStep.ForeColor = Color.White;
            btnNextStep.Location = new Point(145, 12);
            btnNextStep.Name = "btnNextStep";
            btnNextStep.Size = new Size(549, 46);
            btnNextStep.TabIndex = 1;
            btnNextStep.Text = "Tiếp Tục ›";
            btnNextStep.UseVisualStyleBackColor = false;
            btnNextStep.Click += btnNextStep_Click;
            // 
            // btnPrevStep
            // 
            btnPrevStep.BackColor = Color.White;
            btnPrevStep.Cursor = Cursors.Hand;
            btnPrevStep.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnPrevStep.FlatStyle = FlatStyle.Flat;
            btnPrevStep.Font = new Font("Segoe UI", 9.5F);
            btnPrevStep.ForeColor = Color.FromArgb(40, 50, 45);
            btnPrevStep.Location = new Point(0, 12);
            btnPrevStep.Name = "btnPrevStep";
            btnPrevStep.Size = new Size(130, 46);
            btnPrevStep.TabIndex = 0;
            btnPrevStep.Text = "‹ Quay lại";
            btnPrevStep.UseVisualStyleBackColor = false;
            btnPrevStep.Click += btnPrevStep_Click;
            // 
            // pnlSurveyRight
            // 
            pnlSurveyRight.Controls.Add(pnlLivePreviewCard);
            pnlSurveyRight.Dock = DockStyle.Fill;
            pnlSurveyRight.Location = new Point(701, 0);
            pnlSurveyRight.Margin = new Padding(0);
            pnlSurveyRight.Name = "pnlSurveyRight";
            pnlSurveyRight.Size = new Size(468, 685);
            pnlSurveyRight.TabIndex = 1;
            // 
            // pnlLivePreviewCard
            // 
            pnlLivePreviewCard.BackColor = Color.White;
            pnlLivePreviewCard.Controls.Add(lblPreviewDisclaimer);
            pnlLivePreviewCard.Controls.Add(pnlPreviewMacroBox);
            pnlLivePreviewCard.Controls.Add(pnlPreviewStatsList);
            pnlLivePreviewCard.Controls.Add(pnlPreviewBmiBox);
            pnlLivePreviewCard.Controls.Add(pnlPreviewUserSnippet);
            pnlLivePreviewCard.Controls.Add(lblPreviewTitle);
            pnlLivePreviewCard.Dock = DockStyle.Top;
            pnlLivePreviewCard.Location = new Point(0, 0);
            pnlLivePreviewCard.Name = "pnlLivePreviewCard";
            pnlLivePreviewCard.Padding = new Padding(20);
            pnlLivePreviewCard.Size = new Size(468, 620);
            pnlLivePreviewCard.TabIndex = 0;
            // 
            // lblPreviewDisclaimer
            // 
            lblPreviewDisclaimer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblPreviewDisclaimer.Font = new Font("Segoe UI", 7.5F, FontStyle.Italic);
            lblPreviewDisclaimer.ForeColor = Color.FromArgb(140, 140, 135);
            lblPreviewDisclaimer.Location = new Point(20, 580);
            lblPreviewDisclaimer.Name = "lblPreviewDisclaimer";
            lblPreviewDisclaimer.Padding = new Padding(0, 4, 0, 0);
            lblPreviewDisclaimer.Size = new Size(428, 25);
            lblPreviewDisclaimer.TabIndex = 7;
            lblPreviewDisclaimer.Text = "* Các chỉ số được tự động đồng bộ theo từng nấc điều chỉnh bên trái.";
            // 
            // pnlPreviewMacroBox
            // 
            pnlPreviewMacroBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlPreviewMacroBox.BackColor = Color.FromArgb(240, 248, 240);
            pnlPreviewMacroBox.Controls.Add(lblPreviewMacroBreakdown);
            pnlPreviewMacroBox.Controls.Add(pnlMacroColorBar);
            pnlPreviewMacroBox.Controls.Add(lblPreviewTargetCal);
            pnlPreviewMacroBox.Controls.Add(lblPreviewCalTitle);
            pnlPreviewMacroBox.Location = new Point(20, 417);
            pnlPreviewMacroBox.Name = "pnlPreviewMacroBox";
            pnlPreviewMacroBox.Padding = new Padding(14);
            pnlPreviewMacroBox.Size = new Size(428, 127);
            pnlPreviewMacroBox.TabIndex = 6;
            // 
            // lblPreviewMacroBreakdown
            // 
            lblPreviewMacroBreakdown.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPreviewMacroBreakdown.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblPreviewMacroBreakdown.ForeColor = Color.FromArgb(60, 70, 65);
            lblPreviewMacroBreakdown.Location = new Point(14, 92);
            lblPreviewMacroBreakdown.Name = "lblPreviewMacroBreakdown";
            lblPreviewMacroBreakdown.Size = new Size(400, 20);
            lblPreviewMacroBreakdown.TabIndex = 3;
            lblPreviewMacroBreakdown.Text = "Đạm 104g              Carb 156g              Béo 39g";
            // 
            // pnlMacroColorBar
            // 
            pnlMacroColorBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlMacroColorBar.BackColor = Color.FromArgb(190, 70, 40);
            pnlMacroColorBar.Location = new Point(14, 78);
            pnlMacroColorBar.Name = "pnlMacroColorBar";
            pnlMacroColorBar.Size = new Size(400, 8);
            pnlMacroColorBar.TabIndex = 2;
            pnlMacroColorBar.Paint += pnlMacroColorBar_Paint;
            // 
            // lblPreviewTargetCal
            // 
            lblPreviewTargetCal.AutoSize = true;
            lblPreviewTargetCal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblPreviewTargetCal.ForeColor = Color.FromArgb(34, 76, 56);
            lblPreviewTargetCal.Location = new Point(14, 30);
            lblPreviewTargetCal.Name = "lblPreviewTargetCal";
            lblPreviewTargetCal.Size = new Size(150, 41);
            lblPreviewTargetCal.TabIndex = 1;
            lblPreviewTargetCal.Text = "1389 kcal";
            // 
            // lblPreviewCalTitle
            // 
            lblPreviewCalTitle.AutoSize = true;
            lblPreviewCalTitle.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblPreviewCalTitle.ForeColor = Color.FromArgb(100, 100, 95);
            lblPreviewCalTitle.Location = new Point(14, 10);
            lblPreviewCalTitle.Name = "lblPreviewCalTitle";
            lblPreviewCalTitle.Size = new Size(180, 17);
            lblPreviewCalTitle.TabIndex = 0;
            lblPreviewCalTitle.Text = "DỰ KIẾN CALO HẰNG NGÀY";
            // 
            // pnlPreviewStatsList
            // 
            pnlPreviewStatsList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlPreviewStatsList.Controls.Add(lblPreviewWater);
            pnlPreviewStatsList.Controls.Add(lblPreviewWaterTitle);
            pnlPreviewStatsList.Controls.Add(lblPreviewTdee);
            pnlPreviewStatsList.Controls.Add(lblPreviewTdeeTitle);
            pnlPreviewStatsList.Controls.Add(lblPreviewBmr);
            pnlPreviewStatsList.Controls.Add(lblPreviewBmrTitle);
            pnlPreviewStatsList.Location = new Point(20, 269);
            pnlPreviewStatsList.Name = "pnlPreviewStatsList";
            pnlPreviewStatsList.Size = new Size(428, 126);
            pnlPreviewStatsList.TabIndex = 5;
            // 
            // lblPreviewWater
            // 
            lblPreviewWater.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPreviewWater.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPreviewWater.ForeColor = Color.FromArgb(40, 120, 200);
            lblPreviewWater.Location = new Point(252, 80);
            lblPreviewWater.Name = "lblPreviewWater";
            lblPreviewWater.Size = new Size(170, 25);
            lblPreviewWater.TabIndex = 5;
            lblPreviewWater.Text = "~1800 ml / ngày";
            lblPreviewWater.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPreviewWaterTitle
            // 
            lblPreviewWaterTitle.AutoSize = true;
            lblPreviewWaterTitle.Font = new Font("Segoe UI", 9F);
            lblPreviewWaterTitle.ForeColor = Color.FromArgb(100, 100, 95);
            lblPreviewWaterTitle.Location = new Point(10, 82);
            lblPreviewWaterTitle.Name = "lblPreviewWaterTitle";
            lblPreviewWaterTitle.Size = new Size(194, 20);
            lblPreviewWaterTitle.TabIndex = 4;
            lblPreviewWaterTitle.Text = "💧 Nước uống khuyến nghị:";
            // 
            // lblPreviewTdee
            // 
            lblPreviewTdee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPreviewTdee.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPreviewTdee.ForeColor = Color.FromArgb(30, 40, 35);
            lblPreviewTdee.Location = new Point(252, 45);
            lblPreviewTdee.Name = "lblPreviewTdee";
            lblPreviewTdee.Size = new Size(170, 25);
            lblPreviewTdee.TabIndex = 3;
            lblPreviewTdee.Text = "1889 kcal";
            lblPreviewTdee.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPreviewTdeeTitle
            // 
            lblPreviewTdeeTitle.AutoSize = true;
            lblPreviewTdeeTitle.Font = new Font("Segoe UI", 9F);
            lblPreviewTdeeTitle.ForeColor = Color.FromArgb(100, 100, 95);
            lblPreviewTdeeTitle.Location = new Point(10, 47);
            lblPreviewTdeeTitle.Name = "lblPreviewTdeeTitle";
            lblPreviewTdeeTitle.Size = new Size(198, 20);
            lblPreviewTdeeTitle.TabIndex = 2;
            lblPreviewTdeeTitle.Text = "⚡ Tiêu hao cả ngày (TDEE):";
            // 
            // lblPreviewBmr
            // 
            lblPreviewBmr.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPreviewBmr.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPreviewBmr.ForeColor = Color.FromArgb(30, 40, 35);
            lblPreviewBmr.Location = new Point(252, 10);
            lblPreviewBmr.Name = "lblPreviewBmr";
            lblPreviewBmr.Size = new Size(170, 25);
            lblPreviewBmr.TabIndex = 1;
            lblPreviewBmr.Text = "1219 kcal";
            lblPreviewBmr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPreviewBmrTitle
            // 
            lblPreviewBmrTitle.AutoSize = true;
            lblPreviewBmrTitle.Font = new Font("Segoe UI", 9F);
            lblPreviewBmrTitle.ForeColor = Color.FromArgb(100, 100, 95);
            lblPreviewBmrTitle.Location = new Point(10, 12);
            lblPreviewBmrTitle.Name = "lblPreviewBmrTitle";
            lblPreviewBmrTitle.Size = new Size(186, 20);
            lblPreviewBmrTitle.TabIndex = 0;
            lblPreviewBmrTitle.Text = "🔥 Trao đổi cơ bản (BMR):";
            // 
            // pnlPreviewBmiBox
            // 
            pnlPreviewBmiBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlPreviewBmiBox.BackColor = Color.FromArgb(252, 250, 245);
            pnlPreviewBmiBox.Controls.Add(lblPreviewBmiStatus);
            pnlPreviewBmiBox.Controls.Add(lblPreviewBmiVal);
            pnlPreviewBmiBox.Controls.Add(lblPreviewBmiTitle);
            pnlPreviewBmiBox.Location = new Point(20, 170);
            pnlPreviewBmiBox.Name = "pnlPreviewBmiBox";
            pnlPreviewBmiBox.Padding = new Padding(14);
            pnlPreviewBmiBox.Size = new Size(428, 74);
            pnlPreviewBmiBox.TabIndex = 4;
            // 
            // lblPreviewBmiStatus
            // 
            lblPreviewBmiStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPreviewBmiStatus.BackColor = Color.FromArgb(240, 248, 240);
            lblPreviewBmiStatus.BorderStyle = BorderStyle.FixedSingle;
            lblPreviewBmiStatus.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblPreviewBmiStatus.ForeColor = Color.FromArgb(34, 112, 68);
            lblPreviewBmiStatus.Location = new Point(287, 20);
            lblPreviewBmiStatus.Name = "lblPreviewBmiStatus";
            lblPreviewBmiStatus.Size = new Size(125, 34);
            lblPreviewBmiStatus.TabIndex = 2;
            lblPreviewBmiStatus.Text = "BÌNH THƯỜNG";
            lblPreviewBmiStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPreviewBmiVal
            // 
            lblPreviewBmiVal.AutoSize = true;
            lblPreviewBmiVal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblPreviewBmiVal.ForeColor = Color.FromArgb(30, 40, 35);
            lblPreviewBmiVal.Location = new Point(14, 28);
            lblPreviewBmiVal.Name = "lblPreviewBmiVal";
            lblPreviewBmiVal.Size = new Size(72, 37);
            lblPreviewBmiVal.TabIndex = 1;
            lblPreviewBmiVal.Text = "19.5";
            // 
            // lblPreviewBmiTitle
            // 
            lblPreviewBmiTitle.AutoSize = true;
            lblPreviewBmiTitle.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblPreviewBmiTitle.ForeColor = Color.FromArgb(120, 120, 115);
            lblPreviewBmiTitle.Location = new Point(14, 10);
            lblPreviewBmiTitle.Name = "lblPreviewBmiTitle";
            lblPreviewBmiTitle.Size = new Size(79, 17);
            lblPreviewBmiTitle.TabIndex = 0;
            lblPreviewBmiTitle.Text = "CHỈ SỐ BMI";
            // 
            // pnlPreviewUserSnippet
            // 
            pnlPreviewUserSnippet.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlPreviewUserSnippet.BackColor = Color.FromArgb(252, 250, 245);
            pnlPreviewUserSnippet.Controls.Add(lblPreviewUserSub);
            pnlPreviewUserSnippet.Controls.Add(lblPreviewUserName);
            pnlPreviewUserSnippet.Controls.Add(lblPreviewAvatar);
            pnlPreviewUserSnippet.Location = new Point(20, 78);
            pnlPreviewUserSnippet.Name = "pnlPreviewUserSnippet";
            pnlPreviewUserSnippet.Padding = new Padding(12);
            pnlPreviewUserSnippet.Size = new Size(428, 75);
            pnlPreviewUserSnippet.TabIndex = 3;
            // 
            // lblPreviewUserSub
            // 
            lblPreviewUserSub.AutoSize = true;
            lblPreviewUserSub.Font = new Font("Segoe UI", 8.5F);
            lblPreviewUserSub.ForeColor = Color.FromArgb(120, 120, 115);
            lblPreviewUserSub.Location = new Point(70, 42);
            lblPreviewUserSub.Name = "lblPreviewUserSub";
            lblPreviewUserSub.Size = new Size(186, 20);
            lblPreviewUserSub.TabIndex = 2;
            lblPreviewUserSub.Text = "Nữ, 24 tuổi • 160cm / 50kg";
            // 
            // lblPreviewUserName
            // 
            lblPreviewUserName.AutoSize = true;
            lblPreviewUserName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPreviewUserName.ForeColor = Color.FromArgb(30, 40, 35);
            lblPreviewUserName.Location = new Point(70, 15);
            lblPreviewUserName.Name = "lblPreviewUserName";
            lblPreviewUserName.Size = new Size(65, 25);
            lblPreviewUserName.TabIndex = 1;
            lblPreviewUserName.Text = "olodo";
            // 
            // lblPreviewAvatar
            // 
            lblPreviewAvatar.BackColor = Color.FromArgb(34, 76, 56);
            lblPreviewAvatar.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPreviewAvatar.ForeColor = Color.White;
            lblPreviewAvatar.Location = new Point(12, 12);
            lblPreviewAvatar.Name = "lblPreviewAvatar";
            lblPreviewAvatar.Size = new Size(48, 50);
            lblPreviewAvatar.TabIndex = 0;
            lblPreviewAvatar.Text = "L";
            lblPreviewAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPreviewTitle
            // 
            lblPreviewTitle.AutoSize = true;
            lblPreviewTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPreviewTitle.ForeColor = Color.FromArgb(30, 40, 35);
            lblPreviewTitle.Location = new Point(20, 33);
            lblPreviewTitle.Name = "lblPreviewTitle";
            lblPreviewTitle.Size = new Size(165, 28);
            lblPreviewTitle.TabIndex = 1;
            lblPreviewTitle.Text = "Phiếu Thể Trạng";
            // 
            // pnlSurveyHeader
            // 
            pnlSurveyHeader.Controls.Add(btnCancelSurvey);
            pnlSurveyHeader.Controls.Add(lblSurveyStepBadge);
            pnlSurveyHeader.Controls.Add(btnHomeFromSurvey);
            pnlSurveyHeader.Controls.Add(lblSurveySub);
            pnlSurveyHeader.Dock = DockStyle.Top;
            pnlSurveyHeader.Location = new Point(30, 15);
            pnlSurveyHeader.Name = "pnlSurveyHeader";
            pnlSurveyHeader.Size = new Size(1169, 55);
            pnlSurveyHeader.TabIndex = 0;
            // 
            // btnCancelSurvey
            // 
            btnCancelSurvey.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelSurvey.BackColor = Color.Red;
            btnCancelSurvey.Cursor = Cursors.Hand;
            btnCancelSurvey.FlatAppearance.BorderSize = 0;
            btnCancelSurvey.FlatStyle = FlatStyle.Flat;
            btnCancelSurvey.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancelSurvey.ForeColor = Color.White;
            btnCancelSurvey.Location = new Point(1089, 10);
            btnCancelSurvey.Name = "btnCancelSurvey";
            btnCancelSurvey.Size = new Size(80, 34);
            btnCancelSurvey.TabIndex = 5;
            btnCancelSurvey.Text = "Hủy bỏ";
            btnCancelSurvey.UseVisualStyleBackColor = false;
            btnCancelSurvey.Click += btnCancelSurvey_Click;
            // 
            // lblSurveyStepBadge
            // 
            lblSurveyStepBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSurveyStepBadge.BackColor = Color.FromArgb(240, 248, 240);
            lblSurveyStepBadge.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblSurveyStepBadge.ForeColor = Color.FromArgb(34, 76, 56);
            lblSurveyStepBadge.Location = new Point(839, 10);
            lblSurveyStepBadge.Name = "lblSurveyStepBadge";
            lblSurveyStepBadge.Size = new Size(240, 34);
            lblSurveyStepBadge.TabIndex = 4;
            lblSurveyStepBadge.Text = "Bước 1/5 : Giới tính và Độ tuổi";
            lblSurveyStepBadge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnHomeFromSurvey
            // 
            btnHomeFromSurvey.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHomeFromSurvey.BackColor = Color.White;
            btnHomeFromSurvey.Cursor = Cursors.Hand;
            btnHomeFromSurvey.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnHomeFromSurvey.FlatStyle = FlatStyle.Flat;
            btnHomeFromSurvey.Font = new Font("Segoe UI", 9F);
            btnHomeFromSurvey.ForeColor = Color.FromArgb(40, 50, 45);
            btnHomeFromSurvey.Location = new Point(719, 10);
            btnHomeFromSurvey.Name = "btnHomeFromSurvey";
            btnHomeFromSurvey.Size = new Size(110, 34);
            btnHomeFromSurvey.TabIndex = 3;
            btnHomeFromSurvey.Text = "🏠 Trang chủ";
            btnHomeFromSurvey.UseVisualStyleBackColor = false;
            btnHomeFromSurvey.Click += btnHomeFromSurvey_Click;
            // 
            // lblSurveySub
            // 
            lblSurveySub.AutoSize = true;
            lblSurveySub.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSurveySub.ForeColor = Color.Black;
            lblSurveySub.Location = new Point(15, 16);
            lblSurveySub.Name = "lblSurveySub";
            lblSurveySub.Size = new Size(251, 28);
            lblSurveySub.TabIndex = 2;
            lblSurveySub.Text = "Cập nhật chỉ số thể trạng";
            // 
            // pnlProfileView
            // 
            pnlProfileView.Controls.Add(lblPageTitle);
            pnlProfileView.Controls.Add(tlpProfile);
            pnlProfileView.Dock = DockStyle.Top;
            pnlProfileView.Location = new Point(0, 0);
            pnlProfileView.Name = "pnlProfileView";
            pnlProfileView.Padding = new Padding(30, 20, 30, 30);
            pnlProfileView.Size = new Size(1229, 520);
            pnlProfileView.TabIndex = 0;
            pnlProfileView.Paint += pnlProfileView_Paint;
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblPageTitle.ForeColor = Color.FromArgb(30, 40, 35);
            lblPageTitle.Location = new Point(30, 20);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(379, 37);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Hồ Sơ Cá Nhân và Thể Trạng";
            lblPageTitle.Click += lblPageTitle_Click;
            // 
            // tlpProfile
            // 
            tlpProfile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpProfile.ColumnCount = 2;
            tlpProfile.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350F));
            tlpProfile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpProfile.Controls.Add(pnlUserCard, 0, 0);
            tlpProfile.Controls.Add(pnlNutritionGoalCard, 1, 0);
            tlpProfile.Location = new Point(30, 75);
            tlpProfile.Name = "tlpProfile";
            tlpProfile.RowCount = 1;
            tlpProfile.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpProfile.Size = new Size(1169, 420);
            tlpProfile.TabIndex = 1;
            // 
            // pnlUserCard
            // 
            pnlUserCard.BackColor = Color.White;
            pnlUserCard.Controls.Add(btnChangePassword);
            pnlUserCard.Controls.Add(btnLogOut);
            pnlUserCard.Controls.Add(pnlUserStatsBar);
            pnlUserCard.Controls.Add(lblUserEmail);
            pnlUserCard.Controls.Add(lblUserName);
            pnlUserCard.Controls.Add(pnlAvatar);
            pnlUserCard.Dock = DockStyle.Fill;
            pnlUserCard.Location = new Point(0, 0);
            pnlUserCard.Margin = new Padding(0, 0, 20, 0);
            pnlUserCard.Name = "pnlUserCard";
            pnlUserCard.Padding = new Padding(20);
            pnlUserCard.Size = new Size(330, 420);
            pnlUserCard.TabIndex = 0;
            // 
            // btnLogOut
            // 
            btnChangePassword.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnChangePassword.BackColor = Color.White;
            btnChangePassword.Cursor = Cursors.Hand;
            btnChangePassword.FlatAppearance.BorderColor = Color.FromArgb(210, 225, 215);
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.FromArgb(34, 76, 56);
            btnChangePassword.Location = new Point(20, 312);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(290, 40);
            btnChangePassword.TabIndex = 5;
            btnChangePassword.Text = "🔒  Đổi Mật Khẩu";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // btnLogOut
            // 
            btnLogOut.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLogOut.BackColor = Color.White;
            btnLogOut.Cursor = Cursors.Hand;
            btnLogOut.FlatAppearance.BorderColor = Color.FromArgb(230, 215, 215);
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnLogOut.ForeColor = Color.FromArgb(180, 70, 70);
            btnLogOut.Location = new Point(20, 360);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(290, 40);
            btnLogOut.TabIndex = 6;
            btnLogOut.Text = "[→  Đăng Xuất Tài Khoản";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // pnlUserStatsBar
            // 
            pnlUserStatsBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlUserStatsBar.BackColor = Color.FromArgb(252, 250, 245);
            pnlUserStatsBar.Controls.Add(lblStatWeightVal);
            pnlUserStatsBar.Controls.Add(lblStatWeightTitle);
            pnlUserStatsBar.Controls.Add(lblStatHeightVal);
            pnlUserStatsBar.Controls.Add(lblStatHeightTitle);
            pnlUserStatsBar.Controls.Add(lblStatAgeVal);
            pnlUserStatsBar.Controls.Add(lblStatAgeTitle);
            pnlUserStatsBar.Location = new Point(20, 217);
            pnlUserStatsBar.Name = "pnlUserStatsBar";
            pnlUserStatsBar.Size = new Size(290, 66);
            pnlUserStatsBar.TabIndex = 4;
            // 
            // lblStatWeightVal
            // 
            lblStatWeightVal.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblStatWeightVal.ForeColor = Color.FromArgb(30, 40, 35);
            lblStatWeightVal.Location = new Point(195, 30);
            lblStatWeightVal.Name = "lblStatWeightVal";
            lblStatWeightVal.Size = new Size(90, 25);
            lblStatWeightVal.TabIndex = 5;
            lblStatWeightVal.Text = "50 kg";
            lblStatWeightVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatWeightTitle
            // 
            lblStatWeightTitle.Font = new Font("Segoe UI", 7.5F);
            lblStatWeightTitle.ForeColor = Color.FromArgb(130, 125, 120);
            lblStatWeightTitle.Location = new Point(195, 10);
            lblStatWeightTitle.Name = "lblStatWeightTitle";
            lblStatWeightTitle.Size = new Size(90, 18);
            lblStatWeightTitle.TabIndex = 4;
            lblStatWeightTitle.Text = "CÂN NẶNG";
            lblStatWeightTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatHeightVal
            // 
            lblStatHeightVal.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblStatHeightVal.ForeColor = Color.FromArgb(30, 40, 35);
            lblStatHeightVal.Location = new Point(95, 30);
            lblStatHeightVal.Name = "lblStatHeightVal";
            lblStatHeightVal.Size = new Size(95, 25);
            lblStatHeightVal.TabIndex = 3;
            lblStatHeightVal.Text = "160 cm";
            lblStatHeightVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatHeightTitle
            // 
            lblStatHeightTitle.Font = new Font("Segoe UI", 7.5F);
            lblStatHeightTitle.ForeColor = Color.FromArgb(130, 125, 120);
            lblStatHeightTitle.Location = new Point(94, 10);
            lblStatHeightTitle.Name = "lblStatHeightTitle";
            lblStatHeightTitle.Size = new Size(95, 18);
            lblStatHeightTitle.TabIndex = 2;
            lblStatHeightTitle.Text = "CHIỀU CAO";
            lblStatHeightTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatAgeVal
            // 
            lblStatAgeVal.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblStatAgeVal.ForeColor = Color.FromArgb(30, 40, 35);
            lblStatAgeVal.Location = new Point(5, 30);
            lblStatAgeVal.Name = "lblStatAgeVal";
            lblStatAgeVal.Size = new Size(85, 25);
            lblStatAgeVal.TabIndex = 1;
            lblStatAgeVal.Text = "50 tuổi";
            lblStatAgeVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatAgeTitle
            // 
            lblStatAgeTitle.Font = new Font("Segoe UI", 7.5F);
            lblStatAgeTitle.ForeColor = Color.FromArgb(130, 125, 120);
            lblStatAgeTitle.Location = new Point(5, 10);
            lblStatAgeTitle.Name = "lblStatAgeTitle";
            lblStatAgeTitle.Size = new Size(85, 18);
            lblStatAgeTitle.TabIndex = 0;
            lblStatAgeTitle.Text = "TUỔI";
            lblStatAgeTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserEmail
            // 
            lblUserEmail.Anchor = AnchorStyles.Top;
            lblUserEmail.Font = new Font("Segoe UI", 9F);
            lblUserEmail.ForeColor = Color.FromArgb(120, 120, 115);
            lblUserEmail.Location = new Point(15, 180);
            lblUserEmail.Name = "lblUserEmail";
            lblUserEmail.Size = new Size(300, 22);
            lblUserEmail.TabIndex = 2;
            lblUserEmail.Text = "olodo@kitfitness.vn";
            lblUserEmail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            lblUserName.Anchor = AnchorStyles.Top;
            lblUserName.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblUserName.ForeColor = Color.FromArgb(30, 40, 35);
            lblUserName.Location = new Point(15, 142);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(300, 35);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "olodo";
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAvatar
            // 
            pnlAvatar.Anchor = AnchorStyles.Top;
            pnlAvatar.BackColor = Color.FromArgb(235, 248, 240);
            pnlAvatar.Controls.Add(lblAvatarCheck);
            pnlAvatar.Controls.Add(lblAvatarInitial);
            pnlAvatar.Location = new Point(115, 25);
            pnlAvatar.Name = "pnlAvatar";
            pnlAvatar.Size = new Size(100, 100);
            pnlAvatar.TabIndex = 0;
            // 
            // lblAvatarCheck
            // 
            lblAvatarCheck.BackColor = Color.FromArgb(34, 76, 56);
            lblAvatarCheck.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAvatarCheck.ForeColor = Color.White;
            lblAvatarCheck.Location = new Point(72, 72);
            lblAvatarCheck.Name = "lblAvatarCheck";
            lblAvatarCheck.Size = new Size(26, 26);
            lblAvatarCheck.TabIndex = 1;
            lblAvatarCheck.Text = "✓";
            lblAvatarCheck.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAvatarInitial
            // 
            lblAvatarInitial.Dock = DockStyle.Fill;
            lblAvatarInitial.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblAvatarInitial.ForeColor = Color.FromArgb(34, 76, 56);
            lblAvatarInitial.Location = new Point(0, 0);
            lblAvatarInitial.Name = "lblAvatarInitial";
            lblAvatarInitial.Size = new Size(100, 100);
            lblAvatarInitial.TabIndex = 0;
            lblAvatarInitial.Text = "L";
            lblAvatarInitial.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlNutritionGoalCard
            // 
            pnlNutritionGoalCard.BackColor = Color.White;
            pnlNutritionGoalCard.Controls.Add(btnStartSurvey);
            pnlNutritionGoalCard.Controls.Add(tlpMetrics);
            pnlNutritionGoalCard.Controls.Add(lblGoalCardTitle);
            pnlNutritionGoalCard.Controls.Add(lblGoalCardSub);
            pnlNutritionGoalCard.Controls.Add(lblBmiTag);
            pnlNutritionGoalCard.Dock = DockStyle.Fill;
            pnlNutritionGoalCard.Location = new Point(353, 3);
            pnlNutritionGoalCard.Name = "pnlNutritionGoalCard";
            pnlNutritionGoalCard.Padding = new Padding(25);
            pnlNutritionGoalCard.Size = new Size(813, 414);
            pnlNutritionGoalCard.TabIndex = 1;
            // 
            // btnStartSurvey
            // 
            btnStartSurvey.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnStartSurvey.BackColor = Color.FromArgb(34, 76, 56);
            btnStartSurvey.Cursor = Cursors.Hand;
            btnStartSurvey.FlatAppearance.BorderSize = 0;
            btnStartSurvey.FlatStyle = FlatStyle.Flat;
            btnStartSurvey.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnStartSurvey.ForeColor = Color.White;
            btnStartSurvey.Location = new Point(25, 339);
            btnStartSurvey.Name = "btnStartSurvey";
            btnStartSurvey.Size = new Size(763, 52);
            btnStartSurvey.TabIndex = 4;
            btnStartSurvey.Text = "Thiết Lập Lại Mục Tiêu và TDEE (Chạy Lại Khảo Sát)";
            btnStartSurvey.UseVisualStyleBackColor = false;
            btnStartSurvey.Click += btnStartSurvey_Click;
            // 
            // tlpMetrics
            // 
            tlpMetrics.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpMetrics.ColumnCount = 3;
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tlpMetrics.Controls.Add(pnlBmr, 0, 0);
            tlpMetrics.Controls.Add(pnlTdee, 1, 0);
            tlpMetrics.Controls.Add(pnlTargetCal, 2, 0);
            tlpMetrics.Location = new Point(25, 120);
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.RowCount = 1;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetrics.Size = new Size(763, 180);
            tlpMetrics.TabIndex = 3;
            // 
            // pnlBmr
            // 
            pnlBmr.BackColor = Color.FromArgb(250, 248, 242);
            pnlBmr.Controls.Add(lblBmrSub);
            pnlBmr.Controls.Add(lblBmrVal);
            pnlBmr.Controls.Add(lblBmrTitle);
            pnlBmr.Dock = DockStyle.Fill;
            pnlBmr.Location = new Point(0, 0);
            pnlBmr.Margin = new Padding(0, 0, 15, 0);
            pnlBmr.Name = "pnlBmr";
            pnlBmr.Padding = new Padding(16);
            pnlBmr.Size = new Size(239, 180);
            pnlBmr.TabIndex = 0;
            // 
            // lblBmrSub
            // 
            lblBmrSub.AutoSize = true;
            lblBmrSub.Font = new Font("Segoe UI", 8.5F);
            lblBmrSub.ForeColor = Color.FromArgb(120, 120, 115);
            lblBmrSub.Location = new Point(16, 120);
            lblBmrSub.Name = "lblBmrSub";
            lblBmrSub.Size = new Size(184, 20);
            lblBmrSub.TabIndex = 2;
            lblBmrSub.Text = "Lượng calo duy trì sự sống";
            // 
            // lblBmrVal
            // 
            lblBmrVal.AutoSize = true;
            lblBmrVal.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblBmrVal.ForeColor = Color.FromArgb(30, 40, 35);
            lblBmrVal.Location = new Point(16, 55);
            lblBmrVal.Name = "lblBmrVal";
            lblBmrVal.Size = new Size(185, 50);
            lblBmrVal.TabIndex = 1;
            lblBmrVal.Text = "1219 kcal";
            // 
            // lblBmrTitle
            // 
            lblBmrTitle.AutoSize = true;
            lblBmrTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblBmrTitle.ForeColor = Color.FromArgb(120, 115, 110);
            lblBmrTitle.Location = new Point(16, 18);
            lblBmrTitle.Name = "lblBmrTitle";
            lblBmrTitle.Size = new Size(177, 20);
            lblBmrTitle.TabIndex = 0;
            lblBmrTitle.Text = "Năng lượng nghỉ (BMR)";
            // 
            // pnlTdee
            // 
            pnlTdee.BackColor = Color.FromArgb(250, 248, 242);
            pnlTdee.Controls.Add(lblTdeeSub);
            pnlTdee.Controls.Add(lblTdeeVal);
            pnlTdee.Controls.Add(lblTdeeTitle);
            pnlTdee.Dock = DockStyle.Fill;
            pnlTdee.Location = new Point(254, 0);
            pnlTdee.Margin = new Padding(0, 0, 15, 0);
            pnlTdee.Name = "pnlTdee";
            pnlTdee.Padding = new Padding(16);
            pnlTdee.Size = new Size(239, 180);
            pnlTdee.TabIndex = 1;
            // 
            // lblTdeeSub
            // 
            lblTdeeSub.AutoSize = true;
            lblTdeeSub.Font = new Font("Segoe UI", 8.5F);
            lblTdeeSub.ForeColor = Color.FromArgb(120, 120, 115);
            lblTdeeSub.Location = new Point(16, 120);
            lblTdeeSub.Name = "lblTdeeSub";
            lblTdeeSub.Size = new Size(198, 20);
            lblTdeeSub.TabIndex = 2;
            lblTdeeSub.Text = "Calo tiêu hao gồm vận động";
            // 
            // lblTdeeVal
            // 
            lblTdeeVal.AutoSize = true;
            lblTdeeVal.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTdeeVal.ForeColor = Color.FromArgb(30, 40, 35);
            lblTdeeVal.Location = new Point(16, 55);
            lblTdeeVal.Name = "lblTdeeVal";
            lblTdeeVal.Size = new Size(185, 50);
            lblTdeeVal.TabIndex = 1;
            lblTdeeVal.Text = "1889 kcal";
            // 
            // lblTdeeTitle
            // 
            lblTdeeTitle.AutoSize = true;
            lblTdeeTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTdeeTitle.ForeColor = Color.FromArgb(120, 115, 110);
            lblTdeeTitle.Location = new Point(16, 18);
            lblTdeeTitle.Name = "lblTdeeTitle";
            lblTdeeTitle.Size = new Size(159, 20);
            lblTdeeTitle.TabIndex = 0;
            lblTdeeTitle.Text = "Tiêu hao ngày (TDEE)";
            // 
            // pnlTargetCal
            // 
            pnlTargetCal.BackColor = Color.FromArgb(240, 248, 240);
            pnlTargetCal.Controls.Add(lblTargetCalSub);
            pnlTargetCal.Controls.Add(lblTargetCalVal);
            pnlTargetCal.Controls.Add(lblTargetCalTitle);
            pnlTargetCal.Dock = DockStyle.Fill;
            pnlTargetCal.Location = new Point(508, 0);
            pnlTargetCal.Margin = new Padding(0);
            pnlTargetCal.Name = "pnlTargetCal";
            pnlTargetCal.Padding = new Padding(16);
            pnlTargetCal.Size = new Size(255, 180);
            pnlTargetCal.TabIndex = 2;
            // 
            // lblTargetCalSub
            // 
            lblTargetCalSub.AutoSize = true;
            lblTargetCalSub.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTargetCalSub.ForeColor = Color.FromArgb(46, 117, 89);
            lblTargetCalSub.Location = new Point(16, 120);
            lblTargetCalSub.Name = "lblTargetCalSub";
            lblTargetCalSub.Size = new Size(98, 20);
            lblTargetCalSub.TabIndex = 2;
            lblTargetCalSub.Text = "Để đạt 47 kg";
            // 
            // lblTargetCalVal
            // 
            lblTargetCalVal.AutoSize = true;
            lblTargetCalVal.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTargetCalVal.ForeColor = Color.FromArgb(34, 76, 56);
            lblTargetCalVal.Location = new Point(16, 55);
            lblTargetCalVal.Name = "lblTargetCalVal";
            lblTargetCalVal.Size = new Size(185, 50);
            lblTargetCalVal.TabIndex = 1;
            lblTargetCalVal.Text = "1389 kcal";
            // 
            // lblTargetCalTitle
            // 
            lblTargetCalTitle.AutoSize = true;
            lblTargetCalTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTargetCalTitle.ForeColor = Color.FromArgb(46, 117, 89);
            lblTargetCalTitle.Location = new Point(16, 18);
            lblTargetCalTitle.Name = "lblTargetCalTitle";
            lblTargetCalTitle.Size = new Size(148, 20);
            lblTargetCalTitle.TabIndex = 0;
            lblTargetCalTitle.Text = "Calo Mục Tiêu Ngày";
            // 
            // lblGoalCardTitle
            // 
            lblGoalCardTitle.AutoSize = true;
            lblGoalCardTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblGoalCardTitle.ForeColor = Color.FromArgb(30, 40, 35);
            lblGoalCardTitle.Location = new Point(25, 48);
            lblGoalCardTitle.Name = "lblGoalCardTitle";
            lblGoalCardTitle.Size = new Size(483, 32);
            lblGoalCardTitle.TabIndex = 2;
            lblGoalCardTitle.Text = "Mục tiêu calo và Chuyển hóa năng lượng";
            // 
            // lblGoalCardSub
            // 
            lblGoalCardSub.AutoSize = true;
            lblGoalCardSub.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            lblGoalCardSub.ForeColor = Color.FromArgb(120, 115, 110);
            lblGoalCardSub.Location = new Point(25, 22);
            lblGoalCardSub.Name = "lblGoalCardSub";
            lblGoalCardSub.Size = new Size(192, 17);
            lblGoalCardSub.TabIndex = 1;
            lblGoalCardSub.Text = "CHỈ SỐ SỨC KHỎE KHOA HỌC";
            // 
            // lblBmiTag
            // 
            lblBmiTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBmiTag.BackColor = Color.FromArgb(254, 248, 235);
            lblBmiTag.BorderStyle = BorderStyle.FixedSingle;
            lblBmiTag.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblBmiTag.ForeColor = Color.FromArgb(180, 110, 20);
            lblBmiTag.Location = new Point(593, 20);
            lblBmiTag.Name = "lblBmiTag";
            lblBmiTag.Size = new Size(195, 32);
            lblBmiTag.TabIndex = 0;
            lblBmiTag.Text = "BMI: 19.5 (BÌNH THƯỜNG)";
            lblBmiTag.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Name = "ucProfile";
            Size = new Size(1250, 850);
            pnlMain.ResumeLayout(false);
            pnlSurveyView.ResumeLayout(false);
            tlpSurveyContent.ResumeLayout(false);
            pnlSurveyLeft.ResumeLayout(false);
            pnlSurveyBottomActions.ResumeLayout(false);
            pnlSurveyRight.ResumeLayout(false);
            pnlLivePreviewCard.ResumeLayout(false);
            pnlLivePreviewCard.PerformLayout();
            pnlPreviewMacroBox.ResumeLayout(false);
            pnlPreviewMacroBox.PerformLayout();
            pnlPreviewStatsList.ResumeLayout(false);
            pnlPreviewStatsList.PerformLayout();
            pnlPreviewBmiBox.ResumeLayout(false);
            pnlPreviewBmiBox.PerformLayout();
            pnlPreviewUserSnippet.ResumeLayout(false);
            pnlPreviewUserSnippet.PerformLayout();
            pnlSurveyHeader.ResumeLayout(false);
            pnlSurveyHeader.PerformLayout();
            pnlProfileView.ResumeLayout(false);
            pnlProfileView.PerformLayout();
            tlpProfile.ResumeLayout(false);
            pnlUserCard.ResumeLayout(false);
            pnlUserStatsBar.ResumeLayout(false);
            pnlAvatar.ResumeLayout(false);
            pnlNutritionGoalCard.ResumeLayout(false);
            pnlNutritionGoalCard.PerformLayout();
            tlpMetrics.ResumeLayout(false);
            pnlBmr.ResumeLayout(false);
            pnlBmr.PerformLayout();
            pnlTdee.ResumeLayout(false);
            pnlTdee.PerformLayout();
            pnlTargetCal.ResumeLayout(false);
            pnlTargetCal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlProfileView;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.TableLayoutPanel tlpProfile;
        private System.Windows.Forms.Panel pnlUserCard;
        private System.Windows.Forms.Panel pnlAvatar;
        private System.Windows.Forms.Label lblAvatarInitial;
        private System.Windows.Forms.Label lblAvatarCheck;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel pnlUserStatsBar;
        private System.Windows.Forms.Label lblStatAgeTitle;
        private System.Windows.Forms.Label lblStatAgeVal;
        private System.Windows.Forms.Label lblStatHeightTitle;
        private System.Windows.Forms.Label lblStatHeightVal;
        private System.Windows.Forms.Label lblStatWeightTitle;
        private System.Windows.Forms.Label lblStatWeightVal;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Panel pnlNutritionGoalCard;
        private System.Windows.Forms.Label lblBmiTag;
        private System.Windows.Forms.Label lblGoalCardSub;
        private System.Windows.Forms.Label lblGoalCardTitle;
        private System.Windows.Forms.TableLayoutPanel tlpMetrics;
        private System.Windows.Forms.Panel pnlBmr;
        private System.Windows.Forms.Label lblBmrTitle;
        private System.Windows.Forms.Label lblBmrVal;
        private System.Windows.Forms.Label lblBmrSub;
        private System.Windows.Forms.Panel pnlTdee;
        private System.Windows.Forms.Label lblTdeeTitle;
        private System.Windows.Forms.Label lblTdeeVal;
        private System.Windows.Forms.Label lblTdeeSub;
        private System.Windows.Forms.Panel pnlTargetCal;
        private System.Windows.Forms.Label lblTargetCalTitle;
        private System.Windows.Forms.Label lblTargetCalVal;
        private System.Windows.Forms.Label lblTargetCalSub;
        private System.Windows.Forms.Button btnStartSurvey;
        private System.Windows.Forms.Panel pnlSurveyView;
        private System.Windows.Forms.Panel pnlSurveyHeader;
        private System.Windows.Forms.Label lblSurveySub;
        private System.Windows.Forms.Button btnHomeFromSurvey;
        private System.Windows.Forms.Label lblSurveyStepBadge;
        private System.Windows.Forms.Button btnCancelSurvey;
        private System.Windows.Forms.TableLayoutPanel tlpSurveyContent;
        private System.Windows.Forms.Panel pnlSurveyLeft;
        private System.Windows.Forms.Panel pnlSurveyStepContainer;
        private System.Windows.Forms.Panel pnlSurveyBottomActions;
        private System.Windows.Forms.Button btnPrevStep;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Panel pnlSurveyRight;
        private System.Windows.Forms.Panel pnlLivePreviewCard;
        private System.Windows.Forms.Label lblPreviewTitle;
        private System.Windows.Forms.Panel pnlPreviewUserSnippet;
        private System.Windows.Forms.Label lblPreviewAvatar;
        private System.Windows.Forms.Label lblPreviewUserName;
        private System.Windows.Forms.Label lblPreviewUserSub;
        private System.Windows.Forms.Panel pnlPreviewBmiBox;
        private System.Windows.Forms.Label lblPreviewBmiTitle;
        private System.Windows.Forms.Label lblPreviewBmiVal;
        private System.Windows.Forms.Label lblPreviewBmiStatus;
        private System.Windows.Forms.Panel pnlPreviewStatsList;
        private System.Windows.Forms.Label lblPreviewBmrTitle;
        private System.Windows.Forms.Label lblPreviewBmr;
        private System.Windows.Forms.Label lblPreviewTdeeTitle;
        private System.Windows.Forms.Label lblPreviewTdee;
        private System.Windows.Forms.Label lblPreviewWaterTitle;
        private System.Windows.Forms.Label lblPreviewWater;
        private System.Windows.Forms.Panel pnlPreviewMacroBox;
        private System.Windows.Forms.Label lblPreviewCalTitle;
        private System.Windows.Forms.Label lblPreviewTargetCal;
        private System.Windows.Forms.Panel pnlMacroColorBar;
        private System.Windows.Forms.Label lblPreviewMacroBreakdown;
        private System.Windows.Forms.Label lblPreviewDisclaimer;
        private Label lblUserEmail;
    }
}
