namespace Kit_Fitness.Models;

public partial class MenuItem
{
    public long Id { get; set; }

    public long MenuId { get; set; }

    public string DayOfWeek { get; set; } = null!;

    public string MealType { get; set; } = null!;

    public long FoodId { get; set; }

    public decimal Quantity { get; set; }

    public string? TrafficLight { get; set; }

    public virtual Food Food { get; set; } = null!;

    public virtual Menu Menu { get; set; } = null!;
}
