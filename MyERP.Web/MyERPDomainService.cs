using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel.DomainServices.Server;
using System.ServiceModel.DomainServices.Server.ApplicationServices;
using System.Web.ApplicationServices;
using System.Web.Security;
using MyERP.DataAccess;
using MyERP.DataAccess.Shared;
using Telerik.OpenAccess;

namespace MyERP.Web
{
    public partial class MyERPDomainService
    {
        private MyERPMembershipUser _membershipUser;
        public override void Initialize(DomainServiceContext context)
        {
            base.Initialize(context);
            _membershipUser = (MyERPMembershipUser)Membership.GetUser(context.User.Identity.Name, true);

        }

        #region NumberSequences
        public void DeleteNumberSequences(NumberSequence numberSequence)
        {
            // This is a callback method. The actual Delete is performed internally.
        }

        public void UpdateNumberSequences(NumberSequence numberSequence)
        {
            // This is a callback method. The actual Update is performed internally.
        }

        public void InsertNumberSequences(NumberSequence numberSequence)
        {
            string SqlQuery = String.Format("CREATE SEQUENCE {0} MINVALUE {1} MAXVALUE {2} START {3}", new object[] { numberSequence.NoSeqName, numberSequence.StartingNo, numberSequence.EndingNo, numberSequence.CurrentNo });
            using (var connection = this.DataContext.Connection)
            {
                // 3. Create a new instance of the OACommand class.
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = SqlQuery;
                    command.ExecuteNonQuery();
                }
            }

        } 
        #endregion

        #region GeneralJournalDocument
        [Invoke]
        public GeneralJournalDocument GetGeneralJournalDocumentNos(GeneralJournalDocument generalJournalDocument)
        {
            //lay NoSeries cua GeneralJournalSetup
            var generalJournalSetup = GetGeneralJournalSetupOfOrganization(generalJournalDocument.OrganizationId);
            generalJournalDocument.NumberSequenceId = generalJournalSetup.GeneralJournalNumberSequenceId;

            generalJournalDocument.DocumentNo =
                NoSeriesLib.NextNo(generalJournalSetup.GeneralJournalNumberSequence.NoSeqName,
                    generalJournalSetup.GeneralJournalNumberSequence.FormatNo);

            return generalJournalDocument;
        }
        #endregion

        #region GeneralJournalSetup
        [Invoke]
        public GeneralJournalSetup GetGeneralJournalSetupOfOrganization(Guid organizationId)
        {
            Organization allOrganization = GetOrganizations().FirstOrDefault(c => c.Code == "*");

            GeneralJournalSetup generalJournalSetup = 
               GetGeneralJournalSetups().FirstOrDefault(c => c.OrganizationId == organizationId) ??
               GetGeneralJournalSetups().FirstOrDefault(c => c.OrganizationId == allOrganization.Id);

            return generalJournalSetup;
        }
        #endregion

        #region Sequence service
        public int SequenceNextVal(string sequenceName)
        {
            string SqlQuery = String.Format("SELECT nextval('{0}')", new object[] { sequenceName });
            using (var connection = this.DataContext.Connection)
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = SqlQuery;
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        #endregion

        #region Dashboard services
        public DashboardStats GetDashboardStats()
        {
            var stats = new DashboardStats() { };
            return stats;
        }
        #endregion
    }
}