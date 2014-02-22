using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MyERP.Infrastructure;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;
using WindowStartupLocation = Telerik.Windows.Controls.WindowStartupLocation;

namespace MyERP
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class ApplicationNavigator
    {
        [Import]
        public AtomicModuleLoader ModuleLoader { private get; set; }

        [Import]
        public IModuleManager ModuleManager { private get; set; }

        [Import]
        public IRegionManager RegionManager { private get; set; }

        [Import]
        public IModuleCatalog ModuleCatalog { private get; set; }

        [Import]
        public CompositionContainer Container { private get; set; }

        private IDictionary<string, string> ModuleDefaultViewNames = new Dictionary<string, string>()
        {
            { ModuleNames.HomeModule, "HomeWindow" },
            { ModuleNames.UserModule, "UserWindow" }
        };

        private string currentUri;
        public void NavigateToModule(string uri, Action<int> progressChangedCallback = null, Action completedCallback = null)
        {
            this.currentUri = uri;

            if (this.ModuleLoader.IsModuleLoaded(uri))
            {
                this.NavigateToDefaultRegion(uri);
                completedCallback();
            }
            else
            {
                EventHandler completed = null;
                EventHandler<ProgressChangedEventArgs> progressChanged = null;
                completed = (s, e) =>
                {
                    this.ModuleLoader.PriorityOperationCompleted -= completed;
                    this.NavigateToDefaultRegion(this.currentUri);
                    completedCallback();
                };

                progressChanged = (s, e) =>
                {
                    progressChangedCallback(e.ProgressPercentage);
                };

                this.ModuleLoader.PriorityOperationCompleted += completed;
                this.ModuleLoader.PriorityOperationProgressChanged += progressChanged;

                this.ModuleLoader.ProcessWithPriority(uri);
            }
        }

        public void SwitchToModule(string uri, Action<int> progressChangedCallback = null, Action completedCallback = null)
        {
            this.currentUri = uri;

            if (this.ModuleLoader.IsModuleLoaded(uri))
            {
                this.NavigateToDefaultRegion(uri);
                completedCallback();
            }
            else
            {
                EventHandler completed = null;
                EventHandler<ProgressChangedEventArgs> progressChanged = null;
                completed = (s, e) =>
                {
                    this.ModuleLoader.PriorityOperationCompleted -= completed;
                    this.NavigateToDefaultRegion(this.currentUri);
                    completedCallback();
                };

                progressChanged = (s, e) =>
                {
                    progressChangedCallback(e.ProgressPercentage);
                };

                this.ModuleLoader.PriorityOperationCompleted += completed;
                this.ModuleLoader.PriorityOperationProgressChanged += progressChanged;

                this.ModuleLoader.ProcessWithPriority(uri);
            }
        }

        //private void NavigateToDefaultRegion(string moduleName)
        //{
        //    if (this.ModuleDefaultViewNames.ContainsKey(moduleName))
        //    {
        //        var viewName = this.ModuleDefaultViewNames[moduleName];
        //        this.RegionManager.RequestNavigate( RegionNames.ContentRegion, viewName);
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("Cannot navigate to unknown module name.");
        //    }
        //}

        private void NavigateToDefaultRegion(string moduleName)
        {
            if (this.ModuleDefaultViewNames.ContainsKey(moduleName))
            {
                bool foundExport = false;
                System.ComponentModel.Composition.Primitives.ComposablePartDefinition partFound = null;
                var viewName = this.ModuleDefaultViewNames[moduleName];
                var parts = this.Container.Catalog.Parts;
                foreach (var part in parts)
                {
                    foreach (var exportDefinition in part.ExportDefinitions)
                    {
                        if (exportDefinition.ContractName == viewName)
                        {
                            foundExport = true;
                            break;
                        }
                    }
                    if (foundExport)
                    {
                        partFound = part;
                        break;
                    }
                }
                if (foundExport)
                {
                    //var exportValue = Container.GetExportedValue<IView>(viewName);
                    //RadWindow win = new RadWindow();

                    //SetRestrictedAreaMarginToRadWindow(win);
                    //win.IsRestricted = true;
                    //win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    //win.Content = exportValue;
                    //StyleManager.SetTheme(win, new Windows8Theme());
                    //win.Closed += (sender, args) => { win.Content = null; };
                    //win.Show();

                    var win = Container.GetExportedValue<RadWindow>(viewName);

                    SetRestrictedAreaMarginToRadWindow(win);
                    win.IsRestricted = true;
                    win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    win.Show();
                }
                else
                {
                    throw new InvalidOperationException("Cannot navigate to unknown module name.");
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot navigate to unknown module name.");
            }
        }

        public void SetRestrictedAreaMarginToRadWindow(RadWindow window)
        {
            var shell = this.Container.GetExportedValue<Shell>();
            var contenRegion = shell.ContentRegionPlaceholder;
            GeneralTransform generalTransform1 = contenRegion.TransformToVisual(Application.Current.RootVisual);
            Point topLeftOffset = generalTransform1.Transform(new Point(0, 0));
            Point bottomRightOffset = generalTransform1.Transform(new Point(contenRegion.RenderSize.Width, contenRegion.RenderSize.Height));

            double right = ((FrameworkElement)Application.Current.RootVisual).ActualWidth - bottomRightOffset.X;
            double bottom = ((FrameworkElement)Application.Current.RootVisual).ActualHeight - bottomRightOffset.Y;

            window.RestrictedAreaMargin = new Thickness(topLeftOffset.X, topLeftOffset.Y, right, bottom);
        }
    }
}