// Code is generated by Telerik Data Access Service Wizard
// using WebApiBaseRepository.tt template

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Telerik.OpenAccess;
using Telerik.OpenAccess.FetchOptimization;

namespace MyERP.Web
{
    public interface IOpenAccessBaseRepository<TEntity, TContext>
        where TContext : OpenAccessContext, new()
    {
        IQueryable<TEntity> GetAll();
        TEntity GetBy(Expression<Func<TEntity, bool>> filter);
        TEntity AddNew(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }

    public abstract partial class OpenAccessBaseRepository<TEntity, TContext> : IOpenAccessBaseRepository<TEntity, TContext>
        where TContext : OpenAccessContext, new()
    {
        protected TContext dataContext = new TContext();
        protected FetchStrategy fetchStrategy = new FetchStrategy();

        public virtual IQueryable<TEntity> GetAll()
        {
            List<TEntity> allEntities = dataContext.GetAll<TEntity>().ToList();

            List<TEntity> detachedEntities = dataContext.CreateDetachedCopy<List<TEntity>>(allEntities, fetchStrategy);

            return detachedEntities.AsQueryable();
        }

        public virtual TEntity GetBy(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
                throw new ArgumentNullException("filter");

            TEntity entity = dataContext.GetAll<TEntity>().SingleOrDefault(filter);
            if (entity == null)
                return default(TEntity);

            TEntity detachedEntity = dataContext.CreateDetachedCopy(entity, fetchStrategy);

            return detachedEntity;
        }

        public virtual TEntity AddNew(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            TEntity attachedEntity = dataContext.AttachCopy(entity);
            dataContext.SaveChanges();
            TEntity detachedEntity = dataContext.CreateDetachedCopy(attachedEntity, fetchStrategy);

            return detachedEntity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            TEntity attachedEntity = dataContext.AttachCopy(entity);
            dataContext.SaveChanges();
            TEntity detachedEntity = dataContext.CreateDetachedCopy(attachedEntity, fetchStrategy);

            return detachedEntity;
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            TEntity attachedEntity = dataContext.AttachCopy(entity);
            dataContext.Delete(attachedEntity);
            dataContext.SaveChanges();
        }
    }
}