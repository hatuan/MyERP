using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;

namespace MyERP.Web.Controllers
{
    public class ReportController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetReport(string fileName)
        {
            // Create the report object
            StiReport report = new StiReport();

            // Load report
            if (!String.IsNullOrEmpty(fileName))
            {
                report.LoadDocument(Server.MapPath("~/Resources/printReports/") + fileName + ".mdc");
            }
            
            return StiMvcViewer.GetReportResult(report);
        }

        public ActionResult ViewerEvent()
        {
            return StiMvcViewer.ViewerEventResult();
        }

        [HttpPost]
        public ActionResult PrintHtml(string jsonString)
        {
            var report = new Stimulsoft.Report.StiReport();
            report.LoadDocumentFromJson(jsonString);

            return StiMvcReportResponse.PrintAsHtml(report);
        }

        [HttpPost]
        public ActionResult PrintPdf(string jsonString)
        {
            var report = new Stimulsoft.Report.StiReport();
            report.LoadDocumentFromJson(jsonString);

            return StiMvcReportResponse.PrintAsPdf(report);
        }
    }
}