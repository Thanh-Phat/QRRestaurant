namespace QRRestaurant_backend.DTOs.Kitchen
{
    public class KitchenItemDto
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public string TableName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
