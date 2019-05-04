using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess
{
    /// <summary>
    /// How to use ?
    /// context.Persons.WithHint("INDEX(XI_DOWNTIME_LOCK)").Where(x => x.ID == ....)
    /// </summary>
    public static class HintExtension
    {
        public static DbSet<T> WithHint<T>(this DbSet<T> set, string hint) where T : class
        {
            HintInterceptor.HintValue = hint;
            return set;
        }
    }
}
