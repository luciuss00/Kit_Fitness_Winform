using Kit_Fitness.Data;
using Kit_Fitness.Models;
using Microsoft.EntityFrameworkCore;

namespace Kit_Fitness.Repositories
{
    public class WeightLogRepository
    {
        public WeightLog? GetLatestByUser(long userId)
        {
            using var context = new KitFitnessContext();
            return context.WeightLogs
                .Where(w => w.UserId == userId && !w.IsDeleted)
                .OrderByDescending(w => w.LogDate)
                .FirstOrDefault();
        }

        public List<WeightLog> GetByUser(long userId, int limit = 30)
        {
            using var context = new KitFitnessContext();
            return context.WeightLogs
                .Where(w => w.UserId == userId && !w.IsDeleted)
                .OrderByDescending(w => w.LogDate)
                .Take(limit)
                .ToList();
        }

        public WeightLog? GetByUserAndDate(long userId, DateOnly logDate)
        {
            using var context = new KitFitnessContext();
            return context.WeightLogs
                .FirstOrDefault(w => w.UserId == userId && w.LogDate == logDate && !w.IsDeleted);
        }

        public WeightLog Upsert(long userId, DateOnly logDate, decimal weight, string? notes = null)
        {
            using var context = new KitFitnessContext();
            var existing = context.WeightLogs
                .FirstOrDefault(w => w.UserId == userId && w.LogDate == logDate && !w.IsDeleted);

            if (existing != null)
            {
                existing.Weight = weight;
                if (notes != null) existing.Notes = notes;
                existing.UpdatedAt = DateTime.Now;
                context.SaveChanges();
                return existing;
            }

            var log = new WeightLog
            {
                UserId = userId,
                LogDate = logDate,
                Weight = weight,
                Notes = notes,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            context.WeightLogs.Add(log);
            context.SaveChanges();
            return log;
        }

        public WeightLog Add(WeightLog log)
        {
            using var context = new KitFitnessContext();
            log.CreatedAt = DateTime.Now;
            log.UpdatedAt = DateTime.Now;
            context.WeightLogs.Add(log);
            context.SaveChanges();
            return log;
        }
    }
}
