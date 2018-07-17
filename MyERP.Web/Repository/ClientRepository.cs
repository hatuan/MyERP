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
        
        public Client Get(IPrincipal principal)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);

            IQueryable<Client> query = dataContext.Set<Client>();
            query = query.Where(c => c.Id == membershipUser.ClientId);

            return query.First();
        }
    }

}