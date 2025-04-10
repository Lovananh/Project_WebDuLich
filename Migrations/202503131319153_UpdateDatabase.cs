namespace Project_WebDuLich.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
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
                        Location = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.Time(nullable: false, precision: 7),
                        ImageURL = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TourID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "TourID", "dbo.Tours");
            DropForeignKey("dbo.Bookings", "UserID", "dbo.Users");
            DropForeignKey("dbo.Bookings", "TourID", "dbo.Tours");
            DropIndex("dbo.News", new[] { "TourID" });
            DropIndex("dbo.Bookings", new[] { "TourID" });
            DropIndex("dbo.Bookings", new[] { "UserID" });
            DropTable("dbo.News");
            DropTable("dbo.Users");
            DropTable("dbo.Tours");
            DropTable("dbo.Bookings");
        }
    }
}
