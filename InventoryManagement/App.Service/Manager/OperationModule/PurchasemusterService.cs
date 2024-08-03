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
    public class PurchasemusterService
    {
        private ApplicationDbContext _dbContext;
        public PurchasemusterService()
        {
            _dbContext = new ApplicationDbContext();
        }
        public PurchasemusterViewModel Get(int id)
        {
            var entity = _dbContext.Purchasemusters.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<Purchasemuster, PurchasemusterViewModel>(entity));
        }
        public IEnumerable<PurchasemusterViewModel> GetAll()
        {
            var entities = _dbContext.Purchasemusters
                .Include("Supplier")
                .ToList().Select(Mapper.Map<Purchasemuster, PurchasemusterViewModel>);
            return entities;
        }
        public int Add(PurchasemusterViewModel vm)
        {
            var entity = Mapper.Map<PurchasemusterViewModel, Purchasemuster>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            _dbContext.Purchasemusters.Add(entity);
            _dbContext.SaveChanges();

            return entity.Id;
        }
        public int Update(int id, PurchasemusterViewModel vm)
        {
            var entity = _dbContext.Purchasemusters.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            _dbContext.SaveChanges();

            return entity.Id;
        }
        public int Remove(int id)
        {
            var entity = _dbContext.Purchasemusters.SingleOrDefault(c => c.Id == id);
            _dbContext.Purchasemusters.Remove(entity);
            return _dbContext.SaveChanges();
        }
        public string PurchaseNo()
        {
            int parsonalNo = 0;

            var list = _dbContext.Purchasemusters.ToList()
                .OrderByDescending(c => c.Id).FirstOrDefault();

            if (list == null)
            {
                var code = "IMS-" + "000001";
                return code;
            }

            {
                string[] parts = list.PurchaseNo.Split('-');
                parsonalNo = Convert.ToInt32(parts[1]);
            }

            var traineeParsonalNo = "IMS-" + (parsonalNo + 1).ToString().PadLeft(5, '0');
            return traineeParsonalNo;
        }
    }
}
