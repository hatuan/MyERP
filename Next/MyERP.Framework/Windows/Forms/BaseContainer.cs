using System;
using Wisej.Web;

namespace MyERP.Framework.Windows.Forms
{
    public partial class BaseContainer : Wisej.Web.UserControl
    {
        public BaseContainer()
        {
            InitializeComponent();
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

        protected T FindControl<T>(Control control, string name, bool recursive) where T : Control
        {
            if (control.Name.Equals(name))
                return control as T;
            else
            {
                if (recursive)
                {
                    foreach (Control child in control.Controls)
                    {
                        T result = FindControl<T>(child, name, recursive);
                        if (result != null)
                            return result;
                    }
                }
                return null;
            }
        }

        protected T FindControl<T>(string name) where T : Control
        {
            return FindControl<T>(this, name, true);
        }

        /// <summary>
        /// Set properties of form
        /// </summary>
        /// <param name="form"></param>
        internal protected virtual void SetPropertyToOwnerForm(BaseForm form)
        {

        }

    }
}
