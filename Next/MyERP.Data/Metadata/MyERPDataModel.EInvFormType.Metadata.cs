using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(EInvFormType.Metadata))]
    public partial class EInvFormType
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [StringLength(100)]
            [Required()]
            public object InvoiceName { get; set; }
    
            [StringLength(6)]
            [Required()]
            public object InvoiceType { get; set; }
    
            [StringLength(3)]
            [Required()]
            public object InvoiceTypeNo { get; set; }
    
            [StringLength(11)]
            [Required()]
            public object TemplateCode { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object InvoiceForm { get; set; }
    
            [StringLength(6)]
            [Required()]
            public object InvoiceSeries { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object FormFileName { get; set; }
    
            [Required()]
            public object FormFile { get; set; }
    
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
    
            public object Logo { get; set; }
    
            public object Watermark { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            public object OrganizationId { get; set; }
    
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
    
            public object EInvFormReleases { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object RecCreatedByUser { get; set; }
    
            public object RecModifiedByUser { get; set; }
        }
    }
}
