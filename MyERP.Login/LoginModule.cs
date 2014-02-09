using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using MyERP.Infrastructure;

namespace MyERP.Modules.Login
{
    [ModuleExport(ModuleNames.LoginModule, typeof(LoginModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class LoginModule : IModule
    {
        public void Initialize()
        {

        }
    }
}
