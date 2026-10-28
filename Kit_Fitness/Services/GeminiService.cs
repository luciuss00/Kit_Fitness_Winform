using Kit_Fitness.DTOs;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Kit_Fitness.Services
{
    public class GeminiService
    {
        private readonly string? ApiKey;

        // Chỉ sử dụng duy nhất model gemini-3.8-flash, không switch sang model nào khác
        public const string DefaultModelId = "gemini-3.8-flash";
        public string ModelId => DefaultModelId;

        // v1beta hỗ trợ đầy đủ generationConfig (responseMimeType, thinkingConfig...)
        private const string BaseUrl =
            "https://generativelanguage.googleapis.com/v1beta/models/{0}:generateContent";

        private static readonly HttpClient _httpClient = new()
        {
            Timeout = TimeSpan.FromSeconds(60)
        };

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

        public GeminiService()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            ApiKey = configuration["ApiSettings:ApiKey"];
            if (string.IsNullOrWhiteSpace(ApiKey))
            {
                ApiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY");
            }
        }

        public GeminiService(string? apiKey, string? modelId = null)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// Gợi ý 3 món ăn dựa trên nguyên liệu tủ lạnh và calo còn lại.
        /// Lỗi AI sẽ được ném ra (không còn âm thầm trả dữ liệu giả) để UI tự xử lý.
        /// Muốn dùng món mặc định thì gọi <see cref="GetFallbackSuggestions"/> trong catch ở UI.
        /// </summary>
        public async Task<List<AiMealSuggestion>> SuggestMealsAsync(
            List<FridgeItemDisplay> fridgeItems,
            int caloriesRemaining,
            int targetProtein = 0,
            int targetCarb = 0,
            int targetFat = 0)
        {
            if (string.IsNullOrWhiteSpace(ApiKey))
                throw new InvalidOperationException("Chưa cấu hình Gemini API Key (ApiSettings:ApiKey).");

            // Bỏ nguyên liệu đã hết hạn ngay trong code
            var usableItems = (fridgeItems ?? new List<FridgeItemDisplay>())
                .Where(i => i.DaysRemaining >= 0)
                .ToList();

            string prompt = BuildPrompt(usableItems, caloriesRemaining, targetProtein, targetCarb, targetFat);

            var requestBody = new
            {
                contents = new[]
                {
                    new { parts = new[] { new { text = prompt } } }
                },
                generationConfig = new
                {
                    temperature = 0.7,
                    maxOutputTokens = 8192,
                    responseMimeType = "application/json",
                    // Tắt thinking để không tốn token và JSON không bị cắt cụt.
                    thinkingConfig = new { thinkingLevel = "minimal" }
                }
            };

            string jsonBody = JsonSerializer.Serialize(requestBody);
            string model = "gemini-3.8-flash";
            string url = string.Format(BaseUrl, model);

            using var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
            };
            request.Headers.Add("x-goog-api-key", ApiKey);

            using var response = await _httpClient.SendAsync(request);
            string responseJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Gemini API [{model}] lỗi [{(int)response.StatusCode} {response.StatusCode}]: {responseJson}");
            }

            var suggestions = ParseGeminiResponse(responseJson);
            var withinLimit = suggestions.Where(s => s.Calories <= caloriesRemaining).ToList();
            return withinLimit.Count > 0 ? withinLimit : suggestions;
        }

        /// <summary>
        /// Phân tích ảnh hóa đơn chợ/siêu thị để bóc tách danh sách nguyên liệu, số lượng, hạn dùng và ngăn trữ.
        /// </summary>
        public async Task<List<ScannedReceiptItem>> AnalyzeReceiptAsync(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(ApiKey))
                throw new InvalidOperationException("Chưa cấu hình Gemini API Key (ApiSettings:ApiKey).");

            if (!File.Exists(imagePath))
                throw new FileNotFoundException("Không tìm thấy file ảnh hóa đơn.", imagePath);

            byte[] imageBytes = PrepareImageBytes(imagePath, out string mimeType);
            string base64Data = Convert.ToBase64String(imageBytes);

            string prompt =
                "Bạn là trợ lý thông minh chuyên phân tích hóa đơn mua sắm thực phẩm / đi chợ / siêu thị tại Việt Nam.\n" +
                "Hãy đọc hình ảnh hóa đơn này, nhận diện và trích xuất tất cả các mặt hàng thực phẩm, đồ ăn, thức uống, nguyên liệu nấu ăn.\n" +
                "Bỏ qua các mặt hàng phi thực phẩm (hóa mỹ phẩm, đồ gia dụng, túi ni lông, đồ tẩy rửa...).\n\n" +
                "Với mỗi mặt hàng, trích xuất chính xác:\n" +
                "- foodName: Tên thực phẩm ngắn gọn, chuẩn tiếng Việt (ví dụ: 'Ức gà phi lê', 'Thịt ba chỉ heo', 'Bông cải xanh', 'Cà chua', 'Trứng gà', 'Sữa chua', 'Gạo lứt').\n" +
                "- quantity: Số lượng mua (dạng số > 0, ví dụ: 0.5, 1, 2, 500). Mặc định là 1 nếu hóa đơn không ghi rõ.\n" +
                "- unit: Đơn vị tính phù hợp (ví dụ: 'kg', 'g', 'quả', 'hộp', 'bó', 'vỉ', 'gói', 'túi', 'khay', 'con').\n" +
                "- storageType: Gợi ý ngăn bảo quản tốt nhất trong tủ lạnh: 'CHILL' (ngăn mát: rau củ quả, trứng sữa, đồ ăn trong tuần) hoặc 'FREEZER' (ngăn đá/đông: thịt cá tươi sống trữ đông, hải sản, đồ đông lạnh).\n" +
                "- expiryDays: Số ngày bảo quản an toàn khuyến nghị kể từ hôm nay (ví dụ: rau xanh 3-5 ngày, thịt cá ngăn mát 2 ngày, thịt cá ngăn đá 30 ngày, trứng 14 ngày, đồ khô/hộp 30-60 ngày).\n" +
                "- estimatedCalories: Calo ước tính (kcal cho 100g hoặc 1 đơn vị).\n" +
                "- estimatedProtein: Đạm ước tính (g).\n" +
                "- estimatedCarbs: Carb ước tính (g).\n" +
                "- estimatedFat: Béo ước tính (g).\n\n" +
                "Trả về DUY NHẤT một JSON array thuần túy, không có markdown hoặc text thừa ngoài JSON:\n" +
                "[\n" +
                "  {\n" +
                "    \"foodName\": \"Ức gà phi lê\",\n" +
                "    \"quantity\": 0.5,\n" +
                "    \"unit\": \"kg\",\n" +
                "    \"storageType\": \"FREEZER\",\n" +
                "    \"expiryDays\": 30,\n" +
                "    \"estimatedCalories\": 165,\n" +
                "    \"estimatedProtein\": 31,\n" +
                "    \"estimatedCarbs\": 0,\n" +
                "    \"estimatedFat\": 3.6\n" +
                "  }\n" +
                "]";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new object[]
                        {
                            new { text = prompt },
                            new
                            {
                                inlineData = new
                                {
                                    mimeType = mimeType,
                                    data = base64Data
                                }
                            }
                        }
                    }
                },
                generationConfig = new
                {
                    temperature = 0.2,
                    maxOutputTokens = 8192,
                    responseMimeType = "application/json",
                    thinkingConfig = new { thinkingLevel = "minimal" }
                }
            };

            string jsonBody = JsonSerializer.Serialize(requestBody);
            string model = "gemini-3.8-flash";
            string url = string.Format(BaseUrl, model);

            using var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
            };
            request.Headers.Add("x-goog-api-key", ApiKey);

            using var response = await _httpClient.SendAsync(request);
            string responseJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Gemini API [{model}] lỗi [{(int)response.StatusCode} {response.StatusCode}]: {responseJson}");
            }

            return ParseReceiptResponse(responseJson);
        }

        public async Task<AiMealPhotoAnalysis> AnalyzeMealPhotoAsync(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(ApiKey))
                throw new InvalidOperationException("Chưa cấu hình Gemini API Key (ApiSettings:ApiKey).");

            if (!File.Exists(imagePath))
                throw new FileNotFoundException("Không tìm thấy ảnh món ăn.", imagePath);

            byte[] imageBytes = PrepareImageBytes(imagePath, out string mimeType);
            string prompt =
                "Phân tích ảnh món ăn này. Tên món foodName bắt buộc viết bằng tiếng Việt tự nhiên, dùng tên món phổ biến tại Việt Nam; " +
                "nếu ảnh có chữ tiếng nước ngoài thì dịch tên món sang tiếng Việt, không trả tên tiếng Anh. " +
                "Ước lượng món chính nhìn thấy, khối lượng phần ăn trong ảnh theo gram và tổng calo của đúng phần ăn đó. " +
                "Ước lượng protein, carbs và fat trên mỗi 100g. Nếu ảnh có nhiều món, đặt tên mô tả ngắn gọn cho cả phần ăn. " +
                "Chỉ trả về một JSON object, không markdown, theo cấu trúc: " +
                "{\"foodName\":\"...\",\"quantityGrams\":250,\"estimatedCalories\":400," +
                "\"proteinPer100g\":15,\"carbsPer100g\":20,\"fatPer100g\":8}.";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new object[]
                        {
                            new { text = prompt },
                            new { inlineData = new { mimeType, data = Convert.ToBase64String(imageBytes) } }
                        }
                    }
                },
                generationConfig = new
                {
                    temperature = 0.2,
                    maxOutputTokens = 4096,
                    responseMimeType = "application/json",
                    thinkingConfig = new { thinkingLevel = "minimal" }
                }
            };

            string jsonBody = JsonSerializer.Serialize(requestBody);
            string model = "gemini-3.8-flash";

            using var request = new HttpRequestMessage(HttpMethod.Post, string.Format(BaseUrl, model))
            {
                Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
            };
            request.Headers.Add("x-goog-api-key", ApiKey);

            using var response = await _httpClient.SendAsync(request);
            string responseJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Gemini API [{model}] lỗi [{(int)response.StatusCode} {response.StatusCode}]: {responseJson}");
            }

            var root = JsonNode.Parse(responseJson);
            var candidate = root?["candidates"]?[0];
            string? text = null;
            if (candidate?["content"]?["parts"] is JsonArray parts)
            {
                text = string.Concat(parts
                    .Where(part => part?["thought"]?.GetValue<bool>() != true)
                    .Select(part => part?["text"]?.GetValue<string>()));
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                throw new InvalidOperationException($"Model {model} không trả về nội dung.");
            }

            text = Regex.Replace(text, @"^\s*```(?:json)?\s*", "", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"\s*```\s*$", "").Trim();

            var jsonMatch = Regex.Match(text, @"\{[\s\S]*\}");
            if (jsonMatch.Success)
            {
                text = jsonMatch.Value;
            }

            var analysis = JsonSerializer.Deserialize<AiMealPhotoAnalysis>(text, _jsonOptions);
            if (analysis is null || string.IsNullOrWhiteSpace(analysis.FoodName) || analysis.QuantityGrams <= 0)
            {
                throw new InvalidOperationException($"Model {model} trả về cấu trúc phân tích không hợp lệ.");
            }

            return analysis;
        }

        private static byte[] PrepareImageBytes(string imagePath, out string mimeType)
        {
            string ext = Path.GetExtension(imagePath).ToLowerInvariant();
            mimeType = ext switch
            {
                ".png" => "image/png",
                ".webp" => "image/webp",
                ".bmp" => "image/bmp",
                _ => "image/jpeg"
            };

            using var original = Image.FromFile(imagePath);
            int maxDim = 1600;
            if (original.Width <= maxDim && original.Height <= maxDim)
            {
                var fi = new FileInfo(imagePath);
                if (fi.Length <= 3 * 1024 * 1024)
                {
                    return File.ReadAllBytes(imagePath);
                }
            }

            double scale = Math.Min((double)maxDim / original.Width, (double)maxDim / original.Height);
            int newW = Math.Max(1, (int)(original.Width * scale));
            int newH = Math.Max(1, (int)(original.Height * scale));

            using var resized = new Bitmap(newW, newH);
            using (var g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(original, 0, 0, newW, newH);
            }

            using var ms = new MemoryStream();
            resized.Save(ms, ImageFormat.Jpeg);
            mimeType = "image/jpeg";
            return ms.ToArray();
        }

        private List<ScannedReceiptItem> ParseReceiptResponse(string responseJson)
        {
            var root = JsonNode.Parse(responseJson);
            var candidate = root?["candidates"]?[0];

            string? text = null;
            if (candidate?["content"]?["parts"] is JsonArray parts)
            {
                text = string.Concat(parts
                    .Where(p => p?["thought"]?.GetValue<bool>() != true)
                    .Select(p => p?["text"]?.GetValue<string>()));
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                string? blockReason = root?["promptFeedback"]?["blockReason"]?.GetValue<string>();
                throw new InvalidOperationException(
                    blockReason != null
                        ? $"Yêu cầu bị AI chặn: {blockReason}"
                        : "AI không trả về nội dung khi phân tích hóa đơn.");
            }

            text = Regex.Replace(text, @"^\s*```(?:json)?\s*", "", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"\s*```\s*$", "").Trim();

            JsonArray? jsonArray = null;
            if (text.StartsWith("["))
            {
                jsonArray = JsonNode.Parse(text) as JsonArray;
            }
            else if (text.StartsWith("{"))
            {
                var obj = JsonNode.Parse(text);
                var wrapped = obj?["items"] ?? obj?["foods"] ?? obj?["receipt"] ?? obj?["data"];
                if (wrapped is JsonArray arr)
                    jsonArray = arr;
            }

            if (jsonArray == null)
            {
                int start = text.IndexOf('[');
                int end = text.LastIndexOf(']');
                if (start >= 0 && end > start)
                {
                    jsonArray = JsonNode.Parse(text[start..(end + 1)]) as JsonArray;
                }
            }

            if (jsonArray == null || jsonArray.Count == 0)
                throw new InvalidOperationException("AI không tìm thấy thực phẩm nào trong hóa đơn.");

            var result = new List<ScannedReceiptItem>();
            foreach (var node in jsonArray)
            {
                if (node == null) continue;
                string name = node["foodName"]?.GetValue<string>()
                    ?? node["food_name"]?.GetValue<string>()
                    ?? node["name"]?.GetValue<string>()
                    ?? string.Empty;

                if (string.IsNullOrWhiteSpace(name)) continue;

                decimal qty = 1;
                if (node["quantity"] != null)
                {
                    if (decimal.TryParse(node["quantity"]!.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedQty) && parsedQty > 0)
                        qty = parsedQty;
                }

                string unit = node["unit"]?.GetValue<string>() ?? "g";
                string storage = (node["storageType"]?.GetValue<string>() ?? node["storage_type"]?.GetValue<string>() ?? "CHILL").ToUpperInvariant();
                if (storage != "FREEZER" && storage != "CHILL") storage = "CHILL";

                int expiryDays = storage == "FREEZER" ? 30 : 5;
                if (node["expiryDays"] != null)
                {
                    if (int.TryParse(node["expiryDays"]!.ToString(), out var parsedDays) && parsedDays > 0)
                        expiryDays = parsedDays;
                }

                int cals = 150;
                if (node["estimatedCalories"] != null && int.TryParse(node["estimatedCalories"]!.ToString(), out var parsedCals) && parsedCals > 0)
                    cals = parsedCals;

                decimal pro = 5, carb = 20, fat = 3;
                if (node["estimatedProtein"] != null && decimal.TryParse(node["estimatedProtein"]!.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var p)) pro = p;
                if (node["estimatedCarbs"] != null && decimal.TryParse(node["estimatedCarbs"]!.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var c)) carb = c;
                if (node["estimatedFat"] != null && decimal.TryParse(node["estimatedFat"]!.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var f)) fat = f;

                result.Add(new ScannedReceiptItem
                {
                    FoodName = name,
                    Quantity = qty,
                    Unit = unit,
                    StorageType = storage,
                    ExpiryDays = expiryDays,
                    EstimatedCalories = cals,
                    EstimatedProtein = pro,
                    EstimatedCarbs = carb,
                    EstimatedFat = fat
                });
            }

            if (result.Count == 0)
                throw new InvalidOperationException("Không trích xuất được thực phẩm hợp lệ từ ảnh hóa đơn.");

            return result;
        }

        private string BuildPrompt(
            List<FridgeItemDisplay> fridgeItems,
            int caloriesRemaining,
            int targetProtein,
            int targetCarb,
            int targetFat)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Bạn là chuyên gia dinh dưỡng. Hãy gợi ý CHÍNH XÁC 4 món ăn Việt Nam phù hợp.");
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
                    string expiryNote = item.DaysRemaining <= 3
                        ? $" [SẮP HẾT HẠN trong {item.DaysRemaining} ngày - ưu tiên dùng]"
                        : "";
                    string qty = item.Quantity.ToString("0.##", CultureInfo.InvariantCulture);
                    sb.AppendLine($"- {item.FoodName}: {qty} {item.Unit}{expiryNote}");
                }
            }

            sb.AppendLine();
            sb.AppendLine("**Yêu cầu đầu ra (JSON array thuần, không có markdown, không có text ngoài JSON):**");
            sb.AppendLine("Trả về JSON array gồm 4 object, mỗi object có cấu trúc:");
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
            sb.AppendLine("    \"ingredients\": [\"Tên thực phẩm đúng như trong tủ lạnh: 150g\"],");
            sb.AppendLine("    \"cookingSteps\": \"1. Bước 1...\\n2. Bước 2...\\n3. Bước 3...\"");
            sb.AppendLine("  }");
            sb.AppendLine("]");
            sb.AppendLine();
            sb.AppendLine("Tag phải là một trong: TIẾT KIỆM CALO, GIÀU PROTEIN, TƯƠI LÀNH, CÂN BẰNG, TĂNG CƠ");
            sb.AppendLine($"Calo từng món PHẢI <= {caloriesRemaining}. Ưu tiên dùng nguyên liệu sắp hết hạn.");
            sb.AppendLine("Trong ingredients, chỉ liệt kê nguyên liệu đang có trong tủ lạnh, giữ nguyên tên thực phẩm như danh sách đầu vào và ghi lượng dùng kèm đơn vị.");

            return sb.ToString();
        }

        private List<AiMealSuggestion> ParseGeminiResponse(string responseJson)
        {
            System.Diagnostics.Debug.WriteLine($"[GeminiService] Raw response: {responseJson}");

            var root = JsonNode.Parse(responseJson);
            var candidate = root?["candidates"]?[0];

            string? finishReason = candidate?["finishReason"]?.GetValue<string>();
            if (finishReason == "MAX_TOKENS")
                throw new InvalidOperationException("AI trả về bị cắt giữa chừng (MAX_TOKENS). Hãy tăng maxOutputTokens.");

            // Ghép các part không phải "thought"
            string? text = null;
            if (candidate?["content"]?["parts"] is JsonArray parts)
            {
                text = string.Concat(parts
                    .Where(p => p?["thought"]?.GetValue<bool>() != true)
                    .Select(p => p?["text"]?.GetValue<string>()));
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                string? blockReason = root?["promptFeedback"]?["blockReason"]?.GetValue<string>();
                throw new InvalidOperationException(
                    blockReason != null
                        ? $"Yêu cầu bị AI chặn: {blockReason}"
                        : "AI không trả về nội dung.");
            }

            // Phòng trường hợp model vẫn bọc ```json ... ```
            text = Regex.Replace(text, @"^\s*```(?:json)?\s*", "", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"\s*```\s*$", "").Trim();

            // Chấp nhận cả dạng mảng thuần lẫn object bọc {"meals": [...]}
            if (text.StartsWith("{"))
            {
                var obj = JsonNode.Parse(text);
                var wrapped = obj?["meals"] ?? obj?["suggestions"] ?? obj?["data"];
                if (wrapped is null)
                    throw new JsonException("JSON AI trả về không có mảng món ăn.");
                text = wrapped.ToJsonString();
            }
            else
            {
                int start = text.IndexOf('[');
                int end = text.LastIndexOf(']');
                if (start >= 0 && end > start)
                    text = text[start..(end + 1)];
            }

            var suggestions = JsonSerializer.Deserialize<List<AiMealSuggestion>>(text, _jsonOptions);

            if (suggestions == null || suggestions.Count == 0)
                throw new InvalidOperationException("AI không gợi ý được món nào.");

            return suggestions;
        }

        /// <summary>
        /// Món mặc định khi AI lỗi. UI nên báo rõ đây là gợi ý mặc định, không phải từ AI.
        /// </summary>
        public List<AiMealSuggestion> GetFallbackSuggestions()
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
                    Ingredients = new List<string> { "Ức gà: 150g", "Cà chua: 100g", "Rau muống: 100g" },
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
                    Ingredients = new List<string> { "Ức gà: 150g", "Cà chua bi: 100g", "Rau xanh: 80g" },
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
                    Ingredients = new List<string> { "Cá hồi: 150g", "Đậu phụ non: 1 bìa", "Chanh: 1/2 quả" },
                    CookingSteps = "1. Cá hồi ướp muối, tiêu, chanh.\n2. Áp chảo 3 phút mỗi mặt.\n3. Làm sốt bơ chanh, chan lên cá.\n4. Hấp đậu phụ non với tương."
                }
            };
        }
    }
}