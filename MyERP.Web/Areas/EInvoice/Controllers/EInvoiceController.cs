using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
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
using WebGrease.Css.Extensions;

namespace MyERP.Web.Areas.EInvoice.Controllers
{
    public class EInvoiceController : EntityBaseController<MyERP.DataAccess.EInvoiceHeader, MyERP.DataAccess.EntitiesModel>
    {
        public EInvoiceController() : this(new EInvoiceHeaderRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public EInvoiceController(IBaseRepository<MyERP.DataAccess.EInvoiceHeader, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: EInvoice/EInvoice
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
            var paging = ((EInvoiceHeaderRepository)repository).Paging(parameters);

            var data = paging.Data.Select(c => new EInvHeaderViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                InvoiceNumber = c.InvoiceNumber,
                InvoiceIssuedDate = c.InvoiceIssuedDate,
                BuyerCode = c.Buyer?.Code,
                BuyerDisplayName = c.BuyerDisplayName,
                BuyerLegalName = c.BuyerLegalName,
                BuyerTaxCode = c.BuyerTaxCode,
                BuyerAddressLine = c.BuyerAddressLine,
                BuyerPostalCode = c.BuyerPostalCode,
                BuyerDistrictName = c.BuyerDistrictName,
                BuyerCityName = c.BuyerCityName,
                BuyerCountryCode = c.BuyerCountryCode,
                BuyerFaxNumber = c.BuyerFaxNumber,
                BuyerEmail = c.BuyerEmail,
                BuyerBankName = c.BuyerBankName,
                BuyerBankAccount = c.BuyerBankAccount,
                TotalAmountWithoutVAT = c.TotalAmountWithoutVAT,
                TotalVATAmount = c.TotalVATAmount,
                TotalAmountWithVAT = c.TotalAmountWithVAT,
                Description = c.Description,
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Status = (EInvoiceDocumentStatusType)c.Status,
                Version = c.Version
            }).ToList();

            Session.Add("StoreEInvoiceList_StoreRequestParameters", parameters);

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

            ViewData["CurrencyLCYId"] = currencyLcyId;
            CurrencyRepository currencyRepository = new CurrencyRepository();
            ViewData["CurrencyStore"] = currencyRepository.Get(filter: c => c.Id == currencyLcyId, includePaths: new string[] { "Organization" })
                .Select(x => new ExtNetComboBoxModel()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Description = x.Description
                }).ToList();

            PreferenceViewModel preference = (PreferenceViewModel)Session["Preference"];
            var model = new EInvHeaderEditViewModel()
            {
                Id = null,
                InvoiceIssuedDate = preference.WorkingDate,
                CurrencyId = currencyLcyId,
                ExchangeRate = 1,
                EInvoiceLines = new List<EInvLineEditViewModel>(),
                Status = EInvoiceDocumentStatusType.Draft
            };

            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id, new string[] { "Buyer", "Currency", "EInvFormType",
                    "EInvoiceLines", "EInvoiceLines.Vat", "EInvoiceLines.Item", "EInvoiceLines.Uom" }).SingleOrDefault();
                if (entity == null)
                {
                    return this.Direct(false, "Document has been changed or deleted! Please check");
                }

                List<EInvLineEditViewModel> eInvoiceLines = (from eInvoiceLine in entity.EInvoiceLines
                                                                               select new EInvLineEditViewModel()
                                                                               {
                                                                                   Id = eInvoiceLine.Id,
                                                                                   LineNumber = eInvoiceLine.LineNumber,
                                                                                   ItemId = eInvoiceLine.ItemId,
                                                                                   ItemCode = eInvoiceLine.Item == null ? "" : eInvoiceLine.Item.Code,
                                                                                   ItemName = eInvoiceLine.Item == null ? "" : eInvoiceLine.Item.Description,
                                                                                   Item = eInvoiceLine.Item == null ? null : new LookupViewModel()
                                                                                   {
                                                                                       Code = eInvoiceLine.Item.Code,
                                                                                       OrganizationCode = "",
                                                                                       Description = eInvoiceLine.Item.Description,
                                                                                       Blocked = eInvoiceLine.Item.Blocked
                                                                                   },
                                                                                   UnitId = eInvoiceLine.UnitId,
                                                                                   UnitCode = eInvoiceLine.Uom == null ? "" : eInvoiceLine.Uom.Code,
                                                                                   UnitName = eInvoiceLine.Uom == null ? "" : eInvoiceLine.Uom.Description,
                                                                                   Uom = eInvoiceLine.Uom == null ? null : new ItemUomLookUpViewModel()
                                                                                   {
                                                                                       UomId = eInvoiceLine.UnitId,
                                                                                       Code = eInvoiceLine.Uom.Code,
                                                                                       Description = eInvoiceLine.Uom.Description,
                                                                                       QtyPerUom = 0
                                                                                   },
                                                                                   UnitPrice = eInvoiceLine.UnitPrice,
                                                                                   Quantity = eInvoiceLine.Quantity,
                                                                                   ItemTotalAmountWithoutVAT = eInvoiceLine.ItemTotalAmountWithoutVAT,
                                                                                   ItemTotalAmountWithoutVATLCY = eInvoiceLine.ItemTotalAmountWithoutVATLCY,
                                                                                   VatId = eInvoiceLine.VatId,
                                                                                   Vat = eInvoiceLine.Vat == null ? null : new LookupViewModel()
                                                                                   {
                                                                                       Code = eInvoiceLine.Vat.Code,
                                                                                       OrganizationCode = "",
                                                                                       Description = eInvoiceLine.Vat.Description,
                                                                                       Blocked = eInvoiceLine.Vat.Blocked

                                                                                   },
                                                                                   VATPercentage = eInvoiceLine.VATPercentage,
                                                                                   VATAmount = eInvoiceLine.VATAmount,
                                                                                   ItemTotalAmountWithVAT = eInvoiceLine.ItemTotalAmountWithVAT,
                                                                                   ItemTotalAmountWithVATLCY = eInvoiceLine.ItemTotalAmountWithVATLCY,
                                                                               }).ToList();

