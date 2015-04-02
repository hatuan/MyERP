using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyERP.Web.Models
{
    public class SearchViewModel
    {
        public SearchViewModel()
        {
            Searches = new List<MyERP.Search.SearchFieldInfo>();
        }

        public List<MyERP.Search.SearchFieldInfo> Searches { get; set; }
    }

}