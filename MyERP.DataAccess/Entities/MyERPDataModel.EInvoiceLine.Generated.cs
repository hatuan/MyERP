﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 04/12/2019 4:54:58 PM
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
    public partial class EInvoiceLine
    {

        public EInvoiceLine()
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
        public virtual long EInvoiceHeaderId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long LineNumber
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long ItemId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string ItemCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string ItemName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long UnitId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(10)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string UnitCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string UnitName
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
        public virtual decimal Quantity
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal ItemTotalAmountWithoutVAT
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal ItemTotalAmountWithoutVATLCY
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

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal VATPercentage
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal VATAmount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal VATAmountLCY
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal ItemTotalAmountWithVAT
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal ItemTotalAmountWithVATLCY
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte Promotion
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal AdjustmentVATAmount
        {
            get;
            set;
        }

        public virtual bool? IsIncreaseItem
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

        #endregion

        #region Navigation Properties
        public virtual EInvoiceHeader EInvoiceHeader
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
        public virtual Vat Vat
        {
            get;
            set;
        }
        public virtual Item Item
        {
            get;
            set;
        }
        public virtual Uom Uom
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
