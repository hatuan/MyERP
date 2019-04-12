﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 04/12/2019 4:54:58 PM
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
    public partial class EInvoiceHeader
    {

        public EInvoiceHeader()
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

        public virtual long? OriginalInvoiceId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(7)]
        public virtual string InvoiceNumber
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
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

        /// <summary>
        /// Don&apos;t use in Header
        /// </summary>
        public virtual global::System.DateTime? SignedDate
        {
            get;
            set;
        }

        /// <summary>
        /// Don&apos;t use in Header
        /// </summary>
        public virtual global::System.DateTime? SubmittedDate
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

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long CurrencyId
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

        public virtual long? BuyerId
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
        public virtual string BuyerPostalCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string BuyerDistrictName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string BuyerCityName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(2)]
        public virtual string BuyerCountryCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        public virtual string BuyerPhoneNumber
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        public virtual string BuyerFaxNumber
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string BuyerEmail
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string BuyerBankName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
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
        public virtual string SellerPostalCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string SellerDistrictName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string SellerCityName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(2)]
        public virtual string SellerCountryCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        public virtual string SellerPhoneNumber
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        public virtual string SellerFaxNumber
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string SellerEmail
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string SellerBankName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(20)]
        public virtual string SellerBankAccount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string SellerContactPersonName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public virtual string SellerSignedPersonName
        {
            get;
            set;
        }

        /// <summary>
        /// Don&apos;t use in Header
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(100)]
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

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalVATAmount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalAmountWithVAT
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

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string TotalAmountWithVATInWords
        {
            get;
            set;
        }

        public virtual bool? IsTotalAmountPos
        {
            get;
            set;
        }

        public virtual bool? IsTotalVATAmountPos
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
        public virtual ICollection<EInvoiceLine> EInvoiceLines
        {
            get;
            set;
        }
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
        public virtual User RecCreatedByUser
        {
            get;
            set;
        }
        public virtual User RecModifiedByUser
        {
            get;
            set;
        }
        public virtual BusinessPartner Buyer
        {
            get;
            set;
        }
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
