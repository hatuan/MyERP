using System;
using System.Linq;
using System.ServiceModel.DomainServices.Client;

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
            this.RecModifiedById = this.RecCreatedById = MyERP.Repositories.WebContext.Current.User.Id;
            this.RecModified = this.RecCreated = DateTime.Now;
            this.Status = (int)AccountStatusType.Active;
            this.Version = 1;
        }
    }
}
