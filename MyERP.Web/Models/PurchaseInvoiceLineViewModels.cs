using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MyERP.DataAccess;

namespace MyERP.Web.Models
{
    public class PurchaseInvoiceLineEditViewModel
    {

        public long? Id { get; set; }

        [Required]
        public long LineNo { get; set; }

        [Required]
        [Display(Name = "Type")]
        public Byte Type { get; set; }

        [Display(Name = "Item")]
        [Required]
        public long? ItemId { get; set; }

        public LookupViewModel Item { get; set; }

        [Display(Name = "Description")]
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        [Required]
        [Display(Name = "UOM")]
        public long? UomId { get; set; }

        public LookupViewModel Uom { get; set; }

        [Display(Name = "Uom Description")]
        public String UomDescription { get; set; }

        [Display(Name = "Location")]
        [Required]
        public long? LocationId { get; set; }

        public LookupViewModel Location { get; set; }

        [Display(Name = "Qty")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal Quantity { get; set; }

        [Display(Name = "Purchase Price")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal PurchasePrice { get; set; }

        [Display(Name = "Line Disc %")]
        [DisplayFormat(DataFormatString = "{0}")]
        public Byte LineDiscountPercentage { get; set; }

        [Display(Name = "Line Dis Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal LineDiscountAmount { get; set; }

        [Display(Name = "Line Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal LineAmount { get; set; }

        [Display(Name = "Purchase Price LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal PurchasePriceLCY { get; set; }

        [Display(Name = "Line Disc Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal LineDiscountAmountLCY { get; set; }

        [Display(Name = "Line Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal LineAmountLCY { get; set; }

        [Display(Name = "Invoice Disc Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal InvoiceDiscountAmount { get; set; }

        [Display(Name = "Invoice Disc Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal InvoiceDiscountAmountLCY { get; set; }

        [Display(Name = "Unit Price")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal UnitPrice { get; set; }

        [Display(Name = "Unit Price LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal UnitPriceLCY { get; set; }

        [Display(Name = "Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal Amount { get; set; }

        [Display(Name = "Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal AmountLCY { get; set; }

        [Display(Name = "Charge Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal ChargeAmount { get; set; }

        [Display(Name = "Charge Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal ChargeAmountLCY { get; set; }

        [Display(Name = "Import Duty Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal ImportDutyAmount { get; set; }

        [Display(Name = "Import Duty Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal ImportDutyAmountLCY { get; set; }

        [Display(Name = "Excise Tax Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal ExciseTaxAmount { get; set; }

        [Display(Name = "Excise Tax Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal ExciseTaxAmountLCY { get; set; }

        [Display(Name = "Vat Base Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal VatBaseAmount { get; set; }

        [Display(Name = "Vat Identity")]
        [Required]
        public long? VatId { get; set; }

        public LookupViewModel Vat { get; set; }

        [Display(Name = "Vat %")]
        [DisplayFormat(DataFormatString = "{0}")]
        public Decimal VatPercentage { get; set; }

        [Display(Name = "Vat Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal VatAmount { get; set; }

        [Display(Name = "Vat Base Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal VatBaseAmountLCY { get; set; }

        [Display(Name = "Vat Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal VatAmountLCY { get; set; }

        [Display(Name = "Qty Per Uom")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal QtyPerUom { get; set; }

        [Display(Name = "Quantity Base")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal QuantityBase { get; set; }

        [Display(Name = "Cost Price")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal CostPrice { get; set; }

        [Display(Name = "Cost Price Qty Base")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal CostPriceQtyBase { get; set; }

        [Display(Name = "Cost Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal CostAmount { get; set; }

        [Display(Name = "Cost Price LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal CostPriceLCY { get; set; }

        [Display(Name = "Cost Price Qty Base LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal CostPriceQtyBaseLCY { get; set; }

        [Display(Name = "Cost Amount LCY")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal CostAmountLCY { get; set; }
    }


}