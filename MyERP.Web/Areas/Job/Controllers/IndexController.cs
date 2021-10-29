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

namespace MyERP.Web.Areas.Job.Controllers
{
    public class IndexController : EntityBaseController<MyERP.DataAccess.Job, MyERP.DataAccess.EntitiesModel>
    {
        public IndexController() : this(new JobRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public IndexController(IBaseRepository<MyERP.DataAccess.Job, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: Job/Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LookupData(StoreRequestParameters parameters, long? id = null)
        {
            if (id != null && id > 0)
            {
                var data = repository.Get(c => c.Id == id, new[] { "Organization" }).Select(c =>
                    new JobLookupViewModel()
                    {
                        Code = c.Code,
                        Id = c.Id,
                        Description = c.Description,
                        OrganizationCode = c.Organization.Code,
                        Blocked = c.Blocked
                    });
                return this.Store(data, 1);
            }
            else
            {
                var paging = ((JobRepository)repository).Paging(parameters.Start, parameters.Limit,
                    parameters.SimpleSort, parameters.SimpleSortDirection, parameters.Query);

                var data = paging.Data.Where(c => c.Blocked == false)
                    .Select(c => new JobLookupViewModel
                    {
                        Code = c.Code,
                        Id = c.Id,
                        Description = c.Description,
                        OrganizationCode = c.Organization.Code,
                        Blocked = c.Blocked
                    }).ToList();
                return this.Store(data, paging.TotalRecords);
            }
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
            var paging = ((JobRepository)repository).Paging(parameters);

            var data = paging.Data.Select(c => new JobViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                Code = c.Code,
                Description = c.Description,
                JobGroup1Code = c.JobGroupId1 != null ? c.JobGroup1.Code : "",
                JobGroup2Code = c.JobGroupId2 != null ? c.JobGroup2.Code : "",
                JobGroup3Code = c.JobGroupId3 != null ? c.JobGroup3.Code : "",
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Blocked = c.Blocked,
                Version = c.Version
            }).ToList();

            Session.Add("StoreJobList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }
        [HttpGet]
        public ActionResult _Maintenance(string id = null)
        {
            var model = new JobEditViewModel()
            {
                Id = null,
                JobGroupId1 = null,
                JobGroupId2 = null,
                JobGroupId3 = null,
                Blocked = false
            };
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id, new string[] { "JobGroup1", "JobGroup2", "JobGroup3" }).Single();
                model = new JobEditViewModel()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    JobGroupId1 = entity.JobGroupId1,
                    JobGroupId2 = entity.JobGroupId2,
                    JobGroupId3 = entity.JobGroupId3,
                    Description = entity.Description,

                    Blocked = entity.Blocked,
                    Version = entity.Version
                };

                if (entity.JobGroupId1.HasValue)
                {
                    ViewData["JobGroup1Items"] = new List<JobGroup>
                    {
                        new JobGroup()
                        {
                            Id = entity.JobGroupId1??0,
                            Code = entity.JobGroup1.Code,
                            Description = entity.JobGroup1.Description
                        }
                    };
                }
                if (entity.JobGroupId2.HasValue)
                {
                    ViewData["JobGroup2Items"] = new List<JobGroup>
                    {
                        new JobGroup()
                        {
                            Id = entity.JobGroupId2??0,
                            Code = entity.JobGroup2.Code,
                            Description = entity.JobGroup2.Description
                        }
                    };
                }
                if (entity.JobGroupId3.HasValue)
                {
                    ViewData["JobGroup3Items"] = new List<JobGroup>
                    {
                        new JobGroup()
                        {
                            Id = entity.JobGroupId3??0,
                            Code = entity.JobGroup3.Code,
                            Description = entity.JobGroup3.Description
                        }
                    };
                }
            }
            return new Ext.Net.MVC.PartialViewResult() { Model = model, ViewData = ViewData };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(JobEditViewModel model)
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
                    _update.JobGroupId1 = model.JobGroupId1;
                    _update.JobGroupId2 = model.JobGroupId2;
                    _update.JobGroupId3 = model.JobGroupId3;
                    _update.Blocked = model.Blocked;
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
                    var _newModel = new DataAccess.Job()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        Code = model.Code,
                        Description = model.Description,
                        JobGroupId1 = model.JobGroupId1 == 0 ? null : model.JobGroupId1,
                        JobGroupId2 = model.JobGroupId2 == 0 ? null : model.JobGroupId2,
                        JobGroupId3 = model.JobGroupId3 == 0 ? null : model.JobGroupId3,
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
                r.Result = new { Id = model.Id };
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
                    r.ErrorMessage = "Job not found! Please check";
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