namespace QRRestaurant_backend.Entities
{
    public class ChatSession
    {
        public int Id { get; set; }
        public int? TableId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Table Table { get; set; }
    }
}
