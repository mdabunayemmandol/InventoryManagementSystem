using App.Core.Dtos.Invoices;
using App.Service.Manager.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagementApp.Controllers.APi.Invoice
{
    public class InvoiceController : ApiController
    {

        private readonly InvoiceManager invoiceManager;

        public InvoiceController()
        {
            invoiceManager = new InvoiceManager();
        }

        [Route("api/Invoice/GetVoucherNumber")]
        [HttpGet]
        public IHttpActionResult GetVoucherNumber()
        {
            try
            {
                var codeNo = invoiceManager.GenerateInvoiceNo();
                return Ok(codeNo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // GET: api/Invoice
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Invoice/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Invoice
        public IHttpActionResult Post([FromBody]InvoiceDto dto)
        {
            try
            {
                var entity = invoiceManager.Add(dto, "Admin");
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT: api/Invoice/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Invoice/5
        public void Delete(int id)
        {
        }
    }
}
