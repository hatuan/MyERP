using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MyERP.Web.Helpers;
using MyERP.Web.Models;
using Telerik.OpenAccess;

namespace MyERP.Web.Controllers
{
    [Authorize]
    public abstract partial class OpenAccessBaseController<TEntity, TContext> : Controller
        where TContext : OpenAccessContext, new()
    {
        protected IOpenAccessBaseRepository<TEntity, TContext> repository;

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureUIName = null;
            string cultureName = null;
            
            if (Session["Preference"] != null)
            {
                var preference = Session["Preference"] as PreferenceViewModel;
                cultureUIName = preference.CultureUI;
                cultureName = preference.Organization.CultureId;
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
    }
}