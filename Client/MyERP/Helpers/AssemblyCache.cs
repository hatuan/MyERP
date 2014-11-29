using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Dynamic.Utils;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Resources;

namespace MyERP.Helpers
{
    public static class AssemblyCache
    {
        private static readonly List<string> loadedAssemblyNamesCache = new List<string>();

        internal static void Initialize()
        {
            // populate the assembly names cache with the assemblies inside this XAP
            foreach (AssemblyPart ap in Deployment.Current.Parts)
            {
                StreamResourceInfo sri = Application.GetResourceStream(new Uri(ap.Source, UriKind.Relative));
                Assembly a = new AssemblyPart().Load(sri.Stream);
                loadedAssemblyNamesCache.Add(a.FullName.Split(',').First());
            }
            
            // populate the assembly names cache with the assembly parts referred from thisXAP
            foreach (var ep in Deployment.Current.ExternalParts)
            {
                string assemblyName = ep.Source.OriginalString.Replace(".zip", "");
                loadedAssemblyNamesCache.Add(assemblyName);
            }
        }

        internal static bool HasLoadedAssembly(string assemblyName)
        {
            return loadedAssemblyNamesCache.Contains(assemblyName);
        }

        internal static void AddAssemblyName(string assemblyName)
        {
            loadedAssemblyNamesCache.Add(assemblyName);
        }
    }
}
