using Kit_Fitness.Data;
using Kit_Fitness.DTOs;
using Kit_Fitness.Helpers;
using Kit_Fitness.Models;
using Kit_Fitness.Repositories;

namespace Kit_Fitness.Services
{
    /// <summary>
    /// Service trung tâm xử lý dữ liệu tổng hợp cho màn hình Dashboard (Trang chủ)
    /// </summary>
    public class DashboardService
    {
        private readonly DailyLogRepository _dailyLogRepo = new();
        private readonly UserRepository _userRepo = new();
        private readonly WaterLogRepository _waterLogRepo = new();
        private readonly WeightLogRepository _weightLogRepo = new();
        private readonly WorkoutLogRepository _workoutLogRepo = new();
        private readonly FridgeItemRepository _fridgeRepo = new();

        /// <summary>
        /// Lấy tổng hợp dinh dưỡng ngày hôm nay (Calo nạp, Calo đốt, Target Calo, Macro Protein/Carbs/Fat)
        /// </summary>
        public DailyNutritionSummary GetDailyNutrition(long userId, DateOnly date)
        {
            var user = _userRepo.GetById(userId);
            var logs = _dailyLogRepo.GetByUserAndDate(userId, date);
            
            // burned: Tổng lượng calo đã đốt cháy từ các buổi tập Workout trong ngày (kcal)
            var burned = _workoutLogRepo.GetTotalBurnedCalories(userId, date);

            // targetCal: Mục tiêu calo nạp vào hàng ngày tính theo TDEE (mặc định 1450 kcal nếu user chưa cấu hình)
            int targetCal = user?.TargetCalories ?? 1450;

            // Tính target macro chuẩn theo tỷ lệ phân bổ năng lượng lành mạnh: 30% Protein - 40% Carbs - 30% Fat
            // - 1g Protein giải phóng 4 kcal => Khối lượng gram = (targetCal * 30%) / 4
            // - 1g Carbs giải phóng 4 kcal   => Khối lượng gram = (targetCal * 40%) / 4
            // - 1g Fat giải phóng 9 kcal     => Khối lượng gram = (targetCal * 30%) / 9
            int targetProtein = (int)(targetCal * 0.30 / 4);
            int targetCarbs = (int)(targetCal * 0.40 / 4);
            int targetFat = (int)(targetCal * 0.30 / 9);

            // totalCal, totalProtein, totalCarbs, totalFat: Tổng thực tế đã nạp trong ngày từ các món ăn active
            int totalCal = 0;
            decimal totalProtein = 0;
            decimal totalCarbs = 0;
            decimal totalFat = 0;

            foreach (var log in logs)
            {
                // activeItems: Các món ăn trong bữa chưa bị xóa (IsDeleted == false)
                var activeItems = log.LogItems.Where(li => !li.IsDeleted).ToList();
                if (activeItems.Count > 0)
                {
                    // Tính chính xác bằng cách nhân hệ số theo đơn vị (ScaleByUnit: gam, quả, hộp, bát)
                    totalCal += activeItems.Sum(li => NutritionHelper.RoundToInt(NutritionHelper.ScaleByUnit(li.Food?.Calories ?? 0, li.Quantity, li.Food?.Unit)));
                    totalProtein += activeItems.Sum(li => NutritionHelper.ScaleByUnit(li.Food?.Protein ?? 0m, li.Quantity, li.Food?.Unit));
                    totalCarbs += activeItems.Sum(li => NutritionHelper.ScaleByUnit(li.Food?.Carbs ?? 0m, li.Quantity, li.Food?.Unit));
                    totalFat += activeItems.Sum(li => NutritionHelper.ScaleByUnit(li.Food?.Fat ?? 0m, li.Quantity, li.Food?.Unit));
                }
                else if (log.TotalCalories > 0 && !logs.Any(other => other.LogItems.Any(li => !li.IsDeleted)))
                {
                    // Fallback: Chỉ dùng TotalCalories lưu sẵn ở cấp DailyLog nếu bữa đó không có item chi tiết nào
                    totalCal += log.TotalCalories;
                    totalProtein += log.TotalProtein;
                    totalCarbs += log.TotalCarbs;
                    totalFat += log.TotalFat;
                }
            }

            return new DailyNutritionSummary
            {
                TotalCalories = totalCal,
                TotalProtein = (int)Math.Round(totalProtein),
                TotalCarbs = (int)Math.Round(totalCarbs),
                TotalFat = (int)Math.Round(totalFat),
                TargetCalories = targetCal,
                TargetProtein = targetProtein,
                TargetCarbs = targetCarbs,
                TargetFat = targetFat,
                CaloriesBurned = burned,
                CaloriesConsumed = totalCal
            };
        }

