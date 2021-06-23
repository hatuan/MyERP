using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(Location.Metadata))]
    public partial class Location
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
    
            [StringLength(32)]
            public object ContactName { get; set; }
    
            [StringLength(256)]
            public object Address { get; set; }
    
            [StringLength(32)]
            public object Telephone { get; set; }
    
            [StringLength(32)]
            public object Mobiphone { get; set; }
    
            [StringLength(32)]
            public object Fax { get; set; }
    
            [StringLength(32)]
            public object Email { get; set; }
    
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
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object RecCreatedByUser { get; set; }
    
            public object RecModifiedByUser { get; set; }
        }
    }
}
