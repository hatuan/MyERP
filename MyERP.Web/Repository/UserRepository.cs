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
    public partial class UserRepository 
    {
        public UserRepository()
        {
            this.fetchStrategy.LoadWith<User>(c => c.Client);
            this.fetchStrategy.LoadWith<User>(c => c.Organization);
            this.fetchStrategy.LoadWith<User>(c => c.RolesInUser);
          
        }

        public override IQueryable<User> GetAll(IPrincipal principal)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            var allEntities = GetAll().Where(c => c.ClientId == membershipUser.ClientId);

            return allEntities;
        }
    }

}