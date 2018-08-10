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

namespace MyERP.Web.Areas.Account.Controllers
{
    public class IndexController : EntityBaseController<MyERP.DataAccess.Account, MyERP.DataAccess.EntitiesModel>
    {
        public IndexController() : this(new AccountRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public IndexController(IBaseRepository<MyERP.DataAccess.Account, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: Account/Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LookupData(StoreRequestParameters parameters, long? id = null)
        {
            if (id != null && id > 0 && String.IsNullOrEmpty(parameters.Query))
            {
                var data = repository.Get(c => c.Id == id, new string[] { "Organization" }).Select(c => 
                    new AccountLookupViewModel()
                    {
                        Code = c.Code,
                        Id = c.Id,
                        Description = c.Description,
                        OrganizationCode = c.Organization.Code,
                        Status = (DefaultStatusType)c.Status
                    }).ToList();
                return this.Store(data, 1);
            }
            else
            {
                var paging = ((AccountRepository)repository).Paging(parameters.Start, parameters.Limit,
                    parameters.SimpleSort, parameters.SimpleSortDirection, parameters.Query);

                var data = paging.Data.Where(c => c.Status == (short)DefaultStatusType.Active).Select(c =>
                    new AccountLookupViewModel
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