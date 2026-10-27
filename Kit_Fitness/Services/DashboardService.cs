using Kit_Fitness.Data;
using Kit_Fitness.DTOs;
using Kit_Fitness.Helpers;
using Kit_Fitness.Models;
using Kit_Fitness.Repositories;

namespace Kit_Fitness.Services
{
    public class DashboardService
    {
        private readonly DailyLogRepository _dailyLogRepo = new();
        private readonly UserRepository _userRepo = new();
        private readonly WaterLogRepository _waterLogRepo = new();
        private readonly WeightLogRepository _weightLogRepo = new();
        private readonly WorkoutLogRepository _workoutLogRepo = new();
        private readonly FridgeItemRepository _fridgeRepo = new();

        /// <summary>
        /// Lấy tổng hợp dinh dưỡng ngày hôm nay
        /// </summary>
        public DailyNutritionSummary GetDailyNutrition(long userId, DateOnly date)
        {
            var user = _userRepo.GetById(userId);
            var logs = _dailyLogRepo.GetByUserAndDate(userId, date);
            var burned = _workoutLogRepo.GetTotalBurnedCalories(userId, date);

            int targetCal = user?.TargetCalories ?? 1450;

            // Tính target macro dựa trên tỉ lệ: Protein 30%, Carb 40%, Fat 30%
            int targetProtein = (int)(targetCal * 0.30 / 4); // 4 cal/g protein
            int targetCarbs = (int)(targetCal * 0.40 / 4);   // 4 cal/g carb
            int targetFat = (int)(targetCal * 0.30 / 9);     // 9 cal/g fat

            return new DailyNutritionSummary
            {
                TotalCalories = logs.Sum(l => l.TotalCalories),
                TotalProtein = logs.Sum(l => l.TotalProtein),
                TotalCarbs = logs.Sum(l => l.TotalCarbs),
                TotalFat = logs.Sum(l => l.TotalFat),
                TargetCalories = targetCal,
                TargetProtein = targetProtein,
                TargetCarbs = targetCarbs,
                TargetFat = targetFat,
                CaloriesBurned = burned,
                CaloriesConsumed = logs.Sum(l => l.TotalCalories)
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
        /// Tính chuỗi ngày liên tiếp ghi nhận nhật ký (Streak)
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
        /// Đánh giá trạng thái calo hôm nay theo mục tiêu cân nặng
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
        /// Lấy lượng nước đã uống hôm nay
        /// </summary>
        public (int intake, int goal) GetWaterIntake(long userId, DateOnly date)
        {
            var waterLog = _waterLogRepo.GetByUserAndDate(userId, date);
            return (waterLog?.IntakeMl ?? 0, waterLog?.GoalMl ?? 2000);
        }

        /// <summary>
        /// Lấy cân nặng gần nhất
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
        /// Lấy thực phẩm sắp hết hạn
        /// </summary>
        public List<FridgeItem> GetExpiringSoonItems(long userId)
        {
            return _fridgeRepo.GetExpiringSoon(userId);
        }

        /// <summary>
        /// Lấy tên mục tiêu dạng hiển thị
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
