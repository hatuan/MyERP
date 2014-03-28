using System;
using System.ComponentModel.Composition;
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
    }
}
