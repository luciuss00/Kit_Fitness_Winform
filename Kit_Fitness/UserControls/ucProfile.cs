using Kit_Fitness.Forms;
using Kit_Fitness.Helpers;
using Kit_Fitness.Models;
using Kit_Fitness.Services;

namespace Kit_Fitness.UserControls
{
    public partial class ucProfile : UserControl
    {
        private readonly UserProfileService _profileService = new();
        private User _currentUser = null!;
        private readonly SurveyData _surveyData = new();
        private int _currentStep = 1;

        public event EventHandler? LogoutRequested;

        public ucProfile()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                long userId = AppSession.CurrentUserId;
                _currentUser = _profileService.GetProfile(userId);

                // Initialize survey temp data from DB user data
                _surveyData.Gender = _currentUser.Gender ?? "Nam";
                _surveyData.Age = _currentUser.Age ?? 24;
                _surveyData.Height = _currentUser.Height ?? 160;
                _surveyData.Weight = _currentUser.Weight ?? 50;
                _surveyData.Goal = _currentUser.Goal ?? "Giảm mỡ & Nhẹ người";
                _surveyData.TargetWeight = (decimal)(_currentUser.TargetWeightKg ?? 47.0);
                _surveyData.ActivityLevel = _currentUser.ActivityLevel ?? "Vận động vừa phải (Khuyên dùng)";

                // Update Main Profile View (Image 1)
                lblUserName.Text = _currentUser.UserName ?? "olodo";
                lblAvatarInitial.Text = string.IsNullOrEmpty(lblUserName.Text) ? "L" : lblUserName.Text[0].ToString().ToUpper();
                lblUserEmail.Text = $"{_currentUser.UserName?.Replace(" ", "").ToLower() ?? "olodo"}@kitfitness.vn";

                lblStatAgeVal.Text = $"{_surveyData.Age} tuổi";
                lblStatHeightVal.Text = $"{(int)_surveyData.Height} cm";
                lblStatWeightVal.Text = $"{(int)_surveyData.Weight} kg";

                // Scientific Calculations
                var metrics = SurveyMetricsCalculator.Calculate(_surveyData);
                int targetCalories = _currentUser.TargetCalories ?? metrics.TargetCal;

                lblBmrVal.Text = $"{metrics.Bmr} kcal";
                lblTdeeVal.Text = $"{metrics.Tdee} kcal";
                lblTargetCalVal.Text = $"{targetCalories} kcal";
                lblTargetCalSub.Text = $"Để đạt {(int)_surveyData.TargetWeight} kg";

                lblBmiTag.Text = $"BMI: {metrics.Bmi:0.0} ({metrics.BmiStatus})";

