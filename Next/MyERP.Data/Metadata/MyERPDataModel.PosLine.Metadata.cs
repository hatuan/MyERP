using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(PosLine.Metadata))]
    public partial class PosLine
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            public object PosHeaderId { get; set; }
    
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
    
            public object SalesPriceId { get; set; }
    
            [Required()]
            public object UnitPrice { get; set; }
    
            [Required()]
            public object Amount { get; set; }
    
            public object VatIdentifierId { get; set; }
    
            [Required()]
            public object VatPercentage { get; set; }
    
            [Required()]
            public object VatAmount { get; set; }
    
            public object DiscountId { get; set; }
    
            [Required()]
            public object LineDiscountPercentage { get; set; }
    
            [Required()]
            public object LineDiscountAmount { get; set; }
    
            [Required()]
            public object InvoiceDiscountAmount { get; set; }
    
            [Required()]
            public object UnitPriceLCY { get; set; }
    
            [Required()]
            public object AmountLCY { get; set; }
    
            [Required()]
            public object VatAmountLCY { get; set; }
    
            [Required()]
            public object LineDiscountAmountLCY { get; set; }
    
            [Required()]
            public object InvoiceDiscountAmountLCY { get; set; }
    
            [Required()]
            public object QtyPerUom { get; set; }
    
            [Required()]
            public object QuantityBase { get; set; }
    
            [Required()]
            public object OrganizationId { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            public object PosHeader { get; set; }
    
            public object SalesPrice { get; set; }
    
            public object Location { get; set; }
        }
    }
}
