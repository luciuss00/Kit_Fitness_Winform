using Kit_Fitness.Data;
using Kit_Fitness.Models;
using Microsoft.EntityFrameworkCore;

namespace Kit_Fitness.Repositories
{
    public class FridgeItemRepository
    {
        public List<FridgeItem> GetByUser(long userId)
        {
            using var context = new KitFitnessContext();
            return context.FridgeItems
                .Include(f => f.Food)
                .Where(f => f.UserId == userId && !f.IsDeleted)
                .OrderBy(f => f.ExpiryDate)
                .ToList();
        }

        public List<FridgeItem> GetByUserAndStorage(long userId, string storageType)
        {
            using var context = new KitFitnessContext();
            return context.FridgeItems
                .Include(f => f.Food)
                .Where(f => f.UserId == userId && f.StorageType == storageType && !f.IsDeleted)
                .OrderBy(f => f.ExpiryDate)
                .ToList();
        }

        public List<FridgeItem> GetExpiringSoon(long userId, int daysThreshold = 3)
        {
            using var context = new KitFitnessContext();
            var threshold = DateOnly.FromDateTime(DateTime.Now.AddDays(daysThreshold));
            return context.FridgeItems
                .Include(f => f.Food)
                .Where(f => f.UserId == userId && !f.IsDeleted
                    && f.ExpiryDate != null && f.ExpiryDate <= threshold)
                .OrderBy(f => f.ExpiryDate)
                .ToList();
        }

        public FridgeItem Add(FridgeItem item)
        {
            using var context = new KitFitnessContext();
            item.CreatedAt = DateTime.Now;
            item.UpdatedAt = DateTime.Now;
            context.FridgeItems.Add(item);
            context.SaveChanges();
            return item;
        }

        public FridgeItem? GetById(long id)
        {
            using var context = new KitFitnessContext();
            return context.FridgeItems
                .Include(f => f.Food)
                .FirstOrDefault(f => f.Id == id && !f.IsDeleted);
        }

        public void Update(FridgeItem item)
        {
            using var context = new KitFitnessContext();
            item.UpdatedAt = DateTime.Now;
            context.FridgeItems.Update(item);
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            using var context = new KitFitnessContext();
            var item = context.FridgeItems.Find(id);
            if (item != null)
            {
                item.IsDeleted = true;
                item.UpdatedAt = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}