                model = new EInvHeaderEditViewModel()
                {
                    Id = entity.Id,
                    FormTypeId = entity.FormTypeId,
                    InvoiceIssuedDate = entity.InvoiceIssuedDate,
                    InvoiceNumber = entity.InvoiceNumber,
                    CurrencyId = entity.CurrencyId,
                    ExchangeRate = entity.ExchangeRate,
                    BuyerId = entity.Buyer?.Id,
                    BuyerDisplayName = entity.BuyerDisplayName,
                    BuyerLegalName = entity.BuyerLegalName,
                    BuyerTaxCode = entity.BuyerTaxCode,
                    BuyerAddressLine = entity.BuyerAddressLine,
                    BuyerPostalCode = entity.BuyerPostalCode,
                    BuyerDistrictName = entity.BuyerDistrictName,
                    BuyerCityName = entity.BuyerCityName,
                    BuyerCountryCode = entity.BuyerCountryCode,
                    BuyerFaxNumber = entity.BuyerFaxNumber,
                    BuyerEmail = entity.BuyerEmail,
                    BuyerBankName = entity.BuyerBankName,
                    BuyerBankAccount = entity.BuyerBankAccount,
                    SellerLegalName = entity.SellerLegalName,
                    SellerTaxCode = entity.SellerTaxCode,
                    SellerAddressLine = entity.SellerAddressLine,
                    SellerPostalCode = entity.SellerPostalCode,
                    SellerDistrictName = entity.SellerDistrictName,
                    SellerCityName = entity.SellerCityName,
                    SellerCountryCode = entity.SellerCountryCode,
                    SellerPhoneNumber = entity.SellerPhoneNumber,
                    SellerFaxNumber = entity.SellerFaxNumber,
                    SellerEmail = entity.SellerEmail,
                    SellerBankName = entity.SellerBankName,
                    SellerBankAccount = entity.SellerBankAccount,
                    SellerContactPersonName = entity.SellerContactPersonName,
                    SellerSignedPersonName = entity.SellerSignedPersonName,
                    PaymentMethodName = entity.PaymentMethodName,
                    Description = entity.Description,
                    InvoiceNote = entity.InvoiceNote,
                    TotalAmountWithoutVAT = entity.TotalAmountWithoutVAT,
                    TotalVATAmount = entity.TotalVATAmount,
                    TotalAmountWithVAT = entity.TotalAmountWithVAT,
                    TotalAmountWithVATFrn = entity.TotalAmountWithVATFrn,
                    TotalAmountWithVATInWords = entity.TotalAmountWithVATInWords,
                    EInvoiceLines = eInvoiceLines,
                    Status = (EInvoiceDocumentStatusType)entity.Status,
                    Version = entity.Version
                };

                ViewData["BuyerStore"] = new List<object>()
                {
                    new ExtNetComboBoxModel
                    {
                        Id = entity.BuyerId,
                        Code = entity.Buyer?.Code,
                        Description = entity.Buyer?.Description
                    }
                };

                ViewData["FormTypeStore"] = new List<object>()
                {
                    new EInvFormTypeLookupViewModel()
                    {
                        Id = entity.FormTypeId,
                        InvoiceType = entity.EInvFormType.InvoiceType,
                        TemplateCode = entity.EInvFormType.TemplateCode,
                        InvoiceForm = entity.EInvFormType.InvoiceForm,
                        InvoiceSeries = entity.EInvFormType.InvoiceSeries,
                    }
                };

                ViewData["CurrencyStore"] = new List<object>()
                {
                    new ExtNetComboBoxModel
                    {
                        Id = entity.CurrencyId,
                        Code = entity.Currency.Code,
                        Description = entity.Currency.Description
                    }
                };

