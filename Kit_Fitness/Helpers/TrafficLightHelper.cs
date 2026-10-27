namespace Kit_Fitness.Helpers;

/// <summary>
/// Lớp tiện ích hỗ trợ tính toán & phân loại Đèn Giao Thông (Traffic Light: XANH / VÀNG / ĐỎ)
/// theo chuẩn dinh dưỡng khoa học cho từng món ăn, từng bữa ăn và tổng cả ngày.
/// </summary>
public static class TrafficLightHelper
{
    // Ngưỡng calo cho từng món ăn độc lập (Food level):
    // <= 200 kcal: Món nhẹ/healthy (Xanh)
    // 201 - 500 kcal: Món vừa phải (Vàng)
    // > 500 kcal: Món đậm đặc năng lượng (Đỏ)
    public const int FoodGreenThreshold = 200;
    public const int FoodYellowThreshold = 500;

    /// <summary>
    /// Đèn giao thông tĩnh cho từng món ăn (dựa trên calo trên 1 khẩu phần)
    /// </summary>
    public static string ResolveFoodTrafficLight(decimal calories)
    {
        if (calories <= FoodGreenThreshold) return "GREEN";
        if (calories <= FoodYellowThreshold) return "YELLOW";
        return "RED";
    }

    /// <summary>
    /// Bảng phân bổ % calo cho 1 bữa ăn dựa theo số bữa ăn trong ngày (mealPerDay)
    /// Key: Số bữa ăn trong ngày (1 đến 6 bữa)
    /// Value: (Ngưỡng calo an toàn - XANH %, Ngưỡng calo cận trần - VÀNG %)
    /// Ví dụ: Ăn 3 bữa/ngày thì mỗi bữa chiếm 25-40% calo cả ngày là hợp lý.
    /// </summary>
    private static readonly Dictionary<int, (decimal Green, decimal Yellow)> MealThresholds = new()
    {
        [1] = (60.0m, 90.0m),
        [2] = (40.0m, 65.0m),
        [3] = (25.0m, 40.0m),
        [4] = (20.0m, 32.0m),
        [5] = (16.0m, 26.0m),
        [6] = (13.0m, 20.0m)
    };

    /// <summary>
    /// Tính màu Đèn Giao Thông cho từng bữa ăn cụ thể
    /// </summary>
    /// <param name="mealPerDay">Số bữa ăn/ngày của user (VD: 3 bữa)</param>
    /// <param name="totalCaloriesOfMeal">Tổng calo của riêng bữa ăn này</param>
    /// <param name="userTargetCalories">Chỉ tiêu calo cả ngày của user</param>
    public static string CalculateMealTrafficLight(int mealPerDay, decimal totalCaloriesOfMeal, decimal userTargetCalories)
    {
        if (userTargetCalories <= 0) return "GREEN";

        // Giới hạn số bữa hợp lệ từ 1 đến 6 bữa
        int effective = Math.Min(Math.Max(mealPerDay, 1), 6);

        // percentage: Tỷ lệ % calo của bữa này chiếm bao nhiêu phần trong tổng calo ngày
        decimal percentage = (totalCaloriesOfMeal / userTargetCalories) * 100.0m;

        // Lấy ngưỡng chuẩn cho số bữa tương ứng
        var (green, yellow) = MealThresholds[effective];

        if (percentage <= green) return "GREEN";
        if (percentage <= yellow) return "YELLOW";
        return "RED";
    }

    /// <summary>
    /// Đánh giá Traffic Light cho toàn bộ ngày dựa trên mục tiêu cân nặng (Goal)
    /// </summary>
    public static string CalculateDailyTrafficLight(string? goal, decimal totalCalories, decimal userTargetCalories)
    {
        if (userTargetCalories <= 0) return "GREEN";

        // ratio: % tổng calo đã nạp / calo mục tiêu ngày
        decimal ratio = (totalCalories / userTargetCalories) * 100.0m;

        // normalizedGoal: Chuẩn hóa chuỗi mục tiêu sang 3 mã chuẩn: GAIN_WEIGHT, MAINTAIN, LOSE_WEIGHT
        string normalizedGoal = NormalizeGoal(goal);

        switch (normalizedGoal)
        {
            case "GAIN_WEIGHT":
                if (ratio < 75.0m) return "RED";     // Ăn quá ít đối với người cần tăng cân
                if (ratio < 93.0m) return "YELLOW";  // Đang tiến gần
                if (ratio <= 110.0m) return "GREEN"; // Thặng dư calo chuẩn
                return "RED";                        // Dư thừa quá đà

            case "MAINTAIN":
                if (ratio < 80.0m) return "YELLOW";  // Thiếu hụt
                if (ratio <= 105.0m) return "GREEN"; // Cân bằng tốt
                if (ratio <= 112.0m) return "YELLOW";// Chạm trần
                return "RED";                        // Dư thừa

            case "LOSE_WEIGHT":
            default:
                if (ratio < 60.0m) return "YELLOW";  // Nhịn ăn quá mức
                if (ratio <= 105.0m) return "GREEN"; // Thâm hụt đốt mỡ an toàn
                return "RED";                        // Vượt ngân sách calo giảm cân
        }
    }

    /// <summary>
    /// Chuẩn hóa chuỗi mục tiêu tự do sang Enum Key chuẩn: "GAIN_WEIGHT", "MAINTAIN", "LOSE_WEIGHT"
    /// Giúp code so sánh an toàn, tránh lỗi gõ sai chữ hoa/thường hoặc chuỗi dài tiếng Việt
    /// </summary>
    public static string NormalizeGoal(string? goal)
    {
        if (string.IsNullOrWhiteSpace(goal)) return "LOSE_WEIGHT";
        var g = goal.Trim().ToUpperInvariant();
        if (g.Contains("GAIN") || g.Contains("TĂNG")) return "GAIN_WEIGHT";
        if (g.Contains("MAINTAIN") || g.Contains("GIỮ") || g.Contains("DUY TRÌ")) return "MAINTAIN";
        return "LOSE_WEIGHT";
    }

    /// <summary>
    /// Bảng mã màu chuẩn giao diện cho Đèn Giao Thông trong WinForms
    /// </summary>
    public static Color GetColor(string? trafficLight)
    {
        return (trafficLight ?? "").Trim().ToUpperInvariant() switch
        {
            "GREEN" => Color.FromArgb(47, 82, 51),    // Xanh lá Kit Fitness (#2F5233)
            "YELLOW" => Color.FromArgb(217, 164, 65), // Vàng hổ phách (#D9A441)
            "RED" => Color.FromArgb(181, 67, 43),     // Đỏ đất nung cảnh báo (#B5432B)
            _ => Color.FromArgb(124, 115, 104)        // Xám trung tính
        };
    }
}
