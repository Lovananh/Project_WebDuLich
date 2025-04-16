namespace Project_WebDuLich.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDurationToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tours", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tours", "Duration", c => c.Time(nullable: false, precision: 7));
        }
    }
}
