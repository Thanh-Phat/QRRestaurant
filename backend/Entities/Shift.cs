namespace QRRestaurant_backend.Entities
{
    public class Shift
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
