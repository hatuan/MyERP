using Ext.Net;
using Ext.Net.MVC;
using MyERP.DataAccess.Enum;
using MyERP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MyERP.Web.Controllers
{
    public class EInvoiceSignedController : EntityBaseController<MyERP.DataAccess.EInvoiceSigned, MyERP.DataAccess.EntitiesModel>
    {
        public EInvoiceSignedController() : this(new EInvoiceSignedRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public EInvoiceSignedController(IBaseRepository<MyERP.DataAccess.EInvoiceSigned, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        [AllowAnonymous]
        public ActionResult Index(string sellerTaxCode, string clientUUID)
        {
            ViewData["SellerTaxCode"] = sellerTaxCode;
            ViewData["ClientUUID"] = clientUUID;

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");

            return View(model: new EInvoiceSignedViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Search(string sellerTaxCode, string clientUUID, string buyerTaxCode, string reservationCode)
        {
            if(String.IsNullOrWhiteSpace(sellerTaxCode))
                new ArgumentNullException(nameof(sellerTaxCode));
            if (String.IsNullOrWhiteSpace(clientUUID))
                new ArgumentNullException(nameof(clientUUID));

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");

            if (String.IsNullOrWhiteSpace(buyerTaxCode) && String.IsNullOrWhiteSpace(reservationCode))
            {
                X.GetCmp<TextField>("BuyerTaxCode").MarkInvalid("Must input Buyer TaxCode or Reservation Code");
                X.GetCmp<TextField>("ReservationCode").MarkInvalid("Must input Buyer TaxCode or Reservation Code");

                return this.Direct(); //if return this.Direct(false, "....") MarkInvalid not work
            }

            var searchResult = (repository as EInvoiceSignedRepository).Search(sellerTaxCode, clientUUID, buyerTaxCode, reservationCode);
            Session["SearchResult"] = searchResult;

            List<EInvoiceSignedViewModel> storeData = searchResult.Select(x => new EInvoiceSignedViewModel()
            {
                Id = x.Id,
                InvoiceNumber = x.InvoiceNumber,
                InvoiceIssuedDate = x.InvoiceIssuedDate,
                BuyerLegalName = x.BuyerLegalName,
                BuyerTaxCode = x.BuyerTaxCode,
                BuyerAddressLine = x.BuyerAddressLine,
                Description = x.Description,
                TotalAmountWithoutVAT = x.TotalAmountWithoutVAT,
                TotalVATAmount = x.TotalVATAmount,
                TotalAmountWithVAT = x.TotalAmountWithVAT,
                Status = x.Status,
                ReservationCode = x.ReservationCode
            }).ToList();

            X.GetCmp<Store>("StoreEInvoiceSigned").LoadData(storeData, false);
            return this.Direct();
        }

        [AllowAnonymous]
        public ActionResult Print(string reservationCode)
        {
            if (String.IsNullOrEmpty(reservationCode))
                throw new ArgumentNullException(nameof(reservationCode));

            var searchResult = Session["SearchResult"] as List<EInvoiceSignedViewModel>;
            EInvoiceSignedViewModel printInvoice = searchResult.Where(x => x.ReservationCode == reservationCode).First();
            string renderName = $"eInvoiceRender_{printInvoice.ReservationCode}_{DateTime.Now:yyyyMMddhhmmss}";
            string dirPath = Server.MapPath($"~/Resources/PrintReports/EInvoiceSigned/{renderName}");
            if (!System.IO.Directory.Exists(dirPath))
            {
                System.IO.Directory.CreateDirectory(dirPath);
            }
            string fullHtmlPath = dirPath + $"/{renderName}.html";
            try
            {
                (repository as EInvoiceSignedRepository).CreateHtmlFile(printInvoice, dirPath, fullHtmlPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return this.Direct(new { FileName = renderName });
        }
    }
}