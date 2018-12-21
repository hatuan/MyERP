﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 12/21/2018 11:37:24 PM
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
    /// There are no comments for MyERP.DataAccess.BusinessPartner in the schema.
    /// </summary>
    public partial class BusinessPartner    {

        public BusinessPartner()
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

    
        /// <summary>
        /// There are no comments for BusinessPartnerPriceGroupId in the schema.
        /// </summary>
        public virtual long? BusinessPartnerPriceGroupId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusinessPartnerGroupId1 in the schema.
        /// </summary>
        public virtual long? BusinessPartnerGroupId1
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusinessPartnerGroupId2 in the schema.
        /// </summary>
        public virtual long? BusinessPartnerGroupId2
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusinessPartnerGroupId3 in the schema.
        /// </summary>
        public virtual long? BusinessPartnerGroupId3
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusPartnerDiscGroupId in the schema.
        /// </summary>
        public virtual long? BusPartnerDiscGroupId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TaxCode in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string TaxCode
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
        /// There are no comments for Address in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string Address
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
        /// There are no comments for Mobilephone in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string Mobilephone
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Fax in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string Fax
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Mail in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string Mail
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
        /// There are no comments for IsCustomer in the schema.
        /// </summary>
        public virtual bool? IsCustomer
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CustomerAccountId in the schema.
        /// </summary>
        public virtual long? CustomerAccountId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsVendor in the schema.
        /// </summary>
        public virtual bool? IsVendor
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VendorAccountId in the schema.
        /// </summary>
        public virtual long? VendorAccountId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsEmployee in the schema.
        /// </summary>
        public virtual bool? IsEmployee
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EmployeeAccountId in the schema.
        /// </summary>
        public virtual long? EmployeeAccountId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PaymentTermId in the schema.
        /// </summary>
        public virtual long? PaymentTermId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BankAccount in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string BankAccount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BankName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string BankName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Comment in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public virtual string Comment
        {
            get;
            set;
        }

    
        /// <summary>
        /// Gioi han tien cong no
        /// </summary>
        public virtual decimal? CreditLimit
        {
            get;
            set;
        }

    
        /// <summary>
        /// Gioi han tien hang hoa ... tren hoa don
        /// </summary>
        public virtual decimal? AmountLimit
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GeoLatitude in the schema.
        /// </summary>
        public virtual double? GeoLatitude
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GeoLongitude in the schema.
        /// </summary>
        public virtual double? GeoLongitude
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
        /// There are no comments for BusinessPartnerGroup1 in the schema.
        /// </summary>
        public virtual BusinessPartnerGroup BusinessPartnerGroup1
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BusinessPartnerGroup2 in the schema.
        /// </summary>
        public virtual BusinessPartnerGroup BusinessPartnerGroup2
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BusinessPartnerGroup3 in the schema.
        /// </summary>
        public virtual BusinessPartnerGroup BusinessPartnerGroup3
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
        /// There are no comments for BusinessPartnerPriceGroup in the schema.
        /// </summary>
        public virtual BusinessPartnerPriceGroup BusinessPartnerPriceGroup
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BusPartnerDiscGroup in the schema.
        /// </summary>
        public virtual BusinessPartnerDiscountGroup BusPartnerDiscGroup
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
