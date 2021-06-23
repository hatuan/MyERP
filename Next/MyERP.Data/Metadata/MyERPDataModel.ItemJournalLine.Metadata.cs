using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(ItemJournalLine.Metadata))]
    public partial class ItemJournalLine
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [Required()]
            public object ItemJournalHeaderId { get; set; }
    
            public object ItemJournalHeader { get; set; }
        }
    }
}
