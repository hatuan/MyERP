using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using MyERP.Infrastructure;

namespace MyERP.Modules.Financial
{
    [ModuleExport(ModuleNames.FinancialModule, typeof(FinancialModule), InitializationMode = InitializationMode.OnDemand)]
    public class FinancialModule : IModule
    {
        public void Initialize()
        {

        }
    }
}
