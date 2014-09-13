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
    public class GeneralJournalSetupRepository : RepositoryBase
    {
        public void GetGeneralJournalSetups(Action<IEnumerable<GeneralJournalSetup>> callback)
        {
            DataServiceQuery<GeneralJournalSetup> query = (DataServiceQuery<GeneralJournalSetup>)from generalJournalSetup in Container.GeneralJournalSetups
                                                                                       .Expand(c => c.RecCreatedByUser)
                                                                                       .Expand(c => c.RecModifiedByUser)
                                                                                       where generalJournalSetup.ClientId.Equals(SessionManager.Session["ClientId"])
                                                                                            && generalJournalSetup.OrganizationId.Equals((SessionManager.Session["Organization"] as Organization).Id)
                                                                                       select generalJournalSetup;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<GeneralJournalSetup>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }
    }
}
