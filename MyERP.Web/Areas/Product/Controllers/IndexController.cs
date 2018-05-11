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

namespace MyERP.Web.Areas.Product.Controllers
{
    public class IndexController : EntityBaseController<MyERP.DataAccess.Product, MyERP.DataAccess.EntitiesModel>
    {
        // GET: Product/Index
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
            var paging = ((ProductRepository)repository).ProductsPaging(parameters);

            var data = paging.Data.Select(c => new UOMViewModel
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

            Session.Add("StoreProductList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }

        [HttpGet]
        public ActionResult _Maintenance(string id = null)
        {
            var model = new UOMEditViewModel()
            {
                Id = null,
                Status = DefaultStatusType.Active
            };
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var uom = repository.GetBy(c => c.Id == _id);
                model = new UOMEditViewModel()
                {
                    Id = uom.Id,
                    Code = uom.Code,
                    Description = uom.Description,
                    Status = (DefaultStatusType)uom.Status,
                    Version = uom.Version
                };
            }

            return new Ext.Net.MVC.PartialViewResult() { Model = model };
        }
    }
}