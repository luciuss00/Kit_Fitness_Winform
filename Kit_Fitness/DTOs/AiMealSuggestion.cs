namespace Kit_Fitness.DTOs
{
    public class AiMealSuggestion
    {
        public string Tag { get; set; } = "";          // "TIẾT KIỆM CALO", "GIÀU PROTEIN", ...
        public int Calories { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Servings { get; set; } = "";     // "Khẩu phần: 1 người • Chuẩn bị: 20 phút"
        public int Protein { get; set; }
        public int Carb { get; set; }
        public int Fat { get; set; }
        public List<string> Ingredients { get; set; } = new();  // Nguyên liệu cần dùng từ tủ lạnh
        public string CookingSteps { get; set; } = "";          // Hướng dẫn nấu (raw text)
    }
}
