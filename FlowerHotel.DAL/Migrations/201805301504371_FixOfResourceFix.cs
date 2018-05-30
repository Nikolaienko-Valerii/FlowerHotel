namespace FlowerHotel.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixOfResourceFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resources", "Hotel_Id", "dbo.Hotels");
            DropIndex("dbo.Resources", new[] { "Hotel_Id" });
            DropColumn("dbo.Resources", "Hotel_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resources", "Hotel_Id", c => c.Int());
            CreateIndex("dbo.Resources", "Hotel_Id");
            AddForeignKey("dbo.Resources", "Hotel_Id", "dbo.Hotels", "Id");
        }
    }
}
