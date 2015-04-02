
using System;
using System.ComponentModel.DataAnnotations;
using MyERP.DataAccess.Resources;

namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(CurrencyConvertRate.CurrencyConvertRateMetadata))]
    public partial class CurrencyConvertRate
    {
        internal sealed class CurrencyConvertRateMetadata
        {
            public CurrencyConvertRateMetadata()
            {
            }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public DateTime ValidForm { get; set; }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            [Association("CurrencyConvertRate-currency-association", "CurrencyId", "Id")]
            public Currency Currency { get; set; }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            [Association("CurrencyConvertRate-currency-relational-association", "CurrencyRelationalId", "Id")]
            public Currency CurrencyRelational { get; set; }

            [Association("CurrencyConvertRate-client-association", "ClientId", "ClientId")]
            public Client Client { get; set; }

            [Association("CurrencyConvertRate-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }

            [Association("CurrencyConvertRate-user-created-association", "RecCreatedById", "Id")]
            public User RecCreatedByUser { get; set; }

            [Association("CurrencyConvertRate-user-modified-association", "RecModifiedById", "Id")]
            public User RecModifiedByUser { get; set; }
        }
    }
}
