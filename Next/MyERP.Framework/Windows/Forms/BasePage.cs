using System;
using System.Reflection;
using Wisej.Web;


namespace MyERP.Framework.Windows.Forms
{
    public partial class BasePage : Page
    {
        public BasePage()
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
            ModuleInfo moduleInfo;
            Type type;
            MyERPManager.GetInstance().Windows.GetModuleType("MainPage", out moduleInfo, out type);
            type.InvokeMember("ShowMainPage", BindingFlags.InvokeMethod, null, null, null);
        }

        private void btnPersonInfo_Click(object sender, EventArgs e)
        {
            ExecPersonInfoPopup();
        }

        protected virtual void ExecPersonInfoPopup()
        {
        }

        protected Control FindControl(Control control, string name, bool recursive)
        {
            if (control.Name.Equals(name))
                return control;
            else
            {
                if (recursive)
                {
                    foreach (Control child in control.Controls)
                    {
                        Control result = FindControl(child, name, recursive);
                        if (result != null)
                            return result;
                    }
                }
                return null;
            }
        }

        protected Control FindControl(string name)
        {
            return FindControl(this, name, true);
        }
    }
}
