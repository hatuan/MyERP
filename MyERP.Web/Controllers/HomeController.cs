using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyERP.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //
        //GET: /Home/About
        public ActionResult About()
        {
            ViewBag.Message = "MyERP is a new Cloud ERP system";

            return View();
        }

        //
        //GET: /Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Please contact to :";

            return View();
        }
    }
}