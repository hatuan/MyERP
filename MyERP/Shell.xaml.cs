using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using MyERP.Infrastructure;
using MyERP.ViewModels;

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
        public ApplicationNavigator ApplicationNavigator;

        public Shell()
        {
            InitializeComponent();
        }

        public void OnImportsSatisfied()
        {
            LoadModulesInBackground();
            //NavigateToDashboardModule();
        }

        private void NavigateToDashboardModule()
        {
            this.ViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.DashboardModule);
        }

        private void LoadModulesInBackground()
        {
            Queue<string> urls = new Queue<string>(new string[]
                                               {
                                                   ModuleNames.DashboardModule
                                               });

            foreach (var url in urls)
            {
                ModuleLoader.AddLoadOperation(url);
            }

            ModuleLoader.ProcessQueueAsync();
        }
    }
}