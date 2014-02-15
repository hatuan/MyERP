using System.ComponentModel.Composition;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;

namespace MyERP.ViewModels
{
    [Export(typeof(IApplicationViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ApplicationViewModel : NotificationObject, IApplicationViewModel
    {
        private bool busyIndicatorIsIndeterminate;
        private string currentViewName;
        private string currentModuleName;
        private int progressPercentage = 0;
        private bool isLoadingData;
        private bool isLoadingModule;

        // The shell imports IModuleManager once to load modules on-demand.
        // Due to SilverLight/MEF restrictions this must be public.
        [Import]
        public ApplicationNavigator ApplicationNavigator;

        [ImportingConstructor]
        public ApplicationViewModel()
        {
            this.SwitchContentRegionViewCommand = new DelegateCommand<string>(SwitchContentRegionView);
            this.CurrentModuleName = "HomeModule";
            this.CurrentViewName = "DashboardView";
        }

        public ICommand SwitchContentRegionViewCommand { get; private set; }

        public string CurrentModuleName
        {
            get
            {
                return this.currentModuleName;
            }
            set
            {
                this.currentModuleName = value;
                this.RaisePropertyChanged("CurrentModuleName");
            }
        }

        public bool IsBusy
        {
            get
            {
                return this.isLoadingData || this.isLoadingModule;
            }
        }

        public bool IsLoadingData
        {
            get
            {
                return this.isLoadingData;
            }
            set
            {
                this.isLoadingData = value;
                this.RaisePropertyChanged("IsBusy");
            }
        }

        public bool IsLoadingModule
        {
            get
            {
                return this.isLoadingModule;
            }
            set
            {
                this.isLoadingModule = value;
                this.RaisePropertyChanged("IsBusy");
            }
        }

        public bool BusyIndicatorIsIndeterminate
        {
            get
            {
                return this.busyIndicatorIsIndeterminate;
            }
            set
            {
                this.busyIndicatorIsIndeterminate = value;
                this.RaisePropertyChanged("BusyIndicatorIsIndeterminate");
            }
        }

        public int ProgressPercentage
        {
            get
            {
                return this.progressPercentage;
            }
            set
            {
                this.progressPercentage = value;
                this.RaisePropertyChanged("ProgressPercentage");
            }
        }

        public string CurrentViewName
        {
            get
            {
                return this.currentViewName;
            }
            set
            {
                if (this.currentViewName == value)
                {
                    return;
                }

                this.currentViewName = value;
                this.RaisePropertyChanged("CurrentViewName");
            }
        }

        public void SwitchContentRegionView(string moduleName)
        {
            this.CurrentModuleName = moduleName;

            this.isLoadingModule = true;
            this.ApplicationNavigator.NavigateToModule(moduleName,
                (progress) =>
                {
                    this.ProgressPercentage = progress;
                },
                () =>
                {
                    this.isLoadingModule = false;
                    // we want to show indeterminate indication after first load
                    this.BusyIndicatorIsIndeterminate = true;
                });
        }
    }
}
