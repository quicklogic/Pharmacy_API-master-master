namespace PharmacyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PharmacyAPIPrototype123Test_db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Availabilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Producer = c.Int(nullable: false),
                        Description = c.String(maxLength: 500),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Availability = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        Discount = c.Int(),
                        Total = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category)
                .ForeignKey("dbo.Producers", t => t.Producer)
                .ForeignKey("dbo.Types", t => t.Type)
                .ForeignKey("dbo.Availabilities", t => t.Availability)
                .Index(t => t.Producer)
                .Index(t => t.Availability)
                .Index(t => t.Type)
                .Index(t => t.Category);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        imageURL = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 100),
                        Status = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 0),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Delivery = c.Int(nullable: false),
                        Payment = c.Int(nullable: false),
                        Commentary = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DeliveryMethod", t => t.Delivery)
                .ForeignKey("dbo.PaymentMethod", t => t.Payment)
                .ForeignKey("dbo.Users", t => t.Login)
                .ForeignKey("dbo.Statuses", t => t.Status)
                .Index(t => t.Login)
                .Index(t => t.Status)
                .Index(t => t.Delivery)
                .Index(t => t.Payment);
            
            CreateTable(
                "dbo.DeliveryMethod",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PaymentMethod",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Recipies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        RecipeImageURL = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        login = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.login)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID)
                .Index(t => t.login);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        login = c.String(nullable: false, maxLength: 100),
                        password = c.String(nullable: false, maxLength: 100),
                        AccessLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.login);
            
            CreateTable(
                "dbo.UsersInfo",
                c => new
                    {
                        login = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        SecondName = c.String(nullable: false, maxLength: 100),
                        Patronomyc = c.String(maxLength: 100),
                        number = c.String(nullable: false, maxLength: 11),
                        mail = c.String(nullable: false, maxLength: 100),
                        address = c.String(nullable: false, maxLength: 100),
                        BornDate = c.DateTime(nullable: false, storeType: "date"),
                        OrdersPrice = c.Decimal(nullable: false, precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.login)
                .ForeignKey("dbo.Users", t => t.login)
                .Index(t => t.login);
            
            CreateTable(
                "dbo.Statuses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                        logoURL = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Availability", "dbo.Availabilities");
            DropForeignKey("dbo.Products", "Type", "dbo.Types");
            DropForeignKey("dbo.Recipies", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "Producer", "dbo.Producers");
            DropForeignKey("dbo.Orders", "Status", "dbo.Statuses");
            DropForeignKey("dbo.Recipies", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.UsersInfo", "login", "dbo.Users");
            DropForeignKey("dbo.Recipies", "login", "dbo.Users");
            DropForeignKey("dbo.Orders", "Login", "dbo.Users");
            DropForeignKey("dbo.ProductOrders", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductOrders", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Payment", "dbo.PaymentMethod");
            DropForeignKey("dbo.Orders", "Delivery", "dbo.DeliveryMethod");
            DropForeignKey("dbo.Images", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "Category", "dbo.Categories");
            DropIndex("dbo.ProductOrders", new[] { "ProductID" });
            DropIndex("dbo.ProductOrders", new[] { "OrderID" });
            DropIndex("dbo.UsersInfo", new[] { "login" });
            DropIndex("dbo.Recipies", new[] { "login" });
            DropIndex("dbo.Recipies", new[] { "ProductID" });
            DropIndex("dbo.Recipies", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "Payment" });
            DropIndex("dbo.Orders", new[] { "Delivery" });
            DropIndex("dbo.Orders", new[] { "Status" });
            DropIndex("dbo.Orders", new[] { "Login" });
            DropIndex("dbo.Images", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "Category" });
            DropIndex("dbo.Products", new[] { "Type" });
            DropIndex("dbo.Products", new[] { "Availability" });
            DropIndex("dbo.Products", new[] { "Producer" });
            DropTable("dbo.ProductOrders");
            DropTable("dbo.Types");
            DropTable("dbo.Producers");
            DropTable("dbo.Statuses");
            DropTable("dbo.UsersInfo");
            DropTable("dbo.Users");
            DropTable("dbo.Recipies");
            DropTable("dbo.PaymentMethod");
            DropTable("dbo.DeliveryMethod");
            DropTable("dbo.Orders");
            DropTable("dbo.Images");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Availabilities");
        }
    }
}
