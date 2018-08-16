﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/16/2018 5:23:29 PM
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
        public virtual global::System.Nullable<decimal> UnitCost
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UnitPrice in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> UnitPrice
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ItemDiscountGroupId in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> ItemDiscountGroupId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ItemGroupId1 in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> ItemGroupId1
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ItemGroupId2 in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> ItemGroupId2
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ItemGroupId3 in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> ItemGroupId3
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PurchVendorId in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> PurchVendorId
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

        #endregion
    
        #region Extensibility Method Definitions
        partial void OnCreated();
        #endregion
    }

}
