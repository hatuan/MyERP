using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.UI;

namespace MyERP.Web
{
    public class MyERPVersion
    {
        public static Version Version = typeof(MyERP.Web.Global).Assembly.GetName().Version;

        private static string rev = (Version.Revision == 0) ? "" : ("." + Version.Revision);
        private static string bld = (Version.Build == 0) ? "" : ("." + Version.Build + rev);

        public static string Major = Version.Major + "." + Version.Minor + bld;
        public static string WithBuild = Version.Major + "." + Version.Minor + "." + Version.Build;
        public static string Full = Version.ToString();
    }

    public partial class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            this.Application["Ext.Net.LicenseKey"] = "aXJEZXZlbG9wZXJzLmNvbSw0LDIwNTAtMDEtMDE=";
            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHm4lqN+V3/fvJECXRrqdoEPZqYyFXh3g3K9oCDFvgzMl4c9KudQQwMJ6nO6w7rHz59BhwYgDE0QzKtjY2WxEejTNewbNDXY492M2mDsK1Hb4t6MoFYGbSoID0gow3VC5cFhvcOKVoagiHq6/4iqFc3RS7nZQBp95+WB6N1fR//H7OBlvfuBKldvC1pJh6pTW/7HRdOclErt/EGwivx9SpuDNabWWBfIZJBdJsvKjpoIsDQGibWk8Y8F9V1mCLf88FurWwEZ9WzXePbJn+wfabHM+a7pqDAXhsaW33UEW6vQ3kgLrVjbcHWdhtYbp5j6ZeIMLBCW2LXiCZpzy3N3XqjlroV/s7KRZGeZMvRrLWhcM8YJ6sBTMUyQrF/Fk3d5f0WbAf7+opIA5rhxY+qgwWcE42S+HOOcMgb2IWtj5ycC/GXZ4o9qtk2WWJzCC+ygckXK7iI5pzhzScGmLCBrFnjyE5EP65FViVDSCcNl6hUFw7wwRtcQq5pnOu6wHRXsSpwNPufWaRqE4gd7hbrQoPqki4BLOYgGOQjZ3kJdc7MG47nVT62z1ScLsjH73q4yhABt8h1wmJl0LanKnE6EGkvZPCrDBBf0sZp12sJrxK8FGsPUKrBNZ5f4VuYkdzWS1ed2m5MZNHkDDd3LncYkQnLPh/MYAsnc2ud715njwiM62xIWYk9lIrmCWJU3JVcexRDS3/l7Po9UU5gx2xJKUW1tWOXKQ9GqQZYtn/rl804VMC1/tWr4X2XU1otulny5P8YkZ7BTG6zmkcW6raROxv7xkSUwE0LK2FmIpeBr29Zxn0QUYBtC09J+wVD5y00f/1jMU+k1jQmi1n2tpWgy6CxAHPPrQFhk0FsGXEDg82IELCKncbqkfqgT0QyV262YL2uxrcbcJ1Wrzf4llEX90hMa3oZK5wdQLrCBkXIlXverhGL3I09fR6lcXDMj8A3vrQrhr4bwYcWTH0hyJCPVLYIVxAFLwgV8wk700QOo3z32sSWKnyMHVx3brFB8I7rOPaW2Sc8rBxc1E9EvNcqiTwRd9QA3lIdR2Hpc4jyn5dx8PT6GTNGXNKhoTZDLrGMtYqXw4rVOXfkE8+opF4+/H602ockCI/IY7C65+sxooNgSg+9LpzImUt6GdtrvF8HrvJ0rUW6ZiAmGaQmqdrHfwC3K+QKU4UEWuLU1GPG+PKMrYEbtT/Hei7NPA5sOqHqbzaMsW7zj+enlhuEUeMdlxqfQs1QtTERrzX2HXv/JZ43rASH4ycuGftLR2v3AOHhtBCoYOCszhOiHYGmH0I9lwi8HDRTXjkuoRU1Zxmz9rSIQy35/aypV339OS7p4VydO5LibEiwugzaNHXCZalEPShhcWzTAq6+uCb+jA9ob+Za4yICRdIjgot/E5ZQNZl2VEhFmWR7pYSB7MB24z0ysVf3igAc50/3Lr4d7mQ7SgmtKFoejGOjvb75YOq/pEJGxCo1xIS+jhZklyLuiwmtyDe7Xmpn33fip22qx2iF7FYW71AyuT3tTPn2a7Jc2wXlPCAxB6dqx0eeX4fWA3+RIosUTxTyA7a/SM95pwN9FKYFPZ8TcTqDIq0Ntc57IdX5u1To=";

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configuration.MessageHandlers.Add(new MethodOverrideHandler());
            WebApiOdataConfig.Register(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.Filters.Add(new MembershipHttpAuthorizeAttribute());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
        }

        /// <summary>
        /// http://stackoverflow.com/questions/9594229/accessing-session-using-asp-net-web-api
        /// </summary>
        protected void Application_PostAuthorizeRequest()
        {
            if (IsWebApiOdataRequest())
            {
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            }
        }

        private bool IsWebApiOdataRequest()
        {
            return HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.StartsWith(WebApiOdataConfig.UrlPrefixRelative);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
#if DEBUG
            // Enables debugging code output by default if the project is built in debug configuration.
            if (Session["Ext.Net.ScriptMode"] == null)
            {
                Session["Ext.Net.ScriptMode"] = ScriptMode.Debug;
            }

            if (Session["Ext.Net.SourceFormatting"] == null)
            {
                Session["Ext.Net.SourceFormatting"] = true;
            }
#endif // DEBUG
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            // Skip authenticating all ext.axd embedded resources (.js, .css, images)
            if (HttpContext.Current.Request.FilePath.EndsWith("/ext.axd"))
            {
                HttpContext.Current.SkipAuthorization = true;
            }
        }

        public void Application_PreRequestHandlerExecute(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;

            // use an if statement to make sure the request is not for a static file (js/css/html etc.)
            if (context != null && context.Session != null)
            {
                if (context.Session["Preference"] == null 
                    && HttpContext.Current.User.Identity.IsAuthenticated
                    && !Context.Request.Url.AbsoluteUri.ToLower().Contains("/user/preference")
                    && !Context.Request.Url.AbsoluteUri.ToLower().Contains("/user/login"))
                {
                    // You've handled the error, so clear it. Leaving the server in an error state can cause unintended side effects as the server continues its attempts to handle the error.
                    Server.ClearError();

                    // Possible that a partially rendered page has already been written to response buffer before encountering error, so clear it.
                    Context.Response.Clear();

                    // Finally redirect, transfer, or render a error view
                    Context.Response.Redirect(@"/User/Preference");
                }

            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}