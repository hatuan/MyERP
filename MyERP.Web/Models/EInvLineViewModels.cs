using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyERP.Web.Models
{
    public class EInvLineEditViewModel
    {
        public long? Id { get; set; }

        [Required]
        public long LineNumber { get; set; }

        [Display(Name = "Item")]
        [Required]
        public long? ItemId { get; set; }

        [Display(Name = "Item Code")]
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String ItemCode { get; set; }

        public LookupViewModel Item { get; set; }

        [Display(Name = "Description")]
        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String ItemName { get; set; }

        [Required]
        [Display(Name = "UOM")]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String UnitId { get; set; }

        [Required]
        [Display(Name = "UOM Code")]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String UnitCode { get; set; }

        public ItemUomLookUpViewModel Uom { get; set; }

        [Display(Name = "Uom Description")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String UnitName { get; set; }
        
        [Display(Name = "Unit Price LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal UnitPriceLCY { get; set; }

        [Display(Name = "Unit Price")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal UnitPrice { get; set; }

        [Display(Name = "Qty")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal Quantity { get; set; }
        
        [Display(Name = "Line Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal ItemTotalAmountWithoutVAT { get; set; }
        
        [Display(Name = "Line Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal ItemTotalAmountWithoutVATLCY { get; set; }
        
        [Display(Name = "Vat Identity")]
        [Required]
        public long? VatId { get; set; }

        public LookupViewModel Vat { get; set; }

        [Display(Name = "Vat %")]
        [DisplayFormat(DataFormatString = "{0}")]
        public Decimal VATPercentage { get; set; }

        [Display(Name = "Vat Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal VATAmount { get; set; }

        [Display(Name = "Vat Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal VATAmountLCY { get; set; }

        [Display(Name = "Payment Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal ItemTotalAmountWithVAT { get; set; }

        [Display(Name = "Payment Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal ItemTotalAmountWithVATLCY { get; set; }
    }
}