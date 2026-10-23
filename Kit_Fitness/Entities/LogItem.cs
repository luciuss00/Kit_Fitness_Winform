using System;
using System.Collections.Generic;

namespace Kit_Fitness.Models;

public partial class LogItem
{
    public long Id { get; set; }

    public long DailyLogId { get; set; }

    public long FoodId { get; set; }

    public string TimeSlot { get; set; } = null!;

    public decimal Quantity { get; set; }

    public string? TrafficLight { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual DailyLog DailyLog { get; set; } = null!;

    public virtual Food Food { get; set; } = null!;
}
