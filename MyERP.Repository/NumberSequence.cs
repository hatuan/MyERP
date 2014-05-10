using System;
using MyERP.Infrastructure;

namespace MyERP.DataAccess
{
    public partial class NumberSequence
    {
        partial void OnCreated()
        {
            this.OrganizationId = (SessionManager.Session["Organization"] as Organization).Id;
            this.ClientId = MyERP.Repositories.WebContext.Current.User.ClientId;
            this.Code = "";
            this.Name = "";
            this.NoSeqName = String.Format("seq_no_series_{0}", Id.ToString().Replace("-", "_"));
            this.FormatNo = "";
            this.StartingNo = 0;
            this.EndingNo = 0;
            this.CurrentNo = 0;
            this.RecModifiedBy = this.RecCreatedBy = MyERP.Repositories.WebContext.Current.User.Id;
            this.RecModified = this.RecCreated = DateTime.Now;
            this.Status = (int)NumberSequenceStatusType.Active;
            this.Version = 1;
        }
    }
}
