using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Kit_Fitness.Helpers;
using Kit_Fitness.Models;
using Kit_Fitness.Repositories;
using Kit_Fitness.Services;

namespace Kit_Fitness.UserControls
{
    public partial class ucWorkout : UserControl
    {
        private readonly WorkoutLogRepository _workoutRepository = new();
        private readonly UserProfileService _userProfileService = new();
        private DateOnly _selectedDate = DateOnly.FromDateTime(DateTime.Now);
        private double? _userWeightKg = 55.0;
        private bool _isUpdatingUi = false;

        private sealed class IntensityComboItem
        {
            public IntensityLevel Level { get; set; }
            public string DisplayText { get; set; } = string.Empty;
            public double Met { get; set; }
            public string Desc { get; set; } = string.Empty;

            public override string ToString() => DisplayText;
        }

        public ucWorkout()
        {
            InitializeComponent();
            LoadUserWeight();
            InitializeSportsControls();
            WireEvents();
            ResizeDateNavigation();
            pnlHeader.Resize += (s, e) => ResizeDateNavigation();
            LoadData();
        }

        private void LoadUserWeight()
        {
            try
            {
                var user = _userProfileService.GetProfile(AppSession.CurrentUserId);
                if (user?.Weight.HasValue == true && user.Weight.Value > 0)
                {
                    _userWeightKg = (double)user.Weight.Value;
                    lblUserWeightInfo.Text = $"👤 Cân nặng: {_userWeightKg.Value:0.#} kg";
                }
                else
                {
                    _userWeightKg = 55.0;
                    lblUserWeightInfo.Text = "👤 Cân nặng: 55 kg (mặc định)";
                }
            }
            catch
            {
                _userWeightKg = 55.0;
                lblUserWeightInfo.Text = "👤 Cân nặng: 55 kg (mặc định)";
            }
        }

        private void InitializeSportsControls()
        {
            _isUpdatingUi = true;

            // Nạp danh mục
            cboCategory.DataSource = SportsHelper.Categories.ToList();
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
            cboCategory.SelectedIndex = 0;

            // Nạp môn theo danh mục ban đầu
            PopulateSportsList("all");

            _isUpdatingUi = false;

            UpdateIntensityOptions();
            RecalculateCalories();
        }

        private void PopulateSportsList(string categoryId)
        {
            var sports = SportsHelper.GetByCategory(categoryId);
            cboSport.DataSource = sports;
            cboSport.DisplayMember = "ToString";

            if (sports.Count > 0)
            {
                cboSport.SelectedIndex = 0;
            }
        }

        private void UpdateIntensityOptions()
        {
            var selectedSport = cboSport.SelectedItem as SportItem;
            var currentLevel = (cboIntensity.SelectedItem as IntensityComboItem)?.Level ?? IntensityLevel.Moderate;

            var items = new List<IntensityComboItem>();

            if (selectedSport != null)
            {
                items.Add(new IntensityComboItem
                {
                    Level = IntensityLevel.Moderate,
                    DisplayText = $"Vừa - {selectedSport.Moderate.Label} (MET {selectedSport.Moderate.Met:0.#})",
                    Met = selectedSport.Moderate.Met,
                    Desc = selectedSport.Moderate.Desc
                });
                items.Add(new IntensityComboItem
                {
                    Level = IntensityLevel.Light,
                    DisplayText = $"Nhẹ - {selectedSport.Light.Label} (MET {selectedSport.Light.Met:0.#})",
                    Met = selectedSport.Light.Met,
                    Desc = selectedSport.Light.Desc
                });
                items.Add(new IntensityComboItem
                {
                    Level = IntensityLevel.Vigorous,
                    DisplayText = $"Nặng - {selectedSport.Vigorous.Label} (MET {selectedSport.Vigorous.Met:0.#})",
                    Met = selectedSport.Vigorous.Met,
                    Desc = selectedSport.Vigorous.Desc
                });
            }
            else
            {
                items.Add(new IntensityComboItem
                {
                    Level = IntensityLevel.Moderate,
                    DisplayText = "Vừa - Cường độ trung bình (MET 6.0)",
                    Met = 6.0,
                    Desc = "Vận động đều đặn, nhịp thở tăng nhẹ"
                });
                items.Add(new IntensityComboItem
                {
                    Level = IntensityLevel.Light,
                    DisplayText = "Nhẹ - Thả lỏng / Khởi động (MET 3.5)",
                    Met = 3.5,
                    Desc = "Thong thả, không tốn nhiều sức"
                });
                items.Add(new IntensityComboItem
                {
                    Level = IntensityLevel.Vigorous,
                    DisplayText = "Nặng - Dốc sức tối đa (MET 9.0)",
                    Met = 9.0,
                    Desc = "Bứt tốc, nhịp tim cao, mồ hôi nhiều"
                });
            }

            cboIntensity.DataSource = items;
            var match = items.FirstOrDefault(i => i.Level == currentLevel) ?? items[0];
            cboIntensity.SelectedItem = match;
        }

