using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;
using MyERP.Infrastructure;
using MyERP.Infrastructure.ViewModels;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using MyERP.Repositories;
using MyERP.ViewModels;


namespace MyERP.Modules.User.ViewModels
{
    [Export]
    public class LoginViewModel : ViewModelBase
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

        private const string PASSWORD_ERROR = "Password is incorrect";
        
        private void OnLoginCommandExecuted()
        {
            string passEncrypt = Cryptography.Encrypt(Cryptography.GetHashKey(UserName+Password), Password);
            UserRepository.GetUserinfoByUserNameAndPassword(UserName, passEncrypt,
                userinfo =>
                {
                    if (userinfo != null)
                    {
                        RemoveError("Password", PASSWORD_ERROR);
                        NavigateToDashboardModule();
                    }
                    else
                    {
                        AddError("Password", PASSWORD_ERROR, false);
                    }

                });
        }

        private String _userName = String.Empty;
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
                this._userName = value ?? String.Empty;
                this.RaisePropertyChanged("UserName");
            }
        }

        private String _password = String.Empty;
        public String Password
        {
            get
            {
                return this._password;
            }
            set
            {
                if (this._password == value)
                {
                    return;
                }
                this._password = value ?? String.Empty;
                this.RaisePropertyChanged("Password");
            }
        }

        private void NavigateToDashboardModule()
        {
            this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.HomeModule);
        }
    }
}
