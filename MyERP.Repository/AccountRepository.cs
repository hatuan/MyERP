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
                                              select account;
        }

        public void GetAccounts(Action<IEnumerable<Account>> callback)
        {
            DataServiceQuery<Account> query = (DataServiceQuery<Account>)from account in Container.Accounts
                                                                             .Expand(c => c.Currency)
                                                                             .Expand(c => c.ParentAccount)
                                                                             .Expand(c => c.RecCreatedByUser)
                                                                             .Expand(c => c.RecModifiedByUser)
                                                                       select account;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<Account>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }

        public void GetAccountsByLookupValue(string lookupValue, Action<IEnumerable<Account>> callback)
        {
            DataServiceQuery<Account> query = (DataServiceQuery<Account>)from account in Container.Accounts
                                                                         where account.Code == lookupValue
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
