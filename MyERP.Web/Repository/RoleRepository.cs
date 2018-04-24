using System.Linq;
using System.Security.Principal;
using System.Web.Security;
using MyERP.DataAccess;

namespace MyERP.Web
{
    public partial class RoleRepository 
    {
        public RoleRepository()
        {

        }

        public override IQueryable<Role> GetAll(IPrincipal principal)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            var allEntities = GetAll().Where(c => c.ClientId == membershipUser.ClientId);

            return allEntities;
        }
    }

}