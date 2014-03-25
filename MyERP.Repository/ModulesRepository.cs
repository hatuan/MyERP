using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ServiceModel.DomainServices.Client;
using MyERP.DataAccess;

namespace MyERP.Repositories
{
    [Export]
    public class ModulesRepository : RepositoryBase
    {
        public void GetGeneralLeaderJournals(Action<IEnumerable<Module>> callback)
        {
            EntityQuery<Module> query =
                this.Context.GetModulesQuery().Where(u => u.Group == "GeneralLeaderJournals");

            this.LoadQuery<Module>(query, callback);
        }

        public void GetGeneralLeaderReports(Action<IEnumerable<Module>> callback)
        {
            EntityQuery<Module> query =
                this.Context.GetModulesQuery().Where(u => u.Group == "GeneralLeaderReports");

            this.LoadQuery<Module>(query, callback);
        }

        public void GetGeneralLeaderSetup(Action<IEnumerable<Module>> callback)
        {
            EntityQuery<Module> query =
                this.Context.GetModulesQuery().Where(u => u.Group == "GeneralLeaderSetup");

            this.LoadQuery<Module>(query, callback);
        }
    }
}
