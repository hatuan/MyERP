using System;

namespace MyERP.Infrastructure
{
    public interface ICloseable
    {
        event EventHandler<EventArgs> RequestClose;
    }
}
