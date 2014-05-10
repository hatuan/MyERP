using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.Text;
using System.Threading.Tasks;
using MyERP.DataAccess.Resources;

namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(User.UserMetadata))]
    public partial class User
    {
        internal sealed class UserMetadata
        {
            public UserMetadata()
            {
            }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String Name { get; set; }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String Password { get; set; }

            [Include]
            [Association("User-client-association", "ClientId", "ClientId")]
            public Client Client { get; set; }

            [Include]
            [Association("User-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }
        }
    }
}
