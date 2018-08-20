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

namespace MyERP.Web.Areas.Cash.Controllers
{
    public class CashPaymentController : EntityBaseController<MyERP.DataAccess.CashHeader, MyERP.DataAccess.EntitiesModel>
    {
        public CashPaymentController() : this(new CashHeaderRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public CashPaymentController(IBaseRepository<MyERP.DataAccess.CashHeader, MyERP.DataAccess.EntitiesModel> repository)
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
            var paging = ((CashHeaderRepository)repository).Paging(parameters, DocumentType.CashPayment);

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

            Session.Add("StoreCashPaymentList_StoreRequestParameters", parameters);

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
            long cashReceiptSequenceId = optionRepository.OptionParameter(organizationId, OptionParameter.CashPaymentSequenceId);
            if (cashReceiptSequenceId == 0)
                return this.Direct(false, "ERROR : Please set Option CashPaymentSequence first");

            ViewData["CurrencyLCYId"] = currencyLcyId;
            CurrencyRepository currencyRepository = new CurrencyRepository();
            ViewData["Currencies"] = currencyRepository.Get(filter: c => c.Id == currencyLcyId, includePaths: new string[] { "Organization" })
                .Select(x => new CurrencyLookupViewModel()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Description = x.Description,
                    OrganizationCode = x.Organization.Code,
                    Status = (DefaultStatusType)x.Status
                }).ToList();

            PreferenceViewModel preference = (PreferenceViewModel)Session["Preference"];
            var model = new CashHeaderEditViewModel()
            {
                Id = null,
                DocumentType = DocumentType.CashPayment,
                DocSubType = (byte) CashPaymentDocumentSubType.CashPayment,
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
                var entity = repository.Get(c => c.Id == _id, new string[] { "Account", "BusinessPartner", "Currency", "CashLines", "CashLines.CorrespAccount", "CashLines.BusinessPartner" }).SingleOrDefault();
                if (entity == null)
                {
                    return this.Direct(false, "Cash Header has been changed or deleted! Please check");
                }

                List<CashLineEditViewModel> cashLines = (from cashLine in entity.CashLines
                                                         select new CashLineEditViewModel()
                                                         {
                                                             Id = cashLine.Id,
                                                             LineNo = cashLine.LineNo,
                                                             CorrespAccountId = cashLine.CorrespAccountId,
                                                             CorrespAccount = new AccountLookupViewModel()
                                                             {
                                                                 Id = cashLine.CorrespAccount.Id,
                                                                 Code = cashLine.CorrespAccount.Code,
                                                                 Description = cashLine.CorrespAccount.Description,
                                                                 OrganizationCode = "",
                                                                 Status = (DefaultStatusType)cashLine.CorrespAccount.Status
                                                             },
                                                             Description = cashLine.Description,
                                                             BusinessPartnerId = cashLine.BusinessPartnerId,
                                                             BusinessPartner = new BusinessPartnerLookupViewModel()
                                                             {
                                                                 Id = cashLine.BusinessPartner.Id,
                                                                 Code = cashLine.BusinessPartner.Code,
                                                                 Description = cashLine.BusinessPartner.Description,
                                                                 OrganizationCode = "",
                                                                 Status = (DefaultStatusType)cashLine.BusinessPartner.Status
                                                             },
                                                             Amount = cashLine.Amount,
                                                             AmountLCY = cashLine.AmountLCY,
                                                             JobId = cashLine.JobId,
                                                         }).ToList();

                model = new CashHeaderEditViewModel()
                {
                    Id = entity.Id,
                    DocumentType = (DocumentType)entity.DocumentType,
                    DocSubType = entity.DocSubType,
                    DocSequenceId = entity.DocSequenceId,
                    DocumentNo = entity.DocumentNo,
                    DocumentDate = entity.DocumentDate,
                    PostingDate = entity.PostingDate,
                    CurrencyId = entity.CurrencyId,
                    CurrencyFactor = entity.CurrencyFactor,
                    BusinessPartnerId = entity.BusinessPartnerId,
                    BusinessPartnerName = entity.BusinessPartnerName,
                    BusinessPartnerAddress = entity.BusinessPartnerAddress,
                    BusinessPartnerContactName = entity.BusinessPartnerContactName,
                    AccountId = entity.AccountId,
                    Description = entity.Description,
                    CashLines = cashLines,
                    TotalAmount = entity.TotalAmount,
                    TotalAmountLCY = entity.TotalAmountLCY,
                    TotalVatAmount = entity.TotalVatAmount,
                    TotalVatAmountLCY = entity.TotalVatAmountLCY,
                    TotalPayment = entity.TotalPayment,
                    TotalPaymentLCY = entity.TotalPaymentLCY,
                    Status = (CashDocumentStatusType)entity.Status,
                    Version = entity.Version
                };

                ViewData["BusinessPartners"] = new List<Object>()
                {
                    new BusinessPartnerLookupViewModel
                    {
                        Id = entity.BusinessPartnerId,
                        Code = entity.BusinessPartner.Code,
                        Description = entity.BusinessPartner.Description
                    }
                };

                ViewData["Currencies"] = new List<Object>()
                {
                    new CurrencyLookupViewModel
                    {
                        Id = entity.CurrencyId,
                        Code = entity.Currency.Code,
                        Description = entity.Currency.Description
                    }
                };

                ViewData["Accounts"] = new List<Object>()
                {
                     new AccountLookupViewModel
                     {
                         Id = entity.AccountId,
                         Code = entity.Account.Code,
                         Description = entity.Account.Description
                     }
                };

                ViewData["CorrespAccounts"] = cashLines.GroupBy(x => new { x.CorrespAccountId }).Select(i => i.First())
                    .Select(x => new AccountLookupViewModel
                    {
                        Id = x.CorrespAccountId,
                        Code = x.CorrespAccount.Code,
                        Description = x.CorrespAccount.Description,
                    }).ToList();
            }

