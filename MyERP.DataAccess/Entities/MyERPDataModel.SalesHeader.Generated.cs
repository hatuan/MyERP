﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 10/13/2018 6:20:15 PM
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
    /// There are no comments for MyERP.DataAccess.SalesHeader in the schema.
    /// </summary>
    public partial class SalesHeader    {

        public SalesHeader()
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
        /// There are no comments for SellToCustomerId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long SellToCustomerId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellToCustomerName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string SellToCustomerName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellToAddress in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellToAddress
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellToContactId in the schema.
        /// </summary>
        public virtual long? SellToContactId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellToContactName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string SellToContactName
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
        /// There are no comments for BillToCustomerId in the schema.
        /// </summary>
        public virtual long? BillToCustomerId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillToName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string BillToName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillToAddress in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string BillToAddress
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillToContactId in the schema.
        /// </summary>
        public virtual long? BillToContactId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillToContactName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string BillToContactName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillToVatCode in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string BillToVatCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// Ten nhom vat tu khi ke khai hoa don VAT dau ra
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string BillToVatNote
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
        public virtual long? CurrencyId
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
        public virtual decimal? TotalAmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalAmountNoVat in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalAmountNoVat
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalAmountVat0 in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalAmountVat0
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalAmountVat5 in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalAmountVat5
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalAmountVat10 in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalAmountVat10
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
        /// There are no comments for TotalVat5Amount in the schema.
        /// </summary>
        public virtual int? TotalVat5Amount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalVat10Amount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalVat10Amount
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
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int NoPrinted
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
        /// There are no comments for SalesLines in the schema.
        /// </summary>
        public virtual ICollection<SalesLine> SalesLines
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
        /// There are no comments for SellToCustomer in the schema.
        /// </summary>
        public virtual BusinessPartner SellToCustomer
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BillToCustomer in the schema.
        /// </summary>
        public virtual BusinessPartner BillToCustomer
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

        #endregion
    
        #region Extensibility Method Definitions
        partial void OnCreated();
        #endregion
    }

}
