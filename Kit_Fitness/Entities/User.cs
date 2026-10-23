namespace Kit_Fitness.Models;

public partial class User
{
    public long Id { get; set; }

    public string? UserName { get; set; }

    public int? TargetCalories { get; set; }

    public decimal? Height { get; set; }

    public decimal? Weight { get; set; }

    public string UserType { get; set; } = null!;

    public int MealPerDay { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public string? ActivityLevel { get; set; }

    public string? Goal { get; set; }

    public double? WeeklyRateKg { get; set; }

    public double? TargetWeightKg { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<DailyLog> DailyLogs { get; set; } = new List<DailyLog>();

    public virtual ICollection<FridgeItem> FridgeItems { get; set; } = new List<FridgeItem>();

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<UserActiveMenu> UserActiveMenus { get; set; } = new List<UserActiveMenu>();

    public virtual ICollection<WaterLog> WaterLogs { get; set; } = new List<WaterLog>();

    public virtual ICollection<WeightLog> WeightLogs { get; set; } = new List<WeightLog>();

    public virtual ICollection<WorkoutLog> WorkoutLogs { get; set; } = new List<WorkoutLog>();
}
