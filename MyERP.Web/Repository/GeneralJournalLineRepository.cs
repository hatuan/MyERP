using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using MyERP.DataAccess;
using MyERP.Web.Models;
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

        public override IQueryable<GeneralJournalLine> GetAll(IPrincipal principal)
        {
            var preference = HttpContext.Current.Session["Preference"] as PreferenceViewModel;

            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);
            var allEntities =
                GetAll()
                    .Where(
                        c =>
                            c.ClientId == membershipUser.ClientId &&
                            (c.OrganizationId == preference.Organization.Id));

            return allEntities;
        }
    }

}