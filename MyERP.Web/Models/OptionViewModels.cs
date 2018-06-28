﻿using System;
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
        [Display(Name = "Organization", ResourceType = typeof(Resources.Resources))]
        public String OrganizationCode { get; set; }

        [Required]
        [Display(Name = "Organization_Description", ResourceType = typeof(Resources.Resources))]
        public String OrganizationDescription { get; set; }

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
        [Display(Name = "Created_At", ResourceType = typeof(Resources.Resources))]
        public DateTime RecCreatedAt { get; set; }

        [Required]
        [Display(Name = "Modified_By", ResourceType = typeof(Resources.Resources))]
        public String RecModifiedBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Modified_At", ResourceType = typeof(Resources.Resources))]
        public DateTime RecModifiedAt { get; set; }
    }

    public class OptionEditViewModel
    {
        public long? Id { get; set; }

        [Required]
        public long OrganizationId { get; set; }

        [Required]
        public long RootOrganizationId { get; set; }

        [Display(Name = "Sales_POS", ResourceType = typeof(Resources.Resources))]
        public long? SalesPosSequenceId { get; set; }

        [Display(Name = "Sales_Order", ResourceType = typeof(Resources.Resources))]
        public long? SalesOrderSequenceId { get; set; }

        [Display(Name = "Sales_Shipment", ResourceType = typeof(Resources.Resources))]
        public long? SalesShipmentSeqId { get; set; }

        [Display(Name = "Sales_Invoice", ResourceType = typeof(Resources.Resources))]
        public long? SaleInvoiceSeqId { get; set; }

        [Display(Name = "Purchase_Order", ResourceType = typeof(Resources.Resources))]
        public long? PurchOrderSequenceId { get; set; }

        [Display(Name = "Purchase_Receive", ResourceType = typeof(Resources.Resources))]
        public long? PurchReceiveSeqId { get; set; }

        [Display(Name = "Purchase_Invoice", ResourceType = typeof(Resources.Resources))]
        public long? PurchInvoiceSeqId { get; set; }

        [Required]
        [Display(Name = "Status", ResourceType = typeof(Resources.Resources))]
        public DefaultStatusType Status { get; set; }

        public Int64 Version { get; set; }
    }
}