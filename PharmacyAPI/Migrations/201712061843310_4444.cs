namespace PharmacyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4444 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ImageURI", c => c.String(maxLength: 128, fixedLength: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ImageURI", c => c.String());
        }
    }
}
