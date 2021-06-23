using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(UserInRole.Metadata))]
    public partial class UserInRole
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [Required()]
            public object RoleId { get; set; }
    
            [Required()]
            public object UserId { get; set; }
    
            public object User { get; set; }
    
            public object Role { get; set; }
        }
    }
}
