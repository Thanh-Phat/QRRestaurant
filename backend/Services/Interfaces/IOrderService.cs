using QRRestaurant_backend.DTOs.Order;

namespace QRRestaurant_backend.Services.Interfaces
{
    public interface IOrderService
    {
            Task<OrderResponse> CreateAsync(CreateOrderRequest request);
            Task<OrderResponse?> GetByIdAsync(int id);
            Task<List<OrderResponse>> GetAllTableAsync(int tableId);
            Task<bool> UpdateStatusAsync(int orderId, string status);
    }
}
