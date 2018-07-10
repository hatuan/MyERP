using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.DataAccess.Enum;
using MyERP.Web.Controllers;
using MyERP.Web.Models;
using MyERP.Web.Others;
using Newtonsoft.Json;
using PartialViewResult = Ext.Net.MVC.PartialViewResult;

namespace MyERP.Web.Areas.POS.Controllers
{
    public class IndexController : EntityBaseController<MyERP.DataAccess.PosHeader, MyERP.DataAccess.EntitiesModel>
    {
        public IndexController() : this(new PosHeaderRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public IndexController(IBaseRepository<MyERP.DataAccess.PosHeader, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: POS/Index
        public ActionResult Index()
        {
            ViewBag.Title = "Point Of Sales";
            return View();
        }

        public ActionResult AddTab(string containerId)
        {
            MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
            long clientId = user.ClientId ?? 0;
            long organizationId = user.OrganizationId ?? 0;

            if (clientId == 0 || organizationId == 0)
                return this.Direct(false, "User don't have Client or Organization. Please set");

            var optionRepository = new OptionRepository();

            long oneTimeBusinessPartnerId =
                optionRepository.OptionParameter(organizationId, OptionParameter.OneTimeBusinessPartnerId);
            if (oneTimeBusinessPartnerId == 0)
                return this.Direct(false, "ERROR : Please set Option OneTimeBusinessPartner first");

            long salesPosLocationId = optionRepository.OptionParameter(organizationId, OptionParameter.SalesPosLocationId);
            if (salesPosLocationId == 0)
                return this.Direct(false, "ERROR : Please set Option SalesPosLocation first");

            long salesPosSequenceId = optionRepository.OptionParameter(organizationId, OptionParameter.SalesPosSequenceId);
            if (salesPosSequenceId == 0)
                return this.Direct(false, "ERROR : Please set Option SalesPosSequence first");

            var businessPartnerRepository = new BusinessPartnerRepository();
            var oneTimeBusinessPartner = businessPartnerRepository.Get(x => x.Id == oneTimeBusinessPartnerId).FirstOrDefault();
            if(oneTimeBusinessPartner == null)
                return this.Direct(false, "ERROR : OneTimeBusinessPartner not found!! Please check");

            var model = new PosHeaderEditViewModel()
            {
                DocumentDate = DateTime.Now,
                DocSequenceId = salesPosSequenceId,
                LocationId = salesPosLocationId,
                SellToCustomerId = oneTimeBusinessPartnerId,
                SellToCustomerName = oneTimeBusinessPartner.Description,
                SellToAddress = oneTimeBusinessPartner.Address,

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

        public ActionResult AddItemToDetails(long? lookupItemId, String viewBagID, String posLines, long sellToCustomerId)
        {
            MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
            long clientId = user.ClientId ?? 0;
            long organizationId = user.OrganizationId ?? 0;

            if (clientId == 0 || organizationId == 0)
                return this.Direct(false, "User don't have Client or Organization. Please set");

            if (lookupItemId == null || lookupItemId <= 0)
                return this.Direct(false, "ERR : Lookup item is empty");

            var itemRepository = new ItemRepository();
            var item = itemRepository.Get(c => c.Id == lookupItemId, new[] {"BaseUom"}).SingleOrDefault();
            if (item == null)
                return this.Direct(false, "ERR : Item not found");

            List<PosLineEditViewModel> posLinesModel = JsonConvert.DeserializeObject<List<PosLineEditViewModel>>(posLines, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });

            PosLineEditViewModel foundLine = (from posLine in posLinesModel
                where posLine.ItemId == item.Id && posLine.UomId == item.BaseUomId
                select posLine).SingleOrDefault();

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

            Decimal quantity = foundLine == null ? 1 : 1 + foundLine.Quantity;
            var salesPriceRepository = new SalesPriceRepository();
            var getPriceDTO = salesPriceRepository.GetPriceOfItem(organizationId, sellToCustomerId, DateTime.Today, lookupItemId??0, item.BaseUomId, quantity);
            Decimal unitPrice = getPriceDTO.UnitPrice;

            if (unitPrice == 0)
            {
                return this.Direct(false, "ERR : Item unit price not found, can't be selling");
            }

            var amount = Round.RoundAmountLCY(quantity * unitPrice);

            var newItem = new PosLineEditViewModel()
            {
                ItemId = item.Id,
                Description = item.Description,
                LineNo = lineNo,
                Quantity = quantity,
                UnitPrice = unitPrice,
                Amount = amount,
                UomId = item.BaseUomId,
                UomDescription = item.BaseUom.Description,
                UnitPriceLCY = unitPrice,
                AmountLCY = amount,
                QtyPerUom = 1,
                QuantityBase = quantity,
                Item = item,
                ItemUoms = itemUoms
            };

            Store posLineStore = X.GetCmp<Store>("PosLineStore" + viewBagID);
            if (foundLine != null)
            {
                var posLine = posLineStore.GetById(foundLine.LineNo);
                posLineStore.Remove(posLine);
            }

            posLineStore.Add(newItem);
            posLineStore.CommitChanges();

            return this.Direct();
        }

        public ActionResult LineEdit(int lineNo, string field, string oldValue, string newValue, string viewBagId, string recordData, long sellToCustomerId)
        {
            MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
            long clientId = user.ClientId ?? 0;
            long organizationId = user.OrganizationId ?? 0;

            if (clientId == 0 || organizationId == 0)
                return this.Direct(false, "User don't have Client or Organization. Please set");

            PosLineEditViewModel posLineEditViewModel = JSON.Deserialize<PosLineEditViewModel>(recordData, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });
            ItemUomLookUpViewModel itemUom = (from x in posLineEditViewModel.ItemUoms
                where x.UomId == posLineEditViewModel.UomId
                select x).First();

            ModelProxy record = X.GetCmp<Store>("PosLineStore" + viewBagId).GetById(lineNo);

            switch (field)
            {
                case "Quantity":
                    if (String.Compare(oldValue, newValue, StringComparison.InvariantCultureIgnoreCase) != 0)
                    {
                        record.Set("QtyPerUom", itemUom.QtyPerUom);
                        record.Set("QuantityBase", itemUom.QtyPerUom * posLineEditViewModel.Quantity);

                        var salesPriceRepository = new SalesPriceRepository();
                        var getPriceDTO = salesPriceRepository.GetPriceOfItem(organizationId, sellToCustomerId, DateTime.Today, posLineEditViewModel.ItemId??0, posLineEditViewModel.UomId??0, posLineEditViewModel.Quantity);
                        Decimal unitPrice = getPriceDTO.UnitPrice;

                        if (unitPrice == 0)
                        {
                            return this.Direct(false, "ERR : Item unit price not found, can't be selling");
                        }

                        var amount = Round.RoundAmountLCY(posLineEditViewModel.Quantity * unitPrice);

                        record.Set("UnitPrice", unitPrice);
                        record.Set("Amount", amount);
                        record.Set("UnitPriceLCY", unitPrice);
                        record.Set("AmountLCY", amount);
                    }

                    break;
                case "UomId":
                    if (String.Compare(oldValue, newValue, StringComparison.CurrentCultureIgnoreCase) != 0)
                    {
                        var uomRepository = new UomRepository();
                        var _uomId = Convert.ToInt64(newValue);
                        var uom = uomRepository.Get(c => c.Id == _uomId).FirstOrDefault();
                        record.Set("UomDescription", uom != null ? uom.Description : "");
                        record.Set("QtyPerUom", itemUom.QtyPerUom);
                        record.Set("QuantityBase", itemUom.QtyPerUom * posLineEditViewModel.Quantity);

                        var salesPriceRepository = new SalesPriceRepository();
                        var getPriceDTO = salesPriceRepository.GetPriceOfItem(organizationId, sellToCustomerId, DateTime.Today, posLineEditViewModel.ItemId ?? 0, posLineEditViewModel.UomId ?? 0, posLineEditViewModel.Quantity);
                        Decimal unitPrice = getPriceDTO.UnitPrice;

                        if (unitPrice == 0)
                        {
                            return this.Direct(false, "ERR : Item unit price not found, can't be selling");
                        }

                        var amount = Round.RoundAmountLCY(posLineEditViewModel.Quantity * unitPrice);

                        record.Set("UnitPrice", unitPrice);
                        record.Set("Amount", amount);
                        record.Set("UnitPriceLCY", unitPrice);
                        record.Set("AmountLCY", amount);
                    }

                    break;
            }

            record.Commit();

            return this.Direct();
        }

        public ActionResult ChangeBusinessPartner(String viewBagID, string selectedData, String posLines)
        {
            BusinessPartnerLookupViewModel selectedPartner = JsonConvert.DeserializeObject<BusinessPartnerLookupViewModel>(selectedData, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });
            this.GetCmp<TextField>("sellToCustomerName" + viewBagID).Value = selectedPartner.Description;
            this.GetCmp<TextField>("sellToAddress" + viewBagID).Value = selectedPartner.Address;

            MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
            long clientId = user.ClientId ?? 0;
            long organizationId = user.OrganizationId ?? 0;

            if (clientId == 0 || organizationId == 0)
                return this.Direct(false, "User don't have Client or Organization. Please set");

            List<PosLineEditViewModel> posLinesModel = JsonConvert.DeserializeObject<List<PosLineEditViewModel>>(posLines, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });
            
            List<GetPriceDTO> itemListRequest = (from posLine in posLinesModel
                select new GetPriceDTO
                {
                    Id = posLine.LineNo,
                    OrgId = organizationId,
                    BusPartId = selectedPartner.Id,
                    WorkingDate = DateTime.Today,
                    ItemId = posLine.ItemId??0,
                    UomId = posLine.UomId??0,
                    Qty = posLine.Quantity
                }).ToList();

            var salesPriceRepository = new SalesPriceRepository();
            itemListRequest = salesPriceRepository.GetPriceOfItemList(organizationId, selectedPartner.Id, DateTime.Today, itemListRequest);
            Store posLineStore = X.GetCmp<Store>("PosLineStore" + viewBagID);

            var getPriceDTONotFound =
                (from getPriceDTO in itemListRequest where getPriceDTO.UnitPrice <= 0 select getPriceDTO).FirstOrDefault();

            if (getPriceDTONotFound != null)
            {
                PosLineEditViewModel posLineEditViewModel = (from posLine in posLinesModel where posLine.LineNo == getPriceDTONotFound.Id select posLine).First();
                return this.Direct(false, $"ERR : Item { posLineEditViewModel.Description } unit price not found, can't be selling");
            }

            foreach (GetPriceDTO getPriceDTO in itemListRequest)
            {
                PosLineEditViewModel posLineEditViewModel = (from posLine in posLinesModel where posLine.LineNo == getPriceDTO.Id select posLine).First();

                ModelProxy record = posLineStore.GetById(getPriceDTO.Id);
                Decimal unitPrice = getPriceDTO.UnitPrice;

                if (unitPrice == 0)
                {
                    return this.Direct(false, "ERR : Item unit price not found, can't be selling");
                }

                var amount = Round.RoundAmountLCY(posLineEditViewModel.Quantity * unitPrice);

                record.Set("UnitPrice", unitPrice);
                record.Set("Amount", amount);
                record.Set("UnitPriceLCY", unitPrice);
                record.Set("AmountLCY", amount);

                record.Commit();
            }

            return this.Direct();
        }

        public ActionResult Print(String viewBagID, String posLines, PosHeaderEditViewModel headerModel)
        {
            List<PosLineEditViewModel> posLinesModel = JsonConvert.DeserializeObject<List<PosLineEditViewModel>>(posLines, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });


            return this.Direct();
        }
    }
}