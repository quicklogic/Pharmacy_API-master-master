namespace PharmacyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        RecipeImageURL = c.String(nullable: false, maxLength: 10),
                        login = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.login)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.ProductID)
                .Index(t => t.login);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Baskets", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Baskets", "login", "dbo.Users");
            DropIndex("dbo.Baskets", new[] { "login" });
            DropIndex("dbo.Baskets", new[] { "ProductID" });
            DropTable("dbo.Baskets");
        }
    }
}
