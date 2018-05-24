namespace FlowerHotel.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userId_fix : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Plants", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Orders", "ApplicationUserId");
            DropColumn("dbo.Plants", "ApplicationUserId");
            RenameColumn(table: "dbo.Orders", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.Plants", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Orders", "ApplicationUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Plants", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "ApplicationUserId");
            CreateIndex("dbo.Plants", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Plants", new[] { "ApplicationUserId" });
            DropIndex("dbo.Orders", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Plants", "ApplicationUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Plants", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Orders", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Plants", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Plants", "ApplicationUser_Id");
            CreateIndex("dbo.Orders", "ApplicationUser_Id");
        }
    }
}
