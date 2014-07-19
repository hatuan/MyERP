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
        
        /// <summary>
        /// Update user default Organization in database and Cache with organizationId value
        /// </summary>
        /// <param name="name"></param>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        public bool UpdateDefaultOrganization(string name, Guid organizationId)
        {
            var user = GetBy(c => c.Name == name);
            if (user == null) return false;
            try
            {
                user.OrganizationId = organizationId;
                Update(user);

                ////Store in cache with new membershipUser
                var cacheKey = string.Format("UserData_{0}", name);
                var membershipUser = new MyERPMembershipUser(user);
                HttpRuntime.Cache[cacheKey] = membershipUser;

                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public override IQueryable<User> GetAll(IPrincipal principal)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            var allEntities = GetAll().Where(c => c.ClientId == membershipUser.ClientId);

            return allEntities;
        }
    }

}