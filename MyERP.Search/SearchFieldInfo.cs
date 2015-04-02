using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyERP.DataAccess;
using MyERP.Parse;

namespace MyERP.Search
{
    public class SearchFieldInfo
    {
        public AccountSearchField AccountSearchField { get; set; }
        public CurrencySearchField CurrencySearchField { get; set; }
        public String SearchFieldValue { get; set; }
    }
}
