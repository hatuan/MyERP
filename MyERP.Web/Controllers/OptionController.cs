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
                return this.Direct(false, "User don't have Client or Organization. Please set");
            }

            var organizationRepository = new OrganizationRepository();
            var organizations = (from org in organizationRepository.Get()
                    orderby org.Code
                    select new Ext.Net.ListItem
                    {
                        Text = org.Desctiption,
                        Value = org.Id + ""
                    }
                ).ToList();

            ViewData["Organizations"] = organizations;

            var noSequenceRepository = new NoSequenceRepository();
            ViewData["NoSequences"] = noSequenceRepository.Get(filter: c => c.Status == (short)DefaultStatusType.Active, includePaths: new string[] {"Organization"})
                .OrderBy(o => o.Code)
                .Select(x => new NoSequenceViewModel()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Description = x.Description,
                    OrganizationCode = x.Organization.Code,
                    Status = (DefaultStatusType)x.Status
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

            var model = new OptionEditViewModel()
            {
                Id = option.Id,
                OrganizationId = option.OrganizationId,
                RootOrganizationId = rootOrganizationId,
                PurchInvoiceSeqId = option.PurchInvoiceSeqId,
                PurchOrderSequenceId = option.PurchOrderSequenceId,
                PurchReceiveSeqId = option.PurchReceiveSeqId,
                SalesPosSequenceId = option.SalesPosSequenceId,
                SaleInvoiceSeqId = option.SaleInvoiceSeqId,
                SalesOrderSequenceId = option.SalesOrderSequenceId,
                SalesShipmentSeqId = option.SalesShipmentSeqId,
                Status = (DefaultStatusType) option.Status,
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
            return this.Direct();
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
                Status = (DefaultStatusType)c.Status,
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