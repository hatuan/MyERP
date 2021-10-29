using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.DataAccess.Enum;
using MyERP.Web.Models;

namespace MyERP.Web.Controllers
{
    public class OptionController : EntityBaseController<MyERP.DataAccess.Option, MyERP.DataAccess.EntitiesModel>
    {
        public OptionController() : this(new OptionRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public OptionController(IBaseRepository<MyERP.DataAccess.Option, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: Option
        public ActionResult _Maintenance(string containerId = "MainCenterPanel")
        {
            MyERPMembershipUser user = (MyERPMembershipUser) Membership.GetUser(User.Identity.Name, true);
            long clientId = user.ClientId ?? 0;
            long organizationId = user.OrganizationId ?? 0;

            if (clientId == 0 || organizationId == 0)
            {
                return this.Direct(false, Resources.Resources.User_dont_have_Client_or_Organization_Please_set);
            }

            var organizationRepository = new OrganizationRepository();
            var organizations = (from org in organizationRepository.Get()
                    orderby org.Code
                    select new Ext.Net.ListItem
                    {
                        Text = org.Description,
                        Value = org.Id + ""
                    }
                ).ToList();

            ViewData["Organizations"] = organizations;

            var noSequenceRepository = new NoSequenceRepository();
            ViewData["NoSequences"] = noSequenceRepository.Get(includePaths: new string[] {"Organization"})
                .OrderBy(o => o.Code)
                .Select(x => new NoSequenceViewModel()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Description = x.Description,
                    OrganizationCode = x.Organization.Code,
                    Blocked = x.Blocked
                }).ToList();

            var optionRepository = new OptionRepository();
            var option = optionRepository.Get(x => x.OrganizationId == organizationId).SingleOrDefault();
            var rootOrganizationId = organizationRepository.GetRootOrganization(User).Id;

            ViewData["OrgHasOption"] = true;
            if (option == null)
            {
                ViewData["OrgHasOption"] = false;
                option = optionRepository.Get(x => x.OrganizationId == rootOrganizationId).Single();
            }
            var businessPartnerRepository = new BusinessPartnerRepository();
            ViewData["BusinessPartner"] = businessPartnerRepository.Get(filter: c => c.Id == option.OneTimeBusinessPartnerId, includePaths: new string[] { "Organization" })
                .Select(x => new BusinessPartnerLookupViewModel()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Description = x.Description,
                    OrganizationCode = x.Organization.Code,
                    Blocked = x.Blocked
                }).ToList();

            var model = new OptionEditViewModel()
            {
                Id = option.Id,
                OrganizationId = option.OrganizationId,
                RootOrganizationId = rootOrganizationId,
                OneTimeBusinessPartnerId = option.OneTimeBusinessPartnerId,
                GeneralLedgerSequenceId = option.GeneralLedgerSequenceId,
                CashReceiptSequenceId = option.CashReceiptSequenceId,
                CashPaymentSequenceId = option.CashPaymentSequenceId,
                BankReceiptSequenceId = option.BankReceiptSequenceId,
                BankCheckqueSequenceId = option.BankCheckqueSequenceId,
                PurchInvoiceSeqId = option.PurchInvoiceSeqId,
                PurchOrderSequenceId = option.PurchOrderSequenceId,
                PurchReceiveSeqId = option.PurchReceiveSeqId,
                SalesPosSequenceId = option.SalesPosSequenceId,
                SalesInvoiceSeqId = option.SalesInvoiceSeqId,
                SalesOrderSequenceId = option.SalesOrderSequenceId,
                SalesShipmentSeqId = option.SalesShipmentSeqId,
                Blocked = option.Blocked,
                Version = option.Version
            };

            return new Ext.Net.MVC.PartialViewResult
            {
                ContainerId = containerId,
                ViewName = "_Maintenance",
                WrapByScriptTag = false,
                RenderMode = RenderMode.AddTo,
                ClearContainer = true,
                Model = model,
                ViewData = ViewData
            };
        }

