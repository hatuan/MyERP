using System;
using System.ComponentModel.DataAnnotations;

namespace MyERP.Web.Models
{
    
    public class ClientEditViewModel
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Description")]
        public String Description { get; set; }

        public long CurrencyLcyId { get; set; }

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
        public Int16 UnitAmountRoundingPrecision { get; set; }

        [Display(Name = "Actived")]
        public Boolean IsActived { get; set; }

        public Int64 Version { get; set; }
    }
}