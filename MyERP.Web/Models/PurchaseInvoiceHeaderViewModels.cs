using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class PurchaseInvoiceHeaderViewModel
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

        [Display(Name = "Account Payable")]
        [Required]
        public String AccountPayableCode { get; set; }

        [Display(Name = "Buy From Vendor")]
        [Required]
        public String BuyFromVendorCode { get; set; }

        [Display(Name = "Buy From Name")]
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyFromVendorName { get; set; }

        [Display(Name = "Buy From Address")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyFromAddress { get; set; }
        
        [Display(Name = "Buy From Contact Name")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyFromContactName { get; set; }

        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        [Display(Name = "Pay To Vendor")]
        [Required]
        public String PayToVendorCode { get; set; }

        [Display(Name = "Pay To Name")]
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String PayToName { get; set; }

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
        public PurchaseInvoiceDocumentStatusType Status { get; set; }

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

    public class PurchaseInvoiceHeaderEditViewModel
    {
        public long? Id { get; set; }

        [Display(Name = "Document Ttype")]
        public DocumentType DocumentType { get; set; }

        [Display(Name = "Document Subtype")]
        public byte DocSubType { get; set; }

        [Display(Name = "Document No")]
        public string DocumentNo { get; set; }

        [Display(Name = "Sequence No")]
        [Required]
        public long DocSequenceId { get; set; }

        [Display(Name = "Document Date")]
        [Required]
        public DateTime DocumentDate { get; set; }

        [Display(Name = "Posting Date")]
        [Required]
        public DateTime PostingDate { get; set; }

        [Display(Name = "Account Payable")]
        [Required]
        public long AccountPayableId { get; set; }

        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        [Display(Name = "Currency")]
        [Required]
        public long CurrencyId { get; set; }

        [Display(Name = "Currency Factor")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal CurrencyFactor { get; set; }

        [Display(Name = "Buy From Vendor")]
        [Required]
        public long BuyFromVendorId { get; set; }

        public ExtNetComboBoxModel BuyFromVendor { get; set; }

        [Display(Name = "Buy From Vendor Name")]
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyFromVendorName { get; set; }

        [Display(Name = "Buy From Address")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyFromAddress { get; set; }

        [Display(Name = "Buy From Contact Name")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BuyFromContactName { get; set; }

        [Display(Name = "Pay To Vendor")]
        [Required]
        public long PayToVendorId { get; set; }

        public ExtNetComboBoxModel PayToVendor { get; set; }

        [Display(Name = "Pay To Name")]
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String PayToName { get; set; }

        [Display(Name = "Pay To Address")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String PayToAddress { get; set; }

        [Display(Name = "Pay To Contact Name")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String PayToContactName { get; set; }

        [Display(Name = "Pay To Vat Code")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String PayToVatCode { get; set; }

        [Display(Name = "Pay To Vat Note")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String PayToVatNote { get; set; }

        [Display(Name = "Ship To Name")]
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String ShipToName { get; set; }

        [Display(Name = "Ship To Address")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String ShipToAddress { get; set; }

        [Display(Name = "Ship To Contact Name")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String ShipToContactName { get; set; }

        [Display(Name = "Invoice Disc %")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Byte InvoiceDiscountPercentage { get; set; }

        [Display(Name = "Invoice Disc Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal InvoiceDiscountAmount { get; set; }

        [Display(Name = "Invoice Disc Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal InvoiceDiscountAmountLCY { get; set; }

        [Display(Name = "Total Line Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalLineAmount { get; set; }

        [Display(Name = "Total Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalAmount { get; set; }

        [Display(Name = "Total Charge")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalChargeAmount { get; set; }

        [Display(Name = "Total Import Duty")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalImportDutyAmount { get; set; }

        [Display(Name = "Total Excise Tax")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalExciseTaxAmount { get; set; }

        [Display(Name = "Total Vat Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalVatAmount { get; set; }

        [Display(Name = "Total Payment")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalPayment { get; set; }

        [Display(Name = "Total Line Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalLineAmountLCY { get; set; }

        [Display(Name = "Total Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalAmountLCY { get; set; }

        [Display(Name = "Total Charge LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalChargeAmountLCY { get; set; }

        [Display(Name = "Total Import Duty LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalImportDutyAmountLCY { get; set; }

        [Display(Name = "Total Excise Tax LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalExciseTaxAmountLCY { get; set; }

        [Display(Name = "Total Vat Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalVatAmountLCY { get; set; }

        [Display(Name = "Total Payment LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalPaymentLCY { get; set; }

        [EnsureMinimumElements(1, ErrorMessage = "At least a Purchase Invoice Line is required")]
        public List<PurchaseInvoiceLineEditViewModel> PurchaseInvoiceLines { get; set; }

        public List<VatEntryEditViewModel> PurchaseVatEntries { get; set; }

        public Int64 Version { get; set; }

        public PurchaseInvoiceDocumentStatusType Status { get; set; }

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