                // Ensure Main Profile view is visible
                pnlProfileView.Visible = true;
                pnlSurveyView.Visible = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ucProfile LoadData error: {ex.Message}");
            }
        }

        private void StartSurvey()
        {
            pnlProfileView.Visible = false;
            pnlSurveyView.Visible = true;
            pnlSurveyView.Dock = DockStyle.Fill;
            pnlSurveyView.BringToFront();
            _currentStep = 1;
            NavigateSurveyStep(_currentStep);
        }

        private void CancelSurvey()
        {
            pnlSurveyView.Visible = false;
            pnlProfileView.Visible = true;
            pnlProfileView.Dock = DockStyle.Top;
            pnlProfileView.BringToFront();
        }

        private void NavigateSurveyStep(int step)
        {
            if (step < 1) step = 1;
            if (step > 5) step = 5;
            _currentStep = step;

            btnPrevStep.Enabled = (_currentStep > 1);
            btnNextStep.Text = (_currentStep == 5) ? "✓  Lưu Thay Đổi và Áp Dụng" : "Tiếp Tục ›";
            btnNextStep.BackColor = (_currentStep == 5) ? Color.FromArgb(27, 77, 62) : Color.FromArgb(34, 76, 56);

            lblSurveyStepBadge.Text = _currentStep switch
            {
                1 => "Bước 1/5 : Giới tính và Độ tuổi",
                2 => "Bước 2/5 : Chiều cao và Cân nặng",
                3 => "Bước 3/5 : Mục tiêu vóc dáng",
                4 => "Bước 4/5 : Cường độ vận động",
                5 => "Bước 5/5 : Lộ trình Calo Chuẩn",
                _ => "Bước 1/5"
            };

            pnlSurveyStepContainer.Controls.Clear();
            pnlSurveyStepContainer.SuspendLayout();

            UserControl stepCtrl = _currentStep switch
            {
                1 => new ucSurveyStep1(_surveyData),
                2 => new ucSurveyStep2(_surveyData),
                3 => new ucSurveyStep3(_surveyData),
                4 => new ucSurveyStep4(_surveyData),
                5 => new ucSurveyStep5(_surveyData),
                _ => new ucSurveyStep1(_surveyData)
            };

            stepCtrl.Dock = DockStyle.Fill;

            if (stepCtrl is ucSurveyStep1 s1) s1.DataChanged += (s, e) => UpdateLivePreview();
            else if (stepCtrl is ucSurveyStep2 s2) s2.DataChanged += (s, e) => UpdateLivePreview();
            else if (stepCtrl is ucSurveyStep3 s3) s3.DataChanged += (s, e) => UpdateLivePreview();
            else if (stepCtrl is ucSurveyStep4 s4) s4.DataChanged += (s, e) => UpdateLivePreview();

            pnlSurveyStepContainer.Controls.Add(stepCtrl);
            pnlSurveyStepContainer.ResumeLayout(true);
            UpdateLivePreview();
        }

        private void UpdateLivePreview()
        {
            var m = SurveyMetricsCalculator.Calculate(_surveyData);

            lblPreviewAvatar.Text = string.IsNullOrEmpty(lblUserName.Text) ? "L" : lblUserName.Text[0].ToString().ToUpper();
            lblPreviewUserName.Text = _currentUser?.UserName ?? "olodo";
            lblPreviewUserSub.Text = $"{_surveyData.Gender}, {_surveyData.Age} tuổi • {(int)_surveyData.Height}cm / {(int)_surveyData.Weight}kg";

            lblPreviewBmiVal.Text = m.Bmi.ToString("0.0");
            lblPreviewBmiStatus.Text = m.BmiStatus;

            lblPreviewBmr.Text = $"{m.Bmr} kcal";
            lblPreviewTdee.Text = $"{m.Tdee} kcal";
            lblPreviewWater.Text = $"~{m.WaterMl} ml / ngày";

            lblPreviewCalTitle.AutoSize = false;
            lblPreviewCalTitle.Location = new Point(14, 10);
            lblPreviewCalTitle.Size = new Size(pnlPreviewMacroBox.Width - 28, 18);
            lblPreviewCalTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblPreviewCalTitle.Text = "MỤC TIÊU NẠP VÀO MỖI NGÀY";

            lblPreviewTargetCal.AutoSize = false;
            lblPreviewTargetCal.Location = new Point(14, 30);
            lblPreviewTargetCal.Size = new Size(pnlPreviewMacroBox.Width - 28, 41);
            lblPreviewTargetCal.TextAlign = ContentAlignment.MiddleCenter;
            lblPreviewTargetCal.Text = $"{m.TargetCal} kcal";

            lblPreviewMacroBreakdown.TextAlign = ContentAlignment.MiddleCenter;
            lblPreviewMacroBreakdown.Text = $"Đạm {m.ProteinGrams}g              Carb {m.CarbGrams}g              Béo {m.FatGrams}g";
            lblPreviewDisclaimer.Text = "* Thông số được tính toán tự động dựa theo công thức Mifflin-St Jeor & WHO.";

            pnlMacroColorBar.Invalidate();
        }

        private void pnlMacroColorBar_Paint(object? sender, PaintEventArgs e)
        {
            int w = pnlMacroColorBar.Width;
            int h = pnlMacroColorBar.Height;
            if (w <= 0 || h <= 0) return;

            // 30% Protein, 45% Carb, 25% Fat
            int wProtein = (int)(w * 0.30);
            int wCarb = (int)(w * 0.45);
            int wFat = w - wProtein - wCarb;

            using var brProtein = new SolidBrush(Color.FromArgb(185, 28, 28)); // Đạm: Đỏ
            using var brCarb = new SolidBrush(Color.FromArgb(217, 119, 6));     // Carb: Vàng cam
            using var brFat = new SolidBrush(Color.FromArgb(31, 41, 55));       // Béo: Than tối

            e.Graphics.FillRectangle(brProtein, 0, 0, wProtein, h);
            e.Graphics.FillRectangle(brCarb, wProtein, 0, wCarb, h);
            e.Graphics.FillRectangle(brFat, wProtein + wCarb, 0, wFat, h);
        }

        private void CompleteSurveyAndSave()
        {
            try
            {
                var m = SurveyMetricsCalculator.Calculate(_surveyData);
                long userId = AppSession.CurrentUserId;

                // Save to database via Entity Framework Core through UserProfileService
                _profileService.UpdateProfile(
                    userId: userId,
                    userName: _currentUser.UserName,
                    age: _surveyData.Age,
                    gender: _surveyData.Gender,
                    height: _surveyData.Height,
                    weight: _surveyData.Weight,
                    activityLevel: _surveyData.ActivityLevel,
                    goal: _surveyData.Goal,
                    targetCalories: m.TargetCal,
                    targetWeightKg: (double)_surveyData.TargetWeight
                );

                MessageBox.Show("Đã lưu kết quả khảo sát và cập nhật chỉ số thể trạng vào CSDL thành công! 🌿", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close survey and return to main Profile view
                CancelSurvey();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu thể trạng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStartSurvey_Click(object sender, EventArgs e)
        {
            StartSurvey();
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            if (_currentStep < 5)
            {
                NavigateSurveyStep(_currentStep + 1);
            }
            else
            {
                CompleteSurveyAndSave();
            }
        }

        private void pnlProfileView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancelSurvey_Click(object sender, EventArgs e)
        {
            CancelSurvey();
        }

        private void btnHomeFromSurvey_Click(object sender, EventArgs e)
        {
            CancelSurvey();
        }

        private void btnPrevStep_Click(object sender, EventArgs e)
        {
            NavigateSurveyStep(_currentStep - 1);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            using var changePasswordForm = new frmChangePassword();
            changePasswordForm.ShowDialog(this);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã đăng xuất tài khoản an toàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LogoutRequested?.Invoke(this, EventArgs.Empty);
        }

        private void lblPageTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
