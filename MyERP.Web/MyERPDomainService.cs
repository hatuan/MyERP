using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private MyERPMembershipUser _membershipUser;
        public override void Initialize(DomainServiceContext context)
        {
            base.Initialize(context);
            _membershipUser = (MyERPMembershipUser)Membership.GetUser(context.User.Identity.Name, true);

        }

        public IQueryable<Organization> GetOrganizationsByClientId(Guid clientId)
        {
            var organizations = this.DataContext.Organizations.ToList().Where(a => a.ClientId == clientId && a.Status == (int)OrganizationStatusType.Active);
            return organizations.AsQueryable();
        }

        #region NoSeries
        public void DeleteNoSeries(NoSeries noSeries)
        {
            // This is a callback method. The actual Delete is performed internally.
        }

        public void UpdateNoSeiess(NoSeries noSeries)
        {
            // This is a callback method. The actual Update is performed internally.
        }

        public void InsertNoSeries(NoSeries noSeries)
        {
            string SqlQuery = String.Format("CREATE SEQUENCE {0} MINVALUE {1} MAXVALUE {2} START {3}", new object[] {noSeries.NoSeqName, noSeries.StartingNo, noSeries.EndingNo, noSeries.CurrentNo});
            using (var connection = this.DataContext.Connection)
            {
                // 3. Create a new instance of the OACommand class.
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = SqlQuery;
                    command.ExecuteNonQuery();
                }
            }

        } 
        #endregion

        #region Dashboard services
        public DashboardStats GetDashboardStats()
        {
            var stats = new DashboardStats() { };
            return stats;
        }
        #endregion
    }
}