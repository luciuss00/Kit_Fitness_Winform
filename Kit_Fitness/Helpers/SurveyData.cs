namespace Kit_Fitness.Helpers
{
    public class SurveyData
    {
        public string Gender { get; set; } = "Nữ";
        public int Age { get; set; } = 24;
        public decimal Height { get; set; } = 160;
        public decimal Weight { get; set; } = 50;
        public string Goal { get; set; } = "Giảm mỡ & Nhẹ người";
        public decimal TargetWeight { get; set; } = 47;
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
    }

    public static class SurveyMetricsCalculator
    {
        public static ScientificMetrics Calculate(SurveyData data)
        {
            return Calculate(data.Gender, data.Age, data.Height, data.Weight, data.Goal, data.ActivityLevel);
        }

        public static ScientificMetrics Calculate(string gender, int age, decimal heightCm, decimal weightKg, string goal, string activity)
        {
            // 1. BMI: weight / (height/100)^2
            double hM = (double)heightCm / 100.0;
            double bmi = (hM > 0) ? (double)weightKg / (hM * hM) : 0;
            string bmiStatus = bmi switch
            {
                < 18.5 => "THIẾU CÂN",
                <= 24.9 => "BÌNH THƯỜNG",
                <= 29.9 => "THỪA CÂN",
                _ => "BÉO PHÌ"
            };

            // 2. BMR (Mifflin-St Jeor)
            double w = (double)weightKg;
            double h = (double)heightCm;
            double bmrRaw = (gender == "Nam")
                ? (10.0 * w + 6.25 * h - 5.0 * age + 5)
                : (10.0 * w + 6.25 * h - 5.0 * age - 161);
            int bmr = (int)Math.Round(bmrRaw);

            // 3. TDEE
            double activityMult = activity switch
            {
                var a when a.Contains("Ít vận động") => 1.2,
                var a when a.Contains("nhẹ nhàng") => 1.375,
                var a when a.Contains("vừa phải") => 1.55,
                var a when a.Contains("Cường độ cao") => 1.725,
                _ => 1.55
            };
            int tdee = (int)Math.Round(bmr * activityMult);

            // 4. Target Calories
            int targetCal = tdee;
            if (goal.Contains("Giảm mỡ"))
            {
                targetCal = tdee - 500;
            }
            else if (goal.Contains("Tăng cân"))
            {
                targetCal = tdee + 300;
            }
            if (targetCal < 1000) targetCal = 1000;

            // 5. Macros (Protein 30%, Carb 45%, Fat 25%)
            int protein = (int)Math.Round((targetCal * 0.30) / 4.0);
            int carbs = (int)Math.Round((targetCal * 0.45) / 4.0);
            int fat = (int)Math.Round((targetCal * 0.25) / 9.0);

            // 6. Water (~36 ml / kg)
            int waterMl = (int)Math.Round(w * 36.0 / 100.0) * 100;
            if (waterMl < 1500) waterMl = 1500;

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
                WaterMl = waterMl
            };
        }
    }
}
