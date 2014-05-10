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

    }
}
