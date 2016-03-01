using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyERP.DataAccess.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// http://docs.telerik.com/data-access/getting-started/getting-started-fluent-mapping-overview
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
