using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices;
using System.ServiceModel.DomainServices.Server;

namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(Account.AccountMetadata))]
    public partial class Account
    {
        internal sealed class AccountMetadata
        {
            public AccountMetadata()
            {
            }

            [Include]
            [Association("Account-currency-association", "CurrencyId", "Id")]
            public Currency Currency { get; set; }

            [Include]
            [Association("Account-account-parent-association", "ParentAccountId", "Id")]
            public Account ParentAccount { get; set; }

            [Include]
            [Association("Account-client-association", "ClientId", "Id")]
            public Client Client { get; set; }

            [Include]
            [Association("Account-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }

            [Include]
            [Association("Account-user-created-association", "RecCreatedById", "Id")]
            public User RecCreatedByUser { get; set; }

            [Include]
            [Association("Account-user-modified-association", "RecModifiedById", "Id")]
            public User RecModifiedByUser { get; set; }
        }

        public AccountStatusType StatusType
        {
            get { return (AccountStatusType) Status; }
            set
            {
                //intentionally empty
            }
        }
    }
}
