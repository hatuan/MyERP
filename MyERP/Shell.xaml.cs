using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using MyERP.Infrastructure;
using MyERP.ViewModels;
using MyERP.Views;
using Telerik.Windows.Controls;

namespace MyERP
{
    [Export(typeof(Shell))]
    public partial class Shell : UserControl, IPartImportsSatisfiedNotification
    {
        [Import]
        public AtomicModuleLoader ModuleLoader { private get; set; }

        [Import]
        public IApplicationViewModel ViewModel
        {
            private get
            {
                return this.DataContext as IApplicationViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        [Import]
        public IEventAggregator Aggregator;

        [Import]
        public IRegionManager RegionManager { get; set; }

        public Shell()
        {
            InitializeComponent();
            
        }

        public void OnImportsSatisfied()
        {
            LoadModulesInBackground();
            NavigateToLoginModule();
        }

        private void NavigateToLoginModule()
        {
            this.ViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.UserModule);
            this.Aggregator.GetEvent<ShowUserLoginProcessEvent>().Publish(null);

            //this.ViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.UserModule);
        }

        private void LoadModulesInBackground()
        {
            Queue<string> urls = new Queue<string>(new string[]
                                               {
                                                   ModuleNames.UserModule,
                                                   ModuleNames.HomeModule,
                                                   ModuleNames.FinancialModule,
                                                   ModuleNames.SetupModule
                                               });

            foreach (var url in urls)
            {
                ModuleLoader.AddLoadOperation(url);
            }

            ModuleLoader.ProcessQueueAsync();
        }
    }
}