namespace Kit_Fitness.Models;

public partial class UserActiveMenu
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long MenuId { get; set; }

    public DateOnly StartDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Menu Menu { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
