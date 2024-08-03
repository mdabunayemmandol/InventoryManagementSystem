namespace App.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePurchasemstTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchasemsts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchasemstNo = c.String(),
                        SupplierId = c.Int(nullable: false),
                        SupplierName = c.String(),
                        PhoneNumber = c.String(),
                        SalesDate = c.DateTime(nullable: false),
                        TotalAmount = c.String(),
                        TransportCost = c.Decimal(precision: 18, scale: 2),
                        PayAble = c.String(),
                        PayAmount = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.String(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: false)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.PurchasemstDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchasemstId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: false)
                .ForeignKey("dbo.Purchasemsts", t => t.PurchasemstId, cascadeDelete: false)
                .Index(t => t.ItemId)
                .Index(t => t.PurchasemstId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchasemsts", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchasemstDetails", "PurchasemstId", "dbo.Purchasemsts");
            DropForeignKey("dbo.PurchasemstDetails", "ItemId", "dbo.Items");
            DropIndex("dbo.PurchasemstDetails", new[] { "PurchasemstId" });
            DropIndex("dbo.PurchasemstDetails", new[] { "ItemId" });
            DropIndex("dbo.Purchasemsts", new[] { "SupplierId" });
            DropTable("dbo.PurchasemstDetails");
            DropTable("dbo.Purchasemsts");
        }
    }
}
