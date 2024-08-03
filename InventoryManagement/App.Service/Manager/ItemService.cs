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
    public class ItemService
    {
        private ApplicationDbContext _dbContext;
        public ItemService()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ItemViewModel Get(int id)
        {
            var entity = _dbContext.Items.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<Item, ItemViewModel>(entity));
        }
        public IEnumerable<ItemViewModel> GetAll()
        {
            var entities = _dbContext.Items
                .Include("Category")
                .Include("Unit")
                .ToList().Select(Mapper.Map<Item, ItemViewModel>);
            return entities;
        }
        public int Add(ItemViewModel vm)
        {
            var entity = Mapper.Map<ItemViewModel, Item>(vm);
            _dbContext.Items.Add(entity);
            return _dbContext.SaveChanges();
        }
        public object Get(object id)
        {
            throw new NotImplementedException();
        }
        public int Update(int id, ItemViewModel vm)
        {
            var entity = _dbContext.Items.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            return _dbContext.SaveChanges();
        }
        public int Remove(int id)
        {
            var entity = _dbContext.Items.SingleOrDefault(c => c.Id == id);
            _dbContext.Items.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
