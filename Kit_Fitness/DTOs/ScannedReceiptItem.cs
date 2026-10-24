using System.Text.Json.Serialization;

namespace Kit_Fitness.DTOs
{
    public class ScannedReceiptItem
    {
        [JsonPropertyName("foodName")]
        public string FoodName { get; set; } = string.Empty;

        [JsonPropertyName("quantity")]
        public decimal Quantity { get; set; } = 1;

        [JsonPropertyName("unit")]
        public string Unit { get; set; } = "g";

        [JsonPropertyName("storageType")]
        public string StorageType { get; set; } = "CHILL"; // "CHILL" hoặc "FREEZER"

        [JsonPropertyName("expiryDays")]
        public int ExpiryDays { get; set; } = 5;

        [JsonPropertyName("estimatedCalories")]
        public int EstimatedCalories { get; set; } = 150;

        [JsonPropertyName("estimatedProtein")]
        public decimal EstimatedProtein { get; set; } = 5;

        [JsonPropertyName("estimatedCarbs")]
        public decimal EstimatedCarbs { get; set; } = 20;

        [JsonPropertyName("estimatedFat")]
        public decimal EstimatedFat { get; set; } = 3;
    }
}
