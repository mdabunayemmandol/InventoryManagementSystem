using App.Core.Model.OperationModule;
using App.Core.ViewModel.OperationModule;
using App.Persistance.DatabaseFile;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Manager.OperationModule
{
    public class SaleService
    {
        private ApplicationDbContext _dbContext;
        public SaleService()
        {
            _dbContext = new ApplicationDbContext();
        }
        public SaleViewModel Get(int id)
        {
            var entity = _dbContext.Sales.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<Sale, SaleViewModel>(entity));
        }
        public IEnumerable<SaleViewModel> GetAll()
        {
            var entities = _dbContext.Sales
                .Include("Customer")
                .ToList().Select(Mapper.Map<Sale, SaleViewModel>);
            return entities;
        }
        public int Add(SaleViewModel vm)
        {
            var entity = Mapper.Map<SaleViewModel, Sale>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            _dbContext.Sales.Add(entity);
            _dbContext.SaveChanges();

            return entity.Id;
        }
        public int Update(int id, SaleViewModel vm)
        {
            var entity = _dbContext.Sales.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            _dbContext.SaveChanges();

            return entity.Id;
        }
        public int Remove(int id)
        {
            var entity = _dbContext.Sales.SingleOrDefault(c => c.Id == id);
            _dbContext.Sales.Remove(entity);
            return _dbContext.SaveChanges();
        }
        public string SalesNo()
        {
            int SalesNo = 0;

            var list = _dbContext.Sales.ToList()
                .OrderByDescending(c => c.Id).FirstOrDefault();

            if (list == null)
            {
                var code = "IMS-" + "00001";
                return code;
            }

            {
                string[] parts = list.SalesNo.Split('-');
                SalesNo = Convert.ToInt32(parts[1]);
            }

            var traineeParsonalNo = "IMS-" + (SalesNo + 1).ToString().PadLeft(5, '0');
            return traineeParsonalNo;
        }
    }
}
