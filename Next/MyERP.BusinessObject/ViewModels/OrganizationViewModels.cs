using System;
using System.ComponentModel.DataAnnotations;
using MyERP.DataAccess.Enum;

namespace MyERP.BusinessObject.ViewModels
{
    public class OrganizationViewModel
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [Display(Name = "Code")]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }
        
        [Required]
        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Status")]
        public OrganizationStatusType Status { get; set; }

        [Required]
        [Display(Name="CreatedBy")]
        public long RecCreateBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        [Display(Name = "CreatedAt")]
        public DateTime RecCreated { get; set; }

        [Required]
        [Display(Name = "ModifiedBy")]
        public long RecModifiedBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        [Display(Name = "ModifiedAt")]
        public DateTime RecModified { get; set; }
    }

    public class OrganizationEditViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Code")]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Invalid Code - only allow a-z A-Z 0-9 character")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Name { get; set; }
        
        [Required]
        [Display(Name = "Status")]
        public OrganizationStatusType Status { get; set; }

        public Int64 Version { get; set; }
    }
}