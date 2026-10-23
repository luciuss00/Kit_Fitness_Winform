using Kit_Fitness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kit_Fitness.Data;

public partial class KitFitnessContext : DbContext
{
    public KitFitnessContext()
    {
    }

    public KitFitnessContext(DbContextOptions<KitFitnessContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<DailyLog> DailyLogs { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<FridgeItem> FridgeItems { get; set; }

    public virtual DbSet<LogItem> LogItems { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserActiveMenu> UserActiveMenus { get; set; }

    public virtual DbSet<WaterLog> WaterLogs { get; set; }

    public virtual DbSet<WeightLog> WeightLogs { get; set; }

    public virtual DbSet<WorkoutLog> WorkoutLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__accounts__3213E83F76921E4A");

            entity.ToTable("accounts");

            entity.HasIndex(e => e.Email, "UQ__accounts__AB6E61646A8BD4DD").IsUnique();

            entity.HasIndex(e => e.Email, "idx_accounts_email");

            entity.HasIndex(e => e.UserId, "idx_accounts_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Balance)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("balance");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.RecoveryCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("recovery_code");
            entity.Property(e => e.Provider)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("LOCAL")
                .HasColumnName("provider");
            entity.Property(e => e.ProviderId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("provider_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("ACTIVE")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_accounts_user");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__admins__3213E83F27F69BA5");

            entity.ToTable("admins");

            entity.HasIndex(e => e.Email, "UQ__admins__AB6E6164C84885B1").IsUnique();

            entity.HasIndex(e => e.Email, "idx_admins_email");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("ADMIN")
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<DailyLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__daily_lo__3213E83FEAC3628D");

            entity.ToTable("daily_logs");

            entity.HasIndex(e => new { e.UserId, e.LogDate }, "idx_daily_logs_user_date");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.LogDate).HasColumnName("log_date");
            entity.Property(e => e.MealTrafficLight)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("meal_traffic_light");
            entity.Property(e => e.MealType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("meal_type");
            entity.Property(e => e.TotalCalories).HasColumnName("total_calories");
            entity.Property(e => e.TotalCarbs).HasColumnName("total_carbs");
            entity.Property(e => e.TotalFat).HasColumnName("total_fat");
            entity.Property(e => e.TotalProtein).HasColumnName("total_protein");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.DailyLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_daily_logs_user");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__foods__3213E83F9DCDD3DE");

            entity.ToTable("foods");

            entity.HasIndex(e => e.IsDeleted, "idx_foods_is_deleted");

            entity.HasIndex(e => e.Name, "idx_foods_name");

            entity.HasIndex(e => e.Type, "idx_foods_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calories).HasColumnName("calories");
            entity.Property(e => e.Carbs)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("carbs");
            entity.Property(e => e.CreateByAdminId).HasColumnName("create_by_admin_id");
            entity.Property(e => e.CreateByUserId).HasColumnName("create_by_user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Fat)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("fat");
            entity.Property(e => e.IsCustom).HasColumnName("is_custom");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Protein)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("protein");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("g")
                .HasColumnName("unit");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.CreateByAdmin).WithMany(p => p.Foods)
                .HasForeignKey(d => d.CreateByAdminId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_foods_admin");
        });

        modelBuilder.Entity<FridgeItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__fridge_i__3213E83FE440B420");

            entity.ToTable("fridge_items");

            entity.HasIndex(e => e.ExpiryDate, "idx_fridge_items_expiry");

            entity.HasIndex(e => new { e.UserId, e.StorageType }, "idx_fridge_items_user_storage");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiryDate).HasColumnName("expiry_date");
            entity.Property(e => e.FoodId).HasColumnName("food_id");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.LastNotifiedAt).HasColumnName("last_notified_at");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1.00m)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("quantity");
            entity.Property(e => e.StorageType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("CHILL")
                .HasColumnName("storage_type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Food).WithMany(p => p.FridgeItems)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_fridge_items_food");

            entity.HasOne(d => d.User).WithMany(p => p.FridgeItems)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_fridge_items_user");
        });

        modelBuilder.Entity<LogItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__log_item__3213E83FA15DAC19");

            entity.ToTable("log_items");

            entity.HasIndex(e => e.DailyLogId, "idx_log_items_daily_log");

            entity.HasIndex(e => e.FoodId, "idx_log_items_food");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DailyLogId).HasColumnName("daily_log_id");
            entity.Property(e => e.FoodId).HasColumnName("food_id");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1.00m)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("quantity");
            entity.Property(e => e.TimeSlot)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("12:00")
                .HasColumnName("time_slot");
            entity.Property(e => e.TrafficLight)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("traffic_light");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.DailyLog).WithMany(p => p.LogItems)
                .HasForeignKey(d => d.DailyLogId)
                .HasConstraintName("fk_log_items_daily_log");

            entity.HasOne(d => d.Food).WithMany(p => p.LogItems)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_log_items_food");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__menus__3213E83F690A3E1E");

            entity.ToTable("menus");

            entity.HasIndex(e => e.Category, "idx_menus_category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.IsSystem)
                .HasDefaultValue(true)
                .HasColumnName("is_system");
            entity.Property(e => e.TargetCalories).HasColumnName("target_calories");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Menus)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_menus_user");
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__menu_ite__3213E83F2DB83A40");

            entity.ToTable("menu_items");

            entity.HasIndex(e => new { e.MenuId, e.DayOfWeek }, "idx_menu_items_menu_day");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("day_of_week");
            entity.Property(e => e.FoodId).HasColumnName("food_id");
            entity.Property(e => e.MealType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("meal_type");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1.00m)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("quantity");
            entity.Property(e => e.TrafficLight)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("traffic_light");

            entity.HasOne(d => d.Food).WithMany(p => p.MenuItems)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_menu_items_food");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuItems)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("fk_menu_items_menu");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__notifica__3213E83F9578DF3F");

            entity.ToTable("notifications");

            entity.HasIndex(e => new { e.UserId, e.CreatedAt }, "idx_notifications_user_id_created").IsDescending(false, true);

            entity.HasIndex(e => new { e.UserId, e.IsRead }, "idx_notifications_user_read");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Body).HasColumnName("body");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.IsRead).HasColumnName("is_read");
            entity.Property(e => e.ReadAt).HasColumnName("read_at");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("SYSTEM")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_notifications_user");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__refresh___3213E83FCDBD5681");

            entity.ToTable("refresh_tokens");

            entity.HasIndex(e => e.Token, "UQ__refresh___CA90DA7A491B432F").IsUnique();

            entity.HasIndex(e => e.AccountId, "idx_refresh_tokens_account_id");

            entity.HasIndex(e => e.Token, "idx_refresh_tokens_token");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");
            entity.Property(e => e.Revoked).HasColumnName("revoked");
            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("token");

            entity.HasOne(d => d.Account).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_refresh_tokens_account");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F1EB31D76");

            entity.ToTable("users");

            entity.HasIndex(e => e.IsDeleted, "idx_users_is_deleted");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityLevel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("activity_level");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Goal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("goal");
            entity.Property(e => e.Height)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("height");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.MealPerDay)
                .HasDefaultValue(3)
                .HasColumnName("meal_per_day");
            entity.Property(e => e.TargetCalories).HasColumnName("target_calories");
            entity.Property(e => e.TargetWeightKg).HasColumnName("target_weight_kg");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("user_name");
            entity.Property(e => e.UserType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("FREE")
                .HasColumnName("user_type");
            entity.Property(e => e.WeeklyRateKg).HasColumnName("weekly_rate_kg");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("weight");
        });

        modelBuilder.Entity<UserActiveMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_act__3213E83FFF55C869");

            entity.ToTable("user_active_menus");

            entity.HasIndex(e => new { e.UserId, e.IsActive }, "idx_user_active_menus_user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Menu).WithMany(p => p.UserActiveMenus)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_active_menus_menu");

            entity.HasOne(d => d.User).WithMany(p => p.UserActiveMenus)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_active_menus_user");
        });

        modelBuilder.Entity<WaterLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__water_lo__3213E83F8EBEC5EF");

            entity.ToTable("water_logs");

            entity.HasIndex(e => new { e.UserId, e.LogDate }, "uk_water_logs_user_date").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.GoalMl)
                .HasDefaultValue(2000)
                .HasColumnName("goal_ml");
            entity.Property(e => e.IntakeMl).HasColumnName("intake_ml");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.LogDate).HasColumnName("log_date");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.WaterLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_water_logs_user");
        });

        modelBuilder.Entity<WeightLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__weight_l__3213E83FE43D4CD7");

            entity.ToTable("weight_logs");

            entity.HasIndex(e => new { e.UserId, e.LogDate }, "idx_weight_logs_user_date");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.LogDate).HasColumnName("log_date");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("weight");

            entity.HasOne(d => d.User).WithMany(p => p.WeightLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_weight_logs_user");
        });

        modelBuilder.Entity<WorkoutLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__workout___3213E83FEBBBFABB");

            entity.ToTable("workout_logs");

            entity.HasIndex(e => new { e.UserId, e.LogDate }, "idx_workout_logs_user_date");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BurnedCalories).HasColumnName("burned_calories");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");
            entity.Property(e => e.ExerciseName)
                .HasMaxLength(255)
                .HasColumnName("exercise_name");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.LogDate).HasColumnName("log_date");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.WorkoutLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_workout_logs_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
