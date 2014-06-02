using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyERP.DataAccess;
using Telerik.OpenAccess;

namespace MyERP.Web
{
    public partial class GeneralJournalDocumentRepository 
    {
        public GeneralJournalDocumentRepository()
        {
            this.fetchStrategy.LoadWith<GeneralJournalDocument>(c => c.Client);
            this.fetchStrategy.LoadWith<GeneralJournalDocument>(c => c.Organization);
            this.fetchStrategy.LoadWith<GeneralJournalDocument>(c => c.RecModifiedByUser);
            this.fetchStrategy.LoadWith<GeneralJournalDocument>(c => c.RecCreatedByUser);

            this.fetchStrategy.LoadWith<GeneralJournalDocument>(c => c.NumberSequence);
        }
    }

}