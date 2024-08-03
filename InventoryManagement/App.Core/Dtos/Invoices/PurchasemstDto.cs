using App.Core.Model.OperationModule;
using App.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Dtos.Invoices
{
    public class PurchasemstDto
    {
        public PurchasemstDto()
        {
            PurchaseDetails = new List<PurchasemstDetails>();
        }
        public int Id { get; set; }
        public string PurchasemstNo { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public string SupplierName { get; set; }
        public string PhoneNumber { get; set; }
        public string PurchaseDate { get; set; }
        public string TotalBill { get; set; }
        public decimal? TransportCost { get; set; }
        public string PayAble { get; set; }
        public string PayAmount { get; set; }
        public ICollection<PurchasemstDetails> PurchaseDetails { get; set; }
    }
}
