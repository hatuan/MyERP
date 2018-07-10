using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using MyERP.Web.Models;
using MyERP.Web.Others;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyERP.Web
{
    public partial class SalesPriceRepository
    {
        public GetPriceDTO GetPriceOfItem(long OrgId, long BusPartId, DateTime date, long ItemId, long UomId, Decimal Qty)
        {
            string URL = AppSettings.BaseUrl + "/SalesPrices/GetPriceOfItem";

            using (var httpClient = new HttpClient())
            {                                                                           
                httpClient.BaseAddress = new Uri(URL);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string urlParameters = $"?org_id={OrgId:D}&bus_part_id={BusPartId:D}&date={date:yyyy/MM/dd}&item_id={ItemId:D}&uom_id={UomId:D}&qty={Qty}";

                var response = httpClient.GetAsync(urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<GetPriceDTO>().Result;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<GetPriceDTO> GetPriceOfItemList(long OrgId, long BusPartId, DateTime date, List<GetPriceDTO> itemListRequest)
        {
            string URL = AppSettings.BaseUrl + "/SalesPrices/GetPriceOfItemList";

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URL);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string urlParameters = $"?org_id={OrgId:D}&bus_part_id={BusPartId:D}&date={date:yyyy/MM/dd}";
                var content = new StringContent(JsonConvert.SerializeObject(itemListRequest), Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync(urlParameters, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<GetPriceDTO>>().Result;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}