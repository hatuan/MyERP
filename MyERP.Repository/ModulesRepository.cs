using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Services.Client;
using System.Linq;
using MyERP.Infrastructure;
using MyERP.Repository.MyERPService;

namespace MyERP.Repositories
{
    [Export]
    public class ModulesRepository : RepositoryBase
    {

        public void GetGroupOfModule(String groupName, Action<IEnumerable<Module>> callback)
        {
            DataServiceQuery<Module> query = (DataServiceQuery<Module>)from module in Container.Modules
                                                                       where module.Group == groupName
                                                                       select module;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<Module>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }

        public void GetGeneralLeaderJournals(Action<IEnumerable<Module>> callback)
        {
            DataServiceQuery<Module> query = (DataServiceQuery<Module>) from module in Container.Modules
                                                                        where module.Group == "GeneralLeaderJournals"
                                                                        select module;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<Module>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }

        public void GetGeneralLeaderReports(Action<IEnumerable<Module>> callback)
        {
            DataServiceQuery<Module> query = (DataServiceQuery<Module>)from module in Container.Modules
                                                                       where module.Group == "GeneralLeaderReports"
                                                                       select module;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<Module>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }

        public void GetGeneralLeaderSetup(Action<IEnumerable<Module>> callback)
        {
            DataServiceQuery<Module> query = (DataServiceQuery<Module>)from module in Container.Modules
                                                                       where module.Group == "GeneralLeaderSetup"
                                                                       select module;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<Module>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }

        public void GetMasterSystem(Action<IEnumerable<Module>> callback)
        {
            DataServiceQuery<Module> query = (DataServiceQuery<Module>)from module in Container.Modules
                                                                       where module.Group == "MasterSystem"
                                                                       select module;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<Module>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }

        public void GetMasterCompany(Action<IEnumerable<Module>> callback)
        {
            DataServiceQuery<Module> query = (DataServiceQuery<Module>)from module in Container.Modules
                                                                       where module.Group == "MasterCompany"
                                                                       select module;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<Module>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }

        public void GetMasterBasic(Action<IEnumerable<Module>> callback)
        {
            DataServiceQuery<Module> query = (DataServiceQuery<Module>)from module in Container.Modules
                                                                       where module.Group == "MasterBasic"
                                                                       select module;

            query.BeginExecute(result =>
            {
                var request = result.AsyncState as DataServiceQuery<Module>;
                var response = request.EndExecute(result);

                UIThread.Invoke(() => callback(response));
            }, query);
        }

    }
}
