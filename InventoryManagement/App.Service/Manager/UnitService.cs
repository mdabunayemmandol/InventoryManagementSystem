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
    public class UnitService
    {
        private ApplicationDbContext _dbContext;
        public UnitService()
        {
            _dbContext = new ApplicationDbContext();
        }
        public UnitViewModel Get(int id)
        {
            var entity = _dbContext.Units.SingleOrDefault(c => c.Id == id);

            return (Mapper.Map<Unit, UnitViewModel>(entity));
        }
        public IEnumerable<UnitViewModel> GetAll()
        {
            var entities = _dbContext.Units.ToList().Select(Mapper.Map<Unit, UnitViewModel>);
            return entities;
        }
        public int Add(UnitViewModel vm)
        {
            var entity = Mapper.Map<UnitViewModel, Unit>(vm);
            _dbContext.Units.Add(entity);
            return _dbContext.SaveChanges();
        }
        public object Get(object id)
        {
            throw new NotImplementedException();
        }
        public int Update(int id, UnitViewModel vm)
        {
            var entity = _dbContext.Units.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            return _dbContext.SaveChanges();
        }
        public int Remove(int id)
        {
            var entity = _dbContext.Units.SingleOrDefault(c => c.Id == id);
            _dbContext.Units.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
