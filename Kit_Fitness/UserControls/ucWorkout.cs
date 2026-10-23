using Kit_Fitness.Helpers;
using Kit_Fitness.Models;
using Kit_Fitness.Repositories;

namespace Kit_Fitness.UserControls
{
    public partial class ucWorkout : UserControl
    {
        private readonly WorkoutLogRepository _workoutRepository = new();
        private DateOnly _selectedDate = DateOnly.FromDateTime(DateTime.Now);

        public ucWorkout()
        {
            InitializeComponent();
            WireEvents();
            ResizeDateNavigation();
            pnlHeader.Resize += (s, e) => ResizeDateNavigation();
            LoadData();
        }

        private void WireEvents()
        {
            btnPreviousDay.Click += (s, e) =>
            {
                _selectedDate = _selectedDate.AddDays(-1);
                LoadData();
            };

            btnNextDay.Click += (s, e) =>
            {
                _selectedDate = _selectedDate.AddDays(1);
                LoadData();
            };

            btnAddWorkout.Click += (s, e) => AddWorkout();
        }

        public void LoadData()
        {
            try
            {
                var today = DateOnly.FromDateTime(DateTime.Now);
                btnNextDay.Visible = _selectedDate < today;
                lblSelectedDate.Text = _selectedDate == today
                    ? $"Hôm nay, {_selectedDate:dd} Thg {_selectedDate:MM}"
                    : _selectedDate.ToString("dd 'Thg' MM yyyy");
                ResizeDateNavigation();

                var workouts = _workoutRepository.GetByUserAndDate(AppSession.CurrentUserId, _selectedDate);
                lblSummary.Text = $"{workouts.Sum(w => w.DurationMinutes)} phút • {workouts.Sum(w => w.BurnedCalories):N0} kcal";
                RenderWorkoutList(workouts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải nhật ký workout: {ex.Message}", "Workout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResizeDateNavigation()
        {
            btnPreviousDay.Left = lblTitle.Right + 18;
            btnPreviousDay.Top = 4;
            lblSelectedDate.Left = btnPreviousDay.Right + 12;
            lblSelectedDate.Top = btnPreviousDay.Top + 1;
            btnNextDay.Left = lblSelectedDate.Right + 12;
            btnNextDay.Top = btnPreviousDay.Top;
            lblSubtitle.Top = Math.Max(lblTitle.Bottom, btnPreviousDay.Bottom) + 4;
        }

        private void AddWorkout()
        {
            string exerciseName = txtExerciseName.Text.Trim();
            if (string.IsNullOrWhiteSpace(exerciseName))
            {
                MessageBox.Show("Vui lòng nhập tên môn hoặc bài tập.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtExerciseName.Focus();
                return;
            }

            try
            {
                _workoutRepository.Add(new WorkoutLog
                {
                    UserId = AppSession.CurrentUserId,
                    LogDate = _selectedDate,
                    ExerciseName = exerciseName,
                    DurationMinutes = (int)numDuration.Value,
                    BurnedCalories = (int)numCalories.Value,
                    IsDeleted = false
                });

                txtExerciseName.Clear();
                numDuration.Value = 30;
                numCalories.Value = 300;
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể lưu workout: {ex.Message}", "Workout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenderWorkoutList(List<WorkoutLog> workouts)
        {
            pnlWorkoutList.SuspendLayout();
            pnlWorkoutList.Controls.Clear();
            pnlWorkoutList.Controls.Add(lblListTitle);

            int y = 58;
            if (workouts.Count == 0)
            {
                var emptyLabel = new Label
                {
                    AutoSize = true,
                    ForeColor = Color.FromArgb(120, 120, 115),
                    Font = new Font("Segoe UI", 9.5F),
                    Location = new Point(5, y),
                    Text = "Chưa có buổi tập nào trong ngày này. Hãy bắt đầu ngay!"
                };
                pnlWorkoutList.Controls.Add(emptyLabel);
            }
            else
            {
                foreach (var workout in workouts)
                {
                    var card = CreateWorkoutCard(workout);
                    card.Location = new Point(5, y);
                    card.Width = Math.Max(300, pnlWorkoutList.ClientSize.Width - 25);
                    PositionCaloriesLabel(card);
                    pnlWorkoutList.Controls.Add(card);
                    y += card.Height + 10;
                }
            }

            pnlWorkoutList.ResumeLayout(true);
        }

        private Panel CreateWorkoutCard(WorkoutLog workout)
        {
            var card = new Panel
            {
                BackColor = Color.White,
                Height = 70,
                Padding = new Padding(14),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            var nameLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 50, 45),
                Location = new Point(14, 12),
                Text = workout.ExerciseName
            };

            var detailLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(110, 110, 105),
                Location = new Point(14, 39),
                Text = $"{workout.DurationMinutes} phút"
            };

            var caloriesLabel = new Label
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(190, 110, 20),
                Location = new Point(Math.Max(150, card.Width - 145), 25),
                Text = $"🔥 {workout.BurnedCalories:N0} kcal"
            };

            card.Controls.Add(nameLabel);
            card.Controls.Add(detailLabel);
            card.Controls.Add(caloriesLabel);
            card.Resize += (s, e) => PositionCaloriesLabel(card);
            return card;
        }

        private static void PositionCaloriesLabel(Panel card)
        {
            var caloriesLabel = card.Controls.OfType<Label>().LastOrDefault();
            if (caloriesLabel != null)
            {
                caloriesLabel.Left = Math.Max(14, card.ClientSize.Width - caloriesLabel.Width - 14);
            }
        }
    }
}
