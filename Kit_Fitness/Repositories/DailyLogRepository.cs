using Kit_Fitness.Data;
using Kit_Fitness.Models;
using Microsoft.EntityFrameworkCore;

namespace Kit_Fitness.Repositories
{
    public class DailyLogRepository
    {
        public List<DailyLog> GetByUserAndDate(long userId, DateOnly date)
        {
            using var context = new KitFitnessContext();
            return context.DailyLogs
                .Include(d => d.LogItems.Where(li => !li.IsDeleted))
                    .ThenInclude(li => li.Food)
                .Where(d => d.UserId == userId && d.LogDate == date && !d.IsDeleted)
                .OrderBy(d => d.MealType)
                .ToList();
        }

        public List<DailyLog> GetByUserAndDateRange(long userId, DateOnly startDate, DateOnly endDate)
        {
            using var context = new KitFitnessContext();
            return context.DailyLogs
                .Include(d => d.LogItems)
                    .ThenInclude(li => li.Food)
                .Where(d => d.UserId == userId && d.LogDate >= startDate && d.LogDate <= endDate && !d.IsDeleted)
                .OrderBy(d => d.LogDate)
                .ThenBy(d => d.MealType)
                .ToList();
        }

        public DailyLog Add(DailyLog log)
        {
            using var context = new KitFitnessContext();
            log.CreatedAt = DateTime.Now;
            log.UpdatedAt = DateTime.Now;
            context.DailyLogs.Add(log);
            context.SaveChanges();
            return log;
        }

        public void Update(DailyLog log)
        {
            using var context = new KitFitnessContext();
            log.UpdatedAt = DateTime.Now;
            context.DailyLogs.Update(log);
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            using var context = new KitFitnessContext();
            var log = context.DailyLogs.Find(id);
            if (log != null)
            {
                log.IsDeleted = true;
                log.UpdatedAt = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}
