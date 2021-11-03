﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 11/03/2021 3:16:01 PM
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
    public partial class BusinessPartner
    {

        public BusinessPartner()
        {
            OnCreated();
        }

        #region Properties

        [Key]
        [Required()]
        public virtual long Id { get; set; }

        [StringLength(32)]
        [Required()]
        public virtual string Code { get; set; }

        [StringLength(256)]
        [Required()]
        public virtual string Description { get; set; }

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

        [Required()]
        public virtual bool Blocked { get; set; }

        [Required()]
        public virtual long Version { get; set; }

        public virtual long? BusinessPartnerPriceGroupId { get; set; }

        public virtual long? BusinessPartnerGroupId1 { get; set; }

        public virtual long? BusinessPartnerGroupId2 { get; set; }

        public virtual long? BusinessPartnerGroupId3 { get; set; }

        public virtual long? BusPartnerDiscGroupId { get; set; }

        [StringLength(32)]
        public virtual string TaxCode { get; set; }

        [StringLength(32)]
        public virtual string ContactName { get; set; }

        [StringLength(256)]
        public virtual string Address { get; set; }

        [StringLength(256)]
        public virtual string AddressTransition { get; set; }

        [StringLength(32)]
        public virtual string Telephone { get; set; }

        [StringLength(32)]
        public virtual string Mobilephone { get; set; }

        [StringLength(32)]
        public virtual string Fax { get; set; }

        [StringLength(32)]
        public virtual string Mail { get; set; }

        [StringLength(32)]
        public virtual string Website { get; set; }

        public virtual bool? IsCustomer { get; set; }

        public virtual long? CustomerAccountId { get; set; }

        public virtual bool? IsVendor { get; set; }

        public virtual long? VendorAccountId { get; set; }

        public virtual bool? IsEmployee { get; set; }

        public virtual long? EmployeeAccountId { get; set; }

        public virtual long? PaymentTermId { get; set; }

        [StringLength(32)]
        public virtual string BankAccount { get; set; }

        [StringLength(256)]
        public virtual string BankName { get; set; }

        [StringLength(512)]
        public virtual string Comment { get; set; }

        /// <summary>
        /// Gioi han tien cong no
        /// </summary>
        public virtual decimal? CreditLimit { get; set; }

        /// <summary>
        /// Gioi han tien hang hoa ... tren hoa don
        /// </summary>
        public virtual decimal? AmountLimit { get; set; }

        public virtual double? GeoLatitude { get; set; }

        public virtual double? GeoLongitude { get; set; }

        #endregion

        #region Navigation Properties

        public virtual User RecCreatedByUser { get; set; }
        public virtual User RecModifiedByUser { get; set; }
        public virtual BusinessPartnerGroup BusinessPartnerGroup1 { get; set; }
        public virtual BusinessPartnerGroup BusinessPartnerGroup2 { get; set; }
        public virtual BusinessPartnerGroup BusinessPartnerGroup3 { get; set; }
        public virtual Client Client { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual BusinessPartnerPriceGroup BusinessPartnerPriceGroup { get; set; }
        public virtual BusinessPartnerDiscGroup BusPartnerDiscGroup { get; set; }

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
