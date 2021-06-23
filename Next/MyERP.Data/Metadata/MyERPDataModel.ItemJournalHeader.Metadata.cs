using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(ItemJournalHeader.Metadata))]
    public partial class ItemJournalHeader
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            public object ItemJournalLines { get; set; }
        }
    }
}
