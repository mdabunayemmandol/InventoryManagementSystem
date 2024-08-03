using App.Core.Model.SetupModule;
using App.Core.ViewModel.OperationModule;
using App.Service.Manager.ReportModule;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementApp.Controllers
{
    public class PurchasemusterController : Controller
    {
        PurchaseReportService _service = new PurchaseReportService();



        // GET: Purchasemuster
        public ActionResult PurchasemusterCreate()
        {
            ViewBag.SupplierId = new SelectList(new List<Supplier>(), "Id", "Name");
           
            return View();
        }


        [HttpPost]
        [Route("Purchasemuster/GetPurchaseReport")]
        public JsonResult GetPurchaseReport(int purchaseId)
        {
            try
            {
                CultureInfo cInfo = new CultureInfo("en-IN");
                ReportViewer viewer = new ReportViewer();

                string path = Path.Combine(Server.MapPath("/Reports"), "PurchseInvoice.rdlc");
                viewer.LocalReport.ReportPath = path;

                var sales = _service.GetPurchaseById(purchaseId);
                var ci = new ReportDataSource("PurchaseMaster", sales);
                viewer.LocalReport.DataSources.Add(ci);

                var salesDetails = _service.GetPurchaseDetailsData(purchaseId);
                var sd = new ReportDataSource("PurchaseDetails", salesDetails);
                viewer.LocalReport.DataSources.Add(sd);


                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension,
                    out streamIds, out warnings);


                string fileName = "PurchseInvoice" + DateTime.Now.ToString("dd_MM_yyyy");
                string outputPath = "~/Reports";
                //var di = new DirectoryInfo(Server.MapPath(outputPath));
                if (System.IO.File.Exists(Server.MapPath(outputPath + fileName + ".pdf")))
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath(outputPath + fileName + ".pdf"));
                    }
                    catch (Exception)
                    {
                        fileName = DateTime.Now.ToString("dd_MM_yyyy");
                    }

                }

                using (var stream = System.IO.File.Create(Path.Combine(Server.MapPath(outputPath), fileName + ".pdf")))
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                var pdfHref = "/Reports/" + fileName + ".pdf";

                return Json(pdfHref, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



    }
}