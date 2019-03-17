using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Web;
using Ext.Net;
using MyERP.DataAccess;

namespace MyERP.Web
{
    public partial class EInvFormReleaseRepository
    {
        public Paging<EInvFormRelease> Paging(StoreRequestParameters parameters)
        {
            return Paging(parameters.Start, parameters.Limit, parameters.SimpleSort, parameters.SimpleSortDirection);
        }

        public Paging<EInvFormRelease> Paging(int start, int limit, string sort, SortDirection dir)
        {
            var entities = Get(includePaths: new String[] { "Organization", "Client", "RecCreatedByUser", "RecModifiedByUser", "EInvFormType" });

            if (!string.IsNullOrEmpty(sort))
                entities = dir == SortDirection.ASC ? entities.OrderBy(sort) : entities.OrderBy(sort + " DESC");
            else
                entities = entities.OrderBy("ReleaseDate");

            var count = entities.ToList().Count;
            var ranges = (start < 0 || limit <= 0) ? entities.ToList() : entities.Skip(start).Take(limit).ToList();

            return new Paging<EInvFormRelease>(ranges, count);
        }
    }

    public partial class EInvFormTypeRepository 
    {
        public Paging<EInvFormType> Paging(StoreRequestParameters parameters)
        {
            return Paging(parameters.Start, parameters.Limit, parameters.SimpleSort, parameters.SimpleSortDirection);
        }

        public Paging<EInvFormType> Paging(int start, int limit, string sort, SortDirection dir)
        {
            var entities = Get(includePaths: new String[] { "Organization", "Client", "RecCreatedByUser", "RecModifiedByUser" });

            if (!string.IsNullOrEmpty(sort))
                entities = dir == SortDirection.ASC ? entities.OrderBy(sort) : entities.OrderBy(sort + " DESC");
            else
                entities = entities.OrderBy("RecCreatedAt");

            var count = entities.ToList().Count;
            var ranges = (start < 0 || limit <= 0) ? entities.ToList() : entities.Skip(start).Take(limit).ToList();

            return new Paging<EInvFormType>(ranges, count);
        }

        public decimal GetMaxReleaseOfFormType(long formTypeId, long formReleaseId)
        {
            try
            {
                var formType = Get(includePaths: new String[] {"EInvFormReleases"}).First(x => x.Id == formTypeId);
                var maxFormReleaseTo = formType.EInvFormReleases.Where(x => x.Id != formReleaseId).Max(x => x.ReleaseTo);
                return maxFormReleaseTo;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }

    public partial class EInvoiceHeaderRepository 
    {
        public Paging<EInvoiceHeader> Paging(StoreRequestParameters parameters)
        {
            return Paging(parameters.Start, parameters.Limit, parameters.SimpleSort, parameters.SimpleSortDirection);
        }

        public Paging<EInvoiceHeader> Paging(int start, int limit, string sort, SortDirection dir)
        {
            var entities = Get(includePaths: new String[] { "Organization", "Client", "RecCreatedByUser", "RecModifiedByUser", "Buyer", "Currency" });

            if (!string.IsNullOrEmpty(sort))
                entities = dir == SortDirection.ASC ? entities.OrderBy(sort) : entities.OrderBy(sort + " DESC");
            else
                entities = entities.OrderBy("InvoiceIssuedDate");

            var count = entities.ToList().Count;
            var ranges = (start < 0 || limit <= 0) ? entities.ToList() : entities.Skip(start).Take(limit).ToList();

            return new Paging<EInvoiceHeader>(ranges, count);
        }
    }

    public partial class EInvoiceLineRepository 
    {

    }

    public partial class EInvoiceSignedRepository 
    {
        public Paging<EInvoiceSigned> Paging(StoreRequestParameters parameters)
        {
            return Paging(parameters.Start, parameters.Limit, parameters.SimpleSort, parameters.SimpleSortDirection);
        }

        public Paging<EInvoiceSigned> Paging(int start, int limit, string sort, SortDirection dir)
        {
            var entities = Get(includePaths: new String[] { "Organization", "Client", "RecCreatedByUser", "RecModifiedByUser" });

            if (!string.IsNullOrEmpty(sort))
                entities = dir == SortDirection.ASC ? entities.OrderBy(sort) : entities.OrderBy(sort + " DESC");
            else
                entities = entities.OrderBy("InvoiceIssuedDate");

            var count = entities.ToList().Count;
            var ranges = (start < 0 || limit <= 0) ? entities.ToList() : entities.Skip(start).Take(limit).ToList();

            return new Paging<EInvoiceSigned>(ranges, count);
        }
    }
}