﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 11/24/2018 5:28:32 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace MyERP.DataAccess
{

    /// <summary>
    /// There are no comments for MyERP.DataAccess.PurchaseInvoiceHeader in the schema.
    /// </summary>
    public partial class PurchaseInvoiceHeader    {

        public PurchaseInvoiceHeader()
        {
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long Id
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DocumentType in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte DocumentType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DocSequenceId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long DocSequenceId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DocumentNo in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string DocumentNo
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DocumentDate in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime DocumentDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PostingDate in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime PostingDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyFromVendorId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long BuyFromVendorId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyFromVendorName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string BuyFromVendorName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyFromAddress in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyFromAddress
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyFromContactId in the schema.
        /// </summary>
        public virtual long? BuyFromContactId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyFromContactName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string BuyFromContactName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PayToVendorId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long PayToVendorId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PayToName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string PayToName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PayToAddress in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string PayToAddress
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PayToContactId in the schema.
        /// </summary>
        public virtual long? PayToContactId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PayToContactName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string PayToContactName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PayToVatCode in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string PayToVatCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// Ten nhom vat tu khi ke khai hoa don VAT dau ra
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string PayToVatNote
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountPayableId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long AccountPayableId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ShipToName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string ShipToName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ShipToAddress in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string ShipToAddress
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ShipToContactName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string ShipToContactName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrencyId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long CurrencyId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrencyFactor in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CurrencyFactor
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LocationId in the schema.
        /// </summary>
        public virtual long? LocationId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SalesPersonId in the schema.
        /// </summary>
        public virtual long? SalesPersonId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalLineAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalLineAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalLineAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalLineAmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalAmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalChargeAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalChargeAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalChargeAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalChargeAmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// Khong su dung
        /// </summary>
        public virtual long? DiscountId
        {
            get;
            set;
        }

    
        /// <summary>
        /// Khong su dung
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte InvoiceDiscountPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceDiscountAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal InvoiceDiscountAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceDiscountAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal InvoiceDiscountAmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalImportDutyAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalImportDutyAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalImportDutyAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalImportDutyAmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalExciseTaxAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalExciseTaxAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalExciseTaxAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalExciseTaxAmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalVatAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalVatAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalVatAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalVatAmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalPayment in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalPayment
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalPaymentLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalPaymentLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NoPrinted in the schema.
        /// </summary>
        public virtual int? NoPrinted
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for QuoteId in the schema.
        /// </summary>
        public virtual long? QuoteId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CampaignId in the schema.
        /// </summary>
        public virtual long? CampaignId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OpportunityId in the schema.
        /// </summary>
        public virtual long? OpportunityId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganizationId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long OrganizationId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClientId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long ClientId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RecCreatedAt in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime RecCreatedAt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RecCreatedBy in the schema.
        /// </summary>
        public virtual long? RecCreatedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RecModifiedAt in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime RecModifiedAt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RecModifiedBy in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long RecModifiedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Status in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual short Status
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Version in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long Version
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for PurchaseInvoiceLines in the schema.
        /// </summary>
        public virtual ICollection<PurchaseInvoiceLine> PurchaseInvoiceLines
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Client in the schema.
        /// </summary>
        public virtual Client Client
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Organization in the schema.
        /// </summary>
        public virtual Organization Organization
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for RecCreatedByUser in the schema.
        /// </summary>
        public virtual User RecCreatedByUser
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for RecModifiedByUser in the schema.
        /// </summary>
        public virtual User RecModifiedByUser
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Currency in the schema.
        /// </summary>
        public virtual Currency Currency
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NoSequence in the schema.
        /// </summary>
        public virtual NoSequence NoSequence
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BuyFromVendor in the schema.
        /// </summary>
        public virtual BusinessPartner BuyFromVendor
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PayToVendor in the schema.
        /// </summary>
        public virtual BusinessPartner PayToVendor
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Location in the schema.
        /// </summary>
        public virtual Location Location
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for AccountPayable in the schema.
        /// </summary>
        public virtual Account AccountPayable
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for VatEntries in the schema.
        /// </summary>
        public virtual ICollection<VatEntry> VatEntries
        {
            get;
            set;
        }

        #endregion
    
        #region Extensibility Method Definitions
        partial void OnCreated();
        #endregion
    }

}
