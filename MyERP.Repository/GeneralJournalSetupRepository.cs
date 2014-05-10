using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using MyERP.DataAccess;

namespace MyERP.Repositories
{
    [Export]
    public class GeneralJournalSetupRepository : RepositoryBase
    {
        public void GetGeneralJournalSetupOfOrganization(Guid organizationId, Action<GeneralJournalSetup> callback)
        {
            EntityQuery<GeneralJournalSetup> currentGeneralJournalSetup =
                this.Context.GetGeneralJournalSetupsQuery().Where(c => c.OrganizationId == organizationId);

            this.LoadQuery(currentGeneralJournalSetup, (generalJournalSetupOfCurrentOrganization) =>
            {
                if (generalJournalSetupOfCurrentOrganization == null)
                {
                    GetGeneralJournalSetupOfAllOrganization(callback);
                }
                else
                    callback(generalJournalSetupOfCurrentOrganization);
            });

        }

        public void GetGeneralJournalSetupOfAllOrganization(Action<GeneralJournalSetup> callback)
        {
            Organization allOrganization = this.Context.Organizations.FirstOrDefault(c => c.Code == "*");

            EntityQuery<GeneralJournalSetup> allGeneralJournalSetup =
                this.Context.GetGeneralJournalSetupsQuery().Where(c => c.OrganizationId == allOrganization.Id);

            this.LoadQuery(allGeneralJournalSetup, callback);
        }
    }
}
