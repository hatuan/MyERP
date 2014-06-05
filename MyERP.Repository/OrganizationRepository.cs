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

        public void GetAllOrganization(Guid clientId, Action<Organization> callback)
        {
            Uri actionUri = new Uri(this.Container.BaseUri,
                String.Format("Organizations(guid'{0}')/GetAllOrganization", clientId)
                );

            this.Container.BeginExecute<int>(actionUri, result =>
            {
                var response = this.Container.EndExecute<Organization>(result).FirstOrDefault();
                UIThread.Invoke(() => callback(response));
            }, this.Container);
        }
    }
}
