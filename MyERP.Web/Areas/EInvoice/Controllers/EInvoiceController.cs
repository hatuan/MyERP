using System;
using System.Collections.Generic;
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

            var optionRepository = new OptionRepository();
            long purchaseInvoiceSequenceId = optionRepository.OptionParameter(organizationId, OptionParameter.PurchInvoiceSeqId);
            if (purchaseInvoiceSequenceId == 0)
                return this.Direct(false, "ERROR : Please set Option Purchase Invoice first");

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
                    "EInvoiceLines", "EInvoiceLines.Vat"  }).SingleOrDefault();
                if (entity == null)
                {
                    return this.Direct(false, "Document has been changed or deleted! Please check");
                }

                List<EInvLineEditViewModel> eInvoiceLines = (from eInvoiceLine in entity.EInvoiceLines
                                                                               select new EInvLineEditViewModel()
                                                                               {
                                                                                   Id = eInvoiceLine.Id,
                                                                                   LineNumber = eInvoiceLine.LineNumber,
                                                                                   ItemCode = eInvoiceLine.ItemCode,
                                                                                   ItemName = eInvoiceLine.ItemName,
                                                                                   UnitCode = eInvoiceLine.UnitCode,
                                                                                   UnitName = eInvoiceLine.UnitName,
                                                                                   UnitPrice = eInvoiceLine.UnitPrice,
                                                                                   Quantity = eInvoiceLine.Quantity,
                                                                                   ItemTotalAmountWithoutVAT = eInvoiceLine.ItemTotalAmountWithoutVAT,
                                                                                   VatId = eInvoiceLine.VatId,
                                                                                   Vat = eInvoiceLine.Vat == null ? null : new LookupViewModel()
                                                                                   {
                                                                                       Code = eInvoiceLine.Vat.Code,
                                                                                       OrganizationCode = "",
                                                                                       Description = eInvoiceLine.Vat.Description,
                                                                                       Status = (DefaultStatusType)eInvoiceLine.Vat.Status

                                                                                   },
                                                                                   VATPercentage = eInvoiceLine.VATPercentage,
                                                                                   VATAmount = eInvoiceLine.VATAmount,
                                                                               }).ToList();

                model = new EInvHeaderEditViewModel()
                {
                    Id = entity.Id,
                    FormTypeId = entity.FormTypeId,
                    InvoiceIssuedDate = entity.InvoiceIssuedDate,
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
                    Description = entity.Description,
                    TotalAmountWithoutVAT = entity.TotalAmountWithoutVAT,
                    TotalVATAmount = entity.TotalVATAmount,
                    TotalAmountWithVAT = entity.TotalAmountWithVAT,
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
                    new ExtNetComboBoxModel
                    {
                        Id = entity.FormTypeId,
                        Code = entity.EInvFormType.InvoiceSeries,
                        Description = entity.EInvFormType.TemplateCode
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
            return this.Direct();
        }

        public ActionResult LineEdit(int lineNo, string field, string oldValue, string newValue, string recordData,
            string headerData)
        {
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

            Store invoiceLineGridStore = X.GetCmp<Store>("InvoiceLineGridStore");
            invoiceLineGridStore.Add(newItem);

            return this.Direct(new { LineNo = lineNumber });
        }
    }
}