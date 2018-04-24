using System.Data.Entity;
using System.Web.Mvc;

namespace MyERP.Web.Controllers
{
    [Authorize]
    public abstract partial class EntityBaseController<TEntity, TContext> : BaseController
        where TContext : DbContext, new()
    {
        protected IBaseRepository<TEntity, TContext> repository;
    }
}