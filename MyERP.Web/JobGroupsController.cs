// Code is generated by Telerik Data Access Service Wizard
// using WebApiController.tt template

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MyERP.DataAccess;

namespace MyERP.Web
{
    /// <summary>
    /// Web API Controller for JobGroups entity defined in MyERP.DataAccess.EntitiesModel data model
    /// </summary>
    public partial class JobGroupsController : OpenAccessBaseApiController<MyERP.DataAccess.JobGroup, MyERP.DataAccess.EntitiesModel>
    {
        /// <summary>
        /// Constructor used by the Web API infrastructure.
        /// </summary>
        public JobGroupsController()
        {
            this.repository = new JobGroupRepository();
        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Web API Infrastructure will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public JobGroupsController(IOpenAccessBaseRepository<MyERP.DataAccess.JobGroup , MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // Get all method is implemented in the base class

        /// <summary>
        /// Gets single instance by it's primary key
        /// </summary>
        /// <param name="id">Primary key value to filter by</param>
        /// <returns>Entity instance if a matching entity is found</returns>
        public virtual MyERP.DataAccess.JobGroup Get(String id)
        {
            MyERP.DataAccess.JobGroup entity = repository.GetBy(m => m.Code == id);

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
        public virtual HttpResponseMessage Put(String id, MyERP.DataAccess.JobGroup entity)
        {
                        if (entity == null ||
                id != entity.Code)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            repository.Update(entity);

            return Request.CreateResponse(HttpStatusCode.NoContent);
                    }

        /// <summary>
        /// Deletes an entity by it's ID
        /// </summary>
        /// <param name="id">ID of the entity to delete</param>
        /// <returns>Always HttpStatusCode.OK</returns>
        public virtual HttpResponseMessage Delete(String id)
        {
                        MyERP.DataAccess.JobGroup entity = repository.GetBy(m => m.Code == id);
            if (entity != null)
            {
                repository.Delete(entity);
            }

            // According to the HTTP specification, the DELETE method must be idempotent, 
            // meaning that several DELETE requests to the same URI must have the same effect as a single DELETE request. 
            // Therefore, the method should not return an error code if the product was already deleted.
            return new HttpResponseMessage(HttpStatusCode.OK);
                    }

        /// <summary>
        /// Creates the response sent back to client after a new entity is successfully created.
        /// </summary>
        /// <param name="httpStatusCode">Status code to return</param>
        /// <param name="entityToEmbed">Entity instance to embed in the response</param>
        /// <returns>HttpResponseMessage with the provided status code and object to embed</returns>
        protected override HttpResponseMessage CreateResponse(HttpStatusCode httpStatusCode, MyERP.DataAccess.JobGroup entityToEmbed)
        {
            HttpResponseMessage response = Request.CreateResponse<MyERP.DataAccess.JobGroup>(httpStatusCode, entityToEmbed);

            string uri = Url.Link("DefaultApi", new { id = entityToEmbed.Code });
            response.Headers.Location = new Uri(uri);

            return response;
        }
    }
}
