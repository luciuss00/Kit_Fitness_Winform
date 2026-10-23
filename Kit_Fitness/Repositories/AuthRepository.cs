using Kit_Fitness.Data;
using Kit_Fitness.Models;
using Microsoft.EntityFrameworkCore;
using BCryptHasher = BCrypt.Net.BCrypt;

namespace Kit_Fitness.Repositories;

public sealed class AuthRepository
{
    /// <summary>
    /// Tạo mã khôi phục ngẫu nhiên 16 ký tự (dạng XXXX-XXXX-XXXX-XXXX).
    /// Trả về (plainText, hash).
    /// </summary>
    private static (string PlainText, string Hash) GenerateRecoveryCode()
    {
        const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
        var rng = new Random();
        var segments = new string[4];
        for (var i = 0; i < 4; i++)
        {
            var seg = new char[4];
            for (var j = 0; j < 4; j++)
                seg[j] = chars[rng.Next(chars.Length)];
            segments[i] = new string(seg);
        }
        var plain = string.Join("-", segments);   // e.g. ABCD-EF23-GHKL-MN45
        var hash  = BCryptHasher.HashPassword(plain);
        return (plain, hash);
    }

    public (bool Success, string Message, long UserId, string UserName, string RecoveryCode) Register(
        string userName,
        string password)
    {
        var normalizedUserName = userName.Trim().ToLowerInvariant();

        using var context = new KitFitnessContext();

        // Dùng username làm email (unique identifier)
        if (context.Accounts.Any(a => a.Email == normalizedUserName && !a.IsDeleted))
        {
            return (false, "Tên tài khoản này đã được đăng ký.", 0, string.Empty, string.Empty);
        }

        using var transaction = context.Database.BeginTransaction();
        try
        {
            var now = DateTime.Now;
            var user = new User
            {
                UserName  = userName.Trim(),
                UserType  = "FREE",
                MealPerDay = 3,
                CreatedAt = now,
                UpdatedAt = now,
                IsDeleted = false
            };

            context.Users.Add(user);
            context.SaveChanges();

            var (recoveryPlain, recoveryHash) = GenerateRecoveryCode();

            var account = new Account
            {
                UserId       = user.Id,
                Email        = normalizedUserName,   // lưu username vào cột email
                PasswordHash = BCryptHasher.HashPassword(password),
                RecoveryCode = recoveryHash,
                Balance      = 0,
                Status       = "ACTIVE",
                Provider     = "LOCAL",
                CreatedAt    = now,
                UpdatedAt    = now,
                IsDeleted    = false
            };

            context.Accounts.Add(account);
            context.SaveChanges();
            transaction.Commit();

            return (true, string.Empty, user.Id, user.UserName ?? userName.Trim(), recoveryPlain);
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public (bool Success, string Message, long UserId, string UserName) Login(
        string userName,
        string password)
    {
        var normalizedUserName = userName.Trim().ToLowerInvariant();
        using var context = new KitFitnessContext();

        var account = context.Accounts
            .Include(a => a.User)
            .FirstOrDefault(a => a.Email == normalizedUserName
                && !a.IsDeleted
                && a.Status == "ACTIVE"
                && a.Provider == "LOCAL"
                && !a.User.IsDeleted);

        if (account?.PasswordHash is null || !BCryptHasher.Verify(password, account.PasswordHash))
        {
            return (false, "Tên tài khoản hoặc mật khẩu không đúng.", 0, string.Empty);
        }

        return (true, string.Empty, account.UserId, account.User.UserName ?? "Người dùng");
    }

    public (bool Success, string Message) ResetPassword(
        string userName,
        string recoveryCode,
        string newPassword)
    {
        var normalizedUserName = userName.Trim().ToLowerInvariant();
        using var context = new KitFitnessContext();

        var account = context.Accounts
            .Include(a => a.User)
            .FirstOrDefault(a => a.Email == normalizedUserName
                && !a.IsDeleted
                && a.Status == "ACTIVE"
                && a.Provider == "LOCAL"
                && !a.User.IsDeleted);

        if (account is null)
        {
            return (false, "Tên tài khoản không tồn tại.");
        }

        if (account.RecoveryCode is null
            || !BCryptHasher.Verify(recoveryCode.Trim().ToUpperInvariant(), account.RecoveryCode))
        {
            return (false, "Mã khôi phục không đúng.");
        }

        // Cập nhật mật khẩu mới
        account.PasswordHash = BCryptHasher.HashPassword(newPassword);
        account.UpdatedAt    = DateTime.Now;
        context.Accounts.Update(account);
        context.SaveChanges();

        return (true, string.Empty);
    }

    public (bool Success, string Message) ChangePassword(
        long userId,
        string currentPassword,
        string newPassword)
    {
        using var context = new KitFitnessContext();

        var account = context.Accounts
            .FirstOrDefault(a => a.UserId == userId
                && !a.IsDeleted
                && a.Status == "ACTIVE"
                && a.Provider == "LOCAL");

        if (account is null)
        {
            return (false, "Không tìm thấy tài khoản hợp lệ.");
        }

        if (account.PasswordHash is null || !BCryptHasher.Verify(currentPassword, account.PasswordHash))
        {
            return (false, "Mật khẩu hiện tại không chính xác.");
        }

        if (BCryptHasher.Verify(newPassword, account.PasswordHash))
        {
            return (false, "Mật khẩu mới không được trùng với mật khẩu hiện tại.");
        }

        account.PasswordHash = BCryptHasher.HashPassword(newPassword);
        account.UpdatedAt    = DateTime.Now;
        context.Accounts.Update(account);
        context.SaveChanges();

        return (true, string.Empty);
    }
}
