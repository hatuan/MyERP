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
    public partial class CurrencyRepository 
    {
        public CurrencyRepository()
        {
            this.fetchStrategy.LoadWith<Currency>(c => c.Client);
            this.fetchStrategy.LoadWith<Currency>(c => c.Organization);
            this.fetchStrategy.LoadWith<Currency>(c => c.RecModifiedByUser);
            this.fetchStrategy.LoadWith<Currency>(c => c.RecCreatedByUser);
            
        }

        public override IQueryable<Currency> GetAll(IPrincipal principal)
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