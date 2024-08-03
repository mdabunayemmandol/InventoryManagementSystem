using App.Core.CommonModel;
using App.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Model.OperationModule
{
    public class Purchasedetail: BaseDomain
    {
        public int Id { get; set; }
        public int PurchasemusterId { get; set; }
        public Purchasemuster Purchasemuster { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string Remark { get; set; }
    }
}
