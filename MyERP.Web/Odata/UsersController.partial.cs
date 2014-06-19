using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using MyERP.DataAccess;

namespace MyERP.Web.Odata
{
    public partial class UsersController
    {
        public SingleResult<User> GetUser([FromODataUri] Guid key)
        {
            return SingleResult.Create(repository.GetAll().Where(c => c.Id == key).AsQueryable());
        }
    }
}
