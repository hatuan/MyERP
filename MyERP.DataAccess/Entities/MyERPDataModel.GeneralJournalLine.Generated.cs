﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 4/2/2019 10:55:04 PM
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
    /// There are no comments for MyERP.DataAccess.GeneralJournalLine in the schema.
    /// </summary>
    public partial class GeneralJournalLine    {

        public GeneralJournalLine()
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
        /// There are no comments for GeneralJournalHeaderId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long GeneralJournalHeaderId
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
        public virtual global::System.DateTime? PostingDate
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
        /// There are no comments for AccountId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long AccountId
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
        /// There are no comments for DebitAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal DebitAmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DebitAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal DebitAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreditAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CreditAmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreditAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CreditAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusinessPartnerId in the schema.
        /// </summary>
        public virtual long? BusinessPartnerId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for JobId in the schema.
        /// </summary>
        public virtual long? JobId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FixAssetId in the schema.
        /// </summary>
        public virtual long? FixAssetId
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
        /// There are no comments for PostingGroup in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(3)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string PostingGroup
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for GeneralJournalHeader in the schema.
        /// </summary>
        public virtual GeneralJournalHeader GeneralJournalHeader
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
        /// There are no comments for BusinessPartner in the schema.
        /// </summary>
        public virtual BusinessPartner BusinessPartner
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Job in the schema.
        /// </summary>
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
