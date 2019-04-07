﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 4/3/2019 10:01:01 PM
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
    /// There are no comments for MyERP.DataAccess.Item in the schema.
    /// </summary>
    public partial class Item    {

        public Item()
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
        /// There are no comments for Code in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string Code
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BaseUomId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long BaseUomId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UnitCost in the schema.
        /// </summary>
        public virtual decimal? UnitCost
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UnitPrice in the schema.
        /// </summary>
        public virtual decimal? UnitPrice
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CostingMethod in the schema.
        /// </summary>
        public virtual byte? CostingMethod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ItemDiscountGroupId in the schema.
        /// </summary>
        public virtual long? ItemDiscountGroupId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ItemGroupId1 in the schema.
        /// </summary>
        public virtual long? ItemGroupId1
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ItemGroupId2 in the schema.
        /// </summary>
        public virtual long? ItemGroupId2
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ItemGroupId3 in the schema.
        /// </summary>
        public virtual long? ItemGroupId3
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PurchVendorId in the schema.
        /// </summary>
        public virtual long? PurchVendorId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SalesUomId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long SalesUomId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PurchUomId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long PurchUomId
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
        /// There are no comments for InventoryAccountId in the schema.
        /// </summary>
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

    
        /// <summary>
        /// There are no comments for SalesAccountId in the schema.
        /// </summary>
        public virtual long? SalesAccountId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SalesInternalAccountId in the schema.
        /// </summary>
        public virtual long? SalesInternalAccountId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SalesReturnAccountId in the schema.
        /// </summary>
        public virtual long? SalesReturnAccountId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SalesDiscountAccountId in the schema.
        /// </summary>
        public virtual long? SalesDiscountAccountId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for COGSAccountId in the schema.
        /// </summary>
        public virtual long? COGSAccountId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for COGSDiffAccountId in the schema.
        /// </summary>
        public virtual long? COGSDiffAccountId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WIPAccountId in the schema.
        /// </summary>
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

    
        /// <summary>
        /// There are no comments for LeadTimeCalc in the schema.
        /// </summary>
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

    
        /// <summary>
        /// There are no comments for IncludeInventory in the schema.
        /// </summary>
        public virtual bool? IncludeInventory
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ReorderCycle in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string ReorderCycle
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SafetyLeadTime in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string SafetyLeadTime
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SafetyStockQty in the schema.
        /// </summary>
        public virtual decimal? SafetyStockQty
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ReorderPoint in the schema.
        /// </summary>
        public virtual decimal? ReorderPoint
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MaximumInventory in the schema.
        /// </summary>
        public virtual decimal? MaximumInventory
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ReorderQty in the schema.
        /// </summary>
        public virtual decimal? ReorderQty
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MinimumOrderQty in the schema.
        /// </summary>
        public virtual decimal? MinimumOrderQty
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MaximumOrderQty in the schema.
        /// </summary>
        public virtual decimal? MaximumOrderQty
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrderMultiple in the schema.
        /// </summary>
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

    
        /// <summary>
        /// There are no comments for RoutingId in the schema.
        /// </summary>
        public virtual long? RoutingId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BomId in the schema.
        /// </summary>
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

    
        /// <summary>
        /// There are no comments for Scrap in the schema.
        /// </summary>
        public virtual decimal? Scrap
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LotSize in the schema.
        /// </summary>
        public virtual decimal? LotSize
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LowLevelCode in the schema.
        /// </summary>
        public virtual byte? LowLevelCode
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
        /// There are no comments for RecModifiedAt in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime RecModifiedAt
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for BaseUom in the schema.
        /// </summary>
        public virtual Uom BaseUom
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
        /// There are no comments for RecCreatedByUser in the schema.
        /// </summary>
        public virtual User RecCreatedByUser
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
        /// There are no comments for ItemUoms in the schema.
        /// </summary>
        public virtual ICollection<ItemUom> ItemUoms
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ItemGroup1 in the schema.
        /// </summary>
        public virtual ItemGroup ItemGroup1
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ItemGroup2 in the schema.
        /// </summary>
        public virtual ItemGroup ItemGroup2
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ItemGroup3 in the schema.
        /// </summary>
        public virtual ItemGroup ItemGroup3
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SalesUom in the schema.
        /// </summary>
        public virtual Uom SalesUom
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PurchUom in the schema.
        /// </summary>
        public virtual Uom PurchUom
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PurchVendor in the schema.
        /// </summary>
        public virtual BusinessPartner PurchVendor
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ItemDiscountGroup in the schema.
        /// </summary>
        public virtual ItemDiscountGroup ItemDiscountGroup
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
    
        /// <summary>
        /// There are no comments for InventoryAccount in the schema.
        /// </summary>
        public virtual Account InventoryAccount
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ConsignmentAccount in the schema.
        /// </summary>
        public virtual Account ConsignmentAccount
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SalesAccount in the schema.
        /// </summary>
        public virtual Account SalesAccount
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SalesInternalAccount in the schema.
        /// </summary>
        public virtual Account SalesInternalAccount
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SalesReturnAccount in the schema.
        /// </summary>
        public virtual Account SalesReturnAccount
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SalesDiscountAccount in the schema.
        /// </summary>
        public virtual Account SalesDiscountAccount
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for COGSAccount in the schema.
        /// </summary>
        public virtual Account COGSAccount
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for COGSDiffAccount in the schema.
        /// </summary>
        public virtual Account COGSDiffAccount
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WIPAccount in the schema.
        /// </summary>
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
