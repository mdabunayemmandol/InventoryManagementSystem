using App.Core.ViewModel.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementApp.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult CustomersCreate()
        {
            var isActive = new CustomerViewModel() { IsActive = true };
            return View(isActive);
        }
    }
}