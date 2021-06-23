using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(Client.Metadata))]
    public partial class Client
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [StringLength(36)]
            [Required()]
            public object UUID { get; set; }
    
            [StringLength(256)]
            public object Description { get; set; }
    
            [Required()]
            public object IsActivated { get; set; }
    
            [StringLength(8)]
            public object CultureId { get; set; }
    
            [Required()]
            public object AmountDecimalPlaces { get; set; }
    
            [Required()]
            public object AmountRoundingPrecision { get; set; }
    
            [Required()]
            public object UnitAmountDecimalPlaces { get; set; }
    
            [Required()]
            public object UnitAmountRoundingPrecision { get; set; }
    
            public object CurrencyLcyId { get; set; }
    
            [StringLength(14)]
            public object TaxCode { get; set; }
    
            [StringLength(256)]
            public object Address { get; set; }
    
            [StringLength(256)]
            public object AddressTransition { get; set; }
    
            [StringLength(32)]
            public object Telephone { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object Email { get; set; }
    
            [StringLength(32)]
            public object Website { get; set; }
    
            public object Image { get; set; }
    
            [StringLength(32)]
            public object RepresentativeName { get; set; }
    
            [StringLength(32)]
            public object RepresentativePosition { get; set; }
    
            [StringLength(32)]
            public object ContactName { get; set; }
    
            [StringLength(32)]
            public object Mobilephone { get; set; }
    
            public object TaxAuthoritiesId { get; set; }
    
            public object RecCreatedBy { get; set; }
    
            [Required()]
            public object RecCreatedAt { get; set; }
    
            public object RecModifiedBy { get; set; }
    
            [Required()]
            public object RecModifiedAt { get; set; }
    
            [Required()]
            public object Version { get; set; }
    
            public object RecCreatedByUser { get; set; }
    
            public object RecModifiedByUser { get; set; }
    
            public object Organizations { get; set; }
    
            public object CurrencyLcy { get; set; }
        }
    }
}
