using Kit_Fitness.DTOs;
using Kit_Fitness.Models;
using Kit_Fitness.Repositories;

namespace Kit_Fitness.Services
{
    /// <summary>
    /// Service quản lý nghiệp vụ kho Tủ Lạnh (Cất giữ, Phân loại Ngăn Mát/Đá, Cảnh báo hạn dùng)
    /// </summary>
    public class FridgeService
    {
        private readonly FridgeItemRepository _fridgeRepo = new();
        private readonly FoodRepository _foodRepo = new();

        /// <summary>
        /// Lấy danh sách thực phẩm theo từng ngăn cụ thể (CHILL - Mát, FREEZER - Đá)
        /// </summary>
        public List<FridgeItemDisplay> GetItemsByStorage(long userId, string storageType)
        {
            var items = _fridgeRepo.GetByUserAndStorage(userId, storageType);
            return items.Select(MapToDisplay).ToList();
        }

        /// <summary>
        /// Lấy tất cả thực phẩm trong tủ lạnh của người dùng
        /// </summary>
        public List<FridgeItemDisplay> GetAllItems(long userId)
        {
            var items = _fridgeRepo.GetByUser(userId);
            return items.Select(MapToDisplay).ToList();
        }

        /// <summary>
        /// Đếm số lượng món trong từng ngăn (hỗ trợ cả ROOM gom vào Ngăn mát, FREEZE gom vào Ngăn đá)
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
        /// Thêm thực phẩm mới vào tủ lạnh với ngày hết hạn dự kiến
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
        /// Chuyển đổi vị trí bảo quản (Đang ở Ngăn mát -> chuyển sang Ngăn đông và ngược lại)
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
        /// Tiêu thụ thực phẩm (nếu dùng hết thì tự động xóa khỏi tủ, nếu còn dư thì giảm số lượng)
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
        /// Xóa bỏ thực phẩm khỏi tủ lạnh (đánh dấu xóa mềm IsDeleted = true)
        /// </summary>
        public void RemoveItem(long itemId)
        {
            _fridgeRepo.Delete(itemId);
        }

        /// <summary>
        /// Lọc danh sách các thực phẩm sắp hết hạn trong vòng 3 ngày tới (hoặc đã quá hạn) để cảnh báo
        /// </summary>
        public List<FridgeItemDisplay> GetExpiryWarnings(long userId)
        {
            var items = _fridgeRepo.GetExpiringSoon(userId);
            return items.Select(MapToDisplay).ToList();
        }

        /// <summary>
        /// Hàm chuyển đổi (Mapper) từ Entity FridgeItem sang DTO hiển thị FridgeItemDisplay
        /// Tính toán số ngày còn lại (DaysRemaining) và phân loại trạng thái tươi ngon
        /// </summary>
        private FridgeItemDisplay MapToDisplay(FridgeItem item)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);

            // daysRemaining: Số ngày còn lại tính từ hôm nay tới ngày hết hạn ExpiryDate
            // - Nếu không có hạn sử dụng, gán 999 ngày (không bao giờ hết hạn)
            // - Ví dụ: Hạn 29/10, Hôm nay 27/10 => 29 - 27 = 2 ngày
            int daysRemaining = item.ExpiryDate.HasValue
                ? item.ExpiryDate.Value.DayNumber - today.DayNumber
                : 999;

            // status: Phân loại trạng thái thực phẩm dựa theo số ngày còn lại
            // - < 0: Đã quá hạn ("expired" -> Huy hiệu đỏ)
            // - <= 3: Cận hạn cần ưu tiên ăn ngay ("expiring_soon" -> Huy hiệu vàng)
            // - Còn lại: Còn tươi ngon ("fresh" -> Huy hiệu xanh)
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
