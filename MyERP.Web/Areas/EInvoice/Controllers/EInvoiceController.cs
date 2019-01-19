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

namespace MyERP.Web.Areas.EInvoice.Controllers
{
    public class EInvoiceController : EntityBaseController<MyERP.DataAccess.EInvoiceHeader, MyERP.DataAccess.EntitiesModel>
    {
        public EInvoiceController() : this(new EInvoiceHeaderRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public EInvoiceController(IBaseRepository<MyERP.DataAccess.EInvoiceHeader, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: EInvoice/EInvoice
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
            var paging = ((EInvoiceHeaderRepository)repository).Paging(parameters);

            var data = paging.Data.Select(c => new EInvHeaderViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                InvoiceNumber = c.InvoiceNumber,
                InvoiceIssuedDate = c.InvoiceIssuedDate,
                BuyerCode = c.BusinessPartner?.Code,
                BuyerDisplayName = c.BuyerDisplayName,
                BuyerLegalName = c.BuyerLegalName,
                BuyerTaxCode = c.BuyerTaxCode,
                BuyerAddressLine = c.BuyerAddressLine,
                BuyerPostalCode = c.BuyerPostalCode,
                BuyerDistrictName = c.BuyerDistrictName,
                BuyerCityName = c.BuyerCityName,
                BuyerCountryCode = c.BuyerCountryCode,
                BuyerFaxNumber = c.BuyerFaxNumber,
                BuyerEmail = c.BuyerEmail,
                BuyerBankName = c.BuyerBankName,
                BuyerBankAccount = c.BuyerBankAccount,
                TotalAmountWithoutVAT = c.TotalAmountWithoutVAT,
                TotalVATAmount = c.TotalVATAmount,
                TotalAmountWithVAT = c.TotalAmountWithVAT,
                Description = c.Description,
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Status = (EInvoiceDocumentStatusType)c.Status,
                Version = c.Version
            }).ToList();

            Session.Add("StoreEInvoiceList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }

        [HttpGet]
        public ActionResult _Maintenance(string id = null)
        {
            return this.Direct();
        }
    }
}