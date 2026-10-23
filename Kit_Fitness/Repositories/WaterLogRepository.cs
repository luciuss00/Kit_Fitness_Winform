using Kit_Fitness.Data;
using Kit_Fitness.Models;
using Microsoft.EntityFrameworkCore;

namespace Kit_Fitness.Repositories
{
    public class WaterLogRepository
    {
        public WaterLog? GetByUserAndDate(long userId, DateOnly date)
        {
            using var context = new KitFitnessContext();
            return context.WaterLogs
                .FirstOrDefault(w => w.UserId == userId && w.LogDate == date && !w.IsDeleted);
        }

        public WaterLog AddOrUpdate(long userId, DateOnly date, int intakeMl, int goalMl = 2000)
        {
            using var context = new KitFitnessContext();
            var existing = context.WaterLogs
                .FirstOrDefault(w => w.UserId == userId && w.LogDate == date && !w.IsDeleted);

            if (existing != null)
            {
                existing.IntakeMl = intakeMl;
                existing.GoalMl = goalMl;
                existing.UpdatedAt = DateTime.Now;
                context.SaveChanges();
                return existing;
            }
            else
            {
                var waterLog = new WaterLog
                {
                    UserId = userId,
                    LogDate = date,
                    IntakeMl = intakeMl,
                    GoalMl = goalMl,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                context.WaterLogs.Add(waterLog);
                context.SaveChanges();
                return waterLog;
            }
        }
    }
}
