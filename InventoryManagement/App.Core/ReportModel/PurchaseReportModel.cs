using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ReportModel
{
    public class PurchaseReportModel
    {
        public string PurchaseNo { get; set; }
        public string SupplierName { get; set; }
        public DateTime Date { get; set; }
        public string Remark { get; set; }
    }
}
