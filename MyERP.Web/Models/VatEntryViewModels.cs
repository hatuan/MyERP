using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Ext.Net.MVC;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class VatEntryEditViewModel
    {
        public long? Id { get; set; }

        [Required]
        public long LineNo { get; set; }

        public long? DocumentHeaderId { get; set; }

        [Display(Name = "Document Ttype")]
        public DocumentType DocumentType { get; set; }

        [Display(Name = "Document Subtype")]
        public byte DocSubType { get; set; }

        [Display(Name = "Document No")]
        public string DocumentNo { get; set; }

        [Display(Name = "Document Date")]
        [Required]
        public DateTime DocumentDate { get; set; }

        [Display(Name = "Posting Date")]
        [Required]
        public DateTime PostingDate { get; set; }

        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }

        [Display(Name = "Invoice Date")]
        [Required]
        [DateColumn]
        [DataType(DataType.Date)]
        public DateTime InvoiceIssuedDate { get; set; }

        [Display(Name = "Invoice Series")]
        [Required]
        public string InvoiceSeries { get; set; }
        
        [Display(Name = "Business Partner")]
        [Required]
        public long BusinessPartnerId { get; set; }

        public LookupViewModel BusinessPartner { get; set; }

        [Display(Name = "BP Name")]
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BusinessPartnerName { get; set; }

        [Display(Name = "BP Address")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String BusinessPartnerAddress { get; set; }

        [Display(Name = "Tax Code")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String TaxCode { get; set; }

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

        [Display(Name = "Vat Base Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal VatBaseAmount { get; set; }

        [Display(Name = "Vat Base Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal VatBaseAmountLCY { get; set; }

        [Display(Name = "Vat")]
        [Required]
        public long? VatId { get; set; }

        public LookupViewModel Vat { get; set; }

        [Display(Name = "Vat %")]
        [DisplayFormat(DataFormatString = "{0}")]
        public Decimal VatPercentage { get; set; }

        [Display(Name = "Vat Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal VatAmount { get; set; }

        [Display(Name = "Vat Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal VatAmountLCY { get; set; }

        [Display(Name = "Account Vat")]
        [Required]
        public long AccountVatId { get; set; }

        public LookupViewModel AccountVat { get; set; }

        [Display(Name = "Corresp Account")]
        [Required]
        public long CorrespAccountId { get; set; }

        public LookupViewModel CorrespAccount { get; set; }
    }
}