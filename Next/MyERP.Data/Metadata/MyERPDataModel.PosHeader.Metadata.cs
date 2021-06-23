using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(PosHeader.Metadata))]
    public partial class PosHeader
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
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
            public object SellToAddress { get; set; }
    
            public object SellToContactId { get; set; }
    
            [StringLength(256)]
            public object SellToContactName { get; set; }
    
            [StringLength(256)]
            public object Description { get; set; }
    
            [Required()]
            public object BillToCustomerId { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object BillToName { get; set; }
    
            [StringLength(256)]
            public object BillToAddress { get; set; }
    
            public object BillToContactId { get; set; }
    
            [StringLength(256)]
            public object BillToContactName { get; set; }
    
            [StringLength(32)]
            public object BillToVatCode { get; set; }
    
            [StringLength(256)]
            public object BillToVatNote { get; set; }
    
            [StringLength(256)]
            public object ShipToName { get; set; }
    
            [StringLength(256)]
            public object ShipToAddress { get; set; }
    
            [StringLength(256)]
            public object ShipToContactName { get; set; }
    
            [Required()]
            public object LocationId { get; set; }
    
            [Required()]
            public object SalesPersonId { get; set; }
    
            [Required()]
            public object CurrencyId { get; set; }
    
            [Required()]
            public object CurrencyFactor { get; set; }
    
            [Required()]
            public object TotalAmount { get; set; }
    
            public object TotalAmountLCY { get; set; }
    
            [Required()]
            public object TotalVatAmount { get; set; }
    
            [Required()]
            public object TotalVatAmountLCY { get; set; }
    
            public object DiscountId { get; set; }
    
            [Required()]
            public object InvoiceDiscountPercentage { get; set; }
    
            [Required()]
            public object InvoiceDiscountAmount { get; set; }
    
            [Required()]
            public object InvoiceDiscountAmountLCY { get; set; }
    
            [Required()]
            public object TotalLineDiscountAmount { get; set; }
    
            [Required()]
            public object TotalLineDiscountAmountLCY { get; set; }
    
            [Required()]
            public object TotalPayment { get; set; }
    
            [Required()]
            public object TotalPaymentLCY { get; set; }
    
            [Required()]
            public object CashOfCustomer { get; set; }
    
            [Required()]
            public object ChangeReturnToCustomer { get; set; }
    
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
    
            public object PosLines { get; set; }
    
            public object Location { get; set; }
    
            public object SellToCustomer { get; set; }
    
            public object BillToCustomer { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object RecCreatedByUser { get; set; }
    
            public object RecModifiedByUser { get; set; }
        }
    }
}
