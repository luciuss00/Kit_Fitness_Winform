namespace Kit_Fitness.Helpers
{
    /// <summary>
    /// Lưu trữ thông tin phiên đăng nhập của người dùng hiện tại
    /// </summary>
    public static class AppSession
    {
        public static long CurrentUserId { get; set; } = 1; // Mặc định user 1 cho demo
        public static string CurrentUserName { get; set; } = "Người dùng";
    }
}
