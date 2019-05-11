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
    public partial class NoSequenceLine
    {

        public NoSequenceLine()
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

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long NoSequenceId
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long LineNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime StartingDate
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int StartingNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int EndingNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int CurrentNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(32)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string FormatNo
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int WarningNo
        {
            get;
            set;
        }

        public virtual global::System.DateTime? LastDateUsed
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
        public virtual long OrganizationId
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

        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long RecCreatedBy
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
        public virtual long RecModifiedBy
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

        #endregion

        #region Navigation Properties
        public virtual NoSequence NoSequence
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

        #endregion

        #region Extensibility Method Definitions
        partial void OnCreated();
        #endregion
    }

}
