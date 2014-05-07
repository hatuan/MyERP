using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.Text;
using System.Threading.Tasks;

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

            [Include]
            [Association("Currency-client-association", "ClientId", "ClientId")]
            public Client Client { get; set; }

            [Include]
            [Association("Currency-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }

            [Include]
            [Association("Account-user-created-association", "RecCreatedById", "Id")]
            public User RecCreatedByUser { get; set; }

            [Include]
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
