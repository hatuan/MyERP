﻿using System;
using System.ComponentModel.DataAnnotations;
using MyERP.DataAccess.Enum;

namespace MyERP.BusinessObject.ViewModels
{
    public class CurrencyViewModel
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public String OrganizationCode { get; set; }

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
        public DefaultMasterStatusType Status { get; set; }

        [Required]
        [Display(Name="CreatedBy")]
        public long RecCreateBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        [Display(Name = "CreatedAt")]
        public DateTime RecCreatedAt { get; set; }

        [Required]
        [Display(Name = "ModifiedBy")]
        public long RecModifiedBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        [Display(Name = "ModifiedAt")]
        public DateTime RecModifiedAt { get; set; }
    }
    /*
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

    public class CurrencyLookupViewModel
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

        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }
    }

    public class CurrencyHeaderViewModel
    {
        [Display(Name = "Currency")]
        [Required]
        public long CurrencyId { get; set; }

        [Display(Name = "Currency Factor")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal CurrencyFactor { get; set; }
    }
    */
}