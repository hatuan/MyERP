using System;

using System.ComponentModel.DataAnnotations;

using MyERP.DataAccess.Resources;

namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(User.UserMetadata))]
    public partial class User
    {
        internal sealed class UserMetadata
        {
            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String Name { get; set; }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String Password { get; set; }

            [Association("User-client-association", "ClientId", "ClientId")]
            public Client Client { get; set; }

            [Association("User-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }
        }
    }
}
