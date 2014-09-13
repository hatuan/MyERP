using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Services.Client;
using System.Linq;
using MyERP.DataAccess;
using MyERP.Infrastructure;
using MyERP.Infrastructure.Extensions;
using MyERP.Repository.MyERPService;

namespace MyERP.Repositories
{
    [Export]
    public class GeneralJournalDocumentRepository : RepositoryBase
    {
        public void GetGeneralJournalDocumens(Action<IEnumerable<GeneralJournalDocument>> callback)
        {
            DataServiceQuery<GeneralJournalDocument> query = (DataServiceQuery<GeneralJournalDocument>)from generalJournalDocument in Container.GeneralJournalDocuments
                                                                                                       .Expand(c => c.Organization)
                                                                                                       .Expand(c => c.Currency)
                                                                                                       .Expand(c => c.RecCreatedByUser)
                                                                                                       .Expand(c => c.RecModifiedByUser)
                                                                                                       .Expand(c => c.GeneralJournalLines)
                                                                                                       where generalJournalDocument.ClientId.Equals(SessionManager.Session["ClientId"])
                                                                                                       orderby generalJournalDocument.DocumentNo, generalJournalDocument.DocumentPosted
                                                                                                       select generalJournalDocument;
            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<GeneralJournalDocument>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }

        public void AddNew(GeneralJournalDocument generalJournalDocument)
        {
            base.AddNew("GeneralJournalDocuments", generalJournalDocument);
        }

        public override void Delete(object entity)
        {
            var generalJournalDocument = entity as GeneralJournalDocument;
            generalJournalDocument.GeneralJournalLines.ForEach(e => base.Delete(e));
            base.Delete(entity);
        }
    }
}
