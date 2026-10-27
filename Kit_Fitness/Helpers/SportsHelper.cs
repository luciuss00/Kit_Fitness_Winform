using System;
using System.Collections.Generic;
using System.Linq;

namespace Kit_Fitness.Helpers
{
    public enum IntensityLevel
    {
        Light,
        Moderate,
        Vigorous
    }

    public class SportIntensityConfig
    {
        public double Met { get; set; }
        public string Label { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;

        public SportIntensityConfig(double met, string label, string desc)
        {
            Met = met;
            Label = label;
            Desc = desc;
        }
    }

    public class SportCategoryItem
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public SportCategoryItem(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;
    }

    public class SportItem
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Emoji { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int DefaultDuration { get; set; } = 30;
        public SportIntensityConfig Light { get; set; }
        public SportIntensityConfig Moderate { get; set; }
        public SportIntensityConfig Vigorous { get; set; }

        public SportItem(string id, string name, string emoji, string category, int defaultDuration,
            SportIntensityConfig light, SportIntensityConfig moderate, SportIntensityConfig vigorous)
        {
            Id = id;
            Name = name;
            Emoji = emoji;
            Category = category;
            DefaultDuration = defaultDuration;
            Light = light;
            Moderate = moderate;
            Vigorous = vigorous;
        }

        public SportIntensityConfig GetIntensity(IntensityLevel level) => level switch
        {
            IntensityLevel.Light => Light,
            IntensityLevel.Vigorous => Vigorous,
            _ => Moderate
        };

        public override string ToString() => $"{Emoji} {Name}";
    }

    public static class SportsHelper
    {
        public static readonly List<SportCategoryItem> Categories = new()
        {
            new SportCategoryItem("all", "Tất cả nhóm môn"),
            new SportCategoryItem("cardio", "Chạy & Cardio"),
            new SportCategoryItem("strength", "Gym & Thể hình"),
            new SportCategoryItem("sports", "Thể thao bóng"),
            new SportCategoryItem("combat", "Võ thuật"),
            new SportCategoryItem("dance_mind", "Yoga & Nhảy"),
            new SportCategoryItem("outdoor", "Dã ngoại & Nước")
        };

