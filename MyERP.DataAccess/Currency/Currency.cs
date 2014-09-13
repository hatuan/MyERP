
using System;
using System.ComponentModel.DataAnnotations;
using MyERP.DataAccess.Resources;

namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(Currency.CurrencyMetadata))]
    public partial class Currency
    {
        internal sealed class CurrencyMetadata
        {
            public CurrencyMetadata()
            {
            }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String Code { get; set; }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String Name { get; set; }

            [Association("Currency-client-association", "ClientId", "ClientId")]
            public Client Client { get; set; }

            [Association("Currency-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }

            [Association("Account-user-created-association", "RecCreatedById", "Id")]
            public User RecCreatedByUser { get; set; }

            [Association("Account-user-modified-association", "RecModifiedById", "Id")]
            public User RecModifiedByUser { get; set; }
        }

        public CurrencyStatusType StatusType
        {
            get { return (CurrencyStatusType)Status; }
            set
            {
                //intentionally empty
            }
        }
    }
}
