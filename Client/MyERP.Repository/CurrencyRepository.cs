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
    public class CurrencyRepository : RepositoryBase
    {
        public void GetCurrencies(Action<IEnumerable<Currency>> callback)
        {
            DataServiceQuery<Currency> query = (DataServiceQuery<Currency>)from currency in Container.Currencies
                                                                             .Expand(c => c.RecCreatedByUser)
                                                                             .Expand(c => c.RecModifiedByUser)
                                                                           where currency.ClientId.Equals(SessionManager.Session["ClientId"])
                                                                           orderby currency.Code
                                                                           select currency;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<Currency>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }

        public void GetCurrencyById(Guid id, Action<Currency> callback)
        {
            DataServiceQuery<Currency> query = (DataServiceQuery<Currency>)from currency in Container.Currencies
                                                                           where currency.Id.Equals(id)
                                                                           select currency;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<Currency>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response.FirstOrDefault()));
            }, query);
        }

        public void GetCurrenciesByLookupValue(string lookupValue, Action<IEnumerable<Currency>> callback)
        {
            DataServiceQuery<Currency> query = (DataServiceQuery<Currency>)from currency in Container.Currencies
                                                                           orderby currency.Code
                                                                           where currency.ClientId.Equals(SessionManager.Session["ClientId"])
                                                                            && currency.Code.StartsWith(lookupValue)
                                                                           select currency;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<Currency>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }
    }
}
