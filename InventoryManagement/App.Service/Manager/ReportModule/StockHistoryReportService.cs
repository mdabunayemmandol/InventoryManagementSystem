using App.Core.ReportModel;
using App.Persistance.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Manager.ReportModule
{
    public class StockHistoryReportService
    {
        private ApplicationDbContext _dbContext;
        public StockHistoryReportService()
        {
            _dbContext = new ApplicationDbContext();
        }
        public List<StockHistoryReportModel> Getstock()
        {
            var list = new List<StockHistoryReportModel>();

            var items = _dbContext.Items.ToList();
            var entities = _dbContext.StockHistorys.
                Include("Item")
                .ToList();

            foreach (var item in items)
            {
                var data = new StockHistoryReportModel()
                {
                    Item = item.ItemsName,
                    InQuantity = entities.Where(c => c.ItemId == item.Id && c.StockType == "In").Sum(c => c.Quantity),
                    OutQuantity = entities.Where(c => c.ItemId == item.Id && c.StockType == "Out").Sum(c => c.Quantity),
                    Stock = entities.Where(c => c.ItemId == item.Id && c.StockType == "In").Sum(c => c.Quantity)- entities.Where(c => c.ItemId == item.Id && c.StockType == "Out").Sum(c => c.Quantity),

                };
                list.Add(data);

            }

            return list;
        }
    }
}
