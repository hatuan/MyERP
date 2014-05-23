using System.ComponentModel.DataAnnotations;

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

            [Association("Organization-client-association", "ClientId", "ClientId")]
            public Client Client { get; set; }

            [Association("Organization-user-created-association", "RecCreatedById", "Id")]
            public User RecCreatedByUser { get; set; }

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
