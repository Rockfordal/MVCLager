namespace MVCLager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categoryonstockitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockItems", "Category_ID", c => c.Int());
            CreateIndex("dbo.StockItems", "Category_ID");
            AddForeignKey("dbo.StockItems", "Category_ID", "dbo.Categories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockItems", "Category_ID", "dbo.Categories");
            DropIndex("dbo.StockItems", new[] { "Category_ID" });
            DropColumn("dbo.StockItems", "Category_ID");
        }
    }
}
