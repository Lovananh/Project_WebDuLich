namespace Project_WebDuLich.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Project_WebDuLich.Models;

    public partial class DatabaseTour : DbContext
    {
        public DatabaseTour()
            : base("name=DatabaseTour1")
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Tours> tours { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<News> news { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Hotel> hotels { get; set; }
        public DbSet<TourHotel> tourHotels { get; set; }
        public DbSet<Payment> payments { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
