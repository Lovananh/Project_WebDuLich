namespace Project_WebDuLich.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseTours : DbContext
    {
        public DatabaseTours()
            : base("name=DatabaseTours")
        {
        }

        public DbSet<Tours> tours { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<News> news { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>().HasKey(n => n.NewsID); // Đảm bảo khóa chính
        }
    }
}
