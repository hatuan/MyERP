using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.DomainServices.Hosting;
using System.ServiceModel.DomainServices.Server;
using System.ServiceModel.DomainServices.Server.ApplicationServices;
using System.Threading;
using System.Web.Profile;
using System.Web.Security;
using MyERP.DataAccess;

namespace MyERP.Web
{
    [EnableClientAccess]
    public class MyERPAuthenticationDomainService : AuthenticationBase<AuthUser>
    {
        protected override AuthUser GetAuthenticatedUser(System.Security.Principal.IPrincipal principal)
        {
            AuthUser user = base.GetAuthenticatedUser(principal);  //here will pass windows authentication        

            var memUser = Membership.GetUser(principal.Identity.Name, true);
            user.Id = (Guid)memUser.ProviderUserKey;
            return user;

        }
    }

    public class AuthUser : UserBase
    {
        [ProfileUsage(IsExcluded = true)] ///NEEDED FOR WINDOWS/ACTIVE DIRECTORY LOGON
        public Guid Id { get; set; }
    }
}