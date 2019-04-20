﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 04/20/2019 10:57:25 PM
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
    public partial class Option
    {

        public Option()
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

        public virtual long? SalesPosLocationId
        {
            get;
            set;
        }

        public virtual long? SalesPosSequenceId
        {
            get;
            set;
        }

        public virtual long? SalesOrderSequenceId
        {
            get;
            set;
        }

        public virtual long? SalesShipmentSeqId
        {
            get;
            set;
        }

        public virtual long? SalesInvoiceSeqId
        {
            get;
            set;
        }

        public virtual long? PurchOrderSequenceId
        {
            get;
            set;
        }

        public virtual long? PurchReceiveSeqId
        {
            get;
            set;
        }

        public virtual long? PurchInvoiceSeqId
        {
            get;
            set;
        }

        public virtual long? OneTimeBusinessPartnerId
        {
            get;
            set;
        }

        public virtual long? GeneralLedgerSequenceId
        {
            get;
            set;
        }

        public virtual long? CashReceiptSequenceId
        {
            get;
            set;
        }

        public virtual long? CashPaymentSequenceId
        {
            get;
            set;
        }

        public virtual long? BankReceiptSequenceId
        {
            get;
            set;
        }

        public virtual long? BankCheckqueSequenceId
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
        public virtual short Status
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
        public virtual global::System.DateTime RecCreatedAt
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
        public virtual User RecModifiedByUser
        {
            get;
            set;
        }
        public virtual NoSequence SalesPosSequence
        {
            get;
            set;
        }
        public virtual NoSequence SalesOrderSequence
        {
            get;
            set;
        }
        public virtual NoSequence SalesShipmentSequence
        {
            get;
            set;
        }
        public virtual NoSequence SalesInvoiceSequence
        {
            get;
            set;
        }
        public virtual NoSequence PurchOrderSequence
        {
            get;
            set;
        }
        public virtual NoSequence PurchReceiveSequence
        {
            get;
            set;
        }
        public virtual NoSequence PurchInvoiceSequence
        {
            get;
            set;
        }
        public virtual User RecCreatedByUser
        {
            get;
            set;
        }
        public virtual Location SalesPosLocation
        {
            get;
            set;
        }
        public virtual BusinessPartner OneTimeBusinessPartner
        {
            get;
            set;
        }
        public virtual NoSequence GeneralLedgerSequence
        {
            get;
            set;
        }
        public virtual NoSequence CashReceiptSequence
        {
            get;
            set;
        }
        public virtual NoSequence CashPaymentSequence
        {
            get;
            set;
        }
        public virtual NoSequence BankReceiptSequence
        {
            get;
            set;
        }
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
