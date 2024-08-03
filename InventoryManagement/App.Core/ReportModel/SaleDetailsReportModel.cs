using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ReportModel
{
    public class SaleDetailsReportModel
    {
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string Remark { get; set; }
    }
}
