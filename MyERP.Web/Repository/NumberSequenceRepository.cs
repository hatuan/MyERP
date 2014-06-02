using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyERP.DataAccess;
using Telerik.OpenAccess;

namespace MyERP.Web
{
    public partial class NumberSequenceRepository 
    {
        public NumberSequenceRepository()
        {
            this.fetchStrategy.LoadWith<NumberSequence>(c => c.Client);
            this.fetchStrategy.LoadWith<NumberSequence>(c => c.Organization);
            this.fetchStrategy.LoadWith<NumberSequence>(c => c.RecModifiedByUser);
            this.fetchStrategy.LoadWith<NumberSequence>(c => c.RecCreatedByUser);
        }
    }

}