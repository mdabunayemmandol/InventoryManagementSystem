using App.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementApp.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult InvoiceCreate()
        {
            ViewBag.CustomerId = new SelectList(new List<Customer>(), "Id", "Name");
            ViewBag.SupplierId = new SelectList(new List<Supplier>(), "Id", "Name");
            return View();
        }
    }
}