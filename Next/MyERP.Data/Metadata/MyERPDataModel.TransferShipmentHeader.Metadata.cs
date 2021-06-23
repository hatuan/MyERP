using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(TransferShipmentHeader.Metadata))]
    public partial class TransferShipmentHeader
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            public object TransferShipmentLines { get; set; }
        }
    }
}