        [HttpPost]
        public ActionResult _Maintenance(OptionEditViewModel model)
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

                if (model.Id.HasValue)
                {
                    var _update = repository.Get(c => c.Id == model.Id).SingleOrDefault();
                    if (_update == null || _update.Version != model.Version)
                    {
                        r.Success = false;
                        r.ErrorMessage = "Option has been changed or deleted! Please check";
                        return r;               
                    }

                    _update.OneTimeBusinessPartnerId = model.OneTimeBusinessPartnerId;
                    _update.GeneralLedgerSequenceId = model.GeneralLedgerSequenceId;
                    _update.CashReceiptSequenceId = model.CashReceiptSequenceId;
                    _update.CashPaymentSequenceId = model.CashPaymentSequenceId;
                    _update.BankReceiptSequenceId = model.BankReceiptSequenceId;
                    _update.BankCheckqueSequenceId = model.BankCheckqueSequenceId;
                    _update.PurchInvoiceSeqId = model.PurchInvoiceSeqId;
                    _update.PurchOrderSequenceId = model.PurchOrderSequenceId;
                    _update.PurchReceiveSeqId = model.PurchReceiveSeqId;
                    _update.SalesOrderSequenceId = model.SalesOrderSequenceId;
                    _update.SalesInvoiceSeqId = model.SalesInvoiceSeqId;
                    _update.SalesPosSequenceId = model.SalesPosSequenceId;
                    _update.SalesShipmentSeqId = model.SalesShipmentSeqId;
                    _update.Blocked = model.Blocked;
                    _update.RecModifiedAt = DateTime.Now;
                    _update.RecModifiedBy = (long)user.ProviderUserKey;
                    _update.Version++;

                    try
                    {
                        var entity = this.repository.Update(_update);
                        model.Version = entity.Version;
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
                    var _newModel = new DataAccess.Option()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        OneTimeBusinessPartnerId = model.OneTimeBusinessPartnerId,
                        GeneralLedgerSequenceId = model.GeneralLedgerSequenceId,
                        CashReceiptSequenceId = model.CashReceiptSequenceId,
                        CashPaymentSequenceId = model.CashPaymentSequenceId,
                        BankReceiptSequenceId = model.BankReceiptSequenceId,
                        BankCheckqueSequenceId = model.BankCheckqueSequenceId,
                        PurchInvoiceSeqId = model.PurchInvoiceSeqId,
                        PurchOrderSequenceId = model.PurchOrderSequenceId,
                        PurchReceiveSeqId = model.PurchReceiveSeqId,
                        SalesOrderSequenceId = model.SalesOrderSequenceId,
                        SalesInvoiceSeqId = model.SalesInvoiceSeqId,
                        SalesPosSequenceId = model.SalesPosSequenceId,
                        SalesShipmentSeqId = model.SalesShipmentSeqId,
                        Blocked = model.Blocked,
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
                r.Success = true;
                r.Result = new {Id = model.Id, Version = model.Version};
                return r;
            }
            r.Success = false;
            return r;
        }

        public ActionResult GetData(StoreRequestParameters parameters)
        {
            var paging = ((OptionRepository)repository).Paging(parameters);

            var data = paging.Data.Select(c => new OptionViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Blocked = c.Blocked,
                Version = c.Version
            }).ToList();

            Session.Add("StoreOptionList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            DirectResult r = new DirectResult();
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id, new [] { "Organization" }).SingleOrDefault();
                if (entity == null)
                {
                    r.Success = false;
                    r.ErrorMessage = "Option not found! Please check";
                    return r;
                }

                if (entity.Organization.Code == "*")
                {
                    r.Success = false;
                    r.ErrorMessage = "Can not delete Option of Root Organization! Please check";
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
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }

            return this.Direct();
        }
    }
}