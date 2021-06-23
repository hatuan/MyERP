using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(TransferReceiptLine.Metadata))]
    public partial class TransferReceiptLine
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [Required()]
            public object TransferReceiptHeaderId { get; set; }
    
            public object TransferReceiptHeader { get; set; }
        }
    }
}
