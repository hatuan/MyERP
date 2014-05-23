using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(GeneralJournalDocument.GeneralJournalDocumentMetadata))]
    public partial class GeneralJournalDocument
    {
        internal sealed class GeneralJournalDocumentMetadata
        {
            [Association("gldocument-number-sequence-association", "NumberSequenceId", "Id")]
            public NumberSequence NumberSequence { get; set; }

            [Association("gldocument-line-association", "Id", "GeneralJournalDocumentId")]
            public ICollection<GeneralJournalLine> GeneralJournalLines { get; set; }

            [Association("gldocument-client-association", "ClientId", "ClientId")]
            public Client Client { get; set; }
            [Association("gldocument-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }

            [Association("gldocument-user-created-association", "RecCreatedBy", "Id")]
            public User RecCreatedByUser { get; set; }

            [Association("gldocument-user-modified-association", "RecModifiedBy", "Id")]
            public User RecModifiedByUser { get; set; }
        }

        public bool Locked
        {
            get { return DocumentStatusType == GeneralJournalDocumentStatusType.Posted; }
            set { }
        }

        public GeneralJournalDocumentStatusType DocumentStatusType
        {
            get { return (GeneralJournalDocumentStatusType)Status; }
            set
            {
                //intentionally empty
            }
        }
    }
}
