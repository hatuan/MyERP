using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Ext.Net;
using MyERP.DataAccess;

namespace MyERP.Web
{
    public partial class UomRepository 
    {
        public Paging<Uom> UomsPaging(StoreRequestParameters parameters)
        {
            return UomsPaging(parameters.Start, parameters.Limit, parameters.SimpleSort, parameters.SimpleSortDirection, null);
        }

        public  Paging<Uom> UomsPaging(int start, int limit, string sort, SortDirection dir, string filter)
        {
            var uoms = GetAll();

            if (!string.IsNullOrEmpty(filter) && filter != "*")
            {
                uoms.Where(c => c.Description.ToLower().StartsWith(filter.ToLower()) || c.Code.ToLower().StartsWith(filter.ToLower()));
            }

            if (!string.IsNullOrEmpty(sort))
                uoms = dir == SortDirection.ASC ? uoms.OrderBy(sort) : uoms.OrderBy(sort + " DESC");
            else
                uoms = uoms.OrderBy("Code");

            var count = uoms.ToList().Count;
            var rangeUoms = (start < 0 || limit < 0) ? uoms.ToList() : uoms.Skip(start).Take(limit).ToList();

            return new Paging<Uom>(rangeUoms, count);
        }
    }

}