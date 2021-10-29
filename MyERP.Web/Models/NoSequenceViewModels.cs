using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Ext.Net;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class NoSequenceViewModel
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

        [Display(Name = "Starting Date")]
        public DateTime StartingDate { get; set; }

        [Display(Name = "Starting No")]
        public Int32 StartingNo { get; set; }

        [Display(Name = "Ending No")]
        public Int32 EndingNo { get; set; }

        [Display(Name = "Current No")]
        public Int32 CurrentNo { get; set; }

        [Display(Name = "Warning No")]
        public Int32 WarningNo { get; set; }

        [Display(Name = "Format No")]
        public String FormatNo { get; set; }

        [Required]
        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Blocked")]
        public Boolean Blocked { get; set; }

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

    public class NoSequenceEditViewModel
    {
        public long? Id { get; set; }

        [Required]
        [Display(Name = "Code")]
        [Remote("ExtCheckDuplicateNoSequence", "Validation", AreaReference.UseRoot, AdditionalFields = "Id", ErrorMessage = "Code already exists. Please specify another one.")]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Invalid Code - only allow a-z A-Z 0-9 character")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        public List<NoSequenceLineEditViewModel> NoSequenceLines { get; set; }

        [Required]
        [Display(Name = "Blocked")]
        public Boolean Blocked { get; set; }

        public Int64 Version { get; set; }
    }
}