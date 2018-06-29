using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class CurrencyViewModel
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [Display(Name = "Organization", ResourceType = typeof(Resources.Resources))]
        public String OrganizationCode { get; set; }

        [Required]
        [Display(Name = "Code", ResourceType = typeof(Resources.Resources))]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        public String Description { get; set; }
        
        [Required]
        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Status", ResourceType = typeof(Resources.Resources))]
        public DefaultStatusType Status { get; set; }

        [Required]
        [Display(Name="Created_By", ResourceType = typeof(Resources.Resources))]
        public String RecCreateBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        [Display(Name = "Created_At", ResourceType = typeof(Resources.Resources))]
        public DateTime RecCreatedAt { get; set; }

        [Required]
        [Display(Name = "Modified_By", ResourceType = typeof(Resources.Resources))]
        public String RecModifiedBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        [Display(Name = "Modified_At", ResourceType = typeof(Resources.Resources))]
        public DateTime RecModifiedAt { get; set; }
    }

    public class CurrencyEditViewModel
    {
        public long? Id { get; set; }

        [Required]
        [Display(Name = "Code", ResourceType = typeof(Resources.Resources))]
        [Remote("ExtCheckDuplicateCurrency", "Validation", AdditionalFields = "Id", ErrorMessageResourceName = "Code_already_exists_Please_specify_another_one", ErrorMessageResourceType = typeof(Resources.Resources))]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessageResourceName = "Invalid_Code_only_allow_a_z_A_Z_0_9_character", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(32, ErrorMessageResourceName = "The_0_must_be_at_least_2_characters_long", ErrorMessageResourceType = typeof(Resources.Resources))]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        [StringLength(256, ErrorMessageResourceName = "The_0_must_be_at_least_2_characters_long", ErrorMessageResourceType = typeof(Resources.Resources))]
        public String Description { get; set; }
        
        [Required]
        [Display(Name = "Status", ResourceType = typeof(Resources.Resources))]
        public DefaultStatusType Status { get; set; }

        public Int64 Version { get; set; }
    }
}