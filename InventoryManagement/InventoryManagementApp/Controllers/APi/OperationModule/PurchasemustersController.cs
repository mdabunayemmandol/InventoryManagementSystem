using App.Core.ViewModel.OperationModule;
using App.Service.Manager.OperationModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagementApp.Controllers.APi.OperationModule
{
    public class PurchasemustersController : ApiController
    {
        PurchasemusterService _service = new PurchasemusterService();
        [HttpGet]
        [Route("api/Purchasemusters/GetPurchaseNo")]
        public IHttpActionResult GetPurchaseNo()
        {
            try
            {
                var code = _service.PurchaseNo();
                return Ok(code);
            }
            catch (Exception e)
            {

                return BadRequest("Not Found");
            }
        }

        // GET: api/Purchasemusters
        public IHttpActionResult Get()
        {
            try
            {
                var entities = _service.GetAll();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Purchasemusters/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _service.GetAll().Where(c => c.Id == id).FirstOrDefault();
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Purchasemusters
        public IHttpActionResult Post([FromBody]PurchasemusterViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _service.Add(vm);
                    return Ok(entity);
                }
                else
                {
                    return BadRequest("Required Field Must Not be Empty!");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Purchasemusters/5
        public IHttpActionResult Put(int id, [FromBody]PurchasemusterViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _service.Update(id, vm);
                    return Ok(entity);
                }
                else
                {
                    return BadRequest("Required Field Must Not be Empty!");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Purchasemusters/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = _service.Remove(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
