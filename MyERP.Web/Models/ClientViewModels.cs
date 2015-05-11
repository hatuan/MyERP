using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Data.Edm.Csdl;
using MyERP.DataAccess;

namespace MyERP.Web.Models
{
    
    public class ClientEditViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }

        public Guid CurrencyLCYId { get; set; }

        [Required]
        [Display(Name = "Currency LCY")]
        public String CurrencyLCYCode { get; set; }

        [Required]
        [Display(Name = "Culture")]
        public String CultureId { get; set; }

        [Required]
        [Display(Name = "Amount Decimal Places")]
        public Int16 AmountDecimalPlaces { get; set; }

        [Required]
        [Display(Name = "Amount Rounding Precision")]
        public Decimal AmountRoundingPrecision { get; set; }

        [Required]
        [Display(Name = "Unit-Amount Decimal Places")]
        public Int16 UnitAmountDecimalPlaces { get; set; }

        [Required]
        [Display(Name = "Unit-Amount Rounding Precision")]
        public Decimal UnitAmountRoundingPrecision { get; set; }

        [Display(Name = "Actived")]
        public Boolean IsActived { get; set; }

        public Int64 Version { get; set; }
    }
}