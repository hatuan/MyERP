using System.Web.Mvc;

namespace MyERP.Web.Areas.BusinessPartner
{
    public class BusinessPartnerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BusinessPartner";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BusinessPartner_default",
                "BusinessPartner/{controller}/{action}/{id}",
                new { controller="Index", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}