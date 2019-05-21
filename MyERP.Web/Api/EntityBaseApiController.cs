using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyERP.Web.Api
{
    public abstract partial class EntityBaseApiController<TEntity, TContext> : BaseApiController
        where TContext : DbContext, new()
        where TEntity : class
    {
        protected IBaseRepository<TEntity, TContext> repository;

        public virtual IQueryable<TEntity> Get()
        {
            var allEntities = repository.GetAll(User);
            return allEntities;
        }

        /// <summary>
        /// Gets single instance by it's primary key
        /// </summary>
        /// <param name="id">Primary key value to filter by</param>
        /// <returns>Entity instance if a matching entity is found</returns>
        public virtual TEntity Get(long id)
        {
            string clause = "Id = @0";
            TEntity entity = repository.Get().Where(clause, id).FirstOrDefault();

            if (entity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return entity;
        }

        /// <summary>
        /// Updates single entity.
        /// </summary>
        /// <remarks>Replaces the whole existing entity with the provided one</remarks>
        /// <param name="id">ID of the entity to update</param>
        /// <param name="entity">Entity with the new updated values</param>
        /// <returns>HttpStatusCode.BadRequest if ID parameter does not match the ID value of the entity,
        /// or HttpStatusCode.NoContent if the operation was successful</returns>
        public virtual HttpResponseMessage Put(long id, TEntity entity)
        {
            dynamic _entity = entity;
            if (entity == null || id != _entity.Id)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            repository.Update(entity);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Creates a new entity based on the provided data
        /// </summary>
        /// <param name="entity">The new entity to be created</param>
        /// <returns>HTTP Status:
        /// - Accepted when operation is successful or 
        /// - MethodNotAllowed if the operation is disabled for this entity or
        /// - BadRequest if the provided entity is NULL</returns>
        public virtual HttpResponseMessage Post(TEntity entity)
        {
            if (entity == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //TODO: should we check if the incomming entity is not an existing one?
            TEntity newEntity = repository.AddNew(entity);

            var response = CreateResponse(HttpStatusCode.Accepted, newEntity);
            return response;
        }

        /// <summary>
        /// Deletes an entity by it's ID
        /// </summary>
        /// <param name="id">ID of the entity to delete</param>
        /// <returns>Always HttpStatusCode.OK</returns>
        public virtual HttpResponseMessage Delete(long id)
        {
            string clause = "Id = @0";
            TEntity entity = repository.Get().Where(clause, id).FirstOrDefault();

            if (entity != null)
            {
                repository.Delete(entity);
            }

            // According to the HTTP specification, the DELETE method must be idempotent, 
            // meaning that several DELETE requests to the same URI must have the same effect as a single DELETE request. 
            // Therefore, the method should not return an error code if the product was already deleted.
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        protected virtual HttpResponseMessage CreateResponse(HttpStatusCode httpStatusCode, TEntity entityToEmbed)
        {
            HttpResponseMessage response = Request.CreateResponse<TEntity> (httpStatusCode, entityToEmbed);
            dynamic _entityToEmbed = entityToEmbed;
            string uri = Url.Link("DefaultApi", new { id = _entityToEmbed.Id });
            response.Headers.Location = new Uri(uri);

            return response;
        }
    }
}
