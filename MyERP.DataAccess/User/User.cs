using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.DomainServices.Server.ApplicationServices;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess
{
    public partial class User
    {
        public UserStatusType StatusType
        {
            get { return (UserStatusType)Status; }
            set
            {
                //intentionally empty
            }
        }
    }
}
