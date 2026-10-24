namespace Kit_Fitness.Forms
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlNavbar = new Panel();
            pnlRightActions = new FlowLayoutPanel();
            btnProfileAvatar = new Button();
            btnNotifications = new Button();
            btnQuickAdd = new Button();
            pnlNavMenu = new FlowLayoutPanel();
            btnNavHome = new Button();
            btnNavDiary = new Button();
            btnNavWorkout = new Button();
            btnNavPantry = new Button();
            btnNavProfile = new Button();
            pnlBrand = new Panel();
            lblSlogan = new Label();
            lblBrandName = new Label();
            lblLogoCircle = new Label();
            pnlContent = new Panel();
            pnlNavbar.SuspendLayout();
            pnlRightActions.SuspendLayout();
            pnlNavMenu.SuspendLayout();
            pnlBrand.SuspendLayout();
            SuspendLayout();
            // 
            // pnlNavbar
            // 
            pnlNavbar.BackColor = Color.FromArgb(250, 247, 240);
            pnlNavbar.Controls.Add(pnlRightActions);
            pnlNavbar.Controls.Add(pnlNavMenu);
            pnlNavbar.Controls.Add(pnlBrand);
            pnlNavbar.Dock = DockStyle.Top;
            pnlNavbar.Location = new Point(0, 0);
            pnlNavbar.Name = "pnlNavbar";
            pnlNavbar.Padding = new Padding(15, 10, 15, 10);
            pnlNavbar.Size = new Size(1300, 75);
            pnlNavbar.TabIndex = 0;
            // 
            // pnlRightActions
            // 
            pnlRightActions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlRightActions.Controls.Add(btnProfileAvatar);
            pnlRightActions.Controls.Add(btnNotifications);
            pnlRightActions.Controls.Add(btnQuickAdd);
            pnlRightActions.FlowDirection = FlowDirection.RightToLeft;
            pnlRightActions.Location = new Point(1034, 14);
            pnlRightActions.Name = "pnlRightActions";
            pnlRightActions.Size = new Size(251, 46);
            pnlRightActions.TabIndex = 2;
            // 
            // btnProfileAvatar
            // 
            btnProfileAvatar.BackColor = Color.FromArgb(230, 245, 235);
            btnProfileAvatar.Cursor = Cursors.Hand;
            btnProfileAvatar.FlatAppearance.BorderSize = 0;
            btnProfileAvatar.FlatStyle = FlatStyle.Flat;
            btnProfileAvatar.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnProfileAvatar.ForeColor = Color.FromArgb(34, 76, 56);
            btnProfileAvatar.Location = new Point(209, 2);
            btnProfileAvatar.Margin = new Padding(6, 2, 0, 2);
            btnProfileAvatar.Name = "btnProfileAvatar";
            btnProfileAvatar.Size = new Size(42, 40);
            btnProfileAvatar.TabIndex = 4;
            btnProfileAvatar.Text = "L";
            btnProfileAvatar.UseVisualStyleBackColor = false;
            // 
            // btnNotifications
            // 
            btnNotifications.BackColor = Color.White;
            btnNotifications.Cursor = Cursors.Hand;
            btnNotifications.FlatAppearance.BorderColor = Color.FromArgb(230, 225, 215);
            btnNotifications.FlatStyle = FlatStyle.Flat;
            btnNotifications.Font = new Font("Segoe UI", 11F);
            btnNotifications.ForeColor = Color.FromArgb(80, 80, 80);
            btnNotifications.Location = new Point(161, 2);
            btnNotifications.Margin = new Padding(6, 2, 0, 2);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.Size = new Size(42, 40);
            btnNotifications.TabIndex = 3;
            btnNotifications.Text = "🔔";
            btnNotifications.UseVisualStyleBackColor = false;
            // 
            // btnQuickAdd
            // 
            btnQuickAdd.BackColor = Color.FromArgb(34, 76, 56);
            btnQuickAdd.Cursor = Cursors.Hand;
            btnQuickAdd.FlatAppearance.BorderSize = 0;
            btnQuickAdd.FlatStyle = FlatStyle.Flat;
            btnQuickAdd.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnQuickAdd.ForeColor = Color.White;
            btnQuickAdd.Location = new Point(19, 2);
            btnQuickAdd.Margin = new Padding(6, 2, 0, 2);
            btnQuickAdd.Name = "btnQuickAdd";
            btnQuickAdd.Size = new Size(136, 40);
            btnQuickAdd.TabIndex = 1;
            btnQuickAdd.Text = "🍴 Nhập Món";
            btnQuickAdd.UseVisualStyleBackColor = false;
            // 
            // pnlNavMenu
            // 
            pnlNavMenu.Controls.Add(btnNavHome);
            pnlNavMenu.Controls.Add(btnNavDiary);
            pnlNavMenu.Controls.Add(btnNavWorkout);
            pnlNavMenu.Controls.Add(btnNavPantry);
            pnlNavMenu.Controls.Add(btnNavProfile);
            pnlNavMenu.Location = new Point(300, 14);
            pnlNavMenu.Name = "pnlNavMenu";
            pnlNavMenu.Size = new Size(624, 48);
            pnlNavMenu.TabIndex = 1;
            // 
            // btnNavHome
            // 
            btnNavHome.BackColor = Color.White;
            btnNavHome.Cursor = Cursors.Hand;
            btnNavHome.FlatAppearance.BorderColor = Color.FromArgb(220, 215, 205);
            btnNavHome.FlatStyle = FlatStyle.Flat;
            btnNavHome.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnNavHome.ForeColor = Color.FromArgb(34, 76, 56);
            btnNavHome.Location = new Point(0, 2);
            btnNavHome.Margin = new Padding(0, 2, 8, 2);
            btnNavHome.Name = "btnNavHome";
            btnNavHome.Padding = new Padding(0, 6, 0, 0);
            btnNavHome.Size = new Size(113, 44);
            btnNavHome.TabIndex = 0;
            btnNavHome.Text = "🏠 Trang chủ";
            btnNavHome.UseVisualStyleBackColor = false;
            // 
            // btnNavDiary
            // 
            btnNavDiary.BackColor = Color.Transparent;
            btnNavDiary.Cursor = Cursors.Hand;
            btnNavDiary.FlatAppearance.BorderSize = 0;
            btnNavDiary.FlatStyle = FlatStyle.Flat;
            btnNavDiary.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnNavDiary.ForeColor = Color.FromArgb(100, 100, 95);
            btnNavDiary.Location = new Point(121, 2);
            btnNavDiary.Margin = new Padding(0, 2, 8, 2);
            btnNavDiary.Name = "btnNavDiary";
            btnNavDiary.Size = new Size(110, 40);
            btnNavDiary.TabIndex = 1;
            btnNavDiary.Text = "🍴 Nhật ký";
            btnNavDiary.UseVisualStyleBackColor = false;
            // 
            // btnNavWorkout
            // 
            btnNavWorkout.BackColor = Color.Transparent;
            btnNavWorkout.Cursor = Cursors.Hand;
            btnNavWorkout.FlatAppearance.BorderSize = 0;
            btnNavWorkout.FlatStyle = FlatStyle.Flat;
            btnNavWorkout.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnNavWorkout.ForeColor = Color.FromArgb(100, 100, 95);
            btnNavWorkout.Location = new Point(239, 2);
            btnNavWorkout.Margin = new Padding(0, 2, 8, 2);
            btnNavWorkout.Name = "btnNavWorkout";
            btnNavWorkout.Size = new Size(110, 40);
            btnNavWorkout.TabIndex = 2;
            btnNavWorkout.Text = "🏋 Workout";
            btnNavWorkout.UseVisualStyleBackColor = false;
            // 
            // btnNavPantry
            // 
            btnNavPantry.BackColor = Color.Transparent;
            btnNavPantry.Cursor = Cursors.Hand;
            btnNavPantry.FlatAppearance.BorderSize = 0;
            btnNavPantry.FlatStyle = FlatStyle.Flat;
            btnNavPantry.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnNavPantry.ForeColor = Color.FromArgb(100, 100, 95);
            btnNavPantry.Location = new Point(357, 2);
            btnNavPantry.Margin = new Padding(0, 2, 8, 2);
            btnNavPantry.Name = "btnNavPantry";
            btnNavPantry.Size = new Size(120, 40);
            btnNavPantry.TabIndex = 3;
            btnNavPantry.Text = "\U0001f9ca Tủ lạnh";
            btnNavPantry.UseVisualStyleBackColor = false;
            // 
            // btnNavProfile
            // 
            btnNavProfile.BackColor = Color.Transparent;
            btnNavProfile.Cursor = Cursors.Hand;
            btnNavProfile.FlatAppearance.BorderSize = 0;
            btnNavProfile.FlatStyle = FlatStyle.Flat;
            btnNavProfile.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnNavProfile.ForeColor = Color.FromArgb(100, 100, 95);
            btnNavProfile.Location = new Point(485, 2);
            btnNavProfile.Margin = new Padding(0, 2, 0, 2);
            btnNavProfile.Name = "btnNavProfile";
            btnNavProfile.Size = new Size(110, 40);
            btnNavProfile.TabIndex = 4;
            btnNavProfile.Text = "👤 Cá nhân";
            btnNavProfile.UseVisualStyleBackColor = false;
            // 
            // pnlBrand
            // 
            pnlBrand.Controls.Add(lblSlogan);
            pnlBrand.Controls.Add(lblBrandName);
            pnlBrand.Controls.Add(lblLogoCircle);
            pnlBrand.Dock = DockStyle.Left;
            pnlBrand.Location = new Point(15, 10);
            pnlBrand.Name = "pnlBrand";
            pnlBrand.Size = new Size(238, 55);
            pnlBrand.TabIndex = 0;
            // 
            // lblSlogan
            // 
            lblSlogan.AutoSize = true;
            lblSlogan.Font = new Font("Segoe UI", 7.8F);
            lblSlogan.ForeColor = Color.FromArgb(120, 120, 115);
            lblSlogan.Location = new Point(55, 30);
            lblSlogan.Name = "lblSlogan";
            lblSlogan.Size = new Size(172, 17);
            lblSlogan.TabIndex = 2;
            lblSlogan.Text = "Đồ ăn tươi • Chống lãng phí";
            // 
            // lblBrandName
            // 
            lblBrandName.AutoSize = true;
            lblBrandName.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblBrandName.ForeColor = Color.FromArgb(30, 40, 35);
            lblBrandName.Location = new Point(54, 8);
            lblBrandName.Name = "lblBrandName";
            lblBrandName.Size = new Size(126, 28);
            lblBrandName.TabIndex = 1;
            lblBrandName.Text = "KIT FITNESS";
            // 
            // lblLogoCircle
            // 
            lblLogoCircle.BackColor = Color.FromArgb(34, 76, 56);
            lblLogoCircle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLogoCircle.ForeColor = Color.White;
            lblLogoCircle.Location = new Point(5, 7);
            lblLogoCircle.Name = "lblLogoCircle";
            lblLogoCircle.Size = new Size(42, 40);
            lblLogoCircle.TabIndex = 0;
            lblLogoCircle.Text = "K";
            lblLogoCircle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(250, 247, 240);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 75);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1300, 775);
            pnlContent.TabIndex = 1;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 247, 240);
            ClientSize = new Size(1300, 850);
            Controls.Add(pnlContent);
            Controls.Add(pnlNavbar);
            MinimumSize = new Size(1000, 700);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KIT-FITNESS - Quản Lý Dinh Dưỡng Cá Nhân";
            Load += frmMain_Load;
            pnlNavbar.ResumeLayout(false);
            pnlRightActions.ResumeLayout(false);
            pnlNavMenu.ResumeLayout(false);
            pnlBrand.ResumeLayout(false);
            pnlBrand.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlNavbar;
        private System.Windows.Forms.Panel pnlBrand;
        private System.Windows.Forms.Label lblLogoCircle;
        private System.Windows.Forms.Label lblBrandName;
        private System.Windows.Forms.Label lblSlogan;
        private System.Windows.Forms.FlowLayoutPanel pnlNavMenu;
        private System.Windows.Forms.Button btnNavHome;
        private System.Windows.Forms.Button btnNavDiary;
        private System.Windows.Forms.Button btnNavWorkout;
        private System.Windows.Forms.Button btnNavPantry;
        private System.Windows.Forms.Button btnNavProfile;
        private System.Windows.Forms.FlowLayoutPanel pnlRightActions;
        private System.Windows.Forms.Button btnProfileAvatar;
        private System.Windows.Forms.Button btnNotifications;
        private System.Windows.Forms.Button btnQuickAdd;
        private System.Windows.Forms.Panel pnlContent;
    }
}