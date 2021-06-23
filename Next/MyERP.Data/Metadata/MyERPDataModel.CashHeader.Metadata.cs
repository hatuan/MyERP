using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(CashHeader.Metadata))]
    public partial class CashHeader
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
    
            [Required()]
            public object PostingDate { get; set; }
    
            [Required()]
            public object BusinessPartnerId { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object BusinessPartnerName { get; set; }
    
            [StringLength(256)]
            public object BusinessPartnerAddress { get; set; }
    
            public object BusinessPartnerContactId { get; set; }
    
            [StringLength(256)]
            public object BusinessPartnerContactName { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object Description { get; set; }
    
            [Required()]
            public object AccountId { get; set; }
    
            [Required()]
            public object CurrencyId { get; set; }
    
            [Required()]
            public object CurrencyFactor { get; set; }
    
            [Required()]
            public object TotalAmount { get; set; }
    
            [Required()]
            public object TotalVatAmount { get; set; }
    
            [Required()]
            public object TotalPayment { get; set; }
    
            [Required()]
            public object TotalAmountLCY { get; set; }
    
            [Required()]
            public object TotalVatAmountLCY { get; set; }
    
            [Required()]
            public object TotalPaymentLCY { get; set; }
    
            public object NoPrinted { get; set; }
    
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
    
            public object CashLines { get; set; }
    
            public object BusinessPartner { get; set; }
    
            public object RecCreatedByUser { get; set; }
    
            public object RecModifiedByUser { get; set; }
    
            public object Currency { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object Account { get; set; }
    
            public object VatEntries { get; set; }
        }
    }
}
