using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(EInvoiceLine.Metadata))]
    public partial class EInvoiceLine
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [Required()]
            public object EInvoiceHeaderId { get; set; }
    
            [Required()]
            public object LineNumber { get; set; }
    
            [Required()]
            public object ItemId { get; set; }
    
            [StringLength(50)]
            [Required()]
            public object ItemCode { get; set; }
    
            [StringLength(255)]
            [Required()]
            public object ItemName { get; set; }
    
            [Required()]
            public object UnitId { get; set; }
    
            [StringLength(10)]
            [Required()]
            public object UnitCode { get; set; }
    
            [StringLength(50)]
            [Required()]
            public object UnitName { get; set; }
    
            [Required()]
            public object UnitPrice { get; set; }
    
            [Required()]
            public object Quantity { get; set; }
    
            [Required()]
            public object ItemTotalAmountWithoutVAT { get; set; }
    
            [Required()]
            public object ItemTotalAmountWithoutVATLCY { get; set; }
    
            [Required()]
            public object VatId { get; set; }
    
            [Required()]
            public object VATPercentage { get; set; }
    
            [Required()]
            public object VATAmount { get; set; }
    
            [Required()]
            public object VATAmountLCY { get; set; }
    
            [Required()]
            public object ItemTotalAmountWithVAT { get; set; }
    
            [Required()]
            public object ItemTotalAmountWithVATLCY { get; set; }
    
            [Required()]
            public object Promotion { get; set; }
    
            [Required()]
            public object AdjustmentVATAmount { get; set; }
    
            public object IsIncreaseItem { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            [Required()]
            public object OrganizationId { get; set; }
    
            public object EInvoiceHeader { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object Vat { get; set; }
    
            public object Item { get; set; }
    
            public object Uom { get; set; }
        }
    }
}
