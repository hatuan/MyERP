using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(VatEntry.Metadata))]
    public partial class VatEntry
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            public object PurchHeaderId { get; set; }
    
            public object CashHeaderId { get; set; }
    
            [Required()]
            public object DocumentType { get; set; }
    
            [Required()]
            public object DocumentSubType { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object DocumentNo { get; set; }
    
            [Required()]
            public object DocumentDate { get; set; }
    
            [Required()]
            public object PostingDate { get; set; }
    
            [Required()]
            public object InvoiceIssuedDate { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object InvoiceNumber { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object InvoiceSeries { get; set; }
    
            [Required()]
            public object LineNo { get; set; }
    
            [Required()]
            public object BusinessPartnerId { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object BusinessPartnerName { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object BusinessPartnerAddress { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object TaxCode { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object Description { get; set; }
    
            [Required()]
            public object CurrencyId { get; set; }
    
            [Required()]
            public object CurrencyFactor { get; set; }
    
            [Required()]
            public object VatBaseAmount { get; set; }
    
            [Required()]
            public object VatBaseAmountLCY { get; set; }
    
            [Required()]
            public object VatId { get; set; }
    
            [Required()]
            public object VatPercentage { get; set; }
    
            [Required()]
            public object VatAmount { get; set; }
    
            [Required()]
            public object VatAmountLCY { get; set; }
    
            [Required()]
            public object AccountVatId { get; set; }
    
            [Required()]
            public object CorrespAccountId { get; set; }
    
            public object JobId { get; set; }
    
            [Required()]
            public object OrganizationId { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            public object BusinessPartner { get; set; }
    
            public object Vat { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object AccountVat { get; set; }
    
            public object CorrespAccount { get; set; }
    
            public object Job { get; set; }
    
            public object Currency { get; set; }
        }
    }
}
