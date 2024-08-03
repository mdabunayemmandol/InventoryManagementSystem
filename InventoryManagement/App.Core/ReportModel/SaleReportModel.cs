using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ReportModel
{
    public class SaleReportModel
    {
        public string SalesNo { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public string Remark { get; set; }
    }
}
