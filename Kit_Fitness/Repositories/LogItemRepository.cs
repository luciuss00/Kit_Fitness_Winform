using Kit_Fitness.Data;
using Kit_Fitness.Models;
using Microsoft.EntityFrameworkCore;

namespace Kit_Fitness.Repositories
{
    public class LogItemRepository
    {
        public LogItem Add(LogItem item)
        {
            using var context = new KitFitnessContext();
            item.CreatedAt = DateTime.Now;
            item.UpdatedAt = DateTime.Now;
            context.LogItems.Add(item);
            context.SaveChanges();
            return item;
        }

        public void Delete(long id)
        {
            using var context = new KitFitnessContext();
            var item = context.LogItems.Find(id);
            if (item != null)
            {
                item.IsDeleted = true;
                item.UpdatedAt = DateTime.Now;
                context.SaveChanges();
            }
        }

        public List<LogItem> GetByDailyLogId(long dailyLogId)
        {
            using var context = new KitFitnessContext();
            return context.LogItems
                .Include(li => li.Food)
                .Where(li => li.DailyLogId == dailyLogId && !li.IsDeleted)
                .ToList();
        }
    }
}
