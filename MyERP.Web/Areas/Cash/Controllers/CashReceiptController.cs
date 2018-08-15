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

namespace MyERP.Web.Areas.Cash.Controllers
{
    public class CashReceiptController : EntityBaseController<MyERP.DataAccess.CashHeader, MyERP.DataAccess.EntitiesModel>
    {
        public CashReceiptController() : this(new CashHeaderRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public CashReceiptController(IBaseRepository<MyERP.DataAccess.CashHeader, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: Cash/CashReceipt
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
            var paging = ((CashHeaderRepository)repository).Paging(parameters);

            var data = paging.Data.Select(c => new CashHeaderViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                DocumentNo = c.DocumentNo,
                DocumentDate = c.DocumentDate,
                AccountCode = c.Account.Code,
                Description = c.Description,
                BusinessPartnerCode = c.BusinessPartner.Code,
                BusinessPartnerName = c.BusinessPartnerName,
                BusinessPartnerAddress = c.BusinessPartnerAddress,
                BusinessPartnerContactName = c.BusinessPartnerContactName,
                TotalAmount = c.TotalAmount,
                TotalVatAmount = c.TotalVatAmount,
                TotalPayment = c.TotalPayment,
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Status = (CashDocumentStatusType)c.Status,
                Version = c.Version
            }).ToList();

            Session.Add("StoreCashReceiptList_StoreRequestParameters", parameters);

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
            long cashReceiptSequenceId = optionRepository.OptionParameter(organizationId, OptionParameter.CashReceiptSequenceId);
            if (cashReceiptSequenceId == 0)
                return this.Direct(false, "ERROR : Please set Option CashReceiptSequence first");

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

            PreferenceViewModel preference = (PreferenceViewModel) Session["Preference"];
            var model = new CashHeaderEditViewModel()
            {
                Id = null,
                DocSubType = CashReceiptDocumentSubType.CashReceipt,
                DocSequenceId = cashReceiptSequenceId,
                DocumentDate = preference.WorkingDate,
                PostingDate = preference.WorkingDate,
                CurrencyId = currencyLcyId,
                CurrencyFactor = 1,
                CashLines = new List<CashLineEditViewModel>(),
                Status = CashDocumentStatusType.Draft
            };

            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id, new string[] {"CashLines"}).SingleOrDefault();

                List<CashLineEditViewModel> cashLines = new List<CashLineEditViewModel>();

                model = new CashHeaderEditViewModel()
                {
                    Id = entity.Id,
                    Description = entity.Description,
                    CashLines = cashLines,
                    Status = (CashDocumentStatusType)entity.Status,
                    Version = entity.Version
                };
            }

            return new Ext.Net.MVC.PartialViewResult() { Model = model, ViewData = ViewData };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(CashHeaderEditViewModel model, String cashLineJSON)
        {
            DirectResult r = new DirectResult();

            if (ModelState.IsValid)
            {
                MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
                long clientId = user.ClientId ?? 0;
                long organizationId = user.OrganizationId ?? 0;

                if (clientId == 0 || organizationId == 0)
                {
                    r.Success = false;
                    r.ErrorMessage = Resources.Resources.User_dont_have_Client_or_Organization_Please_set;
                    return r;
                }
                bool isEdit = model.Id.HasValue;

                if (model.Id.HasValue)
                {
                    var _update = repository.Get(c => c.Id == model.Id).SingleOrDefault();
                    if (_update == null || _update.Version != model.Version)
                    {
                        r.Success = false;
                        r.ErrorMessage = "Item has been changed or deleted! Please check";
                        return r;
                    }
                    _update.Description = model.Description;
                    _update.Status = (byte)model.Status;
                    _update.RecModifiedAt = DateTime.Now;
                    _update.RecModifiedBy = (long)user.ProviderUserKey;
                    _update.Version++;

                    try
                    {
                        this.repository.Update(_update);
                    }
                    catch (Exception ex)
                    {
                        r.Success = false;
                        r.ErrorMessage = ex.Message;
                        return r;
                    }

                }
                else
                {
                    var _newModel = new DataAccess.CashHeader()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        Description = model.Description,
                        Status = (byte)model.Status,
                        Version = 1,
                        RecModifiedAt = DateTime.Now,
                        RecCreatedBy = (long)user.ProviderUserKey,
                        RecCreatedAt = DateTime.Now,
                        RecModifiedBy = (long)user.ProviderUserKey
                    };

                    try
                    {
                        var newEntity = this.repository.AddNew(_newModel);
                        model.Id = newEntity.Id;
                    }
                    catch (Exception ex)
                    {
                        r.Success = false;
                        r.ErrorMessage = ex.Message;
                        return r;
                    }
                }

                Store StoreCashReceiptList = X.GetCmp<Store>("StoreCashReceiptList");
                StoreCashReceiptList.Reload();
                r.Success = true;
                return r;
            }
            r.Success = false;
            return r;
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            DirectResult r = new DirectResult();
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id).SingleOrDefault();
                if (entity == null)
                {
                    r.Success = false;
                    r.ErrorMessage = "ItemGroup not found! Please check";
                    return r;
                }

                try
                {
                    this.repository.Delete(entity);
                }
                catch (Exception e)
                {
                    r.Success = false;
                    r.ErrorMessage = e.Message;
                    return r;
                }

                Store StoreCashReceiptList = X.GetCmp<Store>("StoreCashReceiptList");
                StoreCashReceiptList.Reload();
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
            this.GetCmp<TextField>("BusinessPartnerAddress").Value = selectedPartner.Address;
            this.GetCmp<TextField>("BusinessPartnerContactName").Value = selectedPartner.ContactName;
            
            return this.Direct();
        }

        public ActionResult ChangeCurrency(string selectedData)
        {
            CurrencyLookupViewModel selectedCurrency = JsonConvert.DeserializeObject<CurrencyLookupViewModel>(selectedData, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });

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
            

            this.GetCmp<TextField>("CurrencyFactor").Value = selectedCurrency.Id == currencyLcyId ? 1 : 1;
            this.GetCmp<TextField>("CurrencyFactor").ReadOnly = selectedCurrency.Id == currencyLcyId;
            this.GetCmp<Column>("CashLineAmountLCYCol").Hidden = selectedCurrency.Id == currencyLcyId;

            return this.Direct();
        }

        public ActionResult AddLine(String cashLinesJSON)
        {
            List<CashLineEditViewModel> cashLinesModel = JsonConvert.DeserializeObject<List<CashLineEditViewModel>>(cashLinesJSON);
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

            CashHeaderEditViewModel cashHeaderEditViewModel = JSON.Deserialize<CashHeaderEditViewModel>(headerData, new JsonSerializerSettings
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
                                Status = (DefaultStatusType) c.Status
                            }
                        ).First();
                    record.Set("CorrespAccountCode", corespAcc.Code);
                    record.Set("CorrespAccount", corespAcc);
                    //TODO: Update CorrespAccountStore
                    //Store correspAccountStore = X.GetCmp<Store>("CorrespAccountStore");
                    //correspAccountStore.Add(corespAcc);
                    break;
                case "Amount":
                    var amountLCY = Round.RoundAmountLCY(cashLineEditViewModel.Amount * cashHeaderEditViewModel.CurrencyFactor);
                    record.Set("AmountLCY", amountLCY);
                    break;
            }
            record.Commit();
            return this.Direct();
        }
    }
}