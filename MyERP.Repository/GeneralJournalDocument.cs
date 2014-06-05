
using System;
using System.Data.Services.Client;
using System.Linq;
using MyERP.Infrastructure.Extensions;
using MyERP.Repositories;

namespace MyERP.Repository.MyERPService
{
    public partial class GeneralJournalDocument
    {
        GeneralJournalLineRepository GeneralJournalLineRepository = new GeneralJournalLineRepository();
        GeneralJournalDocumentRepository GeneralJournalDocumentRepository = new GeneralJournalDocumentRepository();

        partial void OnNumberSequenceIdChanged()
        {

        }

        partial void OnDocumentNoChanged()
        {
            var pendingEntityChanges =
                GeneralJournalDocumentRepository.Container.Entities.Any(
                    ed => ed.State != EntityStates.Unchanged && ed.Entity.GetType() == typeof (GeneralJournalDocument));

            if (pendingEntityChanges)
                GeneralJournalLines.ForEach(e =>
                {
                    e.DocumentNo = this.DocumentNo;
                    GeneralJournalLineRepository.Update(e);
                });
        }

        partial void OnDocumentCreatedChanged()
        {
            var pendingEntityChanges =
                GeneralJournalDocumentRepository.Container.Entities.Any(
                    ed => ed.State != EntityStates.Unchanged && ed.Entity.GetType() == typeof(GeneralJournalDocument));

            if(pendingEntityChanges)
                GeneralJournalLines.ForEach(e =>
                {
                    e.DocumentCreated = this.DocumentCreated;
                    GeneralJournalLineRepository.Update(e);
                });
        }

        partial void OnDocumentPostedChanged()
        {
            var pendingEntityChanges =
                GeneralJournalDocumentRepository.Container.Entities.Any(
                    ed => ed.State != EntityStates.Unchanged && ed.Entity.GetType() == typeof(GeneralJournalDocument));

            if(pendingEntityChanges)
                GeneralJournalLines.ForEach(e =>
                {
                    e.DocumentPosted = this.DocumentPosted;
                    GeneralJournalLineRepository.Update(e);
                });
        }
    }
}
