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
        public void GetUsers(Action<IEnumerable<User>> callback)
        {
            this.LoadQuery<User>(this.Context.GetUsersQuery(), callback);
        }

        public void GetUserByUserNameAndPassword(String userName, String pass, Action<User> callback)
        {
            EntityQuery<User> query =
                this.Context.GetUsersQuery().Where(u => u.Name == userName && u.Password == pass);

            this.LoadQuery<User>(query, callback);
        }

        public void GetUserByUserName(String userName, Action<User> callback)
        {
            EntityQuery<User> query =
                this.Context.GetUsersQuery().Where(u => u.Name == userName);

            this.LoadQuery<User>(query, callback);
        }
    }
}
