using App.Core.Model.OperationModule;
using App.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementApp.Controllers
{
    public class SalesdetailController : Controller
    {
        // GET: Salesdetail
        public ActionResult SalesdetailCreate()
        {
            ViewBag.ItemId = new SelectList(new List<Item>(), "Id", "ItemsName");
            ViewBag.SaleId = new SelectList(new List<Sale>(), "Id", "SalesNo");
            return View();
        }
    }
}