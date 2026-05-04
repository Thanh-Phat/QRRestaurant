namespace QRRestaurant_backend.Entities
{
    public class QRCode
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}
