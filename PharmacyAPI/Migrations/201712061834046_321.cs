namespace PharmacyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _321 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "ProductID", "dbo.Products");
            DropIndex("dbo.Images", new[] { "ProductID" });
            AddColumn("dbo.Products", "ImageURI", c => c.String());
            DropColumn("dbo.Baskets", "RecipeImageURL");
            DropTable("dbo.Images");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        imageURL = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Baskets", "RecipeImageURL", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Products", "ImageURI");
            CreateIndex("dbo.Images", "ProductID");
            AddForeignKey("dbo.Images", "ProductID", "dbo.Products", "ID");
        }
    }
}
