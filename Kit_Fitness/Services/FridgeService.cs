using Kit_Fitness.DTOs;
using Kit_Fitness.Models;
using Kit_Fitness.Repositories;

namespace Kit_Fitness.Services
{
    public class FridgeService
    {
        private readonly FridgeItemRepository _fridgeRepo = new();
        private readonly FoodRepository _foodRepo = new();

        /// <summary>
        /// Lấy danh sách thực phẩm theo ngăn
        /// </summary>
        public List<FridgeItemDisplay> GetItemsByStorage(long userId, string storageType)
        {
            var items = _fridgeRepo.GetByUserAndStorage(userId, storageType);
            return items.Select(MapToDisplay).ToList();
        }

        /// <summary>
        /// Lấy tất cả thực phẩm trong tủ lạnh
        /// </summary>
        public List<FridgeItemDisplay> GetAllItems(long userId)
        {
            var items = _fridgeRepo.GetByUser(userId);
            return items.Select(MapToDisplay).ToList();
        }

        /// <summary>
        /// Đếm số món theo từng ngăn
        /// </summary>
        public (int chillCount, int freezerCount) GetStorageCounts(long userId)
        {
            var all = _fridgeRepo.GetByUser(userId);
            return (
                all.Count(i => i.StorageType == "CHILL" || i.StorageType == "ROOM"),
                all.Count(i => i.StorageType == "FREEZER" || i.StorageType == "FREEZE")
            );
        }

        /// <summary>
        /// Thêm thực phẩm vào tủ lạnh
        /// </summary>
        public void AddItem(long userId, long foodId, decimal quantity, string storageType, DateOnly? expiryDate)
        {
            _fridgeRepo.Add(new FridgeItem
            {
                UserId = userId,
                FoodId = foodId,
                Quantity = quantity,
                StorageType = storageType,
                ExpiryDate = expiryDate
            });
        }

        /// <summary>
        /// Chuyển ngăn (CHILL <-> FREEZER)
        /// </summary>
        public void ToggleStorage(long itemId)
        {
            var item = _fridgeRepo.GetById(itemId);
            if (item != null)
            {
                item.StorageType = item.StorageType == "CHILL" ? "FREEZER" : "CHILL";
                _fridgeRepo.Update(item);
            }
        }

        /// <summary>
        /// Sử dụng (giảm số lượng hoặc xóa)
        /// </summary>
        public void UseItem(long itemId, decimal quantityUsed)
        {
            var item = _fridgeRepo.GetById(itemId);
            if (item != null)
            {
                if (item.Quantity <= quantityUsed)
                {
                    _fridgeRepo.Delete(itemId);
                }
                else
                {
                    item.Quantity -= quantityUsed;
                    _fridgeRepo.Update(item);
                }
            }
        }

        /// <summary>
        /// Xóa thực phẩm khỏi tủ lạnh
        /// </summary>
        public void RemoveItem(long itemId)
        {
            _fridgeRepo.Delete(itemId);
        }

        /// <summary>
        /// Lấy cảnh báo hết hạn
        /// </summary>
        public List<FridgeItemDisplay> GetExpiryWarnings(long userId)
        {
            var items = _fridgeRepo.GetExpiringSoon(userId);
            return items.Select(MapToDisplay).ToList();
        }

        private FridgeItemDisplay MapToDisplay(FridgeItem item)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            int daysRemaining = item.ExpiryDate.HasValue
                ? item.ExpiryDate.Value.DayNumber - today.DayNumber
                : 999;

            string status = daysRemaining switch
            {
                < 0 => "expired",
                <= 3 => "expiring_soon",
                _ => "fresh"
            };

            return new FridgeItemDisplay
            {
                Id = item.Id,
                FoodName = item.Food?.Name ?? "Không tên",
                Quantity = item.Quantity,
                Unit = item.Food?.Unit ?? "g",
                ExpiryDate = item.ExpiryDate,
                StorageType = item.StorageType,
                DaysRemaining = daysRemaining,
                Status = status
            };
        }
    }
}