        public static readonly List<SportItem> SportsList = new()
        {
            // ===== 1. CARDIO, CHẠY & ĐẠP XE =====
            new SportItem(
                "running", "Chạy bộ ngoài trời", "🏃‍♂️", "cardio", 30,
                new SportIntensityConfig(6.0, "Chạy chậm", "~6 km/h, chạy thả lỏng duy trì"),
                new SportIntensityConfig(8.3, "Chạy vừa", "~8-9 km/h, nhịp thở đều"),
                new SportIntensityConfig(11.5, "Chạy nhanh / Nước rút", ">10 km/h, bứt tốc tối đa")
            ),
            new SportItem(
                "treadmill", "Chạy máy (Treadmill)", "🏃‍♀️", "cardio", 30,
                new SportIntensityConfig(5.5, "Chạy nhẹ máy", "Tốc độ 5-7 km/h, độ dốc 0%"),
                new SportIntensityConfig(8.0, "Chạy đều máy", "Tốc độ 8-9 km/h, độ dốc 1-2%"),
                new SportIntensityConfig(11.0, "Interval trên máy", "Chạy bứt tốc dốc cao")
            ),
            new SportItem(
                "walking", "Đi bộ thể dục", "🚶‍♂️", "cardio", 35,
                new SportIntensityConfig(2.5, "Tản bộ", "Dạo mát, dưới 4 km/h"),
                new SportIntensityConfig(3.5, "Đi bộ đều", "Bước nhanh 4.5 - 5.5 km/h"),
                new SportIntensityConfig(5.0, "Đi bộ nhanh / Đánh tay", "Đi bộ thể lực >6 km/h")
            ),
            new SportItem(
                "incline_walk", "Đi bộ dốc (Incline Walk)", "🧗‍♂️", "cardio", 30,
                new SportIntensityConfig(4.0, "Dốc nhẹ", "Độ dốc 3-5%, tốc độ 4 km/h"),
                new SportIntensityConfig(6.0, "Dốc vừa", "Độ dốc 8-10%, tốc độ 4.5 km/h"),
                new SportIntensityConfig(8.5, "Dốc cao (12-3-30)", "Độ dốc 12-15%, tốc độ 5 km/h")
            ),
            new SportItem(
                "stair_climbing", "Leo cầu thang / StairMaster", "🪜", "cardio", 20,
                new SportIntensityConfig(5.0, "Bước chậm", "Leo từng bậc, nhịp thong thả"),
                new SportIntensityConfig(8.0, "Leo liên tục", "Nhịp bước đều, đổ mồ hôi"),
                new SportIntensityConfig(11.0, "Leo nhanh / 2 bậc", "Tốc độ cao, mỏi đùi cấp tốc")
            ),
            new SportItem(
                "cycling", "Đạp xe ngoài trời", "🚴‍♂️", "cardio", 40,
                new SportIntensityConfig(4.0, "Đạp thong thả", "<15 km/h, ngắm cảnh"),
                new SportIntensityConfig(6.8, "Đạp đều lực", "16-20 km/h, duy trì guồng chân"),
                new SportIntensityConfig(10.0, "Đua xe / Lên dốc", ">22 km/h, kháng lực nặng")
            ),
            new SportItem(
                "spinning", "Đạp xe trong nhà (Spinning)", "🚴‍♀️", "cardio", 35,
                new SportIntensityConfig(4.5, "Kháng lực nhẹ", "Guồng chân 60-70 rpm"),
                new SportIntensityConfig(7.0, "Lớp Spinning cơ bản", "Thay đổi tư thế ngồi - đứng"),
                new SportIntensityConfig(10.5, "HIIT Spinning", "Kháng lực cao, nước rút hết sức")
            ),
            new SportItem(
                "jump_rope", "Nhảy dây", "🪢", "cardio", 20,
                new SportIntensityConfig(8.0, "Nhảy cơ bản", "<100 nhịp/phút, đổi chân"),
                new SportIntensityConfig(10.0, "Nhịp độ đều", "100 - 120 nhịp/phút"),
                new SportIntensityConfig(12.5, "Nhảy nhanh / Double Under", ">120 nhịp/phút, bật nhảy cao")
            ),
            new SportItem(
                "rowing", "Chèo thuyền máy (Rowing)", "🚣‍♂️", "cardio", 25,
                new SportIntensityConfig(4.5, "Kéo nhẹ", "<100 watt, thả lỏng"),
                new SportIntensityConfig(7.0, "Kéo đều", "120-150 watt, chuẩn form"),
                new SportIntensityConfig(10.0, "Kéo bứt phá", ">200 watt, cường độ tối đa")
            ),
            new SportItem(
                "elliptical", "Máy trượt tuyết (Elliptical)", "⛷️", "cardio", 30,
                new SportIntensityConfig(4.5, "Trượt nhẹ", "Kháng lực thấp, bảo vệ khớp"),
                new SportIntensityConfig(6.8, "Trượt đều lực", "Kháng lực vừa, nhịp tim đều"),
                new SportIntensityConfig(9.0, "Kháng lực cao", "Đánh tay mạnh, đốt mỡ nhanh")
            ),
            new SportItem(
                "hiit", "HIIT / Cardio ngắt quãng", "🔥", "cardio", 25,
                new SportIntensityConfig(6.0, "Cardio nhẹ nhàng", "Nghỉ nhiều, nhịp tim vùng 2-3"),
                new SportIntensityConfig(8.5, "HIIT tiêu chuẩn", "Tập 30s - nghỉ 15s đều đặn"),
                new SportIntensityConfig(12.0, "Tabata cực hạn", "Tập 20s dốc sức - nghỉ 10s")
            ),

            // ===== 2. GYM & THỂ HÌNH =====
            new SportItem(
                "gym", "Gym / Nâng tạ", "🏋️‍♂️", "strength", 45,
                new SportIntensityConfig(3.5, "Tập nhẹ / Khởi động", "Nghỉ nhiều giữa các hiệp"),
                new SportIntensityConfig(5.0, "Tập tạ tiêu chuẩn", "Nghỉ 60-90s, cơ bắp đạt ngưỡng"),
                new SportIntensityConfig(6.5, "Tạ nặng / Supersets", "Nghỉ ngắn, tạ nặng gần thất bại")
            ),
            new SportItem(
                "calisthenics", "Calisthenics (Hít đất / Kéo xà)", "🤸‍♂️", "strength", 35,
                new SportIntensityConfig(4.0, "Bài tập cơ bản", "Hít đất, squat bodyweight nhẹ"),
                new SportIntensityConfig(6.0, "Kéo xà & Dip", "Pull-up, Dips, Leg raises đều"),
                new SportIntensityConfig(8.5, "Muscle-up & Skill", "Bài nâng cao, gồng cơ tối đa")
            ),
            new SportItem(
                "crossfit", "CrossFit / WOD", "💥", "strength", 30,
                new SportIntensityConfig(5.5, "WOD kỹ thuật", "Tập làm quen với bài tập"),
                new SportIntensityConfig(8.0, "WOD tiêu chuẩn", "Hoàn thành bài tập đúng giờ"),
                new SportIntensityConfig(11.5, "WOD thi đấu / For Time", "Chạy đua với thời gian, kiệt sức")
            ),
            new SportItem(
                "pilates", "Pilates (Mat / Reformer)", "🧘‍♀️", "strength", 45,
                new SportIntensityConfig(2.8, "Pilates thảm cơ bản", "Kiểm soát nhịp thở và cơ core"),
                new SportIntensityConfig(4.0, "Pilates Reformer", "Tập với máy kháng lực lò xo"),
                new SportIntensityConfig(5.5, "Power Pilates", "Chuỗi động tác liên tục, siết cơ sâu")
            ),
            new SportItem(
                "bodypump", "BodyPump (Tạ theo nhạc)", "🎶", "strength", 50,
                new SportIntensityConfig(4.0, "Mức tạ khởi động", "Theo nhạc chậm, số rep vừa phải"),
                new SportIntensityConfig(6.0, "Mức tạ chuẩn lớp", "Đốt mỡ toàn thân với 800+ reps"),
                new SportIntensityConfig(7.8, "Mức tạ nặng", "Gồng cơ liên tục suốt buổi tập")
            ),

            // ===== 3. THỂ THAO ĐỐI KHÁNG & BÓNG =====
            new SportItem(
                "pickleball", "Pickleball", "🏓", "sports", 45,
                new SportIntensityConfig(4.0, "Đánh đôi giải trí", "Đứng bóng nhẹ nhàng"),
                new SportIntensityConfig(6.0, "Đánh đôi đối kháng", "Di chuyển đều, dink và volley liên tục"),
                new SportIntensityConfig(8.0, "Đánh đơn thi đấu", "Chạy bao sân, tốc độ cao")
            ),
            new SportItem(
                "badminton", "Cầu lông", "🏸", "sports", 45,
                new SportIntensityConfig(4.5, "Đánh qua lại", "Tập nhẹ, giải trí gia đình"),
                new SportIntensityConfig(5.5, "Đánh đôi giao lưu", "Di chuyển và đập cầu đều tay"),
                new SportIntensityConfig(7.5, "Đánh đơn thi đấu", "Bứt tốc, smash liên tục, nhịp tim cao")
            ),
            new SportItem(
                "football", "Bóng đá", "⚽", "sports", 60,
                new SportIntensityConfig(5.0, "Đá nhẹ / Tập chuyền", "Khởi động, ít chạy tranh chấp"),
                new SportIntensityConfig(7.0, "Sân 5-7 giao lưu", "Di chuyển vừa phải, phối hợp đội"),
                new SportIntensityConfig(10.0, "Thi đấu đối kháng", "Bứt tốc liên tục, va chạm quyết liệt")
            ),
            new SportItem(
                "basketball", "Bóng rổ", "🏀", "sports", 45,
                new SportIntensityConfig(4.5, "Ném rổ giải trí", "Tập kỹ thuật ném rổ cá nhân"),
                new SportIntensityConfig(6.5, "Bóng rổ nửa sân (3x3)", "Tấn công phòng thủ liên tục"),
                new SportIntensityConfig(8.5, "Toàn sân (5x5)", "Chạy nhanh, bật nhảy tranh bóng")
            ),
            new SportItem(
                "tennis", "Tennis (Quần vợt)", "🎾", "sports", 60,
                new SportIntensityConfig(5.0, "Tập quả bóng với máy/tường", "Luyện cảm giác vợt"),
                new SportIntensityConfig(7.0, "Đánh đôi giao lưu", "Giữ bóng bền ở cuối sân"),
                new SportIntensityConfig(9.0, "Đánh đơn đối kháng", "Chạy cứu bóng khắp mặt sân")
            ),
            new SportItem(
                "table_tennis", "Bóng bàn", "🏓", "sports", 45,
                new SportIntensityConfig(3.5, "Đánh bóng giải trí", "Ít di chuyển chân"),
                new SportIntensityConfig(4.5, "Đánh đôi đều tay", "Giật bóng, di chuyển sang 2 bên"),
                new SportIntensityConfig(6.0, "Thi đấu đối kháng", "Tấn công dồn dập, phản xạ nhanh")
            ),
            new SportItem(
                "volleyball", "Bóng chuyền", "🏐", "sports", 45,
                new SportIntensityConfig(3.5, "Đệm bóng giải trí", "Tập nhẹ ngoài sân"),
                new SportIntensityConfig(5.0, "Thi đấu phong trào", "Chuyền và đập bóng đều đặn"),
                new SportIntensityConfig(7.5, "Bóng chuyền bãi biển", "Bật nhảy liên tục trên cát")
            ),
            new SportItem(
                "billiards", "Bida (Billiards / Snooker)", "🎱", "sports", 60,
                new SportIntensityConfig(2.0, "Đánh bida thư giãn", "Đi lại quanh bàn, tính toán thế bi"),
                new SportIntensityConfig(2.5, "Tập trung luyện cơ", "Đánh liên tục, tập thế bi khó"),
                new SportIntensityConfig(3.0, "Thi đấu liên tục", "Tập trung cao độ và đứng suốt trận")
            ),
            new SportItem(
                "golf", "Golf", "⛳", "sports", 90,
                new SportIntensityConfig(3.0, "Sân tập driving range", "Đứng đánh bóng tại chỗ"),
                new SportIntensityConfig(4.5, "Đi xe điện (Cart)", "Chơi 18 hố có xe hỗ trợ"),
                new SportIntensityConfig(5.5, "Đi bộ tự xách gậy", "Đi bộ liên tục qua 18 hố")
            ),

            // ===== 4. VÕ THUẬT & CHIẾN ĐẤU =====
            new SportItem(
                "boxing", "Boxing (Quyền Anh)", "🥊", "combat", 40,
                new SportIntensityConfig(5.5, "Đấm gió (Shadow Boxing)", "Luyện kỹ thuật bộ chân và đòn"),
                new SportIntensityConfig(8.0, "Đấm bao cát / Đích đấm", "Ra đòn dồn dập, né tránh"),
                new SportIntensityConfig(11.0, "Đấu tập (Sparring)", "Cường độ cao toàn thân, nhịp tim đỉnh")
            ),
            new SportItem(
                "kickboxing", "Kickboxing / Muay Thai", "🥋", "combat", 45,
                new SportIntensityConfig(6.0, "Đá gió / Kỹ thuật", "Khởi động đòn đá và gối"),
                new SportIntensityConfig(8.5, "Đá bao cát nặng / Pad", "Kết hợp tay chân liên hoàn"),
                new SportIntensityConfig(11.5, "Sparring thực chiến", "Tiêu hao năng lượng cực đại")
            ),
            new SportItem(
                "taekwondo_karate", "Taekwondo / Karate / Vovinam", "🥋", "combat", 50,
                new SportIntensityConfig(5.0, "Luyện quyền (Kata / Quyền pháp)", "Đúng tư thế, nhịp chậm"),
                new SportIntensityConfig(7.0, "Luyện đòn thế đối luyện", "Đá đích, ép dẻo toàn diện"),
                new SportIntensityConfig(10.0, "Đấu đối kháng", "Di chuyển nhanh, ra đòn dứt khoát")
            ),
            new SportItem(
                "judo_bjj", "Judo / BJJ (Nhu thuật)", "🤼‍♂️", "combat", 60,
                new SportIntensityConfig(5.5, "Khoan đòn kỹ thuật (Drill)", "Luyện kỹ thuật khóa siết"),
                new SportIntensityConfig(8.0, "Vật kỹ thuật đều lực", "Thực hành đè và thoát thế"),
                new SportIntensityConfig(10.5, "Lăn đối kháng (Rolling)", "Gồng toàn thân, nhịp tim tối đa")
            ),
            new SportItem(
                "mma", "MMA (Võ tổng hợp)", "🤼", "combat", 45,
                new SportIntensityConfig(6.0, "Khởi động kỹ thuật", "Đổi thế đứng và nằm"),
                new SportIntensityConfig(9.0, "Lồng ghép đòn đứng - sàn", "Chuyển đổi vật và đánh đứng"),
                new SportIntensityConfig(12.0, "Mô phỏng thi đấu", "5 phút/hiệp dốc kiệt sức")
            ),

            // ===== 5. YOGA, NHẢY & THƯ GIÃN =====
            new SportItem(
                "yoga", "Yoga", "🧘‍♀️", "dance_mind", 45,
                new SportIntensityConfig(2.5, "Hatha / Thư giãn", "Thiền, thở, giãn cơ chậm rãi"),
                new SportIntensityConfig(3.3, "Vinyasa / Flow", "Chuỗi động tác liên tục nhịp nhàng"),
                new SportIntensityConfig(4.5, "Power Yoga / Hot Yoga", "Giữ thế nặng, đổ nhiều mồ hôi")
            ),
            new SportItem(
                "stretching", "Giãn cơ & Phục hồi (Stretching)", "🌸", "dance_mind", 25,
                new SportIntensityConfig(2.0, "Giãn cơ tĩnh (Static)", "Thả lỏng sau buổi tập"),
                new SportIntensityConfig(2.5, "Giãn cơ động (Mobility)", "Tăng biên độ chuyển động khớp"),
                new SportIntensityConfig(3.2, "Ép dẻo sâu (Deep Stretch)", "Ép xoạc và dẻo lưng sâu")
            ),
            new SportItem(
                "zumba", "Zumba / Nhảy hiện đại", "💃", "dance_mind", 45,
                new SportIntensityConfig(4.5, "Nhảy theo nhạc vui vẻ", "Bước chân cơ bản, nhịp vừa"),
                new SportIntensityConfig(6.5, "Lớp Zumba tiêu chuẩn", "Nhún nhảy liên tục suốt 45p"),
                new SportIntensityConfig(8.5, "Cardio Dance bốc lửa", "Bật nhảy, xoay người theo nhạc sôi động")
            ),
            new SportItem(
                "aerobic", "Aerobic", "🕺", "dance_mind", 40,
                new SportIntensityConfig(4.5, "Aerobic dưỡng sinh", "Động tác đều, nhịp thở êm"),
                new SportIntensityConfig(6.5, "Aerobic thể dục nhịp điệu", "Theo nhạc đều đặn cả bài"),
                new SportIntensityConfig(8.5, "Aerobic bục (Step Aerobics)", "Bước lên xuống bục liên tục")
            ),

            // ===== 6. DÃ NGOẠI, NƯỚC & NGOÀI TRỜI =====
            new SportItem(
                "swimming", "Bơi lội", "🏊‍♂️", "outdoor", 35,
                new SportIntensityConfig(5.0, "Bơi thư giãn", "Bơi thả nổi, nghỉ nhiều ở bờ"),
                new SportIntensityConfig(7.0, "Bơi ếch / Bơi sải đều", "Duy trì vòng bơi liên tục"),
                new SportIntensityConfig(10.0, "Bơi bướm / Tốc độ thi đấu", "Bơi cự ly nhanh, nhịp tim cao")
            ),
            new SportItem(
                "climbing", "Leo núi nhân tạo (Bouldering)", "🧗‍♀️", "outdoor", 45,
                new SportIntensityConfig(5.0, "Leo vách nghiêng nhẹ", "Nghỉ ngơi giữa các đường leo"),
                new SportIntensityConfig(7.5, "Bouldering tiêu chuẩn", "Gồng ngón tay, kéo xà vách đá"),
                new SportIntensityConfig(10.0, "Vách trần (Overhang)", "Toàn lực thân trên treo lơ lửng")
            ),
            new SportItem(
                "trekking", "Trekking / Leo núi dã ngoại", "🏕️", "outdoor", 90,
                new SportIntensityConfig(5.0, "Đường mòn đồi thoai thoải", "Balo nhẹ, đi thong thả"),
                new SportIntensityConfig(7.0, "Leo dốc rừng núi", "Địa hình gồ ghề, dốc liên tục"),
                new SportIntensityConfig(9.5, "Balo nặng leo dốc đứng", "Balo >10kg, vượt chướng ngại vật")
            ),
            new SportItem(
                "sup_kayak", "Chèo SUP / Kayak", "🏄‍♂️", "outdoor", 45,
                new SportIntensityConfig(4.0, "Chèo thong thả", "Nước lặng, ngắm cảnh hồ"),
                new SportIntensityConfig(5.5, "Chèo đều tay", "Duy trì tốc độ 4-6 km/h"),
                new SportIntensityConfig(7.5, "Chèo ngược dòng / Sóng", "Dùng lực xô và vai liên tục")
            ),
            new SportItem(
                "skating", "Trượt patin / Ván (Skating)", "🛹", "outdoor", 40,
                new SportIntensityConfig(4.0, "Trượt nhẹ bằng phẳng", "Tốc độ thong thả"),
                new SportIntensityConfig(6.0, "Trượt đều lực", "Duy trì tốc độ 12-15 km/h"),
                new SportIntensityConfig(8.5, "Trick / Tốc độ cao", "Bật nhảy, trượt dốc kháng lực")
            )
        };

