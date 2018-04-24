using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class OrganizationViewModel
    {
        [Required]
        public Guid Id { get; set; }

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

    public class OrganizationEditViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Code")]
        [Remote("CheckDuplicateOrganization", "Validation", AdditionalFields = "Id", ErrorMessage = "Organization code already exists. Please specify another one.")]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Invalid Code - only allow a-z A-Z 0-9 character")]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }
        
        [Required]
        [Display(Name = "Status")]
        public OrganizationStatusType Status { get; set; }

        public Int64 Version { get; set; }
    }
}