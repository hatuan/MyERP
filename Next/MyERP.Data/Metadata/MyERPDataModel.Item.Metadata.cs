using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(Item.Metadata))]
    public partial class Item
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
            public object BaseUomId { get; set; }
    
            public object UnitCost { get; set; }
    
            public object UnitPrice { get; set; }
    
            public object CostingMethod { get; set; }
    
            public object ItemDiscountGroupId { get; set; }
    
            public object ItemGroupId1 { get; set; }
    
            public object ItemGroupId2 { get; set; }
    
            public object ItemGroupId3 { get; set; }
    
            public object PurchVendorId { get; set; }
    
            [Required()]
            public object SalesUomId { get; set; }
    
            [Required()]
            public object PurchUomId { get; set; }
    
            public object VatId { get; set; }
    
            public object InventoryAccountId { get; set; }
    
            public object ConsignmentAccountId { get; set; }
    
            public object SalesAccountId { get; set; }
    
            public object SalesInternalAccountId { get; set; }
    
            public object SalesReturnAccountId { get; set; }
    
            public object SalesDiscountAccountId { get; set; }
    
            public object COGSAccountId { get; set; }
    
            public object COGSDiffAccountId { get; set; }
    
            public object WIPAccountId { get; set; }
    
            public object ReplenishmentSystem { get; set; }
    
            [StringLength(32)]
            public object LeadTimeCalc { get; set; }
    
            public object ReorderingPolicy { get; set; }
    
            public object IncludeInventory { get; set; }
    
            [StringLength(32)]
            public object ReorderCycle { get; set; }
    
            [StringLength(32)]
            public object SafetyLeadTime { get; set; }
    
            public object SafetyStockQty { get; set; }
    
            public object ReorderPoint { get; set; }
    
            public object MaximumInventory { get; set; }
    
            public object ReorderQty { get; set; }
    
            public object MinimumOrderQty { get; set; }
    
            public object MaximumOrderQty { get; set; }
    
            public object OrderMultiple { get; set; }
    
            public object ManufacturingPolicy { get; set; }
    
            public object RoutingId { get; set; }
    
            public object BomId { get; set; }
    
            public object FlushingMethod { get; set; }
    
            public object Scrap { get; set; }
    
            public object LotSize { get; set; }
    
            public object LowLevelCode { get; set; }
    
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
    
            public object BaseUom { get; set; }
    
            public object Client { get; set; }
    
            public object Organization { get; set; }
    
            public object RecCreatedByUser { get; set; }
    
            public object RecModifiedByUser { get; set; }
    
            public object ItemUoms { get; set; }
    
            public object ItemGroup1 { get; set; }
    
            public object ItemGroup2 { get; set; }
    
            public object ItemGroup3 { get; set; }
    
            public object SalesUom { get; set; }
    
            public object PurchUom { get; set; }
    
            public object PurchVendor { get; set; }
    
            public object ItemDiscountGroup { get; set; }
    
            public object Vat { get; set; }
    
            public object InventoryAccount { get; set; }
    
            public object ConsignmentAccount { get; set; }
    
            public object SalesAccount { get; set; }
    
            public object SalesInternalAccount { get; set; }
    
            public object SalesReturnAccount { get; set; }
    
            public object SalesDiscountAccount { get; set; }
    
            public object COGSAccount { get; set; }
    
            public object COGSDiffAccount { get; set; }
    
            public object WIPAccount { get; set; }
        }
    }
}
