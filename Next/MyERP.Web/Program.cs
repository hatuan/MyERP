using MyERP.Web;
using System;
using Wisej.Web;

namespace MyERP.Web
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if(e.Exception.Message=="GoToMainPage")
            {
                Application.MainPage = new MainPage();
            }
        }

        //
        // You can use the entry method below
        // to receive the parameters from the URL in the args collection.
        //
        //static void Main(NameValueCollection args)
        //{
        //}
    }
}