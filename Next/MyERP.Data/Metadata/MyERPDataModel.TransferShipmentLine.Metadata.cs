using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(TransferShipmentLine.Metadata))]
    public partial class TransferShipmentLine
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [Required()]
            public object TransferShipmentHeaderId { get; set; }
    
            public object TransferShipmentHeader { get; set; }
        }
    }
}
