using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyERP.DataAccess;
using Telerik.OpenAccess;

namespace MyERP.Web
{
    public partial class GeneralJournalSetupRepository 
    {
        public GeneralJournalSetupRepository()
        {
            this.fetchStrategy.LoadWith<GeneralJournalSetup>(c => c.Client);
            this.fetchStrategy.LoadWith<GeneralJournalSetup>(c => c.Organization);
            this.fetchStrategy.LoadWith<GeneralJournalSetup>(c => c.RecModifiedByUser);
            this.fetchStrategy.LoadWith<GeneralJournalSetup>(c => c.RecCreatedByUser);

            this.fetchStrategy.LoadWith<GeneralJournalSetup>(c => c.GeneralJournalNumberSequence);
            this.fetchStrategy.LoadWith<GeneralJournalSetup>(c => c.LocalCurrency);
        }
    }

}