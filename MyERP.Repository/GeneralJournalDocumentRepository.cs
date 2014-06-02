using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Services.Client;
using System.Linq;
using MyERP.DataAccess;
using MyERP.Infrastructure;
using MyERP.Repository.MyERPService;

namespace MyERP.Repositories
{
    [Export]
    public class GeneralJournalDocumentRepository : RepositoryBase
    {
        public void GetGeneralJournalDocumens(Action<IEnumerable<GeneralJournalDocument>> callback)
        {
            DataServiceQuery<GeneralJournalDocument> query = (DataServiceQuery<GeneralJournalDocument>)from generalJournalDocument in Container.GeneralJournalDocuments
                                                                                               .Expand(c => c.Currency)
                                                                                               .Expand(c => c.RecCreatedByUser)
                                                                                               .Expand(c => c.RecModifiedByUser)
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
    }
}