        /// <summary>
        /// Lấy danh sách bữa ăn đã ghi nhận trong ngày cho timeline
        /// </summary>
        public List<MealDisplayItem> GetMealsTimeline(long userId, DateOnly date)
        {
            var logs = _dailyLogRepo.GetByUserAndDate(userId, date);
            var result = new List<MealDisplayItem>();

            foreach (var log in logs)
            {
                var meal = new MealDisplayItem
                {
                    DailyLogId = log.Id,
                    MealType = log.MealType,
                    TotalCalories = log.TotalCalories,
                    TotalProtein = log.TotalProtein,
                    TotalCarbs = log.TotalCarbs,
                    TotalFat = log.TotalFat,
                    Items = log.LogItems
                        .Where(li => !li.IsDeleted)
                        .Select(li => new LogItemDisplay
                        {
                            Id = li.Id,
                            FoodName = li.Food?.Name ?? "Không xác định",
                            Quantity = li.Quantity,
                            Unit = li.Food?.Unit ?? "g",
                            Calories = NutritionHelper.RoundToInt(NutritionHelper.ScaleByUnit(li.Food?.Calories ?? 0, li.Quantity, li.Food?.Unit)),
                            TrafficLight = li.TrafficLight
                        }).ToList()
                };
                if (meal.Items.Any())
                    meal.TimeSlot = log.LogItems.FirstOrDefault()?.TimeSlot ?? "12:00";
                result.Add(meal);
            }

            return result;
        }

        /// <summary>
        /// Thuật toán đếm chuỗi ngày liên tiếp ghi nhận nhật ký (Streak Counter)
        /// Giúp tăng động lực người dùng ghi chép bữa ăn mỗi ngày
        /// </summary>
        public (int currentStreak, bool isLoggedToday) GetStreak(long userId, DateOnly today)
        {
            using var context = new KitFitnessContext();
            var activeDates = context.DailyLogs
                .Where(d => d.UserId == userId && !d.IsDeleted && d.TotalCalories > 0)
                .Select(d => d.LogDate)
                .Distinct()
                .ToList();

            var set = new HashSet<DateOnly>(activeDates);
            if (set.Count == 0) return (0, false);

            bool isLoggedToday = set.Contains(today);
            int streak = 0;
            var check = isLoggedToday ? today : today.AddDays(-1);
            while (set.Contains(check))
            {
                streak++;
                check = check.AddDays(-1);
            }

            return (streak, isLoggedToday);
        }

        /// <summary>
        /// Đánh giá trạng thái calo hôm nay theo mục tiêu cân nặng (gọi sang CalorieGoalEvaluator)
        /// </summary>
        public CalorieStatusResult GetCalorieStatus(long userId, DateOnly date)
        {
            var user = _userRepo.GetById(userId);
            var logs = _dailyLogRepo.GetByUserAndDate(userId, date);
            int totalCal = logs.Sum(l => l.TotalCalories);
            int targetCal = user?.TargetCalories ?? 2000;
            int itemsCount = logs.SelectMany(l => l.LogItems).Count(li => !li.IsDeleted);

            return CalorieGoalEvaluator.EvaluateDailyCalorieStatus(user?.Goal, totalCal, targetCal, itemsCount);
        }

        /// <summary>
        /// Lấy lượng nước đã uống hôm nay (IntakeMl) so với mục tiêu (GoalMl, mặc định 2000ml)
        /// </summary>
        public (int intake, int goal) GetWaterIntake(long userId, DateOnly date)
        {
            var waterLog = _waterLogRepo.GetByUserAndDate(userId, date);
            return (waterLog?.IntakeMl ?? 0, waterLog?.GoalMl ?? 2000);
        }

        /// <summary>
        /// Lấy cân nặng gần nhất đã ghi nhận của người dùng
        /// </summary>
        public (decimal weight, decimal? target) GetLatestWeight(long userId)
        {
            var user = _userRepo.GetById(userId);
            var latest = _weightLogRepo.GetLatestByUser(userId);
            return (latest?.Weight ?? user?.Weight ?? 0, (decimal?)(user?.TargetWeightKg));
        }

        /// <summary>
        /// Lấy danh sách thực phẩm trong tủ lạnh
        /// </summary>
        public List<FridgeItem> GetFridgeItems(long userId)
        {
            return _fridgeRepo.GetByUser(userId);
        }

        /// <summary>
        /// Lấy thực phẩm sắp hết hạn trong 3 ngày tới
        /// </summary>
        public List<FridgeItem> GetExpiringSoonItems(long userId)
        {
            return _fridgeRepo.GetExpiringSoon(userId);
        }

        /// <summary>
        /// Chuyển đổi mã mục tiêu thành tên tiếng Việt thân thiện hiển thị trên giao diện
        /// </summary>
        public string GetGoalDisplayName(string? goal)
        {
            var norm = TrafficLightHelper.NormalizeGoal(goal);
            return norm switch
            {
                "LOSE_WEIGHT" => "Giảm mỡ & Nhẹ người",
                "GAIN_WEIGHT" => "Tăng cân & Phát triển cơ",
                "MAINTAIN" => "Giữ dáng & Ăn tươi lành",
                _ => "Duy trì cân nặng"
            };
        }
    }
}
