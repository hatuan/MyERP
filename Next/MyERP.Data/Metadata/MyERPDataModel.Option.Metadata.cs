using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(Option.Metadata))]
    public partial class Option
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            public object SalesPosLocationId { get; set; }
    
            public object SalesPosSequenceId { get; set; }
    
            public object SalesOrderSequenceId { get; set; }
    
            public object SalesShipmentSeqId { get; set; }
    
            public object SalesInvoiceSeqId { get; set; }
    
            public object PurchOrderSequenceId { get; set; }
    
            public object PurchReceiveSeqId { get; set; }
    
            public object PurchInvoiceSeqId { get; set; }
    
            public object OneTimeBusinessPartnerId { get; set; }
    
            public object GeneralLedgerSequenceId { get; set; }
    
            public object CashReceiptSequenceId { get; set; }
    
            public object CashPaymentSequenceId { get; set; }
    
            public object BankReceiptSequenceId { get; set; }
    
            public object BankCheckqueSequenceId { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            [Required()]
            public object OrganizationId { get; set; }
    
            [Required()]
            public object Status { get; set; }
    
            [Required()]
            public object Version { get; set; }
    
            [Required()]
            public object RecCreatedAt { get; set; }
    
            [Required()]
            public object RecCreatedBy { get; set; }
    
            [Required()]
            public object RecModifiedBy { get; set; }
    
            [Required()]
            public object RecModifiedAt { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object RecModifiedByUser { get; set; }
    
            public object SalesPosSequence { get; set; }
    
            public object SalesOrderSequence { get; set; }
    
            public object SalesShipmentSequence { get; set; }
    
            public object SalesInvoiceSequence { get; set; }
    
            public object PurchOrderSequence { get; set; }
    
            public object PurchReceiveSequence { get; set; }
    
            public object PurchInvoiceSequence { get; set; }
    
            public object RecCreatedByUser { get; set; }
    
            public object SalesPosLocation { get; set; }
    
            public object OneTimeBusinessPartner { get; set; }
    
            public object GeneralLedgerSequence { get; set; }
    
            public object CashReceiptSequence { get; set; }
    
            public object CashPaymentSequence { get; set; }
    
            public object BankReceiptSequence { get; set; }
    
            public object BankCheckque { get; set; }
        }
    }
}