            return new Ext.Net.MVC.PartialViewResult() { Model = model, ViewData = ViewData };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(CashHeaderEditViewModel headerModel, String cashLinesJSON)
        {
            List<CashLineEditViewModel> cashLinesModel = JsonConvert.DeserializeObject<List<CashLineEditViewModel>>(cashLinesJSON, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });

            //Save
            ModelState.Clear();
            headerModel.CashLines = cashLinesModel;
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
                var updateCashHeader = repository.Get(c => c.Id == headerModel.Id, new string[] { "CashLines" }).SingleOrDefault();
                if (updateCashHeader == null || updateCashHeader.Version != headerModel.Version)
                {
                    return this.Direct(false, "Cash Header has been changed or deleted! Please check");
                }

                headerModel.TotalVatAmount = 0;
                headerModel.TotalVatAmountLCY = 0;
                headerModel.TotalPayment = headerModel.TotalAmount;
                headerModel.TotalPaymentLCY = headerModel.TotalAmountLCY;

                updateCashHeader.DocSequenceId = headerModel.DocSequenceId;
                updateCashHeader.DocumentNo = headerModel.DocumentNo;
                updateCashHeader.DocumentDate = headerModel.DocumentDate;
                updateCashHeader.PostingDate = headerModel.PostingDate;
                updateCashHeader.DocumentType = (byte)headerModel.DocumentType;
                updateCashHeader.DocSubType = (byte)headerModel.DocSubType;
                updateCashHeader.BusinessPartnerId = headerModel.BusinessPartnerId;
                updateCashHeader.BusinessPartnerName = headerModel.BusinessPartnerName;
                updateCashHeader.BusinessPartnerAddress = headerModel.BusinessPartnerAddress;
                updateCashHeader.BusinessPartnerContactId = null;
                updateCashHeader.BusinessPartnerContactName = headerModel.BusinessPartnerContactName;
                updateCashHeader.CurrencyId = headerModel.CurrencyId;
                updateCashHeader.CurrencyFactor = headerModel.CurrencyFactor;
                updateCashHeader.AccountId = headerModel.AccountId;
                updateCashHeader.Description = headerModel.Description;
                updateCashHeader.TotalAmount = headerModel.TotalAmount;
                updateCashHeader.TotalAmountLCY = headerModel.TotalAmountLCY;
                updateCashHeader.TotalVatAmount = headerModel.TotalVatAmount;
                updateCashHeader.TotalVatAmountLCY = headerModel.TotalVatAmountLCY;
                updateCashHeader.TotalPayment = headerModel.TotalPayment;
                updateCashHeader.TotalPaymentLCY = headerModel.TotalPaymentLCY;
                updateCashHeader.Status = (byte)headerModel.Status;
                updateCashHeader.RecModifiedAt = DateTime.Now;
                updateCashHeader.RecModifiedBy = (long)user.ProviderUserKey;
                updateCashHeader.Version++;

