﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/07/2018 11:21:46 AM
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
    /// There are no comments for MyERP.DataAccess.SalesPrice in the schema.
    /// </summary>
    public partial class SalesPrice    {

        public SalesPrice()
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
        /// There are no comments for SalesPriceGroupId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long SalesPriceGroupId
        {
            get;
            set;
        }

    
        /// <summary>
        /// 1-Customer
        /// 2-Customer Price Group
        /// 3-All Customers
        /// 4-Campaign
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual short SalesType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusinessPartnerId in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> BusinessPartnerId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusPartnerPriceGroupId in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> BusPartnerPriceGroupId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CampaignId in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> CampaignId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ItemId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long ItemId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UomId in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> UomId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StartingDate in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime StartingDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MinQty in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal MinQty
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
        /// There are no comments for EndingDate in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> EndingDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Status in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte Status
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for SalesPriceGroup in the schema.
        /// </summary>
        public virtual SalesPriceGroup SalesPriceGroup
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
    
        /// <summary>
        /// There are no comments for Uom in the schema.
        /// </summary>
        public virtual Uom Uom
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BusPartnerPriceGroup in the schema.
        /// </summary>
        public virtual BusinessPartnerPriceGroup BusPartnerPriceGroup
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BusinessPartner in the schema.
        /// </summary>
        public virtual BusinessPartner BusinessPartner
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
