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

namespace MyERP.Web.Areas.Item.Controllers
{
    public class IndexController : EntityBaseController<MyERP.DataAccess.Item, MyERP.DataAccess.EntitiesModel>
    {
        public IndexController() : this(new ItemRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public IndexController(IBaseRepository<MyERP.DataAccess.Item, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

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
                RenderMode = RenderMode.AddTo,
                ClearContainer = true
            };
        }

        public ActionResult GetData(StoreRequestParameters parameters)
        {
            var paging = ((ItemRepository)repository).Paging(parameters);

            var data = paging.Data.Select(c => new ItemViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                Code = c.Code,
                Description = c.Description,
                BaseUomCode = c.BaseUom.Code,
                ItemGroup1Code = c.ItemGroupId1 != null ? c.ItemGroup1.Code : "",
                ItemGroup2Code = c.ItemGroupId2 != null ? c.ItemGroup2.Code : "",
                ItemGroup3Code = c.ItemGroupId3 != null ? c.ItemGroup3.Code : "",
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

        public ActionResult LookupData(StoreRequestParameters parameters, long? id = null)
        {
            if (id != null && id > 0)
            {
                var entity = repository.GetBy(c => c.Id == id);
                var data = new ItemViewModel()
                {
                    Code = entity.Code,
                    Id = entity.Id,
                    Description = entity.Description,
                    OrganizationCode = entity.Organization.Code,
                    Status = (DefaultStatusType)entity.Status
                };
                return this.Store(data, 1);
            }
            else
            {
                var paging = ((ItemRepository)repository).Paging(parameters.Start, parameters.Limit,
                    parameters.SimpleSort, parameters.SimpleSortDirection, parameters.Query);

                var data = paging.Data.Where(c => c.Status == (short)DefaultStatusType.Active)
                    .Select(c => new ItemViewModel
                    {
                        Code = c.Code,
                        Id = c.Id,
                        Description = c.Description,
                        OrganizationCode = c.Organization.Code,
                        Status = (DefaultStatusType)c.Status
                    }).ToList();
                return this.Store(data, paging.TotalRecords);
            }
        }

        [HttpGet]
        public ActionResult _Maintenance(string id = null)
        {
            var model = new ItemEditViewModel()
            {
                Id = null,
                ItemGroupId1 = null,
                ItemGroupId2 = null,
                ItemGroupId3 = null,
                Status = DefaultStatusType.Active
            };
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id, new string[] {"BaseUom", "ItemGroup1", "ItemGroup2", "ItemGroup3"}).Single();
                model = new ItemEditViewModel()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    BaseUomId = entity.BaseUomId,
                    ItemGroupId1 = entity.ItemGroupId1,
                    ItemGroupId2 = entity.ItemGroupId2,
                    ItemGroupId3 = entity.ItemGroupId3,
                    Description = entity.Description,
                    Status = (DefaultStatusType)entity.Status,
                    Version = entity.Version
                };

                ViewData["BaseUomItems"] = new List<Uom>
                {
                    new Uom()
                    {
                        Id = entity.BaseUomId,
                        Code = entity.BaseUom.Code,
                        Description = entity.BaseUom.Description
                    }
                };
                
                if (entity.ItemGroupId1.HasValue)
                {
                    ViewData["ItemGroup1Items"] = new List<ItemGroup>
                    {
                        new ItemGroup()
                        {
                            Id = entity.ItemGroupId1??0,
                            Code = entity.ItemGroup1.Code,
                            Description = entity.ItemGroup1.Description
                        }
                    };
                }
                if (entity.ItemGroupId2.HasValue)
                {
                    ViewData["ItemGroup2Items"] = new List<ItemGroup>
                    {
                        new ItemGroup()
                        {
                            Id = entity.ItemGroupId2??0,
                            Code = entity.ItemGroup2.Code,
                            Description = entity.ItemGroup2.Description
                        }
                    };
                }
                if (entity.ItemGroupId3.HasValue)
                {
                    ViewData["ItemGroup3Items"] = new List<ItemGroup>
                    {
                        new ItemGroup()
                        {
                            Id = entity.ItemGroupId3??0,
                            Code = entity.ItemGroup3.Code,
                            Description = entity.ItemGroup3.Description
                        }
                    };
                }
            }
            return new Ext.Net.MVC.PartialViewResult() { Model = model, ViewData = ViewData };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(ItemEditViewModel model)
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
                        r.ErrorMessage = "Item has been changed or deleted! Please check";
                        return r;
                    }

                    _update.Code = model.Code;
                    _update.Description = model.Description;
                    _update.BaseUomId = model.BaseUomId;
                    _update.ItemGroupId1 = model.ItemGroupId1;
                    _update.ItemGroupId2 = model.ItemGroupId2;
                    _update.ItemGroupId3 = model.ItemGroupId3;
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
                    var _newModel = new DataAccess.Item()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        Code = model.Code,
                        Description = model.Description,
                        BaseUomId = model.BaseUomId,
                        ItemGroupId1 = model.ItemGroupId1 == 0 ? null : model.ItemGroupId1,
                        ItemGroupId2 = model.ItemGroupId2 == 0 ? null : model.ItemGroupId2,
                        ItemGroupId3 = model.ItemGroupId3 == 0 ? null : model.ItemGroupId3,
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

                Store StoreItemList = X.GetCmp<Store>("StoreItemList");
                StoreItemList.Reload();
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
                    r.ErrorMessage = "Item not found! Please check";
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

                Store StoreItemList = X.GetCmp<Store>("StoreItemList");
                StoreItemList.Reload();
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }

            return this.Direct();
        }
    }
}