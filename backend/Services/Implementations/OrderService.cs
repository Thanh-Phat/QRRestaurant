using Microsoft.EntityFrameworkCore;
using QRRestaurant_backend.Data;
using QRRestaurant_backend.DTOs.Order;
using QRRestaurant_backend.Entities;
using QRRestaurant_backend.Services.Interfaces;

namespace QRRestaurant_backend.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrderResponse> CreateAsync(CreateOrderRequest request)
        {
            //Create new order
            var order = new Order
            {
                TableId = request.TableId,
                Status = "Pending",
                TotalAmount = 0,
                CreatedAt = DateTime.UtcNow
            };
            _context.Orders.Add(order);
            await _context.Orders.AddAsync(order);

            decimal totalAmount = 0;

            //Add order items
            foreach (var item in request.Items)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null) continue;

                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Status = "Pending",
                    CreatedAt = DateTime.Now
                };

                totalAmount += product.Price * item.Quantity;
                _context.OrderItems.Add(orderItem);
            }

            //Update total amount
            order.TotalAmount = totalAmount;
            await _context.SaveChangesAsync();

            //return order response

            return await GetByIdAsync(order.Id) ?? new OrderResponse();
        }

        public async Task<OrderResponse?> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Table)
                .Include(o => o.User)
                .Where(o => o.Id == id)
                .Select(o => new OrderResponse
                {
                    Id = o.Id,
                    TableId = o.TableId,
                    Status = o.Status,
                    TotalAmount = o.TotalAmount,
                    CreatedAt = o.CreatedAt,
                    Items = _context.OrderItems
                            .Where(i => i.OrderId == o.Id)
                            .Join(_context.Products,
                                  i => i.ProductId,
                                  p => p.Id,
                                  (i, p) => new OrderItemDto
                                  {
                                      ProductId = p.Id,
                                      ProductName = p.Name,
                                      Price = p.Price,
                                      Quantity = i.Quantity
                                  }).ToList()
                }).FirstOrDefaultAsync();
        }
        //Get all orders for a table

        public async Task<List<OrderResponse>> GetAllTableAsync(int tableId)
        {
            return await _context.Orders
                .Include(o => o.TableId == tableId)
                .Select(o => new OrderResponse
                {
                    Id = o.Id,
                    TableId = o.TableId,
                    Status = o.Status,
                    TotalAmount = o.TotalAmount,
                    CreatedAt = o.CreatedAt,
                }).ToListAsync();
        }

        //Update order status

        public async Task<bool> UpdateStatusAsync(int orderId, string status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) return false;

            order.Status = status;
            await _context.SaveChangesAsync();
            return true;
        }


    } 
}
