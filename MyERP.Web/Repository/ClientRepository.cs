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
    public partial class ClientRepository 
    {
        public ClientRepository()
        {
            this.fetchStrategy.LoadWith<Client>(c => c.CurrencyLCY);
            this.fetchStrategy.LoadWith<Client>(c => c.RecModifiedByUser);
            this.fetchStrategy.LoadWith<Client>(c => c.RecCreatedByUser);
            
        }
        
        public override IQueryable<Client> GetAll(IPrincipal principal)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            var allEntities = GetAll().Where(c => c.ClientId == membershipUser.ClientId);

            return allEntities;
        }
    }

}