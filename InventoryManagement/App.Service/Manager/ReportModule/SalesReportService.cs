using App.Core.Model.OperationModule;
using App.Core.ReportModel;
using App.Core.ViewModel.OperationModule;
using App.Persistance.DatabaseFile;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Manager.ReportModule
{
    public class SalesReportService
    {
        private ApplicationDbContext _dbContext;
        public SalesReportService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public List<SaleReportModel> GetSaleById(int saleId)
        {
            var list = new List<SaleReportModel>();

            var entities = _dbContext.Sales.
                Include("Customer").
                Where(c => c.Id == saleId).ToList().FirstOrDefault();

            var data = new SaleReportModel()
            {
                SalesNo = entities.SalesNo,
                CustomerName = entities.Customer.CustomerName,
                Date = entities.Date,
                Remark = entities.Remark
            };

            list.Add(data);
            return list;

        }

        public List<SaleDetailsReportModel> GetSaleDetialsById(int salesId)
        {
            var details = _dbContext.Salesdetails
                .Include("Item")
                .Where(c => c.SaleId == salesId).ToList();

            var list = new List<SaleDetailsReportModel>();

            foreach (var d in details)
            {
                var singalData = new SaleDetailsReportModel();
                singalData.ItemName = d.Item.ItemsName;
                singalData.Price = d.Price;
                singalData.Quantity = d.Quantity;
                singalData.TotalPrice = d.TotalPrice;
                list.Add(singalData);
            }

            return list;
        }
        
    }
}
