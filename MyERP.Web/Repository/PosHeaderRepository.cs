﻿using System;
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
    public partial class PosHeaderRepository
    {
        public Paging<PosHeader> Paging(StoreRequestParameters parameters)
        {
            return Paging(parameters.Start, parameters.Limit, parameters.SimpleSort, parameters.SimpleSortDirection, null);
        }

        public Paging<PosHeader> Paging(int start, int limit, string sort, SortDirection dir, string filter)
        {
            var entities = Get(includePaths: new String[] { "Organization", "Client", "RecCreatedByUser", "RecModifiedByUser", "Location", "SellToCustomer" });

            if (!string.IsNullOrEmpty(filter) && filter != "*")
            {
                entities = entities.Where(c => c.DocumentNo.ToLower().StartsWith(filter.ToLower()));
            }

            if (!string.IsNullOrEmpty(sort))
                entities = dir == SortDirection.ASC ? entities.OrderBy(sort) : entities.OrderBy(sort + " DESC");
            else
                entities = entities.OrderBy("Code");

            var count = entities.ToList().Count;
            var ranges = (start < 0 || limit <= 0) ? entities.ToList() : entities.Skip(start).Take(limit).ToList();

            return new Paging<PosHeader>(ranges, count);
        }
    }

}