using System.Linq;
using System.Security.Principal;
using System.Web.Security;
using MyERP.DataAccess;


namespace MyERP.Web
{
    public partial class OrganizationRepository 
    {
        public OrganizationRepository()
        {
        }

        /// <summary>
        /// Get all organizations of user
        /// </summary>
        /// <param name="principal">IPrincipal of User</param>
        /// <returns></returns>
        public override IQueryable<Organization> GetAll(IPrincipal principal)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            var allEntities = GetAll().Where(c => c.ClientId == membershipUser.ClientId);

            return allEntities;
        }

        /// <summary>
        /// Get Root Org of current organization
        /// </summary>
        /// <param name="curOrganization">Current Organization</param>
        /// <returns></returns>
        public Organization GetRootOrganization(Organization curOrganization)
        {
            if(curOrganization == null)
                return default(Organization);

            var rootOrg = GetBy(c => c.ClientId == curOrganization.ClientId && c.Code == "*");

            return rootOrg;
        }

        /// <summary>
        /// Get Root Org of current User
        /// </summary>
        /// <param name="principal">IPrincipal of User</param>
        /// <returns></returns>
        public Organization GetRootOrganization(IPrincipal principal)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            var rootOrg = GetBy(c => c.ClientId == membershipUser.ClientId && c.Code == "*");

            return rootOrg;
        }
    }

}