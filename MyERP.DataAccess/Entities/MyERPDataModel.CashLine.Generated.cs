﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/17/2018 2:36:14 PM
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
    /// There are no comments for MyERP.DataAccess.CashLine in the schema.
    /// </summary>
    public partial class CashLine    {

        public CashLine()
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
        /// There are no comments for CashHeaderId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long CashHeaderId
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
        /// There are no comments for DocumentType in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte DocumentType
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
        public virtual global::System.Nullable<long> BusinessPartnerId
        {
            get;
            set;
        }

    
        /// <summary>
        /// corresponding account
        /// </summary>
        /// <remark>
        /// corresponding account
        /// </remark>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long CorrespAccountId
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
        /// There are no comments for Amount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal Amount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal AmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for JobId in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> JobId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountsPayableLedgerId in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> AccountsPayableLedgerId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountsReceivableLedgerId in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> AccountsReceivableLedgerId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountsRPAmountConv in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> AccountsRPAmountConv
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
        /// There are no comments for CashHeader in the schema.
        /// </summary>
        public virtual CashHeader CashHeader
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
        /// There are no comments for CorrespAccount in the schema.
        /// </summary>
        public virtual Account CorrespAccount
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for AccountsReceivableLedger in the schema.
        /// </summary>
        public virtual AccountsReceivableLedger AccountsReceivableLedger
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for AccountsPayableLedger in the schema.
        /// </summary>
        public virtual AccountsPayableLedger AccountsPayableLedger
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

        #endregion
    
        #region Extensibility Method Definitions
        partial void OnCreated();
        #endregion
    }

}
