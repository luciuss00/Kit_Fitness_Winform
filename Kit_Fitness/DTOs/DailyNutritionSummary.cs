namespace Kit_Fitness.DTOs
{
    /// <summary>
    /// DTO chứa tổng hợp dinh dưỡng trong ngày
    /// </summary>
    public class DailyNutritionSummary
    {
        public int TotalCalories { get; set; }
        public int TotalProtein { get; set; }
        public int TotalCarbs { get; set; }
        public int TotalFat { get; set; }
        public int TargetCalories { get; set; }
        public int TargetProtein { get; set; }
        public int TargetCarbs { get; set; }
        public int TargetFat { get; set; }
        public int CaloriesRemaining => TargetCalories - TotalCalories;
        public int CaloriesBurned { get; set; }
        public int CaloriesConsumed { get; set; }

        // Tiện ích alias cho các màn hình gọi trực tiếp
        public int ProteinConsumed => TotalProtein;
        public int CarbsConsumed => TotalCarbs;
        public int FatConsumed => TotalFat;
        public int ProteinTarget => TargetProtein;
        public int CarbsTarget => TargetCarbs;
        public int FatTarget => TargetFat;
    }
}
