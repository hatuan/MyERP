using System.Linq;
using System.Security.Principal;
using System.Web.Security;
using MyERP.DataAccess;

namespace MyERP.Web
{
    public partial class ClientRepository 
    {
        public ClientRepository()
        {
           
        }
        
        public override IQueryable<Client> GetAll(IPrincipal principal)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            var allEntities = GetAll().Where(c => c.Id == membershipUser.ClientId);

            return allEntities;
        }
    }

}