using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Practices.Prism.Events;
using MyERP.Infrastructure;
using MyERP.Infrastructure.ViewModels;
using MyERP.Modules.Financial.Views;
using Telerik.Windows.Controls;
using DelegateCommand = Microsoft.Practices.Prism.Commands.DelegateCommand;


namespace MyERP.Modules.Financial.ViewModels
{
    [Export]
    public class GeneralJournalsViewModel : NavigationAwareDataViewModel, ICloseable
    {
        public GeneralJournalsViewModel()
        {
        }

        [Import]
        public GeneralJournalDocumentsViewModel GeneralJournalDocumentsViewModel { get; set; }

        [Import]
        public GeneralJournalLinesViewModel GeneralJournalLinesViewModel { get; set; }
        
        [Import]
        public IEventAggregator EventAggregator { get; set; }

        public ICommand AddNewCommand { get; set; }
        public ICommand SubmitChangesCommand { get; set; }
        public ICommand RejectChangesCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        public event EventHandler<EventArgs> RequestClose;

        private bool _generalJournalDocumentsActive;

        public bool GeneralJournalDocumentsActive
        {
            get { return _generalJournalDocumentsActive; }
            set
            {
                _generalJournalDocumentsActive = value; 
                RaisePropertyChanged(() => GeneralJournalDocumentsActive);
            }
        }

        private bool _generalJournalLinesActive;

        public bool GeneralJournalLinesActive
        {
            get { return _generalJournalLinesActive; }
            set
            {
                _generalJournalLinesActive = value;
                RaisePropertyChanged(() => GeneralJournalLinesActive);
            }
        }
        
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

            this.EventAggregator.GetEvent<GeneralJournalsHeaderSwitchEvent>().Subscribe(OnGeneralJournalsHeaderSwitch);
            this.GeneralJournalDocumentsViewModel.PropertyChanged +=
                (sender, args) =>
                {
                    if (args.PropertyName == "SelectedGeneralJournalDocument"
                        && GeneralJournalDocumentsViewModel.SelectedGeneralJournalDocument != null)
                        GeneralJournalLinesViewModel.GeneralJournalDocument = GeneralJournalDocumentsViewModel.SelectedGeneralJournalDocument;

                    if (args.PropertyName == "IsDirty")
                    {
                        RaiseCommandCanExecuteChanged();
                    }
                };
            this.GeneralJournalLinesViewModel.PropertyChanged +=
                (sender, args) =>
                {
                    if (args.PropertyName == "IsDirty")
                    {
                        RaiseCommandCanExecuteChanged();
                    }
                };
        }
        #endregion

        private void RaiseCommandCanExecuteChanged()
        {
            ((DelegateCommand)AddNewCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)SubmitChangesCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)RejectChangesCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)RefreshCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)DeleteCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)CloseWindowCommand).RaiseCanExecuteChanged();
        }

        private bool AddNewCommandCanExecuted()
        {
            if (GeneralJournalDocumentsActive)
                return GeneralJournalDocumentsViewModel.AddNewCommand.CanExecute(null);
            
            if(GeneralJournalLinesActive)
                return GeneralJournalLinesViewModel.AddNewCommand.CanExecute(null);
            
            return false;
        }

        private void OnAddNewCommandExecuted()
        {
            if (GeneralJournalDocumentsActive)
                GeneralJournalDocumentsViewModel.AddNewCommand.Execute(null);

            if (GeneralJournalLinesActive)
                GeneralJournalLinesViewModel.AddNewCommand.Execute(null);
        }

        private bool SubmitChangesCommandCanExecute()
        {
            if (GeneralJournalDocumentsActive)
                return GeneralJournalDocumentsViewModel.SubmitChangesCommand.CanExecute(null);

            if (GeneralJournalLinesActive)
                return GeneralJournalLinesViewModel.SubmitChangesCommand.CanExecute(null);

            return false;
        }

        private void OnRejectChangesExcuted()
        {

        }

        private void OnSubmitChangesExcuted()
        {
            GeneralJournalDocumentsViewModel.IsBusy = true;
            GeneralJournalLinesViewModel.IsBusy = true;

            GeneralJournalDocumentsViewModel.SubmitChangesCommand.Execute(null);
            
            GeneralJournalDocumentsViewModel.IsBusy = false;
            GeneralJournalLinesViewModel.IsBusy = false;
            
            GeneralJournalDocumentsViewModel.IsDirty = false;
            GeneralJournalLinesViewModel.IsDirty = false;
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
            if (GeneralJournalDocumentsActive)
                return GeneralJournalDocumentsViewModel.DeleteCommand.CanExecute(null);

            if (GeneralJournalLinesActive)
                return GeneralJournalLinesViewModel.DeleteCommand.CanExecute(null);

            return false;
        }

        private void OnDeleteExcuted()
        {
            if (GeneralJournalDocumentsActive)
            {
                GeneralJournalDocumentsViewModel.DeleteCommand.Execute(null);
            }

            if (GeneralJournalLinesActive)
                GeneralJournalLinesViewModel.DeleteCommand.Execute(null);
        }

        private bool CloseWindowCanExecute()
        {
            if (this.RequestClose == null)
                return false;

            //Neu co thay doi thi khong cho dong cua so, bat buoc phai luu hay undo
            if (this.GeneralJournalDocumentsViewModel.IsDirty)
                return false;
            if (this.GeneralJournalLinesViewModel.IsDirty)
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

        public void OnGeneralJournalsHeaderSwitch(object obj)
        {
            GeneralJournalLinesActive = obj is GeneralJournalLinesListUserControl;
            GeneralJournalDocumentsActive = obj is GeneralJournalDocumentsListUserControl;

            RaiseCommandCanExecuteChanged();
        }
    }
}
