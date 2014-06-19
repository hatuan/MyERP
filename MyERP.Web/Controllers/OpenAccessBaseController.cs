using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.OpenAccess;

namespace MyERP.Web.Controllers
{
    public abstract partial class OpenAccessBaseController<TEntity, TContext> : Controller
        where TContext : OpenAccessContext, new()
    {
        protected IOpenAccessBaseRepository<TEntity, TContext> repository;
    }
}