// Code is generated by Telerik Data Access Service Wizard
// using WebApiController.tt template

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Microsoft.AspNet.OData;
using MyERP.DataAccess;

namespace MyERP.Web.Odata
{
    /// <summary>
    /// Web API Controller for Organizations entity defined in MyERP.DataAccess.EntitiesModel data model
    /// </summary>
    public partial class OrganizationsController 
    {
        public SingleResult<Organization> GetOrganization([FromODataUri] long key)
        {
            return SingleResult.Create(repository.GetAll().Where(c => c.Id == key).AsQueryable());
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">Organization 's ID of current Organization</param>
        /// <returns></returns>
        public Organization GetAllOrganization([FromODataUri] long key)
        {
            Organization organization = repository.GetBy(o => o.Id == key);
            if (organization == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return repository.GetAll().FirstOrDefault(c => c.ClientId == organization.ClientId && c.Code == "*");
        }
    }
}
