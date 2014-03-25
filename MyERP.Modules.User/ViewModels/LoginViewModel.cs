using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using System.Windows.Input;
using Microsoft.Practices.Prism;
using Microsoft.Practices.ServiceLocation;
using MyERP.DataAccess;
using MyERP.Infrastructure;
using MyERP.Infrastructure.ViewModels;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using MyERP.Repositories;
using MyERP.ViewModels;
using Telerik.Windows.Controls;
using DelegateCommand = Microsoft.Practices.Prism.Commands.DelegateCommand;
using ViewModelBase = MyERP.Infrastructure.ViewModelBase;


namespace MyERP.Modules.User.ViewModels
{
    [Export]
    public class LoginViewModel : ViewModelBase, ICloseable
    {
        public LoginViewModel()
        {
            this.LoginCommand = new DelegateCommand(this.OnLoginCommandExecuted);
        }

        [Import]
        public UserRepository UserRepository { get; set; }

        [Import]
        public IApplicationViewModel ApplicationViewModel { get; set; }

        [Import]
        public SessionRepository SessionRepository { get; set; }

        [Import]
        public IRegionManager RegionManager { get; set; }

        public ICommand LoginCommand { get; set; }

        private const string PASSWORD_ERROR = "Password is incorrect";

        private void OnLoginCommandExecuted()
        {
            string passEncrypt = Cryptography.Encrypt(Cryptography.GetHashKey(UserName + Password), Password);

            //LoginOperation lop = WebContext.Current.Authentication.Login((new LoginParameters(UserName, passEncrypt, true, null)));
            //lop.Completed += (Authsender, args) =>
            //{
            //    if (!lop.HasError)
            //    {
            //        if (lop.LoginSuccess)
            //        {
            //            RemoveError("Password", PASSWORD_ERROR);
            //            LoginSuccessfully();
            //        }
            //        else
            //        {
            //            AddError("Password", PASSWORD_ERROR, false);
            //        }
            //    }
            //    else
            //    {
            //        AddError("Password", lop.Error.Message, false);
            //        lop.MarkErrorAsHandled();
            //    }
            //};


            UserRepository.GetUserinfoByUserNameAndPassword(UserName, passEncrypt,
                user =>
                {
                    if (user != null)
                    {
                        RemoveError("Password", PASSWORD_ERROR);

                        //Insert UserId To Session table
                        Session session = new Session()
                        {
                            Id = ApplicationViewModel.SessionId,
                            UserId = user.Id,
                            WorkingDate = DateTime.Today,
                            LastTime = DateTime.Now,
                            Expire = false
                        };

                        SessionRepository.Context.Sessions.Add(session);
                        SessionRepository.SaveOrUpdateEntities();

                        LoginSuccessfully();
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

        private void LoginSuccessfully()
        {

            //Close LoginView
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
