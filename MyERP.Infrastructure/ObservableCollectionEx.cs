using System;
using System.Windows.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MyERP.Infrastructure
{
    /// <summary>
    /// http://stackoverflow.com/questions/224155/when-clearing-an-observablecollection-there-are-no-items-in-e-olditems
    /// http://geekswithblogs.net/DavidVallens/archive/2011/04/01/when-calling-observablecollection.clear-olditems-is-empty.aspx
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObservableCollectionEx<T> : ObservableCollection<T>
    {
        public ObservableCollectionEx() : base() { }
        public ObservableCollectionEx(IEnumerable<T> collection) : base(collection) { }
        public ObservableCollectionEx(List<T> list) : base(list) { }

        // Some CollectionChanged listeners don't support range actions.
        public Boolean RangeActionsSupported { get; set; }
        protected override void ClearItems()
        {
            if (RangeActionsSupported)
            {
                List<T> oldItems = new List<T>(Items);
                base.ClearItems();
                oldItems.ForEach((oldItem) => base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove,
                    oldItem, 0)));
            }
            else
            {
                while (Count > 0)
                    base.RemoveAt(Count - 1);
            }
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != NotifyCollectionChangedAction.Reset)
                base.OnCollectionChanged(e);
        }

        public ObservableCollectionEx(Boolean rangeActionsSupported = false)
            : base()
        {
            RangeActionsSupported = rangeActionsSupported;
        }

        private CollectionViewSource _view;
        public CollectionViewSource View
        {
            get
            {
                if (_view == null)
                {
                    _view = new CollectionViewSource {Source = this};
                }
                return _view;
            }
        }
    }
}
