using System.ComponentModel.DataAnnotations;


namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(GeneralJournalLine.GeneralJournalLineMetadata))]
    public partial class GeneralJournalLine
    {
        internal sealed class GeneralJournalLineMetadata
        {
            [Association("glline-client-association", "ClientId", "ClientId")]
            public Client Client { get; set; }

            [Association("glline-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }

            [Association("glline-document-association", "GeneralJournalDocumentId", "Id")]
            public GeneralJournalDocument GeneralJournalDocument { get; set; }

            [Association("glline-account-association", "AccountId", "Id")]
            public Account Account { get; set; }

            [Association("glline-coraccount-association", "CorAccountId", "Id")]
            public Account CorAccount { get; set; }

            [Association("glline-currency-association", "CurrencyId", "Id")]
            public Currency Currency { get; set; }


            [Association("glline-business-association", "BusinessPartnerId", "Id")]
            public BusinessPartner BusinessPartner { get; set; }

            [Association("glline-job-association", "JobId", "Id")]
            public Job Job { get; set; }

            [Association("glline-user-created-association", "RecCreatedBy", "Id")]
            public User RecCreatedByUser { get; set; }

            [Association("glline-user-modified-association", "RecModifiedBy", "Id")]
            public User RecModifiedByUser { get; set; }
        }
    }
}
