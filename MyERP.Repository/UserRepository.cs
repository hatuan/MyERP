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
        public void GetUserinfos(Action<IEnumerable<Userinfo>> callback)
        {
            this.LoadQuery<Userinfo>(this.Context.GetUserinfoSetQuery(), callback);
        }

        public void GetUserinfoByUserNameAndPassword(String userName, String pass, Action<Userinfo> callback)
        {
            EntityQuery<Userinfo> query =
                this.Context.GetUserinfoSetQuery().Where(u => u.User_Name == userName && MyERP.Global.Cryptography.Decrypt(u.Pass, null) == pass);

            this.LoadQuery<Userinfo>(query, callback);
        }
    }
}
