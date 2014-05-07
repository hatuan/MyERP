using System;
using System.ComponentModel.Composition;
using MyERP.DataAccess;

namespace MyERP.Repositories
{
    [Export]
    public class GeneralJournalDocumentRepository : RepositoryBase
    {
        private bool isLoading = false;

        public void SetGeneralJournalDocumentNo(GeneralJournalDocument generalJournalDocument, Action<GeneralJournalDocument> callback)
        {
            if (isLoading)
            {
                return;
            }
            isLoading = true;

            this.Context.GetGeneralJournalDocumentNos(generalJournalDocument, (operation) =>
            {
                isLoading = false;
                callback(operation.Value);
            }, null);
        }
    }
}
