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
    public partial class ItemJournalHeader
    {

        public ItemJournalHeader()
        {
            OnCreated();
        }

        #region Properties

        [Key]
        [Required()]
        public virtual long Id { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<ItemJournalLine> ItemJournalLines { get; set; }

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
