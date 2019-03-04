using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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
        [StringLength(6, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String InvoiceSeries { get; set; }

        [Display(Name = "Form Filename")]
        public String FormFileName { get; set; }

        [Display(Name = "Form File")]
        public String FormFile { get; set; }

        [Display(Name = "Form Vars")]
        public String FormVars { get; set; }

        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }

    }
}