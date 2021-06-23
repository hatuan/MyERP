using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(Job.Metadata))]
    public partial class Job
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
    
            public object JobGroupId1 { get; set; }
    
            public object JobGroupId2 { get; set; }
    
            public object JobGroupId3 { get; set; }
    
            public object BusinessPartnerId { get; set; }
    
            public object CreationDate { get; set; }
    
            public object StartingDate { get; set; }
    
            public object EndingDate { get; set; }
    
            [Required()]
            public object OrganizationId { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            [Required()]
            public object Status { get; set; }
    
            [Required()]
            public object RecCreatedAt { get; set; }
    
            [Required()]
            public object RecCreatedBy { get; set; }
    
            [Required()]
            public object RecModifiedAt { get; set; }
    
            [Required()]
            public object RecModifiedBy { get; set; }
    
            [Required()]
            public object Version { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object RecCreatedByUser { get; set; }
    
            public object RecModifiedByUser { get; set; }
    
            public object JobGroup1 { get; set; }
    
            public object JobGroup2 { get; set; }
    
            public object JobGroup3 { get; set; }
    
            public object BusinessPartner { get; set; }
        }
    }
}
