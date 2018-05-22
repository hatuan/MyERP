using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using Action = System.Action;
using PartialViewResult = Ext.Net.MVC.PartialViewResult;

namespace MyERP.Web.Areas.POS.Controllers
{
    public class IndexController : Controller
    {
        // GET: POS/Index
        public ActionResult Index()
        {
            ViewBag.Title = "Point Of Sales";
            return View();
        }

        public ActionResult AddTab(string containerId)
        {
            var result = new PartialViewResult
            {
                ViewName = "PosInvoiceView",
                ContainerId = containerId,
                RenderMode = RenderMode.AddTo
            };

            this.GetCmp<TabPanel>("POSTabs").SetLastTabAsActive();

            return result;
        }

        public ActionResult PosInvoice()
        {
            return View();
        }
    }
}