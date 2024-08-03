using App.Core.Model.OperationModule;
using App.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistance.DatabaseFile
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Purchasemuster> Purchasemusters { get; set; }
        public DbSet<Purchasedetail> Purchasedetails { get; set; }
        public DbSet<StockHistory> StockHistorys { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Salesdetail> Salesdetails { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Purchasemst> Purchasemsts { get; set; }
    }
}
