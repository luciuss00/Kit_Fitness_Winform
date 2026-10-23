using System;
using System.Collections.Generic;

namespace Kit_Fitness.Models;

public partial class Account
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string Email { get; set; } = null!;

    public string? PasswordHash { get; set; }

    public string? RecoveryCode { get; set; }

    public decimal Balance { get; set; }

    public string Status { get; set; } = null!;

    public string Provider { get; set; } = null!;

    public string? ProviderId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual User User { get; set; } = null!;
}
