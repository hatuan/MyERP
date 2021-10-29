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
using MyERP.Web.Models;

namespace MyERP.Web.Controllers
{
    public class CurrencyController : EntityBaseController<MyERP.DataAccess.Currency, MyERP.DataAccess.EntitiesModel>
    {
        /// <summary>
        /// Constructor used by the Controller.
        /// </summary>
        public CurrencyController() : this(new CurrencyRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public CurrencyController(IBaseRepository<MyERP.DataAccess.Currency, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: Currence
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
            var paging = ((CurrencyRepository)repository).Paging(parameters);

            var data = paging.Data.Select(c => new CurrencyViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                Code = c.Code,
                Description = c.Description,
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Blocked = c.Blocked,
                Version = c.Version
            }).ToList();

            Session.Add("StoreCurrencyList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }

        public ActionResult LookupData(StoreRequestParameters parameters, long? id = null)
        {
            if (id != null && id > 0)
            {
                var entity = repository.Get(c => c.Id == id, new[] { "Organization" }).SingleOrDefault();
                var data = new CurrencyViewModel()
                {
                    Code = entity.Code,
                    Id = entity.Id,
                    Description = entity.Description,
                    OrganizationCode = entity.Organization.Code,
                    Blocked = entity.Blocked
                };
                return this.Store(data, 1);
            }
            else
            {
                var paging = ((CurrencyRepository)repository).Paging(parameters.Start, parameters.Limit,
                    parameters.SimpleSort, parameters.SimpleSortDirection, parameters.Query);

                var data = paging.Data.Where(c => c.Blocked == false)
                    .Select(c => new CurrencyViewModel
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

        [HttpGet]
        public ActionResult _Maintenance(string id = null)
        {
            var model = new CurrencyEditViewModel()
            {
                Id = null,
                Blocked = false
            };
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id).Single();
                model = new CurrencyEditViewModel()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Description,
                    Blocked = entity.Blocked,
                    Version = entity.Version
                };
            }
            return new Ext.Net.MVC.PartialViewResult() { Model = model, ViewData = ViewData };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(CurrencyEditViewModel model)
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
                        r.ErrorMessage = Resources.Resources.Currency_has_been_changed_or_deleted_Please_check;
                        return r;
                    }

                    _update.Code = model.Code;
                    _update.Description = model.Description;
                    _update.Blocked = model.Blocked;
                    _update.RecModifiedAt = DateTime.Now;
                    _update.RecModifiedBy = (long)user.ProviderUserKey;
                    _update.Version++;

                    try
                    {
                        var entity = this.repository.Update(_update);
                        model.Id = entity.Id;
                        model.Version = entity.Version;
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
                    var _newModel = new DataAccess.Currency()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        Code = model.Code,
                        Description = model.Description,
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
                        model.Version = newEntity.Version;
                    }
                    catch (Exception ex)
                    {
                        r.Success = false;
                        r.ErrorMessage = ex.Message;
                        return r;
                    }
                }
                
                r.Success = true;
                r.Result = new { Id = model.Id, Version = model.Version };
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
                    r.ErrorMessage = Resources.Resources.Currency_has_been_changed_or_deleted_Please_check;
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