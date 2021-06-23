using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(GeneralLedgerEntry.Metadata))]
    public partial class GeneralLedgerEntry
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
        }
    }
}
