using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using MyERP.DataAccess;


namespace MyERP.Web
{
    public partial class OrganizationRepository 
    {
        public OrganizationRepository()
        {
            this.fetchStrategy.LoadWith<Organization>(c => c.Client);
            this.fetchStrategy.LoadWith<Organization>(c => c.RecModifiedByUser);
            this.fetchStrategy.LoadWith<Organization>(c => c.RecCreatedByUser);
        }

        /// <summary>
        /// Get all organizations of user
        /// </summary>
        /// <param name="principal">IPrincipal of User</param>
        /// <returns></returns>
        public IQueryable<Organization> GetOrganizations(IPrincipal principal)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            var allEntities = GetAll().Where(c => c.ClientId == membershipUser.ClientId);
            
            return allEntities;
        }
    }

}