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
    public partial class RoleRepository 
    {
        public RoleRepository()
        {
            this.fetchStrategy.LoadWith<Role>(c => c.Client);
            this.fetchStrategy.LoadWith<Role>(c => c.Organization);
            this.fetchStrategy.LoadWith<Role>(c => c.RecCreateByUser);
            this.fetchStrategy.LoadWith<Role>(c => c.RecModifiedByUser);
            this.fetchStrategy.LoadWith<Role>(c => c.UsersInRole);
        }

        public override IQueryable<Role> GetAll(IPrincipal principal)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            var allEntities = GetAll().Where(c => c.ClientId == membershipUser.ClientId);

            return allEntities;
        }
    }

}