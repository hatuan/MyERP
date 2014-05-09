using System;
using MyERP.Infrastructure;
using MyERP.Repositories;
using MyERP.DataAccess.Shared;

namespace MyERP.DataAccess
{
    public partial class GeneralJournalDocument
    {
        GeneralJournalSetupRepository GeneralJournalSetupRepository = new GeneralJournalSetupRepository();

        partial void OnCreated()
        {
            this.OrganizationId = (SessionManager.Session["Organization"] as Organization).Id;
            this.ClientId = MyERP.Repositories.WebContext.Current.User.ClientId;

            this.DocumentNo = "";
            GeneralJournalSetupRepository.GetGeneralJournalSetupOfOrganization(OrganizationId, setup =>
            {
                //this.NumberSequence = setup.GeneralJournalNumberSequence;
                this.NumberSequenceId = setup.GeneralJournalNumberSequenceId;
                
                //String formatNo = this.NumberSequence.FormatNo;

                //NoSeriesLib.NextNo(NumberSequence.NoSeqName, formatNo, result => this.DocumentNo = result);
            });

            this.DocumentCreated = Convert.ToDateTime(SessionManager.Session["WorkingDate"]);
            this.DocumentPosted = Convert.ToDateTime(SessionManager.Session["WorkingDate"]);
            this.Description = "";
            this.TotalCreditAmount = 0;
            this.TotalCreditAmountLcy = 0;
            this.TotalDebitAmount = 0;
            this.TotalDebitAmountLcy = 0;
            this.DocumentType = DataAccess.DocumentType.GeneralJournal;
            this.TransactionType = DataAccess.TransactionType.GeneralJournal;
            this.CurrencyExchangeRate = 1;
            this.CurrencyId = Guid.Empty;
            this.RecCreated = DateTime.Now;
            this.RecCreatedBy = MyERP.Repositories.WebContext.Current.User.Id;
            this.RecModified = DateTime.Now;
            this.RecModifiedBy = MyERP.Repositories.WebContext.Current.User.Id;
            this.Status = (int)GeneralJournalDocumentStatusType.Draft;
            this.Version = 1;
        }

        partial void OnNumberSequenceIdChanged()
        {
            System.Diagnostics.Debug.WriteLine(String.Format("IsDeserializing = {0}", this.IsDeserializing));
            if (!this.IsDeserializing)
            {
                NoSeriesLib.NextNo(NumberSequence.NoSeqName, NumberSequence.FormatNo, result => this.DocumentNo = result);
            }
        }
    }
}
