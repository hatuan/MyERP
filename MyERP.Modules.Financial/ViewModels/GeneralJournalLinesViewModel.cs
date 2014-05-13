using System;
using System.ComponentModel.Composition;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using MyERP.DataAccess;
using MyERP.Infrastructure;
using MyERP.Infrastructure.ViewModels;
using MyERP.Repositories;
using MyERP.Web;
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

        public MyERPDomainContext Context { get; set; }

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
                GeneralJournalLines.AutoLoad = true;
            }
        }

        private QueryableDomainServiceCollectionView<GeneralJournalLine> _generalJournalLines;
        public QueryableDomainServiceCollectionView<GeneralJournalLine> GeneralJournalLines
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
            get { return this.GeneralJournalLines.IsBusy; }
        }

        private FilterDescriptor filterGeneralJournalDocument = new FilterDescriptor("GeneralJournalDocumentId",
            FilterOperator.IsEqualTo, FilterDescriptor.UnsetValue);

        #endregion

        #region NavigationAwareDataViewModel overrides
        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();
            this.Context = this.GeneralJournalLineRepository.Context;

            EntityQuery<GeneralJournalLine> getGeneralJournalLinesQuery = Context.GetGeneralJournalLinesQuery().OrderBy(c => c.GeneralJournalDocumentId).ThenBy(c=>c.LineNo);
            GeneralJournalLines = new QueryableDomainServiceCollectionView<GeneralJournalLine>(Context,
                getGeneralJournalLinesQuery);
            GeneralJournalLines.AutoLoad = false;
            GeneralJournalLines.LoadedData += (sender, args) =>
            {
                if (args.HasError)
                {
                    MessageBox.Show(args.Error.ToString(), "Load Error", MessageBoxButton.OK);
                    args.MarkErrorAsHandled();
                    return;
                }
            };
            GeneralJournalLines.SubmittedChanges += GeneralJournalLines_SubmittedChanges;
            GeneralJournalLines.PropertyChanged += GeneralJournalLines_PropertyChanged;
            this.GeneralJournalLines.FilterDescriptors.Add(filterGeneralJournalDocument);

            this.AddNewCommand = new DelegateCommand(OnAddNewCommandExecuted, AddNewCommandCanExecuted);
            this.SubmitChangesCommand = new DelegateCommand(OnSubmitChangesExcuted, SubmitChangesCommandCanExecute);
            this.RejectChangesCommand = new DelegateCommand(OnRejectChangesExcuted, SubmitChangesCommandCanExecute);
            this.RefreshCommand = new DelegateCommand(OnRefreshExcuted, RefreshCommandCanExecute);
            this.DeleteCommand = new DelegateCommand(OnDeleteExcuted, DeleteCommandCanExecute);
            this.CloseWindowCommand = new DelegateCommand(OnCloseWindowExcuted, CloseWindowCanExecute);
        }
        #endregion

        void GeneralJournalLines_SubmittedChanges(object sender, Telerik.Windows.Controls.DomainServices.DomainServiceSubmittedChangesEventArgs e)
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
            return !this.GeneralJournalLines.HasChanges;
        }

        private void OnAddNewCommandExecuted()
        {
            GeneralJournalLine generalJournalLine = new GeneralJournalLine();
            this.GeneralJournalLines.AddNew(generalJournalLine);

            generalJournalLine.GeneralJournalDocumentId = GeneralJournalDocument.Id;
            this.GeneralJournalDocument.GeneralJournalLines.Add(generalJournalLine);
        }

        private bool SubmitChangesCommandCanExecute()
        {
            return this.GeneralJournalLines.HasChanges;
        }

        private void OnRejectChangesExcuted()
        {
            this.GeneralJournalLines.RejectChanges();
        }

        private void OnSubmitChangesExcuted()
        {
            this.GeneralJournalLines.SubmitChanges();
        }

        private bool RefreshCommandCanExecute()
        {
            return this.GeneralJournalLines.CanLoad;
        }

        private void OnRefreshExcuted()
        {
            this.GeneralJournalLines.Load();
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
            if (this.GeneralJournalLines.HasChanges)
                return false;

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
