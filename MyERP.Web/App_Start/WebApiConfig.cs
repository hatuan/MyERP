﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using MyERP.DataAccess;

namespace MyERP.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MessageHandlers.Add(new MethodOverrideHandler());

            config.Routes.MapHttpRoute(
                name: "Auth",
                routeTemplate: "auth",
                defaults: new { controller = "auth" }
            );

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Account>("Accounts");
            builder.EntitySet<BusinessPartnerGroup>("BusinessPartnerGroups");
            builder.EntitySet<BusinessPartner>("BusinessPartners");
            builder.EntitySet<Client>("Clients");
            builder.EntitySet<Currency>("Currencies");
            builder.EntitySet<CurrencyConvertRate>("CurrencyConvertRates");
            builder.EntitySet<GeneralJournalDocument>("GeneralJournalDocuments");
            builder.EntitySet<GeneralJournalLine>("GeneralJournalLines");
            builder.EntitySet<GeneralJournalSetup>("GeneralJournalSetups");
            builder.EntitySet<JobGroup>("JobGroups");
            builder.EntitySet<Job>("Jobs");
            builder.EntitySet<Module>("Modules");
            builder.EntitySet<NumberSequence>("NumberSequences");
            builder.EntitySet<Organization>("Organizations");
            builder.EntitySet<PaymentTerm>("PaymentTerms");
            builder.EntitySet<Session>("Sessions");
            builder.EntitySet<User>("Users");
            
            //var tutorsEntitySet = builder.EntitySet<Tutor>("Tutors");
            //tutorsEntitySet.EntityType.Ignore(s => s.UserName);
            //tutorsEntitySet.EntityType.Ignore(s => s.Password);

            //Declare the Action in the Entity Data Model
            ActionConfiguration sequenceNextVal = builder.Entity<NumberSequence>().Action("SequenceNextVal");
            sequenceNextVal.Parameter<Guid>("key");
            sequenceNextVal.Returns<int>();

            config.Filters.Add(new MembershipHttpAuthorizeAttribute());
            config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
            config.EnableQuerySupport();
        }
    }
}
