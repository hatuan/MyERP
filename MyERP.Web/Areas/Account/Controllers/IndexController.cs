using System;
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
            var paging = ((AccountRepository) repository).Paging(parameters);

            var data = paging.Data.Select(c => new AccountViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                Code = c.Code,
                Description = c.Description,
                ParentCode = c.Parent?.Code,
                CurrencyCode = c.Currency?.Code,
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Blocked = c.Blocked,
                Version = c.Version
            }).ToList();

            Session.Add("StoreAccountList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }

        public ActionResult LookupData(StoreRequestParameters parameters, long? id = null)
        {
            if (id != null && id > 0 && String.IsNullOrEmpty(parameters.Query))
            {
                var data = repository.Get(c => c.Id == id, new string[] {"Organization"}).Select(c =>
                    new AccountLookupViewModel()
                    {
                        Code = c.Code,
                        Id = c.Id,
                        Description = c.Description,
                        OrganizationCode = c.Organization.Code,
                        Blocked = c.Blocked
                    }).ToList();
                return this.Store(data, 1);
            }
            else
            {
                var paging = ((AccountRepository) repository).Paging(parameters.Start, parameters.Limit,
                    parameters.SimpleSort, parameters.SimpleSortDirection, parameters.Query);

                var data = paging.Data.Where(c => c.Blocked == false).Select(c =>
                    new AccountLookupViewModel
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
            var model = new AccountEditViewModel()
            {
                Id = null,
                Blocked = false
            };
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id, new string[] { "Parent", "Currency" }).Single();
                model = new AccountEditViewModel()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Description,
                    CurrencyId = entity.CurrencyId,
                    ParentId = entity.ParentId,
                    Blocked = entity.Blocked,
                    Version = entity.Version
                };

                if (entity.CurrencyId.HasValue)
                {
                    ViewData["CurrencyStore"] = new List<Object>
                    {
                        new CurrencyLookupViewModel()
                        {
                            Id = entity.CurrencyId??0,
                            Code = entity.Currency.Code,
                            Description = entity.Currency.Description
                        }
                    };
                }

                if (entity.ParentId.HasValue)
                {
                    ViewData["ParentStore"] = new List<Object>
                    {
                        new AccountLookupViewModel()
                        {
                            Id = entity.ParentId??0,
                            Code = entity.Parent.Code,
                            Description = entity.Parent.Description
                        }
                    };
                }

            }

            return new Ext.Net.MVC.PartialViewResult() { Model = model, ViewData = ViewData};
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(AccountEditViewModel model)
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
                    var _update = repository.Get(c => c.Id == model.Id, new string[] { "Parent", "Currency" }).SingleOrDefault();
                    if (_update == null || _update.Version != model.Version)
                    {
                        r.Success = false;
                        r.ErrorMessage = "Account has been changed or deleted! Please check";
                        return r;
                    }
                    _update.Code = model.Code;
                    _update.Description = model.Description;
                    _update.CurrencyId = model.CurrencyId;
                    _update.ParentId = model.ParentId;
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
                    var newModel = new DataAccess.Account()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        Code = model.Code,
                        Description = model.Description,
                        CurrencyId = model.CurrencyId,
                        ParentId = model.ParentId,
                        Blocked = model.Blocked,
                        Version = 1,
                        RecModifiedAt = DateTime.Now,
                        RecCreatedBy = (long)user.ProviderUserKey,
                        RecCreatedAt = DateTime.Now,
                        RecModifiedBy = (long)user.ProviderUserKey
                    };

                    try
                    {
                        var newEntity = this.repository.AddNew(newModel);
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
                    r.ErrorMessage = "Account not found! Please check";
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