using Kit_Fitness.Helpers;

namespace Kit_Fitness.UserControls
{
    public partial class ucSurveyStep2 : UserControl
    {
        private SurveyData _data;
        public event EventHandler? DataChanged;

        public ucSurveyStep2()
        {
            InitializeComponent();
            _data = new SurveyData();
            WireEvents();
        }

        public ucSurveyStep2(SurveyData data) : this()
        {
            _data = data;
            BindData();
        }

        private void WireEvents()
        {
            trackH.ValueChanged += (s, e) =>
            {
                _data.Height = trackH.Value;
                lblHeightVal.Text = $"{(int)_data.Height} cm";
                UpdatePresetPills();
                DataChanged?.Invoke(this, EventArgs.Empty);
            };

            btnMinusH.Click += (s, e) =>
            {
                if (_data.Height > 120)
                {
                    _data.Height--;
                    trackH.Value = (int)_data.Height;
                }
            };

            btnPlusH.Click += (s, e) =>
            {
                if (_data.Height < 210)
                {
                    _data.Height++;
                    trackH.Value = (int)_data.Height;
                }
            };

            // Preset Buttons
            btnH150.Click += (s, e) => SetHeight(150);
            btnH155.Click += (s, e) => SetHeight(155);
            btnH160.Click += (s, e) => SetHeight(160);
            btnH165.Click += (s, e) => SetHeight(165);
            btnH170.Click += (s, e) => SetHeight(170);
            btnH175.Click += (s, e) => SetHeight(175);
            btnH180.Click += (s, e) => SetHeight(180);

            trackW.ValueChanged += (s, e) =>
            {
                _data.Weight = trackW.Value;
                lblWeightVal.Text = $"{(int)_data.Weight} kg";
                DataChanged?.Invoke(this, EventArgs.Empty);
            };

            btnMinusW.Click += (s, e) =>
            {
                if (_data.Weight > 35)
                {
                    _data.Weight--;
                    trackW.Value = (int)_data.Weight;
                }
            };

            btnPlusW.Click += (s, e) =>
            {
                if (_data.Weight < 140)
                {
                    _data.Weight++;
                    trackW.Value = (int)_data.Weight;
                }
            };
        }

        public void BindData()
        {
            trackH.Value = Math.Max(120, Math.Min(210, (int)_data.Height));
            lblHeightVal.Text = $"{(int)_data.Height} cm";

            trackW.Value = Math.Max(35, Math.Min(140, (int)_data.Weight));
            lblWeightVal.Text = $"{(int)_data.Weight} kg";

            UpdatePresetPills();
        }

        private void SetHeight(int h)
        {
            _data.Height = h;
            trackH.Value = h;
            lblHeightVal.Text = $"{h} cm";
            UpdatePresetPills();
            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        private void UpdatePresetPills()
        {
            int currentH = (int)_data.Height;
            HighlightPreset(btnH150, currentH == 150);
            HighlightPreset(btnH155, currentH == 155);
            HighlightPreset(btnH160, currentH == 160);
            HighlightPreset(btnH165, currentH == 165);
            HighlightPreset(btnH170, currentH == 170);
            HighlightPreset(btnH175, currentH == 175);
            HighlightPreset(btnH180, currentH == 180);
        }

        private void HighlightPreset(Button btn, bool active)
        {
            btn.BackColor = active ? Color.FromArgb(34, 76, 56) : Color.White;
            btn.ForeColor = active ? Color.White : Color.FromArgb(60, 70, 65);
        }
    }
}
