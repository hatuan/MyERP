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
    public partial class Client
    {

        public Client()
        {
            OnCreated();
        }

        #region Properties

        [Key]
        [Required()]
        public virtual long Id { get; set; }

        /// <summary>
        /// Use to lookup ClientId when access from outsite like api ...
        /// </summary>
        [StringLength(36)]
        [Required()]
        public virtual string UUID { get; set; }

        [StringLength(256)]
        public virtual string Description { get; set; }

        [Required()]
        public virtual bool IsActivated { get; set; }

        [StringLength(8)]
        public virtual string CultureId { get; set; }

        [Required()]
        public virtual short AmountDecimalPlaces { get; set; }

        [Required()]
        public virtual decimal AmountRoundingPrecision { get; set; }

        [Required()]
        public virtual short UnitAmountDecimalPlaces { get; set; }

        [Required()]
        public virtual decimal UnitAmountRoundingPrecision { get; set; }

        public virtual long? CurrencyLcyId { get; set; }

        [StringLength(14)]
        public virtual string TaxCode { get; set; }

        [StringLength(256)]
        public virtual string Address { get; set; }

        [StringLength(256)]
        public virtual string AddressTransition { get; set; }

        [StringLength(32)]
        public virtual string Telephone { get; set; }

        [StringLength(32)]
        [Required()]
        public virtual string Email { get; set; }

        [StringLength(32)]
        public virtual string Website { get; set; }

        public virtual byte[] Image { get; set; }

        [StringLength(32)]
        public virtual string RepresentativeName { get; set; }

        [StringLength(32)]
        public virtual string RepresentativePosition { get; set; }

        [StringLength(32)]
        public virtual string ContactName { get; set; }

        [StringLength(32)]
        public virtual string Mobilephone { get; set; }

        public virtual long? TaxAuthoritiesId { get; set; }

        public virtual long? RecCreatedBy { get; set; }

        [Required()]
        public virtual global::System.DateTime RecCreatedAt { get; set; }

        public virtual long? RecModifiedBy { get; set; }

        [Required()]
        public virtual global::System.DateTime RecModifiedAt { get; set; }

        [Required()]
        public virtual long Version { get; set; }

        #endregion

        #region Navigation Properties

        public virtual User RecCreatedByUser { get; set; }
        public virtual User RecModifiedByUser { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual Currency CurrencyLcy { get; set; }

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
