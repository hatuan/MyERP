using System;
using System.Net;
using System.Threading;

namespace MyERP
{
    /// <summary>
    /// A class that provides ability to download resources synchronously. Use the download methods in a background thread, 
    /// so that UI thread will not sleep.
    /// </summary>
    public static class SynchronousDownloader
    {
        public static object DownloadFile(Uri uri)
        {
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            object objectToReturn = null;

            WebClient wc = new WebClient();
            wc.OpenReadCompleted += (s, e) =>
            {
                objectToReturn = e.Result;
                autoResetEvent.Set();
            };

            wc.OpenReadAsync(uri);
            autoResetEvent.WaitOne();

            return objectToReturn;
        }

        public static string DownloadString(Uri uri)
        {
            AutoResetEvent are = new AutoResetEvent(false);
            string stringToReturn = string.Empty;

            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (s, e) =>
            {
                stringToReturn = e.Result;
                are.Set();
            };

            wc.DownloadStringAsync(uri);
            are.WaitOne();

            return stringToReturn;
        }
    }
}
