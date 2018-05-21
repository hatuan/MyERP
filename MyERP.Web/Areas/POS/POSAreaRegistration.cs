using System.Web.Mvc;

namespace MyERP.Web.Areas.POS
{
    public class POSAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "POS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "POS_default",
                "POS/{controller}/{action}/{id}",
                new { controller = "Index", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}