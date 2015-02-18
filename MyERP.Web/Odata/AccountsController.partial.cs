// Code is generated by Telerik Data Access Service Wizard
// using WebApiController.tt template

using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.OData;
using MyERP.DataAccess;

namespace MyERP.Web.Odata
{
    /// <summary>
    /// Web API Controller for Accounts entity defined in MyERP.DataAccess.EntitiesModel data model
    /// </summary>

    public partial class AccountsController 
    {
        /// <summary>
        /// http://localhost:1602/odata/Accounts(guid'103237eb-bbf8-40ae-8ab8-795bf31fd878')
        /// http://localhost:1602/odata/Accounts/(guid'103237eb-bbf8-40ae-8ab8-795bf31fd878')
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SingleResult<Account> GetAccount([FromODataUri] Guid key)
        {
            return SingleResult.Create(repository.GetAll().Where(c => c.Id == key).AsQueryable());
        }

        /// <summary>
        /// Updates single entity.
        /// </summary>
        /// <remarks>Replaces the whole existing entity with the provided one</remarks>
        /// <param name="key">ID of the entity to update</param>
        /// <param name="entity">Entity with the new updated values</param>
        /// <returns>HttpStatusCode.BadRequest if ID parameter does not match the ID value of the entity,
        /// or HttpStatusCode.NoContent if the operation was successful</returns>
        public IHttpActionResult PutAccount([FromODataUri] Guid key, MyERP.DataAccess.Account entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (entity == null || key != entity.Id)
                return BadRequest();

            repository.Update(entity);

            return Updated(entity);
        }

        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] Guid key, Delta<MyERP.DataAccess.Account> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Account entity = repository.GetBy(c => c.Id == key);
            if (entity == null)
            {
                return NotFound();
            }

            patch.Patch(entity);

            try
            {
                repository.Update(entity);
            }
            catch (Telerik.OpenAccess.Exceptions.OptimisticVerificationException e)
            {
                if (repository.GetBy(c => c.Id == key) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(entity);
        }

        /// <summary>
        /// Deletes an entity by it's ID
        /// </summary>
        /// <param name="key">ID of the entity to delete</param>
        /// <returns>Always HttpStatusCode.OK</returns>
        public IHttpActionResult DeleteAccount([FromODataUri] Guid key)
        {
            MyERP.DataAccess.Account entity = repository.GetBy(m => m.Id == key);
            if (entity != null)
            {
                repository.Delete(entity);
            }

            // According to the HTTP specification, the DELETE method must be idempotent, 
            // meaning that several DELETE requests to the same URI must have the same effect as a single DELETE request. 
            // Therefore, the method should not return an error code if the product was already deleted.
            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Creates a new entity based on the provided data
        /// </summary>
        /// <param name="entity">The new entity to be created</param>
        /// <returns>HTTP Status:
        /// - Accepted when operation is successful or 
        /// - MethodNotAllowed if the operation is disabled for this entity or
        /// - BadRequest if the provided entity is NULL</returns>
        public IHttpActionResult PostAccount(MyERP.DataAccess.Account entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MyERP.DataAccess.Account newEntity = repository.AddNew(entity);

            return Created(newEntity);
        }
    }
}
