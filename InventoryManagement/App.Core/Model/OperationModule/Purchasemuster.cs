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
    public class Purchasemuster: BaseDomain
    {
        public int Id { get; set; }
        [Required]
        public string PurchaseNo { get; set; }
        [Required]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime Date { get; set; }
        public string TotalAmount { get; set; }
        public string Discount { get; set; }
        public string PayAble { get; set; }
        public string PayAmount { get; set; }
        public string Remark { get; set; }
    }
}
