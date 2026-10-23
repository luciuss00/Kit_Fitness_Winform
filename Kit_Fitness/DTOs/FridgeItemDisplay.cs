namespace Kit_Fitness.DTOs
{
    /// <summary>
    /// DTO hiển thị thực phẩm trong tủ lạnh
    /// </summary>
    public class FridgeItemDisplay
    {
        public long Id { get; set; }
        public string FoodName { get; set; } = "";
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = "";
        public DateOnly? ExpiryDate { get; set; }
        public string StorageType { get; set; } = "";
        public int DaysRemaining { get; set; }
        public string Status { get; set; } = ""; // "fresh", "expiring_soon", "expired"
    }
}
