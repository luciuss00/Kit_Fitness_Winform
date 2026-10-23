using Kit_Fitness.Helpers;

namespace Kit_Fitness.UserControls
{
    public partial class ucSurveyStep1 : UserControl
    {
        private SurveyData _data;
        public event EventHandler? DataChanged;

        public ucSurveyStep1()
        {
            InitializeComponent();
            _data = new SurveyData();
            WireEvents();
        }

        public ucSurveyStep1(SurveyData data) : this()
        {
            _data = data;
            BindData();
        }

        private void WireEvents()
        {
            pnlFemale.Click += (s, e) => SelectGender("Nữ");
            lblFemaleIcon.Click += (s, e) => SelectGender("Nữ");
            lblFemaleTitle.Click += (s, e) => SelectGender("Nữ");
            lblFemaleSub.Click += (s, e) => SelectGender("Nữ");

            pnlMale.Click += (s, e) => SelectGender("Nam");
            lblMaleIcon.Click += (s, e) => SelectGender("Nam");
            lblMaleTitle.Click += (s, e) => SelectGender("Nam");
            lblMaleSub.Click += (s, e) => SelectGender("Nam");

            trackAge.ValueChanged += (s, e) =>
            {
                _data.Age = trackAge.Value;
                lblAgeVal.Text = $"{_data.Age} tuổi";
                DataChanged?.Invoke(this, EventArgs.Empty);
            };

            btnMinusAge.Click += (s, e) =>
            {
                if (_data.Age > 14)
                {
                    _data.Age--;
                    trackAge.Value = _data.Age;
                }
            };

            btnPlusAge.Click += (s, e) =>
            {
                if (_data.Age < 80)
                {
                    _data.Age++;
                    trackAge.Value = _data.Age;
                }
            };
        }

        public void BindData()
        {
            SelectGender(_data.Gender ?? "Nữ");
            trackAge.Value = Math.Max(14, Math.Min(80, _data.Age));
            lblAgeVal.Text = $"{_data.Age} tuổi";
        }

        private void SelectGender(string gender)
        {
            _data.Gender = gender;
            bool isFemale = gender == "Nữ";

            pnlFemale.BackColor = isFemale ? Color.FromArgb(246, 252, 248) : Color.White;
            pnlMale.BackColor = !isFemale ? Color.FromArgb(246, 252, 248) : Color.White;

            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ucSurveyStep1_Load(object sender, EventArgs e)
        {

        }
    }
}
