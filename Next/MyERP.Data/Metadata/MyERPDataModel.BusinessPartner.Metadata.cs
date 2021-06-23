using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(BusinessPartner.Metadata))]
    public partial class BusinessPartner
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object Code { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object Description { get; set; }
    
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
    
            public object BusinessPartnerPriceGroupId { get; set; }
    
            public object BusinessPartnerGroupId1 { get; set; }
    
            public object BusinessPartnerGroupId2 { get; set; }
    
            public object BusinessPartnerGroupId3 { get; set; }
    
            public object BusPartnerDiscGroupId { get; set; }
    
            [StringLength(32)]
            public object TaxCode { get; set; }
    
            [StringLength(32)]
            public object ContactName { get; set; }
    
            [StringLength(256)]
            public object Address { get; set; }
    
            [StringLength(256)]
            public object AddressTransition { get; set; }
    
            [StringLength(32)]
            public object Telephone { get; set; }
    
            [StringLength(32)]
            public object Mobilephone { get; set; }
    
            [StringLength(32)]
            public object Fax { get; set; }
    
            [StringLength(32)]
            public object Mail { get; set; }
    
            [StringLength(32)]
            public object Website { get; set; }
    
            public object IsCustomer { get; set; }
    
            public object CustomerAccountId { get; set; }
    
            public object IsVendor { get; set; }
    
            public object VendorAccountId { get; set; }
    
            public object IsEmployee { get; set; }
    
            public object EmployeeAccountId { get; set; }
    
            public object PaymentTermId { get; set; }
    
            [StringLength(32)]
            public object BankAccount { get; set; }
    
            [StringLength(256)]
            public object BankName { get; set; }
    
            [StringLength(512)]
            public object Comment { get; set; }
    
            public object CreditLimit { get; set; }
    
            public object AmountLimit { get; set; }
    
            public object GeoLatitude { get; set; }
    
            public object GeoLongitude { get; set; }
    
            public object RecCreatedByUser { get; set; }
    
            public object RecModifiedByUser { get; set; }
    
            public object BusinessPartnerGroup1 { get; set; }
    
            public object BusinessPartnerGroup2 { get; set; }
    
            public object BusinessPartnerGroup3 { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object BusinessPartnerPriceGroup { get; set; }
    
            public object BusPartnerDiscGroup { get; set; }
        }
    }
}
