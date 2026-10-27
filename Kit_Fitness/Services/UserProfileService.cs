using Kit_Fitness.Models;
using Kit_Fitness.Repositories;

namespace Kit_Fitness.Services
{
    /// <summary>
    /// Service quản lý hồ sơ người dùng (Cân nặng, Chiều cao, Tuổi, Mục tiêu calo, Nước uống)
    /// </summary>
    public class UserProfileService
    {
        private readonly UserRepository _userRepo = new();
        private readonly WeightLogRepository _weightLogRepo = new();
        private readonly WaterLogRepository _waterLogRepo = new();

        /// <summary>
        /// Lấy thông tin hồ sơ của user theo ID (tự động tạo hồ sơ mặc định nếu chưa có)
        /// </summary>
        public User GetProfile(long userId)
        {
            return _userRepo.GetOrCreateDefault(userId);
        }

        /// <summary>
        /// Cập nhật toàn bộ thông số thể trạng và mục tiêu calo của người dùng
        /// </summary>
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
            
            // Chuẩn hóa mức độ vận động và mục tiêu để tránh lưu chuỗi dài hoặc không nhất quán
            if (activityLevel != null) user.ActivityLevel = NormalizeActivityLevel(activityLevel);
            if (goal != null) user.Goal = NormalizeGoal(goal);
            
            if (targetCalories.HasValue) user.TargetCalories = targetCalories.Value;
            if (targetWeightKg.HasValue) user.TargetWeightKg = targetWeightKg.Value;

            _userRepo.Update(user);
        }

        /// <summary>
        /// Chuẩn hóa mức độ vận động về 4 nhóm chuẩn theo tiêu chuẩn tính TDEE:
        /// 1. Ít vận động (Hệ số 1.2)
        /// 2. Vận động nhẹ nhàng (Hệ số 1.375)
        /// 3. Vận động vừa phải (Hệ số 1.55)
        /// 4. Cường độ cao (Hệ số 1.725)
        /// </summary>
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

        /// <summary>
        /// Chuẩn hóa chuỗi mục tiêu thể hình về 3 danh mục hiển thị chuẩn
        /// </summary>
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

        /// <summary>
        /// Ghi nhận cân nặng theo ngày và đồng bộ ngay vào trường Weight của bảng Users
        /// </summary>
        public void LogWeight(long userId, decimal weight, string? notes = null)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            // Upsert: Cập nhật nếu ngày hôm nay đã cân, hoặc thêm mới nếu chưa cân
            _weightLogRepo.Upsert(userId, today, weight, notes);

            // Đồng bộ cân nặng hiện tại vào User để tính toán calo chuẩn
            var user = _userRepo.GetById(userId);
            if (user != null)
            {
                user.Weight = weight;
                _userRepo.Update(user);
            }
        }

        /// <summary>
        /// Ghi nhận lượng nước đã uống (cộng dồn vào tổng lượng nước trong ngày)
        /// </summary>
        public void AddWater(long userId, int amountMl)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var current = _waterLogRepo.GetByUserAndDate(userId, today);
            int newIntake = (current?.IntakeMl ?? 0) + amountMl;
            _waterLogRepo.AddOrUpdate(userId, today, newIntake);
        }

        /// <summary>
        /// Lấy lịch sử theo dõi cân nặng của người dùng (mặc định lấy 30 lần ghi gần nhất để vẽ biểu đồ)
        /// </summary>
        public List<WeightLog> GetWeightHistory(long userId, int limit = 30)
        {
            return _weightLogRepo.GetByUser(userId, limit);
        }
    }
}
