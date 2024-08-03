using App.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Model.OperationModule
{
    public class PurchasemstDetails
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int PurchasemstId { get; set; }
        public Purchasemst Purchasemst { get; set; }
    }
}
