using System.Web.Mvc;

namespace MyERP.Web.Areas.SalesPrice
{
    public class SalesPriceAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SalesPrice";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SalesPrice_default",
                "SalesPrice/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}