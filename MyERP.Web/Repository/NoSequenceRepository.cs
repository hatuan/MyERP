using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Ext.Net;
using MyERP.DataAccess;
using MyERP.Web.Models;
using MyERP.Web.Others;

namespace MyERP.Web
{
    public partial class NoSequenceRepository
    {
        public Paging<NoSequence> Paging(StoreRequestParameters parameters)
        {
            return Paging(parameters.Start, parameters.Limit, parameters.SimpleSort, parameters.SimpleSortDirection, null);
        }

        public Paging<NoSequence> Paging(int start, int limit, string sort, SortDirection dir, string filter)
        {
            var entities = Get(includePaths: new String[] { "Organization", "Client", "RecCreatedByUser", "RecModifiedByUser" });

            if (!string.IsNullOrEmpty(filter) && filter != "*")
            {
                entities = entities.Where(c => c.Description.ToLower().StartsWith(filter.ToLower()) || c.Code.ToLower().StartsWith(filter.ToLower()));
            }

            if (!string.IsNullOrEmpty(sort))
                entities = dir == SortDirection.ASC ? entities.OrderBy(sort) : entities.OrderBy(sort + " DESC");
            else
                entities = entities.OrderBy("Code");

            var count = entities.ToList().Count;
            var ranges = (start < 0 || limit <= 0) ? entities.ToList() : entities.Skip(start).Take(limit).ToList();

            return new Paging<NoSequence>(ranges, count);
        }

        public String GetNextNo(long seqId, DateTime date)
        {
            string URL = AppSettings.BaseUrl + "/NoSequences/GetNextNo";

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URL);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string urlParameters = $"?id={seqId:D}&date={date:yyyy/MM/dd}";

                var response = httpClient.GetAsync(urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return null;
                }
            }
        }
    }

}