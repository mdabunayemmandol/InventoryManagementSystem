using App.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Model.OperationModule
{
    public class StockHistory
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public decimal Quantity { get; set; }
        public string StockType { get; set; }
        public string ReferanceTable { get; set; }
        public int RefaranceId { get; set; }
    }
}
