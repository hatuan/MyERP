﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 1/20/2019 10:39:55 PM
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
    /// There are no comments for MyERP.DataAccess.EInvoiceHeader in the schema.
    /// </summary>
    public partial class EInvoiceHeader    {

        public EInvoiceHeader()
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
        /// There are no comments for FormTypeId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long FormTypeId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OriginalInvoiceId in the schema.
        /// </summary>
        public virtual long? OriginalInvoiceId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceNumber in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(7)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string InvoiceNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string InvoiceName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceIssuedDate in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime InvoiceIssuedDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SignedDate in the schema.
        /// </summary>
        public virtual global::System.DateTime? SignedDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SubmittedDate in the schema.
        /// </summary>
        public virtual global::System.DateTime? SubmittedDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ContractNumber in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string ContractNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ContractDate in the schema.
        /// </summary>
        public virtual global::System.DateTime? ContractDate
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
        /// There are no comments for CurrencyId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long CurrencyId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ExchangeRate in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal ExchangeRate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceNote in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(400)]
        public virtual string InvoiceNote
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AdjustmentType in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte AdjustmentType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AdditionalReferenceDesc in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string AdditionalReferenceDesc
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AdditionalReferenceDate in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime AdditionalReferenceDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyerId in the schema.
        /// </summary>
        public virtual long? BuyerId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyerDisplayName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerDisplayName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyerLegalName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerLegalName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyerTaxCode in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(14)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerTaxCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyerAddressLine in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerAddressLine
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyerPostalCode in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerPostalCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyerDistrictName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerDistrictName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyerCityName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerCityName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyerCountryCode in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(2)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerCountryCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyerPhoneNumber in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerPhoneNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyerFaxNumber in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerFaxNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyerEmail in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerEmail
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyerBankName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerBankName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuyerBankAccount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerBankAccount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellerLegalName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerLegalName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellerTaxCode in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(14)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerTaxCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellerAddressLine in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerAddressLine
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellerPostalCode in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerPostalCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellerDistrictName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerDistrictName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellerCityName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string SellerCityName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellerCountryCode in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(2)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerCountryCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellerPhoneNumber in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerPhoneNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellerFaxNumber in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerFaxNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellerEmail in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerEmail
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellerBankName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerBankName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellerBankAccount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerBankAccount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellerContactPersonName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerContactPersonName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellerSignedPersonName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerSignedPersonName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SellerSubmittedPersonName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerSubmittedPersonName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PaymentMethodName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string PaymentMethodName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SumOfTotalLineAmountWithoutVAT in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal SumOfTotalLineAmountWithoutVAT
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalAmountWithoutVAT in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalAmountWithoutVAT
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalVATAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalVATAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalAmountWithVAT in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalAmountWithVAT
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalAmountWithVATFrn in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalAmountWithVATFrn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalAmountWithVATInWords in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string TotalAmountWithVATInWords
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsTotalAmountPos in the schema.
        /// </summary>
        public virtual bool? IsTotalAmountPos
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsTotalVATAmountPos in the schema.
        /// </summary>
        public virtual bool? IsTotalVATAmountPos
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal DiscountAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDiscountAmtPos in the schema.
        /// </summary>
        public virtual bool? IsDiscountAmtPos
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
        /// There are no comments for OrganizationId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long OrganizationId
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

    
        /// <summary>
        /// There are no comments for Status in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte Status
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RecCreatedBy in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long RecCreatedBy
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
        /// There are no comments for RecModifiedBy in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long RecModifiedBy
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for EInvoiceLines in the schema.
        /// </summary>
        public virtual ICollection<EInvoiceLine> EInvoiceLines
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for EInvFormType in the schema.
        /// </summary>
        public virtual EInvFormType EInvFormType
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
        /// There are no comments for Buyer in the schema.
        /// </summary>
        public virtual BusinessPartner Buyer
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
