namespace QRRestaurant_backend.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; } = "Empty";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
