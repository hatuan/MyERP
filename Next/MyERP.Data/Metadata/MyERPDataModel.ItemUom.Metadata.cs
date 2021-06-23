using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(ItemUom.Metadata))]
    public partial class ItemUom
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [Required()]
            public object ItemId { get; set; }
    
            [Required()]
            public object UomId { get; set; }
    
            [Required()]
            public object QtyPerUom { get; set; }
    
            [Required()]
            public object IsBaseUom { get; set; }
    
            [Required()]
            public object OrganizationId { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            [Required()]
            public object RecCreatedAt { get; set; }
    
            [Required()]
            public object RecCreatedBy { get; set; }
    
            [Required()]
            public object RecModifiedAt { get; set; }
    
            [Required()]
            public object RecModifiedBy { get; set; }
    
            [Required()]
            public object Status { get; set; }
    
            [Required()]
            public object Version { get; set; }
    
            public object Uom { get; set; }
    
            public object Item { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object RecCreatedByUser { get; set; }
    
            public object RecModifiedByUser { get; set; }
        }
    }
}
