using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(PurchaseHeader.Metadata))]
    public partial class PurchaseHeader
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
            public object BuyFromVendorId { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object BuyFromVendorName { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object BuyFromAddress { get; set; }
    
            public object BuyFromContactId { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object BuyFromContactName { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object Description { get; set; }
    
            [Required()]
            public object PayToVendorId { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object PayToName { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object PayToAddress { get; set; }
    
            public object PayToContactId { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object PayToContactName { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object PayToVatCode { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object PayToVatNote { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object ShipToName { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object ShipToAddress { get; set; }
    
            [StringLength(256)]
            [Required()]
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
            public object TotalVatAmount { get; set; }
    
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
    
            public object PuchaseLines { get; set; }
    
            public object BuyFromVendor { get; set; }
    
            public object PayToVendor { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object RecCreatedByUser { get; set; }
    
            public object RecModifiedByUser { get; set; }
    
            public object Currency { get; set; }
    
            public object Location { get; set; }
    
            public object NoSequence { get; set; }
        }
    }
}
