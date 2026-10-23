using Kit_Fitness.Models;

namespace Kit_Fitness.UserControls
{
    public partial class ucMealItemRow : UserControl
    {
        public ucMealItemRow()
        {
            InitializeComponent();
        }

        public Panel ContainerPanel => pnlRow;
        public Label LblNumber => lblNumber;
        public ComboBox CbFood => cbFood;
        public ComboBox CbUnit => cbUnit;
        public NumericUpDown NumWeight => numWeight;
        public NumericUpDown NumCalories => numCalories;
        public Label LblUnit => lblUnit;
        public Panel PnlTrafficLight => pnlTrafficLight;
        public Button BtnDelete => btnDelete;

        public void LoadFoods(IEnumerable<Food> foods, int rowIndex)
        {
            cbFood.Items.Clear();
            foreach (Food food in foods)
            {
                cbFood.Items.Add(food);
            }

            if (cbFood.Items.Count > 0)
            {
                cbFood.SelectedIndex = rowIndex - 1 >= 0 && rowIndex - 1 < cbFood.Items.Count
                    ? rowIndex - 1
                    : 0;
            }

            numWeight.Value = rowIndex switch
            {
                1 => 150,
                2 => 120,
                _ => 100
            };
        }

        private void pnlTrafficLight_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var (dotColor, calText) = pnlTrafficLight.Tag is ValueTuple<Color, string> info
                ? info
                : (Color.FromArgb(46, 125, 50), "0 cal");

            using var brush = new SolidBrush(dotColor);
            e.Graphics.FillEllipse(brush, 7, 9, 10, 10);

            using var textBrush = new SolidBrush(dotColor);
            using var font = new Font("Segoe UI Semibold", 8.2F, FontStyle.Bold);
            e.Graphics.DrawString(calText, font, textBrush, 21, 6);
        }

        private void pnlRow_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
