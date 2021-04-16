using System;
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
            Application.Session.LoginUser = txtUserName.Text;
            Application.Session.IsLogin = true;
            Application.Session.MainPage = "MyERP.Web.MainPage";

            Application.MainPage = new MainPage();
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
