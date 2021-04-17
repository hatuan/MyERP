using System;
using Wisej.Web;


namespace MyERP.CommonUI
{
    public partial class PageTemplate : Page
    {
        public PageTemplate()
        {
            InitializeComponent();
        }

        private void btnNav_Click(object sender, EventArgs e)
        {
            ExecNavPopup();
        }

        protected virtual void ExecNavPopup()
        {

        }

        private void PageTemplate_Load(object sender, EventArgs e)
        {
            lblLoginUser.Text = Application.Session.LoginUser;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            var asm = System.Reflection.Assembly.Load(System.IO.File.ReadAllBytes(Application.MapPath("\\bin\\MyERP.Web.dll")));
            var type = asm.GetType("MyERP.Web.MainPage");
            Object instance = Activator.CreateInstance(type);

            Application.MainPage = instance as Page;
        }

        private void btnPersonInfo_Click(object sender, EventArgs e)
        {
            ExecPersonInfoPopup();
        }

        protected virtual void ExecPersonInfoPopup()
        {

        }
    }
}
