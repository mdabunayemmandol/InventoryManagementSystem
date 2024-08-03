using App.Service.Manager.ReportModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagementApp.Controllers.APi.ReportModule
{
    public class DashBoardsController : ApiController
    {
        DashBoardService _service = new DashBoardService();


        [HttpGet]
        [Route("api/DashBoards/GetData")]
        public IHttpActionResult GetData()
        {
            try
            {
                var entities = _service.GetDashBoardData();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
