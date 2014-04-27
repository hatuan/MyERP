using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using System.ServiceModel.DomainServices.Client;
using MyERP.DataAccess;


namespace MyERP.Repositories
{
    [Export]
    public class AccountRepository : RepositoryBase
    {
        public void GetAccounts(Action<IEnumerable<Account>> callback)
        {
            this.LoadQuery(this.Context.GetAccountsQuery().OrderBy(c => c.Code), callback);
        }

        public void GetAccountsByLookupValue(string lookupValue, Action<IEnumerable<Account>> callback)
        {
            if (lookupValue == null)
            {
                callback(Enumerable.Empty<Account>());
                return;
            }

            EntityQuery<Account> query =
                this.Context.GetAccountsQuery().Where(u => u.Code.ToLower().StartsWith(lookupValue.ToLower())).OrderBy(c => c.Code).Take(500);

            this.LoadQuery(query, callback);
        }
    }
}
