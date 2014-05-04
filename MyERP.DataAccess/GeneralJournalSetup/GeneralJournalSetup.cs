using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;


namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(GeneralJournalSetup.GeneralJournalSetupMetadata))]
    public partial class GeneralJournalSetup
    {
        internal sealed class GeneralJournalSetupMetadata
        {
            [Include]
            [Association("glsetup-type1-noseries-association", "DefaultDocumentType1NoId", "Id")]
            public NoSeries DefaultDocumentType1No { get; set; }

            [Include]
            [Association("glsetup-lcy-currency-association", "LocalCurrencyId", "Id")]
            public Currency Currency { get; set; }

            [Include]
            [Association("glsetup-client-association", "ClientId", "Id")]
            public Client Client { get; set; }

            [Include]
            [Association("glsetup-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }

            [Include]
            [Association("glsetup-user-created-association", "RecCreatedBy", "Id")]
            public User RecCreatedByUser { get; set; }

            [Include]
            [Association("glsetup-user-modified-association", "RecModifiedBy", "Id")]
            public User RecModifiedByUser { get; set; }
        }
    }
}
