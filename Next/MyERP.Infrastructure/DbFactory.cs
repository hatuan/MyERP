using MyERP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Infrastructure
{
    //reference : https://chsakell.com/2015/02/15/asp-net-mvc-solution-architecture-best-practices/
    public class DbFactory : Disposable, IDbFactory
    {
        EntitiesModel dbContext;

        public EntitiesModel Init()
        {
            return dbContext ?? (dbContext = new EntitiesModel());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
