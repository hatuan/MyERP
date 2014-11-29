using System;
using System.Linq;
using MyERP.Helpers;
using Microsoft.Practices.Prism.Modularity;
using System.ComponentModel;

namespace MyERP
{
    public class AtomicModuleLoadOperation
    {
        private const double moduleProgressMutiplier = 0.25;
        private const double dependenciesProgressMutiplier = 0.75;

        private int overallProgress = 0;

        public event EventHandler LoadOperationCompleted;
        public event EventHandler<ProgressChangedEventArgs> LoadOperationProgressChanged;

        private readonly IModuleCatalog moduleCatalog;

        private readonly IModuleManager moduleManager;

        public AtomicModuleLoadOperation(string moduleName, IModuleCatalog moduleCatalog, IModuleManager moduleManager)
        {
            this.ModuleName = moduleName;
            this.moduleCatalog = moduleCatalog;
            this.moduleManager = moduleManager;
        }

        public string ModuleName { get; private set; }

        public void Load()
        {
            EnsureModuleDependencies();
        }

        private void EnsureModuleDependencies()
        {
            var dependencyEnsurer = new DependenciesEnsurer();

            EventHandler<EventArgs> onDependenciesEnsured = null;
            onDependenciesEnsured = new EventHandler<EventArgs>(
                (s, e) =>
                {
                    dependencyEnsurer.EnsureProcessFinished -= onDependenciesEnsured;

                    int currentProgress = (int)(100 * dependenciesProgressMutiplier);

                    this.overallProgress = currentProgress;
                    this.RaiseLoadOperationProgressChanged(overallProgress);
                    LoadModule();
                });

            dependencyEnsurer.EnsureProcessProgressChanged += (s, e) =>
            {
                this.overallProgress = (int)(e.ProgressPercentage * dependenciesProgressMutiplier);
                this.RaiseLoadOperationProgressChanged(overallProgress);
            };

            dependencyEnsurer.EnsureProcessFinished += onDependenciesEnsured;

            dependencyEnsurer.RunEnsureProcessAsync(this.moduleCatalog.Modules.Single(m => m.ModuleName == this.ModuleName).Ref);
        }
  
        private void LoadModule()
        {
            EventHandler<LoadModuleCompletedEventArgs> onModuleLoaded = null;
            onModuleLoaded = new EventHandler<LoadModuleCompletedEventArgs>(
                (sender, args) =>
                {
                    this.moduleManager.LoadModuleCompleted -= onModuleLoaded;
                    this.RaiseLoadOperationCompleted();
                });

            this.moduleManager.LoadModuleCompleted += onModuleLoaded;
            this.moduleManager.ModuleDownloadProgressChanged += OnModuleManagerModuleDownloadProgressChanged;
            this.moduleManager.LoadModule(this.ModuleName);
        }

        void OnModuleManagerModuleDownloadProgressChanged(object sender, ModuleDownloadProgressChangedEventArgs e)
        {
            int previousProgress = (int)(100 * dependenciesProgressMutiplier);
            int currentProgress = (int)(e.ProgressPercentage * moduleProgressMutiplier);

            this.overallProgress = previousProgress + currentProgress;
            this.RaiseLoadOperationProgressChanged(overallProgress);
        }
  
        private void RaiseLoadOperationCompleted()
        {
            this.overallProgress = 100;
            if (this.LoadOperationCompleted != null)
            {
                this.LoadOperationCompleted(this, EventArgs.Empty);
            }
        }

        private void RaiseLoadOperationProgressChanged(int progressPercentage)
        {
            if (this.LoadOperationProgressChanged != null)
            {
                this.LoadOperationProgressChanged(this, new ProgressChangedEventArgs(progressPercentage, null));
            }
        }
    }
}