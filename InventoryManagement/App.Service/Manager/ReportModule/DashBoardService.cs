using App.Core.ReportModel;
using App.Persistance.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Manager.ReportModule
{
    public class DashBoardService
    {
        private ApplicationDbContext _dbContext;

        public DashBoardService()
        {
            _dbContext = new ApplicationDbContext();
        }


        public DashBoardModel GetDashBoardData()
        {
            var data = new DashBoardModel()
            {
                TotalCustomer = _dbContext.Customers.ToList().Count(),
                TotalSupplier = _dbContext.Suppliers.ToList().Count(),
                TotalPurchase = _dbContext.Purchasedetails.ToList().Sum(c => c.TotalPrice),
                TotalSales = _dbContext.Salesdetails.ToList().Sum(c => c.TotalPrice)
            };

            return data;
        }



    }
}
