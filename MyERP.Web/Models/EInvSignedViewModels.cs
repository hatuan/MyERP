using MyERP.DataAccess.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyERP.Web.Models
{
    public class EInvoiceSignedViewModel
    {
        public Int64 Id { get; set; }

        [Display(Name = "Organization")]
        public String OrganizationCode { get; set; }

        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }

        [Display(Name = "Invoice Date")]
        public DateTime InvoiceIssuedDate { get; set; }

        [Display(Name = "Buyer Code")]
        public String BuyerCode { get; set; }

        [Display(Name = "Buyer Display Name")]
        public String BuyerDisplayName { get; set; }

        [Display(Name = "Buyer Legal Name")]
        public String BuyerLegalName { get; set; }

        [Display(Name = "Buyer Tax Code")]
        public String BuyerTaxCode { get; set; }

        [Display(Name = "Buyer Address")]
        public String BuyerAddressLine { get; set; }

        [Display(Name = "Buyer Postal Code")]
        public String BuyerPostalCode { get; set; }

        [Display(Name = "Buyer District Name")]
        public String BuyerDistrictName { get; set; }

        [Display(Name = "Buyer City Name")]
        public String BuyerCityName { get; set; }

        [Display(Name = "Buyer Country Code")]
        public String BuyerCountryCode { get; set; }

        [Display(Name = "Buyer Phone Number")]
        public String BuyerPhoneNumber { get; set; }

        [Display(Name = "Buyer Fax Number")]
        public String BuyerFaxNumber { get; set; }

        [Display(Name = "Buyer Email")]
        public String BuyerEmail { get; set; }

        [Display(Name = "Buyer Bank Name")]
        public String BuyerBankName { get; set; }

        [Display(Name = "Buyer Bank Account")]
        public String BuyerBankAccount { get; set; }

        [Display(Name = "Description")]
        public String Description { get; set; }

        [Display(Name = "Total Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalAmountWithoutVAT { get; set; }

        [Display(Name = "Total Vat Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalVATAmount { get; set; }

        [Display(Name = "Total Payment")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalAmountWithVAT { get; set; }

        [Display(Name = "Total Payment In Words")]
        public String TotalAmountWithVATInWords { get; set; }

        [Display(Name = "Currency")]
        public String CurrencyCode { get; set; }

        [Display(Name = "Exchange Rate")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal ExchangeRate { get; set; }

        [Display(Name = "Status")]
        public EInvoiceDocumentStatusType Status { get; set; }

        public String ReservationCode { get; set; }

        public String Logo { get; set; }
        public String Watermark { get; set; }

        public String SignedXML { get; set; }
        public String SignedXSL { get; set; }
    }

    public class SignXMLDTO
    {
        public string OriginXML { get; set; }
        public string SignedXML { get; set; }
        public string SerialNumber { get; set; }
        public string PIN { get; set; }
        public bool Status { get; set; }
        public long UomId { get; set; }
        public string Exception { get; set; }
    }
}