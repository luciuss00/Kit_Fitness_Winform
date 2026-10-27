using Kit_Fitness.Forms;

namespace Kit_Fitness
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            while (true)
            {
                using (var loginForm = new frmLogin())
                {
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }

                // Kiểm tra nếu người dùng mới chưa thiết lập thể trạng (TargetCalories / Chiều cao / Cân nặng)
                // thì tự động mở Onboarding Wizard chào đón và tính toán lộ trình
                var userRepo = new Kit_Fitness.Repositories.UserRepository();
                var user = userRepo.GetById(Kit_Fitness.Helpers.AppSession.CurrentUserId);
                if (user != null && (!user.TargetCalories.HasValue || user.TargetCalories <= 0 || !user.Height.HasValue || !user.Weight.HasValue))
                {
                    using var onboardingForm = new frmOnboarding();
                    onboardingForm.ShowDialog();
                }

                using var mainForm = new frmMain();
                if (mainForm.ShowDialog() != DialogResult.Retry)
                {
                    return;
                }
            }
        }
    }
}