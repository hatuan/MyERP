using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.DataAccess.Enum;
using MyERP.Web.Controllers;
using MyERP.Web.Models;
using Newtonsoft.Json;

namespace MyERP.Web.Areas.EInvoice.Controllers
{
    public class FormReleaseController : EntityBaseController<MyERP.DataAccess.EInvFormRelease, MyERP.DataAccess.EntitiesModel>
    {
        public FormReleaseController() : this(new EInvFormReleaseRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public FormReleaseController(IBaseRepository<MyERP.DataAccess.EInvFormRelease, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: EInvoice/FormRelease
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
            var paging = ((EInvFormReleaseRepository)repository).Paging(parameters);

            var data = paging.Data.Select(c => new EInvFormReleaseViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                FormTypeId = c.FormTypeId,
                TemplateCode = c.EInvFormType.TemplateCode,
                InvoiceSeries = c.EInvFormType.InvoiceSeries,
                ReleaseTotal = c.ReleaseTotal,
                ReleaseFrom = c.ReleaseFrom,
                ReleaseTo = c.ReleaseTo,
                ReleaseUsed = c.ReleaseUsed,
                ReleaseDate = c.ReleaseDate,
                StartDate = c.StartDate,
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                TaxAuthoritiesStatus = (TaxAuthoritiesStatus)c.Status,
                Version = c.Version
            }).ToList();

            Session.Add("StoreFormReleaseList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }

        [HttpGet]
        public ActionResult _Maintenance(string id = null)
        {

            var model = new EInvFormReleaseEditViewModel()
            {
                Id = null,
                TaxAuthoritiesStatus = TaxAuthoritiesStatus.Inactive
            };

            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id, includePaths: new String[] { "EInvFormType" }).Single();

                model = new EInvFormReleaseEditViewModel()
                {
                    Id = entity.Id,
                    FormTypeId = entity.FormTypeId,
                    ReleaseTotal = entity.ReleaseTotal,
                    ReleaseFrom = entity.ReleaseFrom,
                    ReleaseTo = entity.ReleaseTo,
                    ReleaseDate = entity.ReleaseDate,
                    StartDate = entity.StartDate,
                    TaxAuthoritiesStatus = (TaxAuthoritiesStatus)entity.Status,
                    Version = entity.Version
                };


                ViewData["FormTypeStore"] = new List<EInvFormTypeLookupViewModel>
                {
                    new EInvFormTypeLookupViewModel()
                    {
                        Id = entity.FormTypeId,
                        InvoiceType = entity.EInvFormType.InvoiceType,
                        TemplateCode = entity.EInvFormType.TemplateCode,
                        InvoiceForm = entity.EInvFormType.InvoiceForm,
                        InvoiceSeries = entity.EInvFormType.InvoiceSeries,
                    }
                };
               
            }
            else
            {
                
            }
            
            return new Ext.Net.MVC.PartialViewResult() { Model = model, ViewData = ViewData };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(EInvFormReleaseEditViewModel model)
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
                        r.ErrorMessage = "Form Release has been changed or deleted! Please check";
                        return r;
                    }

                    if (_update.ReleaseUsed > 0 || (TaxAuthoritiesStatus)_update.TaxAuthoritiesStatus == TaxAuthoritiesStatus.Active)
                    {
                        r.Success = false;
                        r.ErrorMessage = "Form Release has been used! Can not Edit or Delete";
                        return r;
                    }

                    _update.FormTypeId = model.FormTypeId;
                    _update.ReleaseTotal = model.ReleaseTotal;
                    _update.ReleaseFrom = model.ReleaseFrom;
                    _update.ReleaseTo = model.ReleaseTo;
                    _update.ReleaseDate = model.ReleaseDate;
                    _update.StartDate = model.StartDate;
                    _update.TaxAuthoritiesStatus = (byte)model.TaxAuthoritiesStatus;
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
                    var _newModel = new DataAccess.EInvFormRelease()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        FormTypeId = model.FormTypeId,
                        ReleaseTotal = model.ReleaseTotal,
                        ReleaseFrom = model.ReleaseFrom,
                        ReleaseTo = model.ReleaseTo,
                        ReleaseDate = model.ReleaseDate,
                        StartDate = model.StartDate,
                        TaxAuthoritiesStatus = (byte)model.TaxAuthoritiesStatus,
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
                    r.ErrorMessage = "Form not found! Please check";
                    return r;
                }

                if (entity.ReleaseUsed > 0 || (TaxAuthoritiesStatus)entity.TaxAuthoritiesStatus ==  TaxAuthoritiesStatus.Active)
                {
                    r.Success = false;
                    r.ErrorMessage = "Form Release has been used! Can not Edit or Delete";
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeFormType(EInvFormReleaseEditViewModel model)
        {
            //Calc max release to of FormType
            decimal maxFormReleaseTo = (new EInvFormTypeRepository()).GetMaxReleaseOfFormType(model.FormTypeId);

            return this.Direct(new { ReleaseFrom = maxFormReleaseTo + 1, ReleaseTo = maxFormReleaseTo + 1 + model.ReleaseTotal });
    }
    }
}