//------------------------------------------------------------------------------
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
    public partial class TransferLine
    {

        public TransferLine()
        {
            OnCreated();
        }

        #region Properties

        [Key]
        [Required()]
        public virtual long Id { get; set; }

        [Required()]
        public virtual long TransferHeaderId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual TransferHeader TransferHeader { get; set; }

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
