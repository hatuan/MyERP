using System;
using System.ComponentModel.Composition;
using System.Data.Services.Client;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using MyERP.Infrastructure;
using MyERP.Infrastructure.ViewModels;
using MyERP.Repositories;
using MyERP.Repository.MyERPService;
using Telerik.Windows.Data;

namespace MyERP.Modules.Financial.ViewModels
{
    [Export]
    public class GeneralJournalLinesViewModel : NavigationAwareDataViewModel, ICloseable
    {
        public GeneralJournalLinesViewModel() { }

        #region Repositories
        [Import]
        public GeneralJournalLineRepository GeneralJournalLineRepository { get; set; }
        #endregion

        #region View-visible properties
        [Import]
        public IEventAggregator EventAggregator { get; set; }

        public ICommand AddNewCommand { get; set; }
        public ICommand SubmitChangesCommand { get; set; }
        public ICommand RejectChangesCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        private GeneralJournalDocument _generalJournalDocument;
        public GeneralJournalDocument GeneralJournalDocument {
            get { return _generalJournalDocument; }
            set
            {
                if (value == null)
                    return;

                _generalJournalDocument = value;
                filterGeneralJournalDocument.Value = value.Id ;
            }
        }

        private ObservableItemCollection<GeneralJournalLine> _generalJournalLines;
        public ObservableItemCollection<GeneralJournalLine> GeneralJournalLines
        {
            get { return this._generalJournalLines; }
            set { _generalJournalLines = value; }
        }

        private GeneralJournalLine _selectedGeneralJournalLine;
        public GeneralJournalLine SelectedGeneralJournalLine
        {
            get
            {
                return this._selectedGeneralJournalLine;
            }
            set
            {
                if (this._selectedGeneralJournalLine == value)
                {
                    return;
                }
                this._selectedGeneralJournalLine = value;
                this.RaisePropertyChanged("SelectedGeneralJournalLine");

                ((DelegateCommand)DeleteCommand).RaiseCanExecuteChanged();
            }
        }

        public bool IsBusy
        {
            get { return false; }
        }

        private FilterDescriptor filterGeneralJournalDocument = new FilterDescriptor("GeneralJournalDocumentId",
            FilterOperator.IsEqualTo, FilterDescriptor.UnsetValue);

        #endregion

        #region NavigationAwareDataViewModel overrides
        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();

            this.AddNewCommand = new DelegateCommand(OnAddNewCommandExecuted, AddNewCommandCanExecuted);
            this.SubmitChangesCommand = new DelegateCommand(OnSubmitChangesExcuted, SubmitChangesCommandCanExecute);
            this.RejectChangesCommand = new DelegateCommand(OnRejectChangesExcuted, SubmitChangesCommandCanExecute);
            this.RefreshCommand = new DelegateCommand(OnRefreshExcuted, RefreshCommandCanExecute);
            this.DeleteCommand = new DelegateCommand(OnDeleteExcuted, DeleteCommandCanExecute);
            this.CloseWindowCommand = new DelegateCommand(OnCloseWindowExcuted, CloseWindowCanExecute);
        }
        #endregion

        void GeneralJournalLines_SubmittedChanges(object sender, Telerik.Windows.Controls.DataServices.DataServiceSubmittedChangesEventArgs e)
        {
            if (e.HasError)
            {
                MessageBox.Show(e.Error.ToString(), "Submit Error", MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }


        void GeneralJournalLines_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "CanLoad":
                    ((DelegateCommand)RefreshCommand).RaiseCanExecuteChanged();
                    break;
                case "IsBusy":
                    RaisePropertyChanged(() => IsBusy);
                    break;
                case "HasChanges":
                    ((DelegateCommand)AddNewCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand)CloseWindowCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand)SubmitChangesCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand)RejectChangesCommand).RaiseCanExecuteChanged();
                    break;
            }
        }

        public event EventHandler<EventArgs> RequestClose;

        private bool AddNewCommandCanExecuted()
        {
            return true;
        }

        private void OnAddNewCommandExecuted()
        {

        }

        private bool SubmitChangesCommandCanExecute()
        {
            return true;
        }

        private void OnRejectChangesExcuted()
        {
            
        }

        private void OnSubmitChangesExcuted()
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
            return SelectedGeneralJournalLine != null;
        }

        private void OnDeleteExcuted()
        {
            if (SelectedGeneralJournalLine != null)
                this.GeneralJournalLines.Remove(SelectedGeneralJournalLine);
        }

        private bool CloseWindowCanExecute()
        {
            if (this.RequestClose == null)
                return false;

            //Neu co thay doi thi khong cho dong cua so, bat buoc phai luu hay undo
            //if (this.GeneralJournalLines.HasChanges)
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

        public void GotFocusChanged(object sender, RoutedEventArgs e)
        {
            this.EventAggregator.GetEvent<GeneralJournalsHeaderSwitchEvent>().Publish(sender);
        }
    }
}
