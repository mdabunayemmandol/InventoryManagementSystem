using App.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementApp.Controllers
{
    public class PurchasemstController : Controller
    {
        // GET: Purchasemst
        public ActionResult PurchasemstCreate()
        {
            ViewBag.SupplierId = new SelectList(new List<Supplier>(), "Id", "Name");
            return View();
        }
    }
}