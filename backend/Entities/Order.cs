namespace QRRestaurant_backend.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }

        public Table Table { get; set; }
        public User User { get; set; }
    }
}
