using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MyERP.Web.Helpers;
using MyERP.Web.Models;
using Telerik.OpenAccess;

namespace MyERP.Web.Controllers
{
    [Authorize]
    public abstract partial class OpenAccessBaseController<TEntity, TContext> : BaseController
        where TContext : OpenAccessContext, new()
    {
        protected IOpenAccessBaseRepository<TEntity, TContext> repository;
    }
}