﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 04/21/2021 10:23:21 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    public partial class PurchaseLine
    {

        public PurchaseLine()
        {
            OnCreated();
        }

        #region Properties

        [Key]
        [Required()]
        public virtual long Id { get; set; }

        [Required()]
        public virtual long PurchaseHeaderId { get; set; }

        [Required()]
        public virtual byte DocumentType { get; set; }

        [StringLength(32)]
        [Required()]
        public virtual string DocumentNo { get; set; }

        [Required()]
        public virtual long LineNo { get; set; }

        [Required()]
        public virtual byte Type { get; set; }

        public virtual long? ItemId { get; set; }

        [Required()]
        public virtual long LocationId { get; set; }

        [StringLength(256)]
        public virtual string Description { get; set; }

        public virtual long? UomId { get; set; }

        [StringLength(256)]
        public virtual string UomDescription { get; set; }

        [Required()]
        public virtual decimal Quantity { get; set; }

        [Required()]
        public virtual decimal UnitPrice { get; set; }

        [Required()]
        public virtual decimal Amount { get; set; }

        [Required()]
        public virtual decimal UnitPriceLCY { get; set; }

        [Required()]
        public virtual decimal AmountLCY { get; set; }

        public virtual long? DiscountId { get; set; }

        [Required()]
        public virtual byte LineDiscountPercentage { get; set; }

        [Required()]
        public virtual decimal LineDiscountAmount { get; set; }

        [Required()]
        public virtual decimal LineDiscountAmountLCY { get; set; }

        [Required()]
        public virtual decimal InvoiceDiscountAmount { get; set; }

        [Required()]
        public virtual decimal InvoiceDiscountAmountLCY { get; set; }

        [Required()]
        public virtual decimal CostUnit { get; set; }

        [Required()]
        public virtual decimal CostUnitLCY { get; set; }

        [Required()]
        public virtual decimal CostAmount { get; set; }

        [Required()]
        public virtual decimal CostAmountLCY { get; set; }

        [Required()]
        public virtual decimal QuantityReceived { get; set; }

        [Required()]
        public virtual decimal OutstandingQuantity { get; set; }

        [Required()]
        public virtual decimal QuantityInvoiced { get; set; }

        [Required()]
        public virtual decimal QtyReceivedNotInvoiced { get; set; }

        [Required()]
        public virtual decimal QtyPerUom { get; set; }

        [Required()]
        public virtual decimal QuantityBase { get; set; }

        [Required()]
        public virtual decimal OutstandingQtyBase { get; set; }

        [Required()]
        public virtual decimal QuantityReceivedBase { get; set; }

        [Required()]
        public virtual decimal QuantityInvoicedBase { get; set; }

        [Required()]
        public virtual decimal QtyReceivedNotInvoicedBase { get; set; }

        [Required()]
        public virtual long OrganizationId { get; set; }

        [Required()]
        public virtual long ClientId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual PurchaseHeader PurchaseHeader { get; set; }
        public virtual Location Location { get; set; }
        public virtual Client Client { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Uom Uom { get; set; }
        public virtual Item Item { get; set; }

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
