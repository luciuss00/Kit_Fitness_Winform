using Kit_Fitness.Data;
using Kit_Fitness.Models;
using Microsoft.EntityFrameworkCore;

namespace Kit_Fitness.Repositories
{
    public class WorkoutLogRepository
    {
        public List<WorkoutLog> GetByUserAndDate(long userId, DateOnly date)
        {
            using var context = new KitFitnessContext();
            return context.WorkoutLogs
                .Where(w => w.UserId == userId && w.LogDate == date && !w.IsDeleted)
                .OrderBy(w => w.CreatedAt)
                .ToList();
        }

        public WorkoutLog Add(WorkoutLog log)
        {
            using var context = new KitFitnessContext();
            log.CreatedAt = DateTime.Now;
            log.UpdatedAt = DateTime.Now;
            context.WorkoutLogs.Add(log);
            context.SaveChanges();
            return log;
        }

        public int GetTotalBurnedCalories(long userId, DateOnly date)
        {
            using var context = new KitFitnessContext();
            return context.WorkoutLogs
                .Where(w => w.UserId == userId && w.LogDate == date && !w.IsDeleted)
                .Sum(w => w.BurnedCalories);
        }

        public int GetTotalDurationMinutes(long userId, DateOnly date)
        {
            using var context = new KitFitnessContext();
            return context.WorkoutLogs
                .Where(w => w.UserId == userId && w.LogDate == date && !w.IsDeleted)
                .Sum(w => w.DurationMinutes);
        }

        public bool Delete(long workoutLogId)
        {
            using var context = new KitFitnessContext();
            var log = context.WorkoutLogs.FirstOrDefault(w => w.Id == workoutLogId && !w.IsDeleted);
            if (log == null) return false;

            log.IsDeleted = true;
            log.UpdatedAt = DateTime.Now;
            context.SaveChanges();
            return true;
        }
    }
}
