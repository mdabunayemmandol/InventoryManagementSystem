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
    public class PurchasemstController : ApiController
    {
        private readonly PurchasemstManager purchasemstManager;
        public PurchasemstController()
        {
            purchasemstManager = new PurchasemstManager();
        }
        [Route("api/Purchasemst/GetVoucherNumber")]
        [HttpGet]
        public IHttpActionResult GetVoucherNumber()
        {
            try
            {
                var codeNo = purchasemstManager.GeneratePurchasemstNo();
                return Ok(codeNo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // GET: api/Purchasemst
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Purchasemst/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Purchasemst
        public IHttpActionResult Post([FromBody]PurchasemstDto dto)
        {
            try
            {
                var entity = purchasemstManager.Add(dto, "Admin");
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT: api/Purchasemst/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Purchasemst/5
        public void Delete(int id)
        {
        }
    }
}
