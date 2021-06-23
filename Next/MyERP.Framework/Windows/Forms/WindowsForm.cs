using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wisej.Web;

namespace MyERP.Framework.Windows.Forms
{
    public class WindowsForm<T> : WindowsForm where T: BaseContainer
    {
        public T Root
        {
            get
            {
                return this.Controls[0] as T;
            }
        }
    }

    public class WindowsForm : BaseForm
    {
        private BaseContainer rootControl;

        public BaseContainer RootControl => rootControl;

        internal void SetRootControl(BaseContainer rootControl)
        {
            this.rootControl = rootControl;

            SuspendLayout();
            rootControl.Dock = DockStyle.Fill;
            rootControl.Location = new System.Drawing.Point(0, 0);
            rootControl.SetPropertyToOwnerForm(this);
            Controls.Add(rootControl);
            ResumeLayout();
        }

        protected WindowsManager GetWindows()
        {
            return MyERPManager.GetInstance().Windows;
        }
    }
}
