using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using System.ServiceModel.DomainServices.Client;
using MyERP.DataAccess;


namespace MyERP.Repositories
{
    [Export]
    public class OrganizationRepository : RepositoryBase
    {
        public void GetOrganizations(Action<IEnumerable<Organization>> callback)
        {
            this.LoadQuery<Organization>(this.Context.GetOrganizationsQuery(), callback);
        }

        public void GetOrganizationsByClientId(Guid clientId, Action<IEnumerable<Organization>> callback)
        {
            if (clientId == Guid.Empty)
            {
                callback(Enumerable.Empty<Organization>());
                return;
            }
            this.LoadQuery(this.Context.GetOrganizationsByClientIdQuery(clientId), callback);
        }
    }
}
