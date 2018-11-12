using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.Web.Models;

namespace MyERP.Web.Areas.Vat.Controllers
{
    public class VatEntryController : Controller
    {
        // GET: Vat/VatEntry
        public ActionResult Index(VatEntryEditViewModel model)
        {
            return new Ext.Net.MVC.PartialViewResult
            {
                RenderMode = RenderMode.Replace,
                Model = model,
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            };
        }

        public ActionResult LineEdit(int lineNo, string field, string oldValue, string newValue, string recordData,
            string headerData)
        {
            return this.Direct();
        }
    }
}