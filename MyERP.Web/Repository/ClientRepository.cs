using System.Data.Entity;
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
        
        public Client Get(IPrincipal principal, string[] includePaths = null)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);

            IQueryable<Client> query = dataContext.Set<Client>();
            query = query.Where(c => c.Id == membershipUser.ClientId);
            if (includePaths != null)
            {
                for (var i = 0; i < includePaths.Count(); i++)
                {
                    query = query.Include(includePaths[i]);
                }
            }

            return query.First();
        }
    }

}