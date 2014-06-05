using System;
using System.ComponentModel.Composition;
using System.Text;
using System.Windows;
using System.Windows.Input;
using MyERP.Infrastructure;
using Microsoft.Practices.Prism.Regions;
using MyERP.Repositories;
using MyERP.ViewModels;
using DelegateCommand = Microsoft.Practices.Prism.Commands.DelegateCommand;
using ViewModelBase = MyERP.Infrastructure.ViewModelBase;


namespace MyERP.Modules.User.ViewModels
{
    [Export]
    public class LoginViewModel : ViewModelBase, ICloseable
    {
        public LoginViewModel()
        {
            this.LoginCommand = new DelegateCommand(OnLoginCommandExecuted, LoginCommandCanExecute);
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

        private bool _isBusyLogin = false;
        public bool IsBusyLogin {
            get { return _isBusyLogin; }
            set
            {
                _isBusyLogin = value;
                ((DelegateCommand)LoginCommand).RaiseCanExecuteChanged();
            } 
        }

        private bool LoginCommandCanExecute()
        {
            return !IsBusyLogin;
        }

        private void OnLoginCommandExecuted()
        {
            string passEncrypt = Cryptography.Encrypt(Cryptography.GetHashKey(UserName + Password), Password);
            
            IsBusyLogin = true;

            UserRepository.Auth(UserName, passEncrypt, success =>
            {
                if (success)
                {
                    RemoveError("Password", PASSWORD_ERROR);

                    SessionManager.Session.Clear();
                    SessionManager.Session.Add("SessionId", Guid.NewGuid());

                    //Set AuthHeader 
                    var buffer = Encoding.UTF8.GetBytes(String.Format("{0}:{1}", UserName, passEncrypt));
                    UserRepository.SetAuthHeader(String.Format("Basic {0}", Convert.ToBase64String(buffer)));
                    
                    UserRepository.GetUserByUserName(UserName,
                            user =>
                            {
                                SessionManager.Session.Add("User", user);
                                
                                //Neu User khong duoc phan quyen vao client nao thi thoat
                                //va thong bao user khong duoc phan quyen vao mot Client nao
                                if (user.ClientId == Guid.Empty) return;

                                SessionManager.Session.Add("Client", user.Client);
                                SessionManager.Session.Add("ClientId", user.ClientId);
                                LoginSuccessfully();
                            });
                }
                else AddError("Password", PASSWORD_ERROR, false);

                IsBusyLogin = false;
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
                this.OnPropertyChanged("UserName");
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
                this.OnPropertyChanged("Password");
            }
        }

        private void LoginSuccessfully()
        {
            //Navigate to PreferenceView
            var region = this.RegionManager.Regions[RegionNames.UserWindowRegion];
            region.RequestNavigate("PreferenceView");
            
        }

        public event EventHandler<EventArgs> RequestClose;
    }
}
