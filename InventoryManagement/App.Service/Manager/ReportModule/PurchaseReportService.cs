using App.Core.ReportModel;
using App.Persistance.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Manager.ReportModule
{
    public class PurchaseReportService
    {
        private ApplicationDbContext _dbContext;
        public PurchaseReportService()
        {
            _dbContext = new ApplicationDbContext();
        }
        public List<PurchaseReportModel> GetPurchaseById(int purchaseId)
        {
            var list = new List<PurchaseReportModel>();
            var entities = _dbContext.Purchasemusters.
                Include("Supplier").
                Where(c => c.Id == purchaseId).ToList().FirstOrDefault();

            var data = new PurchaseReportModel()
            {
                PurchaseNo = entities.PurchaseNo,
                SupplierName = entities.Supplier.SupplierName,
                Date = entities.Date,
                Remark = entities.Remark
            };

            list.Add(data);
            return list;
        }

        public List<PurchasedetailReportModel> GetPurchaseDetailsData (int purchseMstId)
        {
            var list = new List<PurchasedetailReportModel>();
            var data = _dbContext.Purchasedetails.Include("Item").Where(c => c.PurchasemusterId == purchseMstId).ToList();

            foreach (var item in data)
            {
                var d = new PurchasedetailReportModel()
                {
                    ItemName = item.Item.ItemsName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    Remark = item.Remark
                };

                list.Add(d);

            }
            return list;


        }


        
    }
}
