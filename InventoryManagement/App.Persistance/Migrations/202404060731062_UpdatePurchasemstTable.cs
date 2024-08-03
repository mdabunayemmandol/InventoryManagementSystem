namespace App.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePurchasemstTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchasemsts", "PurchaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Purchasemsts", "SalesDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchasemsts", "SalesDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Purchasemsts", "PurchaseDate");
        }
    }
}
