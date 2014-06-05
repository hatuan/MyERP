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
            var query = (DataServiceQuery<GeneralJournalLine>)from generalJournalLine in Container.GeneralJournalLines
                                                              .Expand(c => c.Account)
                                                              .Expand(c => c.CorAccount)
                                                              .Expand(c => c.Currency)
                                                              .Expand(c => c.BusinessPartner)
                                                              .Expand(c => c.Job)
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

        public void GetGeneralJournalLines(GeneralJournalDocument generalJournalDocument, Action<IEnumerable<GeneralJournalLine>> callback)
        {
            var query = (DataServiceQuery<GeneralJournalLine>)from generalJournalLine in Container.GeneralJournalLines
                                                              .Expand(c => c.Account)
                                                              .Expand(c => c.CorAccount)
                                                              .Expand(c => c.Currency)
                                                              .Expand(c => c.BusinessPartner)
                                                              .Expand(c => c.Job)
                                                              .Expand(c => c.RecCreatedByUser)
                                                              .Expand(c => c.RecModifiedByUser)
                                                              where generalJournalLine.ClientId.Equals(SessionManager.Session["ClientId"]) 
                                                              orderby generalJournalLine.GeneralJournalDocumentId, generalJournalLine.LineNo
                                                              select generalJournalLine;
            if (generalJournalDocument != null)
                query = (DataServiceQuery<GeneralJournalLine>) query.Where(c => c.GeneralJournalDocumentId.Equals(generalJournalDocument.Id));
            else
                query = (DataServiceQuery<GeneralJournalLine>) query.Where(c => c.GeneralJournalDocumentId.Equals(Guid.Empty));

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<GeneralJournalLine>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }

        public void AddNew(GeneralJournalLine generalJournalLine)
        {
            
            //Container.AddLink(generalJournalLine.GeneralJournalDocument, "GeneralJournalLines", generalJournalLine);
            //Container.SetLink(generalJournalLine, "GeneralJournalDocument", generalJournalLine.GeneralJournalDocument);

            if (generalJournalLine.GeneralJournalDocument.GeneralJournalLines.Count == 0)
                generalJournalLine.LineNo = 10000;
            else
                generalJournalLine.LineNo = generalJournalLine.GeneralJournalDocument.GeneralJournalLines.Where(c => c.LineNo % 10000 == 0).Max(m => m.LineNo) + 10000;

            base.AddNew("GeneralJournalLines", generalJournalLine);
            
            generalJournalLine.GeneralJournalDocument.GeneralJournalLines.Add(generalJournalLine);

        }
    }
}
