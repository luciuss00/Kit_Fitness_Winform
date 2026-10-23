using System;
using System.Collections.Generic;

namespace Kit_Fitness.Models;

public partial class DailyLog
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public DateOnly LogDate { get; set; }

    public string MealType { get; set; } = null!;

    public int TotalCalories { get; set; }

    public int TotalProtein { get; set; }

    public int TotalCarbs { get; set; }

    public int TotalFat { get; set; }

    public string? MealTrafficLight { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<LogItem> LogItems { get; set; } = new List<LogItem>();

    public virtual User User { get; set; } = null!;
}