        private void RecalculateCalories()
        {
            if (_isUpdatingUi) return;

            var selectedIntensity = cboIntensity.SelectedItem as IntensityComboItem;
            double met = selectedIntensity?.Met ?? 6.0;
            int duration = (int)numDuration.Value;

            int calories = SportsHelper.CalculateBurnedCalories(met, _userWeightKg, duration);

            _isUpdatingUi = true;
            numCalories.Value = Math.Clamp(calories, numCalories.Minimum, numCalories.Maximum);
            _isUpdatingUi = false;

            string desc = selectedIntensity?.Desc ?? string.Empty;
            if (!string.IsNullOrEmpty(desc))
            {
                lblIntensityDesc.Text = $"⚡ MET {met:0.0} • {desc}";
            }
            else
            {
                lblIntensityDesc.Text = $"⚡ MET {met:0.0} • Dự tính theo cân nặng {_userWeightKg ?? 55:0.#} kg";
            }
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

            cboCategory.SelectedIndexChanged += (s, e) =>
            {
                if (_isUpdatingUi) return;
                var category = cboCategory.SelectedItem as SportCategoryItem;
                if (category != null)
                {
                    _isUpdatingUi = true;
                    PopulateSportsList(category.Id);
                    _isUpdatingUi = false;

                    OnSportSelectedChanged();
                }
            };

            cboSport.SelectedIndexChanged += (s, e) =>
            {
                if (_isUpdatingUi) return;
                OnSportSelectedChanged();
            };

            cboSport.TextChanged += (s, e) =>
            {
                if (_isUpdatingUi) return;
                RecalculateCalories();
            };

            cboIntensity.SelectedIndexChanged += (s, e) =>
            {
                if (_isUpdatingUi) return;
                RecalculateCalories();
            };

            numDuration.ValueChanged += (s, e) =>
            {
                if (_isUpdatingUi) return;
                RecalculateCalories();
            };

            btnAddWorkout.Click += (s, e) => AddWorkout();
        }

        private void OnSportSelectedChanged()
        {
            if (cboSport.SelectedItem is SportItem sport)
            {
                _isUpdatingUi = true;
                numDuration.Value = Math.Clamp(sport.DefaultDuration, numDuration.Minimum, numDuration.Maximum);
                _isUpdatingUi = false;

                UpdateIntensityOptions();
            }

            RecalculateCalories();
        }

        public void LoadData()
        {
            try
            {
                LoadUserWeight();

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
            string exerciseName = cboSport.Text.Trim();
            if (string.IsNullOrWhiteSpace(exerciseName))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập tên môn / bài tập.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSport.Focus();
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

                LoadData();
                MessageBox.Show($"Đã lưu bài tập '{exerciseName}' ({numDuration.Value} phút, {numCalories.Value:N0} kcal)!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Location = new Point(16, y),
                    Text = "Chưa có buổi tập nào trong ngày này. Hãy chọn môn thể thao ở trên để bắt đầu ngay!"
                };
                pnlWorkoutList.Controls.Add(emptyLabel);
            }
            else
            {
                foreach (var workout in workouts)
                {
                    var card = CreateWorkoutCard(workout);
                    card.Location = new Point(16, y);
                    card.Width = Math.Max(300, pnlWorkoutList.ClientSize.Width - 36);
                    PositionCardControls(card);
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
                Height = 72,
                Padding = new Padding(14),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            string emoji = SportsHelper.GetSportEmojiByName(workout.ExerciseName);
            string displayName = workout.ExerciseName.Contains(emoji) ? workout.ExerciseName : $"{emoji}  {workout.ExerciseName}";

            var nameLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 50, 45),
                Location = new Point(16, 12),
                Text = displayName
            };

            var detailLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(110, 110, 105),
                Location = new Point(16, 40),
                Text = $"{workout.DurationMinutes} phút • Ghi nhận: {workout.CreatedAt:HH:mm}"
            };

            var caloriesLabel = new Label
            {
                Name = "lblCardCalories",
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(190, 110, 20),
                Location = new Point(Math.Max(150, card.Width - 210), 24),
                Text = $"🔥 {workout.BurnedCalories:N0} kcal"
            };

            var btnDelete = new Button
            {
                Name = "btnCardDelete",
                Text = "✕",
                Size = new Size(32, 32),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                ForeColor = Color.FromArgb(170, 70, 60),
                BackColor = Color.FromArgb(254, 244, 244),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(Math.Max(200, card.Width - 48), 20)
            };
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += (s, e) =>
            {
                if (MessageBox.Show($"Bạn có muốn xóa buổi tập '{workout.ExerciseName}'?", "Xóa buổi tập", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _workoutRepository.Delete(workout.Id);
                    LoadData();
                }
            };

            card.Controls.Add(nameLabel);
            card.Controls.Add(detailLabel);
            card.Controls.Add(caloriesLabel);
            card.Controls.Add(btnDelete);
            card.Resize += (s, e) => PositionCardControls(card);
            return card;
        }

        private static void PositionCardControls(Panel card)
        {
            var btnDelete = card.Controls["btnCardDelete"];
            var caloriesLabel = card.Controls["lblCardCalories"];

            if (btnDelete != null)
            {
                btnDelete.Left = Math.Max(14, card.ClientSize.Width - btnDelete.Width - 14);
            }

            if (caloriesLabel != null)
            {
                int deleteLeft = btnDelete?.Left ?? card.ClientSize.Width;
                caloriesLabel.Left = Math.Max(14, deleteLeft - caloriesLabel.Width - 16);
            }
        }
    }
}
