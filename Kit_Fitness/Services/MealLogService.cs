using Kit_Fitness.Data;
using Kit_Fitness.Helpers;
using Kit_Fitness.Models;
using Kit_Fitness.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kit_Fitness.Services
{
    public class MealLogService
    {
        private readonly DailyLogRepository _dailyLogRepo = new();
        private readonly LogItemRepository _logItemRepo = new();
        private readonly FoodRepository _foodRepo = new();
        private readonly UserRepository _userRepo = new();

        /// <summary>
        /// Thêm một bữa ăn mới vào nhật ký, liên kết với dữ liệu DB thật
        /// và tính toán traffic light cho từng món ăn cũng như toàn bữa ăn so với calo còn lại trong ngày.
        /// </summary>
        public DailyLog AddMeal(long userId, DateOnly date, string mealType, string timeSlot, List<(long foodId, decimal quantity)> items)
        {
            var itemsWithLight = items.Select(x => (x.foodId, x.quantity, (string?)null)).ToList();
            return AddMeal(userId, date, mealType, timeSlot, itemsWithLight);
        }

        public DailyLog AddMeal(long userId, DateOnly date, string mealType, string timeSlot, List<(long foodId, decimal quantity, string? trafficLight)> items)
        {
            // 1. Đảm bảo user tồn tại trong DB để tránh lỗi khóa ngoại fk_daily_logs_user
            var user = _userRepo.GetOrCreateDefault(userId);

            // 2. Lấy thông tin calo còn lại trong ngày trước khi lưu bữa ăn này
            int targetCalories = user?.TargetCalories > 0 ? user.TargetCalories.Value : 1450;
            int caloriesAlreadyConsumed = 0;

            using (var checkContext = new KitFitnessContext())
            {
                var existingLogsToday = checkContext.DailyLogs
                    .Where(d => d.UserId == userId && d.LogDate == date && !d.IsDeleted)
                    .ToList();
                caloriesAlreadyConsumed = existingLogsToday.Sum(l => l.TotalCalories);
            }

            int remainingBeforeMeal = targetCalories - caloriesAlreadyConsumed;

            // 3. Tính toán dinh dưỡng cho các món mới
            int newCal = 0, newProtein = 0, newCarbs = 0, newFat = 0;
            foreach (var (foodId, quantity, _) in items)
            {
                var food = _foodRepo.GetById(foodId);
                if (food != null)
                {
                    decimal ratio = quantity / 100m;
                    newCal += (int)(food.Calories * ratio);
                    newProtein += (int)((food.Protein ?? 0) * ratio);
                    newCarbs += (int)((food.Carbs ?? 0) * ratio);
                    newFat += (int)((food.Fat ?? 0) * ratio);
                }
            }

            // 4. Phân loại traffic light cho bữa ăn
            string mealTrafficLight = CalculateTrafficLight(newCal, remainingBeforeMeal);

            using var context = new KitFitnessContext();

            // 5. Kiểm tra xem đã có bữa ăn cho mốc giờ / loại bữa này trong ngày chưa
            var existingLog = context.DailyLogs
                .Include(d => d.LogItems.Where(li => !li.IsDeleted))
                    .ThenInclude(li => li.Food)
                .FirstOrDefault(d => d.UserId == userId && d.LogDate == date && !d.IsDeleted &&
                                    (d.MealType == mealType || d.LogItems.Any(li => li.TimeSlot == timeSlot && !li.IsDeleted)));

            if (existingLog != null)
            {
                // Thêm các món mới vào bữa ăn đã có
                foreach (var (foodId, quantity, trafficLight) in items)
                {
                    var food = _foodRepo.GetById(foodId);
                    int itemCal = food != null ? (int)(food.Calories * (quantity / 100m)) : 0;
                    string itemLight = !string.IsNullOrEmpty(trafficLight)
                        ? trafficLight
                        : CalculateTrafficLight(itemCal, remainingBeforeMeal);

                    var logItem = new LogItem
                    {
                        DailyLogId = existingLog.Id,
                        FoodId = foodId,
                        Quantity = quantity,
                        TimeSlot = timeSlot,
                        TrafficLight = itemLight,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    context.LogItems.Add(logItem);
                }
                context.SaveChanges();

                // Nạp lại tất cả các món để tính lại tổng dinh dưỡng
                var allActiveItems = context.LogItems
                    .Include(li => li.Food)
                    .Where(li => li.DailyLogId == existingLog.Id && !li.IsDeleted)
                    .ToList();

                existingLog.TotalCalories = allActiveItems.Sum(li => (int)((li.Food?.Calories ?? 0) * (li.Quantity / 100m)));
                existingLog.TotalProtein = allActiveItems.Sum(li => (int)((li.Food?.Protein ?? 0) * (li.Quantity / 100m)));
                existingLog.TotalCarbs = allActiveItems.Sum(li => (int)((li.Food?.Carbs ?? 0) * (li.Quantity / 100m)));
                existingLog.TotalFat = allActiveItems.Sum(li => (int)((li.Food?.Fat ?? 0) * (li.Quantity / 100m)));
                existingLog.MealTrafficLight = CalculateTrafficLight(existingLog.TotalCalories, remainingBeforeMeal);
                existingLog.UpdatedAt = DateTime.Now;

                context.SaveChanges();
                return existingLog;
            }
            else
            {
                // Tạo bữa ăn mới
                var dailyLog = new DailyLog
                {
                    UserId = userId,
                    LogDate = date,
                    MealType = mealType,
                    TotalCalories = newCal,
                    TotalProtein = newProtein,
                    TotalCarbs = newCarbs,
                    TotalFat = newFat,
                    MealTrafficLight = mealTrafficLight,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                context.DailyLogs.Add(dailyLog);
                context.SaveChanges();

                // Thêm từng món ăn vào DB
                foreach (var (foodId, quantity, trafficLight) in items)
                {
                    var food = _foodRepo.GetById(foodId);
                    int itemCal = food != null ? (int)(food.Calories * (quantity / 100m)) : 0;
                    string itemLight = !string.IsNullOrEmpty(trafficLight)
                        ? trafficLight
                        : CalculateTrafficLight(itemCal, remainingBeforeMeal);

                    context.LogItems.Add(new LogItem
                    {
                        DailyLogId = dailyLog.Id,
                        FoodId = foodId,
                        Quantity = quantity,
                        TimeSlot = timeSlot,
                        TrafficLight = itemLight,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });
                }

                context.SaveChanges();
                return dailyLog;
            }
        }

        /// <summary>
        /// Xóa một món khỏi bữa ăn và cập nhật lại tổng calo / macro của bữa ăn trong DB
        /// </summary>
        public void RemoveLogItem(long logItemId)
        {
            using var context = new KitFitnessContext();
            var item = context.LogItems.FirstOrDefault(li => li.Id == logItemId);
            if (item == null) return;

            item.IsDeleted = true;
            item.UpdatedAt = DateTime.Now;

            var dailyLog = context.DailyLogs
                .Include(d => d.LogItems.Where(li => !li.IsDeleted && li.Id != logItemId))
                    .ThenInclude(li => li.Food)
                .FirstOrDefault(d => d.Id == item.DailyLogId);

            if (dailyLog != null)
            {
                var remainingItems = dailyLog.LogItems.Where(li => !li.IsDeleted && li.Id != logItemId).ToList();
                if (remainingItems.Count == 0)
                {
                    dailyLog.IsDeleted = true;
                    dailyLog.TotalCalories = 0;
                    dailyLog.TotalProtein = 0;
                    dailyLog.TotalCarbs = 0;
                    dailyLog.TotalFat = 0;
                }
                else
                {
                    dailyLog.TotalCalories = remainingItems.Sum(li => (int)((li.Food?.Calories ?? 0) * (li.Quantity / 100m)));
                    dailyLog.TotalProtein = remainingItems.Sum(li => (int)((li.Food?.Protein ?? 0) * (li.Quantity / 100m)));
                    dailyLog.TotalCarbs = remainingItems.Sum(li => (int)((li.Food?.Carbs ?? 0) * (li.Quantity / 100m)));
                    dailyLog.TotalFat = remainingItems.Sum(li => (int)((li.Food?.Fat ?? 0) * (li.Quantity / 100m)));
                }
                dailyLog.UpdatedAt = DateTime.Now;
            }

            context.SaveChanges();
        }

        /// <summary>
        /// Lấy số calo còn lại trong ngày của user
        /// </summary>
        public (int remaining, int target, int consumed) GetDailyCaloriesStatus(long userId, DateOnly date)
        {
            var user = _userRepo.GetOrCreateDefault(userId);
            int target = user?.TargetCalories > 0 ? user.TargetCalories.Value : 1450;

            using var context = new KitFitnessContext();
            var logs = context.DailyLogs
                .Where(d => d.UserId == userId && d.LogDate == date && !d.IsDeleted)
                .ToList();

            int consumed = logs.Sum(l => l.TotalCalories);
            int remaining = target - consumed;
            return (remaining, target, consumed);
        }

        /// <summary>
        /// Tính traffic light cho một món ăn hoặc bữa ăn dựa trên calo còn lại trong ngày
        /// Xanh: Calo món ăn chiếm &lt;= 40% calo còn lại (an toàn / lành mạnh)
        /// Vàng: Calo món ăn chiếm 40% - 70% calo còn lại (cần chú ý / cân nhắc)
        /// Đỏ: Calo món ăn chiếm &gt; 70% calo còn lại hoặc đã vượt calo trong ngày
        /// </summary>
        public string CalculateTrafficLight(int itemCalories, int remainingCalories)
        {
            if (remainingCalories <= 0)
            {
                return "RED";
            }

            double ratio = (double)itemCalories / remainingCalories;
            if (ratio <= 0.40)
            {
                return "GREEN";
            }
            if (ratio <= 0.70)
            {
                return "YELLOW";
            }
            return "RED";
        }

        /// <summary>
        /// Tìm kiếm hoặc tạo mới món ăn tùy chỉnh trong DB nếu người dùng gõ tên món mới
        /// </summary>
        public Food FindOrCreateFood(
            string foodName,
            int calories = 150,
            string unit = "g",
            decimal protein = 0,
            decimal carbs = 0,
            decimal fat = 0)
        {
            return _foodRepo.FindOrCreate(
                foodName,
                calories,
                protein: protein,
                carbs: carbs,
                fat: fat,
                unit: unit,
                createByUserId: AppSession.CurrentUserId);
        }

        /// <summary>
        /// Tìm kiếm món ăn theo tên
        /// </summary>
        public List<Food> SearchFood(string keyword)
        {
            return _foodRepo.Search(keyword);
        }

        /// <summary>
        /// Lấy tất cả món ăn từ DB
        /// </summary>
        public List<Food> GetAllFoods(long? userId = null)
        {
            return _foodRepo.GetAll(userId);
        }

        /// <summary>
        /// Tính ước tính dinh dưỡng từ danh sách món
        /// </summary>
        public (int calories, int protein, int carbs, int fat) EstimateNutrition(List<(long foodId, decimal quantity)> items)
        {
            int totalCal = 0, totalProtein = 0, totalCarbs = 0, totalFat = 0;

            foreach (var (foodId, quantity) in items)
            {
                var food = _foodRepo.GetById(foodId);
                if (food != null)
                {
                    decimal ratio = quantity / 100m;
                    totalCal += (int)(food.Calories * ratio);
                    totalProtein += (int)((food.Protein ?? 0) * ratio);
                    totalCarbs += (int)((food.Carbs ?? 0) * ratio);
                    totalFat += (int)((food.Fat ?? 0) * ratio);
                }
            }

            return (totalCal, totalProtein, totalCarbs, totalFat);
        }
    }
}
