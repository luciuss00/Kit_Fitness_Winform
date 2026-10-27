namespace Kit_Fitness.Helpers;

/// <summary>
/// Lớp tiện ích hỗ trợ tính toán & quy đổi chỉ số dinh dưỡng (Macro & Calo)
/// theo khối lượng thực tế và đơn vị tính (g, ml, quả, hộp, bát,...)
/// </summary>
public static class NutritionHelper
{
    /// <summary>
    /// Kiểm tra xem đơn vị tính có phải là dạng chuẩn 100 đơn vị (100g, 100ml) hay không.
    /// Trong cơ sở dữ liệu dinh dưỡng chuẩn USDA / Viện Dinh Dưỡng, 
    /// các chỉ số dinh dưỡng của thịt, cá, rau củ luôn được lưu trên 100g hoặc 100ml.
    /// </summary>
    public static bool IsPer100Unit(string? unit)
    {
        if (string.IsNullOrWhiteSpace(unit)) return false;
        var u = unit.Trim().ToLowerInvariant();
        return u == "g" || u == "ml" || u == "gram" || u == "gr";
    }

    /// <summary>
    /// Quy đổi giá trị dinh dưỡng (Calo, Protein, Carbs, Fat) theo khối lượng thực tế:
    /// - Nếu là đơn vị khối lượng (g, ml): Giá trị thực = (Dinh dưỡng chuẩn 100g * Khối lượng ăn) / 100
    ///   Ví dụ: Ức gà 165 calo/100g, ăn 200g => (165 * 200) / 100 = 330 kcal.
    /// - Nếu là đơn vị đếm (quả, bát, tô, đĩa, hộp, phần...): Giá trị thực = Dinh dưỡng trên 1 đơn vị * Số lượng
    ///   Ví dụ: Trứng gà 78 calo/quả, ăn 2 quả => 78 * 2 = 156 kcal.
    /// </summary>
    public static decimal ScaleByUnit(decimal? value, decimal? quantity, string? unit)
    {
        if (value == null || quantity == null) return 0m;
        return IsPer100Unit(unit)
            ? (value.Value * quantity.Value) / 100m
            : value.Value * quantity.Value;
    }

    /// <summary>
    /// Làm tròn số nguyên chuẩn toán học (AwayFromZero: .5 luôn làm tròn lên)
    /// </summary>
    public static int RoundToInt(decimal value)
    {
        return (int)Math.Round(value, MidpointRounding.AwayFromZero);
    }

    /// <summary>
    /// Làm tròn 1 chữ số thập phân (VD: 23.45 => 23.5)
    /// </summary>
    public static decimal RoundToOneDecimal(decimal value)
    {
        return Math.Round(value, 1, MidpointRounding.AwayFromZero);
    }
}
