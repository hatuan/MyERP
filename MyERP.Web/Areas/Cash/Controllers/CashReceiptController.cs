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

namespace MyERP.Web.Areas.Cash.Controllers
{
    public class CashReceiptController : EntityBaseController<MyERP.DataAccess.CashHeader, MyERP.DataAccess.EntitiesModel>
    {
        public CashReceiptController() : this(new CashHeaderRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public CashReceiptController(IBaseRepository<MyERP.DataAccess.CashHeader, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: Cash/CashReceipt
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
            var paging = ((CashHeaderRepository)repository).Paging(parameters);

            var data = paging.Data.Select(c => new CashHeaderViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                DocumentNo = c.DocumentNo,
                DocumentDate = c.DocumentDate,
                AccountCode = c.Account.Code,
                Description = c.Description,
                BusinessPartnerCode = c.BusinessPartner.Code,
                BusinessPartnerName = c.BusinessPartnerName,
                BusinessPartnerAddress = c.BusinessPartnerAddress,
                BusinessPartnerContactName = c.BusinessPartnerContactName,
                TotalAmount = c.TotalAmount,
                TotalVatAmount = c.TotalVatAmount,
                TotalPayment = c.TotalPayment,
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Status = (CashDocumentStatusType)c.Status,
                Version = c.Version
            }).ToList();

            Session.Add("StoreCashReceiptList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }

        [HttpGet]
        public ActionResult _Maintenance(string id = null)
        {
            var model = new CashHeaderEditViewModel()
            {
                Id = null,
                Status = CashDocumentStatusType.Draft
            };
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id).SingleOrDefault();
                model = new CashHeaderEditViewModel()
                {
                    Id = entity.Id,
                    Description = entity.Description,
                    Status = (CashDocumentStatusType)entity.Status,
                    Version = entity.Version
                };
            }

            return new Ext.Net.MVC.PartialViewResult() { Model = model };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(CashHeaderEditViewModel model)
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
                    var _newModel = new DataAccess.CashHeader()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
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

                Store StoreCashReceiptList = X.GetCmp<Store>("StoreCashReceiptList");
                StoreCashReceiptList.Reload();
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
                    r.ErrorMessage = "ItemGroup not found! Please check";
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

                Store StoreCashReceiptList = X.GetCmp<Store>("StoreCashReceiptList");
                StoreCashReceiptList.Reload();
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }

            return this.Direct();
        }
    }
}