using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Ext.Net;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class SalesPriceViewModel
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

    public class SalesPriceEditViewModel
    {
        public string ExtId { get; set; }

        public long? Id { get; set; }

        [Required]
        [Display(Name = "Price Group")]
        public long? SalesPriceGroupId { get; set; }

        [Display(Name = "Price Group")]
        public String SalesPriceGroupCode { get; set; }

        [Required]
        [Display(Name = "Sales Type")]
        public short SalesType { get; set; }

        [Required]
        [Display(Name = "Sales Code")]
        public long? SalesCodeId { get; set; }

        [Display(Name = "Sales Code")]
        public String SalesCode { get; set; }

        public ExtNetComboBoxModel SalesModel { get; set; }

        [Required]
        [Display(Name = "Item")]
        public long ItemId { get; set; }

        [Display(Name = "Item")]
        public String ItemCode { get; set; }

        [Display(Name = "Item Description")]
        public String ItemDescription { get; set; }

        public Item Item { get; set; }

        [Required]
        [Display(Name = "UOM")]
        public long? UomId { get; set; }

        [Display(Name = "UOM")]
        public String UomCode { get; set; }

        [Display(Name = "Uom Description")]
        public String UomDescription { get; set; }

        public Uom Uom { get; set; }

        [Display(Name = "Starting Date")]
        [DataType(DataType.Date)]
        public DateTime? StartingDate { get; set; }

        [Display(Name = "MinQty")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal? MinQty { get; set; }

        [Display(Name = "Unit Price")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal? UnitPrice { get; set; }

        [Display(Name = "Ending Date")]
        [DataType(DataType.Date)]
        public DateTime? EndingDate { get; set; }

        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }

        public Int64 Version { get; set; }
    }

    public class GetPriceDTO
    {
        public long OrgId { get; set; }
        public long BusPartId { get; set; }
        public DateTime WorkingDate { get; set; }
        public long ItemId { get; set; }
        public long UomId { get; set; }
        public Decimal Qty { get; set; }
        public Decimal UnitPrice { get; set; }
        public long SalesPriceId { get; set; }
    }
}