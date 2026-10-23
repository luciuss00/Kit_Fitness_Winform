using Kit_Fitness.Models;
using Kit_Fitness.Repositories;

namespace Kit_Fitness.Services
{
    public class UserProfileService
    {
        private readonly UserRepository _userRepo = new();
        private readonly WeightLogRepository _weightLogRepo = new();
        private readonly WaterLogRepository _waterLogRepo = new();

        public User GetProfile(long userId)
        {
            return _userRepo.GetOrCreateDefault(userId);
        }

        public void UpdateProfile(long userId, string? userName, int? age, string? gender,
            decimal? height, decimal? weight, string? activityLevel, string? goal,
            int? targetCalories, double? targetWeightKg)
        {
            var user = _userRepo.GetById(userId);
            if (user == null) return;

            if (userName != null) user.UserName = userName;
            if (age.HasValue) user.Age = age.Value;
            if (gender != null) user.Gender = gender;
            if (height.HasValue) user.Height = height.Value;
            if (weight.HasValue) user.Weight = weight.Value;
            if (activityLevel != null) user.ActivityLevel = NormalizeActivityLevel(activityLevel);
            if (goal != null) user.Goal = NormalizeGoal(goal);
            if (targetCalories.HasValue) user.TargetCalories = targetCalories.Value;
            if (targetWeightKg.HasValue) user.TargetWeightKg = targetWeightKg.Value;

            _userRepo.Update(user);
        }

        private static string NormalizeActivityLevel(string activityLevel)
        {
            if (activityLevel.Contains("Ít vận động", StringComparison.OrdinalIgnoreCase))
                return "Ít vận động";

            if (activityLevel.Contains("nhẹ nhàng", StringComparison.OrdinalIgnoreCase))
                return "Vận động nhẹ nhàng";

            if (activityLevel.Contains("vừa phải", StringComparison.OrdinalIgnoreCase))
                return "Vận động vừa phải";

            if (activityLevel.Contains("Cường độ cao", StringComparison.OrdinalIgnoreCase))
                return "Cường độ cao";

            return activityLevel.Length <= 20 ? activityLevel : activityLevel[..20];
        }

        private static string NormalizeGoal(string goal)
        {
            if (goal.Contains("Giảm mỡ", StringComparison.OrdinalIgnoreCase))
                return "Giảm mỡ & Nhẹ người";

            if (goal.Contains("Giữ dáng", StringComparison.OrdinalIgnoreCase))
                return "Giữ dáng & Ăn lành";

            if (goal.Contains("Tăng cân", StringComparison.OrdinalIgnoreCase))
                return "Tăng cân & Tăng cơ";

            return goal.Length <= 20 ? goal : goal[..20];
        }

        public void LogWeight(long userId, decimal weight, string? notes = null)
        {
            _weightLogRepo.Add(new WeightLog
            {
                UserId = userId,
                Weight = weight,
                LogDate = DateOnly.FromDateTime(DateTime.Now),
                Notes = notes
            });

            var user = _userRepo.GetById(userId);
            if (user != null)
            {
                user.Weight = weight;
                _userRepo.Update(user);
            }
        }

        /// <summary>
        /// Thêm nước uống
        /// </summary>
        public void AddWater(long userId, int amountMl)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var current = _waterLogRepo.GetByUserAndDate(userId, today);
            int newIntake = (current?.IntakeMl ?? 0) + amountMl;
            _waterLogRepo.AddOrUpdate(userId, today, newIntake);
        }

        /// <summary>
        /// Lấy lịch sử cân nặng
        /// </summary>
        public List<WeightLog> GetWeightHistory(long userId, int limit = 30)
        {
            return _weightLogRepo.GetByUser(userId, limit);
        }
    }
}
