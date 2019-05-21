using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class EInvFormTypeViewModel
    {
        [Required]
        public Int64 Id { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public String OrganizationCode { get; set; }

        [Required]
        [Display(Name = "Invoice Type")]
        public String InvoiceType { get; set; }

        [Required]
        [Display(Name = "Template Code")]
        public String TemplateCode { get; set; }

        [Display(Name = "Invoice Form")]
        public String InvoiceForm { get; set; }

        [Display(Name = "Invoice Series")]
        public String InvoiceSeries { get; set; }

        [Required]
        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }

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

    public class EInvFormTypeEditViewModel
    {
        public Int64? Id { get; set; }

        [Display(Name = "Invoice Name")]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String InvoiceName { get; set; }

        [Required]
        [Display(Name = "Invoice Type")]
        public String InvoiceType { get; set; }

        [Required]
        [Display(Name = "Invoice Type No")]
        [StringLength(3, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [RegularExpression("[0-9]{2}[1-9]|[0-9][1-9][0-9]|[1-9][0-9]{2}", ErrorMessage = "Enter only 001 to 999 of Invoice Type No")]
        public String InvoiceTypeNo { get; set; }

        [Display(Name = "Template Code")]
        public String TemplateCode { get; set; }

        [Display(Name = "Invoice Form")]
        public String InvoiceForm { get; set; }

        [Required]
        [Display(Name = "Invoice Series")]
        [Remote("ExtCheckDuplicateEInvoiceSeries", "Validation", AreaReference.UseRoot, AdditionalFields = "Id", ErrorMessageResourceName = "Code_already_exists_Please_specify_another_one", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(6, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String InvoiceSeries { get; set; }

        [Required(ErrorMessage = "Please choose Invoice template")]
        [Display(Name = "Invoice Template")]
        public String FormFileName { get; set; }

        [Display(Name = "Form File")]
        [AllowHtml]
        public String FormFile { get; set; }

        [Display(Name = "Logo")]
        public String Logo { get; set; }

        [Display(Name = "Watermark")]
        public String Watermark { get; set; }

        [Display(Name = "Seller Legal Name")]
        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellerLegalName { get; set; }

        [Display(Name = "Seller Tax Code")]
        [Required]
        [StringLength(14, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellerTaxCode { get; set; }

        [Display(Name = "Seller Address")]
        [Required]
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
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
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

        public Boolean HasFormRelease { get; set; }

        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }

    }

    public class EInvFormTypeLookupViewModel
    {
        [Required]
        public Int64 Id { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public String OrganizationCode { get; set; }

        [Required]
        [Display(Name = "Invoice Type")]
        public String InvoiceType { get; set; }

        [Required]
        [Display(Name = "Template Code")]
        public String TemplateCode { get; set; }

        [Display(Name = "Invoice Form")]
        public String InvoiceForm { get; set; }

        [Display(Name = "Invoice Series")]
        public String InvoiceSeries { get; set; }

        [Display(Name = "Seller Legal Name")]
        [Required]
        public String SellerLegalName { get; set; }

        [Display(Name = "Seller Tax Code")]
        [Required]
        public String SellerTaxCode { get; set; }

        [Display(Name = "Seller Address")]
        public String SellerAddressLine { get; set; }

        [Display(Name = "Buyer Postal Code")]
        public String SellerPostalCode { get; set; }

        [Display(Name = "Seller District Name")]
        public String SellerDistrictName { get; set; }

        [Display(Name = "Seller City Name")]
        public String SellerCityName { get; set; }

        [Display(Name = "Seller Country Code")]
        public String SellerCountryCode { get; set; }

        [Display(Name = "Seller Phone Number")]
        public String SellerPhoneNumber { get; set; }

        [Display(Name = "Seller Fax Number")]
        public String SellerFaxNumber { get; set; }

        [Display(Name = "Seller Email")]
        public String SellerEmail { get; set; }

        [Display(Name = "Seller Bank Name")]
        public String SellerBankName { get; set; }

        [Display(Name = "Seller Bank Account")]
        public String SellerBankAccount { get; set; }

        [Display(Name = "Seller Contact Person Name")]
        public String SellerContactPersonName { get; set; }

        [Display(Name = "Seller Signed Person Name")]
        public String SellerSignedPersonName { get; set; }

        [Required]
        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }
    }
}