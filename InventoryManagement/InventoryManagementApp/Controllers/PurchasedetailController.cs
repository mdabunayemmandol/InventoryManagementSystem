using App.Core.Model.OperationModule;
using App.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementApp.Controllers
{
    public class PurchasedetailController : Controller
    {
        // GET: Purchasedetail
        public ActionResult PurchasedetailCreate()
        {
            ViewBag.ItemId = new SelectList(new List<Item>(), "Id", "ItemsName");
            ViewBag.PurchasemusterId = new SelectList(new List<Purchasemuster>(), "Id", "PurchaseNo");
            return View();
        }
    }
}