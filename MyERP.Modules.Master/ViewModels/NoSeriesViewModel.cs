using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using MyERP.Infrastructure;
using MyERP.Infrastructure.ViewModels;
using MyERP.Repositories;
using MyERP.Repository.MyERPService;
using MyERP.ViewModels;
using Telerik.Windows.Data;

namespace MyERP.Modules.Master.ViewModels
{
    [Export]
    public class NoSeriesViewModel : NavigationAwareDataViewModel, ICloseable
    {
        public NoSeriesViewModel()
        {
            
        }

        [Import]
        public NumberSequenceRepository NumberSequenceRepository { get; set; }

        public ICommand AddNewCommand { get; set; }
        public ICommand SubmitChangesCommand { get; set; }
        public ICommand RejectChangesCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ChangeCodeCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public IApplicationViewModel ApplicationViewModel { get; set; }

        private NumberSequence _selectedNo;
        public NumberSequence SelectedNo
        {
            get
            {
                return this._selectedNo;
            }
            set
            {
                if (this._selectedNo == value)
                {
                    return;
                }
                this._selectedNo = value;
                this.RaisePropertyChanged("SelectedNo");

                ((DelegateCommand)DeleteCommand).RaiseCanExecuteChanged();
            }
        }

        private ObservableItemCollection<NumberSequence> _noSeries;
        public ObservableItemCollection<NumberSequence> NoSeries
        {
            get { return this._noSeries; }
            set { _noSeries = value; }
        }
        
        public bool IsBusy
        {
            get { return true; }
        }

        void _noSeries_LoadedData(object sender, Telerik.Windows.Controls.DomainServices.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                MessageBox.Show(e.Error.ToString(), "Load Error", MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }
        

        void _noSeries_SubmittedChanges(object sender, Telerik.Windows.Controls.DomainServices.DomainServiceSubmittedChangesEventArgs e)
        {
            if (e.HasError)
            {
                MessageBox.Show(e.Error.ToString(), "Submit Error", MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        void _noSeries_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "CanLoad":
                    ((DelegateCommand)RefreshCommand).RaiseCanExecuteChanged();
                    break;
                case "IsBusy":
                    RaisePropertyChanged(e.PropertyName);
                    break;
                case "HasChanges":
                    ((DelegateCommand)AddNewCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand)CloseWindowCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand)SubmitChangesCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand)RejectChangesCommand).RaiseCanExecuteChanged();
                    break;
            }
        }

        private void OnAddNewCommandExecuted()
        {

        }

        private bool AddNewCommandCanExecute()
        {
            return true;
        }
        
        private void OnSubmitChangesExcuted()
        {
        }

        private bool SubmitChangesCommandCanExecute()
        {
            return true;
        }

        private void OnRejectChangesExcuted()
        {
        }

        private bool RefreshCommandCanExecute()
        {
            return true;
        }

        private void OnRefreshExcuted()
        {
        }

        private bool DeleteCommandCanExecute()
        {
            if(SelectedNo == null)
                return false;

            return true;
        }

        private void OnDeleteExcuted()
        {
            if (SelectedNo != null)
                this.NoSeries.Remove(SelectedNo);
        }

        private bool CloseWindowCanExecute()
        {
            if (this.RequestClose == null)
                return false;
            
            //Neu co thay doi thi khong cho dong cua so, bat buoc phai luu hay undo
            //if(this._noSeries.HasChanges)
            //    return false;

            return true;
        }

        private void OnCloseWindowExcuted()
        {
            if (this.RequestClose != null)
            {
                this.RequestClose(null, EventArgs.Empty);
            }
        }

        #region NavigationAwareDataViewModel overrides
        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();
            
            this.AddNewCommand = new DelegateCommand(OnAddNewCommandExecuted, AddNewCommandCanExecute);
            this.SubmitChangesCommand = new DelegateCommand(OnSubmitChangesExcuted, SubmitChangesCommandCanExecute);
            this.RejectChangesCommand = new DelegateCommand(OnRejectChangesExcuted, SubmitChangesCommandCanExecute);
            this.RefreshCommand = new DelegateCommand(OnRefreshExcuted, RefreshCommandCanExecute);
            this.DeleteCommand = new DelegateCommand(OnDeleteExcuted, DeleteCommandCanExecute);
            this.CloseWindowCommand = new DelegateCommand(OnCloseWindowExcuted, CloseWindowCanExecute);
        }
       
        #endregion

        public event EventHandler<EventArgs> RequestClose;
    }
}
