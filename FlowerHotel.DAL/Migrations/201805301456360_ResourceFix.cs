namespace FlowerHotel.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResourceFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resources", "HotelId", "dbo.Hotels");
            DropIndex("dbo.Resources", new[] { "HotelId" });
            RenameColumn(table: "dbo.Resources", name: "HotelId", newName: "Hotel_Id");
            CreateTable(
                "dbo.HotelResources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResourceId = c.Int(nullable: false),
                        HotelId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotels", t => t.HotelId, cascadeDelete: true)
                .ForeignKey("dbo.Resources", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ResourceId)
                .Index(t => t.HotelId);
            
            AlterColumn("dbo.Resources", "Hotel_Id", c => c.Int());
            CreateIndex("dbo.Resources", "Hotel_Id");
            AddForeignKey("dbo.Resources", "Hotel_Id", "dbo.Hotels", "Id");
            DropColumn("dbo.Resources", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resources", "Amount", c => c.Double(nullable: false));
            DropForeignKey("dbo.Resources", "Hotel_Id", "dbo.Hotels");
            DropForeignKey("dbo.HotelResources", "ResourceId", "dbo.Resources");
            DropForeignKey("dbo.HotelResources", "HotelId", "dbo.Hotels");
            DropIndex("dbo.HotelResources", new[] { "HotelId" });
            DropIndex("dbo.HotelResources", new[] { "ResourceId" });
            DropIndex("dbo.Resources", new[] { "Hotel_Id" });
            AlterColumn("dbo.Resources", "Hotel_Id", c => c.Int(nullable: false));
            DropTable("dbo.HotelResources");
            RenameColumn(table: "dbo.Resources", name: "Hotel_Id", newName: "HotelId");
            CreateIndex("dbo.Resources", "HotelId");
            AddForeignKey("dbo.Resources", "HotelId", "dbo.Hotels", "Id", cascadeDelete: true);
        }
    }
}
