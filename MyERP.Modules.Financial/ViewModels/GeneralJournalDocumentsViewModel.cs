using System;
using System.ComponentModel;
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
    public class GeneralJournalDocumentsViewModel : NavigationAwareDataViewModel, ICloseable
    {
        public GeneralJournalDocumentsViewModel() { }

        #region Repositories
        [Import]
        public GeneralJournalDocumentRepository GeneralJournalDocumentRepository { get; set; }
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
                if (value == null || this._selectedGeneralJournalDocument == value)
                    return;

                if (this._selectedGeneralJournalDocument != null)
                    (this._selectedGeneralJournalDocument as IEditableObject).EndEdit();
                
                this._selectedGeneralJournalDocument = value;
                this.RaisePropertyChanged("SelectedGeneralJournalDocument");

                ((DelegateCommand)DeleteCommand).RaiseCanExecuteChanged();

                this._selectedGeneralJournalDocument.PropertyChanged += _selectedGeneralJournalDocument_PropertyChanged;
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
            GeneralJournalDocuments.SubmittingChanges += GeneralJournalDocuments_SubmittingChanges;
            GeneralJournalDocuments.SubmittedChanges += _generalJournalDocuments_SubmittedChanges;
            GeneralJournalDocuments.PropertyChanged += GeneralJournalDocuments_PropertyChanged;

            this.AddNewCommand = new DelegateCommand(this.OnAddNewCommandExecuted, AddNewCommandCanExecuted);
            this.SubmitChangesCommand = new DelegateCommand(OnSubmitChangesExcuted, SubmitChangesCommandCanExecute);
            this.RejectChangesCommand = new DelegateCommand(OnRejectChangesExcuted, SubmitChangesCommandCanExecute);
            this.RefreshCommand = new DelegateCommand(OnRefreshExcuted, RefreshCommandCanExecute);
            this.DeleteCommand = new DelegateCommand(OnDeleteExcuted, DeleteCommandCanExecute);
            this.CloseWindowCommand = new DelegateCommand(OnCloseWindowExcuted, CloseWindowCanExecute);

        }

        #endregion

        private void GeneralJournalDocuments_SubmittingChanges(object sender,
            Telerik.Windows.Controls.DomainServices.DomainServiceSubmittingChangesEventArgs e)
        {
            EntityChangeSet cs = e.ChangeSet;

            System.Diagnostics.Debug.WriteLine(String.Format("Added Count = {0}", cs.AddedEntities.Count));
            foreach (var entity in cs.AddedEntities)
                System.Diagnostics.Debug.WriteLine(String.Format("Added = {0} - {1}", entity, entity.GetIdentity()));

            System.Diagnostics.Debug.WriteLine(String.Format("Modified Count = {0}", cs.ModifiedEntities.Count));
            foreach (var entity in cs.ModifiedEntities)
                System.Diagnostics.Debug.WriteLine(String.Format("Modified = {0} - {1}", entity, entity.GetIdentity()));

            System.Diagnostics.Debug.WriteLine(String.Format("Removed Count = {0}", cs.RemovedEntities.Count));
            foreach (var entity in cs.RemovedEntities)
                System.Diagnostics.Debug.WriteLine(String.Format("Removed = {0} - {1}", entity, entity.GetIdentity()));

        }

        void _generalJournalDocuments_SubmittedChanges(object sender, Telerik.Windows.Controls.DomainServices.DomainServiceSubmittedChangesEventArgs e)
        {
            if (e.HasError)
            {
                MessageBox.Show(e.Error.ToString(), "Submit Error", MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }
        
        void _selectedGeneralJournalDocument_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var generalJournalDocument = sender as GeneralJournalDocument;
            
            if (e.PropertyName == "HasChanges" && !GeneralJournalDocumentRepository.Context.IsSubmitting)
            {
                (sender as IEditableObject).EndEdit();
                GeneralJournalDocumentRepository.SaveOrUpdateEntities();
            }

            //if (generalJournalDocument.EntityState == EntityState.New
            //    && !GeneralJournalDocumentRepository.Context.IsSubmitting)
            //{
            //    (generalJournalDocument as IEditableObject).EndEdit();
            //    GeneralJournalDocumentRepository.Context.CommitChanges();
            //}
        }

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
            return !this.GeneralJournalDocuments.HasChanges;
        }

        private void OnAddNewCommandExecuted()
        {
            if (SelectedGeneralJournalDocument != null)
                (SelectedGeneralJournalDocument as IEditableObject).EndEdit();

            var generalJournalDocuments = new GeneralJournalDocument();
            this.GeneralJournalDocuments.AddNew(generalJournalDocuments);

            this.GeneralJournalDocuments.CommitNew();
        }

        private bool SubmitChangesCommandCanExecute()
        {
            return this.GeneralJournalDocuments.HasChanges;
        }

        private void OnRejectChangesExcuted()
        {
            this.GeneralJournalDocuments.RejectChanges();
        }

        private void OnSubmitChangesExcuted()
        {
            if (SelectedGeneralJournalDocument != null)
                (SelectedGeneralJournalDocument as IEditableObject).EndEdit();

            this.GeneralJournalDocuments.SubmitChanges();
        }

        private bool RefreshCommandCanExecute()
        {
            return this.GeneralJournalDocuments.CanLoad;
        }

        private void OnRefreshExcuted()
        {
            this.GeneralJournalDocuments.Load();
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
                this.GeneralJournalDocuments.Remove(SelectedGeneralJournalDocument);

            RaisePropertyChanged(()=>this.SelectedGeneralJournalDocument);
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

        public void GotFocusChanged(object sender, RoutedEventArgs e)
        {
            this.EventAggregator.GetEvent<GeneralJournalsHeaderSwitchEvent>().Publish(sender);
        }

    }
}
