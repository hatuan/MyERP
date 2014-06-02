using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using MyERP.DataAccess;
using MyERP.Infrastructure;
using MyERP.Infrastructure.Extensions;
using MyERP.Infrastructure.ViewModels;
using MyERP.Repositories;
using MyERP.Repository.MyERPService;
using Telerik.Windows.Data;

namespace MyERP.Modules.Financial.ViewModels
{
    [Export]
    public class GeneralJournalDocumentsViewModel : NavigationAwareDataViewModel, ICloseable
    {
        public GeneralJournalDocumentsViewModel()
        {
            GeneralJournalDocuments = new ObservableCollectionEx<GeneralJournalDocument>();
        }

        #region Repositories
        [Import]
        public GeneralJournalDocumentRepository GeneralJournalDocumentRepository { get; set; }
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

        private ObservableCollectionEx<GeneralJournalDocument> _generalJournalDocuments;
        public ObservableCollectionEx<GeneralJournalDocument> GeneralJournalDocuments
        {
            get { return this._generalJournalDocuments; }
            set
            {
                _generalJournalDocuments = value;
                _generalJournalDocuments.CollectionChanged += GeneralJournalLinesOnCollectionChanged;
                this.RaisePropertyChanged("GeneralJournalDocuments");
            }
        }

        private void GeneralJournalLinesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            if (notifyCollectionChangedEventArgs.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (GeneralJournalDocument item in notifyCollectionChangedEventArgs.OldItems)
                {
                    //Removed items
                    item.PropertyChanged -= GeneralJournalDocumentPropertyChanged;
                }
            }
            else if (notifyCollectionChangedEventArgs.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (GeneralJournalDocument item in notifyCollectionChangedEventArgs.NewItems)
                {
                    //Added items
                    item.PropertyChanged += GeneralJournalDocumentPropertyChanged;
                }
            }
        }

        private void GeneralJournalDocumentPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            GeneralJournalDocument entity = sender as GeneralJournalDocument;
            GeneralJournalDocumentRepository.Update(entity);
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
            get { return false; }
        }

        #endregion

        #region NavigationAwareDataViewModel overrides
        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();
            

            this.AddNewCommand = new DelegateCommand(this.OnAddNewCommandExecuted, AddNewCommandCanExecuted);
            this.SubmitChangesCommand = new DelegateCommand(OnSubmitChangesExcuted, SubmitChangesCommandCanExecute);
            this.RejectChangesCommand = new DelegateCommand(OnRejectChangesExcuted, SubmitChangesCommandCanExecute);
            this.RefreshCommand = new DelegateCommand(OnRefreshExcuted, RefreshCommandCanExecute);
            this.DeleteCommand = new DelegateCommand(OnDeleteExcuted, DeleteCommandCanExecute);
            this.CloseWindowCommand = new DelegateCommand(OnCloseWindowExcuted, CloseWindowCanExecute);

        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            GeneralJournalDocuments.Clear();
            GeneralJournalDocumentRepository.GetGeneralJournalDocumens(results => results.ForEach((item) => this.GeneralJournalDocuments.Add(item)));
            this.RaisePropertyChanged("GeneralJournalDocuments");
        }

        #endregion

        public event EventHandler<EventArgs> RequestClose;

        private bool AddNewCommandCanExecuted()
        {
            return true;
        }

        private void OnAddNewCommandExecuted()
        {
            var newId = Guid.NewGuid();

            GeneralJournalDocument newEntity = new GeneralJournalDocument()
            {
                Id = newId,
                ClientId = (Guid)SessionManager.Session["ClientId"],
                OrganizationId = (SessionManager.Session["Organization"] as Organization).Id,
                Version = 1,
                DocumentCreated = Convert.ToDateTime(SessionManager.Session["WorkingDate"]),
                DocumentPosted = Convert.ToDateTime(SessionManager.Session["WorkingDate"]),
                DocumentType = DataAccess.DocumentType.GeneralJournal.ToString(),
                RecCreated = DateTime.Now,
                RecCreatedBy = (SessionManager.Session["User"] as User).Id,
                RecModified = DateTime.Now,
                RecModifiedBy = (SessionManager.Session["User"] as User).Id,
                TransactionType = DataAccess.TransactionType.GeneralJournal.ToString()
            };

            this.GeneralJournalDocuments.Add(newEntity);
            this.GeneralJournalDocumentRepository.AddNew("GeneralJournalDocuments", newEntity);
            this.SelectedGeneralJournalDocument = newEntity;
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
            GeneralJournalDocumentRepository.SaveChanges();
        }

        private bool RefreshCommandCanExecute()
        {
            return true;
        }

        private void OnRefreshExcuted()
        {
            GeneralJournalDocuments.Clear();
            GeneralJournalDocumentRepository.GetGeneralJournalDocumens(results => results.ForEach((item) => this.GeneralJournalDocuments.Add(item)));
        }

        private bool DeleteCommandCanExecute()
        {
            if (SelectedGeneralJournalDocument == null)
                return false;

            return true;
        }

        private void OnDeleteExcuted()
        {
            if (SelectedGeneralJournalDocument != null)
            {
                this.GeneralJournalDocumentRepository.Delete(SelectedGeneralJournalDocument);
                this.GeneralJournalDocuments.Remove(SelectedGeneralJournalDocument);
            }
        }

        private bool CloseWindowCanExecute()
        {
            if (this.RequestClose == null)
                return false;

            //Neu co thay doi thi khong cho dong cua so, bat buoc phai luu hay undo
            //if (this.GeneralJournalDocuments.HasChanges)
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
