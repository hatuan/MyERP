using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.Web.Models;
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
            var model = new PosHeaderEditViewModel()
            {
                PosLineEditViewModels = new List<PosLineEditViewModel>()
            };

            model.PosLineEditViewModels.Add(new PosLineEditViewModel() { ItemId = 6, Description = "Nước khoáng 19 lít/bình", LineNo = 1, Quantity = 1, UnitPrice = 1, Amount = 1, UomId = 13, UomDescription = "", Id = 1 });

            var result = new PartialViewResult
            {
                ViewName = "PosInvoicePartialView",
                ContainerId = containerId,
                RenderMode = RenderMode.AddTo,
                ViewData = ViewData,
                Model = model
            };
            this.GetCmp<TabPanel>("POSTabs").SetLastTabAsActive();
            result.ViewBag.ID = DateTime.Now.Ticks.ToString();

            return result;
        }

        public ActionResult PosInvoice()
        {
            return View();
        }

        public ActionResult AddItemToDetails(String lookupItemId, String viewBagID, int posLinesCount)
        {
            var itemRepository = new ItemRepository();
            long _lookupItemId = Int64.Parse(lookupItemId);
            var item = itemRepository.GetBy(c => c.Id == _lookupItemId);
            Store posLineStore = X.GetCmp<Store>("posLineStore" + viewBagID);
            int lineNo = posLinesCount <= 0 ? 1 : posLinesCount + 1;

            var newItem =  new PosLineEditViewModel() { ItemId = item.Id, Description = item.Description, LineNo = lineNo, Quantity = 1, UnitPrice = 1, Amount = 1, UomId = 1, UomDescription = "TEST", Id = 2};

            DirectResult result = new DirectResult();
            result.Success = true;
            result.Result = newItem;

            return result;
        }
    }
}