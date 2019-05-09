﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 05/05/2019 5:48:46 PM
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
    public partial class BusinessPartner
    {

        public BusinessPartner()
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

        public virtual long? BusinessPartnerPriceGroupId
        {
            get;
            set;
        }

        public virtual long? BusinessPartnerGroupId1
        {
            get;
            set;
        }

        public virtual long? BusinessPartnerGroupId2
        {
            get;
            set;
        }

        public virtual long? BusinessPartnerGroupId3
        {
            get;
            set;
        }

        public virtual long? BusPartnerDiscGroupId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string TaxCode
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string ContactName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string Address
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string AddressTransition
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string Telephone
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string Mobilephone
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string Fax
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string Mail
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string Website
        {
            get;
            set;
        }

        public virtual bool? IsCustomer
        {
            get;
            set;
        }

        public virtual long? CustomerAccountId
        {
            get;
            set;
        }

        public virtual bool? IsVendor
        {
            get;
            set;
        }

        public virtual long? VendorAccountId
        {
            get;
            set;
        }

        public virtual bool? IsEmployee
        {
            get;
            set;
        }

        public virtual long? EmployeeAccountId
        {
            get;
            set;
        }

        public virtual long? PaymentTermId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public virtual string BankAccount
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public virtual string BankName
        {
            get;
            set;
        }

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

        public virtual double? GeoLatitude
        {
            get;
            set;
        }

        public virtual double? GeoLongitude
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
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
        public virtual BusinessPartnerGroup BusinessPartnerGroup1
        {
            get;
            set;
        }
        public virtual BusinessPartnerGroup BusinessPartnerGroup2
        {
            get;
            set;
        }
        public virtual BusinessPartnerGroup BusinessPartnerGroup3
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
        public virtual BusinessPartnerPriceGroup BusinessPartnerPriceGroup
        {
            get;
            set;
        }
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
