namespace EcomMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductId_to_Int : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "CategoryId", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
        }
    }
}
