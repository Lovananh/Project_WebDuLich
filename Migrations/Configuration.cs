namespace Project_WebDuLich.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Project_WebDuLich.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Project_WebDuLich.Models.DatabaseTours>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Project_WebDuLich.Models.DatabaseTours context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // Danh sách Tour du lịch thực tế
            var tours = new List<Tours>
    {
        new Tours { 
            TourID = 1,    
            TourName = "Khám phá Đà Nẵng",  
            Location = "Đà Nẵng",
            Price = 10, 
            Duration = TimeSpan.FromDays(2),
            ImageURL = "danang.jpg",
            Description = "Trải nghiệm vẻ đẹp của Đà Nẵng với bãi biển Mỹ Khê, Bà Nà Hills, cầu Rồng và ẩm thực đặc sắc." },
        new Tours { TourID = 2, TourName = "Hành trình Hội An", Location = "Hội An", Price = 2500000, Duration = TimeSpan.FromDays(2), ImageURL = "hoian.jpg", Description = "Khám phá phố cổ Hội An với những con hẻm nhỏ, đèn lồng lung linh và ẩm thực địa phương tuyệt vời." },
        new Tours { TourID = 3, TourName = "Khám phá Phố cổ Hà Nội", Location = "Hà Nội", Price = 4000000, Duration = TimeSpan.FromDays(2), ImageURL = "hanoi.jpg", Description = "Trải nghiệm nét cổ kính của phố cổ Hà Nội, thăm Lăng Bác, hồ Hoàn Kiếm và thưởng thức phở Hà Nội." },
        new Tours { TourID = 4, TourName = "Du lịch Vịnh Hạ Long", Location = "Hạ Long", Price = 5000000, Duration = TimeSpan.FromDays(1), ImageURL = "halong.jpg", Description = "Chiêm ngưỡng kỳ quan thiên nhiên thế giới Vịnh Hạ Long với những hòn đảo đá vôi hùng vĩ." }
    };
            context.tours.AddOrUpdate(t => t.TourID, tours.ToArray());

            // Danh sách người dùng
            var users = new List<User>
    {
        new User { UserID = 1, UserName = "admin", Email = "admin@example.com", PasswordHash = "123456", Role = "Admin", Phone = "0123456789" },
        new User { UserID = 2, UserName = "nguyenhong", Email = "hongnguyen@example.com", PasswordHash = "abcdef", Role = "User", Phone = "0987654321" },
        new User { UserID = 3, UserName = "phamvananh", Email = "vananh@example.com", PasswordHash = "password", Role = "User", Phone = "0934567890" }
    };
            context.users.AddOrUpdate(u => u.UserID, users.ToArray());

            // Danh sách tin tức du lịch
            var news = new List<News>
    {
        new News { NewsID = 1, Title = "Top địa điểm không thể bỏ lỡ khi đến Đà Nẵng", Content = "Bà Nà Hills, bãi biển Mỹ Khê, cầu Rồng là những nơi bạn nên ghé thăm khi đến Đà Nẵng.", TourID = 1, Location = "Đà Nẵng", CreatedDate = DateTime.Now },
        new News { NewsID = 2, Title = "Hội An lung linh về đêm", Content = "Thả đèn hoa đăng trên sông Hoài và khám phá phố cổ khi màn đêm buông xuống là trải nghiệm tuyệt vời.", TourID = 2, Location = "Hội An", CreatedDate = DateTime.Now },
        new News { NewsID = 3, Title = "Ẩm thực Hà Nội có gì đặc sắc?", Content = "Phở, bún chả, bánh cuốn là những món ăn không thể bỏ qua khi ghé thăm Hà Nội.", TourID = 3, Location = "Hà Nội", CreatedDate = DateTime.Now }
    };
            context.news.AddOrUpdate(n => n.NewsID, news.ToArray());

            // Danh sách đặt tour
            var bookings = new List<Booking>
    {
        new Booking { BookingID = 1, UserID = 2, TourID = 1, BookingDate = DateTime.Now, Status = Booking.BookingStatus.Confirmed, TotalPrice = 3500000 },
        new Booking { BookingID = 2, UserID = 3, TourID = 2, BookingDate = DateTime.Now, Status = Booking.BookingStatus.Pending, TotalPrice = 2500000 },
        new Booking { BookingID = 3, UserID = 2, TourID = 4, BookingDate = DateTime.Now, Status = Booking.BookingStatus.Canceled, TotalPrice = 5000000 }
    };
            context.bookings.AddOrUpdate(b => b.BookingID, bookings.ToArray());

            context.SaveChanges();
        }
    }
}