                foreach (var cashLineEditViewModel in cashLinesModel)
                {
                    if (cashLineEditViewModel.Id == 0 || cashLineEditViewModel.Id == null)
                        updateCashHeader.CashLines.Add(new DataAccess.CashLine()
                        {
                            ClientId = clientId,
                            OrganizationId = organizationId,
                            LineNo = cashLineEditViewModel.LineNo,
                            DocumentType = (byte)headerModel.DocumentType,
                            DocumentNo = headerModel.DocumentNo,
                            PostingDate = headerModel.PostingDate,
                            CorrespAccountId = cashLineEditViewModel.CorrespAccountId,
                            Description = cashLineEditViewModel.Description,
                            BusinessPartnerId = headerModel.DocSubType != (byte)CashPaymentDocumentSubType.CashPaymentMultiBusinessPartner ? headerModel.BusinessPartnerId : cashLineEditViewModel.BusinessPartnerId,
                            JobId = null,
                            AccountsPayableLedgerId = null,
                            AccountsReceivableLedgerId = null,
                            AccountsRPAmountConv = 0,
                            Amount = cashLineEditViewModel.Amount,
                            AmountLCY = cashLineEditViewModel.AmountLCY
                        });
                    else
                    {
                        updateCashHeader.CashLines.Where(c => c.Id == cashLineEditViewModel.Id)
                            .ForEach(x =>
                            {
                                x.LineNo = cashLineEditViewModel.LineNo;
                                x.DocumentType = (byte)headerModel.DocumentType;
                                x.DocumentNo = headerModel.DocumentNo;
                                x.PostingDate = headerModel.PostingDate;
                                x.CorrespAccountId = cashLineEditViewModel.CorrespAccountId;
                                x.Description = cashLineEditViewModel.Description;
                                x.BusinessPartnerId =
                                    headerModel.DocSubType != (byte)CashPaymentDocumentSubType.CashPaymentMultiBusinessPartner
                                        ? headerModel.BusinessPartnerId
                                        : cashLineEditViewModel.BusinessPartnerId;
                                x.JobId = null;
                                x.AccountsPayableLedgerId = null;
                                x.AccountsReceivableLedgerId = null;
                                x.AccountsRPAmountConv = 0;
                                x.Amount = cashLineEditViewModel.Amount;
                                x.AmountLCY = cashLineEditViewModel.AmountLCY;
                            });
                    }
                }

                foreach (var cashLine in updateCashHeader.CashLines.Where(x => cashLinesModel.All(u => u.Id != x.Id && u.Id != 0 && u.Id.HasValue)).ToList())
                {
                    updateCashHeader.CashLines.Remove(cashLine);
                    this.repository.DataContext.CashLines.Remove(cashLine); //this.repository.DataContext.Entry(salesPriceRemove).State = EntityState.Deleted;
                }

                try
                {
                    var updateEntity = this.repository.Update(updateCashHeader);
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

                List<DataAccess.CashLine> cashLines = cashLinesModel
                    .Select(c => new DataAccess.CashLine()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        LineNo = c.LineNo,
                        DocumentType = (byte)headerModel.DocumentType,
                        DocumentNo = headerModel.DocumentNo,
                        PostingDate = headerModel.PostingDate,
                        CorrespAccountId = c.CorrespAccountId,
                        Description = c.Description,
                        BusinessPartnerId = headerModel.DocSubType != (byte)CashPaymentDocumentSubType.CashPaymentMultiBusinessPartner ? headerModel.BusinessPartnerId : c.BusinessPartnerId,
                        JobId = null,
                        AccountsPayableLedgerId = null,
                        AccountsReceivableLedgerId = null,
                        AccountsRPAmountConv = 0,
                        Amount = c.Amount,
                        AmountLCY = c.AmountLCY
                    }).ToList();

