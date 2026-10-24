using System.Text.Json.Serialization;

namespace Kit_Fitness.DTOs
{
    public class AiMealPhotoAnalysis
    {
        [JsonPropertyName("foodName")]
        public string FoodName { get; set; } = string.Empty;

        [JsonPropertyName("quantityGrams")]
        public decimal QuantityGrams { get; set; }

        [JsonPropertyName("estimatedCalories")]
        public int EstimatedCalories { get; set; }

        [JsonPropertyName("proteinPer100g")]
        public decimal ProteinPer100g { get; set; }

        [JsonPropertyName("carbsPer100g")]
        public decimal CarbsPer100g { get; set; }

        [JsonPropertyName("fatPer100g")]
        public decimal FatPer100g { get; set; }
    }
}