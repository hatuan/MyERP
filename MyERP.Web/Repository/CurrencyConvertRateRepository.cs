using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using MyERP.DataAccess;
using MyERP.Web.Models;
using Telerik.OpenAccess;

namespace MyERP.Web
{
    public partial class CurrencyConvertRateRepository 
    {
        public CurrencyConvertRateRepository()
        {
            this.fetchStrategy.LoadWith<CurrencyConvertRate>(c => c.Currency);
            this.fetchStrategy.LoadWith<CurrencyConvertRate>(c => c.CurrencyRelational);
            this.fetchStrategy.LoadWith<CurrencyConvertRate>(c => c.Client);
            this.fetchStrategy.LoadWith<CurrencyConvertRate>(c => c.Client);
            this.fetchStrategy.LoadWith<CurrencyConvertRate>(c => c.Organization);
            this.fetchStrategy.LoadWith<CurrencyConvertRate>(c => c.RecModifiedByUser);
            this.fetchStrategy.LoadWith<CurrencyConvertRate>(c => c.RecCreatedByUser);
            
        }

        public override IQueryable<CurrencyConvertRate> GetAll(IPrincipal principal)
        {
            var preference = HttpContext.Current.Session["Preference"] as PreferenceViewModel;

            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            var allEntities =
                GetAll()
                    .Where(
                        c =>
                            c.ClientId == membershipUser.ClientId &&
                            (c.OrganizationId == preference.Organization.Id || c.OrganizationId == preference.RootOrganization.Id));

            return allEntities;
        }
    }

}