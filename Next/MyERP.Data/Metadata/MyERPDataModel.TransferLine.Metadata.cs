using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(TransferLine.Metadata))]
    public partial class TransferLine
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [Required()]
            public object TransferHeaderId { get; set; }
    
            public object TransferHeader { get; set; }
        }
    }
}
