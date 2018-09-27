using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class PurchaseInvoiceHeaderViewModels
    {
        [Required]
        public Int64 Id { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public String OrganizationCode { get; set; }

        [Display(Name = "Document No")]
        public string DocumentNo { get; set; }

        [Display(Name = "Document Date")]
        [Required]
        public DateTime DocumentDate { get; set; }

        [Required]
        [Display(Name = "Description")]
        public String Description { get; set; }

        [Display(Name = "Account")]
        [Required]
        public String AccountCode { get; set; }

        [Display(Name = "Business Partner")]
        [Required]
        public String BusinessPartnerCode { get; set; }

        [Display(Name = "Business Partner Name")]
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BusinessPartnerName { get; set; }

        [Display(Name = "BusinessPartner Address")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BusinessPartnerAddress { get; set; }


        [Display(Name = "Contact Name")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BusinessPartnerContactName { get; set; }

        [Display(Name = "Total Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalAmount { get; set; }

        [Display(Name = "Total Vat Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalVatAmount { get; set; }

        [Display(Name = "Total Payment")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalPayment { get; set; }

        [Display(Name = "Currency")]
        public String CurrencyCode { get; set; }

        [Display(Name = "Currency Factor")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal CurrencyFactor { get; set; }

        [Required]
        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Status")]
        public CashDocumentStatusType Status { get; set; }

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
}