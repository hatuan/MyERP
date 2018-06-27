using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult _Maintenance(string containerId = "IndexViewport")
        {
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

            return new Ext.Net.MVC.PartialViewResult
            {
                ContainerId = containerId,
                ViewName = "_Maintenance",
                WrapByScriptTag = false,
                RenderMode = RenderMode.AddTo,
                ViewData = ViewData
            };
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
    }
}