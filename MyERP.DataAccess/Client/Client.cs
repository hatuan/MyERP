using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyERP.DataAccess.Resources;


namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(Client.ClientMetadata))]
    public partial class Client
    {
        internal sealed class ClientMetadata
        {
            public ClientMetadata()
            {
            }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String CultureId { get; set; }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String AmountDecimalPlaces { get; set; }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String UnitAmountDecimalPlaces { get; set; }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public Decimal AmountRoundingPrecision { get; set; }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public Decimal UnitAmountRoundingPrecision { get; set; }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            [Association("Client-currency-association", "CurrencyLCYId", "Id")]
            public Currency CurrencyLCY { get; set; }

            [Association("organization-association", "Id", "OrganizationId")]
            public ICollection<Organization> Organizations { get; set; }

            [Association("Client-user-created-association", "RecCreatedById", "Id")]
            public User RecCreatedByUser { get; set; }

        }
    }
}
