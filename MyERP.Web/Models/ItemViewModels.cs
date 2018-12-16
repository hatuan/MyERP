using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Ext.Net;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class ItemViewModel
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

        [Required]
        [Display(Name = "UOM")]
        public String BaseUomCode { get; set; }

        [Display(Name = "Group 1")]
        public String ItemGroup1Code { get; set; }

        [Display(Name = "Group 2")]
        public String ItemGroup2Code { get; set; }

        [Display(Name = "Group 3")]
        public String ItemGroup3Code { get; set; }

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

    public class ItemEditViewModel
    {
        public long? Id { get; set; }

        [Required]
        [Display(Name = "Code")]
        [Remote("ExtCheckDuplicateItem", "Validation", AreaReference.UseRoot, AdditionalFields = "Id", ErrorMessage = "Product code already exists. Please specify another one.")]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Invalid Code - only allow a-z A-Z 0-9 character")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        [Required]
        [Display(Name = "UOM")]
        public long BaseUomId { get; set; }

        [Display(Name = "Unit Cost")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal? UnitCost { get; set; }

        [Display(Name = "Unit Price")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal? UnitPrice { get; set; }

        [Display(Name = "Vat")]
        public long? VatId { get; set; }

        [Display(Name = "Group 1")]
        public long? ItemGroupId1 { get; set; }

        [Display(Name = "Group 2")]
        public long? ItemGroupId2 { get; set; }

        [Display(Name = "Group 3")]
        public long? ItemGroupId3 { get; set; }

        [Display(Name = "Inventory")]
        public long? InventoryAccountId { get; set; }

        [Display(Name = "Consignment")]
        public long? ConsignmentAccountId { get; set; }

        [Display(Name = "Sales")]
        public long? SalesAccountId { get; set; }

        [Display(Name = "Sales Internal")]
        public long? SalesInternalAccountId { get; set; }

        [Display(Name = "Sales Return")]
        public long? SalesReturnAccountId { get; set; }

        [Display(Name = "Sales Discount")]
        public long? SalesDiscountAccountId { get; set; }

        [Display(Name = "COGS")]
        public long? COGSAccountId { get; set; }

        [Display(Name = "COGS Diff")]
        public long? COGSDiffAccountId { get; set; }

        [Display(Name = "WIP")]
        public long? WIPAccountId { get; set; }

        [Required]
        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }

        public Int64 Version { get; set; }
    }
}