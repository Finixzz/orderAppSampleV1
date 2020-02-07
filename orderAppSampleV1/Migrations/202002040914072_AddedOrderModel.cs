namespace orderAppSampleV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        TableId = c.Int(nullable: false),
                        UserId = c.String(),
                        Quantity = c.Byte(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Tables", t => t.TableId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.TableId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "TableId", "dbo.Tables");
            DropForeignKey("dbo.Orders", "ItemId", "dbo.Items");
            DropIndex("dbo.Orders", new[] { "TableId" });
            DropIndex("dbo.Orders", new[] { "ItemId" });
            DropTable("dbo.Orders");
        }
    }
}
