using MyERP.Framework.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Framework
{
    public class MyERPManager
    {
        private MyERPManager()
        {
            windows = new WindowsManager();
        }

        private WindowsManager windows;

        public WindowsManager Windows => windows;

        private static MyERPManager instance;

        public static MyERPManager GetInstance()
        {
            if(instance == null)
            {
                instance = new MyERPManager();
                instance.Windows.Init();
            }

            return instance;
        }

    }
}
