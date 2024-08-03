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
    public class SalesdetailsController : ApiController
    {
        private SalesdetailService _service = new SalesdetailService();
        [Route("api/Salesdetails/GetSaledetail")]
        [HttpGet]
        public IHttpActionResult GetSaledetail(int id)
        {
            try
            {
                var info = _service.GetAll()
                    .Where(c => c.SaleId == id);
                return Ok(info);
            }
            catch (Exception e)
            {

                return BadRequest("Not Found");
            }
        }

        // GET: api/Salesdetails
        [HttpGet]
        [Route("api/Salesdetails/GetBySaleId")]
        public IHttpActionResult GetBySaleId(int saleId)
        {
            try
            {
                var entities = _service.GetAll().Where(c=>c.SaleId== saleId).ToList();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // GET: api/Salesdetails
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

        // GET: api/Salesdetails/5
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

        // POST: api/Salesdetails
        public IHttpActionResult Post([FromBody]SalesdetailViewModel vm)
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

        // PUT: api/Salesdetails/5
        public IHttpActionResult Put(int id, [FromBody]SalesdetailViewModel vm)
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

        // DELETE: api/Salesdetails/5
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
