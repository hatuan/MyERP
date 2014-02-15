using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using MyERP.Infrastructure;

namespace MyERP.Modules.Home
{
    [ModuleExport(ModuleNames.HomeModule, typeof(HomeModule), InitializationMode = InitializationMode.OnDemand)]
    public class HomeModule : IModule
    {
        public void Initialize()
        {

        }
    }
}
