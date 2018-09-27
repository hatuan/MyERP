﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 09/27/2018 8:53:02 PM
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
    /// There are no comments for MyERP.DataAccess.PurchaseInvoiceLine in the schema.
    /// </summary>
    public partial class PurchaseInvoiceLine    {

        public PurchaseInvoiceLine()
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
        /// There are no comments for PostingDate in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime PostingDate
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
        /// There are no comments for PurchasePrice in the schema.
        /// </summary>
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
        /// There are no comments for LineAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal LineAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PurchasePriceLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal PurchasePriceLCY
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
        /// There are no comments for LineAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal LineAmountLCY
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
        /// There are no comments for UnitPrice in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal UnitPrice
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
        /// There are no comments for Amount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal Amount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AmountLCY in the schema.
        /// </summary>
        public virtual decimal? AmountLCY
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

    
        /// <summary>
        /// There are no comments for VatBaseAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal VatBaseAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VatId in the schema.
        /// </summary>
        public virtual long? VatId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VatPercentage in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte VatPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VatAmount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal VatAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VatBaseAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal VatBaseAmountLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VatAmountLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal VatAmountLCY
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
        /// There are no comments for CostPrice in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CostPrice
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CostPriceQtyBase in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CostPriceQtyBase
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
        /// There are no comments for CostPriceLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CostPriceLCY
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CostPriceQtyBaseLCY in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal CostPriceQtyBaseLCY
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
        /// There are no comments for PurchaseInvoiceHeader in the schema.
        /// </summary>
        public virtual PurchaseInvoiceHeader PurchaseInvoiceHeader
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
        /// There are no comments for Organization in the schema.
        /// </summary>
        public virtual Organization Organization
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
        /// There are no comments for Vat in the schema.
        /// </summary>
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
