﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 05/11/2019 4:21:04 PM
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
    public partial class Job
    {

        public Job()
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

        public virtual long? JobGroupId1
        {
            get;
            set;
        }

        public virtual long? JobGroupId2
        {
            get;
            set;
        }

        public virtual long? JobGroupId3
        {
            get;
            set;
        }

        public virtual long? BusinessPartnerId
        {
            get;
            set;
        }

        public virtual global::System.DateTime? CreationDate
        {
            get;
            set;
        }

        public virtual global::System.DateTime? StartingDate
        {
            get;
            set;
        }

        public virtual global::System.DateTime? EndingDate
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
        public virtual byte Status
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
        public virtual long Version
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
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
        public virtual JobGroup JobGroup1
        {
            get;
            set;
        }
        public virtual JobGroup JobGroup2
        {
            get;
            set;
        }
        public virtual JobGroup JobGroup3
        {
            get;
            set;
        }
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
