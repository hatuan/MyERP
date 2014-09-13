using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyERP.DataAccess;

namespace MyERP.Web.Models
{
    public class NumberSequenceViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public String OrganizationName { get; set; }

        [Required]
        [Display(Name = "Code")]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }
        
        [Required]
        [Display(Name = "Default")]
        public Boolean IsDefault { get; set; }

        [Required]
        [Display(Name="Manual")]
        public Boolean Manual { get; set; }

        [Required]
        [Display(Name = "Current Number")]
        public Int64 CurrentNo { get; set; }

        [Required]
        [Display(Name = "Ending Number")]
        public Int64 EndingNo { get; set; }

        [Required]
        [Display(Name = "Starting Number")]
        public Int64 StartingNo { get; set; }

        [Required]
        [Display(Name = "Format No")]
        public String FormatNo { get; set; }

        [Required]
        [Display(Name = "Status")]
        public NumberSequenceStatusType Status { get; set; }

        [Required]
        [Display(Name="Created By")]
        public String RecCreateBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        [Display(Name = "Created")]
        public DateTime RecCreated { get; set; }

        [Required]
        [Display(Name = "Modified By")]
        public String RecModifiedBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        [Display(Name = "Modified")]
        public DateTime RecModified { get; set; }
    }

    public class NumberSequenceEditViewModel
    {
        public Guid? Id { get; set; }

        [Required]
        [Display(Name = "Code")]
        [Remote("CheckDuplicateNumberSequence", "Validation", AdditionalFields = "Id", ErrorMessage = "Number Sequence code already exists. Please specify another one.")]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Invalid Code - only allow a-z A-Z 0-9 character")]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Default")]
        public Boolean IsDefault { get; set; }

        [Required]
        [Display(Name = "Manual")]
        public Boolean Manual { get; set; }

        [Required]
        [Display(Name = "Current Number")]
        [Range(1, 999999)]
        public int CurrentNo { get; set; }

        [Required]
        [Display(Name = "Ending Number")]
        [Range(1, 999999)]
        public int EndingNo { get; set; }

        [Required]
        [Display(Name = "Starting Number")]
        [Range(1, 999999)]
        public int StartingNo { get; set; }

        [Required]
        [Display(Name = "Format No")]
        public String FormatNo { get; set; }

        [Required]
        [Display(Name = "Status")]
        public NumberSequenceStatusType Status { get; set; }

        public Int64 Version { get; set; }
    }
}