namespace App.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAllTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        Address = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Remark = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                        ItemsName = c.String(),
                        PurchasePrice = c.String(),
                        SalePrice = c.String(),
                        ReoderLevel = c.String(),
                        Remark = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Purchasedetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchasemusterId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.String(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: false)
                .ForeignKey("dbo.Purchasemusters", t => t.PurchasemusterId, cascadeDelete: false)
                .Index(t => t.PurchasemusterId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Purchasemusters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseNo = c.String(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        TotalAmount = c.String(),
                        Discount = c.String(),
                        PayAble = c.String(),
                        PayAmount = c.String(),
                        Remark = c.String(),
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
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false),
                        Address = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Remark = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalesNo = c.String(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        TotalAmount = c.String(),
                        Discount = c.String(),
                        PayAble = c.String(),
                        PayAmount = c.String(),
                        Remark = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.String(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Salesdetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.String(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: false)
                .ForeignKey("dbo.Sales", t => t.SaleId, cascadeDelete: false)
                .Index(t => t.SaleId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.StockHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockType = c.String(),
                        ReferanceTable = c.String(),
                        RefaranceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: false)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockHistories", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Salesdetails", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.Salesdetails", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Purchasedetails", "PurchasemusterId", "dbo.Purchasemusters");
            DropForeignKey("dbo.Purchasemusters", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Purchasedetails", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "UnitId", "dbo.Units");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropIndex("dbo.StockHistories", new[] { "ItemId" });
            DropIndex("dbo.Salesdetails", new[] { "ItemId" });
            DropIndex("dbo.Salesdetails", new[] { "SaleId" });
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.Purchasemusters", new[] { "SupplierId" });
            DropIndex("dbo.Purchasedetails", new[] { "ItemId" });
            DropIndex("dbo.Purchasedetails", new[] { "PurchasemusterId" });
            DropIndex("dbo.Items", new[] { "UnitId" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropTable("dbo.StockHistories");
            DropTable("dbo.Salesdetails");
            DropTable("dbo.Sales");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Purchasemusters");
            DropTable("dbo.Purchasedetails");
            DropTable("dbo.Units");
            DropTable("dbo.Items");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
        }
    }
}
