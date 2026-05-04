using QRRestaurant_backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace QRRestaurant_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<QRCode> QRCodes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShiftReport> ShiftReports { get; set; }
        public DbSet<ChatSession> ChatSessions { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ChatContext> ChatContexts { get; set; }
        public DbSet<ChatIntent> ChatIntents { get; set; }

    }
}
