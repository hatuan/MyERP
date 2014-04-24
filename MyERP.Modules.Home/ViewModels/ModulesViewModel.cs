using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ServiceModel.DomainServices.Client;
using MyERP.Infrastructure.ViewModels;
using MyERP.Repositories;
using MyERP.DataAccess;

namespace MyERP.Modules.Home.ViewModels
{
    [Export]
    public class ModulesViewModel : NavigationAwareDataViewModel
    {
        #region Repositories
        [Import]
        public ModulesRepository ModulesRepository { get; set; }
        #endregion

        #region View-visible properties
        public DomainContext Context { get; set; }

        //set from the view's domaindatasource
        private IEnumerable<Module> _generalLeaderJournals = null;
        public IEnumerable<Module> GeneralLeaderJournals
        {
            get
            {
                if (this._generalLeaderJournals == null)
                {
                    this.ModulesRepository.GetGeneralLeaderJournals((results) =>
                    {
                        this._generalLeaderJournals = results;
                        this.RaisePropertyChanged(() => this.GeneralLeaderJournals);
                    });
                }
                return this._generalLeaderJournals;
            }
            
        }

        //set from the view's domaindatasource
        private IEnumerable<Module> _generalLeaderSetup = null;
        public IEnumerable<Module> GeneralLeaderSetup
        {
            get
            {
                if (this._generalLeaderSetup == null)
                {
                    this.ModulesRepository.GetGeneralLeaderSetup((results) =>
                    {
                        this._generalLeaderSetup = results;
                        this.RaisePropertyChanged(() => this.GeneralLeaderSetup);
                    });
                }
                return this._generalLeaderSetup;
            }
        }

        //set from the view's domaindatasource
        private IEnumerable<Module> _generalLeaderReports = null;
        public IEnumerable<Module> GeneralLeaderReports
        {
            get
            {
                if (this._generalLeaderReports == null)
                {
                    this.ModulesRepository.GetGeneralLeaderReports((results) =>
                    {
                        this._generalLeaderReports = results;
                        this.RaisePropertyChanged(() => this.GeneralLeaderReports);
                    });
                }
                return this._generalLeaderReports;
            }
        }

        #endregion

        #region NavigationAwareDataViewModel overrides
        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();
            this.Context = this.ModulesRepository.Context;
        }
        #endregion
    }
}
