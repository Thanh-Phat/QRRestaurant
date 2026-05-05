using Microsoft.EntityFrameworkCore;
using QRRestaurant_backend.Data;
using QRRestaurant_backend.DTOs.Kitchen;
using QRRestaurant_backend.Services.Interfaces;

namespace QRRestaurant_backend.Services.Implementations
{
    public class KitchenService : IKitchenService
    {
        private readonly AppDbContext _context;

        public KitchenService(AppDbContext context)
        {
            _context = context;
        }

        // Implement kitchen-related methods here, e.g., GetOrdersForKitchen, UpdateOrderStatus, etc.

        // Example method to get all pending orders for the kitchen
        public async Task<List<KitchenItemDto>> GetPendingItemsAsync()
        {
            return await _context.OrderItems
                .Include(i => i.Order)
                    .ThenInclude(o => o.Table)
                .Include(i => i.Product)
                .Where(i => i.Status == "Completed")
                .Select(i => new KitchenItemDto
                {
                    OrderItemId = i.Id,
                    OrderId = i.OrderId,
                    TableName = i.Order.Table.Name,
                    ProductName = i.Product.Name,
                    Quantity = i.Quantity,
                    Status = i.Status
                })
                .ToListAsync();
        }

        // Example method to update the status of an order item
        public async Task<bool> UpdateStatusAsync(int orderItemId, string status)
        {
            var orderItem = await _context.OrderItems.FindAsync(orderItemId);
            if (orderItem == null) return false;

            orderItem.Status = status;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
