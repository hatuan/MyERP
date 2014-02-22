using System;
using Microsoft.Practices.Prism.Events;

namespace MyERP.Infrastructure
{
    public class RadWindowShowEvent : CompositePresentationEvent<MyRadWindowEventParameters> { }

    public class MyRadWindowEventParameters
    {
        public object Content { get; set; }
        public string ViewName { get; set; }
        public Action Callback { get; set; }
    }
}
