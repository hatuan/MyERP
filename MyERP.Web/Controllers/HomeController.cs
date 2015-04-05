using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyERP.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
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
            ViewBag.Message = "MyERP is a new Cloud ERP system for small to medium company using HTML, CSS and JavaScript";

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