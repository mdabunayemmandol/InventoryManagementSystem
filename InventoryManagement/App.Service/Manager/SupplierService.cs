using App.Core.Model.SetupModule;
using App.Core.ViewModel.SetupModule;
using App.Persistance.DatabaseFile;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Manager
{
    public class SupplierService
    {
        private ApplicationDbContext _dbContext;
        public SupplierService()
        {
            _dbContext = new ApplicationDbContext();
        }
        public SupplierViewModel Get(int id)
        {
            var entity = _dbContext.Suppliers.SingleOrDefault(c => c.Id == id);

            return (Mapper.Map<Supplier, SupplierViewModel>(entity));
        }
        public IEnumerable<SupplierViewModel> GetAll()
        {
            var entities = _dbContext.Suppliers.ToList().Select(Mapper.Map<Supplier, SupplierViewModel>);
            return entities;
        }
        public int Add(SupplierViewModel vm)
        {
            var entity = Mapper.Map<SupplierViewModel, Supplier>(vm);
            _dbContext.Suppliers.Add(entity);
            return _dbContext.SaveChanges();
        }
        public object Get(object id)
        {
            throw new NotImplementedException();
        }
        public int Update(int id, SupplierViewModel vm)
        {
            var entity = _dbContext.Suppliers.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            return _dbContext.SaveChanges();
        }
        public int Remove(int id)
        {
            var entity = _dbContext.Suppliers.SingleOrDefault(c => c.Id == id);
            _dbContext.Suppliers.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
