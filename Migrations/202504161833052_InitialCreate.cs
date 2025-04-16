namespace Project_WebDuLich.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        TourID = c.Int(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Tours", t => t.TourID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.TourID);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        TourID = c.Int(nullable: false, identity: true),
                        TourName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ImageURL = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.Int(nullable: false),
                        AvailableSeats = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        CityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TourID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CityID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        TourID = c.Int(),
                        Location = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NewsID)
                .ForeignKey("dbo.Tours", t => t.TourID)
                .Index(t => t.TourID);
            
            CreateTable(
                "dbo.TourHotels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TourID = c.Int(nullable: false),
                        HotelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Hotels", t => t.HotelID, cascadeDelete: true)
                .ForeignKey("dbo.Tours", t => t.TourID, cascadeDelete: true)
                .Index(t => t.TourID)
                .Index(t => t.HotelID);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        HotelID = c.Int(nullable: false, identity: true),
                        HotelName = c.String(nullable: false),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.HotelID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PasswordHash = c.String(nullable: false),
                        Role = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        BookingID = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentMethod = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Bookings", t => t.BookingID, cascadeDelete: true)
                .Index(t => t.BookingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "BookingID", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "UserID", "dbo.Users");
            DropForeignKey("dbo.Bookings", "TourID", "dbo.Tours");
            DropForeignKey("dbo.TourHotels", "TourID", "dbo.Tours");
            DropForeignKey("dbo.TourHotels", "HotelID", "dbo.Hotels");
            DropForeignKey("dbo.News", "TourID", "dbo.Tours");
            DropForeignKey("dbo.Tours", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Tours", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Payments", new[] { "BookingID" });
            DropIndex("dbo.TourHotels", new[] { "HotelID" });
            DropIndex("dbo.TourHotels", new[] { "TourID" });
            DropIndex("dbo.News", new[] { "TourID" });
            DropIndex("dbo.Tours", new[] { "CityID" });
            DropIndex("dbo.Tours", new[] { "CategoryID" });
            DropIndex("dbo.Bookings", new[] { "TourID" });
            DropIndex("dbo.Bookings", new[] { "UserID" });
            DropTable("dbo.Payments");
            DropTable("dbo.Users");
            DropTable("dbo.Hotels");
            DropTable("dbo.TourHotels");
            DropTable("dbo.News");
            DropTable("dbo.Cities");
            DropTable("dbo.Categories");
            DropTable("dbo.Tours");
            DropTable("dbo.Bookings");
        }
    }
}
