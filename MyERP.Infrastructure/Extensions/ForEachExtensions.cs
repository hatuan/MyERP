using System;
using System.Collections.Generic;


namespace MyERP.Infrastructure.Extensions
{
    public static class ForEachExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            foreach (var item in enumeration)
            {
                action(item);
            }
        }
    }
}
