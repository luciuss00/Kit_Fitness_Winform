using Kit_Fitness.Helpers;

namespace Kit_Fitness.UserControls
{
    public partial class ucSurveyStep5 : UserControl
    {
        private SurveyData _data;

        public ucSurveyStep5()
        {
            InitializeComponent();
            _data = new SurveyData();
        }

        public ucSurveyStep5(SurveyData data) : this()
        {
            _data = data;
            BindData();
        }

        public void BindData()
        {
            var m = SurveyMetricsCalculator.Calculate(_data);

            // Subtitle
            string shortActivity = GetShortActivityName(_data.ActivityLevel);
            lblSub.Text = $"Để hoàn thành mục tiêu: {_data.Goal} (Đích: {(int)_data.TargetWeight} kg) với cường độ {shortActivity}.";

            // Calorie display
            lblCalNum.Text = m.TargetCal.ToString();
            int numW = lblCalNum.PreferredWidth;
            int unitW = lblCalUnit.PreferredWidth;
            int startX = Math.Max(0, (610 - (numW + unitW + 8)) / 2);
            lblCalNum.Location = new Point(startX, 0);
            lblCalUnit.Location = new Point(startX + numW + 8, 22);

            // Diff
            if (_data.Goal.Contains("Giảm mỡ"))
            {
                int deficit = m.Tdee - m.TargetCal;
                lblDiff.Text = $"Thâm hụt {deficit} kcal/ngày so với mức duy trì (TDEE: {m.Tdee} kcal)";
            }
            else if (_data.Goal.Contains("Tăng cân"))
            {
                int surplus = m.TargetCal - m.Tdee;
                lblDiff.Text = $"Dư thừa {surplus} kcal/ngày so với mức duy trì (TDEE: {m.Tdee} kcal)";
            }
            else
            {
                lblDiff.Text = $"Cân bằng theo mức tiêu hao duy trì (TDEE: {m.Tdee} kcal)";
            }

            // Macros
            lblProteinVal.Text = $"{m.ProteinGrams}g";
            lblCarbVal.Text = $"{m.CarbGrams}g";
            lblFatVal.Text = $"{m.FatGrams}g";

            // Summary
            lblSummary.Text = $"BMR Cơ Bản: {m.Bmr} kcal     •     TDEE Duy Trì: {m.Tdee} kcal     •     Nước Tối Thiểu: {m.WaterMl} ml";
        }

        private string GetShortActivityName(string? activity)
        {
            if (string.IsNullOrEmpty(activity)) return "Vận động vừa phải";
            int idx = activity.IndexOf('(');
            return idx > 0 ? activity.Substring(0, idx).Trim() : activity;
        }
    }
}
