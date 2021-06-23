using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(PurchaseInvoiceLine.Metadata))]
    public partial class PurchaseInvoiceLine
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [Required()]
            public object PurchaseHeaderId { get; set; }
    
            [Required()]
            public object DocumentType { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object DocumentNo { get; set; }
    
            [Required()]
            public object PostingDate { get; set; }
    
            [Required()]
            public object LineNo { get; set; }
    
            [Required()]
            public object Type { get; set; }
    
            public object ItemId { get; set; }
    
            public object LocationId { get; set; }
    
            [StringLength(256)]
            public object Description { get; set; }
    
            public object UomId { get; set; }
    
            [StringLength(256)]
            public object UomDescription { get; set; }
    
            [Required()]
            public object Quantity { get; set; }
    
            [Required()]
            public object PurchasePrice { get; set; }
    
            public object DiscountId { get; set; }
    
            [Required()]
            public object LineDiscountPercentage { get; set; }
    
            [Required()]
            public object LineDiscountAmount { get; set; }
    
            [Required()]
            public object LineAmount { get; set; }
    
            [Required()]
            public object PurchasePriceLCY { get; set; }
    
            [Required()]
            public object LineDiscountAmountLCY { get; set; }
    
            [Required()]
            public object LineAmountLCY { get; set; }
    
            [Required()]
            public object InvoiceDiscountAmount { get; set; }
    
            [Required()]
            public object InvoiceDiscountAmountLCY { get; set; }
    
            [Required()]
            public object UnitPrice { get; set; }
    
            [Required()]
            public object UnitPriceLCY { get; set; }
    
            [Required()]
            public object Amount { get; set; }
    
            [Required()]
            public object AmountLCY { get; set; }
    
            [Required()]
            public object ChargeAmount { get; set; }
    
            [Required()]
            public object ChargeAmountLCY { get; set; }
    
            [Required()]
            public object ImportDutyAmount { get; set; }
    
            [Required()]
            public object ImportDutyAmountLCY { get; set; }
    
            [Required()]
            public object ExciseTaxAmount { get; set; }
    
            [Required()]
            public object ExciseTaxAmountLCY { get; set; }
    
            [Required()]
            public object VatBaseAmount { get; set; }
    
            public object VatId { get; set; }
    
            [Required()]
            public object VatPercentage { get; set; }
    
            [Required()]
            public object VatAmount { get; set; }
    
            [Required()]
            public object VatBaseAmountLCY { get; set; }
    
            [Required()]
            public object VatAmountLCY { get; set; }
    
            [Required()]
            public object QtyPerUom { get; set; }
    
            [Required()]
            public object QuantityBase { get; set; }
    
            [Required()]
            public object CostPrice { get; set; }
    
            [Required()]
            public object CostPriceQtyBase { get; set; }
    
            [Required()]
            public object CostAmount { get; set; }
    
            [Required()]
            public object CostPriceLCY { get; set; }
    
            [Required()]
            public object CostPriceQtyBaseLCY { get; set; }
    
            [Required()]
            public object CostAmountLCY { get; set; }
    
            public object InventoryAccountId { get; set; }
    
            public object JobId { get; set; }
    
            [Required()]
            public object OrganizationId { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            public object PurchaseInvoiceHeader { get; set; }
    
            public object Location { get; set; }
    
            public object Organization { get; set; }
    
            public object Client { get; set; }
    
            public object Vat { get; set; }
    
            public object Item { get; set; }
    
            public object Uom { get; set; }
    
            public object Job { get; set; }
    
            public object InventoryAccount { get; set; }
        }
    }
}
