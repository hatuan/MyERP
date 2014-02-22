using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using MyERP.Infrastructure;

namespace MyERP.Modules.User
{
    [ModuleExport(ModuleNames.UserModule, typeof(UserModule), InitializationMode = InitializationMode.OnDemand)]
    public class UserModule : IModule
    {
        public void Initialize()
        {

        }
    }
}
