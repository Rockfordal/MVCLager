namespace MVCLager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartitems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CartId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        CreatedUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.StockItems", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.CartId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "ItemId", "dbo.StockItems");
            DropForeignKey("dbo.CartItems", "CartId", "dbo.Carts");
            DropIndex("dbo.CartItems", new[] { "ItemId" });
            DropIndex("dbo.CartItems", new[] { "CartId" });
            DropTable("dbo.CartItems");
        }
    }
}
