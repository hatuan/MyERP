using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Services.Client;
using System.Linq;
using MyERP.Infrastructure;
using MyERP.Repository.MyERPService;


namespace MyERP.Repositories
{
    [Export]
    public class OrganizationRepository : RepositoryBase
    {
        public void GetOrganizations(Action<IEnumerable<Organization>> callback )
        {
            User user = SessionManager.Session["User"] as User;

            DataServiceQuery<Organization> query = (DataServiceQuery<Organization>)from organization in Container.Organizations
                                                                   where organization.ClientId.Equals(user.ClientId)
                                                                   select organization;
            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<Organization>;
                var response = request.EndExecute(result);
                UIThread.Invoke(() =>callback(response));
            }, query);
        }

        public void AllOrganization(Guid organizationId, Action<Organization> callback)
        {
            Uri actionUri = new Uri(String.Format("/Organizations(guid'{0}')/AllOrganization?$expand=Client", organizationId), UriKind.Relative);

            this.Container.BeginExecute<Organization>(actionUri, result =>
            {
                var response = this.Container.EndExecute<Organization>(result).FirstOrDefault();
                UIThread.Invoke(() => callback(response));
            }, this.Container);
        }

        public void GeneralJournalSetup(Guid organizationId, Action<GeneralJournalSetup> callback)
        {
            Uri actionUri = new Uri(String.Format("/Organizations(guid'{0}')/GeneralJournalSetup?$expand=GeneralJournalNumberSequence,LocalCurrency", organizationId), 
                UriKind.Relative);

            this.Container.BeginExecute<GeneralJournalSetup>(actionUri, result =>
            {
                var response = this.Container.EndExecute<GeneralJournalSetup>(result).FirstOrDefault();
                UIThread.Invoke(() => callback(response));
            }, this.Container);
        }
    }
}
