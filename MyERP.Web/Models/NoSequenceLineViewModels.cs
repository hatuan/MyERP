using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class NoSequenceLineViewModel
    {
        [Required]
        public Int64 Id { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public String OrganizationCode { get; set; }

        [Required]
        public Int64 NoSequenceId { get; set; }

        [Required]
        public Int64 LineNo { get; set; }

        [Display(Name = "Starting Date")]
        public DateTime StartingDate { get; set; }

        [Display(Name = "Starting No")]
        public Int32 StartingNo { get; set; }

        [Display(Name = "Ending No")]
        public Int32 EndingNo { get; set; }

        [Display(Name = "Warning No")]
        public Int32 WarningNo { get; set; }

        [Display(Name = "Format No")]
        public String FormatNo { get; set; }

        [Required]
        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }

        [Required]
        [Display(Name="Created By")]
        public String RecCreateBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Created")]
        public DateTime RecCreatedAt { get; set; }

        [Required]
        [Display(Name = "Modified By")]
        public String RecModifiedBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Modified")]
        public DateTime RecModifiedAt { get; set; }
    }

    public class NoSequenceLineEditViewModel
    {
        public long? Id { get; set; }

        public long? NoSequenceId { get; set; }

        public long LineNo { get; set; }

        [Display(Name = "Starting Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DateColumn(Format = "d")]
        public DateTime? StartingDate { get; set; }

        [Display(Name = "Starting No")]
        public int? StartingNo { get; set; }

        [Display(Name = "Ending No")]
        public int? EndingNo { get; set; }

        [Display(Name = "Current No")]
        public int? CurrentNo { get; set; }

        [Display(Name = "Warning No")]
        public int? WarningNo { get; set; }

        [Display(Name = "Format No")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String FormatNo { get; set; }

        [Required]
        [Display(Name = "Status")]
        public DefaultStatusType Status { get; set; }

        public Int64 Version { get; set; }
    }
}