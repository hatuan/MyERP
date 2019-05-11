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
    public partial class PosLine
    {

        public PosLine()
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

        public virtual long? PosHeaderId
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

        public virtual long? VatIdentifierId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual short VatPercentage
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal VatAmount
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
        public virtual byte LineDiscountPercentage
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal LineDiscountAmount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal InvoiceDiscountAmount
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

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal VatAmountLCY
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal LineDiscountAmountLCY
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal InvoiceDiscountAmountLCY
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
        public virtual PosHeader PosHeader
        {
            get;
            set;
        }
        public virtual SalesPrice SalesPrice
        {
            get;
            set;
        }
        public virtual Location Location
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
