using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(GeneralJournalDocument.GeneralJournalDocumentMetadata))]
    public partial class GeneralJournalDocument
    {
        internal sealed class GeneralJournalDocumentMetadata
        {
            [Include]
            [Composition]
            [Association("gldocument-line-association", "Id", "GeneralJournalDocumentId")]
            public IList<GeneralJournalLine> GeneralJournalLines { get; set; }

            [Include]
            [Association("gldocument-client-association", "ClientId", "Id")]
            public Client Client { get; set; }

            [Include]
            [Association("gldocument-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }

            [Include]
            [Association("gldocument-user-created-association", "RecCreatedBy", "Id")]
            public User RecCreatedByUser { get; set; }

            [Include]
            [Association("gldocument-user-modified-association", "RecModifiedBy", "Id")]
            public User RecModifiedByUser { get; set; }
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
