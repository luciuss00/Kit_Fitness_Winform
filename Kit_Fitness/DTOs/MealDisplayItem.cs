namespace Kit_Fitness.DTOs
{
    /// <summary>
    /// DTO cho một bữa ăn hiển thị trên timeline
    /// </summary>
    public class MealDisplayItem
    {
        public long DailyLogId { get; set; }
        public string MealType { get; set; } = "";
        public string TimeSlot { get; set; } = "";
        public int TotalCalories { get; set; }
        public int TotalProtein { get; set; }
        public int TotalCarbs { get; set; }
        public int TotalFat { get; set; }
        public List<LogItemDisplay> Items { get; set; } = new();
    }

    public class LogItemDisplay
    {
        public long Id { get; set; }
        public string FoodName { get; set; } = "";
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = "";
        public int Calories { get; set; }
        public string? TrafficLight { get; set; }
    }
}
