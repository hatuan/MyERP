﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 06/27/2018 3:26:25 PM
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
    /// There are no comments for MyERP.DataAccess.Option in the schema.
    /// </summary>
    public partial class Option    {

        public Option()
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
        /// There are no comments for PosSequenceId in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> PosSequenceId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SalesOrderSequenceId in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> SalesOrderSequenceId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SalesShipmentSeqId in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> SalesShipmentSeqId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SaleInvoiceSeqId in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> SaleInvoiceSeqId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PurchOrderSequenceId in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> PurchOrderSequenceId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PurchReceiveSeqId in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> PurchReceiveSeqId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PurchInvoiceSeqId in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> PurchInvoiceSeqId
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
        /// There are no comments for RecModifiedByUser in the schema.
        /// </summary>
        public virtual User RecModifiedByUser
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PosSequence in the schema.
        /// </summary>
        public virtual NoSequence PosSequence
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SalesOrderSequence in the schema.
        /// </summary>
        public virtual NoSequence SalesOrderSequence
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SalesShipmentSequence in the schema.
        /// </summary>
        public virtual NoSequence SalesShipmentSequence
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SalesInvoiceSequence in the schema.
        /// </summary>
        public virtual NoSequence SalesInvoiceSequence
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PurchOrderSequence in the schema.
        /// </summary>
        public virtual NoSequence PurchOrderSequence
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PurchReceiveSequence in the schema.
        /// </summary>
        public virtual NoSequence PurchReceiveSequence
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PurchInvoiceSequence in the schema.
        /// </summary>
        public virtual NoSequence PurchInvoiceSequence
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

        #endregion
    
        #region Extensibility Method Definitions
        partial void OnCreated();
        #endregion
    }

}
