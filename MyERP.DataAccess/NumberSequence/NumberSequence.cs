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
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(NumberSequence.NumberSequenceMetadata))]
    public partial class NumberSequence
    {
        internal sealed class NumberSequenceMetadata
        {

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String Code { get; set; }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String Name { get; set; }

            [Include]
            [Association("NumberSequence-client-association", "ClientId", "ClientId")]
            public Client Client { get; set; }

            [Include]
            [Association("NumberSequence-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }

            [Include]
            [Association("NumberSequence-user-created-association", "RecCreatedBy", "Id")]
            public User RecCreatedByUser { get; set; }

            [Include]
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
