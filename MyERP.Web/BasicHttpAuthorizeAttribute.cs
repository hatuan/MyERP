using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MyERP.Web
{
    /// <summary>
    /// Remember use : http(s)://username:encrypt_password@...
    /// encrypt_password store in user table like R2UXFUC+WF2Ra+4eJLXXyA==
    /// </summary>
    public abstract class BasicHttpAuthorizeAttribute : AuthorizeAttribute
    {
        private const string BasicAuthResponseHeader = "WWW-Authenticate";
        private const string BasicAuthResponseHeaderValue = "Basic";

        
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null)
                throw Error.ArgumentNull("actionContext");
            
            if (AuthorizationDisabled(actionContext))
                return;
            
            //Case that user is authenticated using forms authentication
            //so no need to check header for basic authentication.
            if (HttpContext.Current.User.Identity.IsAuthenticated) //If current user is authenticated 
            {
                var principal = HttpContext.Current.User;
                if(CheckRoles(principal) && CheckUsers(principal))
                    return;
            }
            else if (AuthorizeRequest(actionContext.ControllerContext.Request)) //Use Basic Auth information
                return;
            
            this.HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (actionContext == null)
                throw Error.ArgumentNull("actionContext");
            actionContext.Response = CreateUnauthorizedResponse(actionContext
                .ControllerContext.Request);
        }

        private HttpResponseMessage CreateUnauthorizedResponse(HttpRequestMessage request)
        {
            var result = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                RequestMessage = request
            };

            //we need to include WWW-Authenticate header in our response,
            //so our client knows we are using HTTP authentication
            result.Headers.Add(BasicAuthResponseHeader, BasicAuthResponseHeaderValue);
            return result;
        }

        private static bool AuthorizationDisabled(HttpActionContext actionContext)
        {
            //support new AllowAnonymousAttribute
            if (!actionContext.ActionDescriptor
                .GetCustomAttributes<AllowAnonymousAttribute>().Any())
                return actionContext.ControllerContext
                    .ControllerDescriptor
                    .GetCustomAttributes<AllowAnonymousAttribute>().Any();
            else
                return true;
        }

        private bool AuthorizeRequest(HttpRequestMessage request)
        {
            AuthenticationHeaderValue authValue = request.Headers.Authorization;
            if (authValue == null || String.IsNullOrWhiteSpace(authValue.Parameter)
                || String.IsNullOrWhiteSpace(authValue.Scheme)
                || authValue.Scheme != BasicAuthResponseHeaderValue)
            {
                return false;
            }

            string[] parsedHeader = ParseAuthorizationHeader(authValue.Parameter);
            if (parsedHeader == null)
            {
                return false;
            }
            IPrincipal principal = null;
            if (TryCreatePrincipal(parsedHeader[0], parsedHeader[1], out principal))
            {
                HttpContext.Current.User = principal;
                return CheckRoles(principal) && CheckUsers(principal);
            }
            else
            {
                return false;
            }
        }

        private bool CheckUsers(IPrincipal principal)
        {
            string[] users = UsersSplit;
            if (users.Length == 0) return true;
            //NOTE: This is a case sensitive comparison
            return users.Any(u => principal.Identity.Name == u);
        }

        private bool CheckRoles(IPrincipal principal)
        {
            string[] roles = RolesSplit;
            if (roles.Length == 0) return true;
            return roles.Any(principal.IsInRole);
        }

        private string[] ParseAuthorizationHeader(string authHeader)
        {
            string[] credentials = Encoding.UTF8.GetString(Convert
                                                            .FromBase64String(authHeader))
                                                            .Split(
                                                            new[] { ':' });
            if (credentials.Length != 2 || string.IsNullOrEmpty(credentials[0])
                || string.IsNullOrEmpty(credentials[1])) return null;
            return credentials;
        }

        protected string[] RolesSplit
        {
            get { return SplitStrings(Roles); }
        }

        protected string[] UsersSplit
        {
            get { return SplitStrings(Users); }
        }

        protected static string[] SplitStrings(string input)
    {
        if(string.IsNullOrWhiteSpace(input)) return new string[0];
        var result = input.Split(',')
            .Where(s=>!String.IsNullOrWhiteSpace(s.Trim()));
        return result.Select(s =>s.Trim()).ToArray();
    }

        /// <summary>
        /// Implement to include authentication logic and create IPrincipal
        /// </summary>
        protected abstract bool TryCreatePrincipal(string user, string password,
            out IPrincipal principal);
    }
}