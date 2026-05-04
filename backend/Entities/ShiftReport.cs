namespace QRRestaurant_backend.Entities
{
    public class ShiftReport
    {
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public int UserId { get; set; }
        public decimal TotalRevenue { get; set; }
        public DateTime CreatedAt { get; set; }

        public Shift Shift { get; set; }
        public User User { get; set; }
    }
}
