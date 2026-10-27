using Kit_Fitness.Helpers;
using Kit_Fitness.Services;
using Kit_Fitness.UserControls;

namespace Kit_Fitness.Forms
{
    public partial class frmOnboarding : Form
    {
        private readonly SurveyData _surveyData = new();
        private readonly UserProfileService _profileService = new();
        private int _currentStep = 1;

        public frmOnboarding()
        {
            InitializeComponent();
            WireEvents();
            LoadStep(1);
        }

        public frmOnboarding(SurveyData initialData) : this()
        {
            _surveyData.Gender = initialData.Gender;
            _surveyData.Age = initialData.Age;
            _surveyData.Height = initialData.Height;
            _surveyData.Weight = initialData.Weight;
            _surveyData.Goal = initialData.Goal;
            _surveyData.TargetWeight = initialData.TargetWeight;
            _surveyData.ActivityLevel = initialData.ActivityLevel;
            _surveyData.WeeklyRateKg = initialData.WeeklyRateKg;
            LoadStep(1);
        }

        private void WireEvents()
        {
            btnNext.Click += BtnNext_Click;
            btnBack.Click += BtnBack_Click;
            btnSkip.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            btnStartJourney.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
        }

        private void BtnNext_Click(object? sender, EventArgs e)
        {
            if (_currentStep < 5)
            {
                LoadStep(_currentStep + 1);
            }
            else
            {
                CompleteOnboarding();
            }
        }

        private void BtnBack_Click(object? sender, EventArgs e)
        {
            if (_currentStep > 1)
            {
                LoadStep(_currentStep - 1);
            }
        }

        private void LoadStep(int step)
        {
            _currentStep = step;

            lblStepBadge.Text = step switch
            {
                1 => "Bước 1/5 : Giới tính & Độ tuổi",
                2 => "Bước 2/5 : Chiều cao & Cân nặng",
                3 => "Bước 3/5 : Định hướng mục tiêu",
                4 => "Bước 4/5 : Cường độ vận động",
                5 => "Bước 5/5 : Lộ trình Calo & Dinh dưỡng",
                _ => $"Bước {step}/5"
            };

            lblMascotSpeech.Text = step switch
            {
                1 => "Mascot Kit: \"Chào mừng bạn mới! Cho Kit biết giới tính và độ tuổi của bạn nhé!\"",
                2 => "Mascot Kit: \"Chiều cao và cân nặng sẽ giúp Kit tính chỉ số BMI tức thì cho bạn!\"",
                3 => "Mascot Kit: \"Mục tiêu của bạn là giảm mỡ nhẹ người, giữ dáng hay tăng cơ bắp?\"",
                4 => "Mascot Kit: \"Chọn mức độ vận động hằng ngày để Kit tính mức tiêu hao TDEE chuẩn nhất!\"",
                5 => "Mascot Kit: \"Woah! Lộ trình Calo và bộ 3 Macro (Đạm, Carb, Béo) đã sẵn sàng!\"",
                _ => "Mascot Kit luôn đồng hành cùng bạn!"
            };

            btnBack.Visible = (step > 1);
            btnNext.Text = (step < 5) ? "Tiếp Tục →" : "Hoàn Thành & Xem Lộ Trình ✨";

            pnlStepHost.Controls.Clear();
            pnlStepHost.SuspendLayout();

            UserControl stepCtrl = step switch
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

            pnlStepHost.Controls.Add(stepCtrl);
            pnlStepHost.ResumeLayout(true);

            UpdateLivePreview();
        }

        private void UpdateLivePreview()
        {
            var m = SurveyMetricsCalculator.Calculate(_surveyData);

            lblPreviewUserSub.Text = $"{_surveyData.Gender}, {_surveyData.Age} tuổi • {(int)_surveyData.Height}cm / {(int)_surveyData.Weight}kg";
            lblPreviewBmiVal.Text = $"BMI {m.Bmi:0.0}";
            lblPreviewBmiBadge.Text = m.BmiStatus;

            lblPreviewBmr.Text = $"🔥 Trao đổi cơ bản (BMR): {m.Bmr} kcal";
            lblPreviewTdee.Text = $"⚡ Tiêu hao cả ngày (TDEE): {m.Tdee} kcal";
            lblPreviewWater.Text = $"💧 Nước uống: ~{m.WaterMl} ml / ngày";

            lblPreviewTargetCal.Text = $"{m.TargetCal} kcal";
            lblPreviewMacros.Text = $"Đạm {m.ProteinGrams}g (30%) • Carb {m.CarbGrams}g (40%) • Béo {m.FatGrams}g (30%)";
        }

        private void CompleteOnboarding()
        {
            var m = SurveyMetricsCalculator.Calculate(_surveyData);

            try
            {
                if (AppSession.CurrentUserId > 0)
                {
                    _profileService.UpdateProfile(
                        userId: AppSession.CurrentUserId,
                        userName: AppSession.CurrentUserName,
                        age: _surveyData.Age,
                        gender: _surveyData.Gender,
                        height: _surveyData.Height,
                        weight: _surveyData.Weight,
                        activityLevel: _surveyData.ActivityLevel,
                        goal: _surveyData.Goal,
                        targetCalories: m.TargetCal,
                        targetWeightKg: (double)_surveyData.TargetWeight
                    );
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Save onboarding error: {ex.Message}");
            }

            // Hiển thị màn hình động viên / Mascot Celebration
            lblCelebBadge.Text = m.CampaignBadge;
            lblCelebTitle.Text = m.MotivationalTitle;
            lblCelebMessage.Text = m.MotivationalMessage;
            lblCelebCalNum.Text = $"{m.TargetCal:N0} Kcal / ngày";
            lblCelebMacroDetail.Text = $"Đạm {m.ProteinGrams}g (30%)   •   Tinh bột {m.CarbGrams}g (40%)   •   Chất béo {m.FatGrams}g (30%)";
            lblCelebEta.Text = m.WeeksNeeded > 0
                ? $"⏳ Dự kiến đạt đích {(int)_surveyData.TargetWeight} kg trong ~{m.WeeksNeeded} tuần ({m.EstimatedDate:dd/MM/yyyy})"
                : "🍃 Mục tiêu: Duy trì thể trạng cân bằng & Năng lượng tích cực";

            pnlCelebration.Visible = true;
            pnlCelebration.BringToFront();
        }
    }
}
