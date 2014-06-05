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

        //public void GetGeneralJournalSetupOfOrganization(Guid organizationId, Action<GeneralJournalSetup> callback)
        //{
        //    DataServiceQuery<GeneralJournalSetup> query = (DataServiceQuery<GeneralJournalSetup>)from generalJournalSetup in Container.GeneralJournalSetups
        //                                                                                         .Expand(c => c.RecCreatedByUser)
        //                                                                                         .Expand(c => c.RecModifiedByUser)
        //                                                                                         where generalJournalSetup.ClientId.Equals(SessionManager.Session["ClientId"]) 
        //                                                                                            && generalJournalSetup.OrganizationId.Equals(organizationId)
        //                                                                                         select generalJournalSetup;

        //    query.BeginExecute(result =>
        //    {
        //        var request = result.AsyncState as DataServiceQuery<GeneralJournalSetup>;
        //        var response = request.EndExecute(result);
        //        if (response.FirstOrDefault() == null)
        //        {
        //            OrganizationRepository OrganizationRepository = new OrganizationRepository();
        //            OrganizationRepository.GetAllOrganization((Guid) SessionManager.Session["ClientId"],
        //                resultAllOrganization =>
        //                {
        //                    var queryAllOrganization = (DataServiceQuery<GeneralJournalSetup>)from generalJournalSetup in Container.GeneralJournalSetups
        //                                                                                         .Expand(c => c.RecCreatedByUser)
        //                                                                                         .Expand(c => c.RecModifiedByUser)
        //                                                                                  where generalJournalSetup.ClientId.Equals(SessionManager.Session["ClientId"])
        //                                                                                     && generalJournalSetup.OrganizationId.Equals(resultAllOrganization.Id)
        //                                                                                  select generalJournalSetup;

        //                    queryAllOrganization.BeginExecute(rs =>
        //                    {
        //                        var rq = rs.AsyncState as DataServiceQuery<GeneralJournalSetup>;
        //                        var rp = rq.EndExecute(rs);
        //                        UIThread.Invoke(() => callback(rp.FirstOrDefault()));
        //                    }, queryAllOrganization);
        //                });
        //        }
        //        else
        //            UIThread.Invoke(() => callback(response.FirstOrDefault()));
        //    }, query);
        //}

        public void GetGeneralJournalSetupOfOrganization(Guid organizationId, Action<GeneralJournalSetup> callback)
        {
            Uri actionUri = new Uri(this.Container.BaseUri,
                String.Format("GeneralJournalSetups(guid'{0}')/GetGeneralJournalSetupOfOrganization", organizationId)
                );

            this.Container.BeginExecute<int>(actionUri, result =>
            {
                var response = this.Container.EndExecute<GeneralJournalSetup>(result).FirstOrDefault();
                UIThread.Invoke(() => callback(response));
            }, this.Container);
        }

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
