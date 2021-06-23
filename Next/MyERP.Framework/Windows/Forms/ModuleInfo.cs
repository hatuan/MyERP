using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyERP.Framework.Windows.Forms
{
    public class ModuleInfo
    {
        public string TypeName { get; set; }
        public string AssemblyName { get; set; }
        public string KindName { get; set; }
    }

    public class ModuleInfoList : Dictionary<string, ModuleInfo>
    {
        public ModuleInfoList()
        {
            items = new Dictionary<string, ModuleInfo>(StringComparer.CurrentCultureIgnoreCase);
        }

        Dictionary<string, ModuleInfo> items;

        public void LoadFromStream(Stream stream)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);
            this.Clear();

            XmlNodeList modules = xmlDoc.DocumentElement.SelectNodes("module");
            for (int i = 0; i < modules.Count; i++)
            {
                XmlElement elm = (XmlElement)modules[i];
                string _assembly = elm.GetAttribute("assembly");
                string _type = elm.GetAttribute("type");
                string _kind = elm.GetAttribute("kind");
                string _namespaces = elm.GetAttribute("namespace");

                ModuleInfo modInfo = new ModuleInfo();
                modInfo.AssemblyName = _assembly;
                modInfo.TypeName = String.Format("{0}.{1}", _namespaces, _type);
                modInfo.KindName = _kind;

                this.Add(_type, modInfo);
            }
        }
    }
}
