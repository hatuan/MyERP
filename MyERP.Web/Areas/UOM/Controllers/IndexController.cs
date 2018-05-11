using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.DataAccess;
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

            return new Ext.Net.MVC.PartialViewResult() {Model = model};
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(UOMEditViewModel model)
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
                    r.ErrorMessage = "User don't have Client or Organization. Please set";
                    return r;
                }
                bool isEdit = model.Id.HasValue;

                if (model.Id.HasValue)
                {
                    var _update = repository.GetBy(c => c.Id == model.Id);
                    if (_update == null || _update.Version != model.Version)
                    {
                        r.Success = false;
                        r.ErrorMessage = "UOM has been changed or deleted! Please check";
                        return r;
                    }

                    _update.Code = model.Code;
                    _update.Description = model.Description;
                    _update.Status = (byte) model.Status;
                    _update.RecModifiedAt = DateTime.Now;
                    _update.RecModifiedBy = (long) user.ProviderUserKey;
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
                    var _newModel = new Uom()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        Code = model.Code,
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

                Store storeUOMList = X.GetCmp<Store>("StoreUOMList");
                storeUOMList.Reload();
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
                var entity = repository.GetBy(c => c.Id == _id);
                if (entity == null)
                {
                    r.Success = false;
                    r.ErrorMessage = "UOM not found! Please check";
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

                Store StoreUOMList = X.GetCmp<Store>("StoreUOMList");
                StoreUOMList.Reload();
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }

            return this.Direct();
        }
    }
}