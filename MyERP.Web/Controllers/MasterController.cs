using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyERP.Web.Controllers
{
    public class MasterController : BaseController
    {
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }
    }
}