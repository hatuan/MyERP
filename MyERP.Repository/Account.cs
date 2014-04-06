using System;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using MyERP.Repositories;

namespace MyERP.DataAccess
{
    public partial class Account
    {
        partial void OnCreated()
        {
            this.Id = Guid.NewGuid();
            this.Code = "";
            this.Name = "";
            this.ParentAccountId = null;
            this.CurrencyId = null;
            this.ArAp = false;
            this.Detail = false;
            this.Level = 0;
            this.RecCreated = DateTime.Now;
            this.RecModified = DateTime.Now;
            this.Status = (int)AccountStatusType.Active;
            this.Version = 1;
        }
    }
}
