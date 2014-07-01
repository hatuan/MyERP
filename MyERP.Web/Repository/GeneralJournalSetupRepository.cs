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

        public override IQueryable<GeneralJournalSetup> GetAll(IPrincipal principal)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            var allEntities = GetAll().Where(c => c.ClientId == membershipUser.ClientId);

            return allEntities;
        }
    }

}