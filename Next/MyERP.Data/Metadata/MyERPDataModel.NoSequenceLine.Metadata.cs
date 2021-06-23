using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(NoSequenceLine.Metadata))]
    public partial class NoSequenceLine
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [Required()]
            public object NoSequenceId { get; set; }
    
            [Required()]
            public object LineNo { get; set; }
    
            [Required()]
            public object StartingDate { get; set; }
    
            [Required()]
            public object StartingNo { get; set; }
    
            [Required()]
            public object EndingNo { get; set; }
    
            [Required()]
            public object CurrentNo { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object FormatNo { get; set; }
    
            [Required()]
            public object WarningNo { get; set; }
    
            public object LastDateUsed { get; set; }
    
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
    
            public object NoSequence { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object RecCreatedByUser { get; set; }
    
            public object RecModifiedByUser { get; set; }
        }
    }
}
