using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static string GetEHoaDonUrl(string path = "")
        {
            if (!String.IsNullOrEmpty(path) && path[0] != '/')
            {
                path = "/" + path;
            }

            if (IsAbsoluteUrl(AppSettings.EHoaDonUrl)) //example http://localhost:8080
            {
                return AppSettings.EHoaDonUrl + (String.IsNullOrEmpty(path) ? "" : path);
            }
            else //is Relative example ~/MyERPBase.dll
            {
                string myERPBaseUrl = AppSettings.EHoaDonUrl.StartsWith("~/")
                    ? AppSettings.EHoaDonUrl.TrimStart(new[] { '~' })
                    : AppSettings.EHoaDonUrl;

                var appUrl = HttpRuntime.AppDomainAppVirtualPath; //return "/" or "/xxx"

                if (appUrl == "/")
                    appUrl = "";

                return GetBaseUrl() + myERPBaseUrl + (String.IsNullOrEmpty(path) ? "" : path);
            }
        }

        /// <summary>
        /// https://stackoverflow.com/questions/730268/unique-random-string-generation
        /// </summary>
        /// <param name="length"></param>
        /// <param name="allowedChars"></param>
        /// <returns></returns>
        public static string RandomString(int length, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length", "length cannot be less than zero.");
            if (string.IsNullOrEmpty(allowedChars)) throw new ArgumentException("allowedChars may not be empty.");

            const int byteSize = 0x100;
            var allowedCharSet = new HashSet<char>(allowedChars).ToArray();
            if (byteSize < allowedCharSet.Length) throw new ArgumentException(String.Format("allowedChars may contain no more than {0} characters.", byteSize));

            // Guid.NewGuid and System.Random are not particularly random. By using a
            // cryptographically-secure random number generator, the caller is always
            // protected, regardless of use.
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                var result = new StringBuilder();
                var buf = new byte[128];
                while (result.Length < length)
                {
                    rng.GetBytes(buf);
                    for (var i = 0; i < buf.Length && result.Length < length; ++i)
                    {
                        // Divide the byte into allowedCharSet-sized groups. If the
                        // random value falls into the last group and the last group is
                        // too small to choose from the entire allowedCharSet, ignore
                        // the value in order to avoid biasing the result.
                        var outOfRangeStart = byteSize - (byteSize % allowedCharSet.Length);
                        if (outOfRangeStart <= buf[i]) continue;
                        result.Append(allowedCharSet[buf[i] % allowedCharSet.Length]);
                    }
                }
                return result.ToString();
            }
        }

        /// <summary>
        /// Use GetRandomFileName() to create random string.
        /// </summary>
        /// <returns>Random string length 10 chars</returns>
        public static string RandomString()
        {
            return System.IO.Path.GetRandomFileName().Replace(".", "").Substring(0, 10);
        }
    }
}