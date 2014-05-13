using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;


namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(GeneralJournalLine.GeneralJournalLineMetadata))]
    public partial class GeneralJournalLine
    {
        internal sealed class GeneralJournalLineMetadata
        {
            [Include]
            [Association("glline-client-association", "ClientId", "ClientId")]
            public Client Client { get; set; }

            [Include]
            [Association("glline-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }

            [Include]
            [Association("glline-document-association", "GeneralJournalDocumentId", "Id")]
            public GeneralJournalDocument GeneralJournalDocument { get; set; }

            [Include]
            [Association("glline-account-association", "AccountId", "Id")]
            public Account Account { get; set; }

            [Include]
            [Association("glline-coraccount-association", "CorAccountId", "Id")]
            public Account CorAccount { get; set; }

            [Include]
            [Association("glline-currency-association", "CurrencyId", "Id")]
            public Currency Currency { get; set; }


            [Include]
            [Association("glline-business-association", "BusinessPartnerId", "Id")]
            public BusinessPartner BusinessPartner { get; set; }

            [Include]
            [Association("glline-job-association", "JobId", "Id")]
            public Job Job { get; set; }

            [Include]
            [Association("glline-user-created-association", "RecCreatedBy", "Id")]
            public User RecCreatedByUser { get; set; }

            [Include]
            [Association("glline-user-modified-association", "RecModifiedBy", "Id")]
            public User RecModifiedByUser { get; set; }
        }
    }
}
