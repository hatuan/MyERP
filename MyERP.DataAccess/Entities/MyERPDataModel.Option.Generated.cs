﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 10/27/2018 4:01:09 PM
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
        /// There are no comments for SalesPosLocationId in the schema.
        /// </summary>
        public virtual long? SalesPosLocationId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SalesPosSequenceId in the schema.
        /// </summary>
        public virtual long? SalesPosSequenceId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SalesOrderSequenceId in the schema.
        /// </summary>
        public virtual long? SalesOrderSequenceId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SalesShipmentSeqId in the schema.
        /// </summary>
        public virtual long? SalesShipmentSeqId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SalesInvoiceSeqId in the schema.
        /// </summary>
        public virtual long? SalesInvoiceSeqId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PurchOrderSequenceId in the schema.
        /// </summary>
        public virtual long? PurchOrderSequenceId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PurchReceiveSeqId in the schema.
        /// </summary>
        public virtual long? PurchReceiveSeqId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PurchInvoiceSeqId in the schema.
        /// </summary>
        public virtual long? PurchInvoiceSeqId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OneTimeBusinessPartnerId in the schema.
        /// </summary>
        public virtual long? OneTimeBusinessPartnerId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GeneralLedgerSequenceId in the schema.
        /// </summary>
        public virtual long? GeneralLedgerSequenceId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CashReceiptSequenceId in the schema.
        /// </summary>
        public virtual long? CashReceiptSequenceId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CashPaymentSequenceId in the schema.
        /// </summary>
        public virtual long? CashPaymentSequenceId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BankReceiptSequenceId in the schema.
        /// </summary>
        public virtual long? BankReceiptSequenceId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BankCheckqueSequenceId in the schema.
        /// </summary>
        public virtual long? BankCheckqueSequenceId
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
        /// There are no comments for SalesPosSequence in the schema.
        /// </summary>
        public virtual NoSequence SalesPosSequence
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
    
        /// <summary>
        /// There are no comments for SalesPosLocation in the schema.
        /// </summary>
        public virtual Location SalesPosLocation
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OneTimeBusinessPartner in the schema.
        /// </summary>
        public virtual BusinessPartner OneTimeBusinessPartner
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for GeneralLedgerSequence in the schema.
        /// </summary>
        public virtual NoSequence GeneralLedgerSequence
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for CashReceiptSequence in the schema.
        /// </summary>
        public virtual NoSequence CashReceiptSequence
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for CashPaymentSequence in the schema.
        /// </summary>
        public virtual NoSequence CashPaymentSequence
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BankReceiptSequence in the schema.
        /// </summary>
        public virtual NoSequence BankReceiptSequence
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BankCheckque in the schema.
        /// </summary>
        public virtual NoSequence BankCheckque
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
