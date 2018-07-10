using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Ext.Net;
using MyERP.DataAccess;

namespace MyERP.Web
{
    public partial class PosHeaderRepository
    {
        public Int64 GetDefaultLocationId()
        {
            return 0;
        }

        public Int64 GetDefaultBusinessPartnerId()
        {
            return 0;
        }

        public Int64 GetDocSequenceId()
        {
            return 0;
        }
    }

}