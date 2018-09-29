﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 09/29/2018 6:43:56 PM
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
    /// There are no comments for MyERP.DataAccess.PurchaseLine in the schema.
    /// </summary>
    public partial class PurchaseLine    {

        public PurchaseLine()
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
        /// There are no comments for PurchaseHeaderId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long PurchaseHeaderId
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
        /// There are no comments for LineNo in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long LineNo
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Type in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte Type
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ItemId in the schema.
        /// </summary>
        public virtual long? ItemId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LocationId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long LocationId
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
        /// There are no comments for UomId in the schema.
        /// </summary>
        public virtual long? UomId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UomDescription in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string UomDescription
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Quantity in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal Quantity
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UnitPrice in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal UnitPrice
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
        /// There are no comments for UnitPriceLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal UnitPriceLCY
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
        /// There are no comments for DiscountId in the schema.
        /// </summary>
        public virtual long? DiscountId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LineDiscountPercentage in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte LineDiscountPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LineDiscountAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal LineDiscountAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LineDiscountAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal LineDiscountAmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceDiscountAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal InvoiceDiscountAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceDiscountAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal InvoiceDiscountAmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CostUnit in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CostUnit
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CostUnitLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CostUnitLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CostAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CostAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CostAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CostAmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for QuantityReceived in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal QuantityReceived
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OutstandingQuantity in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal OutstandingQuantity
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for QuantityInvoiced in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal QuantityInvoiced
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for QtyReceivedNotInvoiced in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal QtyReceivedNotInvoiced
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for QtyPerUom in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal QtyPerUom
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for QuantityBase in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal QuantityBase
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OutstandingQtyBase in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal OutstandingQtyBase
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for QuantityReceivedBase in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal QuantityReceivedBase
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for QuantityInvoicedBase in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal QuantityInvoicedBase
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for QtyReceivedNotInvoicedBase in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal QtyReceivedNotInvoicedBase
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
        /// There are no comments for PurchaseHeader in the schema.
        /// </summary>
        public virtual PurchaseHeader PurchaseHeader
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Location in the schema.
        /// </summary>
        public virtual Location Location
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
        /// There are no comments for Uom in the schema.
        /// </summary>
        public virtual Uom Uom
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Item in the schema.
        /// </summary>
        public virtual Item Item
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
