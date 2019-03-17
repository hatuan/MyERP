using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class EInvFormReleaseViewModel
    {
        [Required]
        public Int64 Id { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public String OrganizationCode { get; set; }

        [Required]
        [Display(Name = "Form Type")]
        public Int64 FormTypeId { get; set; }

        [Required]
        [Display(Name = "Template Code")]
        public String TemplateCode { get; set; }

        [Display(Name = "Invoice Series")]
        public String InvoiceSeries { get; set; }

        [Display(Name = "Release Total")]
        public Decimal ReleaseTotal { get; set; }

        [Display(Name = "Release From")]
        public Decimal ReleaseFrom { get; set; }

        [Display(Name = "Release To")]
        public Decimal ReleaseTo { get; set; }

        [Display(Name = "Release Used")]
        public Decimal ReleaseUsed { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Tax Auth Status")]
        public TaxAuthoritiesStatus TaxAuthoritiesStatus { get; set; }

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

    public class EInvFormReleaseEditViewModel
    {
        public Int64? Id { get; set; }

        [Required]
        [Display(Name = "Form Type")]
        public Int64 FormTypeId { get; set; }

        [Required]
        [Display(Name = "Release Total")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [Range(1, 9999999, ErrorMessage = "Please enter a value between 1 to 9.999.999.00")]
        public Decimal ReleaseTotal { get; set; }

        [Required]
        [Display(Name = "Release From")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [Range(1, 9999999)]
        public Decimal ReleaseFrom { get; set; }

        [Required]
        [Display(Name = "Release To")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [Range(1, 9999999)]
        public Decimal ReleaseTo { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Tax Authorities Status")]
        public TaxAuthoritiesStatus TaxAuthoritiesStatus { get; set; }
    }
}