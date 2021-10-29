﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/10/2021 7:03:41 PM
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
    public partial class SalesPrice
    {

        public SalesPrice()
        {
            OnCreated();
        }

        #region Properties

        [Key]
        [Required()]
        public virtual long Id { get; set; }

        [Required()]
        public virtual long SalesPriceGroupId { get; set; }

        /// <summary>
        /// 1-Customer
        /// 2-Customer Price Group
        /// 3-All Customers
        /// 4-Campaign
        /// </summary>
        [Required()]
        public virtual short SalesType { get; set; }

        public virtual long? BusinessPartnerId { get; set; }

        public virtual long? BusPartnerPriceGroupId { get; set; }

        public virtual long? CampaignId { get; set; }

        [Required()]
        public virtual long ItemId { get; set; }

        public virtual long? UomId { get; set; }

        [Required()]
        public virtual global::System.DateTime StartingDate { get; set; }

        [Required()]
        public virtual decimal MinQty { get; set; }

        [Required()]
        public virtual decimal UnitPrice { get; set; }

        public virtual global::System.DateTime? EndingDate { get; set; }

        public virtual bool? Blocked { get; set; }

        [Required()]
        public virtual long Version { get; set; }

        [Required()]
        public virtual long OrganizationId { get; set; }

        [Required()]
        public virtual long ClientId { get; set; }

        [Required()]
        public virtual global::System.DateTime RecCreatedAt { get; set; }

        [Required()]
        public virtual long RecCreatedBy { get; set; }

        [Required()]
        public virtual global::System.DateTime RecModifiedAt { get; set; }

        [Required()]
        public virtual long RecModifiedBy { get; set; }

        #endregion

        #region Navigation Properties

        public virtual SalesPriceGroup SalesPriceGroup { get; set; }
        public virtual Item Item { get; set; }
        public virtual Uom Uom { get; set; }
        public virtual BusinessPartnerPriceGroup BusPartnerPriceGroup { get; set; }
        public virtual BusinessPartner BusinessPartner { get; set; }

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
