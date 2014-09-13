using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
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
            this.fetchStrategy.LoadWith<GeneralJournalDocument>(c => c.GeneralJournalLines);
        }

        public override IQueryable<GeneralJournalDocument> GetAll(IPrincipal principal)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            var allEntities = GetAll().Where(c => c.ClientId == membershipUser.ClientId);

            return allEntities;
        }
    }

}