using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyERP.DataAccess;
using Telerik.OpenAccess;

namespace MyERP.Web
{
    public partial class UserRepository 
    {
        public UserRepository()
        {
            this.fetchStrategy.LoadWith<User>(c => c.Client);
            this.fetchStrategy.LoadWith<User>(c => c.Organization);
          
        }
    }

}