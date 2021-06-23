﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 04/21/2021 10:23:21 PM
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
    public partial class GeneralJournalHeader
    {

        public GeneralJournalHeader()
        {
            OnCreated();
        }

        #region Properties

        [Key]
        [Required()]
        public virtual long Id { get; set; }

        [Required()]
        public virtual byte DocumentType { get; set; }

        [Required()]
        public virtual byte DocSubType { get; set; }

        [Required()]
        public virtual long DocSequenceId { get; set; }

        [StringLength(32)]
        [Required()]
        public virtual string DocumentNo { get; set; }

        [Required()]
        public virtual global::System.DateTime DocumentDate { get; set; }

        public virtual global::System.DateTime? PostingDate { get; set; }

        [Required()]
        public virtual long CurrencyId { get; set; }

        [Required()]
        public virtual decimal CurrencyFactor { get; set; }

        public virtual int? NoPrinted { get; set; }

        [Required()]
        public virtual long OrganizationId { get; set; }

        [Required()]
        public virtual long ClientId { get; set; }

        [Required()]
        public virtual decimal TotalDebitAmountLCY { get; set; }

        public virtual decimal? TotalDebitAmount { get; set; }

        [Required()]
        public virtual decimal TotalCreditAmountLCY { get; set; }

        [Required()]
        public virtual decimal TotalCreditAmount { get; set; }

        [Required()]
        public virtual long Version { get; set; }

        [Required()]
        public virtual byte Status { get; set; }

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

        public virtual ICollection<GeneralJournalLine> GeneralJournalLines { get; set; }
        public virtual Client Client { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Currency Currency { get; set; }

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
