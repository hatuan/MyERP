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

namespace MyERP.Web.Areas.EInvoice.Controllers
{
    public class FormTypeController : EntityBaseController<MyERP.DataAccess.EInvFormType, MyERP.DataAccess.EntitiesModel>
    {
        public FormTypeController() : this(new EInvFormTypeRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public FormTypeController(IBaseRepository<MyERP.DataAccess.EInvFormType, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: EInvoice/FormType
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
            var paging = ((EInvFormTypeRepository)repository).Paging(parameters);

            var data = paging.Data.Select(c => new EInvFormTypeViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                InvoiceType = c.InvoiceType,
                TemplateCode = c.TemplateCode,
                InvoiceForm = c.InvoiceForm,
                InvoiceSeries = c.InvoiceSeries,
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Status = (DefaultStatusType)c.Status,
                Version = c.Version
            }).ToList();

            Session.Add("StoreFormTypeList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }

        public ActionResult LookupData(StoreRequestParameters parameters, long? id = null)
        {
            if (id != null && id > 0)
            {
                var data = repository.Get(c => c.Id == id, new[] { "Organization" }).Select(c =>
                    new EInvFormTypeViewModel()
                    {
                        Id = c.Id,
                        InvoiceType = c.InvoiceType,
                        TemplateCode = c.TemplateCode,
                        InvoiceForm = c.InvoiceForm,
                        InvoiceSeries = c.InvoiceSeries,
                        OrganizationCode = c.Organization.Code,
                        Status = (DefaultStatusType)c.Status
                    });
                return this.Store(data, 1);
            }
            else
            {
                var paging = ((EInvFormTypeRepository)repository).Paging(parameters.Start, parameters.Limit,
                    parameters.SimpleSort, parameters.SimpleSortDirection);

                var data = paging.Data.Where(c => c.Status == (short)DefaultStatusType.Active)
                    .Select(c => new EInvFormTypeViewModel
                    {
                        Id = c.Id,
                        InvoiceType = c.InvoiceType,
                        TemplateCode = c.TemplateCode,
                        InvoiceForm = c.InvoiceForm,
                        InvoiceSeries = c.InvoiceSeries,
                        OrganizationCode = c.Organization.Code,
                        Status = (DefaultStatusType)c.Status
                    }).ToList();
                return this.Store(data, paging.TotalRecords);
            }
        }

        [HttpGet]
        public ActionResult _Maintenance(string id = null)
        {
            var model = new EInvFormTypeEditViewModel()
            {
                Id = null,
                Status = DefaultStatusType.Active
            };
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id).Single();
                model = new EInvFormTypeEditViewModel()
                {
                    Id = entity.Id,
                    InvoiceType = entity.InvoiceType,
                    TemplateCode = entity.TemplateCode,
                    InvoiceForm = entity.InvoiceForm,
                    InvoiceSeries = entity.InvoiceSeries,
                    Status = (DefaultStatusType)entity.Status,
                    Version = entity.Version
                };
            }
            return new Ext.Net.MVC.PartialViewResult() { Model = model };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(EInvFormTypeEditViewModel model)
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
                        r.ErrorMessage = "Form has been changed or deleted! Please check";
                        return r;
                    }

                    _update.InvoiceType = model.InvoiceType;
                    _update.TemplateCode = model.TemplateCode;
                    _update.InvoiceForm = model.InvoiceForm;
                    _update.InvoiceSeries = model.InvoiceSeries;
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
                    var _newModel = new DataAccess.EInvFormType()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        InvoiceType = model.InvoiceType,
                        TemplateCode = model.TemplateCode,
                        InvoiceForm = model.InvoiceForm,
                        InvoiceSeries = model.InvoiceSeries,
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

        public ActionResult InvoiceFormRender(EInvFormTypeEditViewModel model)
        {
            return this.Content("<html><body>Hello World</body></html>");
        }
    }
}