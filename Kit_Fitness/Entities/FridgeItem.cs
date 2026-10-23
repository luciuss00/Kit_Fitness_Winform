using System;
using System.Collections.Generic;

namespace Kit_Fitness.Models;

public partial class FridgeItem
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long? FoodId { get; set; }

    public decimal Quantity { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public string StorageType { get; set; } = null!;

    public DateTime? LastNotifiedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Food? Food { get; set; }

    public virtual User User { get; set; } = null!;
}
