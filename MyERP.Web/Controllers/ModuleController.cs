using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyERP.Web.Controllers
{
    public class ModuleController : BaseController
    {
        // GET: Module
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        //
        //GET: Module/Financial
        public ActionResult Financial()
        {
            return View();
        }

        //
        //GET: Module/Sale
        public ActionResult Sale()
        {
            return View();
        }

        //
        //GET: Module/Purchase
        public ActionResult Purchase()
        {
            return View();
        }

        //
        //GET: Module/Contact
        public ActionResult Contact()
        {
            return View();
        }

        //
        //GET: Module/Manufacturing
        public ActionResult Manufacturing()
        {
            return View();
        }

        //
        //GET: Module/Warehouse
        public ActionResult Warehouse()
        {
            return View();
        }


        //
        //GET: Module/Master
        public ActionResult Master()
        {
            return View();
        }
    }
}