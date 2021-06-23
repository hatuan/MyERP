using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(ItemLedgerEntry.Metadata))]
    public partial class ItemLedgerEntry
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
        }
    }
}
