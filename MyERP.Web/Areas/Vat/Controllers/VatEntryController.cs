using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.Web.Controllers;
using MyERP.Web.Models;
using Newtonsoft.Json;

namespace MyERP.Web.Areas.Vat.Controllers
{
    public class VatEntryController : EntityBaseController<MyERP.DataAccess.VatEntry, MyERP.DataAccess.EntitiesModel>
    {
        public VatEntryController() : this(new VatEntryRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public VatEntryController(IBaseRepository<MyERP.DataAccess.VatEntry, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: Vat/VatEntry
        public ActionResult Index(List<VatEntryEditViewModel> model, string containerId)
        {
            ViewData["CurrencyIsLCY"] = false;

            return new Ext.Net.MVC.PartialViewResult
            {
                RenderMode = RenderMode.AddTo,
                ContainerId = containerId,
                ClearContainer = true,
                Model = new List<VatEntryEditViewModel>(),
                ViewData = ViewData,
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            };
        }

        public ActionResult AddLine(String vatEntriesJSON)
        {
            List<VatEntryEditViewModel> vatEntriesModel = JsonConvert.DeserializeObject<List<VatEntryEditViewModel>>(vatEntriesJSON, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });
            long lineNo = vatEntriesModel.Count >= 1 ? vatEntriesModel.Max(c => c.LineNo) + 1000 : 1000;

            var newItem = new VatEntryEditViewModel()
            {
                Id = null,
                LineNo = lineNo
            };

            Store vatEntryGridStore = X.GetCmp<Store>("VatEntryGridStore");
            vatEntryGridStore.Add(newItem);

            return this.Direct(new { LineNo = lineNo });
        }

        public ActionResult LineEdit(int lineNo, string field, string oldValue, string newValue, string recordData,
            string headerData)
        {
            return this.Direct();
        }

    }
}