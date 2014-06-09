using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Input;
using MyERP.Infrastructure;
using Microsoft.Practices.Prism.Regions;
using MyERP.Repositories;
using MyERP.Repository.MyERPService;
using MyERP.ViewModels;
using Telerik.Windows.Data;
using DelegateCommand = Microsoft.Practices.Prism.Commands.DelegateCommand;
using ViewModelBase = MyERP.Infrastructure.ViewModels.ViewModelBase;


namespace MyERP.Modules.User.ViewModels
{
    [Export]
    public class PreferenceViewModel : Infrastructure.ViewModels.ViewModelBase, ICloseable
    {
        public PreferenceViewModel()
        {
            this.NextCommand = new DelegateCommand(OnNextCommandExecuted, NextCommandCanExecute);
        }

        [Import]
        public OrganizationRepository OrganizationRepository { get; set; }

        [Import]
        public SessionRepository SessionRepository { get; set; }

        [Import]
        public IApplicationViewModel ApplicationViewModel { get; set; }
        
        [Import]
        public IRegionManager RegionManager { get; set; }

        private IEnumerable<Organization> _organizations = Enumerable.Empty<Organization>();
        public IEnumerable<Organization> Organizations
        {
            get
            {
                return this._organizations;
            }
            set
            {
                if (this._organizations == value) 
                    return;

                _organizations = value;
                OnPropertyChanged("Organizations");
            }
        }
        
        public ICommand NextCommand { get; set; }

        private bool NextCommandCanExecute()
        {
            return true;
        }

        private Organization _organization;
        [Required]
        public Organization Organization
        {
            get { return _organization; }
            set
            {
                _organization = value;
                OnPropertyChanged("Organization");
            }
        }

        private DateTime _workingDate = DateTime.Now;
        [Required]
        public DateTime WorkingDate
        {
            get { return _workingDate; }
            set
            {
                _workingDate = value;
                OnPropertyChanged("WorkingDate");
            }
        }

        private void OnNextCommandExecuted()
        {
            RemoveError("Organization", "Require");
            if (Organization == null)
            {
                AddError("Organization", "Require", false);
                return;
            }

            SessionManager.Session.Add("Organization", Organization);
            SessionManager.Session.Add("WorkingDate", WorkingDate);

            //Insert To Session table
            //Session session = new Session()
            //{
            //    ClientId = MyERP.Repositories.WebContext.Current.User.ClientId,
            //    OrganizationId = (SessionManager.Session["Organization"] as Organization).Id,
            //    Id = (Guid)SessionManager.Session["SessionId"],
            //    UserId = MyERP.Repositories.WebContext.Current.User.Id,
            //    WorkingDate = DateTime.Today,
            //    LastTime = DateTime.Now,
            //    Expire = false,
            //};

            //SessionRepository.Context.Sessions.Add(session);
            //SessionRepository.SaveOrUpdateEntities();

            //Close PreferenceView
            if (this.RequestClose != null)
            {
                this.RequestClose(null, EventArgs.Empty);
            }
            
            //Open HomeModule
            this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.HomeModule);
        }

        public event EventHandler<EventArgs> RequestClose;
    }
}
