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
        public ActionResult Index(List<VatEntryEditViewModel> model, bool documentCurrencyIsLCY)
        {
            ViewData["CurrencyIsLCY"] = documentCurrencyIsLCY;

            /*
            return new Ext.Net.MVC.PartialViewResult
            {
                RenderMode = RenderMode.AddTo,
                ContainerId = containerId,
                ClearContainer = true,
                Model = new List<VatEntryEditViewModel>(),
                ViewData = ViewData,
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            };
            */
            return PartialView(model);
        }

        public ActionResult AddLine(string headerJSON, string vatEntriesJSON)
        {
            CurrencyHeaderViewModel currencyHeaderViewModel = JSON.Deserialize<CurrencyHeaderViewModel>(headerJSON, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });

            List<VatEntryEditViewModel> vatEntriesModel = JsonConvert.DeserializeObject<List<VatEntryEditViewModel>>(vatEntriesJSON, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });
            long lineNo = vatEntriesModel.Count >= 1 ? vatEntriesModel.Max(c => c.LineNo) + 1000 : 1000;

            var newItem = new VatEntryEditViewModel()
            {
                Id = null,
                CurrencyId = currencyHeaderViewModel.CurrencyId,
                CurrencyFactor = currencyHeaderViewModel.CurrencyFactor,
                LineNo = lineNo
            };

            Store vatEntryGridStore = X.GetCmp<Store>("VatEntryGridStore");
            vatEntryGridStore.Add(newItem);

            return this.Direct(new { LineNo = lineNo });
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

            PurchaseInvoiceHeaderEditViewModel purchaseInvoiceHeaderEditViewModel = JSON.Deserialize<PurchaseInvoiceHeaderEditViewModel>(headerData, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });

            VatEntryEditViewModel vatEntryViewModel = JSON.Deserialize<VatEntryEditViewModel>(recordData, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });

            ModelProxy record = X.GetCmp<Store>("VatEntryGridStore").GetById(lineNo);

            switch (field)
            {
                case "BusinessPartnerId":
                    {
                        var businessPartnerRepository = new BusinessPartnerRepository();
                        var businessPartnerId = Convert.ToInt64(newValue);
                        var businessPartner = businessPartnerRepository.Get(c => c.Id == businessPartnerId, new string[] { "Organization" }).First();
                        var businessPartnerModel = new LookupViewModel()
                        {
                            Id = businessPartner.Id,
                            Code = businessPartner.Code,
                            Description = businessPartner.Description,
                            OrganizationCode = businessPartner.Organization.Code,
                            Status = (DefaultStatusType)businessPartner.Status
                        };

                        record.Set("BusinessPartner", businessPartnerModel);
                        record.Set("BusinessPartnerName", businessPartner.Description);
                        record.Set("BusinessPartnerAddress", businessPartner.Address);
                        record.Set("TaxCode", businessPartner.TaxCode);
                        break;
                    }
                case "AccountVatId":
                {
                    var accountRepository = new AccountRepository();
                    var accountVatId = Convert.ToInt64(newValue);
                    var accountVat = accountRepository.Get(c => c.Id == accountVatId, new string[] { "Organization" }).First();
                    var accountVatModel = new LookupViewModel()
                    {
                        Id = accountVat.Id,
                        Code = accountVat.Code,
                        Description = accountVat.Description,
                        OrganizationCode = accountVat.Organization.Code,
                        Status = (DefaultStatusType)accountVat.Status
                    };

                    record.Set("AccountVat", accountVatModel);
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
                            Status = (DefaultStatusType)vat.Status
                        };

                        record.Set("Vat", vatModel);
                        record.Set("VatPercentage", vat.VatPercentage);

                        vatEntryViewModel.VatId = vat.Id;
                        vatEntryViewModel.VatPercentage = vat.VatPercentage;

                        var vatEntryRepository = new VatEntryRepository();
                        vatEntryRepository.Update("VatPercentage", currencyLcyId, ref vatEntryViewModel);

                        vatEntryRepository.UpdateRecord(vatEntryViewModel, ref record);
                        break;
                    }
                case "VatBaseAmount":
                case "VatBaseAmountLCY":
                case "VatPercentage":
                case "VatAmount":
                case "VatAmountLCY":
                    {
                        var vatEntryRepository = new VatEntryRepository();
                        vatEntryRepository.Update(field, currencyLcyId, ref vatEntryViewModel);

                        vatEntryRepository.UpdateRecord(vatEntryViewModel, ref record);
                        break;
                    }
            }
            record.Commit();
            return this.Direct();
        }

    }
}