using System;
using System.Collections.Generic;

namespace Kit_Fitness.Models;

public partial class WeightLog
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public decimal Weight { get; set; }

    public DateOnly LogDate { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User User { get; set; } = null!;
}
