using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Ext.Net;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class ItemUomViewModel
    {
        [Required]
        public Int64 Id { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public String OrganizationCode { get; set; }
        
        [Required]
        [Display(Name = "UOM")]
        public String UomCode { get; set; }

        [Required]
        [Display(Name = "Item")]
        public String ItemCode { get; set; }

        [Required]
        [Display(Name = "QtyPerUom")]
        public Decimal QtyPerUom { get; set; }

        [Required]
        [Display(Name = "IsBaseUOM")]
        public Boolean IsBaseUOM { get; set; }

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

    public class ItemUomEditViewModel
    {
        public long? Id { get; set; }

        [Required]
        [Display(Name = "UOM")]
        public long UomId { get; set; }

        [Display(Name = "Item")]
        public long ItemId { get; set; }

        [Display(Name = "QtyPerUom")]
        public Decimal QtyPerUom { get; set; }

        [Required]
        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }

        public Int64 Version { get; set; }
    }

    public class ItemUomLookUpViewModel
    {
        [Display(Name = "UOM")]
        public long UomId { get; set; }

        [Display(Name = "Code")]
        public String Code { get; set; }

        [Display(Name = "Description")]
        public String Description { get; set; }

        [Display(Name = "QtyPerUom")]
        public Decimal QtyPerUom { get; set; }

    }
}