namespace App.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInvoiceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNo = c.String(),
                        CustomerId = c.Int(nullable: false),
                        CustomerName = c.String(),
                        PhoneNumber = c.String(),
                        SalesDate = c.DateTime(nullable: false),
                        TotalBill = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransportCost = c.Decimal(precision: 18, scale: 2),
                        Payable = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Payamount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SupplierId = c.Int(nullable: false),
                        SaleType = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: false)
                .Index(t => t.CustomerId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: false)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: false)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: false)
                .Index(t => t.ItemId)
                .Index(t => t.UnitId)
                .Index(t => t.InvoiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.InvoiceDetails", "UnitId", "dbo.Units");
            DropForeignKey("dbo.InvoiceDetails", "ItemId", "dbo.Items");
            DropForeignKey("dbo.InvoiceDetails", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers");
            DropIndex("dbo.InvoiceDetails", new[] { "InvoiceId" });
            DropIndex("dbo.InvoiceDetails", new[] { "UnitId" });
            DropIndex("dbo.InvoiceDetails", new[] { "ItemId" });
            DropIndex("dbo.Invoices", new[] { "SupplierId" });
            DropIndex("dbo.Invoices", new[] { "CustomerId" });
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Invoices");
        }
    }
}
