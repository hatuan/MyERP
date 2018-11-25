﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 11/25/2018 10:40:22 PM
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
    /// There are no comments for MyERP.DataAccess.Client in the schema.
    /// </summary>
    public partial class Client    {

        public Client()
        {
          this.Version = 1;
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
        /// There are no comments for Description in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActivated in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual bool IsActivated
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CultureId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(8)]
        public virtual string CultureId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AmountDecimalPlaces in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual short AmountDecimalPlaces
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AmountRoundingPrecision in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal AmountRoundingPrecision
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UnitAmountDecimalPlaces in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual short UnitAmountDecimalPlaces
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UnitAmountRoundingPrecision in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual decimal UnitAmountRoundingPrecision
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrencyLcyId in the schema.
        /// </summary>
        public virtual long? CurrencyLcyId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TaxCode in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(14)]
        public virtual string TaxCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Adress in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string Adress
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AddressTransition in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string AddressTransition
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Telephone in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string Telephone
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Email in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string Email
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Website in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string Website
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Image in the schema.
        /// </summary>
        public virtual byte[] Image
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RepresentativeName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string RepresentativeName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RepresentativePosition in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string RepresentativePosition
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ContactName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string ContactName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Mobilephone in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string Mobilephone
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TaxAuthoritiesId in the schema.
        /// </summary>
        public virtual long? TaxAuthoritiesId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RecCreatedBy in the schema.
        /// </summary>
        public virtual long? RecCreatedBy
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
        /// There are no comments for RecModifiedBy in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long? RecModifiedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RecModifiedAt in the schema.
        /// </summary>
        public virtual global::System.DateTime? RecModifiedAt
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
        /// There are no comments for Organizations in the schema.
        /// </summary>
        public virtual ICollection<Organization> Organizations
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for CurrencyLcy in the schema.
        /// </summary>
        public virtual Currency CurrencyLcy
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
