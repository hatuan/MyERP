using MyERP.BusinessObject.Services;
using System;
using System.Collections.Generic;
using Wisej.Web;


namespace MyERP.Web
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            UserService userService = new UserService();

            string passEncrypt = Cryptography.Encrypt(Cryptography.GetHashKey(txtUserName.Text.Trim() + txtPassword.Text.Trim()), txtPassword.Text.Trim());

            try
            {
                userService.Login(txtUserName.Text.Trim(), passEncrypt);

                Application.Session.IsLogin = true;
                Application.Session.MainPage = "MyERP.Web.MainPage";

                Application.MainPage = new MainPage();
            }
            catch(KeyNotFoundException ex)
            {
                MessageBox.Show("User/Password not found");
            }
        }

        private void LoginPage_Accelerator(object sender, AcceleratorEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Login();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
        }

        private void LoginPage_Activated(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }
    }
}
