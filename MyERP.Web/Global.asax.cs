using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace MyERP.Web
{
    public partial class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configuration.MessageHandlers.Add(new MethodOverrideHandler());
            WebApiOdataConfig.Register(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.Filters.Add(new MembershipHttpAuthorizeAttribute());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            Telerik.OpenAccess.ServiceHost.ServiceHostManager.StartProfilerService(15555); 
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

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

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
                    && !Context.Request.Url.AbsoluteUri.ToLower().Contains("/sl.aspx"))
                {
                    // You've handled the error, so clear it. Leaving the server in an error state can cause unintended side effects as the server continues its attempts to handle the error.
                    Server.ClearError();

                    // Possible that a partially rendered page has already been written to response buffer before encountering error, so clear it.
                    Context.Response.Clear();

                    // Finally redirect, transfer, or render a error view
                    Context.Response.Redirect(@"~/User/Preference");
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