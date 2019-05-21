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
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
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
        public long FormTypeId { get; set; }

        public long? OriginalEInvoiceId { get; set; }

        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }

        [Display(Name = "Invoice Issued Date")]
        [Required]
        public DateTime InvoiceIssuedDate { get; set; }

        [Display(Name = "Contract Number")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String ContractNumber { get; set; }

        [Display(Name = "Contract Date")]
        public DateTime? ContractDate { get; set; }

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

        [Display(Name = "Seller Legal Name")]
        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellerLegalName { get; set; }

        [Display(Name = "Seller Tax Code")]
        [Required]
        [StringLength(14, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellerTaxCode { get; set; }

        [Display(Name = "Seller Address")]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellerAddressLine { get; set; }

        [Display(Name = "Buyer Postal Code")]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellerPostalCode { get; set; }

        [Display(Name = "Seller District Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellerDistrictName { get; set; }

        [Display(Name = "Seller City Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellerCityName { get; set; }

        [Display(Name = "Seller Country Code")]
        [StringLength(2, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellerCountryCode { get; set; }

        [Display(Name = "Seller Phone Number")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellerPhoneNumber { get; set; }

        [Display(Name = "Seller Fax Number")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellerFaxNumber { get; set; }

        [Display(Name = "Seller Email")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellerEmail { get; set; }

        [Display(Name = "Seller Bank Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellerBankName { get; set; }

        [Display(Name = "Seller Bank Account")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellerBankAccount { get; set; }

        [Display(Name = "Seller Contact Person Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellerContactPersonName { get; set; }

        [Display(Name = "Seller Signed Person Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellerSignedPersonName { get; set; }

        [Display(Name = "Invoice Note")]
        [StringLength(400, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String InvoiceNote { get; set; }

        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        [Display(Name = "Adjustment Type")]
        public Byte AdjustmentType { get; set; } /*1: Hóa đơn gốc - 3: Hóa đơn thay thế - 5: Hóa đơn điều chỉnh - 7: Hóa đơn  xóa bỏ - 9: Hóa đơn điều chỉnh chiết khấu*/

        [Display(Name = "Additional Reference Desc")]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String AdditionalReferenceDesc { get; set; }

        [Display(Name = "Additional Reference Date")]
        public DateTime? AdditionalReferenceDate { get; set; }

        [Display(Name = "Currency")]
        [Required]
        public long CurrencyId { get; set; }

        [Display(Name = "Currency Factor")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal ExchangeRate { get; set; }

        [Display(Name = "Payment Method Name")]
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String PaymentMethodName { get; set; }

        [Display(Name = "Total Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalAmountWithoutVAT { get; set; }

        [Display(Name = "Total Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalAmountWithoutVATLCY { get; set; }

        [Display(Name = "Total Vat Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalVATAmount { get; set; }

        [Display(Name = "Total Vat Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalVATAmountLCY { get; set; }

        [Display(Name = "Total Payment")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalAmountWithVAT { get; set; }

        [Display(Name = "Total Payment LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalAmountWithVATFrn { get; set; }

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