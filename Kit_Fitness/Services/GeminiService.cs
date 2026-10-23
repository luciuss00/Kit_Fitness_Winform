using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Kit_Fitness.Services
{
    public class GeminiService
    {
        private readonly string ApiKey;

        public GeminiService()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            ApiKey = configuration["ApiSettings:ApiKey"];
        }

        private const string ModelId = "gemini-3.5-flash";
        private const string BaseUrl =
            "https://generativelanguage.googleapis.com/v1/models/{0}:generateContent?key={1}";

        private static readonly HttpClient _httpClient = new()
        {
            Timeout = TimeSpan.FromSeconds(60)
        };

        /// <summary>
        /// Gợi ý 3 món ăn dựa trên danh sách nguyên liệu tủ lạnh và calo còn lại.
        /// Trả về danh sách <see cref="AiMealSuggestion"/> parse từ JSON Gemini trả về.
        /// </summary>
        public async Task<List<AiMealSuggestion>> SuggestMealsAsync(
            List<FridgeItemDisplay> fridgeItems,
            int caloriesRemaining,
            int targetProtein = 0,
            int targetCarb = 0,
            int targetFat = 0)
        {
            if (string.IsNullOrWhiteSpace(ApiKey))
                throw new InvalidOperationException(
                    "Chưa cấu hình Gemini API Key"
                );

            string prompt = BuildPrompt(fridgeItems, caloriesRemaining, targetProtein, targetCarb, targetFat);

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                },
                generationConfig = new
                {
                    temperature = 0.7,
                    maxOutputTokens = 2048,
                    responseMimeType = "application/json"
                }
            };

            string url = string.Format(BaseUrl, ModelId, ApiKey);
            string jsonBody = JsonSerializer.Serialize(requestBody);

            using var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                string err = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(
                    $"Gemini API lỗi [{response.StatusCode}]: {err}");
            }

            string responseJson = await response.Content.ReadAsStringAsync();
            return ParseGeminiResponse(responseJson);
        }

        private string BuildPrompt(
            List<FridgeItemDisplay> fridgeItems,
            int caloriesRemaining,
            int targetProtein,
            int targetCarb,
            int targetFat)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Bạn là chuyên gia dinh dưỡng. Hãy gợi ý CHÍNH XÁC 3 món ăn Việt Nam phù hợp.");
            sb.AppendLine();
            sb.AppendLine($"**Lượng calo còn lại trong ngày: {caloriesRemaining} kcal**");

            if (targetProtein > 0)
                sb.AppendLine($"Mục tiêu macro: Đạm {targetProtein}g • Carb {targetCarb}g • Béo {targetFat}g");

            sb.AppendLine();
            sb.AppendLine("**Nguyên liệu hiện có trong tủ lạnh:**");
            if (fridgeItems.Count == 0)
            {
                sb.AppendLine("(Tủ lạnh trống — hãy gợi ý món ăn dễ mua nguyên liệu)");
            }
            else
            {
                foreach (var item in fridgeItems)
                {
                    string expiryNote = item.DaysRemaining < 0
                        ? " [ĐÃ HẾT HẠN - bỏ qua]"
                        : item.DaysRemaining <= 3
                            ? $" [SẮP HẾT HẠN trong {item.DaysRemaining} ngày - ưu tiên dùng]"
                            : "";
                    sb.AppendLine($"- {item.FoodName}: {(int)item.Quantity} {item.Unit}{expiryNote}");
                }
            }

            sb.AppendLine();
            sb.AppendLine("**Yêu cầu đầu ra (JSON array thuần, không có markdown, không có text ngoài JSON):**");
            sb.AppendLine("Trả về JSON array gồm 3 object, mỗi object có cấu trúc:");
            sb.AppendLine("[");
            sb.AppendLine("  {");
            sb.AppendLine("    \"tag\": \"TIẾT KIỆM CALO\",");
            sb.AppendLine("    \"calories\": 350,");
            sb.AppendLine("    \"title\": \"Tên món ăn\",");
            sb.AppendLine("    \"description\": \"Mô tả ngắn 1-2 câu về hương vị, cách nấu\",");
            sb.AppendLine("    \"servings\": \"Khẩu phần: 1 người • Chuẩn bị: 20 phút\",");
            sb.AppendLine("    \"protein\": 35,");
            sb.AppendLine("    \"carb\": 20,");
            sb.AppendLine("    \"fat\": 8,");
            sb.AppendLine("    \"ingredients\": [\"Nguyên liệu 1: 150g\", \"Nguyên liệu 2: 100g\"],");
            sb.AppendLine("    \"cookingSteps\": \"1. Bước 1...\\n2. Bước 2...\\n3. Bước 3...\"");
            sb.AppendLine("  }");
            sb.AppendLine("]");
            sb.AppendLine();
            sb.AppendLine("Tag phải là một trong: TIẾT KIỆM CALO, GIÀU PROTEIN, TƯƠI LÀNH, CÂN BẰNG, TĂNG CƠ");
            sb.AppendLine("Calo từng món PHẢI <= caloriesRemaining. Ưu tiên dùng nguyên liệu sắp hết hạn.");

            return sb.ToString();
        }

        private List<AiMealSuggestion> ParseGeminiResponse(string responseJson)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"[GeminiService] Raw response: {responseJson}");

                var root = JsonNode.Parse(responseJson);
                string? text = null;
                if (root?["candidates"]?[0]?["content"]?["parts"] is JsonArray parts)
                {
                    text = parts
                        .Select(part => part?["text"]?.GetValue<string>())
                        .FirstOrDefault(value => !string.IsNullOrWhiteSpace(value) &&
                                                 (value.Contains('[') || value.Contains("{")));
                }

                if (string.IsNullOrWhiteSpace(text))
                {
                    if (root is JsonArray)
                    {
                        text = root.ToJsonString();
                    }
                    else
                    {
                        text = root?["candidates"]?[0]?["content"]?["parts"]?[0]?["json"]?.GetValue<string>();
                    }
                }

                if (string.IsNullOrWhiteSpace(text))
                {
                    System.Diagnostics.Debug.WriteLine("[GeminiService] No valid text payload found, using fallback suggestions.");
                    return GetFallbackSuggestions();
                }

                text = Regex.Replace(text, @"^\s*```(?:json)?\s*", "", RegexOptions.IgnoreCase);
                text = Regex.Replace(text, @"\s*```\s*$", "").Trim();

                int arrayStart = text.IndexOf('[');
                int arrayEnd = text.LastIndexOf(']');
                if (arrayStart >= 0 && arrayEnd > arrayStart)
                    text = text[arrayStart..(arrayEnd + 1)];

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    NumberHandling = JsonNumberHandling.AllowReadingFromString
                };

                List<AiMealSuggestion>? suggestions = null;
                try
                {
                    suggestions = JsonSerializer.Deserialize<List<AiMealSuggestion>>(text, options);
                }
                catch (JsonException)
                {
                    var json = JsonNode.Parse(text);
                    var wrappedArray = json?["meals"] ?? json?["suggestions"] ?? json?["data"];
                    if (wrappedArray is not null)
                        suggestions = wrappedArray.Deserialize<List<AiMealSuggestion>>(options);
                    else
                        throw;
                }

                if (suggestions == null || suggestions.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("[GeminiService] Deserialization resulted in empty list, using fallback.");
                    return GetFallbackSuggestions();
                }

                return suggestions;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[GeminiService] Parse error: {ex.Message}");
                return GetFallbackSuggestions();
            }
        }

        private List<AiMealSuggestion> GetFallbackSuggestions()
        {
            return new List<AiMealSuggestion>
            {
                new AiMealSuggestion
                {
                    Tag = "TIẾT KIỆM CALO",
                    Calories = 385,
                    Title = "Ức gà áp chảo sốt cà chua & Canh rau muống",
                    Description = "Ức gà áp chảo sốt cà chua đậm đà ăn kèm canh rau muống thanh mát và cơm gạo lứt.",
                    Servings = "Khẩu phần: 1 người • Chuẩn bị: 20 phút",
                    Protein = 42, Carb = 18, Fat = 8,
                    CookingSteps = "1. Ức gà ướp muối tiêu 10 phút.\n2. Áp chảo 5 phút mỗi mặt.\n3. Làm sốt cà chua, chan lên gà.\n4. Nấu canh rau muống."
                },
                new AiMealSuggestion
                {
                    Tag = "TƯƠI LÀNH",
                    Calories = 320,
                    Title = "Salad ức gà xé phay & Cà chua bi dầu giấm",
                    Description = "Salad thanh đạm kết hợp ức gà xé phay, cà chua bi giòn ngọt và sốt mè rang dầu giấm.",
                    Servings = "Khẩu phần: 1 người • Chuẩn bị: 15 phút",
                    Protein = 36, Carb = 12, Fat = 11,
                    CookingSteps = "1. Luộc ức gà, để nguội xé nhỏ.\n2. Trộn rau xanh và cà chua bi.\n3. Pha sốt dầu giấm mè rang.\n4. Rưới sốt lên salad."
                },
                new AiMealSuggestion
                {
                    Tag = "GIÀU PROTEIN",
                    Calories = 420,
                    Title = "Cá hồi áp chảo sốt bơ chanh & Đậu phụ non",
                    Description = "Cá hồi phi lê thơm ngậy áp chảo ăn kèm đậu phụ non sốt tương và rau củ hấp bổ dưỡng.",
                    Servings = "Khẩu phần: 1 người • Chuẩn bị: 25 phút",
                    Protein = 45, Carb = 10, Fat = 14,
                    CookingSteps = "1. Cá hồi ướp muối, tiêu, chanh.\n2. Áp chảo 3 phút mỗi mặt.\n3. Làm sốt bơ chanh, chan lên cá.\n4. Hấp đậu phụ non với tương."
                }
            };
        }
    }
}
