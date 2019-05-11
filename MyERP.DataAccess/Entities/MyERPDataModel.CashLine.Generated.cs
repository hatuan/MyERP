﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 05/11/2019 4:21:04 PM
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
    public partial class CashLine
    {

        public CashLine()
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
        public virtual long CashHeaderId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long LineNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte DocumentType
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string DocumentNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime PostingDate
        {
            get;
            set;
        }

        public virtual long? BusinessPartnerId
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

        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string Description
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal Amount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal AmountLCY
        {
            get;
            set;
        }

        public virtual long? JobId
        {
            get;
            set;
        }

        public virtual long? AccountsPayableLedgerId
        {
            get;
            set;
        }

        public virtual long? AccountsReceivableLedgerId
        {
            get;
            set;
        }

        public virtual decimal? AccountsRPAmountConv
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
        public virtual long ClientId
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
        public virtual CashHeader CashHeader
        {
            get;
            set;
        }
        public virtual BusinessPartner BusinessPartner
        {
            get;
            set;
        }
        public virtual Account CorrespAccount
        {
            get;
            set;
        }
        public virtual AccountsReceivableLedger AccountsReceivableLedger
        {
            get;
            set;
        }
        public virtual AccountsPayableLedger AccountsPayableLedger
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
        public virtual Job Job
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
