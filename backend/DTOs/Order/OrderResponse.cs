namespace QRRestaurant_backend.DTOs.Order
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }

        public DateTime CreatedAt { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }

    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
