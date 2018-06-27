using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Ext.Net;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class OptionViewModel
    {
        [Required]
        public Int64 Id { get; set; }

        [Required]
        [Display(Name = "Org Code")]
        public String OrganizationCode { get; set; }

        [Required]
        [Display(Name = "Org Description")]
        public String OrganizationDescription { get; set; }

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

    public class OptionEditViewModel
    {
        public long? Id { get; set; }

        [Display(Name = "POS")]
        public long? PosSequenceId { get; set; }

        [Display(Name = "Sales Order")]
        public long? SalesOrderSequenceId { get; set; }

        [Display(Name = "Sales Shipment")]
        public long? SalesShipmentSeqId { get; set; }

        [Display(Name = "Sales Invoice")]
        public long? SaleInvoiceSeqId { get; set; }

        [Display(Name = "Purchase Order")]
        public long? PurchOrderSequenceId { get; set; }

        [Display(Name = "Purchase Receive")]
        public long? PurchReceiveSeqId { get; set; }

        [Display(Name = "Purchase Invoice")]
        public long? PurchInvoiceSeqId { get; set; }

        [Required]
        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }

        public Int64 Version { get; set; }
    }
}