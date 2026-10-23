using System;
using System.Collections.Generic;

namespace Kit_Fitness.Models;

public partial class WorkoutLog
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public DateOnly LogDate { get; set; }

    public string ExerciseName { get; set; } = null!;

    public int DurationMinutes { get; set; }

    public int BurnedCalories { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User User { get; set; } = null!;
}
