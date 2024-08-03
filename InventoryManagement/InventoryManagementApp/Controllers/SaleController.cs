using App.Core.Model.SetupModule;
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
    public class SaleController : Controller
    {
        private readonly SalesReportService salesReportService = new SalesReportService();

        // GET: Sale
        public ActionResult SaleCreate()
        {
            ViewBag.CustomerId = new SelectList(new List<Customer>(), "Id", "Name");
            return View();
        }


        [HttpPost]
        [Route("Sale/GetSalesReport")]
        public JsonResult GetSalesReport(int salesId)
        {
            try
            {
                CultureInfo cInfo = new CultureInfo("en-IN");
                ReportViewer viewer = new ReportViewer();

                string path = Path.Combine(Server.MapPath("/Reports"), "SalesInvoiceReport.rdlc");
                viewer.LocalReport.ReportPath = path;

                var sales = salesReportService.GetSaleById(salesId);
                var ci = new ReportDataSource("SalesDataset", sales);
                viewer.LocalReport.DataSources.Add(ci);

                var salesDetails = salesReportService.GetSaleDetialsById(salesId);
                var sd = new ReportDataSource("SalesDetails", salesDetails);
                viewer.LocalReport.DataSources.Add(sd);


                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension,
                    out streamIds, out warnings);


                string fileName = "SalesInvoice_" + DateTime.Now.ToString("dd_MM_yyyy");
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