                var newCashHeader = new DataAccess.CashHeader()
                {
                    ClientId = clientId,
                    OrganizationId = organizationId,
                    DocSequenceId = headerModel.DocSequenceId,
                    DocumentType = (byte)headerModel.DocumentType,
                    DocSubType = (byte)headerModel.DocSubType,
                    DocumentNo = headerModel.DocumentNo,
                    DocumentDate = headerModel.DocumentDate,
                    PostingDate = headerModel.PostingDate,
                    BusinessPartnerId = headerModel.BusinessPartnerId,
                    BusinessPartnerName = headerModel.BusinessPartnerName,
                    BusinessPartnerAddress = headerModel.BusinessPartnerAddress,
                    BusinessPartnerContactId = null,
                    BusinessPartnerContactName = headerModel.BusinessPartnerContactName,
                    CurrencyId = headerModel.CurrencyId,
                    CurrencyFactor = headerModel.CurrencyFactor,
                    Description = headerModel.Description,
                    AccountId = headerModel.AccountId,
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
                newCashHeader.CashLines = cashLines;
                try
                {
                    var newEntity = this.repository.AddNew(newCashHeader);
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
                var entity = repository.Get(c => c.Id == _id, new string[] { "CashLines" }).SingleOrDefault();
                if (entity == null)
                {
                    return this.Direct(false, "Cash Header not found!Please check");
                }

                using (var dbContextTransaction = this.repository.DataContext.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var cashLine in entity.CashLines.ToList())
                        {
                            entity.CashLines.Remove(cashLine);
                            this.repository.DataContext.CashLines.Remove(cashLine);  //this.repository.DataContext.Entry(salesPriceRemove).State = EntityState.Deleted;
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

        public ActionResult ChangeCurrencyFactor(CashHeaderEditViewModel model, string cashLinesJSON)
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
                                Status = (DefaultStatusType)c.Status
                            }
                        ).First();
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

        public ActionResult Print(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var _id = Convert.ToInt64(id);
            var entity = repository.Get(c => c.Id == _id, new string[] { "Account", "BusinessPartner", "Currency", "CashLines", "CashLines.CorrespAccount", "CashLines.BusinessPartner" }).SingleOrDefault();
            if (entity == null)
            {
                return this.Direct(false, "Cash Header has been changed or deleted! Please check");
            }

            var cashLines = (from cashLine in entity.CashLines
                             select new
                             {
                                 Id = cashLine.Id,
                                 LineNo = cashLine.LineNo,
                                 CorrespAccountId = cashLine.CorrespAccountId,
                                 CorrespAccountCode = cashLine.CorrespAccount.Code,
                                 Description = cashLine.Description,
                                 BusinessPartnerId = cashLine.BusinessPartnerId,
                                 BusinessPartnerCode = cashLine.BusinessPartner.Code,
                                 Amount = cashLine.Amount,
                                 AmountLCY = cashLine.AmountLCY,
                                 JobId = cashLine.JobId,
                             }).ToList();

            var headerModel = new
            {
                Id = entity.Id,
                DocumentType = (DocumentType)entity.DocumentType,
                DocSubType = (CashPaymentDocumentSubType)entity.DocSubType,
                DocSequenceId = entity.DocSequenceId,
                DocumentNo = entity.DocumentNo,
                DocumentDate = entity.DocumentDate,
                PostingDate = entity.PostingDate,
                CurrencyId = entity.CurrencyId,
                CurrencyCode = entity.Currency.Code,
                CurrencyFactor = entity.CurrencyFactor,
                BusinessPartnerId = entity.BusinessPartnerId,
                BusinessPartnerCode = entity.BusinessPartner.Code,
                BusinessPartnerName = entity.BusinessPartnerName,
                BusinessPartnerAddress = entity.BusinessPartnerAddress,
                BusinessPartnerContactName = entity.BusinessPartnerContactName,
                AccountId = entity.AccountId,
                AccountCode = entity.Account.Code,
                Description = entity.Description,
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
            report.Load(Server.MapPath("~/Resources/Reports/cashPayment_001.mrt"));

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

            var data = JObject.FromObject(new { CashHeader = headerModel, CashLines = cashLines, Client = client, T = ReportServices.ReportGlobalizedTexts() });
            report.Dictionary.Databases.Clear();
            var ds = StiJsonToDataSetConverter.GetDataSet(data);
            report.RegData("data", "", ds);
            report.Dictionary.Synchronize();
            report.Render();

            var fileName = $"cashreceipt_Id_{headerModel.Id}_No_{headerModel.DocumentNo}_{User.Identity.Name}_{DateTime.Now:yyyyMMddhhmmss}";
            report.ExportDocument(StiExportFormat.Pdf, Server.MapPath("~/Resources/printReports/") + fileName + ".pdf");
            report.SaveDocument(Server.MapPath("~/Resources/printReports/") + fileName + ".mdc");

            return this.Direct(new { FileName = fileName });
        }
    }
}