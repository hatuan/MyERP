using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(SalesPrice.Metadata))]
    public partial class SalesPrice
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [Required()]
            public object SalesPriceGroupId { get; set; }
    
            [Required()]
            public object SalesType { get; set; }
    
            public object BusinessPartnerId { get; set; }
    
            public object BusPartnerPriceGroupId { get; set; }
    
            public object CampaignId { get; set; }
    
            [Required()]
            public object ItemId { get; set; }
    
            public object UomId { get; set; }
    
            [Required()]
            public object StartingDate { get; set; }
    
            [Required()]
            public object MinQty { get; set; }
    
            [Required()]
            public object UnitPrice { get; set; }
    
            public object EndingDate { get; set; }
    
            [Required()]
            public object Status { get; set; }
    
            [Required()]
            public object Version { get; set; }
    
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
    
            public object SalesPriceGroup { get; set; }
    
            public object Item { get; set; }
    
            public object Uom { get; set; }
    
            public object BusPartnerPriceGroup { get; set; }
    
            public object BusinessPartner { get; set; }
        }
    }
}
