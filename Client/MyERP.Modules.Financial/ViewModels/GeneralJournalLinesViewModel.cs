﻿using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using MyERP.Infrastructure;
using MyERP.Infrastructure.Extensions;
using MyERP.Infrastructure.ViewModels;
using MyERP.Repositories;
using MyERP.Repository.MyERPService;
using Telerik.Windows.Data;

namespace MyERP.Modules.Financial.ViewModels
{
    [Export]
    public class GeneralJournalLinesViewModel : NavigationAwareDataViewModel, ICloseable
    {
        public GeneralJournalLinesViewModel()
        {
            GeneralJournalLines = new ObservableCollectionEx<GeneralJournalLine>();
        }

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
                OnRefreshExcuted();
            }
        }

        private ObservableCollectionEx<GeneralJournalLine> _generalJournalLines;
        public ObservableCollectionEx<GeneralJournalLine> GeneralJournalLines
        {
            get { return this._generalJournalLines; }
            set
            {
                _generalJournalLines = value; 
                _generalJournalLines.CollectionChanged += GeneralJournalLinesOnCollectionChanged;
                this.RaisePropertyChanged("GeneralJournalLines");
            }
        }

        private void GeneralJournalLinesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            if (notifyCollectionChangedEventArgs.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (GeneralJournalLine item in notifyCollectionChangedEventArgs.OldItems)
                {
                    //Removed items
                    item.PropertyChanged -= GeneralJournalLinePropertyChanged;
                }
            }
            else if (notifyCollectionChangedEventArgs.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (GeneralJournalLine item in notifyCollectionChangedEventArgs.NewItems)
                {
                    //Added items
                    item.PropertyChanged += GeneralJournalLinePropertyChanged;
                }
            }    
        }

        private void GeneralJournalLinePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            GeneralJournalLine entity = sender as GeneralJournalLine;
            GeneralJournalLineRepository.Update(entity);
            IsDirty = true;
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

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        private bool _isDirty;

        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                _isDirty = value;
                RaisePropertyChanged(() => IsDirty);
            }
        }
        
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

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            IsBusy = true;
            GeneralJournalLineRepository.GetGeneralJournalLines(GeneralJournalDocument, results =>
            {
                GeneralJournalLines.Clear();
                results.ForEach((item) => this.GeneralJournalLines.Add(item));
                IsBusy = false;
            });
            this.RaisePropertyChanged("GeneralJournalLines");
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

            GeneralJournalLine newEntity = new GeneralJournalLine()
            {
                Id = newId,
                CorAccountId = Guid.Empty,
                AccountId = Guid.Empty,
                DebitAmount = 0,
                CreditAmountLcy = 0,
                DebitAmountLcy = 0,
                CreditAmount = 0,
                LineNo = 0,
                ClientId = (Guid) SessionManager.Session["ClientId"],
                Client = SessionManager.Session["Client"] as Client,
                OrganizationId = (SessionManager.Session["Organization"] as Organization).Id,
                Organization = (SessionManager.Session["Organization"] as Organization),
                Version = 1,
                GeneralJournalDocumentId = GeneralJournalDocument.Id,
                GeneralJournalDocument = GeneralJournalDocument,
                DocumentNo = GeneralJournalDocument.DocumentNo,
                DocumentCreated = GeneralJournalDocument.DocumentCreated,
                DocumentPosted = GeneralJournalDocument.DocumentPosted,
                DocumentType =  GeneralJournalDocument.DocumentType,
                Description = "",
                RecCreated = DateTime.Now,
                RecCreatedBy = (SessionManager.Session["User"] as User).Id,
                RecModified = DateTime.Now,
                RecModifiedBy = (SessionManager.Session["User"] as User).Id,
                TransactionType = DataAccess.TransactionType.GeneralJournal.ToString()
            };
            
            this.GeneralJournalLineRepository.AddNew(newEntity);
            this.GeneralJournalLines.Add(newEntity);
            this.SelectedGeneralJournalLine = newEntity;

            IsDirty = true;
        }

        private bool SubmitChangesCommandCanExecute()
        {
            return IsDirty;
        }

        private void OnRejectChangesExcuted()
        {
            
        }

        private void OnSubmitChangesExcuted()
        {
            GeneralJournalLineRepository.SaveChanges();
            IsDirty = false;
        }

        private bool RefreshCommandCanExecute()
        {
            return true;
        }

        private void OnRefreshExcuted()
        {
            IsBusy = true;
            GeneralJournalLineRepository.GetGeneralJournalLines(GeneralJournalDocument, results =>
            {
                GeneralJournalLines.Clear();
                results.ForEach((item) => this.GeneralJournalLines.Add(item));
                IsBusy = false;
            });
        }

        private bool DeleteCommandCanExecute()
        {
            return SelectedGeneralJournalLine != null;
        }

        private void OnDeleteExcuted()
        {
            if (SelectedGeneralJournalLine != null)
            {
                this.GeneralJournalLineRepository.Delete(SelectedGeneralJournalLine);
                this.GeneralJournalLines.Remove(SelectedGeneralJournalLine);
                IsDirty = true;
            }
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