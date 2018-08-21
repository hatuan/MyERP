using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using log4net;
using MyERP.Web.Models;
using MyERP.Web.Others;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyERP.Web
{
    public partial class SalesPriceRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(SalesPriceRepository));

        public GetPriceDTO GetPriceOfItem(long OrgId, long BusPartId, DateTime date, long ItemId, long UomId, Decimal Qty)
        {
            string URL = Functions.GetMyERPBaseUrl("/SalesPrices/GetPriceOfItem");

            using (var httpClient = new HttpClient())
            {                                                                           
                httpClient.BaseAddress = new Uri(URL);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string _qty = String.Format(new System.Globalization.CultureInfo("en-US"), "{0:0.00}", Qty);
                string urlParameters = $"?org_id={OrgId:D}&bus_part_id={BusPartId:D}&date={date:yyyy/MM/dd}&item_id={ItemId:D}&uom_id={UomId:D}&qty={_qty}";

                log.Info($"URL AbsoluteUri = {httpClient.BaseAddress.AbsoluteUri}");
                log.Info($"URL Parameters = {urlParameters}");

                try
                {
                    var response = httpClient.GetAsync(urlParameters);
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return result.Content.ReadAsAsync<GetPriceDTO>().Result;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    log.Error("Failed", e);
                    throw;
                }
            }
        }

        public List<GetPriceDTO> GetPriceOfItemList(long OrgId, long BusPartId, DateTime date, List<GetPriceDTO> itemListRequest)
        {
            string URL = Functions.GetMyERPBaseUrl("/SalesPrices/GetPriceOfItemList");

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URL);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string urlParameters = $"?org_id={OrgId:D}&bus_part_id={BusPartId:D}&date={date:yyyy/MM/dd}";
                var content = new StringContent(JsonConvert.SerializeObject(itemListRequest), Encoding.UTF8,"application/json");

                log.Info($"URL AbsoluteUri = {httpClient.BaseAddress.AbsoluteUri}");
                log.Info($"URL Parameters = {urlParameters}");
                try
                {
                    var response = httpClient.PostAsync(urlParameters, content);
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return result.Content.ReadAsAsync<List<GetPriceDTO>>().Result;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    log.Error("Failed", e);
                    throw;
                }
            }
        }
    }
}