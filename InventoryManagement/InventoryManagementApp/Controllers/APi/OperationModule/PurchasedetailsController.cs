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
    public class PurchasedetailsController : ApiController
    {
        private PurchasedetailService _service = new PurchasedetailService();
        [Route("api/Purchasedetails/GetPurchasedetail")]
        [HttpGet]
        public IHttpActionResult GetPurchasedetail(int id)
        {
            try
            {
                var info = _service.GetAll()
                    .Where(c => c.PurchasemusterId == id);
                return Ok(info);
            }
            catch (Exception e)
            {

                return BadRequest("Not Found");
            }
        }


        // GET: api/Purchasedetails
        [HttpGet]
        [Route("api/Purchasedetails/GetByPurchaseId")]
        public IHttpActionResult GetByPurchaseId(int purchaseId)
        {
            try
            {
                var entities = _service.GetAll().Where(c=>c.PurchasemusterId == purchaseId).ToList();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Purchasedetails
        public IHttpActionResult Get()
        {
            try
            {
                var entities = _service.GetAll().ToList();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Purchasedetails/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _service.Get(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Purchasedetails
        public IHttpActionResult Post([FromBody]PurchasedetailViewModel vm)
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

        // PUT: api/Purchasedetails/5
        public IHttpActionResult Put(int id, [FromBody]PurchasedetailViewModel vm)
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

        // DELETE: api/Purchasedetails/5
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