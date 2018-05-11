using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.DataAccess.Enum;
using MyERP.Web.Controllers;
using MyERP.Web.Models;

namespace MyERP.Web.Areas.UOM.Controllers
{
    public class IndexController : EntityBaseController<MyERP.DataAccess.Uom, MyERP.DataAccess.EntitiesModel>
    {
        public IndexController() : this(new UomRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public IndexController(IBaseRepository<MyERP.DataAccess.Uom, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: UOM/Index
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
                RenderMode = RenderMode.Replace
            };
        }

        public ActionResult GetData(StoreRequestParameters parameters)
        {
            var paging = ((UomRepository) repository).UomsPaging(parameters);

            var data = paging.Data.Select( c=> new UOMViewModel
            {
                Code = c.Code,
                Id = c.Id,
                Description = c.Description,
                OrganizationCode = c.Organization.Code,
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Status = (DefaultStatusType)c.Status,
                Version = c.Version
            }).ToList();

            return this.Store(data, paging.TotalRecords);
        }

        [HttpGet]
        public ActionResult _Maintenance(string id)
        {
            var model = new UOMEditViewModel()
            {
                Status = DefaultStatusType.Active
            };
            //if (!String.IsNullOrEmpty(id))
            //{
                var id64 = 2;
                var uom = repository.GetBy(c => c.Id == id64);
                model = new UOMEditViewModel()
                {
                    Id = uom.Id,
                    Code = uom.Code,
                    Description = uom.Description,
                    Status = (DefaultStatusType)uom.Status,
                    Version = uom.Version
                };
            //}

            return new Ext.Net.MVC.PartialViewResult() {Model = model};
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(UOMEditViewModel model)
        {
            DirectResult r = new DirectResult();
            r.Success = false;
            return r;
        }
    }
}