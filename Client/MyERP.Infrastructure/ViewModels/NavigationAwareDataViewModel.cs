using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;

namespace MyERP.Infrastructure.ViewModels
{
    /// <summary>
    /// Navigation-aware ViewModel that provides support for view and event-based data updating.
    /// </summary>
    public abstract class NavigationAwareDataViewModel : NotificationObject, IPartImportsSatisfiedNotification, INavigationAware
    {
        /// <summary>
        /// Triggers data update if a data update condition is satisfied.
        /// Subclasses can implement this to provide their own conditions and specific trigger actions.
        /// </summary>
        protected virtual void TriggerConditionalDataUpdate()
        {
            if (this.IsDataUpdateConditionSatisfied)
            {
                this.OnDataUpdateTriggered();
            }
        }

        /// <summary>
        /// Callback from TriggerConditionalDataUpdate when IsDataUpdateConditionSatisfied is true.
        /// Subclasses should implement this to provide their own actions.
        /// Default implementation is empty.
        /// </summary>
        protected virtual void OnDataUpdateTriggered()
        {

        }
        
        #region IPartImportsSatisfiedNotification
        /// <summary>
        /// Callback when all MEF imports are satisfied.
        /// Subclasses implement this if they need to perform some actions after the viewmodel is completely loaded.
        /// Inherited from IPartImportsSatisfiedNotification.
        /// </summary>
        public virtual void OnImportsSatisfied()
        {

        }
        #endregion

        /// <summary>
        /// The condition that is checked when TriggerConditionalDataUpdate is called.
        /// Subclasses can implement this to provide their own conditions.
        /// </summary>
        protected virtual bool IsDataUpdateConditionSatisfied
        {
            get
            {
                return this.HasViewLoadedOnce && this.DataHasPendingUpdates;
            }
        }

        private bool hasViewLoadedOnce;
        /// <summary>
        /// Gets or sets whether the view belonging to this viewmodel has been navigated to at least once.
        /// Default implementation triggers conditional data update when setting true values.
        /// </summary>
        protected virtual bool HasViewLoadedOnce
        {
            get
            {
                return this.hasViewLoadedOnce;
            }

            set
            {
                this.hasViewLoadedOnce = value;
                if (value)
                {
                    TriggerConditionalDataUpdate();
                }
            }
        }

        private bool dataHasPendingUpdates;
        /// <summary>
        /// Gets or sets whether the data belonging to this viewmodel should be updated later in time.
        /// Default implementation triggers conditional data update when setting true values.
        /// </summary>
        protected virtual bool DataHasPendingUpdates
        {
            get
            {
                return this.dataHasPendingUpdates;
            }

            set
            {
                this.dataHasPendingUpdates = value;
                if (value)
                {
                    TriggerConditionalDataUpdate();
                }
            }
        }

        #region INavigationAware
        /// <summary>
        /// Inherited from INavigationAware.
        /// Default implementation sets HasViewLoadedOnce to true.
        /// Subclasses can override this to implement functionality when the viewmodel is navigated to.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.HasViewLoadedOnce = true;
        }

        /// <summary>
        /// Inherited from INavigationAware.
        /// Shows whether this viewmodel is a navigation target.
        /// Subclasses can override this if they don't want to be navigated to.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        /// <returns>Whether this viewmodel is a navigation target.</returns>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// Inherited from INavigationAware.
        /// Default implementation is empty.
        /// Subclasses can override this to implement functionality when the viewmodel is navigated from.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        #endregion

        private static bool? _isInDesignMode;

        public static bool IsInDesignModeStatic
        {
            get
            {
                if (!_isInDesignMode.HasValue)
                {
#if SILVERLIGHT
                    _isInDesignMode = DesignerProperties.IsInDesignTool;
#else
            var prop = DesignerProperties.IsInDesignModeProperty;
            _isInDesignMode
                = (bool)DependencyPropertyDescriptor
                .FromProperty(prop, typeof(FrameworkElement))
                .Metadata.DefaultValue;
#endif
                }

                return _isInDesignMode.Value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the control is in design mode (running under Blend
        /// or Visual Studio).
        /// </summary>
        [SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "Non static member needed for data binding")]
        public bool IsInDesignMode
        {
            get
            {
                return IsInDesignModeStatic;
            }
        }
    }
}
