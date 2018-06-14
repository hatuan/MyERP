﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.DataAccess.Enum;
using MyERP.Web.Controllers;
using MyERP.Web.Models;

namespace MyERP.Web.Areas.BusinessPartner.Controllers
{
    public class BusinessPartnerGroupController : EntityBaseController<MyERP.DataAccess.BusinessPartnerGroup, MyERP.DataAccess.EntitiesModel>
    {
        public BusinessPartnerGroupController() : this(new BusinessPartnerGroupRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public BusinessPartnerGroupController(IBaseRepository<MyERP.DataAccess.BusinessPartnerGroup, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: BusinessPartner/BusinessPartnerGroup
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
            var paging = ((BusinessPartnerGroupRepository)repository).Paging(parameters);

            var data = paging.Data.Select(c => new BusinessPartnerGroupViewModel
            {
                Id = c.Id,
                Level = c.Level,
                Code = c.Code,
                Description = c.Description,
                OrganizationCode = c.Organization.Code,
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Status = (DefaultStatusType)c.Status,
                Version = c.Version
            }).ToList();

            Session.Add("StoreBusinessPartnerGroupList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }

        public ActionResult LookupData(StoreRequestParameters parameters, byte level, long? id = null)
        {
            if (id != null && id > 0)
            {
                var entity = repository.Get(c => c.Id == id, new string[] { "Organization" }).Single();
                var data = new BusinessPartnerGroupViewModel()
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
                var paging = ((BusinessPartnerGroupRepository)repository).Paging(parameters.Start, parameters.Limit,
                    parameters.SimpleSort, parameters.SimpleSortDirection, parameters.Query);

                var data = paging.Data.Where(c => c.Status == (short)DefaultStatusType.Active && c.Level == level)
                    .Select(c => new BusinessPartnerGroupViewModel
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
            var model = new BusinessPartnerGroupEditViewModel()
            {
                Id = null,
                Status = DefaultStatusType.Active
            };
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id).Single();
                model = new BusinessPartnerGroupEditViewModel()
                {
                    Id = entity.Id,
                    Level = entity.Level,
                    Code = entity.Code,
                    Description = entity.Description,
                    Status = (DefaultStatusType)entity.Status,
                    Version = entity.Version
                };
            }

            return new Ext.Net.MVC.PartialViewResult() { Model = model };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(BusinessPartnerGroupEditViewModel model)
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
                    var _update = repository.Get(c => c.Id == model.Id).SingleOrDefault();
                    if (_update == null || _update.Version != model.Version)
                    {
                        r.Success = false;
                        r.ErrorMessage = "Business Partner Group has been changed or deleted! Please check";
                        return r;
                    }
                    _update.Level = (byte)model.Level;
                    _update.Code = model.Code;
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
                    var _newModel = new DataAccess.BusinessPartnerGroup()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        Level = (byte)model.Level,
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

                Store StoreBusinessPartnerGroupList = X.GetCmp<Store>("StoreBusinessPartnerGroupList");
                StoreBusinessPartnerGroupList.Reload();
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
                    r.ErrorMessage = "Business Partner Group not found! Please check";
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

                Store StoreBusinessPartnerGroupList = X.GetCmp<Store>("StoreBusinessPartnerGroupList");
                StoreBusinessPartnerGroupList.Reload();
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }

            return this.Direct();
        }
    }
}