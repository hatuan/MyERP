using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using System.Windows.Input;
using Microsoft.Practices.Prism;
using Microsoft.Practices.ServiceLocation;
using MyERP.DataAccess;
using MyERP.Infrastructure;
using MyERP.Infrastructure.ViewModels;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using MyERP.Repositories;
using MyERP.ViewModels;
using MyERP.Web;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;
using DelegateCommand = Microsoft.Practices.Prism.Commands.DelegateCommand;
using ViewModelBase = MyERP.Infrastructure.ViewModelBase;


namespace MyERP.Modules.User.ViewModels
{
    [Export]
    public class PreferenceViewModel : NavigationAwareDataViewModel, ICloseable
    {
        public PreferenceViewModel()
        {
            this.NextCommand = new DelegateCommand(OnNextCommandExecuted, NextCommandCanExecute);
        }

        [Import]
        public OrganizationRepository OrganizationRepository { get; set; }

        [Import]
        public IApplicationViewModel ApplicationViewModel { get; set; }

        [Import]
        public SessionRepository SessionRepository { get; set; }

        [Import]
        public IRegionManager RegionManager { get; set; }

        private QueryableCollectionView _organizations;
        public QueryableCollectionView Organizations
        {
            get
            {
                
                return this._organizations;
            }
            set
            {
                if (this._organizations == value) 
                    return;

                _organizations = value;
                this.RaisePropertyChanged("Organizations");
            }
        }
        
        public ICommand NextCommand { get; set; }

        private bool NextCommandCanExecute()
        {
            return true;
        }

        private void OnNextCommandExecuted()
        {
            //Close PreferenceView
            if (this.RequestClose != null)
            {
                this.RequestClose(null, EventArgs.Empty);
            }

            //Open HomeModule
            this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.HomeModule);
        }

        public event EventHandler<EventArgs> RequestClose;

        #region NavigationAwareDataViewModel overrides
        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();

        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            this.ApplicationViewModel.IsLoadingData = true;
            this.OrganizationRepository.GetOrganizationsByClientId(MyERP.Repositories.WebContext.Current.User.ClientId, items =>
            {
                this.ApplicationViewModel.IsLoadingData = false;
                this._organizations = new QueryableCollectionView(new List<Organization>(items));

                this.RaisePropertyChanged("Organizations");
            });
        }

        #endregion
    }
}
