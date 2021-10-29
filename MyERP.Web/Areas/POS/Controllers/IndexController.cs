using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Security;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;
using MyERP.Web.Controllers;
using MyERP.Web.Models;
using MyERP.Web.Others;
using Stimulsoft.Base;
using Stimulsoft.Base.Json;
using Stimulsoft.Base.Json.Linq;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Web;
using JsonConvert = Newtonsoft.Json.JsonConvert;
using JsonSerializerSettings = Newtonsoft.Json.JsonSerializerSettings;
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

        public ActionResult AddHome(string containerId)
        {
            var result = new PartialViewResult
            {
                ViewName = "HomePartialView",
                ContainerId = containerId,
                WrapByScriptTag = false,
                RenderMode = RenderMode.AddTo,
            };

            return result;

        }
        public ActionResult AddTab(string containerId)
        {
            MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
            long clientId = user.ClientId ?? 0;
            long organizationId = user.OrganizationId ?? 0;

            if (clientId == 0 || organizationId == 0)
                return this.Direct(false, Resources.Resources.User_dont_have_Client_or_Organization_Please_set);

            Client client = (new ClientRepository()).Get(User);
            long currencyLcyId = client.CurrencyLcyId ?? 0;
            if(currencyLcyId == 0)
                return this.Direct(false, "ERROR : Please set Client CurrencyLcy first");

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
                Description = "Bán lẻ",
                CurrencyId = currencyLcyId,
                CurrencyFactor = 1,
                SalesPersonId = (long)user.ProviderUserKey,
                InvoiceDiscountPercentage = 0,
                InvoiceDiscountAmount = 0,
                TotalAmount = 0,
                TotalVatAmount = 0,
                TotalLineDiscountAmount = 0,
                TotalPayment = 0,
                Version = 1,
                Status = DefaultDocumentStatusType.Released,
                PosLines = new List<PosLineEditViewModel>()
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

        public ActionResult GetListPOS(StoreRequestParameters parameters)
        {
            var paging = ((PosHeaderRepository)repository).Paging(parameters);

            var data = paging.Data.Select(c => new PosHeaderViewModel()
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                DocumentNo = c.DocumentNo,
                DocumentDate = c.DocumentDate,
                Description = c.Description,
                SellToCustomerCode = c.SellToCustomer.Code,
                SellToCustomerName = c.SellToCustomerName,
                SellToAddress = c.SellToAddress,
                TotalPayment = c.TotalPayment,
                CashOfCustomer = c.CashOfCustomer,
                ChangeReturnToCustomer = c.ChangeReturnToCustomer,
                LocationCode = c.Location.Code,
                SalesPersonCode = "",
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Status = c.Status,
                Version = c.Version
            }).ToList();

            Session.Add("StoreListPOSList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }

        public ActionResult AddItemToDetails(long? lookupItemId, String viewBagID, String posLines, long sellToCustomerId)
        {
            MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
            long clientId = user.ClientId ?? 0;
            long organizationId = user.OrganizationId ?? 0;

            if (clientId == 0 || organizationId == 0)
                return this.Direct(false, Resources.Resources.User_dont_have_Client_or_Organization_Please_set);

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
                VatIdentifierId = null,
                VatPercentage = 0,
                VatAmount = 0,
                LineDiscountPercentage = 0,
                LineDiscountAmount = 0,
                InvoiceDiscountAmount = 0,
                UomId = item.BaseUomId,
                UomDescription = item.BaseUom.Description,
                UnitPriceLCY = unitPrice,
                AmountLCY = amount,
                VatAmountLCY = 0,
                LineDiscountAmountLCY = 0,
                InvoiceDiscountAmountLCY = 0,
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
                return this.Direct(false, Resources.Resources.User_dont_have_Client_or_Organization_Please_set);

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
                        var getPriceDTO = salesPriceRepository.GetPriceOfItem(organizationId, sellToCustomerId, DateTime.Today, posLineEditViewModel.ItemId, posLineEditViewModel.UomId, posLineEditViewModel.Quantity);
                        Decimal unitPrice = getPriceDTO.UnitPrice;

                        if (unitPrice == 0)
                        {
                            return this.Direct(false, "ERR : Item unit price not found, can't be selling");
                        }

                        var amount = Round.RoundAmountLCY(posLineEditViewModel.Quantity * unitPrice);

                        record.Set("UnitPrice", unitPrice);
                        record.Set("Amount", amount);
                        record.Set("VatAmount", 0);
                        record.Set("LineDiscountAmount", 0);
                        record.Set("InvoiceDiscountAmount", 0);
                        record.Set("UnitPriceLCY", unitPrice);
                        record.Set("AmountLCY", amount);
                        record.Set("VatAmountLCY", 0);
                        record.Set("LineDiscountAmountLCY", 0);
                        record.Set("InvoiceDiscountAmountLCY", 0);
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
                        var getPriceDTO = salesPriceRepository.GetPriceOfItem(organizationId, sellToCustomerId, DateTime.Today, posLineEditViewModel.ItemId, posLineEditViewModel.UomId, posLineEditViewModel.Quantity);
                        Decimal unitPrice = getPriceDTO.UnitPrice;

                        if (unitPrice == 0)
                        {
                            return this.Direct(false, "ERR : Item unit price not found, can't be selling");
                        }

                        var amount = Round.RoundAmountLCY(posLineEditViewModel.Quantity * unitPrice);

                        record.Set("UnitPrice", unitPrice);
                        record.Set("Amount", amount);
                        record.Set("VatAmount", 0);
                        record.Set("LineDiscountAmount", 0);
                        record.Set("InvoiceDiscountAmount", 0);
                        record.Set("UnitPriceLCY", unitPrice);
                        record.Set("AmountLCY", amount);
                        record.Set("VatAmountLCY", 0);
                        record.Set("LineDiscountAmountLCY", 0);
                        record.Set("InvoiceDiscountAmountLCY", 0);
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
                return this.Direct(false, Resources.Resources.User_dont_have_Client_or_Organization_Please_set);

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
                    ItemId = posLine.ItemId,
                    UomId = posLine.UomId,
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
                record.Set("VatAmount", 0);
                record.Set("LineDiscountAmount", 0);
                record.Set("InvoiceDiscountAmountLCY", 0);
                record.Set("UnitPriceLCY", unitPrice);
                record.Set("AmountLCY", amount);
                record.Set("VatAmountLCY", 0);
                record.Set("LineDiscountAmountLCY", 0);
                record.Set("InvoiceDiscountAmountLCY", 0);

                record.Commit();
            }

            return this.Direct();
        }

        public ActionResult Print(String viewBagID, String posLinesJSON, PosHeaderEditViewModel headerModel)
        {
            List<PosLineEditViewModel> posLinesModel = JsonConvert.DeserializeObject<List<PosLineEditViewModel>>(posLinesJSON, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });

            //Save
            ModelState.Clear();
            headerModel.PosLines = posLinesModel;
            TryValidateModel(headerModel);
            if (!ModelState.IsValid)
            {
                return this.Direct(false, ModelState.StringifyModelErrors());
            }

            MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
            long clientId = user.ClientId ?? 0;
            long organizationId = user.OrganizationId ?? 0;

            if (clientId == 0 || organizationId == 0)
            {
                return this.Direct(false, Resources.Resources.User_dont_have_Client_or_Organization_Please_set);
            }

            headerModel.DocumentDate = headerModel.DocumentDate + DateTime.Now.TimeOfDay;
            headerModel.DocumentNo =
                (new NoSequenceRepository()).GetNextNo(headerModel.DocSequenceId, headerModel.DocumentDate);
            headerModel.Version = 1;

            List<DataAccess.PosLine> posLines = posLinesModel
                .Select(c => new DataAccess.PosLine()
                {
                    ClientId = clientId,
                    OrganizationId = organizationId,
                    LineNo = c.LineNo,
                    ItemId = c.ItemId,
                    Description = c.Description,
                    LocationId = headerModel.LocationId,
                    UomId = c.UomId,
                    UomDescription = c.UomDescription,
                    UnitPrice = c.UnitPrice,
                    Quantity = c.Quantity,
                    QtyPerUom = c.QtyPerUom,
                    QuantityBase = c.QuantityBase,
                    Amount = c.Amount,
                    VatIdentifierId = c.VatIdentifierId,
                    VatPercentage = c.VatPercentage,
                    VatAmount = c.VatAmount,
                    DiscountId = null,
                    LineDiscountPercentage = c.LineDiscountPercentage,
                    LineDiscountAmount = c.LineDiscountAmount,
                    InvoiceDiscountAmount = c.InvoiceDiscountAmount, //TODO : recalculate InvoiceDiscountAmount from header.InvoiceDiscountAmount
                    UnitPriceLCY = c.UnitPriceLCY,
                    AmountLCY = c.AmountLCY,
                    VatAmountLCY = c.VatAmount,
                    LineDiscountAmountLCY = c.LineDiscountAmount,
                    InvoiceDiscountAmountLCY = c.InvoiceDiscountAmount, //TODO : recalculate InvoiceDiscountAmount from header.InvoiceDiscountAmount
                }).ToList();

            PosHeader newPosHeader = new PosHeader()
            {
                ClientId = clientId,
                OrganizationId = organizationId,
                DocSequenceId = headerModel.DocSequenceId,
                DocumentNo = headerModel.DocumentNo,
                DocumentDate = headerModel.DocumentDate,
                SellToCustomerId = headerModel.SellToCustomerId,
                SellToCustomerName = headerModel.SellToCustomerName,
                SellToAddress = headerModel.SellToAddress,
                SellToContactId = null,
                SellToContactName = "",
                BillToCustomerId = headerModel.SellToCustomerId,
                BillToName = headerModel.SellToCustomerName,
                BillToAddress = headerModel.SellToAddress,
                BillToContactId = null,
                BillToContactName = "",
                BillToVatCode = "",
                BillToVatNote = "",
                ShipToName = "",
                ShipToAddress = "",
                ShipToContactName = "",
                CurrencyId = headerModel.CurrencyId,
                CurrencyFactor = headerModel.CurrencyFactor,
                Description = headerModel.Description,
                LocationId = headerModel.LocationId,
                SalesPersonId = headerModel.SalesPersonId,
                TotalAmount = headerModel.TotalAmount,
                TotalAmountLCY = headerModel.TotalAmount,
                TotalVatAmount = headerModel.TotalVatAmount,
                TotalVatAmountLCY = headerModel.TotalVatAmount,
                TotalLineDiscountAmount = headerModel.TotalLineDiscountAmount,
                TotalLineDiscountAmountLCY = headerModel.TotalLineDiscountAmount,
                InvoiceDiscountPercentage = headerModel.InvoiceDiscountPercentage,
                InvoiceDiscountAmount = headerModel.InvoiceDiscountAmount,
                InvoiceDiscountAmountLCY = headerModel.InvoiceDiscountAmount,
                TotalPayment = headerModel.TotalPayment,
                TotalPaymentLCY = headerModel.TotalPayment,
                CashOfCustomer = headerModel.CashOfCustomer,
                ChangeReturnToCustomer = headerModel.ChangeReturnToCustomer,
                Status = headerModel.Status,
                Version = headerModel.Version,
                RecModifiedAt = DateTime.Now,
                RecCreatedBy = (long)user.ProviderUserKey,
                RecCreatedAt = DateTime.Now,
                RecModifiedBy = (long)user.ProviderUserKey
            };
            newPosHeader.PosLines = posLines;

            try
            {
                newPosHeader = this.repository.AddNew(newPosHeader);
            }
            catch (DbEntityValidationException ex)
            {
                return this.Direct(false, ex.DbEntityValidationExceptionToString());
            }
            catch (Exception ex)
            {
                return this.Direct(false, ex.Message);
            }

            //Print
            StiReport report = new StiReport();
            report.Load(Server.MapPath("~/Resources/Reports/salespos_001.mrt"));

            Client client = (new ClientRepository()).Get(User);
            var data = JObject.FromObject(new {PosHeader = headerModel, PosLines = headerModel.PosLines, Client = client });

            //data.PosHeader = JToken.FromObject(headerModel);
            //data.PosLines = JToken.FromObject(posLines);

            //dataSet.RegData("data", data);

            report.Dictionary.Databases.Clear();
            var ds = StiJsonToDataSetConverter.GetDataSet(data);
            report.RegData("data", "", ds);
            report.Dictionary.Synchronize();
            //========================
            report.Render();
            var fileName = $"salespos_{newPosHeader.Id}_{User.Identity.Name}_{DateTime.Now:yyyyMMddhhmmss}";
            report.ExportDocument(StiExportFormat.Pdf, Server.MapPath("~/Resources/printReports/") + fileName + ".pdf");

            var settings = new Stimulsoft.Report.Export.StiHtmlExportSettings();
            var service = new Stimulsoft.Report.Export.StiHtmlExportService();
            var stream = new System.IO.MemoryStream();
            service.ExportTo(report, stream, settings);
            stream.Seek(0, SeekOrigin.Begin);
            var streamReader = new StreamReader(stream);
            var htmlString = streamReader.ReadToEnd();

            return this.Direct(new { report = htmlString, id = newPosHeader.Id });
            
            /*
            var jsonString = report.SaveToJsonString();
            Window win = new Window
            {
                ID = "SalesPosReportWindows1",
                Icon = Ext.Net.Icon.PageWhiteAcrobat,
                Height = 600,
                Width = 800,
                BodyPadding = 2,
                Frame = true,
                Modal = true,
                Layout = "Fit",
                CloseAction = CloseAction.Destroy,
                Items =
                {
                     new Panel
                     {
                         Loader = new ComponentLoader()
                         {
                             Url = Url.Action("PrintHtml", "Report"),
                             Params =
                             {
                                 new Parameter("jsonString", jsonString, ParameterMode.Value)
                             },
                             Mode = LoadMode.Frame
                         }
                     }   
                }
            };

            win.Render(RenderMode.Auto);
            return this.Direct();
            */
        }
    }
}