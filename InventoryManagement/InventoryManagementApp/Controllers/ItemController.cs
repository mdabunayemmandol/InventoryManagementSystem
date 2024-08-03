using App.Core.Model.SetupModule;
using App.Core.ViewModel.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementApp.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult ItemCreate()
        {
            ViewBag.CategoryId = new SelectList(new List<Category>(), "Id", "Name");
            ViewBag.UnitId = new SelectList(new List<Unit>(), "Id", "Name");
            var isActive = new ItemViewModel() { IsActive = true };
            return View(isActive);
        }
    }
}