namespace Kit_Fitness.Helpers;

public static class TrafficLightHelper
{
    public const int FoodGreenThreshold = 200;
    public const int FoodYellowThreshold = 500;

    /// <summary>
    /// Đèn giao thông tĩnh cho thực phẩm (theo calo/khẩu phần)
    /// </summary>
    public static string ResolveFoodTrafficLight(decimal calories)
    {
        if (calories <= FoodGreenThreshold) return "GREEN";
        if (calories <= FoodYellowThreshold) return "YELLOW";
        return "RED";
    }

    /// <summary>
    /// Ngưỡng đèn giao thông bữa ăn theo số bữa trong ngày (mealPerDay -> [ngưỡng xanh, ngưỡng vàng])
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
    /// Tính Traffic Light cho từng bữa ăn dựa trên tỷ lệ % so với target calo cả ngày
    /// </summary>
    public static string CalculateMealTrafficLight(int mealPerDay, decimal totalCaloriesOfMeal, decimal userTargetCalories)
    {
        if (userTargetCalories <= 0) return "GREEN";
        int effective = Math.Min(Math.Max(mealPerDay, 1), 6);
        decimal percentage = (totalCaloriesOfMeal / userTargetCalories) * 100.0m;
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
        decimal ratio = (totalCalories / userTargetCalories) * 100.0m;
        string normalizedGoal = NormalizeGoal(goal);

        switch (normalizedGoal)
        {
            case "GAIN_WEIGHT":
                if (ratio < 75.0m) return "RED";
                if (ratio < 93.0m) return "YELLOW";
                if (ratio <= 110.0m) return "GREEN";
                return "RED";

            case "MAINTAIN":
                if (ratio < 80.0m) return "YELLOW";
                if (ratio <= 105.0m) return "GREEN";
                if (ratio <= 112.0m) return "YELLOW";
                return "RED";

            case "LOSE_WEIGHT":
            default:
                if (ratio < 60.0m) return "YELLOW";
                if (ratio <= 105.0m) return "GREEN";
                return "RED";
        }
    }

    /// <summary>
    /// Chuẩn hóa chuỗi mục tiêu sang enum key chuẩn
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
    /// Màu sắc hiển thị WinForms cho Traffic Light
    /// </summary>
    public static Color GetColor(string? trafficLight)
    {
        return (trafficLight ?? "").Trim().ToUpperInvariant() switch
        {
            "GREEN" => Color.FromArgb(47, 82, 51),    // Kit Green #2F5233
            "YELLOW" => Color.FromArgb(217, 164, 65), // Kit Gold #D9A441
            "RED" => Color.FromArgb(181, 67, 43),     // Kit Terra/Red #B5432B
            _ => Color.FromArgb(124, 115, 104)        // Neutral Gray
        };
    }
}
