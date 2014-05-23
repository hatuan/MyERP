using System;
using System.ComponentModel.DataAnnotations;
using MyERP.DataAccess.Resources;


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

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String Code { get; set; }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String Name { get; set; }

            [Association("Account-currency-association", "CurrencyId", "Id")]
            public Currency Currency { get; set; }

            [Association("Account-account-parent-association", "ParentAccountId", "Id")]
            public Account ParentAccount { get; set; }

            [Association("Account-client-association", "ClientId", "ClientId")]
            public Client Client { get; set; }

            [Association("Account-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }

            [Association("Account-user-created-association", "RecCreatedById", "Id")]
            public User RecCreatedByUser { get; set; }

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
