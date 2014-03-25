using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ServiceModel.DomainServices.Client;
using MyERP.DataAccess;

namespace MyERP.Repositories
{
    [Export]
    public class UserRepository : RepositoryBase
    {
        public void GetUserinfos(Action<IEnumerable<User>> callback)
        {
            this.LoadQuery<User>(this.Context.GetUsersQuery(), callback);
        }

        public void GetUserinfoByUserNameAndPassword(String userName, String pass, Action<User> callback)
        {
            EntityQuery<User> query =
                this.Context.GetUsersQuery().Where(u => u.Name == userName && u.Password == pass);

            this.LoadQuery<User>(query, callback);
        }
    }
}
