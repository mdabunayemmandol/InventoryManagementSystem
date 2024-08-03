using App.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Manager.ReportManager
{
    public class InvoiceDetailsReport
    {
        private readonly InvoiceDetailsReport _detailsReport;
        public InvoiceDetailsReport()
        {
            _detailsReport = new InvoiceDetailsReport();
        }
        public IEnumerable<InvoiceDetails> GetInvoiceDetail(DateTime formDate, DateTime toDate, string inovoiceType)
        {
            var data = _detailsReport.GetInvoiceDetail(formDate, toDate, inovoiceType);
            return data.ToList();
        }

    }
}
