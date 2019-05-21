using System;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData;
using MyERP.DataAccess;

namespace MyERP.Web.Odata
{
    public partial class UsersController
    {
        public SingleResult<User> GetUser([FromODataUri] long key)
        {
            return SingleResult.Create(repository.GetAll().Where(c => c.Id == key).AsQueryable());
        }
    }
}
