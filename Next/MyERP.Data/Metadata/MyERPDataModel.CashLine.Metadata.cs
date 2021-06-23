using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(CashLine.Metadata))]
    public partial class CashLine
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [Required()]
            public object CashHeaderId { get; set; }
    
            [Required()]
            public object LineNo { get; set; }
    
            [Required()]
            public object DocumentType { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object DocumentNo { get; set; }
    
            [Required()]
            public object PostingDate { get; set; }
    
            public object BusinessPartnerId { get; set; }
    
            [Required()]
            public object CorrespAccountId { get; set; }
    
            [StringLength(256)]
            public object Description { get; set; }
    
            [Required()]
            public object Amount { get; set; }
    
            [Required()]
            public object AmountLCY { get; set; }
    
            public object JobId { get; set; }
    
            public object AccountsPayableLedgerId { get; set; }
    
            public object AccountsReceivableLedgerId { get; set; }
    
            public object AccountsRPAmountConv { get; set; }
    
            [Required()]
            public object OrganizationId { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            public object CashHeader { get; set; }
    
            public object BusinessPartner { get; set; }
    
            public object CorrespAccount { get; set; }
    
            public object AccountsReceivableLedger { get; set; }
    
            public object AccountsPayableLedger { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object Job { get; set; }
        }
    }
}
