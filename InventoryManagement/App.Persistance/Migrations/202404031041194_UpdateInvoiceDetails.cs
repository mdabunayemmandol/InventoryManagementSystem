namespace App.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInvoiceDetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoiceDetails", "UnitId", "dbo.Units");
            DropIndex("dbo.InvoiceDetails", new[] { "UnitId" });
            DropColumn("dbo.InvoiceDetails", "UnitId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoiceDetails", "UnitId", c => c.Int(nullable: false));
            CreateIndex("dbo.InvoiceDetails", "UnitId");
            AddForeignKey("dbo.InvoiceDetails", "UnitId", "dbo.Units", "Id", cascadeDelete: true);
        }
    }
}
