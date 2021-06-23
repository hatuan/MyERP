using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(GeneralJournalLine.Metadata))]
    public partial class GeneralJournalLine
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [Required()]
            public object GeneralJournalHeaderId { get; set; }
    
            [Required()]
            public object DocumentType { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object DocumentNo { get; set; }
    
            public object PostingDate { get; set; }
    
            [Required()]
            public object LineNo { get; set; }
    
            [Required()]
            public object AccountId { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object Description { get; set; }
    
            [Required()]
            public object DebitAmountLCY { get; set; }
    
            [Required()]
            public object DebitAmount { get; set; }
    
            [Required()]
            public object CreditAmountLCY { get; set; }
    
            [Required()]
            public object CreditAmount { get; set; }
    
            public object BusinessPartnerId { get; set; }
    
            public object JobId { get; set; }
    
            public object FixAssetId { get; set; }
    
            [Required()]
            public object OrganizationId { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            [StringLength(3)]
            [Required()]
            public object PostingGroup { get; set; }
    
            public object GeneralJournalHeader { get; set; }
    
            public object Account { get; set; }
    
            public object BusinessPartner { get; set; }
    
            public object Job { get; set; }
        }
    }
}
