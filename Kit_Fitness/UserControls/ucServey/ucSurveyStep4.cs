using Kit_Fitness.Helpers;

namespace Kit_Fitness.UserControls
{
    public partial class ucSurveyStep4 : UserControl
    {
        private SurveyData _data;
        public event EventHandler? DataChanged;

        public ucSurveyStep4()
        {
            InitializeComponent();
            _data = new SurveyData();
            WireEvents();
        }

        public ucSurveyStep4(SurveyData data) : this()
        {
            _data = data;
            BindData();
        }

        private void WireEvents()
        {
            // Act 1
            pnlAct1.Click += (s, e) => SelectActivity("Ít vận động (Ngồi nhiều)");
            lblAct1Title.Click += (s, e) => SelectActivity("Ít vận động (Ngồi nhiều)");
            lblAct1Mult.Click += (s, e) => SelectActivity("Ít vận động (Ngồi nhiều)");
            lblAct1Desc.Click += (s, e) => SelectActivity("Ít vận động (Ngồi nhiều)");

            // Act 2
            pnlAct2.Click += (s, e) => SelectActivity("Vận động nhẹ nhàng");
            lblAct2Title.Click += (s, e) => SelectActivity("Vận động nhẹ nhàng");
            lblAct2Mult.Click += (s, e) => SelectActivity("Vận động nhẹ nhàng");
            lblAct2Desc.Click += (s, e) => SelectActivity("Vận động nhẹ nhàng");

            // Act 3
            pnlAct3.Click += (s, e) => SelectActivity("Vận động vừa phải (Khuyên dùng)");
            lblAct3Title.Click += (s, e) => SelectActivity("Vận động vừa phải (Khuyên dùng)");
            lblAct3Mult.Click += (s, e) => SelectActivity("Vận động vừa phải (Khuyên dùng)");
            lblAct3Desc.Click += (s, e) => SelectActivity("Vận động vừa phải (Khuyên dùng)");

            // Act 4
            pnlAct4.Click += (s, e) => SelectActivity("Năng động & Cường độ cao");
            lblAct4Title.Click += (s, e) => SelectActivity("Năng động & Cường độ cao");
            lblAct4Mult.Click += (s, e) => SelectActivity("Năng động & Cường độ cao");
            lblAct4Desc.Click += (s, e) => SelectActivity("Năng động & Cường độ cao");
        }

        public void BindData()
        {
            SelectActivity(_data.ActivityLevel ?? "Vận động vừa phải (Khuyên dùng)");
        }

        private void SelectActivity(string act)
        {
            _data.ActivityLevel = act;
            bool isA1 = act.Contains("Ít vận động");
            bool isA2 = act.Contains("nhẹ nhàng");
            bool isA3 = act.Contains("vừa phải");
            bool isA4 = act.Contains("Cường độ cao");

            UpdateCard(pnlAct1, lblAct1Check, isA1);
            UpdateCard(pnlAct2, lblAct2Check, isA2);
            UpdateCard(pnlAct3, lblAct3Check, isA3);
            UpdateCard(pnlAct4, lblAct4Check, isA4);

            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateCard(Panel pnl, Label check, bool selected)
        {
            pnl.BackColor = selected ? Color.FromArgb(246, 252, 248) : Color.White;
            check.Visible = selected;
        }
    }
}
