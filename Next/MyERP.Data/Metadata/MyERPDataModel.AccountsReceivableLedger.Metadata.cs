using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(AccountsReceivableLedger.Metadata))]
    public partial class AccountsReceivableLedger
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
        }
    }
}
