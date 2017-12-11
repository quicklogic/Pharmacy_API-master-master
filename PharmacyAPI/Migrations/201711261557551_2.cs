namespace PharmacyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Availability", newName: "AvailabilityID");
            RenameColumn(table: "dbo.Products", name: "Category", newName: "CategoryID");
            RenameColumn(table: "dbo.Products", name: "Producer", newName: "ProducerID");
            RenameColumn(table: "dbo.Products", name: "Type", newName: "TypeID");
            RenameIndex(table: "dbo.Products", name: "IX_Producer", newName: "IX_ProducerID");
            RenameIndex(table: "dbo.Products", name: "IX_Availability", newName: "IX_AvailabilityID");
            RenameIndex(table: "dbo.Products", name: "IX_Type", newName: "IX_TypeID");
            RenameIndex(table: "dbo.Products", name: "IX_Category", newName: "IX_CategoryID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_CategoryID", newName: "IX_Category");
            RenameIndex(table: "dbo.Products", name: "IX_TypeID", newName: "IX_Type");
            RenameIndex(table: "dbo.Products", name: "IX_AvailabilityID", newName: "IX_Availability");
            RenameIndex(table: "dbo.Products", name: "IX_ProducerID", newName: "IX_Producer");
            RenameColumn(table: "dbo.Products", name: "TypeID", newName: "Type");
            RenameColumn(table: "dbo.Products", name: "ProducerID", newName: "Producer");
            RenameColumn(table: "dbo.Products", name: "CategoryID", newName: "Category");
            RenameColumn(table: "dbo.Products", name: "AvailabilityID", newName: "Availability");
        }
    }
}
