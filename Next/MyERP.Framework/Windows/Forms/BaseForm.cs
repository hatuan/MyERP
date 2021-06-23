using System;
using Wisej.Web;

namespace MyERP.Framework.Windows.Forms
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        protected Control FindControl(Control control, string name, bool recursive)
        {
            if (control.Name.Equals(name))
                return control;
            else
            {
                if(recursive)
                {
                    foreach(Control child in control.Controls)
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

        private Form owner = null;

        public Form GetOwner() => this.owner;

        public virtual void SetOwner(Form owner)
        {
            this.owner = owner;
            if(owner != null)
            {
                owner.FormClosed += Owner_FormClosed;
                owner.FormClosing += Owner_FormClosing;
            }
        }

        private void Owner_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Owner_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