        /// <summary>
        /// Tìm môn theo category (hoặc tất cả nếu 'all')
        /// </summary>
        public static List<SportItem> GetByCategory(string categoryId)
        {
            if (string.IsNullOrEmpty(categoryId) || categoryId == "all")
                return SportsList.ToList();

            return SportsList.Where(s => s.Category.Equals(categoryId, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Tìm emoji tương ứng theo tên bài tập
        /// </summary>
        public static string GetSportEmojiByName(string? exerciseName)
        {
            if (string.IsNullOrWhiteSpace(exerciseName)) return "🔥";

            var clean = exerciseName.Trim().ToLowerInvariant();
            var found = SportsList.FirstOrDefault(s =>
                clean.Contains(s.Name.ToLowerInvariant()) ||
                s.Name.ToLowerInvariant().Contains(clean));

            return found?.Emoji ?? "🔥";
        }

        /// <summary>
        /// Tính toán lượng Calories tiêu thụ theo chuẩn khoa học MET:
        /// Calories = round(MET * Weight(kg) * (Minutes / 60))
        /// Trọng lượng mặc định 55kg nếu chưa thiết lập hoặc <= 0
        /// </summary>
        public static int CalculateBurnedCalories(double met, double? weightKg, int durationMinutes)
        {
            double effectiveWeight = (weightKg.HasValue && weightKg.Value > 0) ? weightKg.Value : 55.0;
            int minutes = Math.Max(1, durationMinutes);
            return (int)Math.Round(met * effectiveWeight * (minutes / 60.0));
        }
    }
}
