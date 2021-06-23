
using System;
using Wisej.Web;
using MyERP.Framework.Windows.Forms;

namespace MyERP.Web
{
    public partial class MainPage : BasePage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public static void ShowMainPage()
        {
            MainPage instance = new MainPage();
            Application.MainPage = instance;
        }
    }
}
