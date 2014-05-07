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
            [Association("glline-document-association", "GeneralJournalDocumentId", "Id")]
            public GeneralJournalDocument GeneralJournalDocument { get; set; }
            
            [Include]
            [Association("glline-client-association", "ClientId", "ClientId")]
            public Client Client { get; set; }

            [Include]
            [Association("glline-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }

            [Include]
            [Association("glline-user-created-association", "RecCreatedBy", "Id")]
            public User RecCreatedByUser { get; set; }

            [Include]
            [Association("glline-user-modified-association", "RecModifiedBy", "Id")]
            public User RecModifiedByUser { get; set; }
        }
    }
}
