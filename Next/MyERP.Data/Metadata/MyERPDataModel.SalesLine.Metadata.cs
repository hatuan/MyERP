using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(SalesLine.Metadata))]
    public partial class SalesLine
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            public object SalesHeaderId { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object DocumentNo { get; set; }
    
            [Required()]
            public object LineNo { get; set; }
    
            [Required()]
            public object Type { get; set; }
    
            public object PostingDate { get; set; }
    
            public object ItemId { get; set; }
    
            public object LocationId { get; set; }
    
            [StringLength(256)]
            public object Description { get; set; }
    
            public object UomId { get; set; }
    
            [StringLength(256)]
            public object UomDescription { get; set; }
    
            [Required()]
            public object Quantity { get; set; }
    
            public object SalesPriceId { get; set; }
    
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
            public object CostUnit { get; set; }
    
            [Required()]
            public object CostUnitLCY { get; set; }
    
            [Required()]
            public object CostAmount { get; set; }
    
            [Required()]
            public object CostAmountLCY { get; set; }
    
            [Required()]
            public object QuantityShipped { get; set; }
    
            [Required()]
            public object OutstandingQuantity { get; set; }
    
            [Required()]
            public object QuantityInvoiced { get; set; }
    
            [Required()]
            public object QtyShippedNotInvoiced { get; set; }
    
            [Required()]
            public object QtyPerUom { get; set; }
    
            [Required()]
            public object QuantityBase { get; set; }
    
            [Required()]
            public object OutstandingQtyBase { get; set; }
    
            [Required()]
            public object QuantityShippedBase { get; set; }
    
            [Required()]
            public object QuantityInvoicedBase { get; set; }
    
            [Required()]
            public object QtyShippedNotInvoicedBase { get; set; }
    
            [Required()]
            public object OrganizationId { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            [Required()]
            public object VatId { get; set; }
    
            public object SalesHeader { get; set; }
    
            public object Location { get; set; }
    
            public object SalesPrice { get; set; }
    
            public object Vat { get; set; }
        }
    }
}
