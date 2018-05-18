namespace FlowerHotel.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeFixes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "ApplicationUserId");
            AddForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Employees", "UserId");
            DropColumn("dbo.Employees", "User");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "User", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "UserId", c => c.String());
            DropForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "ApplicationUserId" });
            DropColumn("dbo.Employees", "ApplicationUserId");
        }
    }
}
