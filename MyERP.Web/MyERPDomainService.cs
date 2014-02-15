using System;
using System.Linq;
using MyERP.DataAccess;

namespace MyERP.Web
{
    public partial class MyERPDomainService
    {
        #region Dashboard services
        public DashboardStats GetDashboardStats()
        {
            var stats = new DashboardStats() { };
            return stats;
        }
        #endregion
    }
}