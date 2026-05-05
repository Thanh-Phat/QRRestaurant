using QRRestaurant_backend.DTOs.Kitchen;

namespace QRRestaurant_backend.Services.Interfaces
{
    public interface IKitchenService
    {
        Task<List<KitchenItemDto>> GetPendingItemsAsync();
        Task<bool> UpdateStatusAsync(int orderItemId, string status);
    }
}
