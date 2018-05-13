using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class ItemGroupViewModel
    {
        [Required]
        public Int64 Id { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public String OrganizationCode { get; set; }

        [Required]
        [Display(Name = "Level")]
        public Byte Level { get; set; }

        [Required]
        [Display(Name = "Code")]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Description")]
        public String Description { get; set; }

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

    public class ItemGroupEditViewModel
    {
        public long? Id { get; set; }

        [Required]
        [Display(Name = "Level")]
        public Byte Level { get; set; }

        [Required]
        [Display(Name = "Code")]
        [Remote("ExtCheckDuplicateItemGroup", "Validation", AreaReference.UseRoot, AdditionalFields = "Id", ErrorMessage = "Product code already exists. Please specify another one.")]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Invalid Code - only allow a-z A-Z 0-9 character")]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Description")]
        public String Description { get; set; }
        
        [Required]
        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }

        public Int64 Version { get; set; }
    }
}