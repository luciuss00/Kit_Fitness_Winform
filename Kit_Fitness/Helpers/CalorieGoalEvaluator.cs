namespace Kit_Fitness.Helpers;

public class CalorieStatusResult
{
    public string TrafficLight { get; set; } = "GREEN";
    public string BadgeText { get; set; } = string.Empty;
    public string BadgeStyle { get; set; } = "fresh";
    public string Message { get; set; } = string.Empty;
    public Color ForeColor { get; set; } = Color.FromArgb(47, 82, 51);
    public Color BackColor { get; set; } = Color.FromArgb(235, 242, 235);
}

public static class CalorieGoalEvaluator
{
    public static CalorieStatusResult EvaluateDailyCalorieStatus(
        string? goal,
        decimal totalCalories,
        decimal targetCalories,
        int itemsCount = 1)
    {
        if (itemsCount == 0 || totalCalories <= 0)
        {
            return new CalorieStatusResult
            {
                TrafficLight = "GREEN",
                BadgeText = "CHƯA GHI MÓN",
                BadgeStyle = "empty",
                Message = "Hôm nay bạn chưa ghi nhận món ăn nào.",
                ForeColor = Color.FromArgb(124, 115, 104),
                BackColor = Color.FromArgb(245, 239, 228)
            };
        }

        if (targetCalories <= 0)
        {
            return new CalorieStatusResult
            {
                TrafficLight = "GREEN",
                BadgeText = "TƯƠI LÀNH & CÂN BẰNG",
                BadgeStyle = "fresh",
                Message = "Chế độ ăn lành mạnh mỗi ngày.",
                ForeColor = Color.FromArgb(47, 82, 51),
                BackColor = Color.FromArgb(235, 242, 235)
            };
        }

        decimal ratio = (totalCalories / targetCalories) * 100.0m;
        string normGoal = TrafficLightHelper.NormalizeGoal(goal);

        switch (normGoal)
        {
            case "GAIN_WEIGHT":
                if (ratio < 75m)
                {
                    return new CalorieStatusResult
                    {
                        TrafficLight = "RED",
                        BadgeText = "LƯU Ý • CHƯA ĐỦ CALO",
                        BadgeStyle = "warning",
                        Message = "Lượng calo còn quá thấp so với mục tiêu tăng cân. Cần bổ sung thêm bữa phụ giàu dinh dưỡng!",
                        ForeColor = Color.FromArgb(181, 67, 43),
                        BackColor = Color.FromArgb(252, 236, 233)
                    };
                }
                if (ratio < 93m)
                {
                    return new CalorieStatusResult
                    {
                        TrafficLight = "YELLOW",
                        BadgeText = "CẦN NẠP THÊM CALO",
                        BadgeStyle = "balance",
                        Message = "Đang tiến gần mục tiêu, hãy nạp thêm một chút calo để đạt thặng dư tăng cân nạc.",
                        ForeColor = Color.FromArgb(180, 130, 20),
                        BackColor = Color.FromArgb(255, 249, 219)
                    };
                }
                if (ratio <= 110m)
                {
                    return new CalorieStatusResult
                    {
                        TrafficLight = "GREEN",
                        BadgeText = "ĐẠT CHUẨN TĂNG CÂN",
                        BadgeStyle = "fresh",
                        Message = "Thặng dư tối ưu! Đủ dinh dưỡng để tăng cơ nạc bền vững, hạn chế tích mỡ.",
                        ForeColor = Color.FromArgb(47, 82, 51),
                        BackColor = Color.FromArgb(235, 242, 235)
                    };
                }
                return new CalorieStatusResult
                {
                    TrafficLight = "RED",
                    BadgeText = "CẢNH BÁO • DƯ THỪA CALO",
                    BadgeStyle = "warning",
                    Message = "Calo vượt quá mức thặng dư nạc (> 110%), dễ tích tụ mỡ thừa ngoài ý muốn.",
                    ForeColor = Color.FromArgb(181, 67, 43),
                    BackColor = Color.FromArgb(252, 236, 233)
                };

            case "MAINTAIN":
                if (ratio < 80m)
                {
                    return new CalorieStatusResult
                    {
                        TrafficLight = "YELLOW",
                        BadgeText = "THIẾU NĂNG LƯỢNG",
                        BadgeStyle = "balance",
                        Message = "Calo thấp hơn mức tiêu hao duy trì. Kéo dài có thể bị sụt cân ngoài ý muốn.",
                        ForeColor = Color.FromArgb(180, 130, 20),
                        BackColor = Color.FromArgb(255, 249, 219)
                    };
                }
                if (ratio <= 105m)
                {
                    return new CalorieStatusResult
                    {
                        TrafficLight = "GREEN",
                        BadgeText = "CÂN BẰNG • ỔN ĐỊNH",
                        BadgeStyle = "fresh",
                        Message = "Năng lượng nạp vào cân bằng với mức đốt cháy. Vóc dáng duy trì ổn định!",
                        ForeColor = Color.FromArgb(47, 82, 51),
                        BackColor = Color.FromArgb(235, 242, 235)
                    };
                }
                if (ratio <= 112m)
                {
                    return new CalorieStatusResult
                    {
                        TrafficLight = "YELLOW",
                        BadgeText = "CHẠM TRẦN CALO",
                        BadgeStyle = "balance",
                        Message = "Đang tiệm cận mức dư thừa nhẹ trong ngày. Nên tiết chế bữa ăn muộn.",
                        ForeColor = Color.FromArgb(180, 130, 20),
                        BackColor = Color.FromArgb(255, 249, 219)
                    };
                }
                return new CalorieStatusResult
                {
                    TrafficLight = "RED",
                    BadgeText = "LƯU Ý • VƯỢT CALO",
                    BadgeStyle = "warning",
                    Message = "Vượt quá mức calo duy trì trong ngày, lượng dư thừa sẽ tích trữ mỡ nếu không vận động bù.",
                    ForeColor = Color.FromArgb(181, 67, 43),
                    BackColor = Color.FromArgb(252, 236, 233)
                };

            case "LOSE_WEIGHT":
            default:
                if (ratio < 60m)
                {
                    return new CalorieStatusResult
                    {
                        TrafficLight = "YELLOW",
                        BadgeText = "CẢNH BÁO • ĂN QUÁ ÍT",
                        BadgeStyle = "warning",
                        Message = "Calo quá thấp có thể gây sụt giảm chuyển hóa và mất cơ. Hãy bổ sung thêm đạm và rau củ!",
                        ForeColor = Color.FromArgb(180, 130, 20),
                        BackColor = Color.FromArgb(255, 249, 219)
                    };
                }
                if (ratio <= 85m)
                {
                    return new CalorieStatusResult
                    {
                        TrafficLight = "GREEN",
                        BadgeText = "ĐANG TRONG MỤC TIÊU",
                        BadgeStyle = "fresh",
                        Message = "Mức thâm hụt lý tưởng! Cơ thể đang chuyển hóa mỡ thừa hiệu quả.",
                        ForeColor = Color.FromArgb(47, 82, 51),
                        BackColor = Color.FromArgb(235, 242, 235)
                    };
                }
                if (ratio <= 105m)
                {
                    return new CalorieStatusResult
                    {
                        TrafficLight = "GREEN",
                        BadgeText = "HOÀN THÀNH MỤC TIÊU",
                        BadgeStyle = "fresh",
                        Message = "Đạt chuẩn calo giảm mỡ an toàn trong ngày. Chúc mừng bạn!",
                        ForeColor = Color.FromArgb(47, 82, 51),
                        BackColor = Color.FromArgb(235, 242, 235)
                    };
                }
                return new CalorieStatusResult
                {
                    TrafficLight = "RED",
                    BadgeText = "LƯU Ý • VƯỢT CALO",
                    BadgeStyle = "warning",
                    Message = "Calo đã vượt quá ngân sách giảm mỡ trong ngày. Hãy chú ý tiết chế bữa tiếp theo!",
                    ForeColor = Color.FromArgb(181, 67, 43),
                    BackColor = Color.FromArgb(252, 236, 233)
                };
        }
    }
}
