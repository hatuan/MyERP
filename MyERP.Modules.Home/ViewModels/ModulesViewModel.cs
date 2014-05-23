using System.Collections.Generic;
using System.ComponentModel.Composition;
using MyERP.Infrastructure.ViewModels;
using MyERP.Repositories;
using MyERP.Repository.MyERPService;

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
        //set from the view's domaindatasource
        private IEnumerable<Module> _generalLeaderJournals;
        public IEnumerable<Module> GeneralLeaderJournals
        {
            get
            {
                if (this._generalLeaderJournals == null)
                {
                    //this.ModulesRepository.GetGeneralLeaderJournals((results) =>
                    //{
                    //    this._generalLeaderJournals = results;
                    //    this.RaisePropertyChanged(() => this.GeneralLeaderJournals);
                    //});
                }
                return this._generalLeaderJournals;
            }
            
        }

        //set from the view's domaindatasource
        private IEnumerable<Module> _generalLeaderSetup;
        public IEnumerable<Module> GeneralLeaderSetup
        {
            get
            {
                if (this._generalLeaderSetup == null)
                {
                    //this.ModulesRepository.GetGeneralLeaderSetup((results) =>
                    //{
                    //    this._generalLeaderSetup = results;
                    //    this.RaisePropertyChanged(() => this.GeneralLeaderSetup);
                    //});
                }
                return this._generalLeaderSetup;
            }
        }

        //set from the view's domaindatasource
        private IEnumerable<Module> _generalLeaderReports;
        public IEnumerable<Module> GeneralLeaderReports
        {
            get
            {
                if (this._generalLeaderReports == null)
                {
                    //this.ModulesRepository.GetGeneralLeaderReports((results) =>
                    //{
                    //    this._generalLeaderReports = results;
                    //    this.RaisePropertyChanged(() => this.GeneralLeaderReports);
                    //});
                }
                return this._generalLeaderReports;
            }
        }

        //set from the view's domaindatasource
        private IEnumerable<Module> _masterSystem;
        public IEnumerable<Module> MasterSystem
        {
            get
            {
                if (this._masterSystem == null)
                {
                    //this.ModulesRepository.GetMasterSystem((results) =>
                    //{
                    //    this._masterSystem = results;
                    //    this.RaisePropertyChanged(() => this.MasterSystem);
                    //});
                }
                return this._masterSystem;
            }
        }

        //set from the view's domaindatasource
        private IEnumerable<Module> _masterCompany;
        public IEnumerable<Module> MasterCompany
        {
            get
            {
                if (this._masterCompany == null)
                {
                    //this.ModulesRepository.GetMasterCompany((results) =>
                    //{
                    //    this._masterCompany = results;
                    //    this.RaisePropertyChanged(() => this.MasterCompany);
                    //});
                }
                return this._masterCompany;
            }
        }

        //set from the view's domaindatasource
        private IEnumerable<Module> _masterBasic;
        public IEnumerable<Module> MasterBasic
        {
            get
            {
                if (this._masterBasic == null)
                {
                    //this.ModulesRepository.GetMasterBasic((results) =>
                    //{
                    //    this._masterBasic = results;
                    //    this.RaisePropertyChanged(() => this.MasterBasic);
                    //});
                }
                return this._masterBasic;
            }
        }

        #endregion

        #region NavigationAwareDataViewModel overrides
        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();
        }
        #endregion
    }
}
