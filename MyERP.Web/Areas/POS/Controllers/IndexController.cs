using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.Web.Models;
using Newtonsoft.Json;
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
                DocumentDate = DateTime.Now,
                PosLineEditViewModels = new List<PosLineEditViewModel>()
            };

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

        public ActionResult AddItemToDetails(long? lookupItemId, String viewBagID, String posLines)
        {
            if (lookupItemId == null || lookupItemId <= 0)
                return this.Direct(false, "ERR : Lookup item is empty");

            var itemRepository = new ItemRepository();
            var item = itemRepository.Get(c => c.Id == lookupItemId, new[] {"BaseUom"}).SingleOrDefault();

            List<PosLineEditViewModel> posLinesModel = JsonConvert.DeserializeObject<List<PosLineEditViewModel>>(posLines);
            long lineNo = posLinesModel.Count >= 1 ? posLinesModel.Max(c => c.LineNo) + 1 : 1;

            var itemUomRepository = new ItemUomRepository();
            var listUomOfItem = itemUomRepository.Get(c => c.ItemId == item.Id, new string[] {"Uom"});

            var itemUoms = listUomOfItem.Select(c => new ItemUomLookUpViewModel
            {
                Code = c.Uom.Code,
                UomId = c.UomId,
                Description = c.Uom.Description,
                QtyPerUom = c.QtyPerUom
            }).ToList();

            var newItem = new PosLineEditViewModel()
            {
                ItemId = item.Id,
                Description = item.Description,
                LineNo = lineNo,
                Quantity = 1,
                UnitPrice = 1,
                Amount = 1,
                UomId = item.BaseUomId,
                UomDescription = item.BaseUom.Description,
                ItemUoms = itemUoms
            };

            Store posLineStore = X.GetCmp<Store>("PosLineStore" + viewBagID);
            posLineStore.Add(newItem);
            posLineStore.CommitChanges();

            return this.Direct();
        }

        public ActionResult LineEdit(int lineNo, string field, string oldValue, string newValue, string viewBagId,
            string recordData)
        {
            PosLineEditViewModel posLineEditViewModel = JSON.Deserialize<PosLineEditViewModel>(recordData);

            ModelProxy record = X.GetCmp<Store>("PosLineStore" + viewBagId).GetById(lineNo);

            switch (field)
            {
                case "Quantity":
                    if (String.Compare(oldValue, newValue, StringComparison.InvariantCultureIgnoreCase) != 0)
                        record.Set("Amount",
                            Math.Round(posLineEditViewModel.Quantity * posLineEditViewModel.UnitPrice,
                                MidpointRounding.AwayFromZero));
                    break;
                case "UomId":
                    if (String.Compare(oldValue, newValue, StringComparison.CurrentCultureIgnoreCase) != 0)
                    {
                        var uomRepository = new UomRepository();
                        var _uomId = Convert.ToInt64(newValue);
                        var uom = uomRepository.Get(c => c.Id == _uomId).FirstOrDefault();
                        record.Set("UomDescription", uom != null ? uom.Description : "");
                    }

                    break;
            }

            record.Commit();
            return this.Direct();
        }

        public ActionResult ChangeBusinessPartner(String viewBagID, string selectedData)
        {
            BusinessPartnerLookupViewModel selectedPartner = JsonConvert.DeserializeObject<BusinessPartnerLookupViewModel>(selectedData);
            this.GetCmp<TextField>("sellToCustomerName" + viewBagID).Value = selectedPartner.Description;
            this.GetCmp<TextField>("sellToAddress" + viewBagID).Value = selectedPartner.Address;
            return this.Direct();
        }

        public ActionResult Print(String viewBagID, String posLines, PosHeaderEditViewModel headerModel)
        {
            List<PosLineEditViewModel> posLinesModel = JsonConvert.DeserializeObject<List<PosLineEditViewModel>>(posLines);
            return this.Direct();
        }
    }
}