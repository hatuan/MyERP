using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(AccountsPayableLedger.Metadata))]
    public partial class AccountsPayableLedger
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
        }
    }
}
