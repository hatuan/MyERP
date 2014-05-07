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
using MyERP.DataAccess;
using MyERP.Infrastructure;
using MyERP.Infrastructure.ViewModels;
using MyERP.Repositories;
using MyERP.Web;
using Telerik.Windows.Data;

namespace MyERP.Modules.Financial.ViewModels
{
    [Export]
    public class GeneralJournalDocumentsViewModel : NavigationAwareDataViewModel, ICloseable
    {
        public GeneralJournalDocumentsViewModel() { }

        #region Repositories
        [Import]
        public GeneralJournalDocumentRepository GeneralJournalDocumentRepository { get; set; }
        #endregion

        #region View-visible properties
        public MyERPDomainContext Context { get; set; }

        public ICommand AddNewCommand { get; set; }
        public ICommand SubmitChangesCommand { get; set; }
        public ICommand RejectChangesCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ChangeCodeCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        private QueryableDomainServiceCollectionView<GeneralJournalDocument> _generalJournalDocuments;
        public QueryableDomainServiceCollectionView<GeneralJournalDocument> GeneralJournalDocuments
        {
            get { return this._generalJournalDocuments; }
            set { _generalJournalDocuments = value; }
        }

        private GeneralJournalDocument _selectedGeneralJournalDocument;
        public GeneralJournalDocument SelectedGeneralJournalDocument
        {
            get
            {
                return this._selectedGeneralJournalDocument;
            }
            set
            {
                if (this._selectedGeneralJournalDocument == value)
                {
                    return;
                }
                this._selectedGeneralJournalDocument = value;
                this.RaisePropertyChanged("SelectedGeneralJournalDocument");

                ((DelegateCommand)DeleteCommand).RaiseCanExecuteChanged();
            }
        }

        public bool IsBusy
        {
            get { return this.GeneralJournalDocuments.IsBusy; }
        }

        #endregion

        #region NavigationAwareDataViewModel overrides
        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();
            this.Context = this.GeneralJournalDocumentRepository.Context;
            
            EntityQuery<GeneralJournalDocument> getGeneralJournalDocumentsQuery = Context.GetGeneralJournalDocumentsQuery().OrderBy(c => c.DocumentNo);
            GeneralJournalDocuments = new QueryableDomainServiceCollectionView<GeneralJournalDocument>(Context,
                getGeneralJournalDocumentsQuery);
            GeneralJournalDocuments.PageSize = 10;
            GeneralJournalDocuments.AutoLoad = true;
            GeneralJournalDocuments.LoadedData += (sender, args) =>
            {
                if (args.HasError)
                {
                    MessageBox.Show(args.Error.ToString(), "Load Error", MessageBoxButton.OK);
                    args.MarkErrorAsHandled();
                }
            };
            GeneralJournalDocuments.PropertyChanged += GeneralJournalDocuments_PropertyChanged;

            this.AddNewCommand = new DelegateCommand(this.OnAddNewCommandExecuted, AddNewCommandCanExecuted);
            this.SubmitChangesCommand = new DelegateCommand(OnSubmitChangesExcuted, SubmitChangesCommandCanExecute);
            this.RejectChangesCommand = new DelegateCommand(OnRejectChangesExcuted, SubmitChangesCommandCanExecute);
            this.RefreshCommand = new DelegateCommand(OnRefreshExcuted, RefreshCommandCanExecute);
            this.DeleteCommand = new DelegateCommand(OnDeleteExcuted, DeleteCommandCanExecute);
            this.CloseWindowCommand = new DelegateCommand(OnCloseWindowExcuted, CloseWindowCanExecute);

        }
        #endregion

        void GeneralJournalDocuments_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
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
                    ((DelegateCommand)CloseWindowCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand)SubmitChangesCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand)RejectChangesCommand).RaiseCanExecuteChanged();
                    break;
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
                    ((DelegateCommand)CloseWindowCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand)SubmitChangesCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand)RejectChangesCommand).RaiseCanExecuteChanged();
                    break;
            }
        }

        public event EventHandler<EventArgs> RequestClose;

        private bool AddNewCommandCanExecuted()
        {
            return !this.GeneralJournalDocuments.HasChanges;
        }

        private void OnAddNewCommandExecuted()
        {
            GeneralJournalDocument generalJournalDocument = new GeneralJournalDocument();
            GeneralJournalDocumentRepository.SetGeneralJournalDocumentNo(generalJournalDocument, document =>
            {
                generalJournalDocument = document;
                GeneralJournalDocuments.AddNew(generalJournalDocument);
            });
        }

        private bool SubmitChangesCommandCanExecute()
        {
            return this.GeneralJournalDocuments.HasChanges;
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
           return true;
        }

        private void OnDeleteExcuted()
        {
            
        }

        private bool CloseWindowCanExecute()
        {
            if (this.RequestClose == null)
                return false;

            //Neu co thay doi thi khong cho dong cua so, bat buoc phai luu hay undo
            if (this.GeneralJournalDocuments.HasChanges)
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
    }
}
