namespace QRRestaurant_backend.DTOs.Order
{
    public class CreateOrderRequest
    {
        public int TableId { get; set; }
        public List<OrderItemRequest> Items { get; set; }
    }
}
