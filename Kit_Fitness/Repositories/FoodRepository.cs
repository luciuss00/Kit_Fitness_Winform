using Kit_Fitness.Data;
using Kit_Fitness.Models;

namespace Kit_Fitness.Repositories
{
    public class FoodRepository
    {
        public List<Food> Search(string keyword)
        {
            using var context = new KitFitnessContext();
            return context.Foods
                .Where(f => !f.IsDeleted && f.Name.Contains(keyword))
                .OrderBy(f => f.Name)
                .Take(20)
                .ToList();
        }

        public Food? GetById(long id)
        {
            using var context = new KitFitnessContext();
            return context.Foods.FirstOrDefault(f => f.Id == id && !f.IsDeleted);
        }

        public List<Food> GetAll(long? userId = null)
        {
            using var context = new KitFitnessContext();
            var foods = context.Foods
                .Where(f => !f.IsDeleted &&
                    (!f.IsCustom || (userId.HasValue && f.CreateByUserId == userId.Value)))
                .OrderBy(f => f.Name)
                .ToList();

            if (foods.Count == 0)
            {
                var defaultFoods = new List<Food>
                {
                    new Food { Name = "Ức gà phi lê", Calories = 165, Protein = 31, Carbs = 0, Fat = 3.6m, Unit = "g", Type = "PROTEIN", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Food { Name = "Cơm gạo lứt", Calories = 111, Protein = 2.6m, Carbs = 23, Fat = 0.9m, Unit = "g", Type = "CARB", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Food { Name = "Phở gà ức ít bánh", Calories = 380, Protein = 32, Carbs = 58, Fat = 12, Unit = "tô", Type = "MEAL", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Food { Name = "Trứng gà luộc", Calories = 78, Protein = 6.3m, Carbs = 0.6m, Fat = 5.3m, Unit = "quả", Type = "PROTEIN", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Food { Name = "Rau muống luộc", Calories = 30, Protein = 3, Carbs = 5, Fat = 0.3m, Unit = "đĩa", Type = "VEGGIE", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Food { Name = "Cá hồi áp chảo", Calories = 208, Protein = 20, Carbs = 0, Fat = 13, Unit = "g", Type = "PROTEIN", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Food { Name = "Khoai lang luộc", Calories = 86, Protein = 1.6m, Carbs = 20, Fat = 0.1m, Unit = "củ", Type = "CARB", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Food { Name = "Bắp bò luộc", Calories = 130, Protein = 26, Carbs = 0, Fat = 3, Unit = "g", Type = "PROTEIN", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Food { Name = "Chuối tiêu", Calories = 89, Protein = 1.1m, Carbs = 23, Fat = 0.3m, Unit = "quả", Type = "FRUIT", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Food { Name = "Yến mạch nấu sữa", Calories = 220, Protein = 8, Carbs = 38, Fat = 4.5m, Unit = "bát", Type = "CARB", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Food { Name = "Salad ức gà dầu giấm", Calories = 250, Protein = 28, Carbs = 8, Fat = 11, Unit = "đĩa", Type = "MEAL", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Food { Name = "Sữa chua Hy Lạp", Calories = 97, Protein = 9, Carbs = 4, Fat = 5, Unit = "hộp", Type = "SNACK", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                };

                try
                {
                    context.Foods.AddRange(defaultFoods);
                    context.SaveChanges();
                    foods = context.Foods
                        .Where(f => !f.IsDeleted &&
                            (!f.IsCustom || (userId.HasValue && f.CreateByUserId == userId.Value)))
                        .OrderBy(f => f.Name)
                        .ToList();
                }
                catch
                {
                    return defaultFoods;
                }
            }

            return foods;
        }

        public Food Add(Food food)
        {
            using var context = new KitFitnessContext();
            food.CreatedAt = DateTime.Now;
            food.UpdatedAt = DateTime.Now;
            context.Foods.Add(food);
            context.SaveChanges();
            return food;
        }

        public Food FindOrCreate(string name, int calories = 150, decimal protein = 5, decimal carbs = 20, decimal fat = 3, string unit = "g", long? createByUserId = null)
        {
            using var context = new KitFitnessContext();
            string normalizedName = name.Trim();
            var existing = context.Foods.FirstOrDefault(f =>
                !f.IsDeleted &&
                f.Name.ToLower() == normalizedName.ToLower() &&
                (!f.IsCustom || f.CreateByUserId == createByUserId || f.CreateByUserId == null));

            if (existing != null)
            {
                if (existing.IsCustom && existing.CreateByUserId == null && createByUserId.HasValue)
                {
                    existing.CreateByUserId = createByUserId.Value;
                    existing.UpdatedAt = DateTime.Now;
                    context.SaveChanges();
                }

                return existing;
            }

            var newFood = new Food
            {
                Name = normalizedName,
                Calories = calories > 0 ? calories : 150,
                Protein = protein,
                Carbs = carbs,
                Fat = fat,
                Unit = string.IsNullOrWhiteSpace(unit) ? "g" : unit,
                Type = "CUSTOM",
                IsCustom = true,
                CreateByUserId = createByUserId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            context.Foods.Add(newFood);
            context.SaveChanges();
            return newFood;
        }
    }
}
