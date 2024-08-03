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
    public class CustomerService
    {
        private ApplicationDbContext _dbContext;
        public CustomerService()
        {
            _dbContext = new ApplicationDbContext();
        }
        public CustomerViewModel Get(int id)
        {
            var entity = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            return(Mapper.Map<Customer,CustomerViewModel>(entity));
        }
        public IEnumerable<CustomerViewModel> GetAll()
        {
            var entities = _dbContext.Customers.ToList().Select(Mapper.Map<Customer, CustomerViewModel>);
            return entities;
        }
        public int Add(CustomerViewModel vm)
        {
            var entity = Mapper.Map<CustomerViewModel, Customer>(vm);
            _dbContext.Customers.Add(entity);
            return _dbContext.SaveChanges();
        }
        public object Get(object id)
        {
            throw new NotImplementedException();
        }
        public int Update(int id, CustomerViewModel vm)
        {
            var entity = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            return _dbContext.SaveChanges();
        }
        public int Remove(int id)
        {
            var entity = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            _dbContext.Customers.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
