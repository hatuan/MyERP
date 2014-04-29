using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using MyERP.Infrastructure;

namespace MyERP.Modules.Setup
{
    [ModuleExport(ModuleNames.SetupModule, typeof(SetupModule), InitializationMode = InitializationMode.OnDemand)]
    public class SetupModule : IModule
    {
        public void Initialize()
        {

        }
    }
}
