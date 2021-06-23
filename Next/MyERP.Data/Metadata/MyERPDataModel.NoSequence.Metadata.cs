using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(NoSequence.Metadata))]
    public partial class NoSequence
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object Code { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object Description { get; set; }
    
            [Required()]
            public object DefaultNo { get; set; }
    
            [Required()]
            public object ManualNo { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            [Required()]
            public object OrganizationId { get; set; }
    
            [Required()]
            public object Status { get; set; }
    
            [Required()]
            public object Version { get; set; }
    
            [Required()]
            public object RecCreatedBy { get; set; }
    
            [Required()]
            public object RecCreatedAt { get; set; }
    
            [Required()]
            public object RecModifiedBy { get; set; }
    
            [Required()]
            public object RecModifiedAt { get; set; }
    
            public object NoSequenceLines { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object RecCreatedByUser { get; set; }
    
            public object RecModifiedByUser { get; set; }
        }
    }
}
