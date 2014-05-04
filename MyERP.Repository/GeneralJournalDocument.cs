
using System;
using MyERP.Infrastructure;

namespace MyERP.DataAccess
{
    public partial class GeneralJournalDocument
    {
        partial void OnCreated()
        {
            this.OrganizationId = (SessionManager.Session["Organization"] as Organization).Id;
            this.ClientId = MyERP.Repositories.WebContext.Current.User.ClientId;
            //this.Id = Guid.NewGuid(); de tu dong tao boi OpenAccess
            this.RecModifiedBy = this.RecCreatedBy = MyERP.Repositories.WebContext.Current.User.Id;
            this.RecModified = this.RecCreated = DateTime.Now;
            this.Status = (int)GeneralJournalDocumentStatusType.Draft;
            this.Version = 1;
        }
    }
}
