using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using MyERP.DataAccess;

namespace MyERP.Repositories
{
    [Export]
    public class CurrencyRepository : RepositoryBase
    {
        public void GetCurrencyById(Guid id, Action<Currency> callback)
        {
            EntityQuery<Currency> query = this.Context.GetCurrenciesQuery().Where(c => c.Id == id);

            this.LoadQuery<Currency>(query, callback);
        }

        public void GetCurrenciesByClientAndOrg(Client client, Organization organization, Action<IEnumerable<Currency>> callback)
        {
            if (client == null || organization == null)
            {
                callback(Enumerable.Empty<Currency>());
                return;
            }

            EntityQuery<Currency> query = this.Context.GetCurrenciesQuery().Where(c => c.ClientId == client.Id && c.OrganizationId == organization.Id);
            if (organization.Code != "*")
            {
                Organization defaultOrganization =
                    this.Context.Organizations.FirstOrDefault(c => c.ClientId == client.Id && c.Code == "*");

                query = this.Context.GetCurrenciesQuery()
                        .Where(
                            c =>
                                c.ClientId == client.Id &&
                                (c.OrganizationId == organization.Id || c.OrganizationId == defaultOrganization.Id));
            }

            this.LoadQuery<Currency>(query, callback);
        }
    }
}
