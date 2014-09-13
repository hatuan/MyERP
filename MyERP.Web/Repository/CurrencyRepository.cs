using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using MyERP.DataAccess;
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
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            var allEntities = GetAll().Where(c => c.ClientId == membershipUser.ClientId);

            return allEntities;
        }
    }

}