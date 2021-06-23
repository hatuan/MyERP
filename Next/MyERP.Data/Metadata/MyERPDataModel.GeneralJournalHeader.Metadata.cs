using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(GeneralJournalHeader.Metadata))]
    public partial class GeneralJournalHeader
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [Required()]
            public object DocumentType { get; set; }
    
            [Required()]
            public object DocSubType { get; set; }
    
            [Required()]
            public object DocSequenceId { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object DocumentNo { get; set; }
    
            [Required()]
            public object DocumentDate { get; set; }
    
            public object PostingDate { get; set; }
    
            [Required()]
            public object CurrencyId { get; set; }
    
            [Required()]
            public object CurrencyFactor { get; set; }
    
            public object NoPrinted { get; set; }
    
            [Required()]
            public object OrganizationId { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            [Required()]
            public object TotalDebitAmountLCY { get; set; }
    
            public object TotalDebitAmount { get; set; }
    
            [Required()]
            public object TotalCreditAmountLCY { get; set; }
    
            [Required()]
            public object TotalCreditAmount { get; set; }
    
            [Required()]
            public object Version { get; set; }
    
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
    
            public object GeneralJournalLines { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object Currency { get; set; }
        }
    }
}
