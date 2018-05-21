using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;

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

        public ActionResult AddTab()
        {
            Ext.Net.Panel panel = new Ext.Net.Panel
            {
                Title = "New Tab",
                Closable = true,
                Layout = "Fit",
            };
            X.GetCmp<TabPanel>("POSTabs").Add(panel);
            panel.Render();

            X.GetCmp<TabPanel>("POSTabs").SetLastTabAsActive();

            return this.Direct();
        }
    }
}