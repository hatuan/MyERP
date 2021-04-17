using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Infrastructure.Repositories
{
    public interface IBaseRepository<TEntity, TContext>
        where TContext : DbContext, new()
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Int64 clientId);
        TEntity GetBy(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            string[] includePaths = null);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            string[] includePaths = null,
            int? page = 0,
            int? pageSize = null,
            params SortExpression<TEntity>[] sortExpressions);
        TEntity AddNew(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        TContext DataContext { get; }
    }
}
