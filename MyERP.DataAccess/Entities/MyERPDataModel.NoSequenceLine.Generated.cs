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
    public partial class NoSequenceLine
    {

        public NoSequenceLine()
        {
            OnCreated();
        }

        #region Properties

        [Key]
        [Required()]
        public virtual long Id { get; set; }

        [Required()]
        public virtual long NoSequenceId { get; set; }

        [Required()]
        public virtual long LineNo { get; set; }

        [Required()]
        public virtual global::System.DateTime StartingDate { get; set; }

        [Required()]
        public virtual int StartingNo { get; set; }

        [Required()]
        public virtual int EndingNo { get; set; }

        [Required()]
        public virtual int CurrentNo { get; set; }

        [StringLength(32)]
        [Required()]
        public virtual string FormatNo { get; set; }

        [Required()]
        public virtual int WarningNo { get; set; }

        public virtual global::System.DateTime? LastDateUsed { get; set; }

        [Required()]
        public virtual long ClientId { get; set; }

        [Required()]
        public virtual long OrganizationId { get; set; }

        [Required()]
        public virtual bool Blocked { get; set; }

        [Required()]
        public virtual long Version { get; set; }

        [Required()]
        public virtual long RecCreatedBy { get; set; }

        [Required()]
        public virtual global::System.DateTime RecCreatedAt { get; set; }

        [Required()]
        public virtual long RecModifiedBy { get; set; }

        [Required()]
        public virtual global::System.DateTime RecModifiedAt { get; set; }

        #endregion

        #region Navigation Properties

        public virtual NoSequence NoSequence { get; set; }
        public virtual Client Client { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual User RecCreatedByUser { get; set; }
        public virtual User RecModifiedByUser { get; set; }

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
