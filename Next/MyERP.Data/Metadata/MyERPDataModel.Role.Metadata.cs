using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(Role.Metadata))]
    public partial class Role
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [StringLength(512)]
            public object Description { get; set; }
    
            [Required()]
            public object ClientId { get; set; }
    
            public object Users { get; set; }
    
            public object Client { get; set; }
        }
    }
}
