using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;
using MyERP.Web.Controllers;
using MyERP.Web.Models;
using MyERP.Web.Others;
using Newtonsoft.Json;
using Stimulsoft.Base;
using Stimulsoft.Base.Json.Linq;
using Stimulsoft.Report;
using WebGrease.Css.Extensions;

namespace MyERP.Web.Areas.Purchase.Controllers
{
    public class PurchaseInvoiceController : EntityBaseController<MyERP.DataAccess.PurchaseInvoiceHeader, MyERP.DataAccess.EntitiesModel>
    {
        public PurchaseInvoiceController() : this(new PurchaseInvoiceHeaderRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public PurchaseInvoiceController(IBaseRepository<MyERP.DataAccess.PurchaseInvoiceHeader, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: Cash/CashPayment
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

        public ActionResult GetData(StoreRequestParameters parameters)
        {
            var paging = ((PurchaseInvoiceHeaderRepository)repository).Paging(parameters, DocumentType.PurchaseInvoice);

            var data = paging.Data.Select(c => new PurchaseInvoiceHeaderViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                DocumentNo = c.DocumentNo,
                DocumentDate = c.DocumentDate,
                AccountPayableCode = c.AccountPayable.Code,
                Description = c.Description,
                BuyFromVendorCode = c.BuyFromVendor.Code,
                BuyFromVendorName = c.BuyFromVendorName,
                BuyFromAddress = c.BuyFromAddress,
                BuyFromContactName = c.BuyFromContactName,
                PayToVendorCode = c.PayToVendor.Code,
                PayToName = c.PayToName,
                TotalAmount = c.TotalAmount,
                TotalVatAmount = c.TotalVatAmount,
                TotalPayment = c.TotalPayment,
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Status = (PurchaseInvoiceDocumentStatusType)c.Status,
                Version = c.Version
            }).ToList();

            Session.Add("StorePurchaseInvoiceList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }

        [HttpGet]
        public ActionResult _Maintenance(string id = null)
        {
            MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
            long clientId = user.ClientId ?? 0;
            long organizationId = user.OrganizationId ?? 0;

            if (clientId == 0 || organizationId == 0)
                return this.Direct(false, Resources.Resources.User_dont_have_Client_or_Organization_Please_set);

            Client client = new ClientRepository().Get(User);
            long currencyLcyId = client.CurrencyLcyId ?? 0;
            if (currencyLcyId == 0)
                return this.Direct(false, "ERROR : Please set Client CurrencyLcy first");

            var optionRepository = new OptionRepository();
            long purchaseInvoiceSequenceId = optionRepository.OptionParameter(organizationId, OptionParameter.PurchInvoiceSeqId);
            if (purchaseInvoiceSequenceId == 0)
                return this.Direct(false, "ERROR : Please set Option Purchase Invoice first");

            ViewData["CurrencyLCYId"] = currencyLcyId;
            CurrencyRepository currencyRepository = new CurrencyRepository();
            ViewData["Currency"] = currencyRepository.Get(filter: c => c.Id == currencyLcyId, includePaths: new string[] { "Organization" })
                .Select(x => new CurrencyLookupViewModel()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Description = x.Description,
                    OrganizationCode = x.Organization.Code,
                    Status = (DefaultStatusType)x.Status
                }).ToList();

            PreferenceViewModel preference = (PreferenceViewModel)Session["Preference"];
            var model = new PurchaseInvoiceHeaderEditViewModel()
            {
                Id = null,
                DocumentType = DocumentType.PurchaseInvoice,
                DocSubType = (byte)PurchaseInvoiceDocumentSubType.PurchaseInvoice,
                DocSequenceId = purchaseInvoiceSequenceId,
                DocumentDate = preference.WorkingDate,
                PostingDate = preference.WorkingDate,
                CurrencyId = currencyLcyId,
                CurrencyFactor = 1,
                PurchaseInvoiceLines = new List<PurchaseInvoiceLineEditViewModel>(),
                Status = PurchaseInvoiceDocumentStatusType.Draft
            };

            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id, new string[] { "AccountPayable", "BuyFromVendor", "PayToVendor", "Currency", "PurchaseInvoiceLines", "PurchaseInvoiceLines.Item", "PurchaseInvoiceLines.Location", "PurchaseInvoiceLines.Uom", "PurchaseInvoiceLines.Vat" }).SingleOrDefault();
                if (entity == null)
                {
                    return this.Direct(false, "Cash Header has been changed or deleted! Please check");
                }

                List<PurchaseInvoiceLineEditViewModel> purchaseInvoiceLines = (from purchaseInvoiceLine in entity.PurchaseInvoiceLines
                                                         select new PurchaseInvoiceLineEditViewModel()
                                                         {
                                                             Id = purchaseInvoiceLine.Id,
                                                             LineNo = purchaseInvoiceLine.LineNo,
                                                             Type = purchaseInvoiceLine.Type,
                                                             ItemId = purchaseInvoiceLine.ItemId,
                                                             Item = purchaseInvoiceLine.Item == null ? null : new ExtNetComboBoxModel()
                                                             {
                                                                 Id = purchaseInvoiceLine.Item.Id,
                                                                 Code = purchaseInvoiceLine.Item.Code,
                                                                 Description = purchaseInvoiceLine.Item.Description
                                                             },
                                                             Description = purchaseInvoiceLine.Description,
                                                             UomId = purchaseInvoiceLine.UomId,
                                                             Uom = purchaseInvoiceLine.Uom == null ? null : new ExtNetComboBoxModel()
                                                             {
                                                                 Id = purchaseInvoiceLine.Uom.Id,
                                                                 Code = purchaseInvoiceLine.Uom.Code,
                                                                 Description = purchaseInvoiceLine.Uom.Description
                                                             },
                                                             UomDescription = purchaseInvoiceLine.Uom == null ? null : purchaseInvoiceLine.Uom.Description,
                                                             LocationId = purchaseInvoiceLine.LocationId,
                                                             Location = purchaseInvoiceLine.Location == null ? null : new ExtNetComboBoxModel()
                                                             {
                                                                 Id = purchaseInvoiceLine.Location.Id,
                                                                 Code = purchaseInvoiceLine.Location.Code,
                                                                 Description = purchaseInvoiceLine.Location.Description
                                                             },
                                                             Quantity = purchaseInvoiceLine.Quantity,
                                                             PurchasePrice = purchaseInvoiceLine.PurchasePrice,
                                                             LineDiscountPercentage = purchaseInvoiceLine.LineDiscountPercentage,
                                                             LineDiscountAmount = purchaseInvoiceLine.LineDiscountAmount,
                                                             LineAmount = purchaseInvoiceLine.LineAmount,
                                                             PurchasePriceLCY = purchaseInvoiceLine.PurchasePriceLCY,
                                                             LineDiscountAmountLCY = purchaseInvoiceLine.LineDiscountAmountLCY,
                                                             LineAmountLCY = purchaseInvoiceLine.LineAmountLCY,
                                                             InvoiceDiscountAmount = purchaseInvoiceLine.InvoiceDiscountAmount,
                                                             InvoiceDiscountAmountLCY = purchaseInvoiceLine.InvoiceDiscountAmountLCY,
                                                             UnitPrice = purchaseInvoiceLine.UnitPrice,
                                                             UnitPriceLCY = purchaseInvoiceLine.UnitPriceLCY,
                                                             Amount = purchaseInvoiceLine.Amount,
                                                             AmountLCY = purchaseInvoiceLine.AmountLCY,
                                                             ChargeAmount = purchaseInvoiceLine.ChargeAmount,
                                                             ChargeAmountLCY = purchaseInvoiceLine.CostAmountLCY,
                                                             ImportDutyAmount = purchaseInvoiceLine.ImportDutyAmount,
                                                             ImportDutyAmountLCY = purchaseInvoiceLine.ImportDutyAmountLCY,
                                                             ExciseTaxAmount = purchaseInvoiceLine.ExciseTaxAmount,
                                                             ExciseTaxAmountLCY = purchaseInvoiceLine.ExciseTaxAmountLCY,
                                                             VatBaseAmount = purchaseInvoiceLine.VatBaseAmount,
                                                             VatId = purchaseInvoiceLine.VatId,
                                                             Vat = purchaseInvoiceLine.Vat == null ? null : new ExtNetComboBoxModel()
                                                             {
                                                                 Id = purchaseInvoiceLine.Vat.Id,
                                                                 Code = purchaseInvoiceLine.Vat.Code,
                                                                 Description = purchaseInvoiceLine.Vat.Description
                                                             },
                                                             VatPercentage = purchaseInvoiceLine.VatPercentage,
                                                             VatAmount = purchaseInvoiceLine.VatAmount,
                                                             VatBaseAmountLCY = purchaseInvoiceLine.VatBaseAmountLCY,
                                                             VatAmountLCY = purchaseInvoiceLine.VatAmountLCY,
                                                             QtyPerUom = purchaseInvoiceLine.QtyPerUom,
                                                             QuantityBase = purchaseInvoiceLine.QuantityBase,
                                                             CostPrice = purchaseInvoiceLine.CostPrice,
                                                             CostPriceQtyBase = purchaseInvoiceLine.CostPriceQtyBase,
                                                             CostAmount = purchaseInvoiceLine.CostAmount,
                                                             CostPriceLCY = purchaseInvoiceLine.CostPriceLCY,
                                                             CostPriceQtyBaseLCY = purchaseInvoiceLine.CostPriceQtyBaseLCY,
                                                             CostAmountLCY = purchaseInvoiceLine.CostAmountLCY,
                                                         }).ToList();

                model = new PurchaseInvoiceHeaderEditViewModel()
                {
                    Id = entity.Id,
                    DocumentType = (DocumentType)entity.DocumentType,
                    DocSequenceId = entity.DocSequenceId,
                    DocumentNo = entity.DocumentNo,
                    DocumentDate = entity.DocumentDate,
                    PostingDate = entity.PostingDate,
                    CurrencyId = entity.CurrencyId,
                    CurrencyFactor = entity.CurrencyFactor,
                    BuyFromVendorId = entity.BuyFromVendorId,
                    BuyFromVendorName = entity.BuyFromVendorName,
                    BuyFromAddress = entity.BuyFromAddress,
                    BuyFromContactName = entity.BuyFromContactName,
                    PayToVendorId = entity.PayToVendorId,
                    PayToName = entity.PayToName,
                    PayToAddress = entity.PayToAddress,
                    PayToContactName = entity.PayToContactName,
                    ShipToName = entity.ShipToName,
                    ShipToAddress = entity.ShipToAddress,
                    ShipToContactName = entity.ShipToContactName,
                    AccountPayableId = entity.AccountPayableId,
                    Description = entity.Description,
                    PurchaseInvoiceLines = purchaseInvoiceLines,
                    TotalLineAmount = entity.TotalLineAmount,
                    TotalLineAmountLCY = entity.TotalLineAmountLCY,
                    TotalAmount = entity.TotalAmount,
                    TotalAmountLCY = entity.TotalAmountLCY,
                    TotalVatAmount = entity.TotalVatAmount,
                    TotalVatAmountLCY = entity.TotalVatAmountLCY,
                    TotalPayment = entity.TotalPayment,
                    TotalPaymentLCY = entity.TotalPaymentLCY,
                    Status = (PurchaseInvoiceDocumentStatusType)entity.Status,
                    Version = entity.Version
                };

                ViewData["BuyFromVendor"] = new List<object>()
                {
                    new ExtNetComboBoxModel
                    {
                        Id = entity.BuyFromVendorId,
                        Code = entity.BuyFromVendor.Code,
                        Description = entity.BuyFromVendor.Description
                    }
                };

                ViewData["PayToVendor"] = new List<object>()
                {
                    new ExtNetComboBoxModel
                    {
                        Id = entity.PayToVendorId,
                        Code = entity.PayToVendor.Code,
                        Description = entity.PayToVendor.Description
                    }
                };

                ViewData["Currency"] = new List<object>()
                {
                    new ExtNetComboBoxModel
                    {
                        Id = entity.CurrencyId,
                        Code = entity.Currency.Code,
                        Description = entity.Currency.Description
                    }
                };

                ViewData["AccountPayable"] = new List<object>()
                {
                     new ExtNetComboBoxModel
                     {
                         Id = entity.AccountPayableId,
                         Code = entity.AccountPayable.Code,
                         Description = entity.AccountPayable.Description
                     }
                };

                ViewData["Items"] = purchaseInvoiceLines.Where(x => x.Item != null).GroupBy(x => new { x.ItemId }).Select(i => i.First())
                    .Select(x => new ExtNetComboBoxModel
                    {
                        Id = x.ItemId,
                        Code = x.Item.Code,
                        Description = x.Item.Description,
                    }).ToList();

                ViewData["UOMs"] = purchaseInvoiceLines.Where(x => x.Uom != null).GroupBy(x => new { x.UomId }).Select(i => i.First())
                    .Select(x => new ExtNetComboBoxModel
                    {
                        Id = x.UomId,
                        Code = x.Uom.Code,
                        Description = x.Uom.Description,
                    }).ToList();

                ViewData["Locations"] = purchaseInvoiceLines.Where(x => x.Location != null).GroupBy(x => new { x.LocationId }).Select(i => i.First())
                    .Select(x => new ExtNetComboBoxModel
                    {
                        Id = x.LocationId,
                        Code = x.Location.Code,
                        Description = x.Location.Description,
                    }).ToList();
            }

            return new Ext.Net.MVC.PartialViewResult() { Model = model, ViewData = ViewData };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(PurchaseInvoiceHeaderEditViewModel headerModel, String purchaseInvoiceLinesJSON)
        {
            List<PurchaseInvoiceLineEditViewModel> purchaseInvoiceLines = JsonConvert.DeserializeObject<List<PurchaseInvoiceLineEditViewModel>>(purchaseInvoiceLinesJSON, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });

            //Save
            ModelState.Clear();
            headerModel.PurchaseInvoiceLines = purchaseInvoiceLines;
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

            if (headerModel.Id.HasValue)
            {
                var updatePurchaseInvoiceHeader = repository.Get(c => c.Id == headerModel.Id, new string[] { "PurchaseInvoiceLines" }).SingleOrDefault();
                if (updatePurchaseInvoiceHeader == null || updatePurchaseInvoiceHeader.Version != headerModel.Version)
                {
                    return this.Direct(false, "Purchase Invoice has been changed or deleted! Please check");
                }

                updatePurchaseInvoiceHeader.DocSequenceId = headerModel.DocSequenceId;
                updatePurchaseInvoiceHeader.DocumentNo = headerModel.DocumentNo;
                updatePurchaseInvoiceHeader.DocumentDate = headerModel.DocumentDate;
                updatePurchaseInvoiceHeader.PostingDate = headerModel.PostingDate;
                updatePurchaseInvoiceHeader.DocumentType = (byte)headerModel.DocumentType;
                updatePurchaseInvoiceHeader.BuyFromVendorId = headerModel.BuyFromVendorId;
                updatePurchaseInvoiceHeader.BuyFromVendorName = headerModel.BuyFromVendorName;
                updatePurchaseInvoiceHeader.BuyFromAddress = headerModel.BuyFromAddress;
                updatePurchaseInvoiceHeader.BuyFromContactId = null;
                updatePurchaseInvoiceHeader.BuyFromContactName = headerModel.BuyFromContactName;
                updatePurchaseInvoiceHeader.PayToVendorId = headerModel.PayToVendorId;
                updatePurchaseInvoiceHeader.PayToName = headerModel.PayToName;
                updatePurchaseInvoiceHeader.PayToAddress = headerModel.PayToAddress;
                updatePurchaseInvoiceHeader.PayToContactName = headerModel.PayToContactName;
                updatePurchaseInvoiceHeader.ShipToName = headerModel.ShipToName;
                updatePurchaseInvoiceHeader.ShipToAddress = headerModel.ShipToAddress;
                updatePurchaseInvoiceHeader.ShipToContactName = headerModel.ShipToContactName;
                updatePurchaseInvoiceHeader.CurrencyId = headerModel.CurrencyId;
                updatePurchaseInvoiceHeader.CurrencyFactor = headerModel.CurrencyFactor;
                updatePurchaseInvoiceHeader.AccountPayableId = headerModel.AccountPayableId;
                updatePurchaseInvoiceHeader.Description = headerModel.Description;
                updatePurchaseInvoiceHeader.LocationId = null;
                updatePurchaseInvoiceHeader.SalesPersonId = null;
                updatePurchaseInvoiceHeader.TotalLineAmount = headerModel.TotalLineAmount;
                updatePurchaseInvoiceHeader.TotalLineAmountLCY = headerModel.TotalLineAmountLCY;
                updatePurchaseInvoiceHeader.DiscountId = null;
                updatePurchaseInvoiceHeader.InvoiceDiscountPercentage = headerModel.InvoiceDiscountPercentage;
                updatePurchaseInvoiceHeader.InvoiceDiscountAmount = headerModel.InvoiceDiscountAmount;
                updatePurchaseInvoiceHeader.InvoiceDiscountAmountLCY = headerModel.InvoiceDiscountAmountLCY;
                updatePurchaseInvoiceHeader.TotalAmount = headerModel.TotalAmount;
                updatePurchaseInvoiceHeader.TotalAmountLCY = headerModel.TotalAmountLCY;
                updatePurchaseInvoiceHeader.TotalVatAmount = headerModel.TotalVatAmount;
                updatePurchaseInvoiceHeader.TotalVatAmountLCY = headerModel.TotalVatAmountLCY;
                updatePurchaseInvoiceHeader.TotalPayment = headerModel.TotalPayment;
                updatePurchaseInvoiceHeader.TotalPaymentLCY = headerModel.TotalPaymentLCY;
                updatePurchaseInvoiceHeader.Status = (byte)headerModel.Status;
                updatePurchaseInvoiceHeader.RecModifiedAt = DateTime.Now;
                updatePurchaseInvoiceHeader.RecModifiedBy = (long)user.ProviderUserKey;
                updatePurchaseInvoiceHeader.Version++;

                foreach (var purchaseInvoiceLine in purchaseInvoiceLines)
                {
                    if (purchaseInvoiceLine.Id == 0 || purchaseInvoiceLine.Id == null)
                        updatePurchaseInvoiceHeader.PurchaseInvoiceLines.Add(new DataAccess.PurchaseInvoiceLine()
                        {
                            ClientId = clientId,
                            OrganizationId = organizationId,
                            LineNo = purchaseInvoiceLine.LineNo,
                            DocumentType = (byte)headerModel.DocumentType,
                            DocumentNo = headerModel.DocumentNo,
                            PostingDate = headerModel.PostingDate,
                            Type = purchaseInvoiceLine.Type,
                            ItemId  = purchaseInvoiceLine.ItemId,
                            Description = purchaseInvoiceLine.Description,
                            Quantity = purchaseInvoiceLine.Quantity,
                            PurchasePrice = purchaseInvoiceLine.PurchasePrice,
                            LineDiscountPercentage = purchaseInvoiceLine.LineDiscountPercentage,
                            LineDiscountAmount = purchaseInvoiceLine.LineDiscountAmount,
                            LineAmount = purchaseInvoiceLine.LineAmount,
                            PurchasePriceLCY = purchaseInvoiceLine.PurchasePriceLCY,
                            LineDiscountAmountLCY = purchaseInvoiceLine.LineDiscountAmountLCY,
                            LineAmountLCY = purchaseInvoiceLine.LineAmountLCY,
                            InvoiceDiscountAmount = purchaseInvoiceLine.InvoiceDiscountAmount,
                            InvoiceDiscountAmountLCY = purchaseInvoiceLine.InvoiceDiscountAmountLCY,
                            UnitPrice = purchaseInvoiceLine.UnitPrice,
                            UnitPriceLCY = purchaseInvoiceLine.UnitPriceLCY,
                            Amount = purchaseInvoiceLine.Amount,
                            AmountLCY = purchaseInvoiceLine.AmountLCY,
                            ChargeAmount = purchaseInvoiceLine.ChargeAmount,
                            ChargeAmountLCY = purchaseInvoiceLine.CostAmountLCY,
                            ImportDutyAmount = purchaseInvoiceLine.ImportDutyAmount,
                            ImportDutyAmountLCY = purchaseInvoiceLine.ImportDutyAmountLCY,
                            ExciseTaxAmount = purchaseInvoiceLine.ExciseTaxAmount,
                            ExciseTaxAmountLCY = purchaseInvoiceLine.ExciseTaxAmountLCY,
                            VatBaseAmount = purchaseInvoiceLine.VatBaseAmount,
                            VatId = purchaseInvoiceLine.VatId,
                            VatPercentage = purchaseInvoiceLine.VatPercentage,
                            VatAmount = purchaseInvoiceLine.VatAmount,
                            VatBaseAmountLCY = purchaseInvoiceLine.VatBaseAmountLCY,
                            VatAmountLCY = purchaseInvoiceLine.VatAmountLCY,
                            QtyPerUom = purchaseInvoiceLine.QtyPerUom,
                            QuantityBase = purchaseInvoiceLine.QuantityBase,
                            CostPrice = purchaseInvoiceLine.CostPrice,
                            CostPriceQtyBase = purchaseInvoiceLine.CostPriceQtyBase,
                            CostAmount = purchaseInvoiceLine.CostAmount,
                            CostPriceLCY = purchaseInvoiceLine.CostPriceLCY,
                            CostPriceQtyBaseLCY = purchaseInvoiceLine.CostPriceQtyBaseLCY,
                            CostAmountLCY = purchaseInvoiceLine.CostAmountLCY,
                        });
                    else
                    {
                        updatePurchaseInvoiceHeader.PurchaseInvoiceLines.Where(c => c.Id == purchaseInvoiceLine.Id)
                            .ForEach(x =>
                            {
                                x.LineNo = purchaseInvoiceLine.LineNo;
                                x.DocumentType = (byte)headerModel.DocumentType;
                                x.DocumentNo = headerModel.DocumentNo;
                                x.PostingDate = headerModel.PostingDate;
                                x.Type = purchaseInvoiceLine.Type;
                                x.ItemId = purchaseInvoiceLine.ItemId;
                                x.Description = purchaseInvoiceLine.Description;
                                x.Quantity = purchaseInvoiceLine.Quantity;
                                x.PurchasePrice = purchaseInvoiceLine.PurchasePrice;
                                x.LineDiscountPercentage = purchaseInvoiceLine.LineDiscountPercentage;
                                x.LineDiscountAmount = purchaseInvoiceLine.LineDiscountAmount;
                                x.LineAmount = purchaseInvoiceLine.LineAmount;
                                x.PurchasePriceLCY = purchaseInvoiceLine.PurchasePriceLCY;
                                x.LineDiscountAmountLCY = purchaseInvoiceLine.LineDiscountAmountLCY;
                                x.LineAmountLCY = purchaseInvoiceLine.LineAmountLCY;
                                x.InvoiceDiscountAmount = purchaseInvoiceLine.InvoiceDiscountAmount;
                                x.InvoiceDiscountAmountLCY = purchaseInvoiceLine.InvoiceDiscountAmountLCY;
                                x.UnitPrice = purchaseInvoiceLine.UnitPrice;
                                x.UnitPriceLCY = purchaseInvoiceLine.UnitPriceLCY;
                                x.Amount = purchaseInvoiceLine.Amount;
                                x.AmountLCY = purchaseInvoiceLine.AmountLCY;
                                x.ChargeAmount = purchaseInvoiceLine.ChargeAmount;
                                x.ChargeAmountLCY = purchaseInvoiceLine.CostAmountLCY;
                                x.ImportDutyAmount = purchaseInvoiceLine.ImportDutyAmount;
                                x.ImportDutyAmountLCY = purchaseInvoiceLine.ImportDutyAmountLCY;
                                x.ExciseTaxAmount = purchaseInvoiceLine.ExciseTaxAmount;
                                x.ExciseTaxAmountLCY = purchaseInvoiceLine.ExciseTaxAmountLCY;
                                x.VatBaseAmount = purchaseInvoiceLine.VatBaseAmount;
                                x.VatId = purchaseInvoiceLine.VatId;
                                x.VatPercentage = purchaseInvoiceLine.VatPercentage;
                                x.VatAmount = purchaseInvoiceLine.VatAmount;
                                x.VatBaseAmountLCY = purchaseInvoiceLine.VatBaseAmountLCY;
                                x.VatAmountLCY = purchaseInvoiceLine.VatAmountLCY;
                                x.QtyPerUom = purchaseInvoiceLine.QtyPerUom;
                                x.QuantityBase = purchaseInvoiceLine.QuantityBase;
                                x.CostPrice = purchaseInvoiceLine.CostPrice;
                                x.CostPriceQtyBase = purchaseInvoiceLine.CostPriceQtyBase;
                                x.CostAmount = purchaseInvoiceLine.CostAmount;
                                x.CostPriceLCY = purchaseInvoiceLine.CostPriceLCY;
                                x.CostPriceQtyBaseLCY = purchaseInvoiceLine.CostPriceQtyBaseLCY;
                                x.CostAmountLCY = purchaseInvoiceLine.CostAmountLCY;
                            });
                    }
                }

                foreach (var purchaseInvoiceLine in updatePurchaseInvoiceHeader.PurchaseInvoiceLines.Where(x => purchaseInvoiceLines.All(u => u.Id != x.Id && u.Id != 0 && u.Id.HasValue)).ToList())
                {
                    updatePurchaseInvoiceHeader.PurchaseInvoiceLines.Remove(purchaseInvoiceLine);
                    this.repository.DataContext.PurchaseInvoiceLines.Remove(purchaseInvoiceLine); //this.repository.DataContext.Entry(salesPriceRemove).State = EntityState.Deleted;
                }

                try
                {
                    var updateEntity = this.repository.Update(updatePurchaseInvoiceHeader);
                    headerModel.Id = updateEntity.Id;
                    headerModel.Version = updateEntity.Version;
                }
                catch (Exception ex)
                {
                    return this.Direct(false, ex.Message);
                }

            }
            else //Add New
            {
                headerModel.DocumentNo = (new NoSequenceRepository()).GetNextNo(headerModel.DocSequenceId, headerModel.DocumentDate);
                headerModel.Version = 1;
                headerModel.TotalVatAmount = 0;
                headerModel.TotalVatAmountLCY = 0;
                headerModel.TotalPayment = headerModel.TotalAmount;
                headerModel.TotalPaymentLCY = headerModel.TotalAmountLCY;

                var newPurchaseInvoiceHeader = new DataAccess.PurchaseInvoiceHeader()
                {
                    ClientId = clientId,
                    OrganizationId = organizationId,
                    DocSequenceId = headerModel.DocSequenceId,
                    DocumentType = (byte)headerModel.DocumentType,
                    DocumentNo = headerModel.DocumentNo,
                    DocumentDate = headerModel.DocumentDate,
                    PostingDate = headerModel.PostingDate,
                    BuyFromVendorId  = headerModel.BuyFromVendorId,
                    BuyFromVendorName = headerModel.BuyFromVendorName,
                    BuyFromAddress = headerModel.BuyFromAddress,
                    BuyFromContactId = null,
                    BuyFromContactName = headerModel.BuyFromContactName,
                    PayToVendorId = headerModel.PayToVendorId,
                    PayToName = headerModel.PayToName,
                    PayToAddress = headerModel.PayToAddress,
                    PayToContactName = headerModel.PayToContactName,
                    ShipToName = headerModel.ShipToName,
                    ShipToAddress = headerModel.ShipToAddress,
                    ShipToContactName = headerModel.ShipToContactName,
                    CurrencyId = headerModel.CurrencyId,
                    CurrencyFactor = headerModel.CurrencyFactor,
                    AccountPayableId = headerModel.AccountPayableId,
                    Description = headerModel.Description,
                    LocationId = null,
                    SalesPersonId = null,
                    TotalLineAmount = headerModel.TotalLineAmount,
                    TotalLineAmountLCY = headerModel.TotalLineAmountLCY,
                    DiscountId = null,
                    InvoiceDiscountPercentage = headerModel.InvoiceDiscountPercentage,
                    InvoiceDiscountAmount = headerModel.InvoiceDiscountAmount,
                    InvoiceDiscountAmountLCY = headerModel.InvoiceDiscountAmountLCY,
                    TotalAmount = headerModel.TotalAmount,
                    TotalAmountLCY = headerModel.TotalAmountLCY,
                    TotalVatAmount = headerModel.TotalVatAmount,
                    TotalVatAmountLCY = headerModel.TotalVatAmountLCY,
                    TotalPayment = headerModel.TotalPayment,
                    TotalPaymentLCY = headerModel.TotalPaymentLCY,
                    Status = (byte)headerModel.Status,
                    Version = 1,
                    RecModifiedAt = DateTime.Now,
                    RecCreatedBy = (long)user.ProviderUserKey,
                    RecCreatedAt = DateTime.Now,
                    RecModifiedBy = (long)user.ProviderUserKey
                };
                newPurchaseInvoiceHeader.PurchaseInvoiceLines = purchaseInvoiceLines
                    .Select(c => new DataAccess.PurchaseInvoiceLine()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        LineNo = c.LineNo,
                        DocumentType = (byte)headerModel.DocumentType,
                        DocumentNo = headerModel.DocumentNo,
                        PostingDate = headerModel.PostingDate,
                        Type = c.Type,
                        ItemId = c.ItemId,
                        Description = c.Description,
                        Quantity = c.Quantity,
                        PurchasePrice = c.PurchasePrice,
                        LineDiscountPercentage = c.LineDiscountPercentage,
                        LineDiscountAmount = c.LineDiscountAmount,
                        LineAmount = c.LineAmount,
                        PurchasePriceLCY = c.PurchasePriceLCY,
                        LineDiscountAmountLCY = c.LineDiscountAmountLCY,
                        LineAmountLCY = c.LineAmountLCY,
                        InvoiceDiscountAmount = c.InvoiceDiscountAmount,
                        InvoiceDiscountAmountLCY = c.InvoiceDiscountAmountLCY,
                        UnitPrice = c.UnitPrice,
                        UnitPriceLCY = c.UnitPriceLCY,
                        Amount = c.Amount,
                        AmountLCY = c.AmountLCY,
                        ChargeAmount = c.ChargeAmount,
                        ChargeAmountLCY = c.CostAmountLCY,
                        ImportDutyAmount = c.ImportDutyAmount,
                        ImportDutyAmountLCY = c.ImportDutyAmountLCY,
                        ExciseTaxAmount = c.ExciseTaxAmount,
                        ExciseTaxAmountLCY = c.ExciseTaxAmountLCY,
                        VatBaseAmount = c.VatBaseAmount,
                        VatId = c.VatId,
                        VatPercentage = c.VatPercentage,
                        VatAmount = c.VatAmount,
                        VatBaseAmountLCY = c.VatBaseAmountLCY,
                        VatAmountLCY = c.VatAmountLCY,
                        QtyPerUom = c.QtyPerUom,
                        QuantityBase = c.QuantityBase,
                        CostPrice = c.CostPrice,
                        CostPriceQtyBase = c.CostPriceQtyBase,
                        CostAmount = c.CostAmount,
                        CostPriceLCY = c.CostPriceLCY,
                        CostPriceQtyBaseLCY = c.CostPriceQtyBaseLCY,
                        CostAmountLCY = c.CostAmountLCY,
                    }).ToList(); 
                try
                {
                    var newEntity = this.repository.AddNew(newPurchaseInvoiceHeader);
                    headerModel.Id = newEntity.Id;
                    headerModel.Version = newEntity.Version;
                }
                catch (DbEntityValidationException ex)
                {
                    return this.Direct(false, ex.DbEntityValidationExceptionToString());
                }

                catch (Exception ex)
                {
                    return this.Direct(false, ex.Message);
                }
            }

