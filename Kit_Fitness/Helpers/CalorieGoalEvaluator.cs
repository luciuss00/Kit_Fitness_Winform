namespace Kit_Fitness.Helpers;

/// <summary>
/// Kết quả đánh giá trạng thái calo hàng ngày (Traffic Light)
/// </summary>
public class CalorieStatusResult
{
    public string TrafficLight { get; set; } = "GREEN"; // Màu đèn: GREEN, YELLOW, RED
    public string BadgeText { get; set; } = string.Empty; // Chữ hiển thị trên huy hiệu (VD: ĐẠT CHUẨN, LƯU Ý)
    public string BadgeStyle { get; set; } = "fresh";     // Kiểu dáng CSS/Giao diện
    public string Message { get; set; } = string.Empty;    // Lời khuyên dinh dưỡng cụ thể
    public Color ForeColor { get; set; } = Color.FromArgb(47, 82, 51); // Màu chữ
    public Color BackColor { get; set; } = Color.FromArgb(235, 242, 235); // Màu nền huy hiệu
}

public static class CalorieGoalEvaluator
{
    /// <summary>
    /// Thuật toán đánh giá chế độ ăn uống theo cơ chế Đèn Giao Thông (Traffic Light System)
    /// </summary>
    /// <param name="goal">Mục tiêu của người dùng (Giảm cân / Tăng cân / Giữ dáng)</param>
    /// <param name="totalCalories">Tổng calo thực tế đã nạp trong ngày (kcal)</param>
    /// <param name="targetCalories">Mục tiêu calo hàng ngày theo kế hoạch TDEE (kcal)</param>
    /// <param name="itemsCount">Số lượng món ăn đã ghi nhận trong ngày</param>
    public static CalorieStatusResult EvaluateDailyCalorieStatus(
        string? goal,
        decimal totalCalories,
        decimal targetCalories,
        int itemsCount = 1)
    {
        // 1. Trường hợp người dùng chưa ghi nhận món nào trong ngày
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

        // 2. Trường hợp chưa cấu hình mục tiêu calo (targetCalories <= 0)
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

        // ratio: Tỷ lệ phần trăm (%) calo đã nạp vào so với calo mục tiêu (VD: ăn 1500/2000 => ratio = 75%)
        decimal ratio = (totalCalories / targetCalories) * 100.0m;

        // normGoal: Chuẩn hóa chuỗi mục tiêu về 3 mã chuẩn duy nhất: "GAIN_WEIGHT", "LOSE_WEIGHT", "MAINTAIN"
        string normGoal = TrafficLightHelper.NormalizeGoal(goal);

        switch (normGoal)
        {
            // ================= MỤC TIÊU 1: TĂNG CÂN & TĂNG CƠ (GAIN_WEIGHT) =================
            case "GAIN_WEIGHT":
                if (ratio < 75m)
                {
                    // Nạp < 75%: Đèn ĐỎ - Quá ít calo, không thể tăng cân
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
                    // Nạp 75% - 93%: Đèn VÀNG - Đang tiến gần, cần nạp thêm một chút để thặng dư
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
                    // Nạp 93% - 110%: Đèn XANH - Mức thặng dư lý tưởng (+10% đến +15%) để tăng cơ nạc bền vững
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
                // Nạp > 110%: Đèn ĐỎ - Vượt quá ngưỡng thặng dư nạc, tích mỡ thừa ngoài ý muốn
                return new CalorieStatusResult
                {
                    TrafficLight = "RED",
                    BadgeText = "CẢNH BÁO • DƯ THỪA CALO",
                    BadgeStyle = "warning",
                    Message = "Calo vượt quá mức thặng dư nạc (> 110%), dễ tích tụ mỡ thừa ngoài ý muốn.",
                    ForeColor = Color.FromArgb(181, 67, 43),
                    BackColor = Color.FromArgb(252, 236, 233)
                };

            // ================= MỤC TIÊU 2: GIỮ DÁNG & DUY TRÌ (MAINTAIN) =================
            case "MAINTAIN":
                if (ratio < 80m)
                {
                    // Nạp < 80%: Đèn VÀNG - Thiếu hụt calo, duy trì lâu sẽ bị sụt cân
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
                    // Nạp 80% - 105%: Đèn XANH - Nạp vào = Tiêu hao, vóc dáng giữ nguyên ổn định
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
                    // Nạp 105% - 112%: Đèn VÀNG - Chạm trần calo duy trì
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
                // Nạp > 112%: Đèn ĐỎ - Ăn dư thừa, dễ tăng cân ngoài mong muốn
                return new CalorieStatusResult
                {
                    TrafficLight = "RED",
                    BadgeText = "LƯU Ý • VƯỢT CALO",
                    BadgeStyle = "warning",
                    Message = "Vượt quá mức calo duy trì trong ngày, lượng dư thừa sẽ tích trữ mỡ nếu không vận động bù.",
                    ForeColor = Color.FromArgb(181, 67, 43),
                    BackColor = Color.FromArgb(252, 236, 233)
                };

            // ================= MỤC TIÊU 3: GIẢM MỠ & GIẢM CÂN (LOSE_WEIGHT) =================
            case "LOSE_WEIGHT":
            default:
                if (ratio < 60m)
                {
                    // Nạp < 60%: Đèn VÀNG - Nhịn ăn quá đà, suy giảm trao đổi chất và mất cơ
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
                    // Nạp 60% - 85%: Đèn XANH - Thâm hụt lý tưởng, cơ thể đốt mỡ tự nhiên
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
                    // Nạp 85% - 105%: Đèn XANH - Hoàn thành mục tiêu ngân sách calo giảm mỡ
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
                // Nạp > 105%: Đèn ĐỎ - Vượt quá ngân sách calo giảm cân
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
