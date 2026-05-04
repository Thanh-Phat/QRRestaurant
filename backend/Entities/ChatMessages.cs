namespace QRRestaurant_backend.Entities
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public string Message { get; set; }
        public bool IsBot { get; set; }
        public DateTime CreatedAt { get; set; }

        public ChatSession Session { get; set; }


    }
}
