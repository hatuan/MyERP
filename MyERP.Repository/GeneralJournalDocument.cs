﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using MyERP.DataAccess.Shared;
using MyERP.Infrastructure;
using MyERP.Repositories;

namespace MyERP.DataAccess
{
    public partial class GeneralJournalDocument
    {
        
        public GeneralJournalSetupRepository GeneralJournalSetupRepository = new GeneralJournalSetupRepository();

        partial void OnCreated()
        {
            this.OrganizationId = (SessionManager.Session["Organization"] as Organization).Id;
            this.ClientId = MyERP.Repositories.WebContext.Current.User.ClientId;

            this.DocumentNo = "";
            GeneralJournalSetupRepository.GetGeneralJournalSetupOfOrganization(OrganizationId,
                setup =>
                {
                    this.NumberSequenceId = setup.GeneralJournalNumberSequenceId;
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
            if (this.EntityState==EntityState.Modified  || this.EntityState == EntityState.New)
            {
                NoSeriesLib.NextNo(this.NumberSequence.NoSeqName, this.NumberSequence.FormatNo, result => this.DocumentNo = result);
            }
        }

        //partial void OnDocumentNoChanged()
        //{
        //    if ((this.EntityState == EntityState.Modified || this.EntityState == EntityState.New) && !this.HasValidationErrors)
        //    {
        //        foreach (var generalJournalLine in this.GeneralJournalLines)
        //        {
        //            generalJournalLine.DocumentNo = this.DocumentNo;
        //        }

        //    }
        //}

        //partial void OnDocumentCreatedChanged()
        //{
        //    if ((this.EntityState == EntityState.Modified || this.EntityState == EntityState.New) && !this.HasValidationErrors)
        //    {
        //        foreach (var generalJournalLine in this.GeneralJournalLines)
        //        {
        //            generalJournalLine.DocumentCreated = this.DocumentCreated;
        //        }
        //    }
        //}

        //partial void OnDocumentPostedChanged()
        //{
        //    if ((this.EntityState == EntityState.Modified || this.EntityState == EntityState.New) && !this.HasValidationErrors)
        //    {
        //        foreach (var generalJournalLine in this.GeneralJournalLines)
        //        {
        //            generalJournalLine.DocumentPosted = this.DocumentPosted;
        //        }
        //    }
        //}

    }
}
