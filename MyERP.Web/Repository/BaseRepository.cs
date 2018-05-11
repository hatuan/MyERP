// Code is generated by Telerik Data Access Service Wizard
// using WebApiBaseRepository.tt template

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace MyERP.Web
{
    public interface IBaseRepository<TEntity, TContext>
        where TContext : DbContext, new()
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(IPrincipal principal);
        TEntity GetBy(Expression<Func<TEntity, bool>> filter);
        TEntity AddNew(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        TContext DataContext { get; }
    }

    public abstract partial class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity, TContext>
        where TEntity : class where TContext : DbContext, new()
 
    {
        protected TContext dataContext = new TContext();

        public TContext DataContext
        {
            get { return dataContext; }
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            var membershipUser = (MyERPMembershipUser) Membership.GetUser(HttpContext.Current.User.Identity.Name, true);
            if (membershipUser == null)
                throw new NullReferenceException("membershipUser");

            string clause = "ClientId = @0";
            //LambdaExpression expr = System.Linq.Dynamic.DynamicExpression.ParseLambda(typeof(TEntity), typeof(bool), clause, membershipUser.ClientId);
            return dataContext.Set<TEntity>().Where(clause, membershipUser.ClientId);
            
        }

        /// <summary>
        /// Get All TEntity base on principal
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetAll(IPrincipal principal)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            if (membershipUser == null)
                throw new NullReferenceException("membershipUser");

            string clause = "ClientId = @0";
            return dataContext.Set<TEntity>().Where(clause, membershipUser.ClientId);
        }

        public virtual TEntity GetBy(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            var membershipUser = (MyERPMembershipUser)Membership.GetUser(HttpContext.Current.User.Identity.Name, true);
            if (membershipUser == null)
                throw new NullReferenceException("membershipUser");

            string clause = "ClientId = @0";

            TEntity entity = dataContext.Set<TEntity>().Where(clause, membershipUser.ClientId).SingleOrDefault(filter);

            if (entity == null)
                return default(TEntity);

            return entity;
        }

        public virtual TEntity AddNew(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            TEntity attachedEntity = dataContext.Set<TEntity>().Add(entity);
            dataContext.SaveChanges();

            return attachedEntity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            
            //TEntity attachedEntity = dataContext.Set<TEntity>().Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
            dataContext.SaveChanges();

            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            TEntity attachedEntity = dataContext.Set<TEntity>().Remove(entity);
            dataContext.SaveChanges();
        }
    }
}