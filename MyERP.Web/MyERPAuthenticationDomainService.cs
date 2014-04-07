using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.DomainServices.Hosting;
using System.ServiceModel.DomainServices.Server;
using System.ServiceModel.DomainServices.Server.ApplicationServices;

namespace MyERP.Web
{
    [EnableClientAccess]
    public class MyERPAuthenticationDomainService : AuthenticationBase<AuthUser>
    {
        
    }

    public class AuthUser : UserBase
    {
    }

}