using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyERP.DataAccess;
using Telerik.OpenAccess;

namespace MyERP.Web
{
    public partial class OrganizationRepository 
    {
        public OrganizationRepository()
        {
            this.fetchStrategy.LoadWith<Organization>(c => c.Client);
            this.fetchStrategy.LoadWith<Organization>(c => c.RecModifiedByUser);
            this.fetchStrategy.LoadWith<Organization>(c => c.RecCreatedByUser);
        }
    }

}