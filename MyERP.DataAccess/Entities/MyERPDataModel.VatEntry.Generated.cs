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
    /// There are no comments for MyERP.DataAccess.VatEntry in the schema.
    /// </summary>
    public partial class VatEntry    {

        public VatEntry()
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
        /// There are no comments for DocumentHeaderId in the schema.
        /// </summary>
        public virtual long? DocumentHeaderId
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
        /// There are no comments for DocumentSubType in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte DocumentSubType
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
        /// There are no comments for InvoiceIssuedDate in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime InvoiceIssuedDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceNumber in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string InvoiceNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceSeries in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string InvoiceSeries
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LineNo in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long LineNo
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
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string BusinessPartnerAddress
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TaxCode in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string TaxCode
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
        public virtual long? CurrencyId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrencyFactor in the schema.
        /// </summary>
        public virtual decimal? CurrencyFactor
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VatBaseAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal VatBaseAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VatBaseAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal VatBaseAmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VatId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long VatId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VatPercentage in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal VatPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VatAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal VatAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VatAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal VatAmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountVatId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long AccountVatId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CorrespAccountId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long CorrespAccountId
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for BusinessPartner in the schema.
        /// </summary>
        public virtual BusinessPartner BusinessPartner
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Vat in the schema.
        /// </summary>
        public virtual Vat Vat
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
        /// There are no comments for AccountVat in the schema.
        /// </summary>
        public virtual Account AccountVat
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for CorrespAccount in the schema.
        /// </summary>
        public virtual Account CorrespAccount
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
