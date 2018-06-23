using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Ext.Net;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class LocationViewModel
    {
        [Required]
        public Int64 Id { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public String OrganizationCode { get; set; }

        [Required]
        [Display(Name = "Code")]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Description")]
        public String Description { get; set; }

        [Display(Name = "Contact Name")]
        public String ContactName { get; set; }

        [Display(Name = "Address")]
        public String Address { get; set; }

        [Display(Name = "Telephone")]
        public String Telephone { get; set; }

        [Display(Name = "Mobilephone")]
        public String Mobilephone { get; set; }

        [Display(Name = "Fax")]
        public String Fax { get; set; }

        [Display(Name = "Mail")]
        public String EMail { get; set; }

        [Required]
        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }

        [Required]
        [Display(Name="Created By")]
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

    public class LocationEditViewModel
    {
        public long? Id { get; set; }

        [Required]
        [Display(Name = "Code")]
        [Remote("ExtCheckDuplicateLocation", "Validation", AreaReference.UseRoot, AdditionalFields = "Id", ErrorMessage = "Code already exists. Please specify another one.")]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Invalid Code - only allow a-z A-Z 0-9 character")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        [Display(Name = "Address")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Address { get; set; }

        [Display(Name = "Telephone")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Telephone { get; set; }

        [Display(Name = "Mobilephone")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Mobilephone { get; set; }

        [Display(Name = "Fax")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Fax { get; set; }

        [Display(Name = "Mail")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Email { get; set; }

        [Display(Name = "Contact Name")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String ContactName { get; set; }

        [Required]
        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }

        public Int64 Version { get; set; }
    }
}