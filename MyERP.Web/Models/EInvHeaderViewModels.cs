using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class EInvHeaderViewModel
    {
        [Required] public Int64 Id { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public String OrganizationCode { get; set; }

        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }

        [Display(Name = "Invoice Date")]
        [Required]
        public DateTime InvoiceIssuedDate { get; set; }

        [Display(Name = "Buyer Code")]
        public String BuyerCode { get; set; }

        [Display(Name = "Buyer Display Name")]
        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerDisplayName { get; set; }

        [Display(Name = "Buyer Legal Name")]
        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerLegalName { get; set; }

        [Display(Name = "Buyer Tax Code")]
        [Required]
        [StringLength(14, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerTaxCode { get; set; }

        [Display(Name = "Buyer Address")]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerAddressLine { get; set; }

        [Display(Name = "Buyer Postal Code")]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerPostalCode { get; set; }

        [Display(Name = "Buyer District Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerDistrictName { get; set; }

        [Display(Name = "Buyer City Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerCityName { get; set; }

        [Display(Name = "Buyer Country Code")]
        [StringLength(2, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerCountryCode { get; set; }

        [Display(Name = "Buyer Phone Number")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerPhoneNumber { get; set; }

        [Display(Name = "Buyer Fax Number")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerFaxNumber { get; set; }

        [Display(Name = "Buyer Email")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerEmail { get; set; }

        [Display(Name = "Buyer Bank Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerBankName { get; set; }

        [Display(Name = "Buyer Bank Account")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerBankAccount { get; set; }

        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
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
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String TotalAmountWithVATInWords { get; set; }

        [Display(Name = "Currency")]
        public String CurrencyCode { get; set; }

        [Display(Name = "Exchange Rate")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal ExchangeRate { get; set; }

        [Required] public Int64 Version { get; set; }

        [Required] [Display(Name = "Status")]
        public EInvoiceDocumentStatusType Status { get; set; }

        [Required]
        [Display(Name = "Created By")]
        public String RecCreateBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Created")]
        public DateTime RecCreatedAt { get; set; }

        [Required]
        [Display(Name = "Modified By")]
        public String RecModifiedBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Modified")]
        public DateTime RecModifiedAt { get; set; }
    }

    public class EInvHeaderEditViewModel
    {
        public long? Id { get; set; }

        [Display(Name = "Invoice Series")]
        [Required]
        public long? FormTypeId { get; set; }

        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }

        [Display(Name = "Invoice Issued Date")]
        [Required]
        public DateTime InvoiceIssuedDate { get; set; }

        [Display(Name = "Buyer Code")]
        [Required]
        public long? BuyerId { get; set; }

        [Display(Name = "Buyer Display Name")]
        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerDisplayName { get; set; }

        [Display(Name = "Buyer Legal Name")]
        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerLegalName { get; set; }

        [Display(Name = "Buyer Tax Code")]
        [Required]
        [StringLength(14, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerTaxCode { get; set; }

        [Display(Name = "Buyer Address")]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerAddressLine { get; set; }

        [Display(Name = "Buyer Postal Code")]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerPostalCode { get; set; }

        [Display(Name = "Buyer District Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerDistrictName { get; set; }

        [Display(Name = "Buyer City Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerCityName { get; set; }

        [Display(Name = "Buyer Country Code")]
        [StringLength(2, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerCountryCode { get; set; }

        [Display(Name = "Buyer Phone Number")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerPhoneNumber { get; set; }

        [Display(Name = "Buyer Fax Number")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerFaxNumber { get; set; }

        [Display(Name = "Buyer Email")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerEmail { get; set; }

        [Display(Name = "Buyer Bank Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerBankName { get; set; }

        [Display(Name = "Buyer Bank Account")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyerBankAccount { get; set; }

        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        [Display(Name = "Currency")]
        [Required]
        public long CurrencyId { get; set; }

        [Display(Name = "Currency Factor")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal ExchangeRate { get; set; }

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
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String TotalAmountWithVATInWords { get; set; }

        [EnsureMinimumElements(1, ErrorMessage = "At least a Invoice Line is required")]
        public List<EInvLineEditViewModel> EInvoiceLines { get; set; }

        public Int64 Version { get; set; }

        public EInvoiceDocumentStatusType Status { get; set; }

        [Display(Name = "Created By")]
        public String RecCreateBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created At")]
        public DateTime RecCreatedAt { get; set; }

        [Display(Name = "Modified By")]
        public String RecModifiedBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Modified At")]
        public DateTime RecModifiedAt { get; set; }
    }
}