using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Services.Client;
using System.Linq;
using MyERP.Infrastructure;
using MyERP.Repository.MyERPService;

namespace MyERP.Repositories
{
    [Export]
    public class GeneralJournalLineRepository : RepositoryBase
    {
        public void GetGeneralJournalLines(Action<IEnumerable<GeneralJournalLine>> callback)
        {
            DataServiceQuery<GeneralJournalLine> query = (DataServiceQuery<GeneralJournalLine>)from generalJournalLine in Container.GeneralJournalLines
                                                                                               .Expand(c => c.Currency)
                                                                                               .Expand(c => c.RecCreatedByUser)
                                                                                               .Expand(c => c.RecModifiedByUser)
                                                                                               where generalJournalLine.ClientId.Equals(SessionManager.Session["ClientId"])
                                                                                               orderby generalJournalLine.GeneralJournalDocumentId, generalJournalLine.LineNo
                                                                                               select generalJournalLine;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<GeneralJournalLine>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }
    }
}
