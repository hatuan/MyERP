using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(SalesHeader.Metadata))]
    public partial class SalesHeader
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [Required()]
            public object DocumentType { get; set; }
    
            [Required()]
            public object DocSequenceId { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object DocumentNo { get; set; }
    
            [Required()]
            public object DocumentDate { get; set; }
    
            [Required()]
            public object SellToCustomerId { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object SellToCustomerName { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object SellToAddress { get; set; }
    
            public object SellToContactId { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object SellToContactName { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object Description { get; set; }
    
            [Required()]
            public object BillToCustomerId { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object BillToName { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object BillToAddress { get; set; }
    
            public object BillToContactId { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object BillToContactName { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object BillToVatCode { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object BillToVatNote { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object ShipToName { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object ShipToAddress { get; set; }
    
            [StringLength(256)]
            public object ShipToContactName { get; set; }
    
            [Required()]
            public object CurrencyId { get; set; }
    
            [Required()]
            public object CurrencyFactor { get; set; }
    
            public object LocationId { get; set; }
    
            public object SalesPersonId { get; set; }
    
            [Required()]
            public object TotalAmount { get; set; }
    
            [Required()]
            public object TotalAmountLCY { get; set; }
    
            [Required()]
            public object TotalAmountNoVat { get; set; }
    
            [Required()]
            public object TotalAmountVat0 { get; set; }
    
            [Required()]
            public object TotalAmountVat5 { get; set; }
    
            [Required()]
            public object TotalAmountVat10 { get; set; }
    
            [Required()]
            public object TotalVatAmount { get; set; }
    
            [Required()]
            public object TotalVat5Amount { get; set; }
    
            [Required()]
            public object TotalVat10Amount { get; set; }
    
            [Required()]
            public object TotalPayment { get; set; }
    
            [Required()]
            public object TotalPaymentLCY { get; set; }
    
            [Required()]
            public object NoPrinted { get; set; }
    
            public object QuoteId { get; set; }
    
            public object CampaignId { get; set; }
    
            public object OpportunityId { get; set; }
    
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
    
            public object PostingDate { get; set; }
    
            [Required()]
            public object DocSubType { get; set; }
    
            public object SalesLines { get; set; }
    
            public object Location { get; set; }
    
            public object SellToCustomer { get; set; }
    
            public object BillToCustomer { get; set; }
    
            public object Currency { get; set; }
        }
    }
}
