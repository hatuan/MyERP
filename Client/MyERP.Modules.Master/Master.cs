using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using MyERP.Infrastructure;

namespace MyERP.Modules.Master
{
    [ModuleExport(ModuleNames.MasterModule, typeof(MasterModule), InitializationMode = InitializationMode.OnDemand)]
    public class MasterModule : IModule
    {
        public void Initialize()
        {

        }
    }
}
