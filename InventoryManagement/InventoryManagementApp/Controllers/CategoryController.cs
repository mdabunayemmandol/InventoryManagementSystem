using App.Core.ViewModel.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementApp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult CategoryCreate()
        {
            var isActive = new CategoryViewModel() { IsActive = true };
            return View(isActive);
        }
    }
}