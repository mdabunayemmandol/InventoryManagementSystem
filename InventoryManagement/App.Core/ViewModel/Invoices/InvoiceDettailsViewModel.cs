using App.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ViewModel.Invoices
{
    public class InvoiceDettailsViewModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
