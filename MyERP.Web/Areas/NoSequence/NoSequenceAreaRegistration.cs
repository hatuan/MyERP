using System.Web.Mvc;

namespace MyERP.Web.Areas.NoSequence
{
    public class NoSequenceAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NoSequence";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NoSequence_default",
                "NoSequence/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}