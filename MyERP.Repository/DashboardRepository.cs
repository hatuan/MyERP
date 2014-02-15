using System;
using System.Linq;
using System.ComponentModel.Composition;
using MyERP.DataAccess;
using MyERP.Repositories;

namespace CRM.Repositories
{
    [Export]
    public class DashboardRepository : RepositoryBase
    {
        private bool isLoading = false;

        public void GetDashboardStats(Action<DashboardStats> callback)
        {
            if (isLoading)
            {
                return;
            }
            isLoading = true;
            this.Context.GetDashboardStats((operation) =>
                                           {
                                               isLoading = false;
                                               callback(operation.Value);
                                           }, null);
        }
    }
}
