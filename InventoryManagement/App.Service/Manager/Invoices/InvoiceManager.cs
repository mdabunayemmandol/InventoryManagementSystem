using App.Core.Dtos.Invoices;
using App.Core.Model.SetupModule;
using App.Persistance.DatabaseFile;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Manager.Invoices
{
    public class InvoiceManager
    {
        private ApplicationDbContext _dbContext;
        public InvoiceManager()
        {
            _dbContext = new ApplicationDbContext();
        }
        public int Add(InvoiceDto dto, string user)
        {
            int salesId = 0;
            try
            {
                var entity = Mapper.Map<InvoiceDto,Invoice>(dto);
                entity.CreateBy = user;
                entity.CreateDate = DateTime.Now;

                _dbContext.Invoices.Add(entity);
                _dbContext.SaveChanges();
                salesId = entity.Id;

                return salesId;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string GenerateInvoiceNo()
        {
            int codeNo = 0;

            var list = _dbContext.Invoices.ToList()
                .OrderByDescending(c => c.Id).FirstOrDefault();

            if (list == null)
            {
                var code = "INVOICE-" + "0001";
                return code;
            }

            {
                string[] parts = list.InvoiceNo.Split('-');
                codeNo = Convert.ToInt32(parts[1]);
            }

            var finalCode = "INVOICE-" + (codeNo + 1).ToString().PadLeft(4, '0');
            return finalCode;
        }
    }
}
