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
    public partial class SalesPriceGroup
    {

        public SalesPriceGroup()
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
        public virtual bool Blocked { get; set; }

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

        public virtual ICollection<SalesPrice> SalesPrices { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Client Client { get; set; }
        public virtual User RecCreatedByUser { get; set; }
        public virtual User RecModifiedByUser { get; set; }

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
