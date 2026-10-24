using Kit_Fitness.Helpers;
using Kit_Fitness.Services;
using Kit_Fitness.UserControls;

namespace Kit_Fitness.Forms
{
    public partial class frmMain : Form
    {
        private readonly FridgeService _fridgeService = new();
        private int _expiringCount = 0;
        private List<FridgeItemDisplay> _expiringItems = new();
        private readonly ToolTip _tipNotification = new();

        private ucDashboard? _ucDashboard;
        private ucDiary? _ucDiary;
        private ucWorkout? _ucWorkout;
        private ucFridge? _ucPantry;
        private ucProfile? _ucProfile;

        private enum NavTab
        {
            Home,
            Diary,
            Workout,
            Pantry,
            Profile
        }

        private NavTab _currentTab = NavTab.Home;

        public frmMain()
        {
            InitializeComponent();
            SetProfileAvatarInitial();
            btnNotifications.Paint += BtnNotifications_Paint;
            WireNavigation();
            UpdateNotificationBadge();
            NavigateTo(NavTab.Home);
        }

        private void SetProfileAvatarInitial()
        {
            var userName = AppSession.CurrentUserName?.Trim();
            var nameParts = userName?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            btnProfileAvatar.Text = nameParts is null or { Length: 0 }
                ? "?"
                : char.ToUpperInvariant(nameParts[^1][0]).ToString();
        }

        private void WireNavigation()
        {
            btnNavHome.Click += (s, e) => NavigateTo(NavTab.Home);
            btnNavDiary.Click += (s, e) => NavigateTo(NavTab.Diary);
            btnNavWorkout.Click += (s, e) => NavigateTo(NavTab.Workout);
            btnNavPantry.Click += (s, e) => NavigateTo(NavTab.Pantry);
            btnNavProfile.Click += (s, e) => NavigateTo(NavTab.Profile);
            btnProfileAvatar.Click += (s, e) => NavigateTo(NavTab.Profile);

            btnQuickAdd.Click += (s, e) => OpenQuickLogMeal();

            btnNotifications.Click += (s, e) =>
            {
                using var dlg = new frmExpiringFoodNotification(_expiringItems);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    NavigateTo(NavTab.Pantry);
                }
                UpdateNotificationBadge();
            };
        }

        private void NavigateTo(NavTab tab)
        {
            _currentTab = tab;
            UpdateNavButtonsStyle(tab);

            UserControl controlToDisplay;

            switch (tab)
            {
                case NavTab.Home:
                    if (_ucDashboard == null)
                    {
                        _ucDashboard = new ucDashboard { Dock = DockStyle.Fill };
                        _ucDashboard.OnNhapMonClicked += (s, e) => OpenQuickLogMeal();
                        _ucDashboard.OnTuLanhClicked += (s, e) => NavigateTo(NavTab.Pantry);
                        _ucDashboard.OnViewTimelineClicked += (s, e) => NavigateTo(NavTab.Diary);
                    }
                    else
                    {
                        _ucDashboard.LoadData();
                    }
                    controlToDisplay = _ucDashboard;
                    break;

                case NavTab.Diary:
                    if (_ucDiary == null)
                    {
                        _ucDiary = new ucDiary { Dock = DockStyle.Fill };
                        _ucDiary.OnQuickLogRequested += (s, e) => OpenQuickLogMeal();
                    }
                    else
                    {
                        _ucDiary.LoadData();
                    }
                    controlToDisplay = _ucDiary;
                    break;

                case NavTab.Pantry:
                    if (_ucPantry == null)
                    {
                        _ucPantry = new ucFridge { Dock = DockStyle.Fill };
                    }
                    else
                    {
                        _ucPantry.LoadData();
                    }
                    controlToDisplay = _ucPantry;
                    break;

                case NavTab.Workout:
                    if (_ucWorkout == null)
                    {
                        _ucWorkout = new ucWorkout { Dock = DockStyle.Fill };
                    }
                    else
                    {
                        _ucWorkout.LoadData();
                    }
                    controlToDisplay = _ucWorkout;
                    break;

                case NavTab.Profile:
                    if (_ucProfile == null)
                    {
                        _ucProfile = new ucProfile { Dock = DockStyle.Fill };
                        _ucProfile.LogoutRequested += UcProfile_LogoutRequested;
                    }
                    else
                    {
                        _ucProfile.LoadData();
                    }
                    controlToDisplay = _ucProfile;
                    break;

                default:
                    return;
            }

            pnlContent.SuspendLayout();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(controlToDisplay);
            pnlContent.ResumeLayout(true);
            UpdateNotificationBadge();
        }

        private void UcProfile_LogoutRequested(object? sender, EventArgs e)
        {
            AppSession.CurrentUserId = 0;
            AppSession.CurrentUserName = string.Empty;
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void UpdateNavButtonsStyle(NavTab activeTab)
        {
            SetButtonStyle(btnNavHome, activeTab == NavTab.Home);
            SetButtonStyle(btnNavDiary, activeTab == NavTab.Diary);
            SetButtonStyle(btnNavWorkout, activeTab == NavTab.Workout);
            SetButtonStyle(btnNavPantry, activeTab == NavTab.Pantry);
            SetButtonStyle(btnNavProfile, activeTab == NavTab.Profile);
        }

        private void SetButtonStyle(Button btn, bool isActive)
        {
            if (isActive)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.FromArgb(34, 76, 56);
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            }
            else
            {
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.FromArgb(100, 100, 95);
                btn.FlatAppearance.BorderSize = 0;
            }
        }

        private void OpenQuickLogMeal()
        {
            using var dlg = new frmQuickLogMeal();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                RefreshCurrentControl();
            }
        }

        private void RefreshCurrentControl()
        {
            _ucDashboard?.LoadData();
            _ucDiary?.LoadData();
            _ucWorkout?.LoadData();
            _ucPantry?.LoadData();
            _ucProfile?.LoadData();
            UpdateNotificationBadge();
        }

        public void UpdateNotificationBadge()
        {
            try
            {
                long userId = AppSession.CurrentUserId;
                _expiringItems = _fridgeService.GetExpiryWarnings(userId);
                _expiringCount = _expiringItems.Count;

                if (_expiringCount > 0)
                {
                    _tipNotification.SetToolTip(btnNotifications, $"Có {_expiringCount} thực phẩm sắp/đã hết hạn cần sử dụng!");
                }
                else
                {
                    _tipNotification.SetToolTip(btnNotifications, "Không có thực phẩm nào sắp hết hạn");
                }
            }
            catch
            {
                _expiringCount = 0;
                _expiringItems.Clear();
            }

            btnNotifications.Invalidate();
        }

        private void BtnNotifications_Paint(object? sender, PaintEventArgs e)
        {
            if (_expiringCount <= 0) return;

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            string text = _expiringCount > 9 ? "9+" : _expiringCount.ToString();

            using var brush = new SolidBrush(Color.FromArgb(224, 72, 56));
            using var font = new Font("Segoe UI", 7F, FontStyle.Bold);
            using var textBrush = new SolidBrush(Color.White);

            int badgeSize = 18;
            int x = btnNotifications.Width - badgeSize - 1;
            int y = 1;

            g.FillEllipse(brush, x, y, badgeSize, badgeSize);

            using var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString(text, font, textBrush, new RectangleF(x, y + 0.5f, badgeSize, badgeSize), sf);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateNotificationBadge();
        }

        private void frmMain_OldLoad()
        {

        }
    }
}
