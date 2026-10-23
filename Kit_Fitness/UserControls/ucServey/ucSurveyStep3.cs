using Kit_Fitness.Helpers;

namespace Kit_Fitness.UserControls
{
    public partial class ucSurveyStep3 : UserControl
    {
        private SurveyData _data;
        public event EventHandler? DataChanged;

        public ucSurveyStep3()
        {
            InitializeComponent();
            _data = new SurveyData();
            WireEvents();
        }

        public ucSurveyStep3(SurveyData data) : this()
        {
            _data = data;
            BindData();
        }

        private void WireEvents()
        {
            // Goal 1
            pnlGoal1.Click += (s, e) => SelectGoal("Giảm mỡ & Nhẹ người");
            lblGoal1Icon.Click += (s, e) => SelectGoal("Giảm mỡ & Nhẹ người");
            lblGoal1Title.Click += (s, e) => SelectGoal("Giảm mỡ & Nhẹ người");
            lblGoal1Badge.Click += (s, e) => SelectGoal("Giảm mỡ & Nhẹ người");
            lblGoal1Desc.Click += (s, e) => SelectGoal("Giảm mỡ & Nhẹ người");

            // Goal 2
            pnlGoal2.Click += (s, e) => SelectGoal("Giữ dáng & Ăn tươi lành");
            lblGoal2Icon.Click += (s, e) => SelectGoal("Giữ dáng & Ăn tươi lành");
            lblGoal2Title.Click += (s, e) => SelectGoal("Giữ dáng & Ăn tươi lành");
            lblGoal2Badge.Click += (s, e) => SelectGoal("Giữ dáng & Ăn tươi lành");
            lblGoal2Desc.Click += (s, e) => SelectGoal("Giữ dáng & Ăn tươi lành");

            // Goal 3
            pnlGoal3.Click += (s, e) => SelectGoal("Tăng cân & Phát triển cơ");
            lblGoal3Icon.Click += (s, e) => SelectGoal("Tăng cân & Phát triển cơ");
            lblGoal3Title.Click += (s, e) => SelectGoal("Tăng cân & Phát triển cơ");
            lblGoal3Badge.Click += (s, e) => SelectGoal("Tăng cân & Phát triển cơ");
            lblGoal3Desc.Click += (s, e) => SelectGoal("Tăng cân & Phát triển cơ");

            trackTW.ValueChanged += (s, e) =>
            {
                _data.TargetWeight = trackTW.Value;
                lblTWVal.Text = $"{(int)_data.TargetWeight} kg";
                UpdateDiffLabel();
                DataChanged?.Invoke(this, EventArgs.Empty);
            };

            btnMinusTW.Click += (s, e) =>
            {
                if (_data.TargetWeight > 35)
                {
                    _data.TargetWeight--;
                    trackTW.Value = (int)_data.TargetWeight;
                }
            };

            btnPlusTW.Click += (s, e) =>
            {
                if (_data.TargetWeight < 120)
                {
                    _data.TargetWeight++;
                    trackTW.Value = (int)_data.TargetWeight;
                }
            };
        }

        public void BindData()
        {
            SelectGoal(_data.Goal ?? "Giảm mỡ & Nhẹ người");
            trackTW.Value = Math.Max(35, Math.Min(120, (int)_data.TargetWeight));
            lblTWVal.Text = $"{(int)_data.TargetWeight} kg";
            UpdateDiffLabel();
        }

        private void SelectGoal(string goal)
        {
            _data.Goal = goal;
            bool isG1 = goal.Contains("Giảm mỡ");
            bool isG2 = goal.Contains("Giữ dáng");
            bool isG3 = goal.Contains("Tăng cân");

            UpdateGoalCard(pnlGoal1, lblGoal1Check, isG1);
            UpdateGoalCard(pnlGoal2, lblGoal2Check, isG2);
            UpdateGoalCard(pnlGoal3, lblGoal3Check, isG3);

            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateGoalCard(Panel pnl, Label check, bool selected)
        {
            pnl.BackColor = selected ? Color.FromArgb(246, 252, 248) : Color.White;
            check.Visible = selected;
        }

        private void UpdateDiffLabel()
        {
            decimal diff = _data.Weight - _data.TargetWeight;
            if (diff > 0)
            {
                lblTWDiff.Text = $"Cần giảm {diff:0.#} kg";
                lblTWDiff.ForeColor = Color.FromArgb(34, 112, 68);
            }
            else if (diff < 0)
            {
                lblTWDiff.Text = $"Cần tăng {-diff:0.#} kg";
                lblTWDiff.ForeColor = Color.FromArgb(217, 119, 6);
            }
            else
            {
                lblTWDiff.Text = "Duy trì cân nặng hiện tại";
                lblTWDiff.ForeColor = Color.FromArgb(40, 120, 200);
            }
        }

        private void ucSurveyStep3_Load(object sender, EventArgs e)
        {

        }
    }
}
