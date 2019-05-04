﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 05/04/2019 2:35:19 PM
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
    public partial class EInvoiceSigned
    {

        public EInvoiceSigned()
        {
            OnCreated();
        }

        #region Properties

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long Id
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long FormTypeId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int FormReleaseNo
        {
            get;
            set;
        }

        public virtual long? OriginalEInvoiceId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string OriginalInvoiceId
        {
            get;
            set;
        }

        public virtual global::System.DateTime? OriginalInvoiceIssueDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(6)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string InvoiceType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(11)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string TemplateCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(6)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string InvoiceSeries
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(7)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string InvoiceNumber
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string InvoiceName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime InvoiceIssuedDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime SignedDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime SubmittedDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string ContractNumber
        {
            get;
            set;
        }

        public virtual global::System.DateTime? ContractDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string Description
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(3)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string CurrencyCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal ExchangeRate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(400)]
        public virtual string InvoiceNote
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte AdjustmentType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string AdditionalReferenceDesc
        {
            get;
            set;
        }

        public virtual global::System.DateTime? AdditionalReferenceDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerDisplayName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerLegalName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(14)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerTaxCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerAddressLine
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(10)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerPostalCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerDistrictName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerCityName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(2)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerCountryCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerPhoneNumber
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerFaxNumber
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerEmail
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerBankName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BuyerBankAccount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerLegalName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(14)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerTaxCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerAddressLine
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(10)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerPostalCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerDistrictName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerCityName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(2)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerCountryCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerPhoneNumber
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerFaxNumber
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerEmail
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerBankName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerBankAccount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerContactPersonName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerSignedPersonName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string SellerSubmittedPersonName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string PaymentMethodName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal SumOfTotalLineAmountWithoutVAT
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalAmountWithoutVAT
        {
            get;
            set;
        }

        public virtual bool? IsTotalAmountWithoutVATPos
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalVATAmount
        {
            get;
            set;
        }

        public virtual bool? IsTotalVATAmountPos
        {
            get;
            set;
        }

        public virtual decimal? TotalAmountWithVAT
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalAmountWithVATFrn
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalAmountWithVATInWords
        {
            get;
            set;
        }

        public virtual bool? IsTotalAmountPos
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal DiscountAmount
        {
            get;
            set;
        }

        public virtual bool? IsDiscountAmtPos
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string EInvoiceSignedXMLFile
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string EInvoiceSignedXSLFile
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string EInvoiceSignedFileName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long ClientId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long OrganizationId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long Version
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte Status
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long RecCreatedBy
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime RecCreatedAt
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long RecModifiedBy
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime RecModifiedAt
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
        public virtual EInvFormType EInvFormType
        {
            get;
            set;
        }
        public virtual Client Client
        {
            get;
            set;
        }
        public virtual Organization Organization
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