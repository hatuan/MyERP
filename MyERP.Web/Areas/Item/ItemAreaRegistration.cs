using System.Web.Mvc;

namespace MyERP.Web.Areas.Item
{
    public class ItemAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Item";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Item_default",
                "Item/{controller}/{action}/{id}",
                new { controller  = "Index", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}