using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(EInvoiceHeader.Metadata))]
    public partial class EInvoiceHeader
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [Required()]
            public object FormTypeId { get; set; }
    
            public object OriginalEInvoiceId { get; set; }
    
            [StringLength(32)]
            public object OriginalInvoiceId { get; set; }
    
            public object OriginalInvoiceIssueDate { get; set; }
    
            [StringLength(7)]
            public object InvoiceNumber { get; set; }
    
            [StringLength(100)]
            public object InvoiceName { get; set; }
    
            [Required()]
            public object InvoiceIssuedDate { get; set; }
    
            public object SignedDate { get; set; }
    
            public object SubmittedDate { get; set; }
    
            [StringLength(50)]
            public object ContractNumber { get; set; }
    
            public object ContractDate { get; set; }
    
            [StringLength(256)]
            public object Description { get; set; }
    
            [Required()]
            public object CurrencyId { get; set; }
    
            [Required()]
            public object ExchangeRate { get; set; }
    
            [StringLength(400)]
            public object InvoiceNote { get; set; }
    
            [Required()]
            public object AdjustmentType { get; set; }
    
            [StringLength(255)]
            public object AdditionalReferenceDesc { get; set; }
    
            public object AdditionalReferenceDate { get; set; }
    
            public object BuyerId { get; set; }
    
            [StringLength(255)]
            [Required()]
            public object BuyerDisplayName { get; set; }
    
            [StringLength(255)]
            [Required()]
            public object BuyerLegalName { get; set; }
    
            [StringLength(14)]
            [Required()]
            public object BuyerTaxCode { get; set; }
    
            [StringLength(255)]
            [Required()]
            public object BuyerAddressLine { get; set; }
    
            [StringLength(10)]
            public object BuyerPostalCode { get; set; }
    
            [StringLength(50)]
            public object BuyerDistrictName { get; set; }
    
            [StringLength(50)]
            public object BuyerCityName { get; set; }
    
            [StringLength(2)]
            public object BuyerCountryCode { get; set; }
    
            [StringLength(20)]
            public object BuyerPhoneNumber { get; set; }
    
            [StringLength(20)]
            public object BuyerFaxNumber { get; set; }
    
            [StringLength(50)]
            public object BuyerEmail { get; set; }
    
            [StringLength(100)]
            public object BuyerBankName { get; set; }
    
            [StringLength(20)]
            public object BuyerBankAccount { get; set; }
    
            [StringLength(255)]
            [Required()]
            public object SellerLegalName { get; set; }
    
            [StringLength(14)]
            [Required()]
            public object SellerTaxCode { get; set; }
    
            [StringLength(255)]
            [Required()]
            public object SellerAddressLine { get; set; }
    
            [StringLength(10)]
            public object SellerPostalCode { get; set; }
    
            [StringLength(50)]
            public object SellerDistrictName { get; set; }
    
            [StringLength(50)]
            public object SellerCityName { get; set; }
    
            [StringLength(2)]
            public object SellerCountryCode { get; set; }
    
            [StringLength(20)]
            public object SellerPhoneNumber { get; set; }
    
            [StringLength(20)]
            public object SellerFaxNumber { get; set; }
    
            [StringLength(50)]
            public object SellerEmail { get; set; }
    
            [StringLength(100)]
            public object SellerBankName { get; set; }
    
            [StringLength(20)]
            public object SellerBankAccount { get; set; }
    
            [StringLength(100)]
            public object SellerContactPersonName { get; set; }
    
            [StringLength(100)]
            public object SellerSignedPersonName { get; set; }
    
            [StringLength(100)]
            public object SellerSubmittedPersonName { get; set; }
    
            [StringLength(50)]
            [Required()]
            public object PaymentMethodName { get; set; }
    
            [Required()]
            public object SumOfTotalLineAmountWithoutVAT { get; set; }
    
            [Required()]
            public object TotalAmountWithoutVAT { get; set; }
    
            public object IsTotalAmountWithoutVATPos { get; set; }
    
            [Required()]
            public object TotalVATAmount { get; set; }
    
            public object IsTotalVATAmountPos { get; set; }
    
            [Required()]
            public object TotalAmountWithVAT { get; set; }
    
            [Required()]
            public object TotalAmountWithVATFrn { get; set; }
    
            [StringLength(255)]
            [Required()]
            public object TotalAmountWithVATInWords { get; set; }
    
            public object IsTotalAmountPos { get; set; }
    
            [Required()]
            public object DiscountAmount { get; set; }
    
            public object IsDiscountAmtPos { get; set; }
    
            [StringLength(36)]
            public object ReservationCode { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            [Required()]
            public object OrganizationId { get; set; }
    
            [Required()]
            public object Version { get; set; }
    
            [Required()]
            public object Status { get; set; }
    
            [Required()]
            public object RecCreatedBy { get; set; }
    
            [Required()]
            public object RecCreatedAt { get; set; }
    
            [Required()]
            public object RecModifiedBy { get; set; }
    
            [Required()]
            public object RecModifiedAt { get; set; }
    
            public object EInvoiceLines { get; set; }
    
            public object EInvFormType { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object RecCreatedByUser { get; set; }
    
            public object RecModifiedByUser { get; set; }
    
            public object Buyer { get; set; }
    
            public object Currency { get; set; }
        }
    }
}
