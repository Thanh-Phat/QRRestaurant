namespace QRRestaurant_backend.Entities
{
    public class ChatContext
    {
        public int Id { get; set; }
        public int? TableId { get; set; }
        public string LastProduct { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Table Table { get; set; }
    }
}
