using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wisej.Web;

namespace MyERP.Framework.Windows.Forms
{
    public class WindowsManager
    {
        private ModuleInfoList moduleList = new ModuleInfoList();

        private void LoadModuleList()
        {
            Assembly asm = GetType().Assembly;
            using(Stream stream = asm.GetManifestResourceStream("MyERP.Framework.Windows.ModuleList.xml"))
            {
                moduleList.Clear();
                moduleList.LoadFromStream(stream);
                stream.Close();
            }
        }

        internal void Init()
        {
            LoadModuleList();
        }

        public void GetModuleType(string typeName, out ModuleInfo moduleInfo, out Type type)
        {
            moduleInfo = moduleList[typeName];
            var asm = System.Reflection.Assembly.Load(System.IO.File.ReadAllBytes(Application.MapPath(String.Format("\\{0}\\{1}", "bin", moduleInfo.AssemblyName))));
            type = asm.GetType(moduleInfo.TypeName);
        }
    }
}
