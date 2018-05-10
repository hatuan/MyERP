﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.Web.Models;
using PartialViewResult = Ext.Net.MVC.PartialViewResult;

namespace MyERP.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public PartialViewResult ApplicationMenuPartialView(string containerId)
        {
            return new PartialViewResult
            {
                ContainerId = containerId,
                ViewName = "_ApplicationMenu",
                WrapByScriptTag = false,
                RenderMode = RenderMode.Replace 
            };
        }
    }
}