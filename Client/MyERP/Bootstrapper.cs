using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using MyERP.Infrastructure;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;
using Modularity = Microsoft.Practices.Prism.Modularity;

namespace MyERP
{
    public class Bootstrapper : MefBootstrapper
    {
        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(AutoPopulateExportedViewsBehavior).Assembly));
        }

        protected override DependencyObject CreateShell()
        {
            //var shell = this.Container.GetExportedValue<Shell>();
            //return shell;
            return new Shell();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.RootVisual = this.Shell as UIElement;
        }

        protected override Microsoft.Practices.Prism.Regions.IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            var factory = base.ConfigureDefaultRegionBehaviors();
            factory.AddIfMissing(typeof(MyERP.Infrastructure.AutoPopulateExportedViewsBehavior).Name, typeof(AutoPopulateExportedViewsBehavior));
            return factory;
        }

        /// <summary>
        /// Creates the <see cref="IModuleCatalog"/> used by Prism.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// The base implementation returns a new ModuleCatalog.
        /// </remarks>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            // When using MEF, the existing Prism ModuleCatalog is still the place to configure modules via configuration files.
            return Modularity.ModuleCatalog.CreateFromXaml(new Uri("/MyERP;component/ModulesCatalog.xaml", UriKind.Relative));
        }
        //private void SetShellDefaultView()
        //{
        //    var rm = this.Container.GetExportedValue<IRegionManager>();
        //    //rm.RequestNavigate("HeaderRegion", "MainNavigationMenu");
        //    //rm.RequestNavigate("ContentRegion", "CompaniesView");
        //    rm.RequestNavigate("ContentRegion", "DashboardView");
        //}

        protected override CompositionContainer CreateContainer()
        {
            var container = base.CreateContainer();
            container.ComposeExportedValue(container);
            return container;
        }
    }
}