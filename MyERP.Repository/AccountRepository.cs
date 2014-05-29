using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.ComponentModel.Composition;
using MyERP.Infrastructure;
using MyERP.Repository.MyERPService;


namespace MyERP.Repositories
{
    [Export]
    public class AccountRepository : RepositoryBase
    {
        public DataServiceQuery<Account> GetAccountsQuery()
        {
            return (DataServiceQuery<Account>)from account in Container.Accounts
                                              .Expand(c => c.Currency)
                                              .Expand(c => c.ParentAccount)
                                              .Expand(c => c.RecCreatedByUser)
                                              .Expand(c => c.RecModifiedByUser)
                                              orderby account.Code
                                              select account;
        }

        public void GetAccounts(Action<IEnumerable<Account>> callback)
        {
            DataServiceQuery<Account> query = (DataServiceQuery<Account>)from account in Container.Accounts
                                                                             .Expand(c => c.Currency)
                                                                             .Expand(c => c.ParentAccount)
                                                                             .Expand(c => c.RecCreatedByUser)
                                                                             .Expand(c => c.RecModifiedByUser)
                                                                             orderby account.Code
                                                                             select account;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<Account>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }

        public void GetCurrencyById(Guid id, Action<Account> callback)
        {
            DataServiceQuery<Account> query = (DataServiceQuery<Account>)from account in Container.Accounts
                                                                         where account.Id.Equals(id)
                                                                         select account;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<Account>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response.FirstOrDefault()));
            }, query);
        }

        public void GetAccountsByLookupValue(string lookupValue, Action<IEnumerable<Account>> callback)
        {
            DataServiceQuery<Account> query = (DataServiceQuery<Account>)from account in Container.Accounts
                                                                         orderby account.Code
                                                                         where account.Code.StartsWith(lookupValue)
                                                                         select account;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<Account>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }
    }
}
