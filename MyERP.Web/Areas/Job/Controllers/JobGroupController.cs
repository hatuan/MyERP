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

namespace MyERP.Web.Areas.Job.Controllers
{
    public class JobGroupController : EntityBaseController<MyERP.DataAccess.JobGroup, MyERP.DataAccess.EntitiesModel>
    {
        public JobGroupController() : this(new JobGroupRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public JobGroupController(IBaseRepository<MyERP.DataAccess.JobGroup, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: Job/JobGroup
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LookupData(StoreRequestParameters parameters, long? id = null)
        {
            if (id != null && id > 0)
            {
                var data = repository.Get(c => c.Id == id, new[] { "Organization" }).Select(c =>
                    new JobGroupLookupViewModel()
                    {
                        Code = c.Code,
                        Id = c.Id,
                        Description = c.Description,
                        OrganizationCode = c.Organization.Code,
                        Status = (DefaultStatusType)c.Status
                    });
                return this.Store(data, 1);
            }
            else
            {
                var paging = ((JobGroupRepository)repository).Paging(parameters.Start, parameters.Limit,
                    parameters.SimpleSort, parameters.SimpleSortDirection, parameters.Query);

                var data = paging.Data.Where(c => c.Status == (short)DefaultStatusType.Active)
                    .Select(c => new JobGroupLookupViewModel
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
    }
}