using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(StockkeepingUnit.Metadata))]
    public partial class StockkeepingUnit
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
        }
    }
}
