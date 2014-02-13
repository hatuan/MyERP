using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;
using MyERP.DataAccess;
using MyERP.Infrastructure;
using MyERP.Infrastructure.ViewModels;
using MyERP.Repositories;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Telerik.Windows.Data;

namespace MyERP.ViewModels
{
    [Export]
    public class LoginViewModel : NotificationObject
    {
        public LoginViewModel()
        {
            this.LoginCommand = new DelegateCommand(this.OnLoginCommandExecuted);
        }
        
        [Import]
        public UserRepository UserRepository { get; set; }

        [Import]
        public IApplicationViewModel ApplicationViewModel { get; set; }

        public ICommand LoginCommand { get; set; }

        private void OnLoginCommandExecuted()
        {
            bool correctUserAndPass = false;
            UserRepository.GetUserinfoByUserNameAndPassword(UserName, PassWord, 
                userinfo =>
                {
                    if (userinfo != null) correctUserAndPass = true;
                });
            if (correctUserAndPass)
            {
                NavigateToDashboardModule();
            }
        }

        private String _userName;
        public String UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                if (this._userName == value)
                {
                    return;
                }
                this._userName = value;
                this.RaisePropertyChanged("UserName");
            }
        }

        private String _passWord;
        public String PassWord
        {
            get
            {
                return this.PassWord;
            }
            set
            {
                if (this._passWord == value)
                {
                    return;
                }
                this._passWord = value;
                this.RaisePropertyChanged("PassWord");
            }
        }

        private void NavigateToDashboardModule()
        {
            this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.DashboardModule);
        }

    }
}
