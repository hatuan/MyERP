﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 05/21/2019 11:02:51 PM
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
    public partial class Item
    {

        public Item()
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

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string Code
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(256)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string Description
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long BaseUomId
        {
            get;
            set;
        }

        public virtual decimal? UnitCost
        {
            get;
            set;
        }

        public virtual decimal? UnitPrice
        {
            get;
            set;
        }

        public virtual byte? CostingMethod
        {
            get;
            set;
        }

        public virtual long? ItemDiscountGroupId
        {
            get;
            set;
        }

        public virtual long? ItemGroupId1
        {
            get;
            set;
        }

        public virtual long? ItemGroupId2
        {
            get;
            set;
        }

        public virtual long? ItemGroupId3
        {
            get;
            set;
        }

        public virtual long? PurchVendorId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long SalesUomId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long PurchUomId
        {
            get;
            set;
        }

        public virtual long? VatId
        {
            get;
            set;
        }

        public virtual long? InventoryAccountId
        {
            get;
            set;
        }

        /// <summary>
        /// Tai khoan dai ly
        /// </summary>
        public virtual long? ConsignmentAccountId
        {
            get;
            set;
        }

        public virtual long? SalesAccountId
        {
            get;
            set;
        }

        public virtual long? SalesInternalAccountId
        {
            get;
            set;
        }

        public virtual long? SalesReturnAccountId
        {
            get;
            set;
        }

        public virtual long? SalesDiscountAccountId
        {
            get;
            set;
        }

        public virtual long? COGSAccountId
        {
            get;
            set;
        }

        public virtual long? COGSDiffAccountId
        {
            get;
            set;
        }

        public virtual long? WIPAccountId
        {
            get;
            set;
        }

        /// <summary>
        ///  0-Product Order, 1-Purchase Order, 2-Transfer Order
        /// </summary>
        public virtual byte? ReplenishmentSystem
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string LeadTimeCalc
        {
            get;
            set;
        }

        /// <summary>
        /// 0 - None 1 - Fix ReOrder Qty, 2 - Maximum Qty, 3 - Order, 4 - Lot-to-Lot 
        /// </summary>
        public virtual byte? ReorderingPolicy
        {
            get;
            set;
        }

        public virtual bool? IncludeInventory
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string ReorderCycle
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string SafetyLeadTime
        {
            get;
            set;
        }

        public virtual decimal? SafetyStockQty
        {
            get;
            set;
        }

        public virtual decimal? ReorderPoint
        {
            get;
            set;
        }

        public virtual decimal? MaximumInventory
        {
            get;
            set;
        }

        public virtual decimal? ReorderQty
        {
            get;
            set;
        }

        public virtual decimal? MinimumOrderQty
        {
            get;
            set;
        }

        public virtual decimal? MaximumOrderQty
        {
            get;
            set;
        }

        public virtual byte? OrderMultiple
        {
            get;
            set;
        }

        /// <summary>
        ///  0 - Make-to-Stock, 1 - Make-to-Order
        /// </summary>
        public virtual byte? ManufacturingPolicy
        {
            get;
            set;
        }

        public virtual long? RoutingId
        {
            get;
            set;
        }

        public virtual long? BomId
        {
            get;
            set;
        }

        /// <summary>
        /// 0 - Manual, 1 - Forward, 2 - Backward, 3 - Pick + Forward, 4 - Pick + Backward
        /// </summary>
        public virtual byte? FlushingMethod
        {
            get;
            set;
        }

        public virtual decimal? Scrap
        {
            get;
            set;
        }

        public virtual decimal? LotSize
        {
            get;
            set;
        }

        public virtual byte? LowLevelCode
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
        public virtual global::System.DateTime RecModifiedAt
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

        #endregion

        #region Navigation Properties
        public virtual Uom BaseUom
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
        public virtual User RecCreatedByUser
        {
            get;
            set;
        }
        public virtual User RecModifiedByUser
        {
            get;
            set;
        }
        public virtual ICollection<ItemUom> ItemUoms
        {
            get;
            set;
        }
        public virtual ItemGroup ItemGroup1
        {
            get;
            set;
        }
        public virtual ItemGroup ItemGroup2
        {
            get;
            set;
        }
        public virtual ItemGroup ItemGroup3
        {
            get;
            set;
        }
        public virtual Uom SalesUom
        {
            get;
            set;
        }
        public virtual Uom PurchUom
        {
            get;
            set;
        }
        public virtual BusinessPartner PurchVendor
        {
            get;
            set;
        }
        public virtual ItemDiscountGroup ItemDiscountGroup
        {
            get;
            set;
        }
        public virtual Vat Vat
        {
            get;
            set;
        }
        public virtual Account InventoryAccount
        {
            get;
            set;
        }
        public virtual Account ConsignmentAccount
        {
            get;
            set;
        }
        public virtual Account SalesAccount
        {
            get;
            set;
        }
        public virtual Account SalesInternalAccount
        {
            get;
            set;
        }
        public virtual Account SalesReturnAccount
        {
            get;
            set;
        }
        public virtual Account SalesDiscountAccount
        {
            get;
            set;
        }
        public virtual Account COGSAccount
        {
            get;
            set;
        }
        public virtual Account COGSDiffAccount
        {
            get;
            set;
        }
        public virtual Account WIPAccount
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
