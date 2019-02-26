using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using MyERP.Web.Controllers;

namespace MyERP.Web.Areas.EInvoice.Controllers
{
    public class FormReleaseController : EntityBaseController<MyERP.DataAccess.EInvFormRelease, MyERP.DataAccess.EntitiesModel>
    {
        public FormReleaseController() : this(new EInvFormReleaseRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public FormReleaseController(IBaseRepository<MyERP.DataAccess.EInvFormRelease, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }
        // GET: EInvoice/FormRelease
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _List(string containerId = "MainCenterPanel")
        {
            return new Ext.Net.MVC.PartialViewResult
            {
                ContainerId = containerId,
                ViewName = "_List",
                WrapByScriptTag = false,
                RenderMode = RenderMode.AddTo,
                ClearContainer = true
            };
        }
    }
}