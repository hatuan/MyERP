using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.Practices.Prism.Modularity;
using System.ComponentModel;

namespace MyERP
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class AtomicModuleLoader
    {
        private LinkedList<AtomicModuleLoadOperation> operations = new LinkedList<AtomicModuleLoadOperation>();
        private readonly IList<string> loadedModules = new List<string>();
        private readonly IModuleCatalog moduleCatalog;
        private readonly IModuleManager moduleManager;
        private string priorityModuleName;

        public event EventHandler PriorityOperationCompleted;
        public event EventHandler<ProgressChangedEventArgs> PriorityOperationProgressChanged;

        [ImportingConstructor]
        public AtomicModuleLoader(IModuleCatalog catalog, IModuleManager moduleManager)
        {
            this.moduleCatalog = catalog;
            this.moduleManager = moduleManager;
        }
                        
        public void ProcessQueueAsync()
        {
            this.ProcessNext();
        }
  
        private void ProcessNext()
        {
            AtomicModuleLoadOperation operationToLoad = null;
            if (this.IsQueueEmpty)
            {
                return;
            }

            if (this.priorityModuleName != string.Empty && IsModuleInQueue(this.priorityModuleName))
            {
                operationToLoad = this.operations.Single(o => o.ModuleName == this.priorityModuleName);
                this.operations.Remove(operationToLoad);
            }
            else
            {
                operationToLoad = this.DequeueOperation();
            }

            operationToLoad.LoadOperationCompleted += OnLoadOperationCompleted;
            operationToLoad.LoadOperationProgressChanged += OnLoadOperationProgressChanged;
            operationToLoad.Load();
        }

        void OnLoadOperationProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (this.PriorityOperationProgressChanged != null)
            {
                this.PriorityOperationProgressChanged(this, e);
            }
        }

        void OnLoadOperationCompleted(object sender, EventArgs e)
        {
            AtomicModuleLoadOperation loadOperation = sender as AtomicModuleLoadOperation;

            loadOperation.LoadOperationCompleted -= OnLoadOperationCompleted;

            this.loadedModules.Add(loadOperation.ModuleName);

            // raise event that the priority operation is completed
            if (loadOperation.ModuleName == priorityModuleName)
            {
                priorityModuleName = string.Empty;

                if (this.PriorityOperationCompleted != null)
                {
                    this.PriorityOperationCompleted(this, EventArgs.Empty);
                }
            }
            
            this.ProcessNext();
        }

        public void ProcessWithPriority(string uri)
        {
            this.priorityModuleName = uri;
        }

        /// <summary>
        /// Adds a module to load to the load queue.
        /// It will be loaded after all the modules before it have been loaded.
        /// If isImportant is true, then the module will be put in front of the queue, before all the other modules.
        /// </summary>
        /// <param name="moduleName">The module name.</param>
        /// <param name="isImportant">Indicates if the operation is important.</param>
        public void AddLoadOperation(string moduleName)
        {
            //TODO: refactor this ?
            if (!IsModuleInQueue(moduleName))
            {
                if (!IsModuleLoaded(moduleName))
                {
                    operations.AddLast(new AtomicModuleLoadOperation(moduleName, this.moduleCatalog, this.moduleManager));
                }
            }
        }

        public bool IsModuleLoaded(string moduleName)
        {
            return this.loadedModules.Contains(moduleName);
        }

        private bool IsModuleInQueue(string moduleName)
        {
            int count = 0;
            lock (operations)
            {
                count = operations.Count(op => op.ModuleName == moduleName);
            }
            if (count > 1)
            {
                throw new InvalidOperationException("Queue should not contain an element more than once.");
            }

            var isInQueue = count != 0;
            return isInQueue;
        }

        private AtomicModuleLoadOperation DequeueOperation()
        {
            if (this.IsQueueEmpty)
            {
                return null;
            }
            var operation = operations.First.Value;
            operations.RemoveFirst();
            return operation;
        }

        private bool IsQueueEmpty
        {
            get
            {
                return operations.Count == 0;
            }
        }
    }
}