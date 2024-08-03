using App.Core.ViewModel.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementApp.Controllers
{
    public class UnitController : Controller
    {
        // GET: Unit
        public ActionResult UnitCreate()
        {
            var isActive = new UnitViewModel() { IsActive = true };
            return View(isActive);
        }
    }
}