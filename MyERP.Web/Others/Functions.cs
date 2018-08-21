using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyERP.Web.Others
{
    public class Functions
    {
        public static string GetBaseUrl()
        {
            var request = HttpContext.Current.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath; //return "/" or "/xxx"

            if (appUrl == "/")
                appUrl = "";

            var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return baseUrl;
        }

        public static bool IsAbsoluteUrl(string url)
        {
            Uri result;
            return Uri.TryCreate(url, UriKind.Absolute, out result);
        }

        public static string GetMyERPBaseUrl(string path = "")
        {
            if (!String.IsNullOrEmpty(path) && path[0] != '/')
            {
                path = "/" + path;
            }

            if (IsAbsoluteUrl(AppSettings.MyERPBaseUrl)) //example http://localhost:8080
            {
                return AppSettings.MyERPBaseUrl + (String.IsNullOrEmpty(path) ? "" : path);
            }
            else //is Relative example ~/MyERPBase.dll
            {
                string myERPBaseUrl = AppSettings.MyERPBaseUrl.StartsWith("~/")
                    ? AppSettings.MyERPBaseUrl.TrimStart(new [] {'~'})
                    : AppSettings.MyERPBaseUrl;

                var appUrl = HttpRuntime.AppDomainAppVirtualPath; //return "/" or "/xxx"

                if (appUrl == "/")
                    appUrl = "";

                return GetBaseUrl() + myERPBaseUrl + (String.IsNullOrEmpty(path) ? "" : path);
            }
        }
    }
}