using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(TransferReceiptHeader.Metadata))]
    public partial class TransferReceiptHeader
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            public object TransferReceiptLines { get; set; }
        }
    }
}
