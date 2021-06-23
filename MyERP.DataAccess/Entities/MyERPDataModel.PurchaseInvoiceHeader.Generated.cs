﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 04/21/2021 10:23:21 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    public partial class PurchaseInvoiceHeader
    {

        public PurchaseInvoiceHeader()
        {
            OnCreated();
        }

        #region Properties

        [Key]
        [Required()]
        public virtual long Id { get; set; }

        [Required()]
        public virtual byte DocumentType { get; set; }

        [Required()]
        public virtual byte DocSubType { get; set; }

        [Required()]
        public virtual long DocSequenceId { get; set; }

        [StringLength(32)]
        [Required()]
        public virtual string DocumentNo { get; set; }

        [Required()]
        public virtual global::System.DateTime DocumentDate { get; set; }

        [Required()]
        public virtual global::System.DateTime PostingDate { get; set; }

        [Required()]
        public virtual long BuyFromVendorId { get; set; }

        [StringLength(256)]
        [Required()]
        public virtual string BuyFromVendorName { get; set; }

        [StringLength(256)]
        [Required()]
        public virtual string BuyFromAddress { get; set; }

        public virtual long? BuyFromContactId { get; set; }

        [StringLength(256)]
        [Required()]
        public virtual string BuyFromContactName { get; set; }

        [StringLength(256)]
        [Required()]
        public virtual string Description { get; set; }

        [Required()]
        public virtual long PayToVendorId { get; set; }

        [StringLength(256)]
        [Required()]
        public virtual string PayToName { get; set; }

        [StringLength(256)]
        [Required()]
        public virtual string PayToAddress { get; set; }

        public virtual long? PayToContactId { get; set; }

        [StringLength(256)]
        [Required()]
        public virtual string PayToContactName { get; set; }

        [StringLength(32)]
        [Required()]
        public virtual string PayToVatCode { get; set; }

        /// <summary>
        /// Ten nhom vat tu khi ke khai hoa don VAT dau ra
        /// </summary>
        [StringLength(256)]
        [Required()]
        public virtual string PayToVatNote { get; set; }

        [Required()]
        public virtual long AccountPayableId { get; set; }

        [StringLength(256)]
        [Required()]
        public virtual string ShipToName { get; set; }

        [StringLength(256)]
        [Required()]
        public virtual string ShipToAddress { get; set; }

        [StringLength(256)]
        [Required()]
        public virtual string ShipToContactName { get; set; }

        [Required()]
        public virtual long CurrencyId { get; set; }

        [Required()]
        public virtual decimal CurrencyFactor { get; set; }

        public virtual long? LocationId { get; set; }

        public virtual long? SalesPersonId { get; set; }

        [Required()]
        public virtual decimal TotalLineAmount { get; set; }

        [Required()]
        public virtual decimal TotalLineAmountLCY { get; set; }

        [Required()]
        public virtual decimal TotalAmount { get; set; }

        [Required()]
        public virtual decimal TotalAmountLCY { get; set; }

        [Required()]
        public virtual decimal TotalChargeAmount { get; set; }

        [Required()]
        public virtual decimal TotalChargeAmountLCY { get; set; }

        /// <summary>
        /// Khong su dung
        /// </summary>
        public virtual long? DiscountId { get; set; }

        /// <summary>
        /// Khong su dung
        /// </summary>
        [Required()]
        public virtual byte InvoiceDiscountPercentage { get; set; }

        [Required()]
        public virtual decimal InvoiceDiscountAmount { get; set; }

        [Required()]
        public virtual decimal InvoiceDiscountAmountLCY { get; set; }

        [Required()]
        public virtual decimal TotalImportDutyAmount { get; set; }

        [Required()]
        public virtual decimal TotalImportDutyAmountLCY { get; set; }

        [Required()]
        public virtual decimal TotalExciseTaxAmount { get; set; }

        [Required()]
        public virtual decimal TotalExciseTaxAmountLCY { get; set; }

        [Required()]
        public virtual decimal TotalVatAmount { get; set; }

        [Required()]
        public virtual decimal TotalVatAmountLCY { get; set; }

        [Required()]
        public virtual decimal TotalPayment { get; set; }

        [Required()]
        public virtual decimal TotalPaymentLCY { get; set; }

        public virtual int? NoPrinted { get; set; }

        public virtual long? QuoteId { get; set; }

        public virtual long? CampaignId { get; set; }

        public virtual long? OpportunityId { get; set; }

        [Required()]
        public virtual long OrganizationId { get; set; }

        [Required()]
        public virtual long ClientId { get; set; }

        [Required()]
        public virtual global::System.DateTime RecCreatedAt { get; set; }

        [Required()]
        public virtual long RecCreatedBy { get; set; }

        [Required()]
        public virtual global::System.DateTime RecModifiedAt { get; set; }

        [Required()]
        public virtual long RecModifiedBy { get; set; }

        [Required()]
        public virtual short Status { get; set; }

        [Required()]
        public virtual long Version { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<PurchaseInvoiceLine> PurchaseInvoiceLines { get; set; }
        public virtual Client Client { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual User RecCreatedByUser { get; set; }
        public virtual User RecModifiedByUser { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual NoSequence NoSequence { get; set; }
        public virtual BusinessPartner BuyFromVendor { get; set; }
        public virtual BusinessPartner PayToVendor { get; set; }
        public virtual Location Location { get; set; }
        public virtual Account AccountPayable { get; set; }
        public virtual ICollection<VatEntry> VatEntries { get; set; }

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
