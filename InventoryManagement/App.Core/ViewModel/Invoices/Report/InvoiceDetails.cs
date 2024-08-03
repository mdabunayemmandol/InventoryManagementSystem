using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ViewModel.Invoices.Report
{
    public class InvoiceDetails
    {
        public DateTime CreateDate { get; set; }

        public string InvoiceNo { get; set; }

        public string CustomerName { get; set; }

        public string Contact { get; set; }

        public string ItemName { get; set; }

        public string Unit { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public string Supplier { get; set; }

        public string FormDate { get; set; }

        public string ToDate { get; set; }
    }
}
