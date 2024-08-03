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
    public class PurchasedetailService
    {
        private ApplicationDbContext _dbContext;
        public PurchasedetailService()
        {
            _dbContext = new ApplicationDbContext();
        }
        public PurchasedetailViewModel Get(int id)
        {
            var entity = _dbContext.Purchasedetails.SingleOrDefault(c => c.Id == id);
            return (AutoMapper.Mapper.Map<Purchasedetail, PurchasedetailViewModel>(entity));
        }
        public IEnumerable<PurchasedetailViewModel> GetAll()
        {
            var entities = _dbContext.Purchasedetails
                .Include("Item")
                .Include("Item.Category")
                .ToList().Select(Mapper.Map<Purchasedetail, PurchasedetailViewModel>);
            return entities;
        }
        public int Add(PurchasedetailViewModel vm)
        {
            var entity = Mapper.Map<PurchasedetailViewModel, Purchasedetail>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            _dbContext.Purchasedetails.Add(entity);
            _dbContext.SaveChanges();

            var stock = new StockHistory();
            stock.ItemId = entity.ItemId;
            stock.Quantity =Convert.ToDecimal( entity.Quantity);
            stock.StockType = "In";
            stock.ReferanceTable = "PurchaseDetail";
            stock.RefaranceId = entity.Id;
            _dbContext.StockHistorys.Add(stock);
            _dbContext.SaveChanges();

            return entity.PurchasemusterId;
        }
        public int Update(int id, PurchasedetailViewModel vm)
        {
            var entity = _dbContext.Purchasedetails.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            _dbContext.SaveChanges();


            var historyEntity = _dbContext.StockHistorys.SingleOrDefault(c => c.RefaranceId == vm.Id);
            historyEntity.Quantity =Convert.ToDecimal( entity.Quantity);
            historyEntity.ItemId = entity.ItemId;
            _dbContext.SaveChanges();



            return entity.PurchasemusterId;
        }
        public int Remove(int id)
        {
            var entity = _dbContext.Purchasedetails.SingleOrDefault(c => c.Id == id);
            _dbContext.Purchasedetails.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