                ViewData["ItemStore"] = eInvoiceLines.Where(x => x.Item != null).GroupBy(x => new { x.ItemId }).Select(i => i.First())
                    .Select(x => new ExtNetComboBoxModel
                    {
                        Id = x.ItemId,
                        Code = x.Item.Code,
                        Description = x.Item.Description,
                    }).ToList();

                ViewData["UomStore"] = eInvoiceLines.Where(x => x.Uom != null).GroupBy(x => new { x.UnitId }).Select(i => i.First())
                    .Select(x => new ExtNetComboBoxModel
                    {
                        Id = x.UnitId,
                        Code = x.Uom.Code,
                        Description = x.Uom.Description,
                    }).ToList();

                ViewData["VatStore"] = eInvoiceLines.Where(x => x.Vat != null).GroupBy(x => new { x.VatId }).Select(i => i.First())
                    .Select(x => new ExtNetComboBoxModel
                    {
                        Id = x.VatId,
                        Code = x.Vat.Code,
                        Description = x.Vat.Description,
                    }).ToList();
            }

            return new Ext.Net.MVC.PartialViewResult() { Model = model, ViewData = ViewData };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(EInvHeaderEditViewModel headerModel, String eInvoiceLinesJSON)
        {
            List<EInvLineEditViewModel> eInvoiceLines = JsonConvert.DeserializeObject<List<EInvLineEditViewModel>>(eInvoiceLinesJSON, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });

            //Save
            ModelState.Clear();
            headerModel.EInvoiceLines = eInvoiceLines;
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
                var updateEInvoiceHeader = repository.Get(c => c.Id == headerModel.Id, new string[] { "EInvoiceLines" }).SingleOrDefault();
                if (updateEInvoiceHeader == null || updateEInvoiceHeader.Version != headerModel.Version)
                {
                    return this.Direct(false, "EInvoice has been changed or deleted! Please check");
                }
                updateEInvoiceHeader.FormTypeId = headerModel.FormTypeId;
                updateEInvoiceHeader.OriginalEInvoiceId = headerModel.OriginalEInvoiceId;
                updateEInvoiceHeader.InvoiceNumber = headerModel.InvoiceNumber;
                updateEInvoiceHeader.InvoiceIssuedDate = headerModel.InvoiceIssuedDate;
                updateEInvoiceHeader.ContractNumber = headerModel.ContractNumber;
                updateEInvoiceHeader.ContractDate = headerModel.ContractDate;
                updateEInvoiceHeader.Description = headerModel.Description;
                updateEInvoiceHeader.CurrencyId = headerModel.CurrencyId;
                updateEInvoiceHeader.ExchangeRate = headerModel.ExchangeRate;
                updateEInvoiceHeader.InvoiceNote = headerModel.InvoiceNote;
                updateEInvoiceHeader.AdjustmentType = headerModel.AdjustmentType;
                updateEInvoiceHeader.AdditionalReferenceDesc = headerModel.AdditionalReferenceDesc;
                updateEInvoiceHeader.AdditionalReferenceDate = headerModel.AdditionalReferenceDate;

                updateEInvoiceHeader.BuyerId = headerModel.BuyerId;
                updateEInvoiceHeader.BuyerDisplayName = headerModel.BuyerDisplayName;
                updateEInvoiceHeader.BuyerLegalName = headerModel.BuyerLegalName;
                updateEInvoiceHeader.BuyerTaxCode = headerModel.BuyerTaxCode;
                updateEInvoiceHeader.BuyerAddressLine = headerModel.BuyerAddressLine;
                updateEInvoiceHeader.BuyerPostalCode = headerModel.BuyerPostalCode;
                updateEInvoiceHeader.BuyerDistrictName = headerModel.BuyerDistrictName;
                updateEInvoiceHeader.BuyerCityName = headerModel.BuyerCityName;
                updateEInvoiceHeader.BuyerCountryCode = headerModel.BuyerCountryCode;
                updateEInvoiceHeader.BuyerPhoneNumber = headerModel.BuyerPhoneNumber;
                updateEInvoiceHeader.BuyerFaxNumber = headerModel.BuyerFaxNumber;
                updateEInvoiceHeader.BuyerEmail = headerModel.BuyerEmail;
                updateEInvoiceHeader.BuyerBankName = headerModel.BuyerBankName;
                updateEInvoiceHeader.BuyerBankAccount = headerModel.BuyerBankAccount;

                updateEInvoiceHeader.SellerLegalName = headerModel.SellerLegalName;
                updateEInvoiceHeader.SellerTaxCode = headerModel.SellerTaxCode;
                updateEInvoiceHeader.SellerAddressLine = headerModel.SellerAddressLine;
                updateEInvoiceHeader.SellerPostalCode = headerModel.SellerPostalCode;
                updateEInvoiceHeader.SellerDistrictName = headerModel.SellerDistrictName;
                updateEInvoiceHeader.SellerCityName = headerModel.SellerCityName;
                updateEInvoiceHeader.SellerCountryCode = headerModel.SellerCountryCode;
                updateEInvoiceHeader.SellerPhoneNumber = headerModel.SellerPhoneNumber;
                updateEInvoiceHeader.SellerFaxNumber = headerModel.SellerFaxNumber;
                updateEInvoiceHeader.SellerEmail = headerModel.SellerEmail;
                updateEInvoiceHeader.SellerBankName = headerModel.SellerBankName;
                updateEInvoiceHeader.SellerBankAccount = headerModel.SellerBankAccount;
                updateEInvoiceHeader.SellerContactPersonName = headerModel.SellerContactPersonName;
                updateEInvoiceHeader.SellerSignedPersonName = headerModel.SellerSignedPersonName;
                
                updateEInvoiceHeader.PaymentMethodName = headerModel.PaymentMethodName;

                updateEInvoiceHeader.SumOfTotalLineAmountWithoutVAT = headerModel.TotalAmountWithoutVAT;
                updateEInvoiceHeader.TotalAmountWithoutVAT = headerModel.TotalAmountWithoutVAT;
                updateEInvoiceHeader.TotalVATAmount = headerModel.TotalVATAmount;
                updateEInvoiceHeader.TotalAmountWithVAT = headerModel.TotalAmountWithVAT;
                updateEInvoiceHeader.TotalAmountWithVATFrn = headerModel.TotalAmountWithVATFrn;
                updateEInvoiceHeader.TotalAmountWithVATInWords = headerModel.TotalAmountWithVATInWords;
                updateEInvoiceHeader.Status = headerModel.Status;
                updateEInvoiceHeader.RecModifiedAt = DateTime.Now;
                updateEInvoiceHeader.RecModifiedBy = (long)user.ProviderUserKey;
                updateEInvoiceHeader.Version++;

                foreach (var eInvoiceLine in eInvoiceLines)
                {
                    if (eInvoiceLine.Id == 0 || eInvoiceLine.Id == null)
                        updateEInvoiceHeader.EInvoiceLines.Add(new DataAccess.EInvoiceLine()
                        {
                            ClientId = clientId,
                            OrganizationId = organizationId,
                            LineNumber = eInvoiceLine.LineNumber,
                            ItemId = eInvoiceLine.ItemId,
                            ItemCode = eInvoiceLine.ItemCode,
                            ItemName = eInvoiceLine.ItemName,
                            UnitId = eInvoiceLine.UnitId,
                            UnitCode = eInvoiceLine.UnitCode,
                            UnitName = eInvoiceLine.UnitName,
                            Quantity = eInvoiceLine.Quantity,
                            UnitPrice = eInvoiceLine.UnitPrice,
                            ItemTotalAmountWithoutVAT = eInvoiceLine.ItemTotalAmountWithoutVAT,
                            ItemTotalAmountWithoutVATLCY = eInvoiceLine.ItemTotalAmountWithoutVATLCY,
                            VatId = eInvoiceLine.VatId,
                            VATPercentage = eInvoiceLine.VATPercentage,
                            VATAmount = eInvoiceLine.VATAmount,
                            VATAmountLCY = eInvoiceLine.VATAmountLCY,
                            ItemTotalAmountWithVAT = eInvoiceLine.ItemTotalAmountWithVAT,
                            ItemTotalAmountWithVATLCY = eInvoiceLine.ItemTotalAmountWithVATLCY,
                        });
                    else
                    {
                        updateEInvoiceHeader.EInvoiceLines.Where(c => c.Id == eInvoiceLine.Id)
                            .ForEach(x =>
                            {
                                x.LineNumber = eInvoiceLine.LineNumber;
                                x.ItemId = eInvoiceLine.ItemId;
                                x.ItemCode = eInvoiceLine.ItemCode;
                                x.ItemName = eInvoiceLine.ItemName;
                                x.UnitId = eInvoiceLine.UnitId;
                                x.UnitCode = eInvoiceLine.UnitCode;
                                x.UnitName = eInvoiceLine.UnitName;
                                x.Quantity = eInvoiceLine.Quantity;
                                x.UnitPrice = eInvoiceLine.UnitPrice;
                                x.ItemTotalAmountWithoutVAT = eInvoiceLine.ItemTotalAmountWithoutVAT;
                                x.ItemTotalAmountWithoutVATLCY = eInvoiceLine.ItemTotalAmountWithoutVATLCY;
                                x.VatId = eInvoiceLine.VatId;
                                x.VATPercentage = eInvoiceLine.VATPercentage;
                                x.VATAmount = eInvoiceLine.VATAmount;
                                x.VATAmountLCY = eInvoiceLine.VATAmountLCY;
                                x.ItemTotalAmountWithVAT = eInvoiceLine.ItemTotalAmountWithVAT;
                                x.ItemTotalAmountWithVATLCY = eInvoiceLine.ItemTotalAmountWithVATLCY;
                            });
                    }
                }

                foreach (var eInvoiceLine in updateEInvoiceHeader.EInvoiceLines.Where(x => eInvoiceLines.All(u => u.Id != x.Id && u.Id != 0 && u.Id.HasValue)).ToList())
                {
                    updateEInvoiceHeader.EInvoiceLines.Remove(eInvoiceLine);
                    this.repository.DataContext.EInvoiceLines.Remove(eInvoiceLine); //this.repository.DataContext.Entry(salesPriceRemove).State = EntityState.Deleted;
                }

                try
                {
                    var updateEntity = this.repository.Update(updateEInvoiceHeader);
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
                headerModel.Version = 1;

                var newEInvoiceHeader = new DataAccess.EInvoiceHeader()
                {
                    ClientId = clientId,
                    OrganizationId = organizationId,
                    FormTypeId = headerModel.FormTypeId,
                    OriginalEInvoiceId = headerModel.OriginalEInvoiceId,
                    InvoiceNumber = headerModel.InvoiceNumber,
                    InvoiceIssuedDate = headerModel.InvoiceIssuedDate,
                    ContractNumber = headerModel.ContractNumber,
                    ContractDate = headerModel.ContractDate,
                    Description = headerModel.Description,
                    CurrencyId = headerModel.CurrencyId,
                    ExchangeRate = headerModel.ExchangeRate,
                    InvoiceNote = headerModel.InvoiceNote,
                    AdjustmentType = headerModel.AdjustmentType,
                    AdditionalReferenceDesc = headerModel.AdditionalReferenceDesc,
                    AdditionalReferenceDate = headerModel.AdditionalReferenceDate,
                    BuyerId = headerModel.BuyerId,
                    BuyerDisplayName = headerModel.BuyerDisplayName,
                    BuyerLegalName = headerModel.BuyerLegalName,
                    BuyerTaxCode = headerModel.BuyerTaxCode,
                    BuyerAddressLine = headerModel.BuyerAddressLine,
                    BuyerPostalCode = headerModel.BuyerPostalCode,
                    BuyerDistrictName = headerModel.BuyerDistrictName,
                    BuyerCityName = headerModel.BuyerCityName,
                    BuyerCountryCode = headerModel.BuyerCountryCode,
                    BuyerPhoneNumber = headerModel.BuyerPhoneNumber,
                    BuyerFaxNumber = headerModel.BuyerFaxNumber,
                    BuyerEmail = headerModel.BuyerEmail,
                    BuyerBankName = headerModel.BuyerBankName,
                    BuyerBankAccount = headerModel.BuyerBankAccount,

                    SellerLegalName = headerModel.SellerLegalName,
                    SellerTaxCode = headerModel.SellerTaxCode,
                    SellerAddressLine = headerModel.SellerAddressLine,
                    SellerPostalCode = headerModel.SellerPostalCode,
                    SellerDistrictName = headerModel.SellerDistrictName,
                    SellerCityName = headerModel.SellerCityName,
                    SellerCountryCode = headerModel.SellerCountryCode,
                    SellerPhoneNumber = headerModel.SellerPhoneNumber,
                    SellerFaxNumber = headerModel.SellerFaxNumber,
                    SellerEmail = headerModel.SellerEmail,
                    SellerBankName = headerModel.SellerBankName,
                    SellerBankAccount = headerModel.SellerBankAccount,
                    SellerContactPersonName = headerModel.SellerContactPersonName,
                    SellerSignedPersonName = headerModel.SellerSignedPersonName,

                    PaymentMethodName = headerModel.PaymentMethodName,

                    SumOfTotalLineAmountWithoutVAT = headerModel.TotalAmountWithoutVAT,
                    TotalAmountWithoutVAT = headerModel.TotalAmountWithoutVAT,
                    TotalVATAmount = headerModel.TotalVATAmount,
                    TotalAmountWithVAT = headerModel.TotalAmountWithVAT,
                    TotalAmountWithVATFrn = headerModel.TotalAmountWithVATFrn,
                    TotalAmountWithVATInWords = headerModel.TotalAmountWithVATInWords,

                    Status = headerModel.Status,
                    Version = 1,
                    RecModifiedAt = DateTime.Now,
                    RecCreatedBy = (long)user.ProviderUserKey,
                    RecCreatedAt = DateTime.Now,
                    RecModifiedBy = (long)user.ProviderUserKey
                };

                newEInvoiceHeader.EInvoiceLines = eInvoiceLines
                    .Select(eInvoiceLine => new DataAccess.EInvoiceLine()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        LineNumber = eInvoiceLine.LineNumber,
                        ItemId = eInvoiceLine.ItemId,
                        ItemCode = eInvoiceLine.ItemCode,
                        ItemName = eInvoiceLine.ItemName,
                        UnitId = eInvoiceLine.UnitId,
                        UnitCode = eInvoiceLine.UnitCode,
                        UnitName = eInvoiceLine.UnitName,
                        Quantity = eInvoiceLine.Quantity,
                        UnitPrice = eInvoiceLine.UnitPrice,
                        ItemTotalAmountWithoutVAT = eInvoiceLine.ItemTotalAmountWithoutVAT,
                        ItemTotalAmountWithoutVATLCY = eInvoiceLine.ItemTotalAmountWithoutVATLCY,
                        VatId = eInvoiceLine.VatId,
                        VATPercentage = eInvoiceLine.VATPercentage,
                        VATAmount = eInvoiceLine.VATAmount,
                        VATAmountLCY = eInvoiceLine.VATAmountLCY,
                        ItemTotalAmountWithVAT = eInvoiceLine.ItemTotalAmountWithVAT,
                        ItemTotalAmountWithVATLCY = eInvoiceLine.ItemTotalAmountWithVATLCY
                    }).ToList();
                
                try
                {
                    var newEntity = this.repository.AddNew(newEInvoiceHeader);
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

            //Store storePurchaseInvoiceList = X.GetCmp<Store>("StorePurchaseInvoiceList");
            //storePurchaseInvoiceList.Reload();

            return this.Direct(new { Id = headerModel.Id, Version = headerModel.Version });
        }

        public ActionResult Print(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var _id = Convert.ToInt64(id);
            var entity =  repository.Get(c => c.Id == _id, new string[] { "Currency", "EInvFormType", "EInvoiceLines", "EInvoiceLines.Item", "EInvoiceLines.Vat", "EInvoiceLines.Uom" }).SingleOrDefault();
            if (entity == null)
            {
                return this.Direct(false, "Invoice Header has been changed or deleted! Please check");
            }
            string renderName = $"eInvoiceRender_{User.Identity.Name}_{DateTime.Now:yyyyMMddhhmmss}";
            string dirPath = Server.MapPath($"~/Resources/PrintReports/EInvoices/{renderName}");
            if (!System.IO.Directory.Exists(dirPath))
            {
                System.IO.Directory.CreateDirectory(dirPath);
            }
            string fullHtmlPath = dirPath + $"/{renderName}.html";
            try
            {
                (repository as EInvoiceHeaderRepository).CreateHtmlFile(entity, dirPath, fullHtmlPath);
                
                if (System.IO.File.Exists(Server.MapPath($"~/Resources/images/signature.png")) && entity.Status == EInvoiceDocumentStatusType.Signed)
                {
                    System.IO.File.WriteAllBytes(dirPath + "/signature.png", System.IO.File.ReadAllBytes(Server.MapPath($"~/Resources/images/signature.png")));
                }
            }
            catch (Exception ex)
            {
            }
            return this.Direct(new { FileName = renderName });
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id, new string[] { "EInvoiceLines" }).SingleOrDefault();
                if (entity == null)
                {
                    return this.Direct(false, "Header not found!Please check");
                }

                if(entity.Status != (byte)EInvoiceDocumentStatusType.Draft)
                {
                    return this.Direct(false, "Cannot delete document which had been released or signed!!");
                }

                using (var dbContextTransaction = this.repository.DataContext.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var line in entity.EInvoiceLines.ToList())
                        {
                            entity.EInvoiceLines.Remove(line);
                            this.repository.DataContext.EInvoiceLines.Remove(line);  //this.repository.DataContext.Entry(salesPriceRemove).State = EntityState.Deleted;
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
                Store storeList = X.GetCmp<Store>("StoreEInvoiceList");
                storeList.Reload();
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }

            return this.Direct();
        }

        public ActionResult LineEdit(int lineNo, string field, string oldValue, string newValue, string recordData,
            string headerData)
        {
            if (String.Compare(oldValue, newValue, StringComparison.CurrentCultureIgnoreCase) == 0)
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

            EInvHeaderEditViewModel eInvoiceHeaderEditViewModel = JSON.Deserialize<EInvHeaderEditViewModel>(headerData, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });

            EInvLineEditViewModel eInvoiceLineEditViewModel = JSON.Deserialize<EInvLineEditViewModel>(recordData, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });

            ModelProxy record = X.GetCmp<Store>("EInvoiceLineGridStore").GetById(lineNo);

            switch (field)
            {
                case "ItemId":
                    {
                        var itemRepository = new ItemRepository();
                        var itemId = Convert.ToInt64(newValue);
                        var item = itemRepository.Get(c => c.Id == itemId, new string[] { "Organization", "Vat", "Vat.Organization" }).First();
                        var itemModel = new LookupViewModel()
                        {
                            Id = item.Id,
                            Code = item.Code,
                            Description = item.Description,
                            OrganizationCode = item.Organization.Code,
                            Blocked = item.Blocked
                        };

                        record.Set("Item", itemModel);
                        var itemUomRepository = new ItemUomRepository();
                        var itemUom = itemUomRepository.Get(c => c.ItemId == itemId && c.UomId == item.SalesUomId,
                            new string[] { "Uom" }).First();
                        var uomModel = new ItemUomLookUpViewModel
                        {
                            Code = itemUom.Uom.Code,
                            UomId = itemUom.UomId,
                            Description = itemUom.Uom.Description,
                            QtyPerUom = itemUom.QtyPerUom
                        };
                        record.Set("ItemCode", itemModel.Code);
                        record.Set("ItemName", itemModel.Description);
                        record.Set("Uom", uomModel);
                        record.Set("UnitId", uomModel.UomId);
                        record.Set("UnitCode", uomModel.Code);
                        record.Set("UnitName", uomModel.Description);
                        record.Set("QtyPerUom", uomModel.QtyPerUom);

                        if (item.Vat != null)
                        {
                            var vatModel = new VatLookupViewModel
                            {
                                Id = item.VatId ?? 0,
                                Code = item.Vat.Code,
                                Description = item.Vat.Description,
                                OrganizationCode = item.Vat.Organization.Code,
                                Blocked = item.Vat.Blocked
                            };

                            record.Set("Vat", vatModel);
                            record.Set("VatId", vatModel.Id);
                            record.Set("VATPercentage", item.Vat.VatPercentage);
                        }
                        break;
                    }
                case "UnitId":
                    {
                        var uomId = Convert.ToInt64(newValue);
                        var itemUomRepository = new ItemUomRepository();
                        var itemUom = itemUomRepository.Get(c => c.ItemId == eInvoiceLineEditViewModel.ItemId && c.UomId == uomId,
                            new string[] { "Uom" }).First();
                        var uomModel = new ItemUomLookUpViewModel()
                        {
                            UomId = itemUom.Id,
                            Code = itemUom.Uom.Code,
                            Description = itemUom.Uom.Description,
                            QtyPerUom = itemUom.QtyPerUom
                        };
                        record.Set("Uom", uomModel);
                        record.Set("UnitId", uomModel.UomId);
                        record.Set("UnitCode", uomModel.Code);
                        record.Set("UnitName", uomModel.Description);
                        record.Set("QtyPerUom", uomModel.QtyPerUom);
                        break;
                    }
                case "VatId":
                    {
                        var vatRepository = new VatRepository();
                        var vatId = Convert.ToInt64(newValue);
                        var vat = vatRepository.Get(c => c.Id == vatId, new string[] { "Organization" }).First();
                        var vatModel = new LookupViewModel()
                        {
                            Id = vat.Id,
                            Code = vat.Code,
                            Description = vat.Description,
                            OrganizationCode = vat.Organization.Code,
                            Blocked = vat.Blocked
                        };

                        record.Set("Vat", vatModel);
                        record.Set("VATPercentage", vat.VatPercentage);

                        eInvoiceLineEditViewModel.VatId = vat.Id;
                        eInvoiceLineEditViewModel.VATPercentage = vat.VatPercentage;

                        var eInvoiceLineRepository = new EInvoiceLineRepository();
                        eInvoiceLineRepository.Update("VATPercentage", currencyLcyId, ref eInvoiceHeaderEditViewModel, ref eInvoiceLineEditViewModel);

                        eInvoiceLineRepository.UpdateRecord(eInvoiceLineEditViewModel, ref record);
                        break;
                    }
                
                case "Quantity":
                case "UnitPrice":
                case "ItemTotalAmountWithoutVAT":
                case "UnitPriceLCY":
                case "ItemTotalAmountWithoutVATLCY":
                case "VATAmount":
                case "VATAmountLCY":
                    {
                        var eInvoiceLineRepository = new EInvoiceLineRepository();
                        eInvoiceLineRepository.Update(field, currencyLcyId, ref eInvoiceHeaderEditViewModel,
                            ref eInvoiceLineEditViewModel);

                        eInvoiceLineRepository.UpdateRecord(eInvoiceLineEditViewModel, ref record);
                        break;
                    }
            }
            record.Commit();
            return this.Direct();
        }

        public ActionResult ChangeBuyer(string selectedData)
        {
            BusinessPartnerLookupViewModel selectedPartner = JsonConvert.DeserializeObject<BusinessPartnerLookupViewModel>(selectedData, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });
            
            this.GetCmp<TextField>("BuyerDisplayName").Value = selectedPartner.ContactName;
            this.GetCmp<TextField>("BuyerLegalName").Value = selectedPartner.Description;
            this.GetCmp<TextField>("BuyerTaxCode").Value = selectedPartner.VatCode;
            this.GetCmp<TextField>("BuyerAddressLine").Value = selectedPartner.Address;
            return this.Direct();
        }

        public ActionResult ChangeFormType(string selectedData)
        {
            EInvFormTypeLookupViewModel selectedFormType = JsonConvert.DeserializeObject<EInvFormTypeLookupViewModel>(selectedData, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });

            this.GetCmp<TextField>("SellerLegalName").Value = selectedFormType.SellerLegalName;
            this.GetCmp<TextField>("SellerTaxCode").Value = selectedFormType.SellerTaxCode;
            this.GetCmp<TextField>("SellerAddressLine").Value = selectedFormType.SellerAddressLine;
            this.GetCmp<TextField>("SellerBankName").Value = selectedFormType.SellerBankName;
            this.GetCmp<TextField>("SellerBankAccount").Value = selectedFormType.SellerBankAccount;
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
           
            return this.Direct();
        }

        public ActionResult ChangeExchangeRate(EInvHeaderEditViewModel model, string eInvoiceLinesJSON)
        {
            List<EInvLineEditViewModel> lines = JsonConvert.DeserializeObject<List<EInvLineEditViewModel>>(eInvoiceLinesJSON, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });
            Store lineGridStore = X.GetCmp<Store>("EInvoiceLineGridStore");
            foreach (EInvLineEditViewModel line in lines)
            {
                //calc LCY value
            }
            return this.Direct();
        }

        public ActionResult AddLine(String eInvoiceLinesJSON)
        {
            List<EInvLineEditViewModel> InvoiceLinesModel = JsonConvert.DeserializeObject<List<EInvLineEditViewModel>>(eInvoiceLinesJSON, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });
            long lineNumber = InvoiceLinesModel.Count >= 1 ? InvoiceLinesModel.Max(c => c.LineNumber) + 1000 : 1000;

            var newItem = new EInvLineEditViewModel()
            {
                Id = null,
                LineNumber = lineNumber
            };

            Store invoiceLineGridStore = X.GetCmp<Store>("EInvoiceLineGridStore");
            invoiceLineGridStore.Add(newItem);

            return this.Direct(new { LineNo = lineNumber });
        }

        public ActionResult ReplaceInvoice(string id, string version)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));
            if (String.IsNullOrEmpty(version))
                throw new ArgumentNullException(nameof(version));

            MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);

            var _id = Convert.ToInt64(id);
            var _version = Convert.ToInt64(version);

            try
            {

            }
            catch (System.Data.Entity.Core.ObjectNotFoundException ex)
            {
                return this.Direct(false, ex.Message);
            }
            catch (Exception ex)
            {
                return this.Direct(false, ex.Message);
            }

            return this.Direct();
        }

        public ActionResult CancelInvoice(string id, string version)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));
            if (string.IsNullOrEmpty(version))
                throw new ArgumentNullException(nameof(version));

            MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
            var _id = Convert.ToInt64(id);
            var _version = Convert.ToInt64(version);

            try
            {
               
                return this.Direct();
            }
            catch (System.Data.Entity.Core.ObjectNotFoundException ex)
            {
                return this.Direct(false, ex.Message);
            }
            catch (Exception ex)
            {
                return this.Direct(false, ex.Message);
            }
        }
        public ActionResult StartSignAction(string id, string version)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));
            if (string.IsNullOrEmpty(version))
                throw new ArgumentNullException(nameof(version));

            MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);

            var _id = Convert.ToInt64(id);
            var _version = Convert.ToInt64(version);
            EInvoiceHeader _eInvoiceHeader;
            string originXML, base64OriginXML;
            try
            {
                string reservationCode = MyERP.Web.Others.Functions.RandomString();
                while (!(repository as EInvoiceHeaderRepository).CheckReservationCode(reservationCode))
                {
                    reservationCode = MyERP.Web.Others.Functions.RandomString();
                }
                _eInvoiceHeader = (repository as EInvoiceHeaderRepository).SetEInvNumber(_id, ref _version, (long)user.ProviderUserKey, reservationCode);

                originXML = (repository as EInvoiceHeaderRepository).GetXmlInvoiceInfo(_id, _version);
                base64OriginXML = Convert.ToBase64String(Encoding.UTF8.GetBytes(originXML));
            }
            catch (System.Data.Entity.Core.ObjectNotFoundException ex)
            {
                return this.Direct(false, ex.Message);
            }
            catch (Exception ex)
            {
                return this.Direct(false, ex.Message);
            }

            X.GetCmp<Hidden>("InvoiceNumber").SetValue(_eInvoiceHeader.InvoiceNumber);
            X.GetCmp<Hidden>("Version").SetValue(_eInvoiceHeader.Version);
            X.GetCmp<ComboBox>("Status").SetValue(_eInvoiceHeader.Status);
            return this.Direct(new {OriginXML = base64OriginXML, SerialNumber = "00C62199148ACD49FAAC90AD8E0013B6E2", PIN = "12345678" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PublicSignedInvoice(string id, string signedModelJson)
        {
            SignXMLDTO signedXMLDTO = JsonConvert.DeserializeObject<SignXMLDTO>(signedModelJson, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });
            MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);

            var _id = Convert.ToInt64(id);
            long _signedId = 0;
            try
            {
                _signedId = (repository as EInvoiceHeaderRepository).PublicSignedInvoice(_id, signedXMLDTO, (long)user.ProviderUserKey);
            }
            catch (System.Data.Entity.Core.ObjectNotFoundException ex)
            {
                return this.Direct(false, ex.Message);
            }
            catch (Exception ex)
            {
                return this.Direct(false, ex.Message);
            }

            return this.Direct(new { Id = _signedId });
        }

    }
}