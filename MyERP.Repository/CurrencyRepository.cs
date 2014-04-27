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

            this.LoadQuery(query, callback);
        }

        public void GetCurrenciesByLookupValue(string lookupValue, Action<IEnumerable<Currency>> callback)
        {
            if (lookupValue == null)
            {
                callback(Enumerable.Empty<Currency>());
                return;
            }
                
            EntityQuery<Currency> query =
                this.Context.GetCurrenciesQuery().Where(u => u.Code.ToLower().StartsWith(lookupValue.ToLower())).OrderBy(c => c.Code).Take(500);

            this.LoadQuery(query, callback);
        }

        public void GetCurrenciesByClientAndOrg(Client client, Organization organization, Action<IEnumerable<Currency>> callback)
        {
            if (client == null || organization == null)
            {
                callback(Enumerable.Empty<Currency>());
                return;
            }

            EntityQuery<Currency> query = this.Context.GetCurrenciesQuery().Where(c => c.ClientId == client.Id && c.OrganizationId == organization.Id).OrderBy(c => c.Code);
            if (organization.Code != "*")
            {
                Organization defaultOrganization =
                    this.Context.Organizations.FirstOrDefault(c => c.ClientId == client.Id && c.Code == "*");

                query = this.Context.GetCurrenciesQuery()
                        .Where(
                            c =>
                                c.ClientId == client.Id &&
                                (c.OrganizationId == organization.Id || c.OrganizationId == defaultOrganization.Id)).OrderBy(c => c.Code);
            }

            this.LoadQuery(query, callback);
        }
    }
}
