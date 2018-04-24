using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace MyERP.Web
{
    public class AuthController : ApiController
    {
        [AllowAnonymous]
        public HttpResponseMessage Get([FromUri] String name, [FromUri] String password)
        {
            if (!Membership.Provider.ValidateUser(name, password))
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "error");
            return Request.CreateResponse(HttpStatusCode.Accepted, "ok");
        }
    }
}