namespace Kit_Fitness.Helpers;

public class SurveyData
{
    public string Gender { get; set; } = "Nữ";
    public int Age { get; set; } = 24;
    public decimal Height { get; set; } = 160;
    public decimal Weight { get; set; } = 50;
    public string Goal { get; set; } = "Giảm mỡ & Nhẹ người";
    public decimal TargetWeight { get; set; } = 47;
    public double WeeklyRateKg { get; set; } = 0.5;
    public string ActivityLevel { get; set; } = "Vận động vừa phải (Khuyên dùng)";
}

public class ScientificMetrics
{
    public double Bmi { get; set; }
    public string BmiStatus { get; set; } = "BÌNH THƯỜNG";
    public int Bmr { get; set; }
    public int Tdee { get; set; }
    public int TargetCal { get; set; }
    public int ProteinGrams { get; set; }
    public int CarbGrams { get; set; }
    public int FatGrams { get; set; }
    public int WaterMl { get; set; }
    public int WeeksNeeded { get; set; }
    public DateOnly EstimatedDate { get; set; }
    public string CampaignBadge { get; set; } = string.Empty;
    public string MotivationalTitle { get; set; } = string.Empty;
    public string MotivationalMessage { get; set; } = string.Empty;
}

public static class SurveyMetricsCalculator
{
    public static ScientificMetrics Calculate(SurveyData data)
    {
        return Calculate(
            data.Gender,
            data.Age,
            data.Height,
            data.Weight,
            data.Goal,
            data.ActivityLevel,
            data.TargetWeight,
            data.WeeklyRateKg);
    }

