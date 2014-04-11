using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices;
using System.ServiceModel.DomainServices.Server;

namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(Organization.OrganizationMetadata))]
    public partial class Organization
    {
        internal sealed class OrganizationMetadata
        {
            public OrganizationMetadata()
            {
            }

            [Include]
            [Association("Organization-user-created-association", "RecCreatedById", "Id")]
            public User RecCreatedByUser { get; set; }

            [Include]
            [Association("Organization-user-modified-association", "RecModifiedById", "Id")]
            public User RecModifiedByUser { get; set; }
        }

        public OrganizationStatusType StatusType
        {
            get { return (OrganizationStatusType)Status; }
            set
            {
                //intentionally empty
            }
        }
    }
}
