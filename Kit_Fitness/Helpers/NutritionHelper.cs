namespace Kit_Fitness.Helpers;

public static class NutritionHelper
{
    /// <summary>
    /// Các đơn vị đo lường tính theo 100 đơn vị (100g, 100ml).
    /// </summary>
    public static bool IsPer100Unit(string? unit)
    {
        if (string.IsNullOrWhiteSpace(unit)) return false;
        var u = unit.Trim().ToLowerInvariant();
        return u == "g" || u == "ml" || u == "gram" || u == "gr";
    }

    /// <summary>
    /// Quy đổi dinh dưỡng theo đơn vị:
    /// - Nếu unit là g, ml, gram: value * qty / 100
    /// - Nếu unit là quả, bát, tô, đĩa, hộp, phần...: value * qty
    /// </summary>
    public static decimal ScaleByUnit(decimal? value, decimal? quantity, string? unit)
    {
        if (value == null || quantity == null) return 0m;
        return IsPer100Unit(unit)
            ? (value.Value * quantity.Value) / 100m
            : value.Value * quantity.Value;
    }

    /// <summary>
    /// Làm tròn nửa lên (Round half up)
    /// </summary>
    public static int RoundToInt(decimal value)
    {
        return (int)Math.Round(value, MidpointRounding.AwayFromZero);
    }

    public static decimal RoundToOneDecimal(decimal value)
    {
        return Math.Round(value, 1, MidpointRounding.AwayFromZero);
    }
}
