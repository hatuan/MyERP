using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Ext.Net;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class JobViewModel
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

        [Display(Name = "Group 1")]
        public String JobGroup1Code { get; set; }

        [Display(Name = "Group 2")]
        public String JobGroup2Code { get; set; }

        [Display(Name = "Group 3")]
        public String JobGroup3Code { get; set; }

        [Required]
        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Blocked")]
        public Boolean Blocked { get; set; }

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

    public class JobEditViewModel
    {
        public long? Id { get; set; }

        [Required]
        [Display(Name = "Code")]
        [Remote("ExtCheckDuplicateJob", "Validation", AreaReference.UseRoot, AdditionalFields = "Id", ErrorMessage = "Code already exists. Please specify another one.")]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Invalid Code - only allow a-z A-Z 0-9 character")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }
        
        [Display(Name = "Group 1")]
        public long? JobGroupId1 { get; set; }

        [Display(Name = "Group 2")]
        public long? JobGroupId2 { get; set; }

        [Display(Name = "Group 3")]
        public long? JobGroupId3 { get; set; }

        [Required]
        [Display(Name = "Blocked")]
        public Boolean Blocked { get; set; }

        public Int64 Version { get; set; }
    }

    public class JobLookupViewModel
    {
        [Required]
        public Int64 Id { get; set; }

        [Display(Name = "Organization")]
        public String OrganizationCode { get; set; }

        [Required]
        [Display(Name = "Code")]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Description")]
        public String Description { get; set; }

        [Display(Name = "Blocked")]
        public Boolean Blocked { get; set; }
    }
}