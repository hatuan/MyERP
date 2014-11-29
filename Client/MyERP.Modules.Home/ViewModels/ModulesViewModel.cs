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
        private IEnumerable<Module> _generalLeaderSetup;
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
        private IEnumerable<Module> _generalLeaderReports;
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

        private IEnumerable<Module> _cashJournals;
        public IEnumerable<Module> CashJournals
        {
            get
            {
                if (this._cashJournals == null)
                {
                    this.ModulesRepository.GetGroupOfModule("CashJournals", (results) =>
                    {
                        this._cashJournals = results;
                        this.RaisePropertyChanged(() => this.CashJournals);
                    });
                }
                return this._cashJournals;
            }
        }

        private IEnumerable<Module> _cashReports;
        public IEnumerable<Module> CashReports
        {
            get
            {
                if (this._cashReports == null)
                {
                    this.ModulesRepository.GetGroupOfModule("CashReports", (results) =>
                    {
                        this._cashReports = results;
                        this.RaisePropertyChanged(() => this.CashReports);
                    });
                }
                return this._cashReports;
            }
        }

        private IEnumerable<Module> _cashSetups;
        public IEnumerable<Module> CashSetups
        {
            get
            {
                if (this._cashSetups == null)
                {
                    this.ModulesRepository.GetGroupOfModule("CashSetups", (results) =>
                    {
                        this._cashSetups = results;
                        this.RaisePropertyChanged(() => this.CashSetups);
                    });
                }
                return this._cashSetups;
            }
        }


        private IEnumerable<Module> _costJournals;
        public IEnumerable<Module> CostJournals
        {
            get
            {
                if (this._costJournals == null)
                {
                    this.ModulesRepository.GetGroupOfModule("CostJournals", (results) =>
                    {
                        this._costJournals = results;
                        this.RaisePropertyChanged(() => this.CostJournals);
                    });
                }
                return this._costJournals;
            }
        }

        private IEnumerable<Module> _costReports;
        public IEnumerable<Module> CostReports
        {
            get
            {
                if (this._costReports == null)
                {
                    this.ModulesRepository.GetGroupOfModule("CostReports", (results) =>
                    {
                        this._costReports = results;
                        this.RaisePropertyChanged(() => this.CostReports);
                    });
                }
                return this._costReports;
            }
        }

        private IEnumerable<Module> _costSetups;
        public IEnumerable<Module> CostSetups
        {
            get
            {
                if (this._costSetups == null)
                {
                    this.ModulesRepository.GetGroupOfModule("CostSetups", (results) =>
                    {
                        this._costSetups = results;
                        this.RaisePropertyChanged(() => this.CostSetups);
                    });
                }
                return this._costSetups;
            }
        }

        private IEnumerable<Module> _fixassetJournals;
        public IEnumerable<Module> FixAssetJournals
        {
            get
            {
                if (this._fixassetJournals == null)
                {
                    this.ModulesRepository.GetGroupOfModule("FixAssetJournals", (results) =>
                    {
                        this._fixassetJournals = results;
                        this.RaisePropertyChanged(() => this.FixAssetJournals);
                    });
                }
                return this._fixassetJournals;
            }
        }

        private IEnumerable<Module> _fixassetReports;
        public IEnumerable<Module> FixAssetReports
        {
            get
            {
                if (this._fixassetReports == null)
                {
                    this.ModulesRepository.GetGroupOfModule("FixAssetReports", (results) =>
                    {
                        this._fixassetReports = results;
                        this.RaisePropertyChanged(() => this.FixAssetReports);
                    });
                }
                return this._fixassetReports;
            }
        }

        private IEnumerable<Module> _fixassetSetups;
        public IEnumerable<Module> FixAssetSetups
        {
            get
            {
                if (this._fixassetSetups == null)
                {
                    this.ModulesRepository.GetGroupOfModule("FixAssetSetups", (results) =>
                    {
                        this._fixassetSetups = results;
                        this.RaisePropertyChanged(() => this.FixAssetSetups);
                    });
                }
                return this._fixassetSetups;
            }
        }


        private IEnumerable<Module> _saleJournals;
        public IEnumerable<Module> SaleJournals
        {
            get
            {
                if (this._saleJournals == null)
                {
                    this.ModulesRepository.GetGroupOfModule("SaleJournals", (results) =>
                    {
                        this._saleJournals = results;
                        this.RaisePropertyChanged(() => this.SaleJournals);
                    });
                }
                return this._saleJournals;
            }
        }

        private IEnumerable<Module> _saleReports;
        public IEnumerable<Module> SaleReports
        {
            get
            {
                if (this._saleReports == null)
                {
                    this.ModulesRepository.GetGroupOfModule("SaleReports", (results) =>
                    {
                        this._saleReports = results;
                        this.RaisePropertyChanged(() => this.SaleReports);
                    });
                }
                return this._saleReports;
            }
        }

        private IEnumerable<Module> _saleSetups;
        public IEnumerable<Module> SaleSetups
        {
            get
            {
                if (this._saleSetups == null)
                {
                    this.ModulesRepository.GetGroupOfModule("SaleSetups", (results) =>
                    {
                        this._saleSetups = results;
                        this.RaisePropertyChanged(() => this.SaleSetups);
                    });
                }
                return this._saleSetups;
            }
        }

        private IEnumerable<Module> _puschaseJournals;
        public IEnumerable<Module> PuschaseJournals
        {
            get
            {
                if (this._puschaseJournals == null)
                {
                    this.ModulesRepository.GetGroupOfModule("PuschaseJournals", (results) =>
                    {
                        this._puschaseJournals = results;
                        this.RaisePropertyChanged(() => this.PuschaseJournals);
                    });
                }
                return this._puschaseJournals;
            }
        }

        private IEnumerable<Module> _puschaseReports;
        public IEnumerable<Module> PuschaseReports
        {
            get
            {
                if (this._puschaseReports == null)
                {
                    this.ModulesRepository.GetGroupOfModule("PuschaseReports", (results) =>
                    {
                        this._puschaseReports = results;
                        this.RaisePropertyChanged(() => this.PuschaseReports);
                    });
                }
                return this._puschaseReports;
            }
        }

        private IEnumerable<Module> _puschaseSetups;
        public IEnumerable<Module> PuschaseSetups
        {
            get
            {
                if (this._puschaseSetups == null)
                {
                    this.ModulesRepository.GetGroupOfModule("PuschaseSetups", (results) =>
                    {
                        this._puschaseSetups = results;
                        this.RaisePropertyChanged(() => this.PuschaseSetups);
                    });
                }
                return this._puschaseSetups;
            }
        }

        private IEnumerable<Module> _crmJournals;
        public IEnumerable<Module> CRMJournals
        {
            get
            {
                if (this._crmJournals == null)
                {
                    this.ModulesRepository.GetGroupOfModule("CRMJournals", (results) =>
                    {
                        this._crmJournals = results;
                        this.RaisePropertyChanged(() => this.CRMJournals);
                    });
                }
                return this._crmJournals;
            }
        }

        private IEnumerable<Module> _crmReports;
        public IEnumerable<Module> CRMReports
        {
            get
            {
                if (this._crmReports == null)
                {
                    this.ModulesRepository.GetGroupOfModule("CRMReports", (results) =>
                    {
                        this._crmReports = results;
                        this.RaisePropertyChanged(() => this.CRMReports);
                    });
                }
                return this._crmReports;
            }
        }

        private IEnumerable<Module> _crmSetups;
        public IEnumerable<Module> CRMSetups
        {
            get
            {
                if (this._crmSetups == null)
                {
                    this.ModulesRepository.GetGroupOfModule("CRMSetups", (results) =>
                    {
                        this._crmSetups = results;
                        this.RaisePropertyChanged(() => this.CRMSetups);
                    });
                }
                return this._crmSetups;
            }
        }

        private IEnumerable<Module> _warehouseJournals;
        public IEnumerable<Module> WareHouseJournals
        {
            get
            {
                if (this._warehouseJournals == null)
                {
                    this.ModulesRepository.GetGroupOfModule("WareHouseJournals", (results) =>
                    {
                        this._warehouseJournals = results;
                        this.RaisePropertyChanged(() => this.WareHouseJournals);
                    });
                }
                return this._warehouseJournals;
            }
        }

        private IEnumerable<Module> _warehouseReports;
        public IEnumerable<Module> WareHouseReports
        {
            get
            {
                if (this._warehouseReports == null)
                {
                    this.ModulesRepository.GetGroupOfModule("WareHouseReports", (results) =>
                    {
                        this._warehouseReports = results;
                        this.RaisePropertyChanged(() => this.WareHouseReports);
                    });
                }
                return this._warehouseReports;
            }
        }

        private IEnumerable<Module> _warehouseSetups;
        public IEnumerable<Module> WareHouseSetups
        {
            get
            {
                if (this._warehouseSetups == null)
                {
                    this.ModulesRepository.GetGroupOfModule("WareHouseSetups", (results) =>
                    {
                        this._warehouseSetups = results;
                        this.RaisePropertyChanged(() => this.WareHouseSetups);
                    });
                }
                return this._warehouseSetups;
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
                    this.ModulesRepository.GetMasterSystem((results) =>
                    {
                        this._masterSystem = results;
                        this.RaisePropertyChanged(() => this.MasterSystem);
                    });
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
                    this.ModulesRepository.GetMasterCompany((results) =>
                    {
                        this._masterCompany = results;
                        this.RaisePropertyChanged(() => this.MasterCompany);
                    });
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
                    this.ModulesRepository.GetMasterBasic((results) =>
                    {
                        this._masterBasic = results;
                        this.RaisePropertyChanged(() => this.MasterBasic);
                    });
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
