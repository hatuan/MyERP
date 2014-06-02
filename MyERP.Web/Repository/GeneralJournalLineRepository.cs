using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyERP.DataAccess;
using Telerik.OpenAccess;

namespace MyERP.Web
{
    public partial class GeneralJournalLineRepository 
    {
        public GeneralJournalLineRepository()
        {
            this.fetchStrategy.LoadWith<GeneralJournalLine>(c => c.Client);
            this.fetchStrategy.LoadWith<GeneralJournalLine>(c => c.Organization);
            this.fetchStrategy.LoadWith<GeneralJournalLine>(c => c.RecModifiedByUser);
            this.fetchStrategy.LoadWith<GeneralJournalLine>(c => c.RecCreatedByUser);

            this.fetchStrategy.LoadWith<GeneralJournalLine>(c => c.Account);
            this.fetchStrategy.LoadWith<GeneralJournalLine>(c => c.CorAccount);
            this.fetchStrategy.LoadWith<GeneralJournalLine>(c => c.Currency);
            this.fetchStrategy.LoadWith<GeneralJournalLine>(c => c.BusinessPartner);
            this.fetchStrategy.LoadWith<GeneralJournalLine>(c => c.Job);
            //this.fetchStrategy.LoadWith<GeneralJournalLine>(c => c.FixAsset);
        }
    }

}