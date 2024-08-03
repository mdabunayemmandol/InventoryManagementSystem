namespace App.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInvoiceModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Invoices", new[] { "SupplierId" });
            DropColumn("dbo.Invoices", "SupplierId");
            DropColumn("dbo.Invoices", "SaleType");
            DropColumn("dbo.Invoices", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "Address", c => c.String());
            AddColumn("dbo.Invoices", "SaleType", c => c.String());
            AddColumn("dbo.Invoices", "SupplierId", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoices", "SupplierId");
            AddForeignKey("dbo.Invoices", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
        }
    }
}
