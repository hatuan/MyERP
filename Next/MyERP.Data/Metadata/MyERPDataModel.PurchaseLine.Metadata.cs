using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(PurchaseLine.Metadata))]
    public partial class PurchaseLine
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
            public object LineNo { get; set; }
    
            [Required()]
            public object Type { get; set; }
    
            public object ItemId { get; set; }
    
            [Required()]
            public object LocationId { get; set; }
    
            [StringLength(256)]
            public object Description { get; set; }
    
            public object UomId { get; set; }
    
            [StringLength(256)]
            public object UomDescription { get; set; }
    
            [Required()]
            public object Quantity { get; set; }
    
            [Required()]
            public object UnitPrice { get; set; }
    
            [Required()]
            public object Amount { get; set; }
    
            [Required()]
            public object UnitPriceLCY { get; set; }
    
            [Required()]
            public object AmountLCY { get; set; }
    
            public object DiscountId { get; set; }
    
            [Required()]
            public object LineDiscountPercentage { get; set; }
    
            [Required()]
            public object LineDiscountAmount { get; set; }
    
            [Required()]
            public object LineDiscountAmountLCY { get; set; }
    
            [Required()]
            public object InvoiceDiscountAmount { get; set; }
    
            [Required()]
            public object InvoiceDiscountAmountLCY { get; set; }
    
            [Required()]
            public object CostUnit { get; set; }
    
            [Required()]
            public object CostUnitLCY { get; set; }
    
            [Required()]
            public object CostAmount { get; set; }
    
            [Required()]
            public object CostAmountLCY { get; set; }
    
            [Required()]
            public object QuantityReceived { get; set; }
    
            [Required()]
            public object OutstandingQuantity { get; set; }
    
            [Required()]
            public object QuantityInvoiced { get; set; }
    
            [Required()]
            public object QtyReceivedNotInvoiced { get; set; }
    
            [Required()]
            public object QtyPerUom { get; set; }
    
            [Required()]
            public object QuantityBase { get; set; }
    
            [Required()]
            public object OutstandingQtyBase { get; set; }
    
            [Required()]
            public object QuantityReceivedBase { get; set; }
    
            [Required()]
            public object QuantityInvoicedBase { get; set; }
    
            [Required()]
            public object QtyReceivedNotInvoicedBase { get; set; }
    
            [Required()]
            public object OrganizationId { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            public object PurchaseHeader { get; set; }
    
            public object Location { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object Uom { get; set; }
    
            public object Item { get; set; }
        }
    }
}
