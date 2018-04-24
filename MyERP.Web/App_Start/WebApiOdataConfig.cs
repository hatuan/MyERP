using System.Web.Http;
using System.Web.Http.OData.Builder;
using MyERP.DataAccess;

namespace MyERP.Web
{
    public static class WebApiOdataConfig
    {
        public static string UrlPrefix { get { return "odata"; } }
        public static string UrlPrefixRelative { get { return "~/odata"; } }

        public static void Register(HttpConfiguration config)
        {
            //var apiRoute =  config.Routes.MapHttpRoute(name: "DefaultApi",
            //                               routeTemplate: "api/{controller}/{id}",
            //                               defaults: new { id = RouteParameter.Optional });

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Client>("Clients");
            builder.EntitySet<Currency>("Currencies");
            builder.EntitySet<Organization>("Organizations");
            builder.EntitySet<Role>("Roles");
            builder.EntitySet<User>("Users");
            builder.EntitySet<UserInRole>("UserInRoles");
            
            //var tutorsEntitySet = builder.EntitySet<Tutor>("Tutors");
            //tutorsEntitySet.EntityType.Ignore(s => s.UserName);
            //tutorsEntitySet.EntityType.Ignore(s => s.Password);

            //Declare the Action in the Entity Data Model
            //ActionConfiguration sequenceNextVal = builder.Entity<NumberSequence>().Action("SequenceNextVal");
            //sequenceNextVal.Parameter<Guid>("key");
            //sequenceNextVal.Returns<int>();

            //ActionConfiguration allOrganization = builder.Entity<Organization>().Action("AllOrganization");
            //allOrganization.Parameter<Guid>("key");
            //allOrganization.ReturnsFromEntitySet<Organization>("Organizations");

            //ActionConfiguration generalJournalSetupOfOrganization = builder.Entity<GeneralJournalSetup>().Action("GetGeneralJournalSetupOfOrganization");
            //generalJournalSetupOfOrganization.Parameter<Guid>("organizationKey");
            //generalJournalSetupOfOrganization.ReturnsFromEntitySet<GeneralJournalSetup>("GeneralJournalSetups");


            config.Routes.MapODataRoute("DefaultOdata", "odata", builder.GetEdmModel());
            config.EnableQuerySupport();
        }
    }
}
