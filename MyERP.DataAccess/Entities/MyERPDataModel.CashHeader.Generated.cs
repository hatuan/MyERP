﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 12/11/2018 10:45:15 PM
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
    /// There are no comments for MyERP.DataAccess.CashHeader in the schema.
    /// </summary>
    public partial class CashHeader    {

        public CashHeader()
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
        /// There are no comments for DocSubType in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte DocSubType
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
        /// There are no comments for BusinessPartnerId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long BusinessPartnerId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusinessPartnerName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BusinessPartnerName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusinessPartnerAddress in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string BusinessPartnerAddress
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusinessPartnerContactId in the schema.
        /// </summary>
        public virtual long? BusinessPartnerContactId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusinessPartnerContactName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string BusinessPartnerContactName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long AccountId
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
        /// There are no comments for TotalAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalAmount
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
        /// There are no comments for TotalPayment in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalPayment
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
        /// There are no comments for TotalVatAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal TotalVatAmountLCY
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
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long RecCreatedBy
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
        public virtual byte Status
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
        /// There are no comments for CashLines in the schema.
        /// </summary>
        public virtual ICollection<CashLine> CashLines
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BusinessPartner in the schema.
        /// </summary>
        public virtual BusinessPartner BusinessPartner
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
        /// There are no comments for Account in the schema.
        /// </summary>
        public virtual Account Account
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
