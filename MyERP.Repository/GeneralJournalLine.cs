using System;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using MyERP.DataAccess.Shared;
using MyERP.Infrastructure;
using MyERP.Repositories;

namespace MyERP.DataAccess
{
    public partial class GeneralJournalLine
    {
        protected override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }

        partial void OnCreated()
        {
            this.OrganizationId = (SessionManager.Session["Organization"] as Organization).Id;
            this.ClientId = MyERP.Repositories.WebContext.Current.User.ClientId;

            this.DocumentNo = "";
            this.DocumentCreated = Convert.ToDateTime(SessionManager.Session["WorkingDate"]);
            this.DocumentPosted = Convert.ToDateTime(SessionManager.Session["WorkingDate"]);
            this.Description = "";

            this.DocumentType = DataAccess.DocumentType.GeneralJournal;
            this.TransactionType = DataAccess.TransactionType.GeneralJournal;

            this.DebitAmount = this.DebitAmountLcy = this.CreditAmount = this.CreditAmountLcy = 0;

            this.CurrencyExchangeRate = 1;
            this.CurrencyId = Guid.Empty;

            this.LineNo = 0;

            this.RecCreated = DateTime.Now;
            this.RecCreatedBy = MyERP.Repositories.WebContext.Current.User.Id;
            this.RecModified = DateTime.Now;
            this.RecModifiedBy = MyERP.Repositories.WebContext.Current.User.Id;
            this.Version = 1;
        }

        partial void OnGeneralJournalDocumentIdChanged()
        {
            if (this.EntityState == EntityState.New)
            {
                int _numberOfGeneralJournalLineOfDocument =
                    GeneralJournalDocument.GeneralJournalLines.Where(c => c.LineNo%10000 == 0).ToList().Count;
                this.LineNo = _numberOfGeneralJournalLineOfDocument*10000 + 10000;
            }
        }
    }
}
