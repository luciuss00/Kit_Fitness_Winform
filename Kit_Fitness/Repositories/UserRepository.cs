using Kit_Fitness.Data;
using Kit_Fitness.Models;

namespace Kit_Fitness.Repositories
{
    public class UserRepository
    {
        public User? GetById(long userId)
        {
            using var context = new KitFitnessContext();
            return context.Users.FirstOrDefault(u => u.Id == userId && !u.IsDeleted);
        }

        public User GetOrCreateDefault(long userId)
        {
            using var context = new KitFitnessContext();
            var user = context.Users.FirstOrDefault(u => u.Id == userId && !u.IsDeleted);
            if (user == null)
            {
                user = new User
                {
                    UserName = "olodo",
                    Age = 24,
                    Gender = "Nữ",
                    Height = 160,
                    Weight = 50,
                    TargetWeightKg = 47,
                    TargetCalories = 1389,
                     ActivityLevel = "Vận động vừa phải",
                    Goal = "Giảm mỡ & Nhẹ người",
                    UserType = "USER",
                    MealPerDay = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
            return user;
        }

        public void Update(User user)
        {
            using var context = new KitFitnessContext();
            user.UpdatedAt = DateTime.Now;
            context.Users.Update(user);
            context.SaveChanges();
        }
    }
}
