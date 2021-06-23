using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(User.Metadata))]
    public partial class User
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object Name { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object FullName { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object Email { get; set; }
    
            [Required()]
            public object IsActivated { get; set; }
    
            [Required()]
            public object IsEmailConfirmed { get; set; }
    
            [StringLength(512)]
            public object EmailConfirmationCode { get; set; }
    
            [StringLength(512)]
            public object PasswordQuestion { get; set; }
    
            [StringLength(512)]
            public object PasswordAnswer { get; set; }
    
            [StringLength(128)]
            [Required()]
            public object Password { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object Salt { get; set; }
    
            public object OrganizationId { get; set; }
    
            public object ClientId { get; set; }
    
            [StringLength(8)]
            public object CultureUiId { get; set; }
    
            [StringLength(512)]
            public object Comment { get; set; }
    
            [Required()]
            public object CreatedDate { get; set; }
    
            public object LastModifiedDate { get; set; }
    
            [StringLength(32)]
            [Required()]
            public object LastLoginIp { get; set; }
    
            [Required()]
            public object LastLoginDate { get; set; }
    
            [Required()]
            public object IsLockedOut { get; set; }
    
            [StringLength(512)]
            public object LastLockedOutReason { get; set; }
    
            [Required()]
            public object LastLockedOutDate { get; set; }
    
            [Required()]
            public object LastPasswordChangedDate { get; set; }
    
            [Required()]
            public object Version { get; set; }
    
            public object Roles { get; set; }
    
            public object Organization { get; set; }
    
            public object Client { get; set; }
        }
    }
}
