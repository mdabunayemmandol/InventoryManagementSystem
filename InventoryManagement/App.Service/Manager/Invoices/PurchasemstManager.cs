using App.Core.Dtos.Invoices;
using App.Core.Model.OperationModule;
using App.Persistance.DatabaseFile;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Manager.Invoices
{
    public class PurchasemstManager
    {
        private ApplicationDbContext _dbContext;
        public PurchasemstManager()
        {
            _dbContext = new ApplicationDbContext();
        }
        public int Add(PurchasemstDto dto, string user)
        {
            int PurchaseId = 0;
            try
            {
                var entity = Mapper.Map<PurchasemstDto, Purchasemst>(dto);
                entity.CreateBy = user;
                entity.CreateDate = DateTime.Now;
                _dbContext.Purchasemsts.Add(entity);
                _dbContext.SaveChanges();
                PurchaseId = entity.Id;
                return PurchaseId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string GeneratePurchasemstNo()
        {
            int codeNo = 0;
            var list = _dbContext.Purchasemsts.ToList()
                .OrderByDescending(c => c.Id).FirstOrDefault();

            if (list == null)
            {
                var code = "Purchase-" + "0001";
                return code;
            }
            {
                string[] parts = list.PurchasemstNo.Split('-');
                codeNo = Convert.ToInt32(parts[1]);
            }
            var finalCode = "Purchase-" + (codeNo + 1).ToString().PadLeft(4, '0');
            return finalCode;
        }
    }
}
