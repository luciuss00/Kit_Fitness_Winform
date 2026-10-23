namespace Kit_Fitness.Models;

public partial class Menu
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Category { get; set; }

    public int? TargetCalories { get; set; }

    public string? ImageUrl { get; set; }

    public bool IsSystem { get; set; }

    public long? CreatedByUserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User? CreatedByUser { get; set; }

    public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

    public virtual ICollection<UserActiveMenu> UserActiveMenus { get; set; } = new List<UserActiveMenu>();
}
