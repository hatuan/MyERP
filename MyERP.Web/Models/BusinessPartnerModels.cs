using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Ext.Net;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class BusinessPartnerViewModel
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

        [Display(Name = "Address")]
        public String Address { get; set; }

        [Display(Name = "Telephone")]
        public String Telephone { get; set; }

        [Display(Name = "Mobilephone")]
        public String Mobilephone { get; set; }

        [Display(Name = "Mail")]
        public String Mail { get; set; }

        [Display(Name = "Vat Code")]
        public String VatCode { get; set; }

        [Display(Name = "Contact Name")]
        public String ContactName { get; set; }

        [Display(Name = "Group 1")]
        public String BusinessPartnerGroup1Code { get; set; }

        [Display(Name = "Group 2")]
        public String BusinessPartnerGroup2Code { get; set; }

        [Display(Name = "Group 3")]
        public String BusinessPartnerGroup3Code { get; set; }

        public Int64 Version { get; set; }

        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }

        [Display(Name="Created By")]
        public String RecCreateBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created")]
        public DateTime RecCreatedAt { get; set; }

        [Display(Name = "Modified By")]
        public String RecModifiedBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Modified")]
        public DateTime RecModifiedAt { get; set; }
    }

    public class BusinessPartnerEditViewModel
    {
        public long? Id { get; set; }

        [Required]
        [Display(Name = "Code")]
        [Remote("ExtCheckDuplicateBusinessPartner", "Validation", AreaReference.UseRoot, AdditionalFields = "Id", ErrorMessage = "Code already exists. Please specify another one.")]
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

        [Display(Name = "Mail")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Mail { get; set; }

        [Display(Name = "Vat Code")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String VatCode { get; set; }

        [Display(Name = "Contact Name")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String ContactName { get; set; }

        [Display(Name = "Group 1")]
        public long? BusinessPartnerGroupId1 { get; set; }

        [Display(Name = "Group 2")]
        public long? BusinessPartnerGroupId2 { get; set; }

        [Display(Name = "Group 3")]
        public long? BusinessPartnerGroupId3 { get; set; }

        [Required]
        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }

        public Int64 Version { get; set; }
    }

    public class BusinessPartnerLookupViewModel
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

        [Display(Name = "Address")]
        public String Address { get; set; }

        [Display(Name = "Telephone")]
        public String Telephone { get; set; }

        [Display(Name = "Mobilephone")]
        public String Mobilephone { get; set; }

        [Display(Name = "Mail")]
        public String Mail { get; set; }

        [Display(Name = "Vat Code")]
        public String VatCode { get; set; }

        [Display(Name = "Contact Name")]
        public String ContactName { get; set; }

        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }
    }
}