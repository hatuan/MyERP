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
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            var allEntities = GetAll().Where(c => c.ClientId == membershipUser.ClientId);

            return allEntities;
        }
    }

}