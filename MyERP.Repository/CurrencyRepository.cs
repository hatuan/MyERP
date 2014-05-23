using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace MyERP.Repositories
{
    [Export]
    public class CurrencyRepository : RepositoryBase
    {
        public void GetCurrencyById(Guid id)
        {

        }

        public void GetCurrenciesByLookupValue(string lookupValue)
        {
        }
    }
}
