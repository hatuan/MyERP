using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Resources;
using System.Xml.Linq;

namespace MyERP.Helpers
{
    public class DependenciesEnsurer
    {
        private string pathToXap;

        public event EventHandler<EventArgs> EnsureProcessFinished;
        public event EventHandler<ProgressChangedEventArgs> EnsureProcessProgressChanged;

        /// <summary>
        /// Loads each of the external part with name from the filenames param
        /// </summary>
        /// <param name="fileNames">An enumerable of external part file names, e.g. Telerik.Window.Controls.zip</param>
        private void LoadExternalParts(IEnumerable<string> fileNames, Action<int> loadProgressCallback)
        {
            foreach (string fileName in fileNames)
            {
                //if (loadedAssemblyNamesCache.Contains(fileName.Replace(".zip", ""))) continue;
                if (AssemblyCache.HasLoadedAssembly(fileName.Replace(".zip", ""))) continue;

                Stream fileStream = SynchronousDownloader.DownloadFile(new Uri(fileName, UriKind.Relative)) as Stream;

                var assemblyStream = Application.GetResourceStream(new StreamResourceInfo(fileStream, "application / binary"), new Uri(fileName.Replace(".zip", ".dll"), UriKind.Relative)).Stream;
                Deployment.Current.Dispatcher.BeginInvoke(new Action(() =>
                                                                     {
                                                                         var part = new AssemblyPart();
                                                                         var loadedAssembly = part.Load(assemblyStream);
                                                                         AssemblyCache.AddAssemblyName(loadedAssembly.FullName.Split(',').First());
                                                                     }));
                int filesDownloaded = fileNames.ToList().IndexOf(fileName) + 1;
                int filesCount = fileNames.Count();

                int progress = (int)(filesDownloaded / (double)filesCount * 100);

                loadProgressCallback(progress);
            }
        }

        public void RunEnsureProcessAsync(string pathToXap)
        {
            this.pathToXap = pathToXap;
            var worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;

            worker.ProgressChanged += OnWorkerProgressChanged;
            worker.RunWorkerCompleted += OnWorkerRunWorkerCompleted;
            worker.DoWork += OnWorkerDoWork;
            worker.RunWorkerAsync();
        }

        void OnWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.EnsureProcessProgressChanged != null)
            {
                this.EnsureProcessProgressChanged(this, e);
            }
        }

        private void OnWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            string manifestString = SynchronousDownloader.DownloadString(new Uri(string.Concat(pathToXap.Replace(".xap", ""), "/", "AppManifest.xaml"), UriKind.Relative));
            XDocument xDoc = XDocument.Parse(manifestString);
            var fileNames = xDoc.Descendants().Where(xElement => xElement.Name.LocalName.Equals("ExtensionPart")).Select(xElement => xElement.LastAttribute.Value).ToList();
            
            this.LoadExternalParts(fileNames, (loadProgress) =>
            {
                worker.ReportProgress(loadProgress);
            });
        }

        private void OnWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            worker.RunWorkerCompleted -= OnWorkerRunWorkerCompleted;
            worker.ProgressChanged -= OnWorkerProgressChanged;
            worker.DoWork -= OnWorkerDoWork;

            if (this.EnsureProcessFinished != null)
            {
                this.EnsureProcessFinished(this, EventArgs.Empty);
            }
        }
    }
}