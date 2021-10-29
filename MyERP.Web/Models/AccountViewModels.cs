using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class AccountViewModel
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

        [Display(Name = "Parent")]
        public String ParentCode { get; set; }

        [Display(Name = "Currency")]
        public String CurrencyCode { get; set; }

        [Required]
        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Blocked", ResourceType = typeof(Resources.Resources))]
        public Boolean Blocked { get; set; }

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

    public class AccountEditViewModel
    {
        public long? Id { get; set; }

        [Required]
        [Display(Name = "Code", ResourceType = typeof(Resources.Resources))]
        [Remote("ExtCheckDuplicateAccount", "Validation", AreaReference.UseRoot, AdditionalFields = "Id", ErrorMessageResourceName = "Code_already_exists_Please_specify_another_one", ErrorMessageResourceType = typeof(Resources.Resources))]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessageResourceName = "Invalid_Code_only_allow_a_z_A_Z_0_9_character", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(32, ErrorMessageResourceName = "The_0_must_be_at_least_2_characters_long", ErrorMessageResourceType = typeof(Resources.Resources))]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        [StringLength(256, ErrorMessageResourceName = "The_0_must_be_at_least_2_characters_long", ErrorMessageResourceType = typeof(Resources.Resources))]
        public String Description { get; set; }

        [Display(Name = "Parent")]
        public long? ParentId { get; set; }

        [Display(Name = "Currency")]
        public long? CurrencyId { get; set; }

        [Required]
        [Display(Name = "Blocked", ResourceType = typeof(Resources.Resources))]
        public Boolean Blocked { get; set; }

        public Int64 Version { get; set; }
    }

    public class AccountLookupViewModel
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