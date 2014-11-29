using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using MyERP.Infrastructure;
using MyERP.Infrastructure.Extensions;
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
            this.NoSeries = new ObservableCollectionEx<NumberSequence>(true);
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

        private ObservableCollectionEx<NumberSequence> _noSeries;
        public ObservableCollectionEx<NumberSequence> NoSeries
        {
            get { return this._noSeries; }
            set
            {
                _noSeries = value;
                _noSeries.CollectionChanged += NoSeriesCollectionChanged;
                this.RaisePropertyChanged("NoSeries");
            }
        }

        private void NoSeriesCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (NumberSequence item in e.OldItems)
                {
                    //Removed items
                    item.PropertyChanged -= NumberSequencePropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (NumberSequence item in e.NewItems)
                {
                    //Added items
                    item.PropertyChanged += NumberSequencePropertyChanged;
                }
            }
        }

        private void NumberSequencePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NumberSequence entity = sender as NumberSequence;
            NumberSequenceRepository.Update(entity);
        }

        public bool IsBusy { get; set; }

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
            var newId = Guid.NewGuid();
            var newEntity = new NumberSequence
            {
                OrganizationId = (SessionManager.Session["Organization"] as Organization).Id,
                ClientId = (Guid) SessionManager.Session["ClientId"],
                Id = newId,
                Code = "",
                Name = "",
                NoSeqName = String.Format("seq_no_series_{0}", newId.ToString().Replace("-", "_")),
                FormatNo = "",
                StartingNo = 0,
                EndingNo = 0,
                CurrentNo = 0,
                RecModifiedBy = (SessionManager.Session["User"] as User).Id,
                RecCreatedBy = (SessionManager.Session["User"] as User).Id,
                RecModified = DateTime.Now,
                RecCreated = DateTime.Now,
                Status = 1,
                Version = 1
            };
            this.NoSeries.Add(newEntity);
            this.NumberSequenceRepository.AddNew("NumberSequences", newEntity);
            this.SelectedNo = newEntity;
        }

        private bool AddNewCommandCanExecute()
        {
            return true;
        }
        
        private void OnSubmitChangesExcuted()
        {
            NumberSequenceRepository.SaveChanges();
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
            NoSeries.Clear();
            NumberSequenceRepository.GetNumberSequences(results => results.ForEach((item) => this.NoSeries.Add(item)));

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
            {
                this.NumberSequenceRepository.Delete(SelectedNo);
                this.NoSeries.Remove(SelectedNo);
            }
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
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            NoSeries.Clear();
            NumberSequenceRepository.GetNumberSequences(results => results.ForEach((item) => this.NoSeries.Add(item)));
        }

        #endregion

        public event EventHandler<EventArgs> RequestClose;
    }
}
