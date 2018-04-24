using System.Threading;
using System.Web.Mvc;
using MyERP.Web.Helpers;
using MyERP.Web.Models;

namespace MyERP.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        /*
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureUIName = null;
            string cultureName = null;

            if (Session["Preference"] != null)
            {
                var preference = Session["Preference"] as PreferenceViewModel;
                cultureUIName = preference.CultureUI;
                cultureName = preference.Organization.Client.CultureId;
            }
            else
            {
                cultureName = cultureUIName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ?
                        Request.UserLanguages[0] :  // obtain it from HTTP header AcceptLanguages
                        null;
            }

            // Validate culture name
            cultureUIName = CultureHelper.GetImplementedCulture(cultureUIName); // This is safe
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cultureUIName);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);

            return base.BeginExecuteCore(callback, state);
        }
        */

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            string cultureUIName = null;
            string cultureName = null;

            if (requestContext.HttpContext.Session != null)
            {
                if (requestContext.HttpContext.Session["Preference"] != null)
                {
                    var preference = requestContext.HttpContext.Session["Preference"] as PreferenceViewModel;
                    cultureUIName = preference.CultureUI;
                    cultureName = preference.Organization.Client.CultureId;
                }
                else
                {
                    cultureName = cultureUIName = requestContext.HttpContext.Request.UserLanguages != null && requestContext.HttpContext.Request.UserLanguages.Length > 0 ?
                        requestContext.HttpContext.Request.UserLanguages[0] :  // obtain it from HTTP header AcceptLanguages
                        null;
                }
            }
            else
            {
                cultureName = cultureUIName = requestContext.HttpContext.Request.UserLanguages != null && requestContext.HttpContext.Request.UserLanguages.Length > 0 ?
                        requestContext.HttpContext.Request.UserLanguages[0] :  // obtain it from HTTP header AcceptLanguages
                        null;
            }

            // Validate culture name
            cultureUIName = CultureHelper.GetImplementedCulture(cultureUIName); // This is safe
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cultureUIName);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            
            base.Initialize(requestContext);
        }
    }
}