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

        public void GetMasterSystem(Action<IEnumerable<Module>> callback)
        {
            EntityQuery<Module> query =
              this.Context.GetModulesQuery().Where(u => u.Group == "MasterSystem");

            this.LoadQuery<Module>(query, callback);
        }

        public void GetMasterCompany(Action<IEnumerable<Module>> callback)
        {
            EntityQuery<Module> query =
              this.Context.GetModulesQuery().Where(u => u.Group == "MasterCompany");

            this.LoadQuery<Module>(query, callback);
        }

        public void GetMasterBasic(Action<IEnumerable<Module>> callback)
        {
            EntityQuery<Module> query =
              this.Context.GetModulesQuery().Where(u => u.Group == "MasterBasic");

            this.LoadQuery<Module>(query, callback);
        }

    }
}
