using App.Core.ViewModel.OperationModule;
using App.Service.Manager.OperationModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace InventoryManagementApp.Controllers.APi.OperationModule
{
    public class SalesController : ApiController
    {
        SaleService _service = new SaleService();
        [HttpGet]
        [Route("api/Sales/GetSalesNo")]
        public IHttpActionResult GetSalesNo()
        {
            try
            {
                var code = _service.SalesNo();
                return Ok(code);
            }
            catch (Exception e)
            {

                return BadRequest("Not Found");
            }
        }
        
        // GET: api/Sales
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

        // GET: api/Sales/5
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

        // POST: api/Sales
        public IHttpActionResult Post([FromBody]SaleViewModel vm)
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

        // PUT: api/Sales/5
        public IHttpActionResult Put(int id, [FromBody]SaleViewModel vm)
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

        // DELETE: api/Sales/5
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
