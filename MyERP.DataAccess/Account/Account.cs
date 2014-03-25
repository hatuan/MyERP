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
            [System.ComponentModel.DataAnnotations.Association("Account-currency-association", "CurrencyId", "Id")]
            public Currency Currency { get; set; }

            [Include]
            [System.ComponentModel.DataAnnotations.Association("Account-account-parent-association", "ParentAccountId", "Id")]
            public Account ParentAccount { get; set; }
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
