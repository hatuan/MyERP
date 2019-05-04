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
    public partial class SalesLine
    {

        public SalesLine()
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

        public virtual long? SalesHeaderId
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
        public virtual long LineNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte Type
        {
            get;
            set;
        }

        public virtual global::System.DateTime? PostingDate
        {
            get;
            set;
        }

        public virtual long? ItemId
        {
            get;
            set;
        }

        public virtual long? LocationId
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

        public virtual long? UomId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string UomDescription
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal Quantity
        {
            get;
            set;
        }

        public virtual long? SalesPriceId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal UnitPrice
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
        public virtual decimal UnitPriceLCY
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

        public virtual long? DiscountId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CostUnit
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CostUnitLCY
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CostAmount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CostAmountLCY
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal QuantityShipped
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal OutstandingQuantity
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal QuantityInvoiced
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal QtyShippedNotInvoiced
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal QtyPerUom
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal QuantityBase
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal OutstandingQtyBase
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal QuantityShippedBase
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal QuantityInvoicedBase
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal QtyShippedNotInvoicedBase
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

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long VatId
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
        public virtual SalesHeader SalesHeader
        {
            get;
            set;
        }
        public virtual Location Location
        {
            get;
            set;
        }
        public virtual SalesPrice SalesPrice
        {
            get;
            set;
        }
        public virtual Vat Vat
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
