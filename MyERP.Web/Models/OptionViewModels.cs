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
        [Display(Name = "Organization", ResourceType = typeof(Resources.Resources))]
        public String OrganizationCode { get; set; }

        [Required]
        [Display(Name = "Organization_Description", ResourceType = typeof(Resources.Resources))]
        public String OrganizationDescription { get; set; }

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

        [Display(Name = "General_Ledger", ResourceType = typeof(Resources.Resources))]
        public long? GeneralLedgerSequenceId { get; set; }

        [Display(Name = "Cash_Receipt", ResourceType = typeof(Resources.Resources))]
        public long? CashReceiptSequenceId { get; set; }

        [Display(Name = "Cash_Payment", ResourceType = typeof(Resources.Resources))]
        public long? CashPaymentSequenceId { get; set; }

        [Display(Name = "Bank_Receipt", ResourceType = typeof(Resources.Resources))]
        public long? BankReceiptSequenceId { get; set; }

        [Display(Name = "Bank_Checkque", ResourceType = typeof(Resources.Resources))]
        public long? BankCheckqueSequenceId { get; set; }

        [Display(Name = "Sales_POS", ResourceType = typeof(Resources.Resources))]
        public long? SalesPosSequenceId { get; set; }

        [Display(Name = "Sales_Order", ResourceType = typeof(Resources.Resources))]
        public long? SalesOrderSequenceId { get; set; }

        [Display(Name = "Sales_Shipment", ResourceType = typeof(Resources.Resources))]
        public long? SalesShipmentSeqId { get; set; }

        [Display(Name = "Sales_Invoice", ResourceType = typeof(Resources.Resources))]
        public long? SalesInvoiceSeqId { get; set; }

        [Display(Name = "Purchase_Order", ResourceType = typeof(Resources.Resources))]
        public long? PurchOrderSequenceId { get; set; }

        [Display(Name = "Purchase_Receive", ResourceType = typeof(Resources.Resources))]
        public long? PurchReceiveSeqId { get; set; }

        [Display(Name = "Purchase_Invoice", ResourceType = typeof(Resources.Resources))]
        public long? PurchInvoiceSeqId { get; set; }

        [Display(Name = "One_Time_Business_Partner", ResourceType = typeof(Resources.Resources))]
        public long? OneTimeBusinessPartnerId { get; set; }

        [Required]
        [Display(Name = "Blocked", ResourceType = typeof(Resources.Resources))]
        public Boolean Blocked { get; set; }

        public Int64 Version { get; set; }
    }
}