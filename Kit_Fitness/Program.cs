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

                using var mainForm = new frmMain();
                if (mainForm.ShowDialog() != DialogResult.Retry)
                {
                    return;
                }
            }
        }
    }
}