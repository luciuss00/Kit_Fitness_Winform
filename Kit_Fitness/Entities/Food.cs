namespace Kit_Fitness.Models;

public partial class Food
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public decimal? Fat { get; set; }

    public decimal? Carbs { get; set; }

    public decimal? Protein { get; set; }

    public int Calories { get; set; }

    public bool IsCustom { get; set; }

    public long? CreateByUserId { get; set; }

    public long? CreateByAdminId { get; set; }

    public string? Type { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Admin? CreateByAdmin { get; set; }

    public virtual ICollection<FridgeItem> FridgeItems { get; set; } = new List<FridgeItem>();

    public virtual ICollection<LogItem> LogItems { get; set; } = new List<LogItem>();

    public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
}
