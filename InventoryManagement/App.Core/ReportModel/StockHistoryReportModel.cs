using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ReportModel
{
    public class StockHistoryReportModel
    {
        public string Item { get; set; }
        public decimal InQuantity { get; set; }
        public decimal OutQuantity { get; set; }
        public decimal Stock { get; set; }

    }
}
