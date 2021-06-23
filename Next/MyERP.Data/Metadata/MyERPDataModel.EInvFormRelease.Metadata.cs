using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(EInvFormRelease.Metadata))]
    public partial class EInvFormRelease
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [Required()]
            public object FormTypeId { get; set; }
    
            [Required()]
            public object ReleaseTotal { get; set; }
    
            [Required()]
            public object ReleaseFrom { get; set; }
    
            [Required()]
            public object ReleaseTo { get; set; }
    
            [Required()]
            public object ReleaseUsed { get; set; }
    
            [Required()]
            public object ReleaseDate { get; set; }
    
            [Required()]
            public object StartDate { get; set; }
    
            [Required()]
            public object TaxAuthoritiesStatus { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            [Required()]
            public object OrganizationId { get; set; }
    
            [Required()]
            public object Version { get; set; }
    
            [Required()]
            public object Status { get; set; }
    
            [Required()]
            public object RecCreatedBy { get; set; }
    
            [Required()]
            public object RecCreatedAt { get; set; }
    
            [Required()]
            public object RecModifiedBy { get; set; }
    
            [Required()]
            public object RecModifiedAt { get; set; }
    
            public object EInvFormType { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object RecCreatedByUser { get; set; }
    
            public object RecModifiedByUser { get; set; }
        }
    }
}
