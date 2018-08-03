using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;
using Newtonsoft.Json;

namespace MyERP.Web.Models
{
    public class CashLineViewModel
    {
        public long? Id { get; set; }

        [Required]
        public long LineNo { get; set; }

        [Display(Name = "Correspondence Account")]
        [Required]
        public String CorrespAccountCode { get; set; }

        [Display(Name = "Description")]
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        [Display(Name = "Business Partner")]
        [Required]
        public String BusinessPartnerCode { get; set; }

        [Display(Name = "Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal Amount { get; set; }

        [Display(Name = "Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal AmountLCY { get; set; }
    }

    public class CashLineEditViewModel
    {
        public long? Id { get; set; }

        [Required]
        public long LineNo { get; set; }
                  
        [Display(Name = "Correspondence Account")]
        [Required]
        public long CorrespAccountId { get; set; }

        [Display(Name = "Description")]
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        [Display(Name = "Business Partner")]
        [Required]
        public long BusinessPartnerId { get; set; }

        [Display(Name = "Amount")]
        public Decimal Amount { get; set; }

        [Display(Name = "Amount LCY")]
        public Decimal AmountLCY { get; set; }
    }
}