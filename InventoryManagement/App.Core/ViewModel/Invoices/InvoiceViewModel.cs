using App.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ViewModel.Invoices
{
    public class InvoiceViewModel
    {
        public InvoiceViewModel()
        {
            SalesDetails = new List<InvoiceDettailsViewModel>();
        }
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal TotalBill { get; set; }
        public decimal? TransportCost { get; set; }
        public decimal Payable { get; set; }
        public decimal Payamount { get; set; }
        
        public IEnumerable<InvoiceDettailsViewModel> SalesDetails { get; set; }
    }
}
