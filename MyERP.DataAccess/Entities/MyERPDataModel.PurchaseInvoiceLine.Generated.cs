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
    public partial class PurchaseInvoiceLine
    {

        public PurchaseInvoiceLine()
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
        public virtual long PurchaseHeaderId
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

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long LineNo
        {
            get;
            set;
        }

        /// <summary>
        /// 0 - Comment
        /// 1 - Item
        /// </summary>
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

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal PurchasePrice
        {
            get;
            set;
        }

        /// <summary>
        /// Khong su dung
        /// </summary>
        public virtual long? DiscountId
        {
            get;
            set;
        }

        /// <summary>
        /// Khong su dung
        /// </summary>
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
        public virtual decimal LineAmount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal PurchasePriceLCY
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
        public virtual decimal LineAmountLCY
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
        public virtual decimal InvoiceDiscountAmountLCY
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
        public virtual decimal UnitPriceLCY
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

        /// <summary>
        /// Chi phi
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal ChargeAmount
        {
            get;
            set;
        }

        /// <summary>
        /// Chi phi LCY
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal? ChargeAmountLCY
        {
            get;
            set;
        }

        /// <summary>
        /// Thue nhap khau
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal ImportDutyAmount
        {
            get;
            set;
        }

        /// <summary>
        /// Thuye nhap khau LCY
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal ImportDutyAmountLCY
        {
            get;
            set;
        }

        /// <summary>
        /// Thue tieu thu dac biet
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal ExciseTaxAmount
        {
            get;
            set;
        }

        /// <summary>
        /// Thue tieu thu dac biet LCY
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal ExciseTaxAmountLCY
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal VatBaseAmount
        {
            get;
            set;
        }

        public virtual long? VatId
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

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal VatBaseAmountLCY
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
        public virtual decimal CostPrice
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CostPriceQtyBase
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
        public virtual decimal CostPriceLCY
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CostPriceQtyBaseLCY
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

        public virtual long? InventoryAccountId
        {
            get;
            set;
        }

        public virtual long? JobId
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
        public virtual PurchaseInvoiceHeader PurchaseInvoiceHeader
        {
            get;
            set;
        }
        public virtual Location Location
        {
            get;
            set;
        }
        public virtual Organization Organization
        {
            get;
            set;
        }
        public virtual Client Client
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
        public virtual Job Job
        {
            get;
            set;
        }
        public virtual Account InventoryAccount
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
