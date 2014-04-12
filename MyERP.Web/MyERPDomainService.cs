using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel.DomainServices.Server;
using System.ServiceModel.DomainServices.Server.ApplicationServices;
using System.Web.ApplicationServices;
using System.Web.Security;
using MyERP.DataAccess;
using Telerik.OpenAccess;

namespace MyERP.Web
{
    public partial class MyERPDomainService
    {
        private IPrincipal _user;
        public override void Initialize(DomainServiceContext context)
        {
            base.Initialize(context);
            _user = context.User;
        }

        public IQueryable<Organization> GetOrganizationsByClientId(Guid clientId)
        {
            var organizations = this.DataContext.Organizations.ToList().Where(a => a.ClientId == clientId && a.Status == (int)OrganizationStatusType.Active);
            return organizations.AsQueryable();
        }
        
        #region Dashboard services
        public DashboardStats GetDashboardStats()
        {
            var stats = new DashboardStats() { };
            return stats;
        }
        #endregion
    }
}