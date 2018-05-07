using System.Web.Mvc;

namespace MyERP.Web.Areas.UOM
{
    public class UOMAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UOM";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "UOM_default",
                "UOM/{controller}/{action}/{id}",
                new { controller="Index", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}