namespace App.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePurchasemstTotalBillTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchasemsts", "TotalBill", c => c.String());
            DropColumn("dbo.Purchasemsts", "TotalAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchasemsts", "TotalAmount", c => c.String());
            DropColumn("dbo.Purchasemsts", "TotalBill");
        }
    }
}
