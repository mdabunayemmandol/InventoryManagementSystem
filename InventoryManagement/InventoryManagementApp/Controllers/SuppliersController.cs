using App.Core.ViewModel.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementApp.Controllers
{
    public class SuppliersController : Controller
    {
        // GET: Suppliers
        public ActionResult SuppliersCreate()
        {
            var isActive = new SupplierViewModel() { IsActive = true };
            return View(isActive);
        }
    }
}