    public static ScientificMetrics Calculate(
        string gender,
        int age,
        decimal heightCm,
        decimal weightKg,
        string goal,
        string activity,
        decimal? targetWeightKg = null,
        double? weeklyRateKg = null)
    {
        // 1. BMI: weight / (height/100)^2
        double hM = (double)heightCm / 100.0;
        double bmi = (hM > 0) ? (double)weightKg / (hM * hM) : 0;
        string bmiStatus = bmi switch
        {
            < 18.5 => "HƠI GẦY",
            <= 24.9 => "BÌNH THƯỜNG",
            <= 29.9 => "THỪA CÂN NHẸ",
            _ => "BÉO PHÌ"
        };

        // 2. BMR (Mifflin-St Jeor: Nam +5, Nữ -161)
        double w = (double)weightKg;
        double h = (double)heightCm;
        string gUpper = gender.ToUpperInvariant();
        bool isMale = gUpper == "NAM" || gUpper == "MALE";
        double bmrRaw = isMale
            ? (10.0 * w + 6.25 * h - 5.0 * age + 5)
            : (10.0 * w + 6.25 * h - 5.0 * age - 161);
        int bmr = (int)Math.Round(bmrRaw);

        // 3. TDEE
        string act = (activity ?? "").ToUpperInvariant();
        double activityMult = act switch
        {
            var a when a.Contains("SEDENTARY") || a.Contains("ÍT VẬN ĐỘNG") => 1.2,
            var a when a.Contains("LIGHT") || a.Contains("NHẸ") => 1.375,
            var a when a.Contains("ACTIVE") && !a.Contains("VERY") || a.Contains("NĂNG ĐỘNG") => 1.725,
            var a when a.Contains("VERY_ACTIVE") || a.Contains("CƯỜNG ĐỘ CAO") || a.Contains("RẤT NĂNG") => 1.9,
            _ => 1.55 // MODERATE (Vừa phải)
        };
        int tdee = (int)Math.Round(bmr * activityMult);

        // 4. Target Calories dựa trên Goal & Weekly Rate
        string normGoal = TrafficLightHelper.NormalizeGoal(goal);
        double rate = weeklyRateKg ?? 0.5;
        if (rate <= 0) rate = 0.5;

        // 1 kg mỡ = ~7700 kcal
        int dailyAdjustment = (int)Math.Round((rate * 7700.0) / 7.0);

        int targetCal = tdee;
        if (normGoal == "LOSE_WEIGHT")
        {
            targetCal = tdee - dailyAdjustment;
            if (targetCal < 1200) targetCal = 1200; // Ngưỡng an toàn tối thiểu
        }
        else if (normGoal == "GAIN_WEIGHT")
        {
            targetCal = tdee + Math.Min(500, dailyAdjustment);
        }

        // 5. Macros (Chuẩn dinh dưỡng: Protein 30%, Carbs 40%, Fat 30%)
        int protein = (int)Math.Round((targetCal * 0.30) / 4.0);
        int carbs = (int)Math.Round((targetCal * 0.40) / 4.0);
        int fat = (int)Math.Round((targetCal * 0.30) / 9.0);

        // 6. Water (~36 ml / kg)
        int waterMl = (int)Math.Round(w * 36.0 / 100.0) * 100;
        if (waterMl < 1500) waterMl = 1500;

        // 7. ETA (Tuần hoàn thành mục tiêu cân nặng)
        int weeksNeeded = 0;
        if (targetWeightKg.HasValue && normGoal != "MAINTAIN")
        {
            double diff = Math.Abs((double)weightKg - (double)targetWeightKg.Value);
            weeksNeeded = (int)Math.Ceiling(diff / rate);
        }
        var estDate = DateOnly.FromDateTime(DateTime.Today.AddDays(weeksNeeded * 7));

        // 8. Motivational Quote & Title theo Mục tiêu & BMI
        string campaignBadge = normGoal switch
        {
            "LOSE_WEIGHT" => "🌿 CHIẾN DỊCH GIẢM MỠ & TÁI TẠO NĂNG LƯỢNG",
            "GAIN_WEIGHT" => "⚡ CHIẾN DỊCH TĂNG CƠ & BỨT PHÁ THỂ LỰC",
            _ => "🍃 DUY TRÌ PHONG ĐỘ & CÂN BẰNG TƯƠI SẠCH"
        };

        string title = normGoal switch
        {
            "LOSE_WEIGHT" => "Chinh phục vóc dáng thanh thoát! 🚀",
            "GAIN_WEIGHT" => "Bứt phá giới hạn - Tăng cơ mạnh mẽ! 💪",
            _ => "Giữ vững phong độ đỉnh cao! 🌟"
        };

        string message = normGoal switch
        {
            "LOSE_WEIGHT" => $"Với mức calo mục tiêu {targetCal:N0} Kcal/ngày thâm hụt an toàn và {protein}g đạm, bạn hoàn toàn không cần nhịn ăn khắc khổ. Hãy kiên trì trong ~{weeksNeeded} tuần tới, cơ thể sẽ có sự chuyển hóa kỳ diệu!",
            "GAIN_WEIGHT" => $"Lộ trình {targetCal:N0} Kcal/ngày dồi dào kết hợp {protein}g đạm chất lượng cao là chìa khóa vàng giúp bạn tái tạo cơ bắp săn chắc sau ~{weeksNeeded} tuần!",
            _ => $"Thể trạng hiện tại của bạn đang rất cân bằng (BMI {Math.Round(bmi, 1)}). Mức {targetCal:N0} Kcal/ngày này sẽ là người bạn đồng hành hoàn hảo để duy trì thể lực tươi trẻ!"
        };

        return new ScientificMetrics
        {
            Bmi = Math.Round(bmi, 1),
            BmiStatus = bmiStatus,
            Bmr = bmr,
            Tdee = tdee,
            TargetCal = targetCal,
            ProteinGrams = protein,
            CarbGrams = carbs,
            FatGrams = fat,
            WaterMl = waterMl,
            WeeksNeeded = weeksNeeded,
            EstimatedDate = estDate,
            CampaignBadge = campaignBadge,
            MotivationalTitle = title,
            MotivationalMessage = message
        };
    }
}
