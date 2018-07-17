using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;

namespace MyERP.Web.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult PrintHtml(string jsonString)
        {
            var report = new Stimulsoft.Report.StiReport();
            report.Load(jsonString);

            return StiMvcReportResponse.PrintAsHtml(report);
        }

        public ActionResult PrintPdf(string jsonString)
        {
            var report = new Stimulsoft.Report.StiReport();
            report.Load(jsonString);

            return StiMvcReportResponse.PrintAsPdf(report);
        }
    }
}