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
    public class CategoryService
    {
        private ApplicationDbContext _dbContext;
        public CategoryService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public CategoryViewModel Get(int id)
        {
            var entity = _dbContext.Categorys.SingleOrDefault(c => c.Id == id);

            return (Mapper.Map<Category, CategoryViewModel>(entity));
        }
        public IEnumerable<CategoryViewModel> GetAll()
        {
            var entities = _dbContext.Categorys.ToList()
                .Select(Mapper.Map<Category, CategoryViewModel>);
            return entities;
        }

        public int Add(CategoryViewModel vm)
        {
            var entity = Mapper.Map<CategoryViewModel, Category>(vm);
            _dbContext.Categorys.Add(entity);
            return _dbContext.SaveChanges();
        }

        public object Get(object id)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, CategoryViewModel vm)
        {
            var entity = _dbContext.Categorys.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            return _dbContext.SaveChanges();
        }

        public int Remove(int id)
        {
            var entity = _dbContext.Categorys.SingleOrDefault(c => c.Id == id);
            _dbContext.Categorys.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
