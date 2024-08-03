namespace App.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Invoices", "CreateBy", c => c.String());
            AddColumn("dbo.Invoices", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Invoices", "UpdateBy", c => c.String());
            AddColumn("dbo.Invoices", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Invoices", "DeleteBy", c => c.String());
            AddColumn("dbo.Invoices", "DeleteDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "DeleteDate");
            DropColumn("dbo.Invoices", "DeleteBy");
            DropColumn("dbo.Invoices", "UpdateDate");
            DropColumn("dbo.Invoices", "UpdateBy");
            DropColumn("dbo.Invoices", "CreateDate");
            DropColumn("dbo.Invoices", "CreateBy");
            DropColumn("dbo.Invoices", "IsDelete");
        }
    }
}
