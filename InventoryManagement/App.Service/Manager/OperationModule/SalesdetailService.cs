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
    public class SalesdetailService
    {
        private ApplicationDbContext _dbContext;
        public SalesdetailService()
        {
            _dbContext = new ApplicationDbContext();
        }
        public SalesdetailViewModel Get(int id)
        {
            var entity = _dbContext.Salesdetails.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<Salesdetail, SalesdetailViewModel>(entity));
        }

        public object SaleId()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesdetailViewModel> GetAll()
        {
            var entities = _dbContext.Salesdetails
                .Include("Item")
                .ToList().Select(Mapper.Map<Salesdetail, SalesdetailViewModel>);
            return entities;
        }
        public int Add(SalesdetailViewModel vm)
        {
            var entity = Mapper.Map<SalesdetailViewModel, Salesdetail>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            _dbContext.Salesdetails.Add(entity);
            _dbContext.SaveChanges();


            var stock = new StockHistory();
            stock.ItemId = entity.ItemId;
            stock.Quantity =Convert.ToDecimal( entity.Quantity);
            stock.StockType = "Out";
            stock.ReferanceTable = "SalesDetail";
            stock.RefaranceId = entity.Id;
            _dbContext.StockHistorys.Add(stock);
            _dbContext.SaveChanges();

            return entity.SaleId;
        }
        public int Update(int id, SalesdetailViewModel vm)
        {
            var entity = _dbContext.Salesdetails.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            _dbContext.SaveChanges();


            var historyEntity = _dbContext.StockHistorys.SingleOrDefault(c => c.RefaranceId == vm.Id);
            historyEntity.Quantity = Convert.ToDecimal( entity.Quantity);
            historyEntity.ItemId = entity.ItemId;
            _dbContext.SaveChanges();

            return entity.SaleId;
        }
        public int Remove(int id)
        {
            var entity = _dbContext.Salesdetails.SingleOrDefault(c => c.Id == id);
            _dbContext.Salesdetails.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
