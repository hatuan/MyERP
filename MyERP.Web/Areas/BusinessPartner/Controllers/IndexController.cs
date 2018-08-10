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

namespace MyERP.Web.Areas.BusinessPartner.Controllers
{
    public class IndexController : EntityBaseController<MyERP.DataAccess.BusinessPartner, MyERP.DataAccess.EntitiesModel>
    {
        public IndexController() : this(new BusinessPartnerRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public IndexController(IBaseRepository<MyERP.DataAccess.BusinessPartner, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: BusinessPartner/Index
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
            var paging = ((BusinessPartnerRepository)repository).Paging(parameters);

            var data = paging.Data.Select(c => new BusinessPartnerViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                Code = c.Code,
                Description = c.Description,
                VatCode = c.VatCode,
                Address = c.Address,
                Telephone = c.Telephone,
                Mobilephone = c.Mobilephone,
                Mail = c.Mail,
                ContactName = c.ContactName,
                BusinessPartnerGroup1Code = c.BusinessPartnerGroupId1 != null ? c.BusinessPartnerGroup1.Code : "",
                BusinessPartnerGroup2Code = c.BusinessPartnerGroupId2 != null ? c.BusinessPartnerGroup2.Code : "",
                BusinessPartnerGroup3Code = c.BusinessPartnerGroupId3 != null ? c.BusinessPartnerGroup3.Code : "",
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Status = (DefaultStatusType)c.Status,
                Version = c.Version
            }).ToList();

            Session.Add("StoreBusinessPartnerList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }

        public ActionResult LookupData(StoreRequestParameters parameters, long? id = null)
        {
            if (id != null && id > 0 && String.IsNullOrEmpty(parameters.Query))
            {
                var data = repository.Get(c => c.Id == id, new []{ "Organization" }).Select(c =>
                    new BusinessPartnerLookupViewModel()
                    {
                        Code = c.Code,
                        Id = c.Id,
                        Description = c.Description,
                        Address = c.Address,
                        Telephone = c.Telephone,
                        Mobilephone = c.Mobilephone,
                        Mail = c.Mail,
                        VatCode = c.VatCode,
                        ContactName = c.ContactName,
                        OrganizationCode = c.Organization.Code,
                        Status = (DefaultStatusType)c.Status
                    });
                return this.Store(data, 1);
            }
            else
            {
                var paging = ((BusinessPartnerRepository)repository).Paging(parameters.Start, parameters.Limit,
                    parameters.SimpleSort, parameters.SimpleSortDirection, parameters.Query);

                var data = paging.Data.Where(c => c.Status == (short)DefaultStatusType.Active)
                    .Select(c => new BusinessPartnerLookupViewModel
                    {
                        Code = c.Code,
                        Id = c.Id,
                        Description = c.Description,
                        Address = c.Address,
                        Telephone = c.Telephone,
                        Mobilephone = c.Mobilephone,
                        Mail = c.Mail,
                        VatCode = c.VatCode,
                        ContactName = c.ContactName,
                        OrganizationCode = c.Organization.Code,
                        Status = (DefaultStatusType)c.Status
                    }).ToList();
                return this.Store(data, paging.TotalRecords);
            }
        }

        [HttpGet]
        public ActionResult _Maintenance(string id = null)
        {
            var model = new BusinessPartnerEditViewModel()
            {
                Id = null,
                BusinessPartnerGroupId1 = null,
                BusinessPartnerGroupId2 = null,
                BusinessPartnerGroupId3 = null,
                Status = DefaultStatusType.Active
            };
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id, new string[] { "BusinessPartnerGroup1", "BusinessPartnerGroup2", "BusinessPartnerGroup3" }).Single();
                model = new BusinessPartnerEditViewModel()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    BusinessPartnerGroupId1 = entity.BusinessPartnerGroupId1,
                    BusinessPartnerGroupId2 = entity.BusinessPartnerGroupId2,
                    BusinessPartnerGroupId3 = entity.BusinessPartnerGroupId3,
                    Description = entity.Description,
                    VatCode = entity.VatCode,
                    Address = entity.Address,
                    Telephone = entity.Telephone,
                    Mobilephone = entity.Mobilephone,
                    Mail = entity.Mail,
                    ContactName = entity.ContactName,
                    Status = (DefaultStatusType)entity.Status,
                    Version = entity.Version
                };

                if (entity.BusinessPartnerGroupId1.HasValue)
                {
                    ViewData["BusinessPartnerGroup1Items"] = new List<BusinessPartnerGroup>
                    {
                        new BusinessPartnerGroup()
                        {
                            Id = entity.BusinessPartnerGroupId1??0,
                            Code = entity.BusinessPartnerGroup1.Code,
                            Description = entity.BusinessPartnerGroup1.Description
                        }
                    };
                }
                if (entity.BusinessPartnerGroupId2.HasValue)
                {
                    ViewData["BusinessPartnerGroup2Items"] = new List<BusinessPartnerGroup>
                    {
                        new BusinessPartnerGroup()
                        {
                            Id = entity.BusinessPartnerGroupId2??0,
                            Code = entity.BusinessPartnerGroup2.Code,
                            Description = entity.BusinessPartnerGroup2.Description
                        }
                    };
                }
                if (entity.BusinessPartnerGroupId3.HasValue)
                {
                    ViewData["BusinessPartnerGroup3Items"] = new List<BusinessPartnerGroup>
                    {
                        new BusinessPartnerGroup()
                        {
                            Id = entity.BusinessPartnerGroupId3??0,
                            Code = entity.BusinessPartnerGroup3.Code,
                            Description = entity.BusinessPartnerGroup3.Description
                        }
                    };
                }
            }
            return new Ext.Net.MVC.PartialViewResult() { Model = model, ViewData = ViewData };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(BusinessPartnerEditViewModel model)
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

                    _update.Code = model.Code;
                    _update.Description = model.Description;
                    _update.VatCode = model.VatCode;
                    _update.Address = model.Address;
                    _update.Telephone = model.Telephone;
                    _update.Mobilephone = model.Mobilephone;
                    _update.Mail = model.Mail;
                    _update.ContactName = model.ContactName;
                    _update.BusinessPartnerGroupId1 = model.BusinessPartnerGroupId1;
                    _update.BusinessPartnerGroupId2 = model.BusinessPartnerGroupId2;
                    _update.BusinessPartnerGroupId3 = model.BusinessPartnerGroupId3;
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
                    var _newModel = new DataAccess.BusinessPartner()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        Code = model.Code,
                        Description = model.Description,
                        VatCode = model.VatCode,
                        Address = model.Address,
                        Telephone = model.Telephone,
                        Mobilephone = model.Mobilephone,
                        Mail = model.Mail,
                        ContactName = model.ContactName,
                        BusinessPartnerGroupId1 = model.BusinessPartnerGroupId1 == 0 ? null : model.BusinessPartnerGroupId1,
                        BusinessPartnerGroupId2 = model.BusinessPartnerGroupId2 == 0 ? null : model.BusinessPartnerGroupId2,
                        BusinessPartnerGroupId3 = model.BusinessPartnerGroupId3 == 0 ? null : model.BusinessPartnerGroupId3,
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

                Store StoreBusinessPartnerList = X.GetCmp<Store>("StoreBusinessPartnerList");
                StoreBusinessPartnerList.Reload();
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
                    r.ErrorMessage = "Business Partner not found! Please check";
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

                Store StoreBusinessPartnerList = X.GetCmp<Store>("StoreBusinessPartnerList");
                StoreBusinessPartnerList.Reload();
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }

            return this.Direct();
        }
    }
}