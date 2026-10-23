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