            Store StoreCashPaymentList = X.GetCmp<Store>("StoreCashPaymentList");
            StoreCashPaymentList.Reload();

            return this.Direct(new { Id = headerModel.Id, Version = headerModel.Version });
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id, new string[] { "PurchaseInvoiceLines" }).SingleOrDefault();
                if (entity == null)
                {
                    return this.Direct(false, "Purchase Invoice Header not found! Please check");
                }

                using (var dbContextTransaction = this.repository.DataContext.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var purchaseInvoiceLine in entity.PurchaseInvoiceLines.ToList())
                        {
                            entity.PurchaseInvoiceLines.Remove(purchaseInvoiceLine);
                            this.repository.DataContext.PurchaseInvoiceLines.Remove(purchaseInvoiceLine);  //this.repository.DataContext.Entry(salesPriceRemove).State = EntityState.Deleted;
                        }

                        this.repository.Delete(entity);

                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();

                        return this.Direct(false, e.Message);
                    }
                }
                Store StoreCashPaymentList = X.GetCmp<Store>("StoreCashPaymentList");
                StoreCashPaymentList.Reload();
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }

            return this.Direct();
        }

        public ActionResult ChangeBusinessPartner(string selectedData)
        {
            BusinessPartnerLookupViewModel selectedPartner = JsonConvert.DeserializeObject<BusinessPartnerLookupViewModel>(selectedData, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });
            this.GetCmp<TextField>("BusinessPartnerName").Value = selectedPartner.Description;
            this.GetCmp<TextField>("BusinessPartnerAddress").Value = selectedPartner.Address;
            this.GetCmp<TextField>("BusinessPartnerContactName").Value = selectedPartner.ContactName;

            return this.Direct();
        }

        public ActionResult ChangeCurrency(long? currencyId)
        {
            if (currencyId == null)
                return this.Direct();

            MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
            long clientId = user.ClientId ?? 0;
            long organizationId = user.OrganizationId ?? 0;

            if (clientId == 0 || organizationId == 0)
            {
                return this.Direct(false, Resources.Resources.User_dont_have_Client_or_Organization_Please_set);
            }

            Client client = (new ClientRepository()).Get(User);
            long currencyLcyId = client.CurrencyLcyId ?? 0;
            if (currencyLcyId == 0)
                return this.Direct(false, "ERROR : Please set Client CurrencyLcy first");

            this.GetCmp<TextField>("CurrencyFactor").Value = currencyId == currencyLcyId ? 1 : 1;
            this.GetCmp<TextField>("CurrencyFactor").ReadOnly = currencyId == currencyLcyId;
            this.GetCmp<TextField>("TotalAmountLCY").Hidden = currencyId == currencyLcyId;
            this.GetCmp<Column>("CashLineAmountLCYCol").Hidden = currencyId == currencyLcyId;

            return this.Direct();
        }

        public ActionResult ChangeCurrencyFactor(PurchaseInvoiceHeaderEditViewModel model, string cashLinesJSON)
        {
            List<CashLineEditViewModel> cashLinesModel = JsonConvert.DeserializeObject<List<CashLineEditViewModel>>(cashLinesJSON, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });
            Store cashLineGridStore = X.GetCmp<Store>("CashLineGridStore");
            foreach (CashLineEditViewModel cashLine in cashLinesModel)
            {
                var amountLCY = Round.RoundAmountLCY(cashLine.Amount * model.CurrencyFactor);
                ModelProxy record = cashLineGridStore.GetById(cashLine.LineNo);
                record.Set("AmountLCY", amountLCY);

                record.Commit();
            }
            return this.Direct();
        }

        public ActionResult AddLine(String cashLinesJSON)
        {
            List<CashLineEditViewModel> cashLinesModel = JsonConvert.DeserializeObject<List<CashLineEditViewModel>>(cashLinesJSON, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });
            long lineNo = cashLinesModel.Count >= 1 ? cashLinesModel.Max(c => c.LineNo) + 1000 : 1000;

            var newItem = new CashLineEditViewModel()
            {
                Id = null,
                LineNo = lineNo
            };

            Store cashLineGridStore = X.GetCmp<Store>("CashLineGridStore");
            cashLineGridStore.Add(newItem);

            return this.Direct(new { LineNo = lineNo });
        }

        public ActionResult LineEdit(int lineNo, string field, string oldValue, string newValue, string recordData, string headerData)
        {
            MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
            long clientId = user.ClientId ?? 0;
            long organizationId = user.OrganizationId ?? 0;

            if (clientId == 0 || organizationId == 0)
                return this.Direct(false, Resources.Resources.User_dont_have_Client_or_Organization_Please_set);

            PurchaseInvoiceHeaderEditViewModel purchaseInvoiceHeaderEditViewModel = JSON.Deserialize<PurchaseInvoiceHeaderEditViewModel>(headerData, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });

            CashLineEditViewModel cashLineEditViewModel = JSON.Deserialize<CashLineEditViewModel>(recordData, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });

            ModelProxy record = X.GetCmp<Store>("CashLineGridStore").GetById(lineNo);

            switch (field)
            {
                case "CorrespAccountId":
                    var accountRepository = new AccountRepository();
                    var correspAccountId = Convert.ToInt64(newValue);
                    var corespAcc = accountRepository.Get(c => c.Id == correspAccountId, new string[] { "Organization" }).Select(c =>
                            new AccountLookupViewModel()
                            {
                                Id = c.Id,
                                Code = c.Code,
                                Description = c.Description,
                                OrganizationCode = c.Organization.Code,
                                Status = (DefaultStatusType)c.Status
                            }
                        ).First();
                    record.Set("CorrespAccount", corespAcc);
                    //TODO: Update CorrespAccountStore
                    //Store correspAccountStore = X.GetCmp<Store>("CorrespAccountStore");
                    //correspAccountStore.Add(corespAcc);
                    break;
                case "Amount":
                    var amountLCY = Round.RoundAmountLCY(cashLineEditViewModel.Amount * purchaseInvoiceHeaderEditViewModel.CurrencyFactor);
                    record.Set("AmountLCY", amountLCY);
                    break;
            }
            record.Commit();
            return this.Direct();
        }

        public ActionResult Print(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var _id = Convert.ToInt64(id);
            var entity = repository.Get(c => c.Id == _id, new string[] { "AccountPayable", "BuyFromVendor", "PayToVendor", "Currency", "PurchaseInvoiceLines", "PurchaseInvoiceLines.Item", "PurchaseInvoiceLines.Location", "PurchaseInvoiceLines.Uom", "PurchaseInvoiceLines.Vat" }).SingleOrDefault();
            if (entity == null)
            {
                return this.Direct(false, "Purchase Invoice has been changed or deleted! Please check");
            }

            var purchaseInvoiceLines = (from purchaseInvoiceLine in entity.PurchaseInvoiceLines
                             select new
                             {
                                 Id = purchaseInvoiceLine.Id,
                                 LineNo = purchaseInvoiceLine.LineNo,
                                 ItemId = purchaseInvoiceLine.ItemId,
                                 ItemCode = purchaseInvoiceLine.Item == null ? null : purchaseInvoiceLine.Item.Code,
                                 Description = purchaseInvoiceLine.Description,
                                 Quantity = purchaseInvoiceLine.Quantity,
                                 PurchasePrice = purchaseInvoiceLine.PurchasePrice,
                                 LineDiscountPercentage = purchaseInvoiceLine.LineDiscountPercentage,
                                 LineDiscountAmount = purchaseInvoiceLine.LineDiscountAmount,
                                 LineAmount = purchaseInvoiceLine.LineAmount,
                                 PurchasePriceLCY = purchaseInvoiceLine.PurchasePriceLCY,
                                 LineDiscountAmountLCY = purchaseInvoiceLine.LineDiscountAmountLCY,
                                 LineAmountLCY = purchaseInvoiceLine.LineAmountLCY,
                                 InvoiceDiscountAmount = purchaseInvoiceLine.InvoiceDiscountAmount,
                                 InvoiceDiscountAmountLCY = purchaseInvoiceLine.InvoiceDiscountAmountLCY,
                                 UnitPrice = purchaseInvoiceLine.UnitPrice,
                                 UnitPriceLCY = purchaseInvoiceLine.UnitPriceLCY,
                                 Amount = purchaseInvoiceLine.Amount,
                                 AmountLCY = purchaseInvoiceLine.AmountLCY,
                                 ChargeAmount = purchaseInvoiceLine.ChargeAmount,
                                 ChargeAmountLCY = purchaseInvoiceLine.CostAmountLCY,
                                 ImportDutyAmount = purchaseInvoiceLine.ImportDutyAmount,
                                 ImportDutyAmountLCY = purchaseInvoiceLine.ImportDutyAmountLCY,
                                 ExciseTaxAmount = purchaseInvoiceLine.ExciseTaxAmount,
                                 ExciseTaxAmountLCY = purchaseInvoiceLine.ExciseTaxAmountLCY,
                                 VatBaseAmount = purchaseInvoiceLine.VatBaseAmount,
                                 VatId = purchaseInvoiceLine.VatId,
                                 VatPercentage = purchaseInvoiceLine.VatPercentage,
                                 VatAmount = purchaseInvoiceLine.VatAmount,
                                 VatBaseAmountLCY = purchaseInvoiceLine.VatBaseAmountLCY,
                                 VatAmountLCY = purchaseInvoiceLine.VatAmountLCY,
                                 QtyPerUom = purchaseInvoiceLine.QtyPerUom,
                                 QuantityBase = purchaseInvoiceLine.QuantityBase,
                                 CostPrice = purchaseInvoiceLine.CostPrice,
                                 CostPriceQtyBase = purchaseInvoiceLine.CostPriceQtyBase,
                                 CostAmount = purchaseInvoiceLine.CostAmount,
                                 CostPriceLCY = purchaseInvoiceLine.CostPriceLCY,
                                 CostPriceQtyBaseLCY = purchaseInvoiceLine.CostPriceQtyBaseLCY,
                                 CostAmountLCY = purchaseInvoiceLine.CostAmountLCY,
                             }).ToList();

            var headerModel = new
            {
                Id = entity.Id,
                DocumentType = (DocumentType)entity.DocumentType,
                DocSequenceId = entity.DocSequenceId,
                DocumentNo = entity.DocumentNo,
                DocumentDate = entity.DocumentDate,
                PostingDate = entity.PostingDate,
                CurrencyId = entity.CurrencyId,
                CurrencyCode = entity.Currency.Code,
                CurrencyFactor = entity.CurrencyFactor,
                BuyFromVendorId = entity.BuyFromVendorId,
                BuyFromVendorCode = entity.BuyFromVendor.Code,
                BuyFromVendorName = entity.BuyFromVendorName,
                BuyFromAddress = entity.BuyFromAddress,
                BuyFromContactName = entity.BuyFromContactName,
                PayToVendorId = entity.PayToVendorId,
                PayToVendorCode = entity.PayToVendor.Code,
                PayToName = entity.PayToName,
                PayToAddress = entity.PayToAddress,
                PayToContactName = entity.PayToContactName,
                ShipToName = entity.ShipToName,
                ShipToAddress = entity.ShipToAddress,
                ShipToContactName = entity.ShipToContactName,
                AccountPayableId = entity.AccountPayableId,
                AccountPayableCode = entity.AccountPayable.Code,
                Description = entity.Description,
                LocationId = entity.LocationId,
                LocationCode = entity.Location?.Code,
                SalesPersonId = entity.SalesPersonId,
                TotalLineAmount = entity.TotalLineAmount,
                TotalLineAmountLCY = entity.TotalLineAmountLCY,
                DiscountId = entity.DiscountId,
                InvoiceDiscountPercentage = entity.InvoiceDiscountPercentage,
                InvoiceDiscountAmount = entity.InvoiceDiscountAmount,
                InvoiceDiscountAmountLCY = entity.InvoiceDiscountAmountLCY,
                TotalAmount = entity.TotalAmount,
                TotalAmountLCY = entity.TotalAmountLCY,
                TotalVatAmount = entity.TotalVatAmount,
                TotalVatAmountLCY = entity.TotalVatAmountLCY,
                TotalPayment = entity.TotalPayment,
                TotalPaymentLCY = entity.TotalPaymentLCY,
                Status = (CashDocumentStatusType)entity.Status,
                Version = entity.Version
            };

            //Print
            StiReport report = new StiReport();
            report.Load(Server.MapPath("~/Resources/Reports/purchaseInvoice_001.mrt"));

            Client _client = (new ClientRepository()).Get(User, new string[] { "CurrencyLcy" });
            var client = new
            {
                _client.Description,
                _client.Adress,
                _client.TaxCode,
                _client.Telephone,
                _client.Email,
                _client.Website,
                _client.Image,
                CurrencyLcyCode = _client.CurrencyLcy.Code
            };

            var data = JObject.FromObject(new { PurchaseInvoiceHeader = headerModel, PurchaseInvoiceLines = purchaseInvoiceLines, Client = client, T = ReportServices.ReportGlobalizedTexts() });
            report.Dictionary.Databases.Clear();
            var ds = StiJsonToDataSetConverter.GetDataSet(data);
            report.RegData("data", "", ds);
            report.Dictionary.Synchronize();
            report.Render();

            var fileName = $"purchaseInvoice_Id_{headerModel.Id}_No_{headerModel.DocumentNo}_{User.Identity.Name}_{DateTime.Now:yyyyMMddhhmmss}";
            report.ExportDocument(StiExportFormat.Pdf, Server.MapPath("~/Resources/printReports/") + fileName + ".pdf");
            report.SaveDocument(Server.MapPath("~/Resources/printReports/") + fileName + ".mdc");

            return this.Direct(new { FileName = fileName });
        }
    }
}