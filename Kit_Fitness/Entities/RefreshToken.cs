using System;
using System.Collections.Generic;

namespace Kit_Fitness.Models;

public partial class RefreshToken
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }

    public bool Revoked { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;
}
