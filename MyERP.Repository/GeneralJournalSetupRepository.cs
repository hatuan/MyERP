using System;
using System.ComponentModel.Composition;
using System.ServiceModel.DomainServices.Client;
using MyERP.DataAccess;

namespace MyERP.Repositories
{
    [Export]
    public class GeneralJournalSetupRepository : RepositoryBase
    {
        public void GetGeneralJournalSetupOfOrganization(Guid organizationId, Action<GeneralJournalSetup> callback)
        {
            this.Context.GetGeneralJournalSetupOfOrganization(organizationId, 
                operation => callback(operation.Value),
                null);
        }
    }
}
