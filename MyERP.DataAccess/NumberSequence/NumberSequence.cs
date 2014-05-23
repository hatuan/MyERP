using System;

using System.ComponentModel.DataAnnotations;

using MyERP.DataAccess.Resources;

namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(NumberSequence.NumberSequenceMetadata))]
    public partial class NumberSequence
    {
        internal sealed class NumberSequenceMetadata
        {

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String Code { get; set; }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String Name { get; set; }

            [Association("NumberSequence-client-association", "ClientId", "ClientId")]
            public Client Client { get; set; }

            [Association("NumberSequence-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }

            [Association("NumberSequence-user-created-association", "RecCreatedBy", "Id")]
            public User RecCreatedByUser { get; set; }

            [Association("NumberSequence-user-modified-association", "RecModifiedBy", "Id")]
            public User RecModifiedByUser { get; set; }
        }



        public NumberSequenceStatusType StatusType
        {
            get { return (NumberSequenceStatusType)Status; }
            set
            {
                //intentionally empty
            }
        }
    }

}
